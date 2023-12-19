Imports System.Data.Sql
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Globalization

Public Class FormAbsensiKhusus
    Dim tgl_awal, tgl_akhir As Date
    Dim nik As String

    Dim bulan, tahun As String
    Dim rpt As New ReportDocument
    Dim CRtxtjudul, CRtxtNB, CRtxtcatatan As CrystalDecisions.CrystalReports.Engine.TextObject


    Private Sub load_CmbOpt(ByVal combo As ComboBox)
        With combo.Items
            .Add("Departemen")
            .Add("Status Karyawan")
        End With
    End Sub

    Private Sub load_CmbFilter(ByVal combo_opt As ComboBox, ByVal combo As ComboBox)
        Select Case combo_opt.Text
            Case "Departemen"
                load_combo(Combo_filter, "departemen", "tbl_jabatan")
            Case "Status Karyawan"
                load_combo(Combo_filter, "status_karyawan", "tbl_jabatan")
        End Select
    End Sub

    Private Sub load_grid_karyawan(ByVal grid As DataGridView, ByVal Opt As String)
        Try
            clear_command()
            openDB()
            Select Case Opt
                Case String.Empty
                    sql = "SELECT nik, nama, departemen, jabatan, atasan, status_karyawan FROM view_dtpegawai"
                Case "Pencarian"
                    sql = "SELECT nik, nama, departemen, jabatan, atasan, status_karyawan FROM view_dtpegawai " & _
                    "WHERE nama LIKE '%" & Text_pencarian.Text & "%'"
                Case "departemen"
                    sql = "SELECT nik, nama, departemen, jabatan, atasan, status_karyawan FROM view_dtpegawai " & _
                    "WHERE departemen = '" & Combo_filter.Text & "' OR status_karyawan = '" & Combo_filter.Text & "'"
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            grid.DataSource = DTab
            atur_gridkary(grid)
            grid.Refresh()
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data karyawan " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub atur_gridkary(ByVal grid As DataGridView)
        With grid
            .ReadOnly = True
            .Enabled = True
            .Columns(0).HeaderText = "NIK"
            .Columns(0).Width = "80"
            .Columns(0).Frozen = True
            .Columns(1).HeaderText = "Nama"
            .Columns(1).Width = "180"
            .Columns(1).Frozen = True
            .Columns(2).HeaderText = "Departemen"
            .Columns(2).Width = "180"
            .Columns(3).HeaderText = "Jabatan"
            .Columns(3).Width = "150"
            .Columns(4).HeaderText = "Atasan"
            .Columns(4).Visible = False
            .Columns(5).HeaderText = "Status Karyawan"
            .Columns(5).Width = "80"
            .RowHeadersWidth = 5
        End With
    End Sub

    Private Sub load_dataabsen(ByVal grid As DataGridView)
        Try
            clear_command()
            openDB()
            Cursor.Current = Cursors.WaitCursor
            sql = "IF OBJECT_ID('tempdb..#temp') IS NOT NULL " & _
                "Truncate TABLE #temp else create table #temp (tanggal date,nik varchar(14), " & _
                "nama varchar(255), departemen varchar(255)) " & _
                "declare @nama varchar(255) = (SELECT nama FROM view_dtpegawai WHERE nik = @nik) " & _
                "declare @departemen varchar(255) = (SELECT departemen FROM view_dtpegawai WHERE nik = @nik ) " & _
                "while @tmpDate<=@endDate " & _
                "begin insert into #temp values (@tmpDate,@nik,@nama,@departemen) " & _
                "set @tmpDate = dateadd(day,1,@tmpDate) End " & _
                "SELECT temp2.nik, temp2.nama, temp2.departemen , temp2.tanggal," & _
                "(CASE WHEN DATENAME(dw, temp2.tanggal) = 'Monday' THEN 'Senin' " & _
                "WHEN DATENAME(dw, temp2.tanggal) = 'Tuesday' THEN 'Selasa' " & _
                "WHEN DATENAME(dw, temp2.tanggal) = 'Wednesday' THEN 'Rabu' " & _
                "WHEN DATENAME(dw, temp2.tanggal) = 'Thursday' THEN 'Kamis' " & _
                "WHEN DATENAME(dw, temp2.tanggal) = 'Friday' THEN 'Jumat' " & _
                "WHEN DATENAME(dw, temp2.tanggal) = 'Saturday' THEN 'Sabtu' " & _
                "WHEN DATENAME(dw, temp2.tanggal) = 'Sunday' THEN 'Minggu' END) as hari," & _
                "tbl_dataabsen .timein , tbl_dataabsen .timeout , temp2.ket " & _
                "FROM (SELECT #temp.tanggal , #temp.nama , #temp.nik , #temp.departemen, " & _
                "(CASE WHEN tbl_rekapkerja.tanggal = #temp.tanggal AND " & _
                "tbl_rekapkerja.status  = 'catatan' THEN tbl_rekapkerja.catatan " & _
                "WHEN tbl_rekapkerja.tanggal = #temp.tanggal AND " & _
                "tbl_rekapkerja.status  <> 'catatan' THEN tbl_rekapkerja.status ELSE NULL  END)as ket FROM #temp LEFT OUTER JOIN " & _
                "tbl_rekapkerja ON #temp.tanggal = tbl_rekapkerja .tanggal " & _
                "AND #temp.nik COLLATE DATABASE_DEFAULT = tbl_rekapkerja .nik COLLATE DATABASE_DEFAULT) AS temp2 " & _
                "LEFT OUTER JOIN tbl_dataabsen ON " & _
                "temp2.tanggal = tbl_dataabsen.tanggal AND temp2.nik COLLATE DATABASE_DEFAULT = tbl_dataabsen.nik COLLATE DATABASE_DEFAULT " & _
                "ORDER BY temp2.tanggal "
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@i", SqlDbType.Int).Value = 1
                .Add("@endDate", SqlDbType.Date).Value = DT_tglakhir.Text
                .Add("@tmpDate", SqlDbType.Date).Value = DT_tglawal.Text
                .Add("@nik", SqlDbType.VarChar).Value = nik
                        End With
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            grid.DataSource = DTab
            atur_gridabsen(grid)
            grid.Refresh()
        Catch ex As Exception
            MsgBox("gagal dalam menampilkan database " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Cursor.Current = Cursors.Arrow
            Conn.Close()
        End Try
    End Sub

    Private Sub atur_gridabsen(ByVal grid As DataGridView)
        With grid
            .ReadOnly = True
            .Enabled = True
            .Columns(0).HeaderText = "NIK"
            .Columns(0).Width = "80"
            .Columns(0).Frozen = True
            .Columns(1).HeaderText = "Nama"
            .Columns(1).Width = "160"
            .Columns(1).Frozen = True
            .Columns(2).HeaderText = "Departemen"
            .Columns(2).Width = "110"
            .Columns(3).HeaderText = "Tanggal"
            .Columns(3).Width = "100"
            .Columns(4).HeaderText = "Hari"
            .Columns(4).Width = "80"
            .Columns(5).HeaderText = "Timein"
            .Columns(5).Width = "80"
            .Columns(6).HeaderText = "Timeout"
            .Columns(6).Width = "80"
            .Columns(7).HeaderText = "Keterangan"
            .Columns(7).Width = "200"
            .RowHeadersWidth = 5
            For A% = 1 To grid.RowCount - 1
                If .Rows(A).Cells(4).Value = "Minggu" Then
                    .Rows(A).DefaultCellStyle.BackColor = Color.Red
                End If
            Next
        End With
    End Sub

    Private Sub DT_tglawal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_tglawal.ValueChanged
        format_tanggal(DT_tglawal)
    End Sub

    Private Sub DT_tglakhir_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_tglakhir.ValueChanged
        format_tanggal(DT_tglakhir)
    End Sub

    Private Sub FormAbsensiKhusus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New CultureInfo("id-ID")
        clear_date(Me, Group_periode)
        load_CmbOpt(Combo_Opt)
        load_grid_karyawan(Grid_karyawan, Nothing)
        load_cmbjenisLap(Combo_JLaporan)
    End Sub

    Private Sub Combo_Opt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_Opt.SelectedIndexChanged
        Combo_filter.Text = String.Empty
        Combo_filter.Items.Clear()
        Label_filter.Text = Combo_Opt.Text
        load_CmbFilter(Combo_Opt, Combo_filter)
    End Sub

    Private Sub Combo_filter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_filter.SelectedIndexChanged
        load_grid_karyawan(Grid_karyawan, "departemen")
    End Sub

    Private Sub Grid_karyawan_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid_karyawan.CellContentDoubleClick
        If DT_tglawal.Text = " " Or DT_tglawal.Text = String.Empty Then
            MsgBox("Periode tidak boleh kosong ", MsgBoxStyle.Information, "INFO")
        ElseIf DT_tglakhir.Text = " " Or DT_tglakhir.Text = String.Empty Then
            MsgBox("Periode tidak boleh kosong ", MsgBoxStyle.Information, "INFO")
        Else
            With Grid_karyawan
                nik = .Rows(.CurrentRow.Index).Cells(0).Value
            End With
            load_dataabsen(grid_dtabsen)
        End If
    End Sub

    Private Sub load_cmbjenisLap(ByVal combo As ComboBox)
        With combo.Items
            .Add("Rekap Absen Masa Percobaan")
            .Add("Rekap Absen Kecelakaan Kerja")
        End With
    End Sub

    Private Sub Button_cetak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_cetak.Click

        tahun = Year(DT_tglawal.Text)
        bulan = convert_namabulan(DT_tglawal.Text)
        Try
            
            If Combo_JLaporan.Text = "Rekap Absen Masa Percobaan" Then
                rpt = New Lapabsenbulanan
                            'rpt.Load(Application.StartupPath & "\reports\LapDaftarCuti.rpt")
                'rpt.SetDatabaseLogon(user:=uid, password:=pass)
                rpt.SetDataSource(DTab)
                rpt.SetParameterValue(0, (convert_namabulan(DT_tglawal.Text) & " " & Year(DT_tglawal.Text)))
            ElseIf Combo_JLaporan.Text = "Rekap Absen Kecelakaan Kerja" Then
                rpt = New LaporanKecKerja
                            'rpt.Load(Application.StartupPath & "\reports\LaporanKecKerja.rpt")
                'rpt.SetDatabaseLogon(user:=uid, password:=pass)
                rpt.SetDataSource(DTab)
                CRtxtcatatan = CType(rpt.ReportDefinition.ReportObjects.Item("TextCatatan"), 
                    CrystalDecisions.CrystalReports.Engine.TextObject)
                rpt.SetParameterValue(0, (convert_namabulan(DT_tglawal.Text) & " " & Year(DT_tglawal.Text)))
                CRtxtcatatan.Text = Text_ket.Text
            End If

            FormLaporan.CrystalReportViewer1.ReportSource = rpt
            FormLaporan.ShowDialog()
            FormLaporan.Dispose()
        Catch Ex As Exception
            MsgBox("Gagal dalam menampilkan laporan " & Ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        MsgBox(bulan)
    End Sub

    Private Sub Grid_karyawan_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid_karyawan.CellContentClick

    End Sub

    Private Sub Combo_JLaporan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_JLaporan.SelectedIndexChanged
        If Combo_JLaporan.Text = "Rekap Absen Masa Percobaan" Then
            Text_ket.Visible = False
            Label_catatan.Visible = False
            Group_cetak.Size = New Point(627, 50)
            Button_cetak.Location = New Point(297, 13)
        ElseIf Combo_JLaporan.Text = "Rekap Absen Kecelakaan Kerja" Then
            Text_ket.Visible = True
            Label_catatan.Visible = True
            Group_cetak.Size = New Point(627, 150)
            Button_cetak.Location = New Point(391, 93)
        End If
    End Sub

    Private Sub Text_pencarian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_pencarian.TextChanged
        load_grid_karyawan(Grid_karyawan, "Pencarian")
    End Sub
End Class