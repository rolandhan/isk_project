Imports System.Data.Sql
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Globalization

Public Class FormDaftarCuti
    Dim rpt As New ReportDocument
    Dim tahun As String

    Private Sub FormDaftarCuti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New CultureInfo("id-ID")
        load_combo(Combo_Dept, "departemen", "tbl_jabatan")
        format_tanggal_kosong(DTawal)
        format_tanggal_kosong(DTAkhir)
    End Sub

    Private Sub LoadDataCuti(ByVal grid As DataGridView, ByVal departemen As String)
        Try
            clear_command()
            openDB()
            tahun = (Year(CDate(DTAkhir.Text))).ToString
            If departemen = String.Empty Then
                sql = "SELECT DISTINCT ROW_NUMBER() OVER(ORDER BY view_dtpegawai.nik ASC) AS No, " & _
                "view_dtpegawai.nama ,view_dtpegawai.nik, view_dtpegawai.departemen, " & _
                "view_dtpegawai.status_karyawan,view_dtpegawai.atasan, CONVERT(VARCHAR(10),temp.tgl1 ,105) as tgl1, " & _
                "CONVERT(VARCHAR(10),temp.tgl2 ,105) as tgl2, CONVERT(VARCHAR(10),temp.tgl3 ,105) as tgl3, " & _
                "CONVERT(VARCHAR(10),temp.tgl4 ,105) as tgl4, CONVERT(VARCHAR(10),temp.tgl5 ,105) as tgl5, " & _
                "CONVERT(VARCHAR(10),temp.tgl6 ,105) as tgl6 FROM (SELECT DISTINCT T.NIK, t1.TANGGAL AS tgl1, t2.TANGGAL  AS tgl2," & _
                "t3.TANGGAL  AS tgl3, t4.TANGGAL  AS tgl4, t5.TANGGAL  AS tgl5, t6.TANGGAL  AS tgl6 FROM tbl_rekapkerja t " & _
                "OUTER APPLY (SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY nik ASC) AS No, [nik], [TANGGAL] FROM tbl_rekapkerja " & _
                "WHERE nik = t.nik and TANGGAL between @tglawal AND @tglakhir AND status = 'cuti') AS temp WHERE temp.no = 1) t1 " & _
                "OUTER APPLY (SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY nik ASC) AS No, [nik], [TANGGAL] FROM tbl_rekapkerja " & _
                "WHERE nik = t.nik and TANGGAL between @tglawal AND @tglakhir AND status = 'cuti' ) AS temp WHERE temp.no = 2) t2 " & _
                "OUTER APPLY (SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY nik ASC) AS No, [nik], [TANGGAL] FROM tbl_rekapkerja " & _
                "WHERE nik = t.nik and TANGGAL between @tglawal AND @tglakhir AND status = 'cuti' ) AS temp WHERE temp.no = 3) t3 " & _
                "OUTER APPLY (SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY nik ASC) AS No, [nik], [TANGGAL] FROM tbl_rekapkerja " & _
                "WHERE nik = t.nik and TANGGAL between @tglawal AND @tglakhir AND status = 'cuti' ) AS temp WHERE temp.no = 4) t4 " & _
                "OUTER APPLY (SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY nik ASC) AS No, [nik], [TANGGAL] FROM tbl_rekapkerja " & _
                "WHERE nik = t.nik and TANGGAL between @tglawal AND @tglakhir AND status = 'cuti' ) AS temp WHERE temp.no = 5) t5 " & _
                "OUTER APPLY (SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY nik ASC) AS No, [nik], [TANGGAL] FROM tbl_rekapkerja " & _
                "WHERE nik = t.nik and TANGGAL between @tglawal AND @tglakhir AND status = 'cuti' ) AS temp WHERE temp.no = 6) t6 ) as temp " & _
                "RIGHT OUTER JOIN view_dtpegawai ON temp.NIK = view_dtpegawai.nik ORDER BY view_dtpegawai.nik"
            Else
                sql = "SELECT DISTINCT ROW_NUMBER() OVER(ORDER BY view_dtpegawai.nik ASC) AS No, " & _
                "view_dtpegawai.nama ,view_dtpegawai.nik, view_dtpegawai.departemen, " & _
                "view_dtpegawai.status_karyawan,view_dtpegawai.atasan, CONVERT(VARCHAR(10),temp.tgl1 ,105) as tgl1, " & _
                "CONVERT(VARCHAR(10),temp.tgl2 ,105) as tgl2, CONVERT(VARCHAR(10),temp.tgl3 ,105) as tgl3, " & _
                "CONVERT(VARCHAR(10),temp.tgl4 ,105) as tgl4, CONVERT(VARCHAR(10),temp.tgl5 ,105) as tgl5, " & _
                "CONVERT(VARCHAR(10),temp.tgl6 ,105) as tgl6 FROM (SELECT DISTINCT T.NIK, t1.TANGGAL AS tgl1, t2.TANGGAL  AS tgl2," & _
                "t3.TANGGAL  AS tgl3, t4.TANGGAL  AS tgl4, t5.TANGGAL  AS tgl5, t6.TANGGAL  AS tgl6 FROM tbl_rekapkerja t " & _
                "OUTER APPLY (SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY nik ASC) AS No, [nik], [TANGGAL] FROM tbl_rekapkerja " & _
                "WHERE nik = t.nik and TANGGAL between @tglawal AND @tglakhir AND status = 'cuti') AS temp WHERE temp.no = 1) t1 " & _
                "OUTER APPLY (SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY nik ASC) AS No, [nik], [TANGGAL] FROM tbl_rekapkerja " & _
                "WHERE nik = t.nik and TANGGAL between @tglawal AND @tglakhir AND status = 'cuti' ) AS temp WHERE temp.no = 2) t2 " & _
                "OUTER APPLY (SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY nik ASC) AS No, [nik], [TANGGAL] FROM tbl_rekapkerja " & _
                "WHERE nik = t.nik and TANGGAL between @tglawal AND @tglakhir AND status = 'cuti' ) AS temp WHERE temp.no = 3) t3 " & _
                "OUTER APPLY (SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY nik ASC) AS No, [nik], [TANGGAL] FROM tbl_rekapkerja " & _
                "WHERE nik = t.nik and TANGGAL between @tglawal AND @tglakhir AND status = 'cuti' ) AS temp WHERE temp.no = 4) t4 " & _
                "OUTER APPLY (SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY nik ASC) AS No, [nik], [TANGGAL] FROM tbl_rekapkerja " & _
                "WHERE nik = t.nik and TANGGAL between @tglawal AND @tglakhir AND status = 'cuti' ) AS temp WHERE temp.no = 5) t5 " & _
                "OUTER APPLY (SELECT * FROM (SELECT ROW_NUMBER() OVER(ORDER BY nik ASC) AS No, [nik], [TANGGAL] FROM tbl_rekapkerja " & _
                "WHERE nik = t.nik and TANGGAL between @tglawal AND @tglakhir AND status = 'cuti' ) AS temp WHERE temp.no = 6) t6 ) as temp " & _
                "RIGHT OUTER JOIN view_dtpegawai ON temp.NIK = view_dtpegawai.nik WHERE view_dtpegawai.departemen = @departemen ORDER BY view_dtpegawai.nik"
            End If
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@tglawal", SqlDbType.Date).Value = DTawal.Text
                .Add("@tglakhir", SqlDbType.Date).Value = DTAkhir.Text
                .Add("@departemen", SqlDbType.VarChar).Value = departemen
            End With
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            grid.DataSource = DTab
            atur_gridcuti(grid_cuti)
            grid.Refresh()
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data cuti " & ex.Message)
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub atur_gridcuti(ByVal grid As DataGridView)
        With grid
            .ReadOnly = True
            .Enabled = True
            .Columns(0).HeaderText = "No"
            .Columns(0).Width = "30"
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).Frozen = True
            .Columns(1).HeaderText = "Nama"
            .Columns(1).Width = "180"
            .Columns(1).Frozen = True
            .Columns(2).HeaderText = "NIK"
            .Columns(2).Width = "80"
            .Columns(2).Frozen = True
            .Columns(3).HeaderText = "Departemen"
            .Columns(3).Visible = False
            .Columns(4).HeaderText = "status karyawan"
            .Columns(4).Visible = False
            .Columns(5).HeaderText = "atasan"
            .Columns(5).Visible = False
            .Columns(6).HeaderText = "I"
            .Columns(6).Width = "80"
            .Columns(7).HeaderText = "II"
            .Columns(7).Width = "80"
            .Columns(8).HeaderText = "III"
            .Columns(8).Width = "80"
            .Columns(9).HeaderText = "IV"
            .Columns(9).Width = "80"
            .Columns(10).HeaderText = "V"
            .Columns(10).Width = "80"
            .Columns(11).HeaderText = "VI"
            .Columns(11).Width = "80"
            .RowHeadersWidth = 5
            End With
    End Sub

    Private Sub DTawal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTawal.ValueChanged
        format_tanggal(DTawal)
    End Sub

    Private Sub DTAkhir_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTAkhir.ValueChanged
        format_tanggal(DTAkhir)
    End Sub

    Private Sub Combo_Dept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_Dept.SelectedIndexChanged
        If DTawal.Text = " " Or DTawal.Text = String.Empty Then
            MsgBox("Tolong isikan periode terlebih dahulu", MsgBoxStyle.Information, "INFO")
        Else
            Label_dept.Text = Combo_Dept.Text
            LoadDataCuti(grid_cuti, Combo_Dept.Text)
        End If
    End Sub

    Private Sub Button_cetak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_cetak.Click
        Try
            ' rpt = New LapDaftarCuti
            rpt.Load(Application.StartupPath & "\reports\LapDaftarCuti.rpt")
            'rpt.SetDatabaseLogon(user:=uid, password:=pass)
            rpt.SetDataSource(DTab)
            rpt.SetParameterValue(0, tahun)
            FormLaporan.CrystalReportViewer1.ReportSource = rpt
            FormLaporan.ShowDialog()
            FormLaporan.Dispose()
            FormLaporan.WindowState = FormWindowState.Maximized
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan laporan " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub



End Class