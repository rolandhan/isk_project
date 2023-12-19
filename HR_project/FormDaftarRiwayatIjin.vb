Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports VB = Microsoft.VisualBasic.Strings
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class FormDaftarRiwayatIjin
    Dim jenis_tab As String
    Dim rpt As New reportdocument

    Private Sub FormDaftarRiwayatIjin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        format_tanggal_kosong(DT_awal)
        format_tanggal_kosong(DT_akhir)
    End Sub

    Private Sub loadgrid_data(ByVal grid As DataGridView, ByVal opt As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            Select Case opt
                Case "pencarian"
                    sql = "SELECT nik, nama, jabatan, departemen FROM view_dtpegawai " & _
                        "WHERE nik LIKE '%" & Text_nik.Text & "%' OR nama LIKE '%" & Text_nik.Text & "%'"
                Case "data ijin"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY nik ASC) AS No, NIK, HARI, TANGGAL, " & _
                        "LAMA_CUTI, MULAI_CUTI, TANGGAL_MASUK, ID_CUTI, STATUS, periode, ket FROM tbl_cuti " & _
                        "WHERE MULAI_CUTI BETWEEN @awal AND @akhir " & _
                        "AND nik = @nik ORDER BY MULAI_CUTI"
                Case "data imp"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY nik ASC) AS No, " & _
                        "nik, hari, tanggal, jam, status, alasan, id_ijin, periode, jam_kembali FROM tbl_ijin " & _
                        "WHERE tanggal BETWEEN @awal AND @akhir AND nik = @nik ORDER BY tanggal"
                Case "data telat"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY nik ASC) AS No, " & _
                        "nik, hari, tanggal, telat, alasan, id_telat FROM tbl_telat " & _
                        "WHERE tanggal BETWEEN @awal AND @akhir  AND nik = @nik ORDER BY tanggal"
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            If Not opt = "pencarian" Then
                With sqlcmd.Parameters
                    .Add("@awal", SqlDbType.Date).Value = DT_awal.Text
                    .Add("@akhir", SqlDbType.Date).Value = DT_akhir.Text
                    .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                End With
            End If
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
                sqladapter.Fill(DTab)
                grid.DataSource = DTab
                atur_grid(grid, opt)
                grid.Refresh()
        Catch ex As Exception
            MsgBox("Gagal dalam memuat data " & opt & " karena " & ex.Message, MsgBoxStyle.Critical, "INFO")
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cetak_data(ByVal opt As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            Select Case opt
                Case "data ijin"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY nik ASC) AS No, NIK, HARI, TANGGAL, " & _
                        "LAMA_CUTI, MULAI_CUTI, TANGGAL_MASUK, ID_CUTI, STATUS, periode, ket FROM tbl_cuti " & _
                        "WHERE MULAI_CUTI BETWEEN @awal AND @akhir " & _
                        "AND nik = @nik ORDER BY MULAI_CUTI"
                Case "data imp"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY nik ASC) AS No, " & _
                        "nik, hari, tanggal, jam, status, alasan, id_ijin, periode, jam_kembali FROM tbl_ijin " & _
                        "WHERE tanggal BETWEEN @awal AND @akhir AND nik = @nik ORDER BY tanggal"
                Case "data telat"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY nik ASC) AS No, " & _
                        "nik, hari, tanggal, telat, alasan, id_telat FROM tbl_telat " & _
                        "WHERE tanggal BETWEEN @awal AND @akhir  AND nik = @nik ORDER BY tanggal"
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            If Not opt = "pencarian" Then
                With sqlcmd.Parameters
                    .Add("@awal", SqlDbType.Date).Value = DT_awal.Text
                    .Add("@akhir", SqlDbType.Date).Value = DT_akhir.Text
                    .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                End With
            End If
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
        Catch ex As Exception
            MsgBox("Gagal dalam memuat cetak data " & opt & " karena " & ex.Message, MsgBoxStyle.Critical, "INFO")
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub atur_grid(ByVal grid As DataGridView, ByVal opt As String)
        With grid
            Select Case opt
                Case "pencarian"
                    .ReadOnly = True
                    .Enabled = True
                    .Columns(0).HeaderText = "NIK"
                    .Columns(0).Width = "80"
                    .Columns(1).HeaderText = "Nama"
                    .Columns(1).Width = "200"
                    .Columns(2).HeaderText = "Jabatan"
                    .Columns(2).Width = "200"
                    .Columns(3).HeaderText = "Departemen"
                    .Columns(3).Width = "200"
                    .RowHeadersWidth = 4
                Case "data ijin"
                    .ReadOnly = True
                    .Enabled = True
                    .Columns(0).HeaderText = "No"
                    .Columns(0).Width = "50"
                    .Columns(1).HeaderText = "NIK"
                    .Columns(1).Visible = False
                    .Columns(2).HeaderText = "Hari"
                    .Columns(2).Width = "150"
                    .Columns(3).HeaderText = "Tanggal"
                    .Columns(3).Visible = False
                    .Columns(4).HeaderText = "Lama"
                    .Columns(4).Visible = False
                    .Columns(5).HeaderText = "mulai_Cuti"
                    .Columns(5).Width = "150"
                    .Columns(6).HeaderText = "tanggal_masuk"
                    .Columns(6).Visible = False
                    .Columns(7).HeaderText = "id_cuti"
                    .Columns(7).Visible = False
                    .Columns(8).HeaderText = "status"
                    .Columns(8).Width = "200"
                    .Columns(9).HeaderText = "Periode"
                    .Columns(9).Visible = False
                    .Columns(10).HeaderText = "Ket"
                    .Columns(10).Width = "400"
                    .RowHeadersWidth = 11
                Case "data imp"
                    .ReadOnly = True
                    .Enabled = True
                    .Columns(0).HeaderText = "No"
                    .Columns(0).Width = "50"
                    .Columns(1).HeaderText = "NIK"
                    .Columns(1).Visible = False
                    .Columns(2).HeaderText = "hari"
                    .Columns(2).Width = "150"
                    .Columns(3).HeaderText = "tanggal"
                    .Columns(3).Width = "150"
                    .Columns(4).HeaderText = "jam"
                    .Columns(4).Visible = False
                    .Columns(5).HeaderText = "Status"
                    .Columns(5).Width = "200"
                    .Columns(6).HeaderText = "Alasan"
                    .Columns(6).Width = "400"
                    .Columns(7).HeaderText = "id_ijin"
                    .Columns(7).Visible = False
                    .Columns(8).HeaderText = "Periode"
                    .Columns(8).Visible = False
                    .Columns(9).HeaderText = "Jam kembali"
                    .Columns(9).Visible = False
                    .RowHeadersWidth = 10
                Case "data telat"
                    .ReadOnly = True
                    .Enabled = True
                    .Columns(0).HeaderText = "No"
                    .Columns(0).Width = "50"
                    .Columns(1).HeaderText = "NIK"
                    .Columns(1).Visible = False
                    .Columns(2).HeaderText = "hari"
                    .Columns(2).Width = "150"
                    .Columns(3).HeaderText = "tanggal"
                    .Columns(3).Width = "150"
                    .Columns(4).HeaderText = "telat"
                    .Columns(4).Width = "100"
                    .Columns(5).HeaderText = "Alasan"
                    .Columns(5).Width = "400"
                    .Columns(5).HeaderText = "id telat"
                    .Columns(5).Visible = False
                    .RowHeadersWidth = 5
            End Select
        End With
    End Sub

    Private Sub DT_awal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_awal.ValueChanged
        format_tanggal(DT_awal)
    End Sub

    Private Sub DT_akhir_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_akhir.ValueChanged
        format_tanggal(DT_akhir)
    End Sub

    Private Sub Button_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_go.Click
        loadgrid_data(grid_ijin, "data ijin")
        loadgrid_data(grid_imp, "data imp")
        loadgrid_data(grid_telat, "data telat")
    End Sub

    Private Sub Text_nik_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_nik.TextChanged
        loadgrid_data(grid_cari, "pencarian")
        grid_cari.Visible = True
        grid_cari.BringToFront()
    End Sub

    Private Sub grid_cari_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_cari.CellContentDoubleClick
        With grid_cari
            Text_nama.Text = .Rows(.CurrentRow.Index).Cells(1).Value
            Text_jabatan.Text = .Rows(.CurrentRow.Index).Cells(2).Value
            Text_dept.Text = .Rows(.CurrentRow.Index).Cells(3).Value
            Text_nik.Text = .Rows(.CurrentRow.Index).Cells(0).Value
            grid_cari.Visible = False
            grid_cari.DataSource = Nothing
        End With
    End Sub

    Private Sub Button_cetak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_cetaktlt.Click

        Try
            With rpt
                cetak_data("data telat")
                'rpt = New Lapdaftartelat
                .Load(Application.StartupPath & "\reports\Lapdaftartelat.rpt")
                '.SetDatabaseLogon(user:=uid, password:=pass)
                .SetDataSource(DTab)
                .SetParameterValue(0, Text_nama.Text)
                .SetParameterValue(1, Text_dept.Text)
                .SetParameterValue(2, Text_nik.Text)
                .SetParameterValue(3, Year(DT_awal.Text))
                .SetParameterValue(4, Year(DT_akhir.Text))
                FormLaporan.CrystalReportViewer1.ReportSource = rpt
                FormLaporan.ShowDialog()
                FormLaporan.Dispose()
                FormLaporan.WindowState = FormWindowState.Maximized
            End With
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan laporan " & jenis_tab & " " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab Is tabijin Then
            jenis_tab = "data ijin"
        ElseIf TabControl1.SelectedTab Is tabimp Then
            jenis_tab = "data imp"
        ElseIf TabControl1.SelectedTab Is Tabtelat Then
            jenis_tab = "data telat"
        End If
    End Sub

    Private Sub Button_cetakijin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_cetakijin.Click
        Try
            With rpt
                cetak_data("data ijin")
                'rpt = New LapdaftarIjin
                .Load(Application.StartupPath & "\reports\LapdaftarIjin.rpt")
                '.SetDatabaseLogon(user:=uid, password:=pass)
                .SetDataSource(DTab)
                .SetParameterValue(0, Text_nama.Text)
                .SetParameterValue(1, Text_dept.Text)
                .SetParameterValue(2, Text_nik.Text)
                .SetParameterValue(3, Year(DT_awal.Text))
                .SetParameterValue(4, Year(DT_akhir.Text))
                FormLaporan.CrystalReportViewer1.ReportSource = rpt
                FormLaporan.ShowDialog()
                FormLaporan.Dispose()
                FormLaporan.WindowState = FormWindowState.Maximized
            End With
        Catch ex As Exception
            MsgBox("gagal menampilkan laporan " & ex.Message)
        End Try
    End Sub

    Private Sub Button_cetakimp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_cetakimp.Click
        Try
            With rpt
                cetak_data("data imp")
                'rpt = New Lapdaftarimp
                .Load(Application.StartupPath & "\reports\Lapdaftarimp.rpt")
                '.SetDatabaseLogon(user:=uid, password:=pass)
                .SetDataSource(DTab)
                .SetParameterValue(0, Text_nama.Text)
                .SetParameterValue(1, Text_dept.Text)
                .SetParameterValue(2, Text_nik.Text)
                .SetParameterValue(3, Year(DT_awal.Text))
                .SetParameterValue(4, Year(DT_akhir.Text))
                FormLaporan.CrystalReportViewer1.ReportSource = rpt
                FormLaporan.ShowDialog()
                FormLaporan.Dispose()
                FormLaporan.WindowState = FormWindowState.Maximized
            End With
        Catch ex As Exception
            MsgBox("gagal menampilkan laporan " & ex.Message)
        End Try
    End Sub

    Private Sub Button_baru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_baru.Click
        Clear_text(Me, Nothing)
        clear_date(Me, Nothing)
    End Sub

    Private Sub Buttonkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonkeluar.Click
        Me.Close()
    End Sub
End Class