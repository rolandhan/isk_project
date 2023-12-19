Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FormRekapTahunan
    Private awal, akhir As Date
    Private DTTab As DataTable

    Private Sub FormRekapTahunan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clear_date(Me, Nothing)
    End Sub

    Private Sub loading_grid(ByVal condition As String)
        If DT_tgldari.Text = " " Then
            MsgBox("Tanggal awal periode tidak boleh kosong", MsgBoxStyle.Information, "INFO")
        ElseIf DT_tglke.Text = " " Then
            MsgBox("Tanggal akhir periode tidak boleh kosong", MsgBoxStyle.Information, "INFO")
        End If
        Try
            clear_command()
            openDB()
            If condition Is Nothing Then
                sql = "SELECT DISTINCT dbo.tbl_pegawai.nik, dbo.tbl_pegawai.nama, dbo.tbl_jabatan.departemen, " & _
                    "(CASE WHEN YEAR(dbo.tbl_jabatan.tgl_akhir) = '" & Year(DT_tglke.Value) & "' THEN dbo.tbl_jabatan.jabatan END) AS jabatan_awal, " & _
                    "dbo.tbl_statuskerja.status, dbo.tbl_tanggalkerja.tgl_masuk_rec, " & _
                    "(CASE WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_masuk_rec, GETDATE()) = 1 THEN " & _
                    "CASE WHEN day(dbo.tbl_tanggalkerja.tgl_masuk_rec) < 16 THEN " & _
                    "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 1 THEN 6 " & _
                    "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 2 THEN 5 " & _
                    "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 3 THEN 4 " & _
                    "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 4 THEN 3 " & _
                    "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 5 THEN 2 " & _
                    "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 6 THEN 1 END " & _
                    "WHEN day(dbo.tbl_tanggalkerja.tgl_masuk_rec) > 15 THEN " & _
                    "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 1 THEN 5 " & _
                    "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 2 THEN 4 " & _
                    "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 3 THEN 3 " & _
                    "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 4 THEN 2 " & _
                    "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 5 THEN 1 END END " & _
                    "WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_masuk_rec, GETDATE()) > 1 THEN 6 ELSE 0 END) AS total_cuti, " & _
                    "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti' AND dbo.tbl_rekapkerja.tanggal BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(akhir, "yyyy/M/d") & "' THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cuti, " & _
                    "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'ijin' AND dbo.tbl_rekapkerja.tanggal BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(akhir, "yyyy/M/d") & "' THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_ijin, " & _
                    "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'sakit' AND dbo.tbl_rekapkerja.tanggal BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(akhir, "yyyy/M/d") & "' THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_sakit, " & _
                    "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'kd' AND dbo.tbl_rekapkerja.tanggal BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(akhir, "yyyy/M/d") & "' THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_kd, " & _
                    "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'alfa' AND dbo.tbl_rekapkerja.tanggal BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(akhir, "yyyy/M/d") & "' THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_alfa, " & _
                    "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'cuti kusus' AND dbo.tbl_rekapkerja.tanggal BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(akhir, "yyyy/M/d") & "' THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) AS total_cutikusus, " & _
                    "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'ijin' " & _
                    "OR dbo.tbl_rekapkerja.status = 'sakit' OR dbo.tbl_rekapkerja.status = 'kd' " & _
                    "OR dbo.tbl_rekapkerja.status = 'alfa' AND dbo.tbl_rekapkerja.tanggal BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(akhir, "yyyy/M/d") & "' THEN dbo.tbl_rekapkerja.lama ELSE NULL END),0) as jumlah, " & _
                    "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = '1 jam' " & _
                    "OR dbo.tbl_rekapkerja.status = 'setengah hari' AND dbo.tbl_rekapkerja.tanggal BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(akhir, "yyyy/M/d") & "' THEN 1 ELSE NULL END),0) as total_imp, " & _
                    "COALESCE(SUM(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' AND dbo.tbl_rekapkerja.tanggal BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(akhir, "yyyy/M/d") & "' THEN 1 ELSE NULL END),0) AS telat, " & _
                    "YEAR('" & Format(awal, "yyyy/M/d") & "') as periode, dbo.tbl_statuskerja.atasan, " & _
                    "SUBSTRING((SELECT ', ' + dbo.tbl_rekapkerja.catatan  FROM dbo.tbl_rekapkerja " & _
                    "WHERE dbo.tbl_rekapkerja.nik = dbo.tbl_pegawai.nik AND dbo.tbl_rekapkerja.tanggal " & _
                    "BETWEEN '" & Format(awal, "yyyy/M/d") & "' AND '" & Format(akhir, "yyyy/M/d") & "' FOR XML PATH ('')),3,500) as catatan " & _
                    "FROM dbo.tbl_pegawai " & _
                    "LEFT OUTER JOIN dbo.tbl_rekapkerja ON dbo.tbl_pegawai.nik = dbo.tbl_rekapkerja.nik " & _
                    "LEFT OUTER JOIN dbo.tbl_tanggalkerja ON dbo.tbl_pegawai.nik = dbo.tbl_tanggalkerja.nik " & _
                    "LEFT OUTER JOIN dbo.tbl_statuskerja ON dbo.tbl_pegawai.nik = dbo.tbl_statuskerja.nik " & _
                    "LEFT OUTER JOIN dbo.tbl_jabatan ON dbo.tbl_pegawai.nik = dbo.tbl_jabatan.nik " & _
                    "GROUP BY dbo.tbl_pegawai.nik, dbo.tbl_pegawai.nama, dbo.tbl_jabatan.departemen, " & _
                    "dbo.tbl_jabatan.tgl_akhir, dbo.tbl_jabatan.jabatan, dbo.tbl_statuskerja.status, dbo.tbl_statuskerja.atasan, dbo.tbl_tanggalkerja.tgl_masuk_rec"
            End If
            sqladapter = New SqlDataAdapter(sql, Conn)
            DTTab = New DataTable
            dtset = New DataSet
            dtset.Clear()
            DTTab.Clear()
            sqladapter.Fill(dtset, "dbo.tbl_pegawai " & _
                    "LEFT OUTER JOIN dbo.tbl_rekapkerja ON dbo.tbl_pegawai.nik = dbo.tbl_rekapkerja.nik " & _
                    "LEFT OUTER JOIN dbo.tbl_tanggalkerja ON dbo.tbl_pegawai.nik = dbo.tbl_tanggalkerja.nik " & _
                    "LEFT OUTER JOIN dbo.tbl_statuskerja ON dbo.tbl_pegawai.nik = dbo.tbl_statuskerja.nik " & _
                    "LEFT OUTER JOIN dbo.tbl_jabatan ON dbo.tbl_pegawai.nik = dbo.tbl_jabatan.nik")
            sqladapter.Fill(DTTab)
            grid_karyawan.DataSource = dtset.Tables("dbo.tbl_pegawai " & _
                    "LEFT OUTER JOIN dbo.tbl_rekapkerja ON dbo.tbl_pegawai.nik = dbo.tbl_rekapkerja.nik " & _
                    "LEFT OUTER JOIN dbo.tbl_tanggalkerja ON dbo.tbl_pegawai.nik = dbo.tbl_tanggalkerja.nik " & _
                    "LEFT OUTER JOIN dbo.tbl_statuskerja ON dbo.tbl_pegawai.nik = dbo.tbl_statuskerja.nik " & _
                    "LEFT OUTER JOIN dbo.tbl_jabatan ON dbo.tbl_pegawai.nik = dbo.tbl_jabatan.nik")
            'atur_grid()
            grid_karyawan.Refresh()
            grid_karyawan.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        Catch ex As Exception
            MsgBox("Gagal menampilkan data " & ex.Message)
        End Try
    End Sub

    Private Sub atur_grid()

    End Sub

    Private Sub DT_tgldari_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_tgldari.ValueChanged
        format_tanggal(DT_tgldari)
        awal = DT_tgldari.Value
    End Sub

    Private Sub DT_tglke_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_tglke.ValueChanged
        format_tanggal(DT_tglke)
        akhir = DT_tglke.Value
    End Sub

    Private Sub Button_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_go.Click
        loading_grid(Nothing)
    End Sub
End Class