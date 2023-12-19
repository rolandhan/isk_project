Imports System.IO
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Globalization
Imports System.Xml.Serialization
Imports System.Xml
Imports System.ComponentModel

Public Class FormRekapAbsen
    Private awal, akhir As Date
    Private def_tahun As Integer
    Dim DtTab As DataTable
    Dim departemen As String
    Dim Kondisi_khusus, Filterkhusus As String
    'Dim Rpt As New ReportDocument
    Dim KodeLap, NamaManager, NamaStaf As String
    Dim stopwatch As New System.Diagnostics.Stopwatch()
    Dim FilePath As String = Application.StartupPath & "\config_report.txt"
    Private WithEvents backgroundWorkers As New List(Of BackgroundWorker)
    Private JenisFilter, Filter, NamaJab, Nama As String
    Dim FormLap As New FormLaporan

    Private Sub FormRekapAbsen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New CultureInfo("id-ID")
        'loading_grid()
        clear_date(Me, Group_periode)
        load_departemen()
        Worker1.WorkerReportsProgress = True
        worker2.WorkerReportsProgress = True
        worker3.WorkerReportsProgress = True
        WorkerDtHarian.WorkerReportsProgress = True
        WorkerTimer.WorkerReportsProgress = True
        WorkerLaporan.WorkerReportsProgress = True
        WorkerTahunan.WorkerReportsProgress = True
        Worker1.WorkerSupportsCancellation = True
        worker2.WorkerSupportsCancellation = True
        worker3.WorkerSupportsCancellation = True
        WorkerDtHarian.WorkerSupportsCancellation = True
        WorkerLaporan.WorkerSupportsCancellation = True
        WorkerTimer.WorkerSupportsCancellation = True
        WorkerTahunan.WorkerSupportsCancellation = True
    End Sub



    Private Sub load_cmbkary(ByVal combo As ComboBox)
        With combo
            .Items.Add("KARYAWAN")
            .Items.Add("HARIAN SEMENTARA")
        End With
    End Sub

    Private Sub loading_grid()
        Try
            clear_command()
            openDB()
            awal = CDate("01-01-" & Now.Year)
            akhir = CDate("31-12-" & Now.Year)
            sql = "SELECT dbo.view_dtpegawai.nik, dbo.view_dtpegawai.nama, dbo.view_dtpegawai.departemen, dbo.view_dtpegawai.jabatan, " & _
                "dbo.view_dtpegawai.status_karyawan, " & _
                "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti' AND dbo.tbl_rekapkerja.tanggal BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(akhir, "yyyy/M/d") & "' THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'ijin' AND dbo.tbl_rekapkerja.tanggal BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(akhir, "yyyy/M/d") & "' THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin, " & _
                "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'sakit' AND dbo.tbl_rekapkerja.tanggal BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(akhir, "yyyy/M/d") & "' THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'kd' AND dbo.tbl_rekapkerja.tanggal BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(akhir, "yyyy/M/d") & "' THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND dbo.tbl_rekapkerja.tanggal BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(akhir, "yyyy/M/d") & "' THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND dbo.tbl_rekapkerja.tanggal BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(akhir, "yyyy/M/d") & "' THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = '1 jam' AND dbo.tbl_rekapkerja.tanggal BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(akhir, "yyyy/M/d") & "' THEN 1 ELSE NULL END) AS imp_satujam, " & _
                "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'setengah hari' AND dbo.tbl_rekapkerja.tanggal BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(akhir, "yyyy/M/d") & "' THEN 1 ELSE NULL END) AS imp_sethari, " & _
                "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = '1 jam' AND dbo.tbl_rekapkerja.tanggal BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(akhir, "yyyy/M/d") & "' THEN 1 ELSE NULL END) + " & _
                "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'setengah hari' AND dbo.tbl_rekapkerja.tanggal BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(akhir, "yyyy/M/d") & "' THEN 1 ELSE NULL END) AS total_imp, " & _
                "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND dbo.tbl_rekapkerja.tanggal BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(akhir, "yyyy/M/d") & "' THEN 1 ELSE NULL END) AS telat, " & _
                "YEAR('" & Format(awal, "yyyy/M/d") & "') as periode,dbo.view_dtpegawai.atasan, " & _
                "(SELECT ', ' + dbo.tbl_rekapkerja.catatan  FROM dbo.tbl_rekapkerja " & _
                "WHERE dbo.tbl_rekapkerja.nik = dbo.view_dtpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                "BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(awal, "yyyy/M/d") & "' FOR XML PATH ('')) as catatan " & _
                "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                "dbo.view_dtpegawai ON dbo.tbl_rekapkerja.nik = dbo.view_dtpegawai.nik " & _
                "GROUP BY dbo.view_dtpegawai.nik, dbo.view_dtpegawai.nama, dbo.view_dtpegawai.departemen, dbo.view_dtpegawai.jabatan, " & _
                "dbo.view_dtpegawai.status_karyawan,dbo.view_dtpegawai.atasan"
            sqladapter = New SqlDataAdapter(sql, Conn)
            'dtset = New DataSet
            'dtset.Clear()
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            'sqladapter.Fill(dtset, "dbo.tbl_rekapkerja RIGHT OUTER JOIN dbo.view_dtpegawai ON dbo.tbl_rekapkerja.nik = dbo.view_dtpegawai.nik")
            'grid_karyawan.DataSource = dtset.Tables("dbo.tbl_rekapkerja RIGHT OUTER JOIN dbo.view_dtpegawai ON dbo.tbl_rekapkerja.nik = dbo.view_dtpegawai.nik")
            grid_karyawan.DataSource = DTab
            atur_grid()
            grid_karyawan.Refresh()
        Catch Ex As Exception
            MsgBox("gagal menampilkan data " & Ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub atur_grid()
        If Radio_bulanan.Checked = True Then
            With grid_karyawan
                .ReadOnly = True
                .Columns(0).HeaderText = "NIK"
                .Columns(0).Width = 70
                .Columns(0).Frozen = True
                .Columns(1).HeaderText = "Nama"
                .Columns(1).Width = 180
                .Columns(1).Frozen = True
                .Columns(2).HeaderText = "Departemen"
                .Columns(2).Width = 100
                .Columns(3).HeaderText = "Jabatan"
                .Columns(3).Width = 180
                '.Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                '.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                .Columns(4).HeaderText = "status"
                .Columns(4).Width = 120
                .Columns(5).HeaderText = "cuti"
                .Columns(5).Width = 50
                .Columns(6).HeaderText = "ijin"
                .Columns(6).Width = 50
                .Columns(7).HeaderText = "sakit"
                .Columns(7).Width = 50
                .Columns(8).HeaderText = "kd"
                .Columns(8).Width = 50
                .Columns(9).HeaderText = "alfa"
                .Columns(9).Width = 50
                .Columns(10).HeaderText = "kusus"
                .Columns(10).Width = 50
                .Columns(11).HeaderText = "1jam"
                .Columns(11).Width = 50
                .Columns(12).HeaderText = "1/2 hari"
                .Columns(12).Width = 50
                .Columns(13).HeaderText = "telat"
                .Columns(13).Width = 50
                .Columns(14).HeaderText = "periode"
                .Columns(14).Width = 60
                .Columns(15).HeaderText = "atasan"
                .Columns(15).Visible = False
                .Columns(16).HeaderText = "catatan"
                .Columns(16).Width = 180
                .Columns(17).Visible = False
                '.Columns(16).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                .RowHeadersWidth = 60
            End With
        ElseIf Radio_triwulan.Checked = True Then
            With grid_karyawan
                .ReadOnly = True
                .Enabled = True
                .Columns(0).HeaderText = "NIK"
                .Columns(0).Width = 70
                .Columns(0).Frozen = True
                .Columns(1).HeaderText = "Nama"
                .Columns(1).Width = 180
                .Columns(1).Frozen = True
                .Columns(2).HeaderText = "Departemen"
                .Columns(2).Width = 100
                .Columns(3).HeaderText = "Jabatan"
                .Columns(3).Width = 120
                '.Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                '.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                .Columns(4).HeaderText = "status"
                .Columns(4).Width = 65
                .Columns(5).HeaderText = "cuti"
                .Columns(5).Width = 50
                .Columns(6).HeaderText = "ijin"
                .Columns(6).Width = 50
                .Columns(7).HeaderText = "sakit"
                .Columns(7).Width = 50
                .Columns(8).HeaderText = "kd"
                .Columns(8).Width = 50
                .Columns(9).HeaderText = "alfa"
                .Columns(9).Width = 50
                .Columns(10).HeaderText = "kusus"
                .Columns(10).Visible = False
                .Columns(11).HeaderText = "jumlah"
                .Columns(11).Width = 50
                .Columns(12).HeaderText = "IMP"
                .Columns(12).Width = 50
                .Columns(13).HeaderText = "Telat"
                .Columns(13).Width = 50
                .Columns(14).HeaderText = "periode"
                .Columns(14).Width = 60
                .Columns(15).HeaderText = "Atasan"
                .Columns(15).Visible = False
                .Columns(16).HeaderText = "catatan"
                .Columns(16).Width = 200
                .Columns(17).Visible = False
                '.Columns(16).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                .RowHeadersWidth = 60

            End With
        ElseIf Radio_tahunan.Checked = True Then
            With grid_karyawan
                .ReadOnly = True
                .Enabled = True
                .Columns(0).HeaderText = "NIK"
                .Columns(0).Width = 70
                .Columns(1).HeaderText = "Nama"
                .Columns(1).Width = 180
                .Columns(2).HeaderText = "Departemen"
                .Columns(2).Width = 100
                .Columns(3).HeaderText = "Jabatan"
                .Columns(3).Width = 120
                .Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                '.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                .Columns(4).HeaderText = "status"
                .Columns(4).Width = 50
                .Columns(5).HeaderText = "cuti"
                .Columns(5).Width = 50
                .Columns(6).HeaderText = "ijin"
                .Columns(6).Width = 50
                .Columns(7).HeaderText = "sakit"
                .Columns(7).Width = 50
                .Columns(8).HeaderText = "kd"
                .Columns(8).Width = 50
                .Columns(9).HeaderText = "alfa"
                .Columns(9).Width = 50
                .Columns(10).HeaderText = "kusus"
                .Columns(10).Visible = False
                .Columns(11).HeaderText = "jumlah"
                .Columns(11).Width = 50
                .Columns(12).HeaderText = "IMP"
                .Columns(12).Width = 50
                .Columns(13).HeaderText = "Telat"
                .Columns(13).Width = 50
                .Columns(14).HeaderText = "periode"
                .Columns(14).Width = 60
                .Columns(15).HeaderText = "atasan"
                .Columns(15).Visible = False
                .Columns(16).HeaderText = "catatan"
                .Columns(16).Width = 200
                .Columns(17).Visible = False
                .Columns(16).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                .RowHeadersWidth = 60
            End With
        End If
    End Sub

    Private Sub AturGridHarian()
        With grid_karyawan
            .ReadOnly = True
            .Columns(0).HeaderText = "NIK"
            .Columns(0).Width = 70
            .Columns(0).Frozen = True
            .Columns(1).HeaderText = "Nama"
            .Columns(1).Width = 180
            .Columns(1).Frozen = True
            .Columns(2).HeaderText = "Departemen"
            .Columns(2).Width = 100
            .Columns(3).HeaderText = "Jabatan"
            .Columns(3).Width = 180
            '.Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .Columns(4).HeaderText = "status"
            .Columns(4).Width = 120
            .Columns(5).HeaderText = "cuti"
            .Columns(5).Width = 50
            .Columns(6).HeaderText = "ijin"
            .Columns(6).Width = 50
            .Columns(7).HeaderText = "sakit"
            .Columns(7).Width = 50
            .Columns(8).HeaderText = "kd"
            .Columns(8).Width = 50
            .Columns(9).HeaderText = "alfa"
            .Columns(9).Width = 50
            .Columns(10).HeaderText = "kusus"
            .Columns(10).Width = 50
            .Columns(11).HeaderText = "1jam"
            .Columns(11).Width = 50
            .Columns(12).HeaderText = "1/2 hari"
            .Columns(12).Width = 50
            .Columns(13).HeaderText = "IMP"
            .Columns(13).Width = 50
            .Columns(14).HeaderText = "telat"
            .Columns(14).Width = 50
            .Columns(15).HeaderText = "periode"
            .Columns(15).Width = 60
            .Columns(16).HeaderText = "atasan"
            .Columns(16).Visible = False
            .Columns(17).HeaderText = "catatan"
            .Columns(17).Width = 180
            '.Columns(17).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .RowHeadersWidth = 60
        End With
    End Sub

    Private Sub Button_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_go.Click
        If Check_harian.Checked = True Then
            load_combo(Combo_dept, "departemen", "view_tglpegawai WHERE status_karyawan LIKE 'Harian%'")
            If Not WorkerDtHarian.IsBusy Then
                WorkerDtHarian.RunWorkerAsync()
            End If
        Else
            Combo_dept.Items.Clear()
            Combo_dept.Text = String.Empty
            Combo_khusus.Items.Clear()
            Combo_khusus.Text = String.Empty
            If DT_tgldari.Text = " " Then
                MsgBox("Tanggal awal periode tidak boleh kosong", MsgBoxStyle.Information, "INFO")
            ElseIf DT_tglke.Text = " " Then
                MsgBox("Tanggal akhir periode tidak boleh kosong", MsgBoxStyle.Information, "INFO")
            End If
            JenisFilter = String.Empty
            If Not Worker1.IsBusy Then
                Worker1.RunWorkerAsync()
            End If
                load_combo(Combo_dept, "departemen", "tbl_jabatan WHERE departemen <> 'Direksi'")
                load_combobagkhusus()
        End If
    End Sub


    Private Sub LoadLaporanBulanan(ByVal Condition As String, ByVal filter As String)
        Select Case Condition
            Case String.Empty
                sql = "SELECT * FROM (SELECT temp.nik, temp.nama, temp.departemen, temp.jabatan, temp.status_karyawan, " & _
                    "temp.total_cuti, temp.total_ijin, temp.total_sakit, temp.total_kd, temp.total_alfa, temp.total_cutikusus, " & _
                    "temp.imp_satujam, temp.imp_sethari, temp.total_imp, temp.telat, temp.periode, temp.atasan, temp.catatan FROM  " & _
                    "(SELECT  view_dtpegawai.nik,view_dtpegawai.nama,view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                    "view_dtpegawai.status_karyawan , COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                    "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin," & _
                    "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                    "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                    "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND  " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                    "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                    "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                    "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'satu jam' AND " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS imp_satujam, " & _
                    "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'setengah hari' AND " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS imp_sethari, " & _
                    "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                    "YEAR(@awal) as periode, dbo.view_dtpegawai.atasan, " & _
                    "SUBSTRING((SELECT ', ' + dbo.tbl_rekapkerja.catatan  FROM dbo.tbl_rekapkerja " & _
                    "WHERE dbo.tbl_rekapkerja.nik = view_dtpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                    "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                    "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                    "view_dtpegawai ON tbl_rekapkerja.nik = view_dtpegawai.nik " & _
                    "GROUP BY view_dtpegawai.nik, view_dtpegawai.nama, view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                    "view_dtpegawai.status_karyawan ,view_dtpegawai.atasan) As temp " & _
                    "WHERE temp.jabatan NOT like 'Manager%'  AND temp.jabatan NOT like 'Kepala Bagian%' " & _
                    "AND temp.jabatan NOT like 'KaBag%' " & _
                    "AND temp.jabatan NOT like  'Direktur%') AS Temp2  ORDER BY Temp2.nik"
            Case "Departemen"
                sql = "SELECT * FROM (SELECT * FROM  " & _
                    "(SELECT  view_dtpegawai.nik,view_dtpegawai.nama,view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                    "view_dtpegawai.status_karyawan , COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                    "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin," & _
                    "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                    "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                    "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND  " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                    "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                    "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                    "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'satu jam' AND " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS imp_satujam, " & _
                    "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'setengah hari' AND " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS imp_sethari, " & _
                    "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                    "YEAR(@awal) as periode, dbo.view_dtpegawai.atasan, " & _
                    "SUBSTRING((SELECT ', ' + dbo.tbl_rekapkerja.catatan  FROM dbo.tbl_rekapkerja " & _
                    "WHERE dbo.tbl_rekapkerja.nik = view_dtpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                    "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                    "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                    "view_dtpegawai ON tbl_rekapkerja.nik = view_dtpegawai.nik " & _
                    "GROUP BY view_dtpegawai.nik, view_dtpegawai.nama, view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                    "view_dtpegawai.status_karyawan ,view_dtpegawai.atasan) As temp " & _
                    "WHERE(temp.jabatan NOT like 'Manager%' ) AND (temp.jabatan NOT like 'Kepala Bagian%') " & _
                    "AND (temp.jabatan NOT like 'KaBag%') " & _
                    "AND (temp.jabatan NOT like 'Direktur%')) AS T_Temp WHERE " & _
                    "T_Temp.departemen = '" & filter & "' ORDER BY T_Temp.nik"
            Case "Bagian Khusus"
                sql = "SELECT * FROM (SELECT * FROM  " & _
                    "(SELECT  view_dtpegawai.nik,view_dtpegawai.nama,view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                    "view_dtpegawai.status_karyawan , COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                    "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin," & _
                    "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                    "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                    "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND  " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                    "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                    "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                    "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'satu jam' AND " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS imp_satujam, " & _
                    "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'setengah hari' AND " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS imp_sethari, " & _
                    "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                    "YEAR(@awal) as periode, dbo.view_dtpegawai.atasan, " & _
                    "SUBSTRING((SELECT ', ' + dbo.tbl_rekapkerja.catatan  FROM dbo.tbl_rekapkerja " & _
                    "WHERE dbo.tbl_rekapkerja.nik = view_dtpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                    "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                    "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                    "view_dtpegawai ON tbl_rekapkerja.nik = view_dtpegawai.nik " & _
                    "GROUP BY view_dtpegawai.nik, view_dtpegawai.nama, view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                    "view_dtpegawai.status_karyawan ,view_dtpegawai.atasan) As temp ) AS T_Temp " & _
                    "WHERE T_temp.atasan = '" & filter & "' AND ( T_temp.jabatan LIKE 'Manager%' OR " & _
                    "T_temp.jabatan LIKE 'Kepala Bagian%' OR T_temp.jabatan LIKE 'KaBag%') ORDER BY T_Temp.nik"
                sqlcmd = New SqlCommand(sql, Conn)
                sqlcmd.Parameters.Add("@awal", SqlDbType.Date).Value = DT_tgldari.Text
                sqlcmd.Parameters.Add("@akhir", SqlDbType.Date).Value = DT_tglke.Text
                sqladapter = New SqlDataAdapter
                sqladapter.SelectCommand = sqlcmd
                DTab = New DataTable
                DTab.Clear()
                sqladapter.Fill(DTab)
                grid_karyawan.DataSource = DTab
                atur_grid()
                grid_karyawan.Refresh()
        End Select
    End Sub


    Private Sub load_dtharians(ByVal grid As DataGridView, ByVal condition As String)
        If DT_tgldari.Text = " " Then
            MsgBox("Tanggal awal periode tidak boleh kosong", MsgBoxStyle.Information, "INFO")
        ElseIf DT_tglke.Text = " " Then
            MsgBox("Tanggal akhir periode tidak boleh kosong", MsgBoxStyle.Information, "INFO")
        End If
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "SELECT * FROM (SELECT * FROM  " & _
                "(SELECT  view_dtpegawai.nik,view_dtpegawai.nama,view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                "view_dtpegawai.status_karyawan , COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin, " & _
                "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit,  " & _
                "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND " & _
                "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'satu jam' AND " & _
                "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS imp_satujam, " & _
                "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'setengah hari' AND " & _
                "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS imp_sethari, " & _
                "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'satu jam' AND " & _
                "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) + " & _
                "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'setengah hari' AND " & _
                "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS total_imp, " & _
                "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                "YEAR(@awal) as periode, dbo.view_dtpegawai.atasan, " & _
                "SUBSTRING((SELECT ', ' + dbo.tbl_rekapkerja.catatan  FROM dbo.tbl_rekapkerja " & _
                "WHERE dbo.tbl_rekapkerja.nik = view_dtpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                "view_dtpegawai ON tbl_rekapkerja.nik = view_dtpegawai.nik " & _
                "GROUP BY view_dtpegawai.nik, view_dtpegawai.nama, view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                "view_dtpegawai.status_karyawan ,view_dtpegawai.atasan) As temp " & _
                "WHERE temp.status_karyawan = 'Harian Sementara' OR " & _
                "temp.status_karyawan = 'Keluar - Harian Sementara' ) AS T_Temp ORDER BY T_Temp.nik "
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@awal", SqlDbType.Date).Value = DT_tgldari.Text
                .Add("@akhir", SqlDbType.Date).Value = DT_tglke.Text
            End With
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            Select Case condition
                Case String.Empty
                    sqladapter.Fill(DTab)
                    grid.DataSource = DTab
                    atur_grid()
                    grid.Refresh()
                Case "cetak"
                    sqladapter.Fill(DTab)
            End Select
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data harian sementara " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    'mengisi combo bagian khusus, manual karena bagian khusus tidak bisa di lakukan  pemanggilan otomatis
    Private Sub load_combobagkhusus()
        Try
            ' Membaca daftar nama dari file .txt
            Dim names As New List(Of String)()
            Using reader As New StreamReader(FilePath)
                Dim line As String
                Do
                    line = reader.ReadLine()
                    If line IsNot Nothing Then
                        names.Add(line)
                    End If
                Loop Until line Is Nothing
            End Using

            ' Menampilkan daftar nama di DataGridView
            'grid_nama.Rows.Clear()
            'atur_grid(grid_nama)
            For Each name As String In names
                Combo_khusus.Items.Add(name)
            Next
            Combo_khusus.DataSource = Nothing
            'MessageBox.Show("Daftar nama telah dimuat dari file .txt.")
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat membaca file: " & ex.Message)
        End Try
    End Sub

    'memuat file XML
    Private Sub LoadFromXMLfile(ByVal filename As String, ByVal combo As ComboBox)
        Dim xmldoc As New XmlDocument
        Dim xmlnode As XmlNodeList
        Dim fs As New FileStream(FilePath, FileMode.Open, FileAccess.Read)
        Try
            combo.Items.Clear()
            xmldoc.Load(fs)
            xmlnode = xmldoc.GetElementsByTagName("daftar_nama")
            For i% = 0 To xmlnode.Count - 1
                xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
                combo.Items.Add(xmlnode(i).ChildNodes.Item(0).InnerText.Trim())
            Next
        Catch ex As Exception
        Finally
            xmldoc = Nothing
            fs.Dispose()
            fs.Close()
        End Try
    End Sub



    Private Sub DT_tgldari_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_tgldari.ValueChanged
        DT_tgldari.Refresh()
        format_tanggal(DT_tgldari)
        awal = CDate(DT_tgldari.Text)
    End Sub

    Private Sub DT_tglke_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_tglke.ValueChanged
        DT_tglke.Refresh()
        format_tanggal(DT_tglke)
        akhir = CDate(DT_tglke.Text)
    End Sub


    Private Function cek_periode() As String
        If CDate(DT_tgldari.Text) > CDate("25-09-" & Year(DT_tgldari.Value)) And CDate(DT_tglke.Text) < CDate("26-12-" & Year(DT_tglke.Value)) Then
            Return "I"
        ElseIf CDate(DT_tgldari.Text) > CDate("25-12-" & (CInt(Year(DT_tgldari.Value)))) And CDate(DT_tglke.Text) < CDate("26-03-" & Year(DT_tglke.Value) + 1) Then
            Return "II"
        ElseIf CDate(DT_tgldari.Text) > CDate("25-03-" & Year(DT_tgldari.Text)) And CDate(DT_tglke.Text) < CDate("26-06-" & Year(DT_tglke.Value)) Then
            Return "III"
        ElseIf CDate(DT_tgldari.Text) > CDate("25-06-" & Year(DT_tgldari.Text)) And CDate(DT_tglke.Text) < CDate("26-09-" & Year(DT_tglke.Value)) Then
            Return "IV"
        End If
        Return Nothing
    End Function

    'memanggil data untuk format laporan triwulan yang berisi nama pegawai , nama Manager HRD & GA 
    Private Sub GetDataLapTriwulan()
        Try
            Dim FilePath As String = Application.StartupPath & "\config_report.ini"
            KodeLap = readini(FilePath, "setting Config triwulan", "kode_laporan", "")
            NamaManager = readini(FilePath, "setting Config triwulan", "manager", "")
            NamaStaf = readini(FilePath, "setting Config triwulan", "bag_administrasi", "")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetLaporanBulanan()
        TampilLabel(LabelMemuat, True)
        If Not WorkerTimer.IsBusy Then
            stopwatch.Reset()
            WorkerTimer.RunWorkerAsync()
        End If
        CRReportDocument = New ReportDocument
        With CRReportDocument
            .Load(Application.StartupPath & "\reports\LaporanBulanan.rpt")
            .SetDatabaseLogon(user:=txt_id, password:=txt_pwd)
            .SetDataSource(DTab)
            .SetParameterValue(0, (ConvertBln(DT_tglke.Text).ToUpper))
            .SetParameterValue(1, (ConvertTanggal(DT_tgldari.Text).ToUpper))
            .SetParameterValue(2, (ConvertTanggal(DT_tglke.Text).ToUpper))
            .SetParameterValue(3, departemen)
            With grid_karyawan
                CRReportDocument.SetParameterValue(4, .Rows(0).Cells(15).Value)
            End With
        End With
        
        'FormLaporan.CrystalReportViewer1.ReportSource = Rpt
        'jika prosedur invoke di butuhkan untuk menghindari illegal cross thread
        'FormLaporan.ShowDialog()
        FormLaporan.CrystalReportViewer1.ReportSource = CRReportDocument
        TampilLabel(LabelProcess, False)
        TampilLabel(LabelMemuat, False)
        FormLaporan.ShowDialog()
        WorkerTimer.CancelAsync()
    End Sub

    Private Sub SetlaporanTriwulan()
        'jika prosedur invoke di butuhkan untuk menghindari illegal cross thread
        TampilLabel(LabelMemuat, True)
        If Not WorkerTimer.IsBusy Then
            stopwatch.Reset()
            WorkerTimer.RunWorkerAsync()
        End If
        CRReportDocument = New ReportDocument
        With CRReportDocument
            .Load(Application.StartupPath & "\reports\Laporan_triwulan.rpt")
            .SetDatabaseLogon(user:=txt_id, password:=txt_pwd)
            .SetDataSource(DTab)
            .SetParameterValue(0, (DT_tglke.Value.AddMonths(0).ToString("MMMM")).ToUpper & " " & Year(DT_tglke.Text))
            .SetParameterValue(1, (ConvertBln(DT_tgldari.Text).ToUpper))
            .SetParameterValue(3, departemen)
            .SetParameterValue(2, (ConvertBlnTahun(DT_tglke.Text).ToUpper))
            .SetParameterValue(5, ("Klaten, " & ConvertTanggal(Now)))
            .SetParameterValue(6, (cek_periode()))
            .SetParameterValue(7, NamaStaf)
            .SetParameterValue(8, NamaManager)
            .SetParameterValue(9, KodeLap)
        End With
       
        FormLaporan.CrystalReportViewer1.ReportSource = CRReportDocument
        'jika prosedur invoke di butuhkan untuk menghindari illegal cross thread
        TampilLabel(LabelProcess, False)
        TampilLabel(LabelMemuat, False)
        FormLaporan.ShowDialog()
        WorkerTimer.CancelAsync()
    End Sub

    Private Sub SetLaporanTahunan()
        'jika prosedur invoke di butuhkan untuk menghindari illegal cross thread
        TampilLabel(LabelMemuat, True)
        If Not WorkerTimer.IsBusy Then
            stopwatch.Reset()
            WorkerTimer.RunWorkerAsync()
        End If
        'Rpt = New LaporanTahunan
        CRReportDocument = New ReportDocument
        With CRReportDocument
            .Load(Application.StartupPath & "\reports\LaporanTahunan.rpt")
            .SetDatabaseLogon(user:=txt_id, password:=txt_pwd)
            .SetDataSource(DTab)
            .SetParameterValue(0, (DT_tglke.Value.AddMonths(0).ToString("MMMM")).ToUpper & " " & Year(DT_tglke.Text))
            .SetParameterValue(1, (CDate(DT_tgldari.Text)))
            .SetParameterValue(2, (CDate(DT_tgldari.Text)))
            .SetParameterValue(3, departemen)
            .SetParameterValue(5, ("Klaten, " & ConvertTanggal(Now)))
            .SetParameterValue(6, NamaStaf)
            .SetParameterValue(7, NamaManager)
        End With
       
        FormLaporan.CrystalReportViewer1.ReportSource = CRReportDocument
        'jika prosedur invoke di butuhkan untuk menghindari illegal cross thread
        FormLaporan.ShowDialog()
        TampilLabel(LabelProcess, False)
        TampilLabel(LabelMemuat, False)
        FormLaporan.ShowDialog()
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim Task0 As New Thread(AddressOf GetDataLapTriwulan)
        'Task0.Start()
        If Not WorkerLaporan.IsBusy Then
            WorkerLaporan.RunWorkerAsync()
        End If
        If Check_harian.Checked = True Then
            If Combo_dept.Text = String.Empty Then
                CancelAllWorkers()
                MessageBox.Show(Me, "Silahkan memilih departemen ", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                    departemen = Combo_dept.Text
                If Not WorkerTriwulan.IsBusy Then
                    WorkerTriwulan.RunWorkerAsync()
                End If
            End If
        Else
            If Combo_dept.Text = String.Empty And Combo_khusus.Text = String.Empty Then
                MessageBox.Show("SIlahkan memilih departemen atau bagian khusus terlebih dahulu", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf Combo_dept.Text <> String.Empty And Combo_khusus.Text = String.Empty Then
                If Radio_bulanan.Checked = True Then

                    departemen = Combo_dept.Text
                    If Not WorkerBulanan.IsBusy Then
                        WorkerBulanan.RunWorkerAsync()
                    End If

                ElseIf Radio_triwulan.Checked = True Then
                    If cek_periode() Is Nothing Then
                        CancelAllWorkers()
                        Me.Invoke(Sub()
                                      MessageBox.Show(Me.MdiParent, "Pemilihan rentang periode tidak sesuai", "Kesalahan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                      Button1.Enabled = True
                                  End Sub)
                    Else
                        departemen = Combo_dept.Text
                        If Not WorkerTriwulan.IsBusy Then
                            WorkerTriwulan.RunWorkerAsync()
                        End If
                    End If
                ElseIf Radio_tahunan.Checked = True Then
                    departemen = Combo_dept.Text
                    'Dim task2 As New Thread(AddressOf SetLaporanTahunan)
                    'task2.Start()
                    If Not WorkerTahunan.IsBusy Then
                        WorkerTahunan.RunWorkerAsync()
                    End If
                End If
            ElseIf Combo_dept.Text = String.Empty And Combo_khusus.Text <> String.Empty Then
                If Not worker3.IsBusy Then
                    worker3.RunWorkerAsync()
                End If
                If Radio_bulanan.Checked = True Then
                    Nama = Combo_khusus.Text
                    If Not WorkerBulanan.IsBusy Then
                        WorkerBulanan.RunWorkerAsync()
                    End If

                ElseIf Radio_triwulan.Checked = True Then
                    If cek_periode() Is Nothing Then
                        MessageBox.Show("Pemilihan rentang periode tidak sesuai", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        Nama = Combo_khusus.Text
                        If Not WorkerTriwulan.IsBusy Then
                            WorkerTriwulan.RunWorkerAsync()
                        End If
                    End If
                ElseIf Radio_tahunan.Checked = True Then
                    Nama = Combo_khusus.Text
                    'Dim task2 As New Thread(AddressOf SetLaporanTahunan)
                    'task2.Start()
                    'CancelAllWorkers()
                    If Not WorkerTahunan.IsBusy Then
                        WorkerTahunan.RunWorkerAsync()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub load_departemen()
        fill_combo(Combo_dept, "departemen", "tbl_jabatan")
    End Sub

    Private Sub Combo_dept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_dept.SelectedIndexChanged
            CancelAllWorkers()
            Combo_khusus.Text = String.Empty
            Combo_khusus.Refresh()
            JenisFilter = "Departemen"
            Filter = Combo_dept.Text
            If Check_harian.Checked = True Then
                If Not WorkerDtHarian.IsBusy Then
                    WorkerDtHarian.RunWorkerAsync()
                End If
            Else
                If Not Worker1.IsBusy Then
                    Worker1.RunWorkerAsync()
                End If
            End If

    End Sub

    Private Sub Combo_khusus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_khusus.SelectedIndexChanged
        Combo_dept.Text = String.Empty
        Combo_dept.Refresh()
        JenisFilter = "Bagian Khusus"
        Filter = Combo_khusus.Text
        If Not Worker1.IsBusy Then
            Worker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub grid_karyawan_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles grid_karyawan.CellFormatting
        grid_karyawan.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)

    End Sub

    Private Sub Check_harian_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_harian.CheckedChanged
        'load_dtharians(grid_karyawan, Nothing)
        If Check_harian.Checked = True Then
            Radio_bulanan.Checked = False
            Radio_tahunan.Checked = False
            Radio_triwulan.Checked = True
            Combo_khusus.Enabled = False
            Combo_dept.Items.Clear()
            load_combo(Combo_dept, "departemen", "tbl_jabatan WHERE departemen <> 'Direksi' AND status_karyawan ='Harian Sementara' ")
        End If
    End Sub


    Private Sub Radio_triwulan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_triwulan.CheckedChanged
        clear_date(Me, Nothing)
        Combo_dept.Text = String.Empty
        Combo_khusus.Text = String.Empty
    End Sub

    Private Sub Radio_tahunan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_tahunan.CheckedChanged
        clear_date(Me, Nothing)
        Combo_dept.Text = String.Empty
        Combo_khusus.Text = String.Empty
    End Sub

    Private Sub Radio_bulanan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_bulanan.CheckedChanged
        clear_date(Me, Nothing)
        Combo_dept.Text = String.Empty
        Combo_khusus.Text = String.Empty
    End Sub



    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Worker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker1.DoWork
        Dim sql1 As String
        If ProgressBar1.InvokeRequired Then
            ProgressBar1.Invoke(Sub() UpdateProgress())
        Else
            UpdateProgress()
        End If
        Try
            clear_command()
            openDB()
            'Cursor.Current = Cursors.AppStarting
            If Radio_bulanan.Checked = True Then
                Select Case JenisFilter
                    Case String.Empty
                        sql = "SELECT * FROM (SELECT temp.nik, temp.nama, temp.departemen, temp.jabatan, temp.status_karyawan, " & _
                            "temp.total_cuti, temp.total_ijin, temp.total_sakit, temp.total_kd, temp.total_alfa, temp.total_cutikusus, " & _
                            "temp.imp_satujam, temp.imp_sethari, temp.telat, temp.periode, temp.atasan, temp.catatan FROM  " & _
                            "(SELECT  view_dtpegawai.nik,view_dtpegawai.nama,view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                            "view_dtpegawai.status_karyawan , COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin," & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND  " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                            "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'satu jam' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS imp_satujam, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'setengah hari' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS imp_sethari, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                            "YEAR(@awal) as periode, dbo.view_dtpegawai.atasan, " & _
                            "SUBSTRING((SELECT ', ' + REPLACE(dbo.tbl_rekapkerja.catatan, CHAR(13), '') FROM dbo.tbl_rekapkerja " & _
                            "WHERE dbo.tbl_rekapkerja.nik = view_dtpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                            "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                            "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                            "view_dtpegawai ON tbl_rekapkerja.nik = view_dtpegawai.nik " & _
                            "GROUP BY view_dtpegawai.nik, view_dtpegawai.nama, view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                            "view_dtpegawai.status_karyawan ,view_dtpegawai.atasan) As temp " & _
                            "WHERE temp.jabatan NOT like 'Manager%'  AND temp.jabatan NOT like 'Kepala Bagian%' " & _
                            "AND temp.jabatan NOT like 'KaBag%' " & _
                            "AND temp.jabatan NOT like  'Direktur%') AS T_Temp  WHERE T_temp.status_karyawan <> 'Harian Sementara' ORDER BY T_Temp.nik"
                        '=============================================================================================================================
                        sql1 = "SELECT * FROM (SELECT temp.nik, temp.nama, temp.departemen, temp.jabatan, temp.status_karyawan, " & _
                            "temp.total_cuti, temp.total_ijin, temp.total_sakit, temp.total_kd, temp.total_alfa, temp.total_cutikusus, " & _
                            "temp.imp_satujam, temp.imp_sethari, temp.telat, temp.periode, temp.atasan, temp.catatan, temp.tgl_keluar FROM " & _
                            "(SELECT  view_tglpegawai.nik,view_tglpegawai.nama,view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                            "view_tglpegawai.status_karyawan ,view_tglpegawai.tgl_keluar, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                            "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'satu jam' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS imp_satujam, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'setengah hari' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS imp_sethari, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                            "YEAR(@awal) as periode, dbo.view_tglpegawai.atasan, " & _
                            "SUBSTRING((SELECT ', ' + REPLACE(dbo.tbl_rekapkerja.catatan, CHAR(13), '') FROM dbo.tbl_rekapkerja " & _
                            "WHERE dbo.tbl_rekapkerja.nik = dbo.view_tglpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                            "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                            "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                            "view_tglpegawai ON tbl_rekapkerja.nik = view_tglpegawai.nik " & _
                            "GROUP BY view_tglpegawai.nik, view_tglpegawai.nama, view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                            "view_tglpegawai.status_karyawan ,view_tglpegawai.atasan, view_tglpegawai.tgl_keluar) As temp " & _
                            "WHERE temp.jabatan NOT like 'Manager%'  AND temp.jabatan NOT like 'Kepala Bagian%' " & _
                            "AND temp.jabatan NOT like 'KaBag%' " & _
                            "AND temp.jabatan NOT like  'Direktur%') AS T_Temp  " & _
                            "WHERE (T_Temp.tgl_keluar IS NULL OR T_Temp.tgl_keluar > @awal) " & _
                            "AND (T_temp.status_karyawan <> 'Harian' OR T_temp.status_karyawan <> 'Harian Sementara' OR T_temp.status_karyawan <> 'Harian Tetap') " & _
                            "ORDER BY T_Temp.nik"
                    Case "Departemen"
                        sql = "SELECT * FROM (SELECT * FROM  " & _
                            "(SELECT  view_dtpegawai.nik,view_dtpegawai.nama,view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                            "view_dtpegawai.status_karyawan , COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin," & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND  " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                            "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'satu jam' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS imp_satujam, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'setengah hari' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS imp_sethari, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                            "YEAR(@awal) as periode, dbo.view_dtpegawai.atasan, " & _
                            "SUBSTRING((SELECT ', ' + REPLACE(dbo.tbl_rekapkerja.catatan, CHAR(13), '') FROM dbo.tbl_rekapkerja " & _
                            "WHERE dbo.tbl_rekapkerja.nik = view_dtpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                            "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                            "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                            "view_dtpegawai ON tbl_rekapkerja.nik = view_dtpegawai.nik " & _
                            "GROUP BY view_dtpegawai.nik, view_dtpegawai.nama, view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                            "view_dtpegawai.status_karyawan ,view_dtpegawai.atasan) As temp " & _
                            "WHERE(temp.jabatan NOT like 'Manager%' ) AND (temp.jabatan NOT like 'Kepala Bagian%') " & _
                            "AND (temp.jabatan NOT like 'KaBag%') " & _
                            "AND (temp.jabatan NOT like 'Direktur%')) AS T_Temp WHERE " & _
                            "T_Temp.departemen = '" & Filter & "' AND T_temp.status_karyawan <> 'Harian Sementara'  ORDER BY T_Temp.nik"
                        '=============================================================================================================================
                        sql1 = "SELECT * FROM (SELECT temp.nik, temp.nama, temp.departemen, temp.jabatan, temp.status_karyawan, " & _
                            "temp.total_cuti, temp.total_ijin, temp.total_sakit, temp.total_kd, temp.total_alfa, temp.total_cutikusus, " & _
                            "temp.imp_satujam, temp.imp_sethari, temp.telat, temp.periode, temp.atasan, temp.catatan, temp.tgl_keluar FROM " & _
                            "(SELECT  view_tglpegawai.nik,view_tglpegawai.nama,view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                            "view_tglpegawai.status_karyawan ,view_tglpegawai.tgl_keluar, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                            "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'satu jam' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS imp_satujam, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'setengah hari' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS imp_sethari, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                            "YEAR(@awal) as periode, dbo.view_tglpegawai.atasan, " & _
                            "SUBSTRING((SELECT ', ' + REPLACE(dbo.tbl_rekapkerja.catatan, CHAR(13), '') FROM dbo.tbl_rekapkerja " & _
                            "WHERE dbo.tbl_rekapkerja.nik = dbo.view_tglpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                            "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                            "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                            "view_tglpegawai ON tbl_rekapkerja.nik = view_tglpegawai.nik " & _
                            "GROUP BY view_tglpegawai.nik, view_tglpegawai.nama, view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                            "view_tglpegawai.status_karyawan ,view_tglpegawai.atasan, view_tglpegawai.tgl_keluar) As temp " & _
                            "WHERE temp.jabatan NOT like 'Manager%'  AND temp.jabatan NOT like 'Kepala Bagian%' " & _
                            "AND temp.jabatan NOT like 'KaBag%' " & _
                            "AND temp.jabatan NOT like  'Direktur%') AS T_Temp  " & _
                            "WHERE (T_Temp.tgl_keluar IS NULL OR T_Temp.tgl_keluar > @awal) " & _
                            "AND (T_temp.status_karyawan <> 'Harian' OR T_temp.status_karyawan <> 'Harian Sementara' OR T_temp.status_karyawan <> 'Harian Tetap') " & _
                            "AND T_Temp.departemen = '" & Filter & "' ORDER BY T_Temp.nik"
                    Case "Bagian Khusus"
                        sql = "SELECT * FROM (SELECT * FROM  " & _
                            "(SELECT  view_dtpegawai.nik,view_dtpegawai.nama,view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                            "view_dtpegawai.status_karyawan , COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin," & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND  " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                            "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'satu jam' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS imp_satujam, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'setengah hari' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS imp_sethari, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                            "YEAR(@awal) as periode, dbo.view_dtpegawai.atasan, " & _
                            "SUBSTRING((SELECT ', ' + REPLACE(dbo.tbl_rekapkerja.catatan, CHAR(13), '')  FROM dbo.tbl_rekapkerja " & _
                            "WHERE dbo.tbl_rekapkerja.nik = view_dtpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                            "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                            "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                            "view_dtpegawai ON tbl_rekapkerja.nik = view_dtpegawai.nik " & _
                            "GROUP BY view_dtpegawai.nik, view_dtpegawai.nama, view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                            "view_dtpegawai.status_karyawan ,view_dtpegawai.atasan) As temp ) AS T_Temp " & _
                            "WHERE T_temp.atasan = '" & Filter & "' AND ( T_temp.jabatan LIKE 'Manager%' OR " & _
                            "T_temp.jabatan LIKE 'Kepala Bagian%' OR T_temp.jabatan LIKE 'KaBag%') AND (T_temp.status_karyawan <> 'Harian Sementara') ORDER BY T_Temp.nik"
                        '=============================================================================================================================
                        sql1 = "SELECT * FROM (SELECT temp.nik, temp.nama, temp.departemen, temp.jabatan, temp.status_karyawan, " & _
                            "temp.total_cuti, temp.total_ijin, temp.total_sakit, temp.total_kd, temp.total_alfa, temp.total_cutikusus, " & _
                            "temp.imp_satujam, temp.imp_sethari, temp.telat, temp.periode, temp.atasan, temp.catatan, temp.tgl_keluar FROM " & _
                            "(SELECT  view_tglpegawai.nik,view_tglpegawai.nama,view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                            "view_tglpegawai.status_karyawan ,view_tglpegawai.tgl_keluar, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                            "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'satu jam' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS imp_satujam, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'setengah hari' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS imp_sethari, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                            "YEAR(@awal) as periode, dbo.view_tglpegawai.atasan, " & _
                            "SUBSTRING((SELECT ', ' + REPLACE(dbo.tbl_rekapkerja.catatan, CHAR(13), '') FROM dbo.tbl_rekapkerja " & _
                            "WHERE dbo.tbl_rekapkerja.nik = dbo.view_tglpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                            "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                            "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                            "view_tglpegawai ON tbl_rekapkerja.nik = view_tglpegawai.nik " & _
                            "GROUP BY view_tglpegawai.nik, view_tglpegawai.nama, view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                            "view_tglpegawai.status_karyawan ,view_tglpegawai.atasan, view_tglpegawai.tgl_keluar) As temp " & _
                            "WHERE temp.jabatan like 'Manager%'  OR temp.jabatan like 'Kepala Bagian%' " & _
                            "OR temp.jabatan like 'KaBag%' " & _
                            "OR temp.jabatan like  'Direktur%') AS T_Temp  " & _
                            "WHERE (T_Temp.tgl_keluar IS NULL OR T_Temp.tgl_keluar > @awal) " & _
                            "AND (T_temp.status_karyawan <> 'Harian' OR T_temp.status_karyawan <> 'Harian Sementara' OR T_temp.status_karyawan <> 'Harian Tetap') " & _
                            "AND T_Temp.atasan = '" & Filter & "' ORDER BY T_Temp.nik"
                End Select
            ElseIf Radio_triwulan.Checked = True Then
                'LabelPeriode.Visible = True
                Select Case JenisFilter
                    Case String.Empty
                        sql = "SELECT * FROM (SELECT * FROM " & _
                                    "(SELECT view_dtpegawai.nik,view_dtpegawai.nama,view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                                    "view_dtpegawai.status_karyawan , COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                                    "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin," & _
                                    "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                                    "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                                    "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND  " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                                    "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                                    "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                                    "COALESCE(SUM(CASE WHEN (tbl_rekapkerja.status = 'ijin' " & _
                                    "OR tbl_rekapkerja.status = 'sakit' OR tbl_rekapkerja.status = 'kd' " & _
                                    "OR tbl_rekapkerja.status = 'alfa') AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) as jumlah, " & _
                                    "COUNT(CASE WHEN tbl_rekapkerja.status = 'satu jam' AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) + " & _
                                    "COUNT(CASE WHEN tbl_rekapkerja.status = 'setengah hari' AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS total_imp, " & _
                                    "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                                    "YEAR(@awal) as periode, dbo.view_dtpegawai.atasan, " & _
                                    "SUBSTRING((SELECT ', ' + REPLACE(dbo.tbl_rekapkerja.catatan, CHAR(13), '')  FROM dbo.tbl_rekapkerja " & _
                                    "WHERE dbo.tbl_rekapkerja.nik = view_dtpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                                    "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                                    "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                                    "view_dtpegawai ON dbo.tbl_rekapkerja.nik = view_dtpegawai.nik " & _
                                    "GROUP BY view_dtpegawai.nik, view_dtpegawai.nama, view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                                    "view_dtpegawai.status_karyawan ,view_dtpegawai.atasan) As temp " & _
                                    "WHERE temp.jabatan NOT like 'Manager%' AND temp.jabatan NOT like 'Kepala Bagian%' " & _
                                    "AND temp.jabatan NOT like 'KaBag%' " & _
                                    "AND temp.jabatan NOT like 'Direktur%') AS T_Temp WHERE T_temp.status_karyawan <> 'Harian Sementara' ORDER BY T_Temp.nik"
                        '===========================================================================================================================
                        sql1 = "SELECT * FROM (SELECT temp.nik, temp.nama, temp.departemen, temp.jabatan, temp.status_karyawan, " & _
                            "temp.total_cuti, temp.total_ijin, temp.total_sakit, temp.total_kd, temp.total_alfa, temp.total_cutikusus, " & _
                            "temp.jumlah, temp.total_imp , temp.telat, temp.periode, temp.atasan, temp.catatan, temp.tgl_keluar  FROM " & _
                            "(SELECT view_tglpegawai.nik,view_tglpegawai.nama,view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                            "view_tglpegawai.status_karyawan , view_tglpegawai.tgl_keluar, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit,  " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                            "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                            "COALESCE(SUM(CASE WHEN (tbl_rekapkerja.status = 'ijin' " & _
                            "OR tbl_rekapkerja.status = 'sakit' OR tbl_rekapkerja.status = 'kd' " & _
                            "OR tbl_rekapkerja.status = 'alfa') AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) as jumlah, " & _
                            "COUNT(CASE WHEN tbl_rekapkerja.status = 'satu jam' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) + " & _
                            "COUNT(CASE WHEN tbl_rekapkerja.status = 'setengah hari' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS total_imp, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                            "YEAR(@awal) as periode, dbo.view_tglpegawai.atasan, " & _
                            "SUBSTRING((SELECT ', ' + REPLACE(dbo.tbl_rekapkerja.catatan, CHAR(13), '')  FROM dbo.tbl_rekapkerja " & _
                            "WHERE dbo.tbl_rekapkerja.nik = view_tglpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                            "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                            "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                            "view_tglpegawai ON dbo.tbl_rekapkerja.nik = view_tglpegawai.nik " & _
                            "GROUP BY view_tglpegawai.nik, view_tglpegawai.nama, view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                            "view_tglpegawai.status_karyawan ,view_tglpegawai.atasan, view_tglpegawai .tgl_keluar ) As temp " & _
                            "WHERE temp.jabatan NOT like 'Manager%' AND temp.jabatan NOT like 'Kepala Bagian%' " & _
                            "AND temp.jabatan NOT like 'KaBag%' " & _
                            "AND temp.jabatan NOT like 'Direktur%') AS T_Temp " & _
                            "WHERE (T_Temp.tgl_keluar IS NULL OR T_Temp.tgl_keluar > @awal) " & _
                            "AND (T_temp.status_karyawan <> 'Harian' OR T_temp.status_karyawan <> 'Harian Sementara' " & _
                            "OR T_temp.status_karyawan <> 'Harian Tetap') ORDER BY T_Temp.nik "
                    Case "Departemen"
                        sql = "SELECT * FROM (SELECT  * FROM " & _
                            "(SELECT view_dtpegawai.nik,view_dtpegawai.nama,view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                            "view_dtpegawai.status_karyawan , COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin," & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND  " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                            "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                            "COALESCE(SUM(CASE WHEN (tbl_rekapkerja.status = 'ijin' " & _
                            "OR tbl_rekapkerja.status = 'sakit' OR tbl_rekapkerja.status = 'kd' " & _
                            "OR tbl_rekapkerja.status = 'alfa') AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) as jumlah, " & _
                            "COUNT(CASE WHEN tbl_rekapkerja.status = 'satu jam' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) + " & _
                            "COUNT(CASE WHEN tbl_rekapkerja.status = 'setengah hari' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS total_imp, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                            "YEAR(@awal) as periode, dbo.view_dtpegawai.atasan, " & _
                            "SUBSTRING((SELECT ', ' + REPLACE(dbo.tbl_rekapkerja.catatan, CHAR(13), '') FROM dbo.tbl_rekapkerja " & _
                            "WHERE dbo.tbl_rekapkerja.nik = view_dtpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                            "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                            "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                            "view_dtpegawai ON dbo.tbl_rekapkerja.nik = view_dtpegawai.nik " & _
                            "GROUP BY view_dtpegawai.nik, view_dtpegawai.nama, view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                            "view_dtpegawai.status_karyawan ,view_dtpegawai.atasan) As temp " & _
                            "WHERE temp.jabatan NOT like 'Manager%' AND temp.jabatan NOT like 'Kepala Bagian%' " & _
                            "AND temp.jabatan NOT like 'Kabag%' " & _
                            "AND temp.jabatan NOT like 'Direktur%') AS T_Temp  WHERE T_Temp.departemen = '" & Filter & "' " & _
                            "AND T_temp.status_karyawan <> 'Harian Sementara'  ORDER BY T_Temp.nik"
                        '=============================================================================================================
                        sql1 = "SELECT * FROM (SELECT temp.nik, temp.nama, temp.departemen, temp.jabatan, temp.status_karyawan, " & _
                            "temp.total_cuti, temp.total_ijin, temp.total_sakit, temp.total_kd, temp.total_alfa, temp.total_cutikusus, " & _
                            "temp.jumlah, temp.total_imp , temp.telat, temp.periode, temp.atasan, temp.catatan, temp.tgl_keluar  FROM " & _
                            "(SELECT view_tglpegawai.nik,view_tglpegawai.nama,view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                            "view_tglpegawai.status_karyawan , view_tglpegawai.tgl_keluar, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit,  " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                            "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                            "COALESCE(SUM(CASE WHEN (tbl_rekapkerja.status = 'ijin' " & _
                            "OR tbl_rekapkerja.status = 'sakit' OR tbl_rekapkerja.status = 'kd' " & _
                            "OR tbl_rekapkerja.status = 'alfa') AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) as jumlah, " & _
                            "COUNT(CASE WHEN tbl_rekapkerja.status = 'satu jam' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) + " & _
                            "COUNT(CASE WHEN tbl_rekapkerja.status = 'setengah hari' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS total_imp, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                            "YEAR(@awal) as periode, dbo.view_tglpegawai.atasan, " & _
                            "SUBSTRING((SELECT ', ' + REPLACE(dbo.tbl_rekapkerja.catatan, CHAR(13), '')  FROM dbo.tbl_rekapkerja " & _
                            "WHERE dbo.tbl_rekapkerja.nik = view_tglpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                            "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                            "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                            "view_tglpegawai ON dbo.tbl_rekapkerja.nik = view_tglpegawai.nik " & _
                            "GROUP BY view_tglpegawai.nik, view_tglpegawai.nama, view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                            "view_tglpegawai.status_karyawan ,view_tglpegawai.atasan, view_tglpegawai .tgl_keluar ) As temp " & _
                            "WHERE temp.jabatan NOT like 'Manager%' AND temp.jabatan NOT like 'Kepala Bagian%' " & _
                            "AND temp.jabatan NOT like 'KaBag%' " & _
                            "AND temp.jabatan NOT like 'Direktur%') AS T_Temp " & _
                            "WHERE (T_Temp.tgl_keluar IS NULL OR T_Temp.tgl_keluar > @awal) " & _
                            "AND T_Temp.departemen = '" & Filter & "' " & _
                            "AND (T_temp.status_karyawan <> 'Harian' OR T_temp.status_karyawan <> 'Harian Sementara' " & _
                            "OR T_temp.status_karyawan <> 'Harian Tetap') ORDER BY T_Temp.nik "
                    Case "Bagian Khusus"
                        sql = "SELECT * FROM (SELECT * FROM " & _
                                    "(SELECT view_dtpegawai.nik,view_dtpegawai.nama,view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                                    "view_dtpegawai.status_karyawan , COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                                    "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin," & _
                                    "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                                    "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                                    "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND  " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                                    "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                                    "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                                    "COALESCE(SUM(CASE WHEN (tbl_rekapkerja.status = 'ijin' " & _
                                    "OR tbl_rekapkerja.status = 'sakit' OR tbl_rekapkerja.status = 'kd' " & _
                                    "OR tbl_rekapkerja.status = 'alfa') AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) as jumlah, " & _
                                    "COUNT(CASE WHEN tbl_rekapkerja.status = 'satu jam' AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) + " & _
                                    "COUNT(CASE WHEN tbl_rekapkerja.status = 'setengah hari' AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS total_imp, " & _
                                    "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                                    "YEAR(@awal) as periode, dbo.view_dtpegawai.atasan, " & _
                                    "SUBSTRING((SELECT ', ' + REPLACE(dbo.tbl_rekapkerja.catatan, CHAR(13), '')  FROM dbo.tbl_rekapkerja " & _
                                    "WHERE dbo.tbl_rekapkerja.nik = view_dtpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                                    "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                                    "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                                    "view_dtpegawai ON dbo.tbl_rekapkerja.nik = view_dtpegawai.nik " & _
                                    "GROUP BY view_dtpegawai.nik, view_dtpegawai.nama, view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                                    "view_dtpegawai.status_karyawan ,view_dtpegawai.atasan) As temp " & _
                                    "WHERE temp.jabatan like 'Manager%' OR temp.jabatan like 'Kepala Bagian%' " & _
                                    "OR temp.jabatan  like 'KaBag%' " & _
                                    "OR temp.jabatan  like 'Direktur%') AS T_Temp WHERE T_temp.status_karyawan <> 'Harian Sementara' AND " & _
                                    "T_temp.atasan = '" & Filter & "' ORDER BY T_Temp.nik"
                        '==========================================================================================================================
                        sql1 = "SELECT * FROM (SELECT temp.nik, temp.nama, temp.departemen, temp.jabatan, temp.status_karyawan, " & _
                            "temp.total_cuti, temp.total_ijin, temp.total_sakit, temp.total_kd, temp.total_alfa, temp.total_cutikusus, " & _
                            "temp.jumlah, temp.total_imp , temp.telat, temp.periode, temp.atasan, temp.catatan, temp.tgl_keluar  FROM " & _
                            "(SELECT view_tglpegawai.nik,view_tglpegawai.nama,view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                            "view_tglpegawai.status_karyawan , view_tglpegawai.tgl_keluar, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit,  " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                            "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                            "COALESCE(SUM(CASE WHEN (tbl_rekapkerja.status = 'ijin' " & _
                            "OR tbl_rekapkerja.status = 'sakit' OR tbl_rekapkerja.status = 'kd' " & _
                            "OR tbl_rekapkerja.status = 'alfa') AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) as jumlah, " & _
                            "COUNT(CASE WHEN tbl_rekapkerja.status = 'satu jam' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) + " & _
                            "COUNT(CASE WHEN tbl_rekapkerja.status = 'setengah hari' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS total_imp, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                            "YEAR(@awal) as periode, dbo.view_tglpegawai.atasan, " & _
                            "SUBSTRING((SELECT ', ' + REPLACE(dbo.tbl_rekapkerja.catatan, CHAR(13), '')  FROM dbo.tbl_rekapkerja " & _
                            "WHERE dbo.tbl_rekapkerja.nik = view_tglpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                            "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                            "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                            "view_tglpegawai ON dbo.tbl_rekapkerja.nik = view_tglpegawai.nik " & _
                            "GROUP BY view_tglpegawai.nik, view_tglpegawai.nama, view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                            "view_tglpegawai.status_karyawan ,view_tglpegawai.atasan, view_tglpegawai .tgl_keluar ) As temp " & _
                            "WHERE temp.jabatan like 'Manager%' OR temp.jabatan like 'Kepala Bagian%' " & _
                            "AND temp.jabatan like 'KaBag%' OR temp.jabatan like 'Direktur%') AS T_Temp " & _
                            "WHERE (T_Temp.tgl_keluar IS NULL OR T_Temp.tgl_keluar > @awal) " & _
                            "AND T_Temp.atasan = '" & Filter & "' " & _
                            "AND (T_temp.status_karyawan <> 'Harian' OR T_temp.status_karyawan <> 'Harian Sementara' " & _
                            "OR T_temp.status_karyawan <> 'Harian Tetap') ORDER BY T_Temp.nik "
                End Select
            ElseIf Radio_tahunan.Checked = True Then
                Select Case JenisFilter
                    Case String.Empty
                        sql = "SELECT * FROM (SELECT * FROM " & _
                            "(SELECT view_dtpegawai.nik,view_dtpegawai.nama, view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                            "view_dtpegawai.status_karyawan , COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin," & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND  " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                            "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                            "COALESCE(SUM(CASE WHEN (tbl_rekapkerja.status = 'ijin' " & _
                            "OR tbl_rekapkerja.status = 'sakit' OR tbl_rekapkerja.status = 'kd' " & _
                            "OR tbl_rekapkerja.status = 'alfa') AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) as jumlah, " & _
                            "COUNT(CASE WHEN tbl_rekapkerja.status = 'satu jam' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) + " & _
                            "COUNT(CASE WHEN tbl_rekapkerja.status = 'setengah hari' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS total_imp, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                            "YEAR(@awal) as periode, dbo.view_dtpegawai.atasan, " & _
                            "SUBSTRING((SELECT ', ' + REPLACE(dbo.tbl_rekapkerja.catatan, CHAR(13), '') FROM dbo.tbl_rekapkerja " & _
                            "WHERE dbo.tbl_rekapkerja.nik = view_dtpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                            "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                            "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                            "view_dtpegawai ON dbo.tbl_rekapkerja.nik = view_dtpegawai.nik " & _
                            "GROUP BY view_dtpegawai.nik, view_dtpegawai.nama, view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                            "view_dtpegawai.status_karyawan ,view_dtpegawai.atasan) As temp " & _
                            "WHERE temp.jabatan NOT like 'Manager%' AND temp.jabatan NOT like 'Kepala Bagian%' " & _
                            "AND temp.jabatan NOT like 'KaBag%' " & _
                            "AND temp.jabatan NOT like 'Direktur%') AS T_Temp ORDER BY T_Temp.nik"
                        '================================================================================================================
                        sql1 = "SELECT * FROM (SELECT temp.nik, temp.nama, temp.departemen, temp.jabatan, temp.status_karyawan, " & _
                            "temp.total_cuti, temp.total_ijin, temp.total_sakit, temp.total_kd, temp.total_alfa, temp.total_cutikusus, " & _
                            "temp.jumlah, temp.total_imp , temp.telat, temp.periode, temp.atasan, temp.catatan, temp.tgl_keluar FROM " & _
                            "(SELECT view_tglpegawai.nik,view_tglpegawai.nama, view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                            "view_tglpegawai.status_karyawan , view_tglpegawai.tgl_keluar, COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                            "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                            "COALESCE(SUM(CASE WHEN (tbl_rekapkerja.status = 'ijin' " & _
                            "OR tbl_rekapkerja.status = 'sakit' OR tbl_rekapkerja.status = 'kd' " & _
                            "OR tbl_rekapkerja.status = 'alfa') AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) as jumlah, " & _
                            "COUNT(CASE WHEN tbl_rekapkerja.status = 'satu jam' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) + " & _
                            "COUNT(CASE WHEN tbl_rekapkerja.status = 'setengah hari' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS total_imp, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                            "YEAR(@awal) as periode, dbo.view_tglpegawai.atasan, " & _
                            "SUBSTRING((SELECT ', ' + REPLACE(dbo.tbl_rekapkerja.catatan, CHAR(13), '') FROM dbo.tbl_rekapkerja " & _
                            "WHERE dbo.tbl_rekapkerja.nik = view_tglpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                            "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                            "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                            "view_tglpegawai ON dbo.tbl_rekapkerja.nik = view_tglpegawai.nik " & _
                            "GROUP BY view_tglpegawai.nik, view_tglpegawai.nama, view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                            "view_tglpegawai.status_karyawan ,view_tglpegawai.atasan, view_tglpegawai.tgl_keluar) As temp " & _
                            "WHERE temp.jabatan NOT like 'Manager%' AND temp.jabatan NOT like 'Kepala Bagian%' " & _
                            "AND temp.jabatan NOT like 'KaBag%' " & _
                            "AND temp.jabatan NOT like 'Direktur%') AS T_Temp " & _
                            "WHERE (T_Temp.tgl_keluar IS NULL OR T_Temp.tgl_keluar > @awal) AND (T_temp.status_karyawan <> 'Harian' " & _
                            "OR T_temp.status_karyawan <> 'Harian Sementara' OR T_temp.status_karyawan <> 'Harian Tetap') " & _
                            "ORDER BY T_Temp.nik"
                    Case "Departemen"
                        sql = "SELECT * FROM (SELECT * FROM " & _
                            "(SELECT view_dtpegawai.nik,view_dtpegawai.nama,view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                            "view_dtpegawai.status_karyawan , COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin," & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND  " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                            "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                            "COALESCE(SUM(CASE WHEN (tbl_rekapkerja.status = 'ijin' " & _
                            "OR tbl_rekapkerja.status = 'sakit' OR tbl_rekapkerja.status = 'kd' " & _
                            "OR tbl_rekapkerja.status = 'alfa') AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) as jumlah, " & _
                            "COUNT(CASE WHEN tbl_rekapkerja.status = 'satu jam' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) + " & _
                            "COUNT(CASE WHEN tbl_rekapkerja.status = 'setengah hari' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS total_imp, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                            "YEAR(@awal) as periode, dbo.view_dtpegawai.atasan, " & _
                            "SUBSTRING((SELECT ', ' + REPLACE(dbo.tbl_rekapkerja.catatan, CHAR(13), '') FROM dbo.tbl_rekapkerja " & _
                            "WHERE dbo.tbl_rekapkerja.nik = view_dtpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                            "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                            "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                            "view_dtpegawai ON dbo.tbl_rekapkerja.nik = view_dtpegawai.nik " & _
                            "GROUP BY view_dtpegawai.nik, view_dtpegawai.nama, view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                            "view_dtpegawai.status_karyawan ,view_dtpegawai.atasan) As temp " & _
                            "WHERE temp.jabatan NOT like 'Manager%' AND temp.jabatan NOT like 'Kepala Bagian%' " & _
                            "AND temp.jabatan NOT like 'KaBag%' " & _
                            "AND temp.jabatan NOT like 'Direktur%') AS T_Temp  WHERE T_Temp.departemen = '" & Filter & "' ORDER BY T_Temp.nik"
                        '================================================================================================================
                        sql1 = "SELECT * FROM (SELECT temp.nik, temp.nama, temp.departemen, temp.jabatan, temp.status_karyawan, " & _
                            "temp.total_cuti, temp.total_ijin, temp.total_sakit, temp.total_kd, temp.total_alfa, temp.total_cutikusus, " & _
                            "temp.jumlah, temp.total_imp , temp.telat, temp.periode, temp.atasan, temp.catatan, temp.tgl_keluar FROM " & _
                            "(SELECT view_tglpegawai.nik,view_tglpegawai.nama, view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                            "view_tglpegawai.status_karyawan , view_tglpegawai.tgl_keluar, COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                            "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                            "COALESCE(SUM(CASE WHEN (tbl_rekapkerja.status = 'ijin' " & _
                            "OR tbl_rekapkerja.status = 'sakit' OR tbl_rekapkerja.status = 'kd' " & _
                            "OR tbl_rekapkerja.status = 'alfa') AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) as jumlah, " & _
                            "COUNT(CASE WHEN tbl_rekapkerja.status = 'satu jam' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) + " & _
                            "COUNT(CASE WHEN tbl_rekapkerja.status = 'setengah hari' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS total_imp, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                            "YEAR(@awal) as periode, dbo.view_tglpegawai.atasan, " & _
                            "SUBSTRING((SELECT ', ' + REPLACE(dbo.tbl_rekapkerja.catatan, CHAR(13), '') FROM dbo.tbl_rekapkerja " & _
                            "WHERE dbo.tbl_rekapkerja.nik = view_tglpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                            "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                            "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                            "view_tglpegawai ON dbo.tbl_rekapkerja.nik = view_tglpegawai.nik " & _
                            "GROUP BY view_tglpegawai.nik, view_tglpegawai.nama, view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                            "view_tglpegawai.status_karyawan ,view_tglpegawai.atasan, view_tglpegawai.tgl_keluar) As temp " & _
                            "WHERE temp.jabatan NOT like 'Manager%' AND temp.jabatan NOT like 'Kepala Bagian%' " & _
                            "AND temp.jabatan NOT like 'KaBag%' " & _
                            "AND temp.jabatan NOT like 'Direktur%') AS T_Temp " & _
                            "WHERE (T_Temp.tgl_keluar IS NULL OR T_Temp.tgl_keluar > @awal) AND (T_temp.status_karyawan <> 'Harian' " & _
                            "OR T_temp.status_karyawan <> 'Harian Sementara' OR T_temp.status_karyawan <> 'Harian Tetap') " & _
                            "AND T_Temp.departemen = '" & Filter & "' ORDER BY T_Temp.nik"
                    Case "Bagian Khusus"
                        sql = "SELECT * FROM (SELECT * FROM " & _
                            "(SELECT view_dtpegawai.nik,view_dtpegawai.nama,view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                            "view_dtpegawai.status_karyawan , COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin," & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND  " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                            "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                            "COALESCE(SUM(CASE WHEN (tbl_rekapkerja.status = 'ijin' " & _
                            "OR tbl_rekapkerja.status = 'sakit' OR tbl_rekapkerja.status = 'kd' " & _
                            "OR tbl_rekapkerja.status = 'alfa') AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) as jumlah, " & _
                            "COUNT(CASE WHEN tbl_rekapkerja.status = 'satu jam' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) + " & _
                            "COUNT(CASE WHEN tbl_rekapkerja.status = 'setengah hari' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS total_imp, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                            "YEAR(@awal) as periode, dbo.view_dtpegawai.atasan, " & _
                            "SUBSTRING((SELECT ', ' + REPLACE(dbo.tbl_rekapkerja.catatan, CHAR(13), '') FROM dbo.tbl_rekapkerja " & _
                            "WHERE dbo.tbl_rekapkerja.nik = view_dtpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                            "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                            "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                            "view_dtpegawai ON dbo.tbl_rekapkerja.nik = view_dtpegawai.nik " & _
                            "GROUP BY view_dtpegawai.nik, view_dtpegawai.nama, view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                            "view_dtpegawai.status_karyawan ,view_dtpegawai.atasan) As temp " & _
                            "WHERE temp.atasan = '" & Filter & "' AND " & _
                            "(temp.jabatan LIKE 'Manager%' OR temp.jabatan LIKE 'Kepala Bagian%' OR temp.jabatan LIKE 'KaBag%')) AS T_Temp ORDER BY T_Temp.nik"
                        '================================================================================================================
                        sql1 = "SELECT * FROM (SELECT temp.nik, temp.nama, temp.departemen, temp.jabatan, temp.status_karyawan, " & _
                            "temp.total_cuti, temp.total_ijin, temp.total_sakit, temp.total_kd, temp.total_alfa, temp.total_cutikusus, " & _
                            "temp.jumlah, temp.total_imp , temp.telat, temp.periode, temp.atasan, temp.catatan, temp.tgl_keluar FROM " & _
                            "(SELECT view_tglpegawai.nik,view_tglpegawai.nama, view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                            "view_tglpegawai.status_karyawan , view_tglpegawai.tgl_keluar, COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                            "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                            "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                            "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                            "COALESCE(SUM(CASE WHEN (tbl_rekapkerja.status = 'ijin' " & _
                            "OR tbl_rekapkerja.status = 'sakit' OR tbl_rekapkerja.status = 'kd' " & _
                            "OR tbl_rekapkerja.status = 'alfa') AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) as jumlah, " & _
                            "COUNT(CASE WHEN tbl_rekapkerja.status = 'satu jam' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) + " & _
                            "COUNT(CASE WHEN tbl_rekapkerja.status = 'setengah hari' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS total_imp, " & _
                            "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                            "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                            "YEAR(@awal) as periode, dbo.view_tglpegawai.atasan, " & _
                            "SUBSTRING((SELECT ', ' + REPLACE(dbo.tbl_rekapkerja.catatan, CHAR(13), '') FROM dbo.tbl_rekapkerja " & _
                            "WHERE dbo.tbl_rekapkerja.nik = view_tglpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                            "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                            "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                            "view_tglpegawai ON dbo.tbl_rekapkerja.nik = view_tglpegawai.nik " & _
                            "GROUP BY view_tglpegawai.nik, view_tglpegawai.nama, view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                            "view_tglpegawai.status_karyawan ,view_tglpegawai.atasan, view_tglpegawai.tgl_keluar) As temp " & _
                            "WHERE temp.jabatan like 'Manager%' OR temp.jabatan like 'Kepala Bagian%' " & _
                            "OR temp.jabatan  like 'KaBag%' " & _
                            "OR temp.jabatan  like 'Direktur%') AS T_Temp " & _
                            "WHERE (T_Temp.tgl_keluar IS NULL OR T_Temp.tgl_keluar > @awal) AND (T_temp.status_karyawan <> 'Harian' " & _
                            "OR T_temp.status_karyawan <> 'Harian Sementara' OR T_temp.status_karyawan <> 'Harian Tetap') " & _
                            "AND T_Temp.atasan = '" & Filter & "' ORDER BY T_Temp.nik"
                End Select
            End If
            sqlcmd = New SqlCommand(sql1, Conn)
            sqlcmd.Parameters.Add("@awal", SqlDbType.Date).Value = CDate(DT_tgldari.Text)
            sqlcmd.Parameters.Add("@akhir", SqlDbType.Date).Value = CDate(DT_tglke.Text)
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            e.Result = New Tuple(Of DataTable)(DTab)
        Catch Ex As Exception
            MessageBox.Show("gagal menampilkan data " & Ex.Message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Conn.Close()
            ' Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Private Sub UpdateProgress()
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        ProgressBar1.MarqueeAnimationSpeed = 50
    End Sub

    Private Sub EnableProgress()
        ProgressBar1.Visible = True
        ProgressBar1.Value = 0
    End Sub

    Private Sub EndProgress()
        ProgressBar1.Style = ProgressBarStyle.Blocks
        ProgressBar1.Visible = False
    End Sub

    Private Sub CheckHarianSementara()
        If Check_harian.Checked = True Then

        Else

        End If
    End Sub

    Private Sub Worker1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles Worker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub Worker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles Worker1.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            MessageBox.Show("Gagal dalam menjalankan: & "(e.Error.Message), "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf e.Cancelled Then
            MessageBox.Show("Task was canceled.")
        Else
            ProgressBar1.Style = ProgressBarStyle.Blocks
            ProgressBar1.Visible = False
            'MessageBox.Show("Task completed successfully.")
        End If
        If Not worker2.IsBusy Then
            worker2.RunWorkerAsync()
        End If
        'membersihkan sumber daya
        Worker1.Dispose()
    End Sub

    Private Sub worker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles worker2.DoWork
        If ProgressBar1.InvokeRequired Then
            ProgressBar1.Invoke(Sub() UpdateProgress())
        Else
            UpdateProgress()
        End If
        If grid_karyawan.InvokeRequired Then
            grid_karyawan.Invoke(Sub() UpdateDataGridView())
        Else
            UpdateDataGridView()
        End If
    End Sub

    Private Sub UpdateDataGridView()
        Dim DataTabel As New DataTable
        DataTabel.Clear()
        DataTabel = DTab
        grid_karyawan.DataSource = DataTabel
        atur_grid()
        grid_karyawan.Refresh()
        StopFormatting()
        ProgressBar1.Visible = False
    End Sub

    Private Sub StopFormatting()
        ' Membatalkan thread pemformatan

    End Sub

    'untuk menampilkan pesan error saat proses backgroundworker
    Private Sub ShowErrorMessageBox(ByVal errorMessage As String)
        ' Method to display an error message using MessageBox
        MessageBox.Show(Me, errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub


    Private Sub worker2_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles worker2.RunWorkerCompleted
        If e.Error IsNot Nothing Then
            MessageBox.Show("Gagal dalam menjalankan: & "(e.Error.Message), "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf e.Cancelled Then
            MessageBox.Show("Gagal dalam menjalankan: & "(e.Error.Message), "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            'MessageBox.Show(e.Error.Message, "task completed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ProgressBar1.Style = ProgressBarStyle.Blocks
            ProgressBar1.Visible = False
            worker2.Dispose()
        End If
    End Sub

    Private Sub worker2_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles worker2.ProgressChanged
    End Sub

    Private Sub worker3_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles worker3.DoWork
        'Dim NamaJabatan As String
        clear_command()
        openDB()
        Try
            'Dim nama As String = DirectCast(parameter, String)
            'Cursor.Current = Cursors.AppStarting
            sql = "SELECT nama, jabatan FROM view_dtpegawai WHERE nama = @nama"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@nama", SqlDbType.VarChar).Value = nama
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                If sqlreader.Item("jabatan") = "Manager HRD & GA" Then
                    NamaJab = "EKSPEDISI & SATPAM"
                Else
                    NamaJab = (sqlreader.Item("jabatan"))
                End If
            Else
                MessageBox.Show("nama jabatan tidak ditemukan", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            e.Result = New Tuple(Of String)(NamaJab)
        Catch ex As Exception
            MessageBox.Show("gagal dalam pencarian data " & ex.Message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            'Cursor.Current = Cursors.Arrow

            Conn.Close()
        End Try
    End Sub

    Private Sub worker3_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles worker3.RunWorkerCompleted
        departemen = NamaJab
        worker3.Dispose()
    End Sub

    Private Sub Button_baru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_baru.Click
        clear_date(Me, Group_periode)
        Combo_dept.Text = Nothing
        Combo_khusus.Text = Nothing
        grid_karyawan.DataSource = Nothing
        grid_karyawan.Rows.Clear()
        Radio_bulanan.Checked = False
        Radio_triwulan.Checked = False
        Radio_tahunan.Checked = False
    End Sub

    Private Sub WorkerDtHarian_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles WorkerDtHarian.DoWork
        clear_command()
        openDB()
        Dim sql1 As String
        Try
            If ProgressBar1.InvokeRequired Then
                ProgressBar1.Invoke(Sub() UpdateProgress())
            Else
                UpdateProgress()
            End If
            Select Case JenisFilter
                Case Nothing
                    sql = "SELECT * FROM (SELECT * FROM " & _
                                    "(SELECT view_dtpegawai.nik,view_dtpegawai.nama,view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                                    "view_dtpegawai.status_karyawan , COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                                    "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin," & _
                                    "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                                    "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                                    "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND  " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                                    "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                                    "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                                    "COALESCE(SUM(CASE WHEN (tbl_rekapkerja.status = 'ijin' " & _
                                    "OR tbl_rekapkerja.status = 'sakit' OR tbl_rekapkerja.status = 'kd' " & _
                                    "OR tbl_rekapkerja.status = 'alfa') AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) as jumlah, " & _
                                    "COUNT(CASE WHEN tbl_rekapkerja.status = 'satu jam' AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) + " & _
                                    "COUNT(CASE WHEN tbl_rekapkerja.status = 'setengah hari' AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS total_imp, " & _
                                    "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                                    "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                                    "YEAR(@awal) as periode, dbo.view_dtpegawai.atasan, " & _
                                    "SUBSTRING((SELECT ', ' + dbo.tbl_rekapkerja.catatan  FROM dbo.tbl_rekapkerja " & _
                                    "WHERE dbo.tbl_rekapkerja.nik = view_dtpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                                    "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                                    "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                                    "view_dtpegawai ON dbo.tbl_rekapkerja.nik = view_dtpegawai.nik " & _
                                    "GROUP BY view_dtpegawai.nik, view_dtpegawai.nama, view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                                    "view_dtpegawai.status_karyawan ,view_dtpegawai.atasan) As temp " & _
                                    "WHERE temp.status_karyawan = 'Harian Sementara' OR " & _
                                    "temp.status_karyawan = 'Keluar - Harian Sementara' ) AS T_Temp ORDER BY T_Temp.nik "
                    '=============================================================================================================
                    sql1 = "SELECT * FROM (SELECT temp.nik, temp.nama, temp.departemen, temp.jabatan, temp.status_karyawan, " & _
                        "temp.total_cuti, temp.total_ijin, temp.total_sakit, temp.total_kd, temp.total_alfa, temp.total_cutikusus, " & _
                        "temp.jumlah, temp.total_imp , temp.telat, temp.periode, temp.atasan, temp.catatan, temp.tgl_keluar FROM " & _
                        "(SELECT view_tglpegawai.nik,view_tglpegawai.nama,view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                        "view_tglpegawai.status_karyawan ,view_tglpegawai.tgl_keluar, COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                        "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                        "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                        "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin, " & _
                        "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                        "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                        "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                        "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                        "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND  " & _
                        "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                        "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                        "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                        "COALESCE(SUM(CASE WHEN (tbl_rekapkerja.status = 'ijin' " & _
                        "OR tbl_rekapkerja.status = 'sakit' OR tbl_rekapkerja.status = 'kd' " & _
                        "OR tbl_rekapkerja.status = 'alfa') AND " & _
                        "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) as jumlah, " & _
                        "COUNT(CASE WHEN tbl_rekapkerja.status = 'satu jam' AND " & _
                        "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) + " & _
                        "COUNT(CASE WHEN tbl_rekapkerja.status = 'setengah hari' AND " & _
                        "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS total_imp, " & _
                        "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                        "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                        "YEAR(@awal) as periode, dbo.view_tglpegawai.atasan, " & _
                        "SUBSTRING((SELECT ', ' + dbo.tbl_rekapkerja.catatan  FROM dbo.tbl_rekapkerja " & _
                        "WHERE dbo.tbl_rekapkerja.nik = view_tglpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                        "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                        "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                        "view_tglpegawai ON dbo.tbl_rekapkerja.nik = view_tglpegawai.nik " & _
                        "GROUP BY view_tglpegawai.nik, view_tglpegawai.nama, view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                        "view_tglpegawai.status_karyawan ,view_tglpegawai.atasan, view_tglpegawai.tgl_keluar) As temp " & _
                        "WHERE temp.status_karyawan LIKE 'Harian%' ) AS T_Temp ORDER BY T_Temp.nik"
                Case "Departemen"
                    '=============================================================================================================
                    sql1 = "SELECT * FROM (SELECT temp.nik, temp.nama, temp.departemen, temp.jabatan, temp.status_karyawan, " & _
                        "temp.total_cuti, temp.total_ijin, temp.total_sakit, temp.total_kd, temp.total_alfa, temp.total_cutikusus, " & _
                        "temp.jumlah, temp.total_imp , temp.telat, temp.periode, temp.atasan, temp.catatan, temp.tgl_keluar FROM " & _
                        "(SELECT view_tglpegawai.nik,view_tglpegawai.nama,view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                        "view_tglpegawai.status_karyawan ,view_tglpegawai.tgl_keluar, COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'cuti' AND " & _
                        "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                        "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' AND " & _
                        "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin, " & _
                        "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' AND " & _
                        "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                        "COALESCE(SUM(CASE WHEN tbl_rekapkerja.status = 'kd' AND " & _
                        "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                        "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND  " & _
                        "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                        "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND " & _
                        "dbo.tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                        "COALESCE(SUM(CASE WHEN (tbl_rekapkerja.status = 'ijin' " & _
                        "OR tbl_rekapkerja.status = 'sakit' OR tbl_rekapkerja.status = 'kd' " & _
                        "OR tbl_rekapkerja.status = 'alfa') AND " & _
                        "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN tbl_rekapkerja.lama ELSE NULL END),0) as jumlah, " & _
                        "COUNT(CASE WHEN tbl_rekapkerja.status = 'satu jam' AND " & _
                        "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) + " & _
                        "COUNT(CASE WHEN tbl_rekapkerja.status = 'setengah hari' AND " & _
                        "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS total_imp, " & _
                        "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND " & _
                        "tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir THEN 1 ELSE NULL END) AS telat, " & _
                        "YEAR(@awal) as periode, dbo.view_tglpegawai.atasan, " & _
                        "SUBSTRING((SELECT ', ' + dbo.tbl_rekapkerja.catatan  FROM dbo.tbl_rekapkerja " & _
                        "WHERE dbo.tbl_rekapkerja.nik = view_tglpegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                        "BETWEEN @awal AND @akhir FOR XML PATH ('')),3,500) as catatan " & _
                        "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                        "view_tglpegawai ON dbo.tbl_rekapkerja.nik = view_tglpegawai.nik " & _
                        "GROUP BY view_tglpegawai.nik, view_tglpegawai.nama, view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                        "view_tglpegawai.status_karyawan ,view_tglpegawai.atasan, view_tglpegawai.tgl_keluar) As temp " & _
                        "WHERE temp.status_karyawan LIKE 'Harian%' ) AS T_Temp " & _
                        "WHERE T_Temp.departemen = '" & Filter & "' ORDER BY T_Temp.nik"
            End Select
            sqlcmd = New SqlCommand(sql1, Conn)
            With sqlcmd.Parameters
                .Add("@awal", SqlDbType.Date).Value = DT_tgldari.Text
                .Add("@akhir", SqlDbType.Date).Value = DT_tglke.Text
            End With
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            e.Result = New Tuple(Of DataTable)(DTab)
        Catch ex As Exception
            MessageBox.Show("gagal dalam menampilkan data harian", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub WorkerDtHarian_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles WorkerDtHarian.RunWorkerCompleted
        If ProgressBar1.InvokeRequired Then
            ProgressBar1.Invoke(Sub() EndProgress())
        Else
            EndProgress()
        End If
        If Not worker2.IsBusy Then
            worker2.RunWorkerAsync()
        End If
    End Sub

    Private Sub LabelTimerEnable()
        LabelProcess.Visible = True
    End Sub

    Private Sub LabelTimerDisable()
        LabelProcess.Text = String.Empty
        LabelProcess.Visible = False
    End Sub

    Private Sub DisableLabel(ByVal Visible As Boolean)
        ' Check if Invoke is required
        If LabelProcess.InvokeRequired Then
            ' Access your controls here
            LabelProcess.Invoke(Sub() DisableLabel(Visible))
        Else
            ' Update the Label's Text property
            LabelProcess.Visible = False
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub WorkerTimer_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles WorkerTimer.DoWork
        Try
            TampilLabel(LabelProcess, True)
            stopwatch.Reset()
            stopwatch.Start()
            While Not WorkerTimer.CancellationPending
                ' Calculate elapsed time
                Dim elapsed As TimeSpan = stopwatch.Elapsed

                ' Report elapsed time to UI
                WorkerTimer.ReportProgress(elapsed.TotalMilliseconds)

                ' Sleep for a short interval to reduce CPU usage
                System.Threading.Thread.Sleep(100)
            End While

            stopwatch.Stop()
        Catch ex As Exception
            MsgBox("gagal dalam menampilkan proses dengan waktu " & ex.Message, MsgBoxStyle.Information, "INFO")
        End Try

    End Sub

    Private Sub UpdateLabel(ByVal newText As String)
            ' Check if Invoke is required
        If LabelProcess.InvokeRequired Then
            ' Access your controls here
            LabelProcess.Invoke(Sub() UpdateLabel(newText))
        Else
            ' Update the Label's Text property
            LabelProcess.Text = newText
        End If
    End Sub

    Private Sub TampilLaporan(ByVal Report As ReportDocument)
        Dim Laporan As New FormLaporan
        ' Check if Invoke is required
        If Laporan.InvokeRequired Then
            ' Access your controls here
            Laporan.Invoke(Sub() TampilLaporan(Report))
        Else
            ' Update the Label's Text property
            Laporan.CrystalReportViewer1.ReportSource = Report
        End If
    End Sub

    Private Sub TampilLabel(ByVal Label_ As Label, ByVal tampil As Boolean)
        ' Check if Invoke is required
        If Label_.InvokeRequired Then
            ' Access your controls here
            Label_.Invoke(Sub() TampilLabel(Label_, tampil))
        Else
            ' Update the Label's Text property
            Label_.Visible = tampil
        End If
    End Sub

    Private Sub EnableButton(ByVal Button_ As Button, ByVal Status As Boolean)
        If Button_.InvokeRequired Then
            Button_.Invoke(Sub() EnableButton(Button_, Status))
        Else
            Button_.Enabled = Status
        End If
    End Sub


    Private Sub WorkerTimer_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles WorkerTimer.ProgressChanged
        ' Update tampilan UI dengan periodik waktu
        Dim elapsedMilliseconds As Integer = CInt(e.ProgressPercentage)
        Dim elapsed As New TimeSpan(0, 0, 0, 0, elapsedMilliseconds)
        ' menggunakan Invoke untuk  update Label.Text pada UI thread
        ' menggunakan pemanggilan yang aman untuk update text, menghindari illegal corssthread
        UpdateLabel(elapsed.ToString("hh\:mm\:ss\.fff"))
    End Sub

    Private Sub CancelAllWorkers()
        For Each worker In backgroundWorkers
            If worker.IsBusy Then
                worker.CancelAsync()
            End If
        Next
    End Sub

    Private Sub FormRekapAbsen_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' Check if the form is closing and handle cleanup
        If e.CloseReason = CloseReason.UserClosing Then
            ' Prevent the form from closing immediately
            e.Cancel = True

            ' Dispose any resources or cleanup code here
            ' For example, stop the BackgroundWorker if it's running
            'For Each worker In backgroundWorkers
            If WorkerTimer.IsBusy Then
                WorkerTimer.CancelAsync()
            End If
            'Next
            ' Close the form
            Me.Dispose()
        End If
    End Sub

    Private Sub WorkerLaporan_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles WorkerLaporan.DoWork
        EnableButton(Button1, False)
        Try
            Dim FilePath As String = Application.StartupPath & "\config_report.ini"
            KodeLap = readini(FilePath, "setting Config triwulan", "kode_laporan", "")
            NamaManager = readini(FilePath, "setting Config triwulan", "manager", "")
            NamaStaf = readini(FilePath, "setting Config triwulan", "bag_administrasi", "")
        Catch ex As Exception
            MsgBox("gagal dalam memuat data Nama Manager dan Nama Staff", MsgBoxStyle.Information, "INFO")
        End Try
    End Sub

    Private Sub WorkerLaporan_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles WorkerLaporan.RunWorkerCompleted
        WorkerLaporan.Dispose()
    End Sub

    Private Sub WorkerTahunan_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles WorkerTahunan.DoWork
        'jika prosedur invoke di butuhkan untuk menghindari illegal cross thread
        Try
            Dim tanggal As String = (DT_tglke.Value.AddMonths(0).ToString("MMMM")).ToUpper & " " & Year(CDate(DT_tglke.Text))
            If Not WorkerTimer.IsBusy Then
                'stopwatch.Reset()
                TampilLabel(LabelMemuat, True)
                WorkerTimer.RunWorkerAsync()
            Else
                WorkerTimer.CancelAsync()
                TampilLabel(LabelMemuat, True)
            End If
            'Rpt = New LaporanTahunan
            CRReportDocument = New ReportDocument
            With CRReportDocument
                '.Load(Application.StartupPath & "\reports\LaporanTahunan.rpt")
                .Load(Application.StartupPath & "\reports\LaporanTahunanNew.rpt")
                '.SetDatabaseLogon(user:=txt_id, password:=txt_pwd)
                .SetDataSource(DTab)
                .SetParameterValue(0, tanggal)
                .SetParameterValue(1, (CDate(DT_tgldari.Text)))
                .SetParameterValue(2, (CDate(DT_tglke.Text)))
                .SetParameterValue(3, departemen)
                .SetParameterValue(5, NamaStaf)
                .SetParameterValue(6, NamaManager)
            End With
            e.Result = New Tuple(Of ReportDocument)(CRReportDocument)

            FormLaporan.CrystalReportViewer1.ReportSource = CRReportDocument
            FormLaporan.ShowDialog()
        Catch ex As Exception
            MsgBox("gagal menampilkan proses memanggil laporan tahunan " & ex.Message, MsgBoxStyle.Information, "INFO")
        End Try
        
    End Sub

    Private Sub WorkerTahunan_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles WorkerTahunan.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub WorkerTahunan_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles WorkerTahunan.RunWorkerCompleted
        'FormLaporan.CrystalReportViewer1.ReportSource = CRReportDocument
        'FormLaporan.ShowDialog()
        FormLaporan.CrystalReportViewer1.RefreshReport()
        TampilLabel(LabelProcess, False)
        TampilLabel(LabelMemuat, False)
        WorkerTimer.CancelAsync()
        WorkerTimer.Dispose()
        EnableButton(Button1, True)
        'FormLaporan.ShowDialog()
        WorkerTahunan.Dispose()
    End Sub

    Private Sub WorkerTriwulan_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles WorkerTriwulan.DoWork
        'jika prosedur invoke di butuhkan untuk menghindari illegal cross thread
        Try
            If Not WorkerTimer.IsBusy Then
                'stopwatch.Reset()
                TampilLabel(LabelMemuat, True)
                WorkerTimer.RunWorkerAsync()
            Else
                WorkerTimer.CancelAsync()
                TampilLabel(LabelMemuat, True)
            End If
            'Rpt = New LaporanTahunan
            CRReportDocument = New ReportDocument
            With CRReportDocument
                .Load(Application.StartupPath & "\reports\Laporan_triwulan.rpt")
                '.SetDatabaseLogon(user:=txt_id, password:=txt_pwd)
                .SetDataSource(DTab)
                .SetParameterValue(0, (DT_tglke.Value.AddMonths(0).ToString("MMMM")).ToUpper & " " & Year(DT_tglke.Text))
                .SetParameterValue(1, (ConvertBln(DT_tgldari.Text).ToUpper))
                .SetParameterValue(3, departemen)
                .SetParameterValue(2, (ConvertBlnTahun(DT_tglke.Text).ToUpper))
                .SetParameterValue(5, ("Klaten, " & ConvertTanggal(Now)))
                If Check_harian.Checked = True Then
                    .SetParameterValue(6, " ")
                    .SetParameterValue(10, "harian")
                Else
                    .SetParameterValue(10, "triwulan")
                    .SetParameterValue(6, (cek_periode()))
                End If
                .SetParameterValue(7, NamaStaf)
                .SetParameterValue(8, NamaManager)
                .SetParameterValue(9, KodeLap)
            End With
            e.Result = New Tuple(Of ReportDocument)(CRReportDocument)
            FormLaporan.CrystalReportViewer1.ReportSource = CRReportDocument
            FormLaporan.ShowDialog()
        Catch ex As Exception
            MsgBox("gagal dalam pemanggilan laporan tri wulan " & ex.Message, MsgBoxStyle.Information, "INFO")
        End Try
       
    End Sub

    Private Sub WorkerTriwulan_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles WorkerTriwulan.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub WorkerTriwulan_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles WorkerTriwulan.RunWorkerCompleted
        'FormLaporan.CrystalReportViewer1.ReportSource = CRReportDocument
        'FormLaporan.ShowDialog()
        FormLaporan.CrystalReportViewer1.RefreshReport()
        TampilLabel(LabelProcess, False)
        TampilLabel(LabelMemuat, False)
        WorkerTimer.CancelAsync()
        WorkerTimer.Dispose()
        'FormLaporan.ShowDialog()
        EnableButton(Button1, True)
        WorkerTriwulan.Dispose()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub WorkerBulanan_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles WorkerBulanan.DoWork
        'jika prosedur invoke di butuhkan untuk menghindari illegal cross thread
        Try
            If Not WorkerTimer.IsBusy Then
                'stopwatch.Reset()
                TampilLabel(LabelMemuat, True)
                WorkerTimer.RunWorkerAsync()
            Else
                WorkerTimer.CancelAsync()
                TampilLabel(LabelMemuat, True)
            End If
            'Rpt = New LaporanTahunan
            CRReportDocument = New ReportDocument
            With CRReportDocument
                .Load(Application.StartupPath & "\reports\LaporanBulanan.rpt")
                .SetDatabaseLogon(user:=txt_id, password:=txt_pwd)
                .SetDataSource(DTab)
                .SetParameterValue(0, (ConvertBln(DT_tglke.Text).ToUpper))
                .SetParameterValue(1, (ConvertTanggal(DT_tgldari.Text).ToUpper))
                .SetParameterValue(2, (ConvertTanggal(DT_tglke.Text).ToUpper))
                .SetParameterValue(3, departemen)
                With grid_karyawan
                    CRReportDocument.SetParameterValue(4, .Rows(0).Cells(15).Value)
                End With
            End With
            e.Result = New Tuple(Of ReportDocument)(CRReportDocument)
            FormLaporan.CrystalReportViewer1.ReportSource = CRReportDocument
            FormLaporan.ShowDialog()

        Catch ex As Exception
            MsgBox("gagal dalam menjalankan proses pemanggilan laporan " & ex.Message, MsgBoxStyle.Information, "INFO")
        End Try
        
    End Sub

    Private Sub WorkerBulanan_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles WorkerBulanan.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub WorkerBulanan_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles WorkerBulanan.RunWorkerCompleted

        TampilLabel(LabelProcess, False)
        TampilLabel(LabelMemuat, False)
        WorkerTimer.CancelAsync()
        WorkerTimer.Dispose()
        'FormLaporan.ShowDialog()
        EnableButton(Button1, True)
        WorkerBulanan.Dispose()
    End Sub

    Private Sub WorkerTimer_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles WorkerTimer.RunWorkerCompleted

    End Sub

End Class
