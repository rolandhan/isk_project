Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Threading.Thread
Imports System.Threading.Tasks

Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office
Imports Microsoft.Office.Interop

Imports System.ComponentModel

Public Class FormDataKekaryawanan
    Dim karyawan As String
    Dim departemen As String = String.Empty
    Dim status As String = String.Empty
    Dim jabatan As String = String.Empty
    Dim periode_jab As String = String.Empty
    Dim agama, status_kawin, pendidikan, kab_asal, kec_asal, desa_asal, status_editdata As String
    Dim rowindex As Integer
    Dim xlapp As Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet
    Dim misValue As Object = System.Reflection.Missing.Value
    Dim i As Integer
    Dim j As Integer
    Dim JenisExport As String
    Public Delegate Sub UpdateProgressDelegate()


    Private Sub FormDataKekaryawanan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New CultureInfo("id-ID")
        load_filter(ComboKategori)
        load_filterKTP(Combo_opsiKTP)
        load_filterKTP(Combo_opsiDom)
        load_filterKeluarga(Combo_opsiK)
        load_filterFK(Combo_opsiFK)
        clear_date(Me, Group_periode)
        load_karyawan(Combo_kary)
        worker1.WorkerReportsProgress = True
        worker1.WorkerSupportsCancellation = True
    End Sub

    Private Sub load_gridkaryPeriod(ByVal grid As DataGridView, ByVal opt As String, _
                                     ByVal condition As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            Select Case condition
                Case String.Empty
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, * FROM " & _
            "(SELECT tempjab.nik, tempjab.nama, tempjab.departemen, tempjab.jabawal, tempjab.jabakhir, tempjab.status_karyawan," & _
            "tempjab.atasan, tbl_tanggalkerja.tgl_masuk_rec, tbl_tanggalkerja.tgl_masuk_harian, tbl_tanggalkerja.tgl_borongan, " & _
            "convert(varchar,(DATEDIFF(YEAR,tbl_tanggalkerja.tgl_masuk_rec ,GETDATE()))) " & _
            "+ ' Tahun ' + convert(varchar,(DATEDIFF(month,tbl_tanggalkerja.tgl_masuk_rec ,GETDATE())%12)) + ' bulan' AS masakerja, " & _
            "tbl_tanggalkerja.tgl_kontrak, tbl_tanggalkerja.tgl_tetap,tbl_tanggalkerja.tgl_keluar, " & _
            "(CASE WHEN tempjab.status_karyawan = 'Harian Tetap' THEN NULL " & _
            "WHEN tempjab.status_karyawan = 'Tanpa Status' THEN NULL " & _
            "ELSE CASE WHEN tbl_tanggalkerja.tgl_masuk_rec IS NULL THEN " & _
            "CASE WHEN tbl_tanggalkerja.tgl_kontrak IS NULL THEN NULL " & _
            "ELSE CASE WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_kontrak, GETDATE()) = 1 THEN " & _
            "CASE WHEN day(dbo.tbl_tanggalkerja.tgl_kontrak) < 16 THEN " & _
            "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 1 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 2 THEN'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 3 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 4 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 5 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 6 THEN 'ok' END " & _
            "WHEN day(dbo.tbl_tanggalkerja.tgl_kontrak) > 15 THEN " & _
            "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 1 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 2 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 3 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 4 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 5 THEN 'ok' END END " & _
            "WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_kontrak, GETDATE()) > 1 THEN 'ok' " & _
            "ELSE NULL END END " & _
            "ELSE CASE WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_masuk_rec, GETDATE()) = 1 THEN " & _
            "CASE WHEN day(dbo.tbl_tanggalkerja.tgl_masuk_rec) < 16 THEN " & _
            "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 1 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 2 THEN'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 3 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 4 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 5 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 6 THEN 'ok' END " & _
            "WHEN day(dbo.tbl_tanggalkerja.tgl_masuk_rec) > 15 THEN " & _
            "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 1 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 2 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 3 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 4 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 5 THEN 'ok' END END " & _
            "WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_masuk_rec, GETDATE()) > 1 THEN 'ok' " & _
            "ELSE NULL END END END) AS cuti " & _
            "FROM (SELECT tbl_pegawai.nik, tbl_pegawai.nama, jabatan.departemen, jabatan.jabawal, jabatan.jabakhir," & _
            "jabatan.status_karyawan, jabatan.atasan FROM (SELECT jab_awal.nik,jab_awal.departemen,  jab_awal.jabatan AS jabawal," & _
            "jab_akhir.jabatan AS jabakhir, jab_awal.status_karyawan, jab_awal.atasan " & _
            "FROM (SELECT tbl_jabatan.nik,tbl_jabatan.departemen, tbl_jabatan.jabatan, " & _
            "tbl_jabatan.status_karyawan, tbl_jabatan.atasan FROM tbl_jabatan " & _
            "WHERE year(tbl_jabatan.tgl_awal) = YEAR( @TGlawal)) AS jab_awal " & _
            "LEFT OUTER JOIN (SELECT tbl_jabatan.nik,tbl_jabatan.departemen, tbl_jabatan.jabatan," & _
            "tbl_jabatan.status_karyawan, tbl_jabatan.atasan " & _
            "FROM tbl_jabatan WHERE year(tbl_jabatan.tgl_awal) = YEAR( @TGlakhir)) AS jab_akhir ON " & _
            "jab_awal.nik = jab_akhir.nik) AS jabatan RIGHT OUTER JOIN tbl_pegawai ON " & _
            "jabatan.nik = tbl_pegawai.nik) AS tempjab LEFT OUTER JOIN tbl_tanggalkerja ON " & _
            "tempjab.nik = tbl_tanggalkerja.nik) AS temp " & _
            "WHERE temp.status_karyawan IN ( @status, @status2 "
                Case "Departemen"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, * FROM " & _
            "(SELECT tempjab.nik, tempjab.nama, tempjab.departemen, tempjab.jabawal, tempjab.jabakhir, tempjab.status_karyawan," & _
            "tempjab.atasan, tbl_tanggalkerja.tgl_masuk_rec, tbl_tanggalkerja.tgl_masuk_harian, tbl_tanggalkerja.tgl_borongan, " & _
            "convert(varchar,(DATEDIFF(YEAR,tbl_tanggalkerja.tgl_masuk_rec ,GETDATE()))) " & _
            "+ ' Tahun ' + convert(varchar,(DATEDIFF(month,tbl_tanggalkerja.tgl_masuk_rec ,GETDATE())%12)) + ' bulan' AS masakerja, " & _
            "tbl_tanggalkerja.tgl_kontrak, tbl_tanggalkerja.tgl_tetap,tbl_tanggalkerja.tgl_keluar, " & _
            "(CASE WHEN tempjab.status_karyawan = 'Harian Tetap' THEN NULL " & _
            "WHEN tempjab.status_karyawan = 'Tanpa Status' THEN NULL " & _
            "ELSE CASE WHEN tbl_tanggalkerja.tgl_masuk_rec IS NULL THEN " & _
            "CASE WHEN tbl_tanggalkerja.tgl_kontrak IS NULL THEN NULL " & _
            "ELSE CASE WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_kontrak, GETDATE()) = 1 THEN " & _
            "CASE WHEN day(dbo.tbl_tanggalkerja.tgl_kontrak) < 16 THEN " & _
            "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 1 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 2 THEN'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 3 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 4 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 5 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 6 THEN 'ok' END " & _
            "WHEN day(dbo.tbl_tanggalkerja.tgl_kontrak) > 15 THEN " & _
            "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 1 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 2 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 3 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 4 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 5 THEN 'ok' END END " & _
            "WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_kontrak, GETDATE()) > 1 THEN 'ok' " & _
            "ELSE NULL END END " & _
            "ELSE CASE WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_masuk_rec, GETDATE()) = 1 THEN " & _
            "CASE WHEN day(dbo.tbl_tanggalkerja.tgl_masuk_rec) < 16 THEN " & _
            "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 1 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 2 THEN'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 3 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 4 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 5 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 6 THEN 'ok' END " & _
            "WHEN day(dbo.tbl_tanggalkerja.tgl_masuk_rec) > 15 THEN " & _
            "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 1 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 2 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 3 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 4 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 5 THEN 'ok' END END " & _
            "WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_masuk_rec, GETDATE()) > 1 THEN 'ok' " & _
            "ELSE NULL END END END) AS cuti " & _
            "FROM (SELECT tbl_pegawai.nik, tbl_pegawai.nama, jabatan.departemen, jabatan.jabawal, jabatan.jabakhir," & _
            "jabatan.status_karyawan, jabatan.atasan FROM (SELECT jab_awal.nik,jab_awal.departemen,  jab_awal.jabatan AS jabawal," & _
            "jab_akhir.jabatan AS jabakhir, jab_awal.status_karyawan, jab_awal.atasan " & _
            "FROM (SELECT tbl_jabatan.nik,tbl_jabatan.departemen, tbl_jabatan.jabatan, " & _
            "tbl_jabatan.status_karyawan, tbl_jabatan.atasan FROM tbl_jabatan " & _
            "WHERE year(tbl_jabatan.tgl_awal) = YEAR( @TGlawal)) AS jab_awal " & _
            "LEFT OUTER JOIN (SELECT tbl_jabatan.nik,tbl_jabatan.departemen, tbl_jabatan.jabatan," & _
            "tbl_jabatan.status_karyawan, tbl_jabatan.atasan " & _
            "FROM tbl_jabatan WHERE year(tbl_jabatan.tgl_awal) = YEAR( @TGlakhir)) AS jab_akhir ON " & _
            "jab_awal.nik = jab_akhir.nik) AS jabatan RIGHT OUTER JOIN tbl_pegawai ON " & _
            "jabatan.nik = tbl_pegawai.nik) AS tempjab LEFT OUTER JOIN tbl_tanggalkerja ON " & _
            "tempjab.nik = tbl_tanggalkerja.nik) AS temp " & _
            "WHERE temp.status_karyawan IN ( 'Kontrak', 'Tetap') " & _
            "AND (temp.jabakhir = @condition OR temp.departemen = @condition OR temp.jabakhir = @condition " & _
            "OR temp.status_karyawan = @condition)"
                Case "Pencarian"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, * FROM " & _
            "(SELECT tempjab.nik, tempjab.nama, tempjab.departemen, tempjab.jabawal, tempjab.jabakhir, tempjab.status_karyawan," & _
            "tempjab.atasan, tbl_tanggalkerja.tgl_masuk_rec, tbl_tanggalkerja.tgl_masuk_harian, tbl_tanggalkerja.tgl_borongan, " & _
            "convert(varchar,(DATEDIFF(YEAR,tbl_tanggalkerja.tgl_masuk_rec ,GETDATE()))) " & _
            "+ ' Tahun ' + convert(varchar,(DATEDIFF(month,tbl_tanggalkerja.tgl_masuk_rec ,GETDATE())%12)) + ' bulan' AS masakerja, " & _
            "tbl_tanggalkerja.tgl_kontrak, tbl_tanggalkerja.tgl_tetap,tbl_tanggalkerja.tgl_keluar, " & _
            "(CASE WHEN tempjab.status_karyawan = 'Harian Tetap' THEN NULL " & _
            "WHEN tempjab.status_karyawan = 'Tanpa Status' THEN NULL " & _
            "ELSE CASE WHEN tbl_tanggalkerja.tgl_masuk_rec IS NULL THEN " & _
            "CASE WHEN tbl_tanggalkerja.tgl_kontrak IS NULL THEN NULL " & _
            "ELSE CASE WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_kontrak, GETDATE()) = 1 THEN " & _
            "CASE WHEN day(dbo.tbl_tanggalkerja.tgl_kontrak) < 16 THEN " & _
            "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 1 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 2 THEN'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 3 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 4 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 5 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 6 THEN 'ok' END " & _
            "WHEN day(dbo.tbl_tanggalkerja.tgl_kontrak) > 15 THEN " & _
            "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 1 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 2 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 3 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 4 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 5 THEN 'ok' END END " & _
            "WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_kontrak, GETDATE()) > 1 THEN 'ok' " & _
            "ELSE NULL END END " & _
            "ELSE CASE WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_masuk_rec, GETDATE()) = 1 THEN " & _
            "CASE WHEN day(dbo.tbl_tanggalkerja.tgl_masuk_rec) < 16 THEN " & _
            "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 1 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 2 THEN'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 3 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 4 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 5 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 6 THEN 'ok' END " & _
            "WHEN day(dbo.tbl_tanggalkerja.tgl_masuk_rec) > 15 THEN " & _
            "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 1 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 2 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 3 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 4 THEN 'ok' " & _
            "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 5 THEN 'ok' END END " & _
            "WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_masuk_rec, GETDATE()) > 1 THEN 'ok' " & _
            "ELSE NULL END END END) AS cuti " & _
            "FROM (SELECT tbl_pegawai.nik, tbl_pegawai.nama, jabatan.departemen, jabatan.jabawal, jabatan.jabakhir," & _
            "jabatan.status_karyawan, jabatan.atasan FROM (SELECT jab_awal.nik,jab_awal.departemen,  jab_awal.jabatan AS jabawal," & _
            "jab_akhir.jabatan AS jabakhir, jab_awal.status_karyawan, jab_awal.atasan " & _
            "FROM (SELECT tbl_jabatan.nik,tbl_jabatan.departemen, tbl_jabatan.jabatan, " & _
            "tbl_jabatan.status_karyawan, tbl_jabatan.atasan FROM tbl_jabatan " & _
            "WHERE year(tbl_jabatan.tgl_awal) = YEAR( @TGlawal)) AS jab_awal " & _
            "LEFT OUTER JOIN (SELECT tbl_jabatan.nik,tbl_jabatan.departemen, tbl_jabatan.jabatan," & _
            "tbl_jabatan.status_karyawan, tbl_jabatan.atasan " & _
            "FROM tbl_jabatan WHERE year(tbl_jabatan.tgl_awal) = YEAR( @TGlakhir)) AS jab_akhir ON " & _
            "jab_awal.nik = jab_akhir.nik) AS jabatan RIGHT OUTER JOIN tbl_pegawai ON " & _
            "jabatan.nik = tbl_pegawai.nik) AS tempjab LEFT OUTER JOIN tbl_tanggalkerja ON " & _
            "tempjab.nik = tbl_tanggalkerja.nik) AS temp " & _
            "WHERE temp.status_karyawan IN ('Kontrak', 'Tetap') " & _
            "AND (temp.nama LIKE  '%" & Text_cari.Text & "%')"
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@TGlawal", SqlDbType.Date).Value = DTawal.Text
                .Add("@TGlakhir", SqlDbType.Date).Value = DT_akhir.Text
                If Not condition = String.Empty Then
                    .AddWithValue("@condition", ComboFilter.Text)
                End If
                If opt = "KARYAWAN" Then
                    .Add("@status", SqlDbType.VarChar).Value = "Tetap"
                    .Add("@status2", SqlDbType.VarChar).Value = "Kontrak"
                Else
                    .Add("@status", SqlDbType.VarChar).Value = opt
                    .Add("@status2", SqlDbType.VarChar).Value = opt
                End If
            End With
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            grid.DataSource = DTab
            atur_griddtkaryawan(grid_karyawan)
        Catch ex As Exception
            MsgBox("Gagal menampilkan data karyawan " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub LoadDataFullKaryawan(ByVal grid As DataGridView, ByVal opt As String, _
                                     ByVal condition As String)
        Try
            clear_command()
            openDB()
            Select Case condition
                Case String.Empty
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY nik ASC) AS No, * FROM (SELECT temp.nik, temp.nama, temp.departemen, temp.jabatan, temp.status_karyawan, temp.atasan, " & _
                        "tbl_tanggalkerja.tgl_masuk_rec, tbl_tanggalkerja.tgl_masuk_harian, tbl_tanggalkerja.tgl_borongan, " & _
                        "convert(varchar,(DATEDIFF(YEAR,tbl_tanggalkerja.tgl_masuk_rec ,GETDATE())))" & _
                        "+ ' Tahun ' + convert(varchar,(DATEDIFF(month,tbl_tanggalkerja.tgl_masuk_rec ,GETDATE())%12)) + ' bulan' AS masakerja, " & _
                        "tbl_tanggalkerja.tgl_kontrak, tbl_tanggalkerja.tgl_tetap,tbl_tanggalkerja.tgl_keluar, " & _
                        "(CASE WHEN temp.status_karyawan = 'Harian Tetap' THEN NULL " & _
                        "WHEN temp.status_karyawan = 'Tanpa Status' THEN NULL " & _
                        "ELSE CASE WHEN tbl_tanggalkerja.tgl_masuk_rec IS NULL THEN " & _
                        "CASE WHEN tbl_tanggalkerja.tgl_kontrak IS NULL THEN NULL " & _
                        "ELSE CASE WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_kontrak, GETDATE()) = 1 THEN " & _
                        "CASE WHEN day(dbo.tbl_tanggalkerja.tgl_kontrak) < 16 THEN " & _
                        "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 1 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 2 THEN'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 3 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 4 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 5 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 6 THEN 'ok' END " & _
                        "WHEN day(dbo.tbl_tanggalkerja.tgl_kontrak) > 15 THEN " & _
                        "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 1 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 2 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 3 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 4 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 5 THEN 'ok' END END " & _
                        "WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_kontrak, GETDATE()) > 1 THEN 'ok' " & _
                        "ELSE NULL END END " & _
                        "ELSE CASE WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_masuk_rec, GETDATE()) = 1 THEN " & _
                        "CASE WHEN day(dbo.tbl_tanggalkerja.tgl_masuk_rec) < 16 THEN " & _
                        "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 1 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 2 THEN'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 3 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 4 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 5 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 6 THEN 'ok' END " & _
                        "WHEN day(dbo.tbl_tanggalkerja.tgl_masuk_rec) > 15 THEN " & _
                        "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 1 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 2 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 3 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 4 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 5 THEN 'ok' END END " & _
                        "WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_masuk_rec, GETDATE()) > 1 THEN 'ok' ELSE NULL END END END) AS cuti " & _
                        "FROM (SELECT tbl_pegawai.nik, tbl_pegawai.nama, " & _
                        "jab.departemen, jab.jabatan, " & _
                        "jab.status_karyawan, jab.atasan FROM tbl_pegawai OUTER APPLY " & _
                        "(SELECT  TOP (1) tbl_jabatan.nik, tbl_jabatan.departemen, tbl_jabatan.jabatan, " & _
                        "tbl_jabatan.atasan, tbl_jabatan.status_karyawan FROM tbl_jabatan " & _
                        "WHERE tbl_jabatan.nik = tbl_pegawai.nik ORDER BY tbl_jabatan.no_urut DESC) AS jab) AS temp " & _
                        "LEFT OUTER JOIN tbl_tanggalkerja ON temp.nik = tbl_tanggalkerja.nik) AS tmp " & _
                        "WHERE tmp.status_karyawan IN ( @status, @status2) OR tmp.status_karyawan LIKE '" & opt & "%'"
                Case "Departemen"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY nik ASC) AS No, * FROM (SELECT  " & _
                        "temp.nik, temp.nama, temp.departemen, temp.jabatan, temp.status_karyawan, temp.atasan, " & _
                        "tbl_tanggalkerja.tgl_masuk_rec, tbl_tanggalkerja.tgl_masuk_harian, tbl_tanggalkerja.tgl_borongan, " & _
                         "convert(varchar,(DATEDIFF(YEAR,tbl_tanggalkerja.tgl_masuk_rec ,GETDATE())))" & _
                        "+ ' Tahun ' + convert(varchar,(DATEDIFF(month,tbl_tanggalkerja.tgl_masuk_rec ,GETDATE())%12)) + ' bulan' AS masakerja, " & _
                        "tbl_tanggalkerja.tgl_kontrak, tbl_tanggalkerja.tgl_tetap,tbl_tanggalkerja.tgl_keluar, " & _
                        "(CASE WHEN temp.status_karyawan = 'Harian Tetap' THEN NULL " & _
                        "WHEN temp.status_karyawan = 'Tanpa Status' THEN NULL " & _
                        "ELSE CASE WHEN tbl_tanggalkerja.tgl_masuk_rec IS NULL THEN " & _
                        "CASE WHEN tbl_tanggalkerja.tgl_kontrak IS NULL THEN NULL " & _
                        "ELSE CASE WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_kontrak, GETDATE()) = 1 THEN " & _
                        "CASE WHEN day(dbo.tbl_tanggalkerja.tgl_kontrak) < 16 THEN " & _
                        "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 1 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 2 THEN'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 3 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 4 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 5 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 6 THEN 'ok' END " & _
                        "WHEN day(dbo.tbl_tanggalkerja.tgl_kontrak) > 15 THEN " & _
                        "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 1 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 2 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 3 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 4 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 5 THEN 'ok' END END " & _
                        "WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_kontrak, GETDATE()) > 1 THEN 'ok' " & _
                        "ELSE NULL END END " & _
                        "ELSE CASE WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_masuk_rec, GETDATE()) = 1 THEN " & _
                        "CASE WHEN day(dbo.tbl_tanggalkerja.tgl_masuk_rec) < 16 THEN " & _
                        "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 1 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 2 THEN'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 3 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 4 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 5 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 6 THEN 'ok' END " & _
                        "WHEN day(dbo.tbl_tanggalkerja.tgl_masuk_rec) > 15 THEN " & _
                        "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 1 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 2 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 3 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 4 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 5 THEN 'ok' END END " & _
                        "WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_masuk_rec, GETDATE()) > 1 THEN 'ok' ELSE NULL END END END) AS cuti " & _
                        "FROM (SELECT tbl_pegawai.nik, tbl_pegawai.nama, jab.departemen, jab.jabatan, " & _
                        "jab.status_karyawan, jab.atasan FROM tbl_pegawai OUTER APPLY " & _
                        "(SELECT  TOP (1) tbl_jabatan.nik, tbl_jabatan.departemen, tbl_jabatan.jabatan, " & _
                        "tbl_jabatan.atasan, tbl_jabatan.status_karyawan FROM tbl_jabatan " & _
                        "WHERE tbl_jabatan.nik = tbl_pegawai.nik ORDER BY tbl_jabatan.no_urut DESC) AS jab) AS temp " & _
                        "LEFT OUTER JOIN tbl_tanggalkerja ON temp.nik = tbl_tanggalkerja.nik) AS tmp " & _
                        "WHERE (tmp.status_karyawan IN ( @status, @status2) OR tmp.status_karyawan LIKE '" & opt & "%') " & _
                        "AND (tmp.departemen = @condition OR  tmp.jabatan = @condition OR tmp.status_karyawan = @condition)"
                Case "Pencarian"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY nik ASC) AS No, * FROM (SELECT  " & _
                        "temp.nik, temp.nama, temp.departemen, temp.jabatan, temp.status_karyawan, temp.atasan, " & _
                        "tbl_tanggalkerja.tgl_masuk_rec, tbl_tanggalkerja.tgl_masuk_harian, tbl_tanggalkerja.tgl_borongan, " & _
                        "convert(varchar,(DATEDIFF(YEAR,tbl_tanggalkerja.tgl_masuk_rec ,GETDATE()))) " & _
                        "+ ' Tahun ' + convert(varchar,(DATEDIFF(month,tbl_tanggalkerja.tgl_masuk_rec ,GETDATE())%12)) + ' bulan' AS masakerja, " & _
                        "tbl_tanggalkerja.tgl_kontrak, tbl_tanggalkerja.tgl_tetap,tbl_tanggalkerja.tgl_keluar, " & _
                        "(CASE WHEN temp.status_karyawan = 'Harian Tetap' THEN NULL " & _
                        "WHEN temp.status_karyawan = 'Tanpa Status' THEN NULL " & _
                        "ELSE CASE WHEN tbl_tanggalkerja.tgl_masuk_rec IS NULL THEN " & _
                        "CASE WHEN tbl_tanggalkerja.tgl_kontrak IS NULL THEN NULL " & _
                        "ELSE CASE WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_kontrak, GETDATE()) = 1 THEN " & _
                        "CASE WHEN day(dbo.tbl_tanggalkerja.tgl_kontrak) < 16 THEN " & _
                        "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 1 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 2 THEN'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 3 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 4 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 5 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 6 THEN 'ok' END " & _
                        "WHEN day(dbo.tbl_tanggalkerja.tgl_kontrak) > 15 THEN " & _
                        "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 1 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 2 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 3 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 4 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_kontrak) = 5 THEN 'ok' END END " & _
                        "WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_kontrak, GETDATE()) > 1 THEN 'ok' " & _
                        "ELSE NULL END END " & _
                        "ELSE CASE WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_masuk_rec, GETDATE()) = 1 THEN " & _
                        "CASE WHEN day(dbo.tbl_tanggalkerja.tgl_masuk_rec) < 16 THEN " & _
                        "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 1 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 2 THEN'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 3 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 4 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 5 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 6 THEN 'ok' END " & _
                        "WHEN day(dbo.tbl_tanggalkerja.tgl_masuk_rec) > 15 THEN " & _
                        "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 1 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 2 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 3 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 4 THEN 'ok' " & _
                        "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 5 THEN 'ok' END END " & _
                        "WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_masuk_rec, GETDATE()) > 1 THEN 'ok' ELSE NULL END END END) AS cuti " & _
                        "FROM (SELECT tbl_pegawai.nik, tbl_pegawai.nama, jab.departemen, jab.jabatan, " & _
                        "jab.status_karyawan, jab.atasan FROM tbl_pegawai OUTER APPLY " & _
                        "(SELECT  TOP (1) tbl_jabatan.nik, tbl_jabatan.departemen, tbl_jabatan.jabatan, " & _
                        "tbl_jabatan.atasan, tbl_jabatan.status_karyawan FROM tbl_jabatan " & _
                        "WHERE tbl_jabatan.nik = tbl_pegawai.nik ORDER BY tbl_jabatan.no_urut DESC) AS jab) AS temp " & _
                        "LEFT OUTER JOIN tbl_tanggalkerja ON temp.nik = tbl_tanggalkerja.nik) AS tmp " & _
                        "WHERE (tmp.status_karyawan IN ( @status, @status2) OR tmp.status_karyawan LIKE '" & opt & "%') " & _
                        "AND (tmp.nama LIKE '%" & Text_cari.Text & "%' OR tmp.nik LIKE '%" & Text_cari.Text & "%')"
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                If Not condition = String.Empty Then
                    .AddWithValue("@condition", ComboFilter.Text)
                End If
                If opt = "KARYAWAN" Then
                    .Add("@status", SqlDbType.VarChar).Value = "Tetap"
                    .Add("@status2", SqlDbType.VarChar).Value = "Kontrak"
                Else
                    .Add("@status", SqlDbType.VarChar).Value = opt
                    .Add("@status2", SqlDbType.VarChar).Value = opt
                End If
            End With
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            grid.DataSource = DTab
            atur_griddtkaryjab(grid_karyawan)
            grid.Refresh()
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data keseluruhan " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    'memanggil data harian
    Private Sub load_gridfullharians(ByVal grid As DataGridView, ByVal condition As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            Select Case condition
                Case String.Empty
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY view_dtpegawai.nik ASC) AS No, " & _
                        "view_dtpegawai.nik, view_dtpegawai.nama, view_dtpegawai.departemen, " & _
                "view_dtpegawai.jabatan, view_dtpegawai.atasan, view_dtpegawai.status_karyawan, " & _
                "temp.tgl_masuk, temp.tgl_keluar, temp.no_urut FROM view_dtpegawai  OUTER APPLY " & _
                "(SELECT TOP (1) tbl_tglharians.nik ,tbl_tglharians .tgl_masuk , tbl_tglharians.tgl_keluar, " & _
                "tbl_tglharians.no_urut FROM tbl_tglharians WHERE tbl_tglharians.nik = view_dtpegawai.nik " & _
                "ORDER BY tbl_tglharians .no_urut DESC) AS temp " & _
                "WHERE view_dtpegawai .status_karyawan LIKE '%Harian%' ORDER BY view_dtpegawai .nik"
                Case "pencarian"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY view_dtpegawai.nik ASC) AS No, * FROM " & _
                "(SELECT view_dtpegawai.nik, view_dtpegawai.nama, view_dtpegawai.departemen, " & _
                "view_dtpegawai.jabatan, view_dtpegawai.atasan, view_dtpegawai.status_karyawan, " & _
                "temp.tgl_masuk, temp.tgl_keluar, temp.no_urut FROM view_dtpegawai  OUTER APPLY " & _
                "(SELECT TOP (1) tbl_tglharians.nik ,tbl_tglharians .tgl_masuk , tbl_tglharians.tgl_keluar, " & _
                "tbl_tglharians.no_urut FROM tbl_tglharians WHERE tbl_tglharians.nik = view_dtpegawai.nik " & _
                "ORDER BY tbl_tglharians .no_urut DESC) AS temp " & _
                "WHERE view_dtpegawai .status_karyawan LIKE '%Harian%') AS temp2 " & _
                "WHERE temp2.nama LIKE '%" & Text_cari.Text & "%' OR temp2.nik LIKE '%" & Text_cari.Text & "%' " & _
                "ORDER BY temp2.nik"
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            grid.DataSource = DTab
            atur_gridharian(grid_karyawan)
            grid.Refresh()
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data harian sementara " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub LoadDataKTP(ByVal grid As DataGridView, ByVal opt As String, _
                                     ByVal condition As String)
        Try
            clear_command()
            openDB()
            Cursor.Current = Cursors.WaitCursor
            Select Case condition
                Case String.Empty
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, " & _
                        "temp.nik, temp.nama, temp.departemen, temp.status_karyawan, temp.no_kk, temp.no_ktp, " & _
                        "temp.tempat_lahir, temp.tgl_lahir, temp.umur, temp.agama, temp.sex, temp.status_kawin, " & _
                        "temp.pendidikan, temp.alamat_asal, temp.desa_asal, temp.rt_asal, temp.rw_asal, " & _
                        "temp.kec_asal, temp.kab_asal, temp.kdpos_asal, temp.no_telp, " & _
                        "temp.email, temp.kerabat, temp.telp_kerabat FROM (SELECT " & _
                        "tbl_pegawai.nik, tbl_pegawai.nama, " & _
                        "convert(varchar,(DATEDIFF(year,tgl_lahir ,GETDATE()))) " & _
                        "+ ' Tahun ' + convert(varchar,(DATEDIFF(month,tgl_lahir ,GETDATE())%12)) + ' bulan' AS umur, " & _
                        "jab.departemen, jab.status_karyawan ,tbl_pegawai.no_kk, tbl_pegawai.no_ktp, " & _
                        "tbl_pegawai.tempat_lahir, tbl_pegawai.tgl_lahir, tbl_pegawai.agama, tbl_pegawai.sex, " & _
                        "tbl_pegawai.pendidikan,tbl_pegawai.alamat_asal, tbl_pegawai.desa_asal, tbl_pegawai.rt_asal, tbl_pegawai.rw_asal, " & _
                        "tbl_pegawai.kec_asal, tbl_pegawai.kab_asal, tbl_pegawai.kdpos_asal, tbl_pegawai.no_telp, " & _
                        "tbl_pegawai.email, tbl_pegawai.status_kawin, tbl_pegawai.kerabat, tbl_pegawai.telp_kerabat FROM  tbl_pegawai " & _
                        "OUTER APPLY " & _
                        "(SELECT TOP (1) tbl_jabatan.nik, tbl_jabatan.departemen, tbl_jabatan.status_karyawan " & _
                        "FROM tbl_jabatan WHERE tbl_jabatan.nik = tbl_pegawai.nik ORDER BY tbl_jabatan.no_urut DESC) AS jab) " & _
                        "AS temp WHERE temp.status_karyawan IN (@status, @status2) OR temp.status_karyawan LIKE '" & opt & "%' ORDER BY temp.nik"
                Case "Departemen"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp2.nik ASC) AS No, * FROM (SELECT " & _
                        "temp.nik, temp.nama, temp.departemen, temp.status_karyawan, temp.no_kk, temp.no_ktp, " & _
                        "temp.tempat_lahir, temp.tgl_lahir, temp.umur, temp.agama, temp.sex, temp.status_kawin, " & _
                        "temp.pendidikan, temp.alamat_asal, temp.desa_asal, temp.rt_asal, temp.rw_asal, " & _
                        "temp.kec_asal, temp.kab_asal, temp.kdpos_asal, temp.no_telp, " & _
                        "temp.email, temp.kerabat, temp.telp_kerabat FROM (SELECT " & _
                        "tbl_pegawai.nik, tbl_pegawai.nama, " & _
                        "convert(varchar,(DATEDIFF(year,tgl_lahir ,GETDATE()))) " & _
                        "+ ' Tahun ' + convert(varchar,(DATEDIFF(month,tgl_lahir ,GETDATE())%12)) + ' bulan' AS umur, " & _
                        "jab.departemen, jab.status_karyawan ,tbl_pegawai.no_kk, tbl_pegawai.no_ktp, " & _
                        "tbl_pegawai.tempat_lahir, tbl_pegawai.tgl_lahir, tbl_pegawai.agama, tbl_pegawai.sex, " & _
                        "tbl_pegawai.pendidikan,tbl_pegawai.alamat_asal, tbl_pegawai.desa_asal, tbl_pegawai.rt_asal, tbl_pegawai.rw_asal, " & _
                        "tbl_pegawai.kec_asal, tbl_pegawai.kab_asal, tbl_pegawai.kdpos_asal, tbl_pegawai.no_telp, " & _
                        "tbl_pegawai.email, tbl_pegawai.status_kawin, tbl_pegawai.kerabat, tbl_pegawai.telp_kerabat FROM  tbl_pegawai " & _
                        "OUTER APPLY " & _
                        "(SELECT TOP (1) tbl_jabatan.nik, tbl_jabatan.departemen, tbl_jabatan.status_karyawan " & _
                        "FROM tbl_jabatan WHERE tbl_jabatan.nik = tbl_pegawai.nik ORDER BY tbl_jabatan.no_urut DESC) AS jab) " & _
                        "AS temp WHERE (temp.status_karyawan IN (@status, @status2) OR temp.status_karyawan LIKE '" & opt & "%')) as temp2 " & _
                        "WHERE temp2.departemen = @condition OR temp2.agama = @condition OR temp2.sex = @condition " & _
                        "OR temp2.status_kawin = @condition OR temp2.pendidikan = @condition " & _
                        "OR temp2.kab_asal = @condition OR temp2.kec_asal = @condition OR temp2.desa_asal = @condition ORDER BY temp2.nik"
                Case "Pencarian"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp2.nik ASC) AS No, * FROM (SELECT " & _
                        "temp.nik, temp.nama, temp.departemen, temp.status_karyawan, temp.no_kk, temp.no_ktp, " & _
                        "temp.tempat_lahir, temp.tgl_lahir, temp.umur,  temp.agama, temp.sex, temp.status_kawin, " & _
                        "temp.pendidikan, temp.alamat_asal, temp.desa_asal, temp.rt_asal, temp.rw_asal, " & _
                        "temp.kec_asal, temp.kab_asal, temp.kdpos_asal, temp.no_telp, " & _
                        "temp.email, temp.kerabat, temp.telp_kerabat FROM (SELECT " & _
                        "tbl_pegawai.nik, tbl_pegawai.nama, " & _
                        "convert(varchar,(DATEDIFF(year,tgl_lahir ,GETDATE()))) " & _
                        "+ ' Tahun ' + convert(varchar,(DATEDIFF(month,tgl_lahir ,GETDATE())%12)) + ' bulan' AS umur, " & _
                        "jab.departemen, jab.status_karyawan ,tbl_pegawai.no_kk, tbl_pegawai.no_ktp, " & _
                        "tbl_pegawai.tempat_lahir, tbl_pegawai.tgl_lahir, tbl_pegawai.agama, tbl_pegawai.sex, " & _
                        "tbl_pegawai.pendidikan,tbl_pegawai.alamat_asal, tbl_pegawai.desa_asal, tbl_pegawai.rt_asal, tbl_pegawai.rw_asal, " & _
                        "tbl_pegawai.kec_asal, tbl_pegawai.kab_asal, tbl_pegawai.kdpos_asal, tbl_pegawai.no_telp, " & _
                        "tbl_pegawai.email, tbl_pegawai.status_kawin, tbl_pegawai.kerabat, tbl_pegawai.telp_kerabat FROM  tbl_pegawai " & _
                        "OUTER APPLY " & _
                        "(SELECT TOP (1) tbl_jabatan.nik, tbl_jabatan.departemen, tbl_jabatan.status_karyawan " & _
                        "FROM tbl_jabatan WHERE tbl_jabatan.nik = tbl_pegawai.nik ORDER BY tbl_jabatan.no_urut DESC) AS jab) " & _
                        "AS temp WHERE (temp.status_karyawan IN ( @status, @status2 ) OR temp.status_karyawan LIKE '" & opt & "%' )) AS temp2 " & _
                        "WHERE temp2.nama LIKE '%" & Text_cariktp.Text & "%' ORDER BY temp2.nik"
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                If Not condition = String.Empty Then
                    .AddWithValue("@condition", combo_filterKTP.Text)
                End If
                If opt = "KARYAWAN" Then
                    .Add("@status", SqlDbType.VarChar).Value = "Tetap"
                    .Add("@status2", SqlDbType.VarChar).Value = "Kontrak"
                Else
                    .Add("@status", SqlDbType.VarChar).Value = opt
                    .Add("@status2", SqlDbType.VarChar).Value = opt
                End If
            End With

            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            grid.DataSource = DTab
            atur_gridKTP(grid_dtKTP)
            grid.Refresh()
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data personal KTP " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            sql = String.Empty
            Conn.Close()
            Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Private Sub LoadDataDomisili(ByVal grid As DataGridView, ByVal opt As String, ByVal condition As String)
        Try
            clear_command()
            openDB()
            Cursor.Current = Cursors.WaitCursor
            Select Case condition
                Case String.Empty
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, " & _
                        "temp.nik, temp.nama, temp.departemen, temp.status_karyawan, temp.no_kk, temp.no_ktp, " & _
                        "temp.tempat_lahir, temp.tgl_lahir, temp.umur, temp.agama, temp.sex, temp.status_kawin, " & _
                        "temp.pendidikan, temp.alamat_dom, temp.desa_dom, temp.rt_dom, temp.rw_dom, " & _
                        "temp.kec_dom, temp.kab_dom, temp.kdpos_dom, temp.no_telp, " & _
                        "temp.email, temp.kerabat, temp.telp_kerabat FROM (SELECT " & _
                        "tbl_pegawai.nik, tbl_pegawai.nama, " & _
                        "convert(varchar,(DATEDIFF(year,tgl_lahir ,GETDATE()))) " & _
                        "+ ' Tahun ' + convert(varchar,(DATEDIFF(month,tgl_lahir ,GETDATE())%12)) + ' bulan' AS umur, " & _
                        "jab.departemen, jab.status_karyawan ,tbl_pegawai.no_kk, tbl_pegawai.no_ktp, " & _
                        "tbl_pegawai.tempat_lahir, tbl_pegawai.tgl_lahir, tbl_pegawai.agama, tbl_pegawai.sex, " & _
                        "tbl_pegawai.pendidikan, tbl_pegawai.alamat_dom, tbl_pegawai.desa_dom, tbl_pegawai.rt_dom, " & _
                        "tbl_pegawai.rw_dom, tbl_pegawai.kec_dom, tbl_pegawai.kab_dom, tbl_pegawai.kdpos_dom, tbl_pegawai.no_telp, " & _
                        "tbl_pegawai.email, tbl_pegawai.status_kawin, tbl_pegawai.kerabat, tbl_pegawai.telp_kerabat " & _
                        "FROM  tbl_pegawai " & _
                        "OUTER APPLY " & _
                        "(SELECT TOP (1) tbl_jabatan.nik, tbl_jabatan.departemen, tbl_jabatan.status_karyawan " & _
                        "FROM tbl_jabatan WHERE tbl_jabatan.nik = tbl_pegawai.nik ORDER BY tbl_jabatan.no_urut DESC) AS jab) " & _
                        "AS temp WHERE temp.status_karyawan IN (@status, @status2) OR temp.status_karyawan LIKE '" & opt & "%' ORDER BY temp.nik"
                Case "Departemen"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, * FROM " & _
                        "(SELECT temp.nik, temp.nama, temp.departemen, temp.status_karyawan, temp.no_kk, temp.no_ktp, " & _
                        "temp.tempat_lahir, temp.tgl_lahir, temp.umur, temp.agama, temp.sex, temp.status_kawin, " & _
                        "temp.pendidikan, temp.alamat_dom, temp.desa_dom, temp.rt_dom, temp.rw_dom, " & _
                        "temp.kec_dom, temp.kab_dom, temp.kdpos_dom, temp.no_telp, " & _
                        "temp.email, temp.kerabat, temp.telp_kerabat FROM (SELECT " & _
                        "tbl_pegawai.nik, tbl_pegawai.nama, " & _
                        "convert(varchar,(DATEDIFF(year,tgl_lahir ,GETDATE()))) " & _
                        "+ ' Tahun ' + convert(varchar,(DATEDIFF(month,tgl_lahir ,GETDATE())%12)) + ' bulan' AS umur, " & _
                        "jab.departemen, jab.status_karyawan ,tbl_pegawai.no_kk, tbl_pegawai.no_ktp, " & _
                        "tbl_pegawai.tempat_lahir, tbl_pegawai.tgl_lahir, tbl_pegawai.agama, tbl_pegawai.sex, " & _
                        "tbl_pegawai.pendidikan, tbl_pegawai.alamat_dom, tbl_pegawai.desa_dom, tbl_pegawai.rt_dom, " & _
                        "tbl_pegawai.rw_dom, tbl_pegawai.kec_dom, tbl_pegawai.kab_dom, tbl_pegawai.kdpos_dom, tbl_pegawai.no_telp, " & _
                        "tbl_pegawai.email, tbl_pegawai.status_kawin, tbl_pegawai.kerabat, tbl_pegawai.telp_kerabat " & _
                        "FROM  tbl_pegawai " & _
                        "OUTER APPLY " & _
                        "(SELECT TOP (1) tbl_jabatan.nik, tbl_jabatan.departemen, tbl_jabatan.status_karyawan " & _
                        "FROM tbl_jabatan WHERE tbl_jabatan.nik = tbl_pegawai.nik ORDER BY tbl_jabatan.no_urut DESC) AS jab) " & _
                        "AS temp WHERE (temp.status_karyawan IN (@status, @status2) OR temp.status_karyawan LIKE '" & opt & "%' )) AS temp2 " & _
                        " WHERE temp2.departemen = @condition OR temp2.agama = @condition OR temp2.sex = @condition " & _
                        "OR temp2.status_kawin = @condition OR temp2.pendidikan = @condition " & _
                        "OR temp2.kab_dom = @condition OR temp2.kec_dom = @condition OR temp2.desa_dom = @condition) ORDER BY temp2.nik"
                Case "Pencarian"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, " & _
                        "temp.nik, temp.nama, temp.departemen, temp.status_karyawan, temp.no_kk, temp.no_ktp, " & _
                        "temp.tempat_lahir, temp.tgl_lahir, temp.umur, temp.agama, temp.sex, temp.status_kawin, " & _
                        "temp.pendidikan, temp.alamat_dom, temp.desa_dom, temp.rt_dom, temp.rw_dom, " & _
                        "temp.kec_dom, temp.kab_dom, temp.kdpos_dom, temp.no_telp, " & _
                        "temp.email, temp.kerabat, temp.telp_kerabat FROM (SELECT " & _
                        "tbl_pegawai.nik, tbl_pegawai.nama, " & _
                        "convert(varchar,(DATEDIFF(year,tgl_lahir ,GETDATE()))) " & _
                        "+ ' Tahun ' + convert(varchar,(DATEDIFF(month,tgl_lahir ,GETDATE())%12)) + ' bulan' AS umur, " & _
                        "jab.departemen, jab.status_karyawan ,tbl_pegawai.no_kk, tbl_pegawai.no_ktp, " & _
                        "tbl_pegawai.tempat_lahir, tbl_pegawai.tgl_lahir, tbl_pegawai.agama, tbl_pegawai.sex, " & _
                        "tbl_pegawai.pendidikan, tbl_pegawai.alamat_dom, tbl_pegawai.desa_dom, tbl_pegawai.rt_dom, " & _
                        "tbl_pegawai.rw_dom, tbl_pegawai.kec_dom, tbl_pegawai.kab_dom, tbl_pegawai.kdpos_dom, tbl_pegawai.no_telp, " & _
                        "tbl_pegawai.email, tbl_pegawai.status_kawin, tbl_pegawai.kerabat, tbl_pegawai.telp_kerabat " & _
                        "FROM  tbl_pegawai " & _
                        "OUTER APPLY " & _
                        "(SELECT TOP (1) tbl_jabatan.nik, tbl_jabatan.departemen, tbl_jabatan.status_karyawan " & _
                        "FROM tbl_jabatan WHERE tbl_jabatan.nik = tbl_pegawai.nik ORDER BY tbl_jabatan.no_urut DESC) AS jab) " & _
                        "AS temp WHERE (temp.status_karyawan IN (@status, @status2) OR temp.status_karyawan LIKE '" & opt & "%') AND " & _
                        "(temp.nama LIKE '%" & Text_caridom.Text & "%' ) ORDER BY temp.nik"
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                If Not condition = String.Empty Then
                    .AddWithValue("@condition", Combo_filterDom.Text)
                End If
                If opt = "KARYAWAN" Then
                    .Add("@status", SqlDbType.VarChar).Value = "Tetap"
                    .Add("@status2", SqlDbType.VarChar).Value = "Kontrak"
                Else
                    .Add("@status", SqlDbType.VarChar).Value = opt
                    .Add("@status2", SqlDbType.VarChar).Value = opt
                End If
            End With
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            grid.DataSource = DTab
            atur_gridKTP(grid_DataDom)
            grid.Refresh()
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data personal Domisili " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            sql = String.Empty
            Conn.Close()
            Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Private Sub LoadDataKeluarga(ByVal grid As DataGridView, ByVal opt As String, _
                                     ByVal condition As String)
        Try
            clear_command()
            openDB()
            Cursor.Current = Cursors.WaitCursor
            Select Case condition
                Case String.Empty
                    sql = "SELECT DISTINCT ROW_NUMBER() OVER(ORDER BY temp2.nik ASC) AS No,temp2.nik, temp2.nama, " & _
                        "temp2.departemen, temp2.status_karyawan, temp2.istri, temp2.no_ktp, temp2.tempat_lahir, " & _
                        "temp2.tgl_lahir, temp2.Anak1, temp2.no_ktp1, temp2.Tempat_lahir1, " & _
                        "temp2.tgl_lahir1, temp2.Anak2, temp2.no_ktp2, temp2.Tempat_lahir2, temp2.tgl_lahir2, " & _
                        "temp2.Anak3, temp2.no_ktp3, temp2.Tempat_lahir3, temp2.tgl_lahir3 " & _
                        "FROM (SELECT temp.nik, temp.nama, temp.departemen, temp.status_karyawan, " & _
                        "tbl_istri.nama as istri, tbl_istri.no_ktp, tbl_istri.Tempat_lahir, " & _
                        "tbl_istri.tgl_lahir, temp.Anak1, temp.no_ktp1, temp.Tempat_lahir1, temp.tgl_lahir1, " & _
                        "temp.Anak2, temp.no_ktp2, temp.Tempat_lahir2, temp.tgl_lahir2, temp.Anak3, " & _
                        "temp.no_ktp3, temp.Tempat_lahir3, temp.tgl_lahir3 " & _
                        "FROM (SELECT view_dtpegawai.nik,view_dtpegawai.nama, view_dtpegawai.departemen, " & _
                        "view_dtpegawai.status_karyawan, dt_anak.Anak1, dt_anak.no_ktp1, dt_anak.Tempat_lahir1, " & _
                        "dt_anak.tgl_lahir1, dt_anak.Anak2, dt_anak.no_ktp2,dt_anak.Tempat_lahir2, " & _
                        "dt_anak.tgl_lahir2, dt_anak.Anak3, dt_anak.no_ktp3,dt_anak.Tempat_lahir3, dt_anak.tgl_lahir3 " & _
                        "FROM (SELECT DISTINCT nik, t1.[nama]  AS Anak1, t1.[no_ktp] As no_ktp1, " & _
                        "t1.[tempat_lahir] AS Tempat_lahir1, " & _
                        "t1.[tgl_lahir] AS tgl_lahir1, t2.[nama]  AS Anak2, t2.[no_ktp] As no_ktp2, " & _
                        "t2.[tempat_lahir] AS Tempat_lahir2, t2.[tgl_lahir] AS tgl_lahir2, t3.[nama] AS Anak3, " & _
                        "t3.[no_ktp] As no_ktp3, t3.[tempat_lahir] AS Tempat_lahir3, " & _
                        "t3.[tgl_lahir]   AS tgl_lahir3 FROM tbl_anak t " & _
                        "OUTER APPLY ( SELECT TOP 1 [nama],[no_ktp], [tempat_lahir], [tgl_lahir] FROM " & _
                        "tbl_anak WHERE nik = t.nik AND [id_anak] = 1 ) t1 " & _
                        "OUTER APPLY ( SELECT TOP 1 [nama],[no_ktp], [tempat_lahir], [tgl_lahir] FROM " & _
                        "tbl_anak WHERE nik = t.nik AND [id_anak] = 2 ) t2 OUTER APPLY " & _
                        "( SELECT TOP 1 [nama],[no_ktp], [tempat_lahir], [tgl_lahir] FROM tbl_anak " & _
                        "WHERE nik = t.nik AND [id_anak] = 3 ) t3) AS dt_anak RIGHT OUTER JOIN view_dtpegawai ON " & _
                        "dt_anak.nik =   view_dtpegawai.nik) AS temp LEFT OUTER JOIN " & _
                        "tbl_istri ON temp.nik = tbl_istri.nik) AS temp2 " & _
                        "WHERE temp2.status_karyawan IN (@status, @status2) OR temp2.status_karyawan LIKE '" & opt & "%'  order by temp2.nik"
                Case "Departemen"
                    sql = "SELECT DISTINCT ROW_NUMBER() OVER(ORDER BY temp2.nik ASC) AS No,temp2.nik, temp2.nama, " & _
                        "temp2.departemen, temp2.status_karyawan, temp2.istri, temp2.no_ktp, temp2.tempat_lahir, " & _
                        "temp2.tgl_lahir, temp2.Anak1, temp2.no_ktp1, temp2.Tempat_lahir1, " & _
                        "temp2.tgl_lahir1, temp2.Anak2, temp2.no_ktp2, temp2.Tempat_lahir2, temp2.tgl_lahir2, " & _
                        "temp2.Anak3, temp2.no_ktp3, temp2.Tempat_lahir3, temp2.tgl_lahir3 " & _
                        "FROM (SELECT temp.nik, temp.nama, temp.departemen, temp.status_karyawan, " & _
                        "tbl_istri.nama as istri, tbl_istri.no_ktp, tbl_istri.Tempat_lahir, " & _
                        "tbl_istri.tgl_lahir, temp.Anak1, temp.no_ktp1, temp.Tempat_lahir1, temp.tgl_lahir1, " & _
                        "temp.Anak2, temp.no_ktp2, temp.Tempat_lahir2, temp.tgl_lahir2, temp.Anak3, " & _
                        "temp.no_ktp3, temp.Tempat_lahir3, temp.tgl_lahir3 " & _
                        "FROM (SELECT view_dtpegawai.nik,view_dtpegawai.nama, view_dtpegawai.departemen, " & _
                        "view_dtpegawai.status_karyawan, dt_anak.Anak1, dt_anak.no_ktp1, dt_anak.Tempat_lahir1, " & _
                        "dt_anak.tgl_lahir1, dt_anak.Anak2, dt_anak.no_ktp2,dt_anak.Tempat_lahir2, " & _
                        "dt_anak.tgl_lahir2, dt_anak.Anak3, dt_anak.no_ktp3,dt_anak.Tempat_lahir3, dt_anak.tgl_lahir3 " & _
                        "FROM (SELECT DISTINCT nik, t1.[nama]  AS Anak1, t1.[no_ktp] As no_ktp1, " & _
                        "t1.[tempat_lahir] AS Tempat_lahir1, " & _
                        "t1.[tgl_lahir] AS tgl_lahir1, t2.[nama]  AS Anak2, t2.[no_ktp] As no_ktp2, " & _
                        "t2.[tempat_lahir] AS Tempat_lahir2, t2.[tgl_lahir] AS tgl_lahir2, t3.[nama] AS Anak3, " & _
                        "t3.[no_ktp] As no_ktp3, t3.[tempat_lahir] AS Tempat_lahir3, " & _
                        "t3.[tgl_lahir]   AS tgl_lahir3 FROM tbl_anak t " & _
                        "OUTER APPLY ( SELECT TOP 1 [nama],[no_ktp], [tempat_lahir], [tgl_lahir] FROM " & _
                        "tbl_anak WHERE nik = t.nik AND [id_anak] = 1 ) t1 " & _
                        "OUTER APPLY ( SELECT TOP 1 [nama],[no_ktp], [tempat_lahir], [tgl_lahir] FROM " & _
                        "tbl_anak WHERE nik = t.nik AND [id_anak] = 2 ) t2 OUTER APPLY " & _
                        "( SELECT TOP 1 [nama],[no_ktp], [tempat_lahir], [tgl_lahir] FROM tbl_anak " & _
                        "WHERE nik = t.nik AND [id_anak] = 3 ) t3) AS dt_anak RIGHT OUTER JOIN view_dtpegawai ON " & _
                        "dt_anak.nik =   view_dtpegawai.nik) AS temp LEFT OUTER JOIN " & _
                        "tbl_istri ON temp.nik = tbl_istri.nik) AS temp2 " & _
                        "WHERE (temp2.status_karyawan IN( @status, @status2) OR temp2.status_karyawan LIKE '" & opt & "%') AND " & _
                        "(temp2.departemen = @condition OR temp2.status_karyawan = @condition ) ORDER BY temp2.nik"
                Case "Pencarian"
                    sql = "SELECT DISTINCT ROW_NUMBER() OVER(ORDER BY temp2.nik ASC) AS No,temp2.nik, temp2.nama, " & _
                        "temp2.departemen, temp2.status_karyawan, temp2.istri, temp2.no_ktp, temp2.tempat_lahir, " & _
                        "temp2.tgl_lahir, temp2.Anak1, temp2.no_ktp1, temp2.Tempat_lahir1, " & _
                        "temp2.tgl_lahir1, temp2.Anak2, temp2.no_ktp2, temp2.Tempat_lahir2, temp2.tgl_lahir2, " & _
                        "temp2.Anak3, temp2.no_ktp3, temp2.Tempat_lahir3, temp2.tgl_lahir3 " & _
                        "FROM (SELECT temp.nik, temp.nama, temp.departemen, temp.status_karyawan, " & _
                        "tbl_istri.nama as istri, tbl_istri.no_ktp, tbl_istri.Tempat_lahir, " & _
                        "tbl_istri.tgl_lahir, temp.Anak1, temp.no_ktp1, temp.Tempat_lahir1, temp.tgl_lahir1, " & _
                        "temp.Anak2, temp.no_ktp2, temp.Tempat_lahir2, temp.tgl_lahir2, temp.Anak3, " & _
                        "temp.no_ktp3, temp.Tempat_lahir3, temp.tgl_lahir3 " & _
                        "FROM (SELECT view_dtpegawai.nik,view_dtpegawai.nama, view_dtpegawai.departemen, " & _
                        "view_dtpegawai.status_karyawan, dt_anak.Anak1, dt_anak.no_ktp1, dt_anak.Tempat_lahir1, " & _
                        "dt_anak.tgl_lahir1, dt_anak.Anak2, dt_anak.no_ktp2,dt_anak.Tempat_lahir2, " & _
                        "dt_anak.tgl_lahir2, dt_anak.Anak3, dt_anak.no_ktp3,dt_anak.Tempat_lahir3, dt_anak.tgl_lahir3 " & _
                        "FROM (SELECT DISTINCT nik, t1.[nama]  AS Anak1, t1.[no_ktp] As no_ktp1, " & _
                        "t1.[tempat_lahir] AS Tempat_lahir1, " & _
                        "t1.[tgl_lahir] AS tgl_lahir1, t2.[nama]  AS Anak2, t2.[no_ktp] As no_ktp2, " & _
                        "t2.[tempat_lahir] AS Tempat_lahir2, t2.[tgl_lahir] AS tgl_lahir2, t3.[nama] AS Anak3, " & _
                        "t3.[no_ktp] As no_ktp3, t3.[tempat_lahir] AS Tempat_lahir3, " & _
                        "t3.[tgl_lahir]   AS tgl_lahir3 FROM tbl_anak t " & _
                        "OUTER APPLY ( SELECT TOP 1 [nama],[no_ktp], [tempat_lahir], [tgl_lahir] FROM " & _
                        "tbl_anak WHERE nik = t.nik AND [id_anak] = 1 ) t1 " & _
                        "OUTER APPLY ( SELECT TOP 1 [nama],[no_ktp], [tempat_lahir], [tgl_lahir] FROM " & _
                        "tbl_anak WHERE nik = t.nik AND [id_anak] = 2 ) t2 OUTER APPLY " & _
                        "( SELECT TOP 1 [nama],[no_ktp], [tempat_lahir], [tgl_lahir] FROM tbl_anak " & _
                        "WHERE nik = t.nik AND [id_anak] = 3 ) t3) AS dt_anak RIGHT OUTER JOIN view_dtpegawai ON " & _
                        "dt_anak.nik =   view_dtpegawai.nik) AS temp LEFT OUTER JOIN " & _
                        "tbl_istri ON temp.nik = tbl_istri.nik) AS temp2 " & _
                        "WHERE (temp2.status_karyawan IN ( @status, @status2) OR temp2.status_karyawan LIKE '" & opt & "%') AND " & _
                        "(temp2.nama like '%" & Text_carikel.Text & "%') order by temp2.nik"
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                If Not condition = String.Empty Then
                    .AddWithValue("@condition", Combo_filterKel.Text)
                End If
                If opt = "KARYAWAN" Then
                    .Add("@status", SqlDbType.VarChar).Value = "Tetap"
                    .Add("@status2", SqlDbType.VarChar).Value = "Kontrak"
                Else
                    .Add("@status", SqlDbType.VarChar).Value = opt
                    .Add("@status2", SqlDbType.VarChar).Value = opt
                End If
            End With
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            grid.DataSource = DTab
            atur_griddtkeluarga(grid_keluarga)
            grid.Refresh()
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data keluarga " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
            sql = String.Empty
            Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Private Sub LoadDataFaskes(ByVal grid As DataGridView, ByVal opt As String, _
                                     ByVal condition As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            Select Case condition
                Case String.Empty
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY view_dtpegawai.nik  ASC) AS No,view_dtpegawai.nik, " & _
                    "view_dtpegawai.nama, view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                    "view_dtpegawai.status_karyawan, tbl_pegawai.sex, tbl_pegawai.agama, tbl_pegawai.no_telp, " & _
                    "tbl_pegawai.status_kawin, tbl_pegawai.faskes_tk1, tbl_pegawai.faskes_gigi " & _
                    "FROM view_dtpegawai LEFT OUTER JOIN tbl_pegawai ON view_dtpegawai.nik = tbl_pegawai.nik " & _
                    "WHERE view_dtpegawai.status_karyawan IN (@status, @status2) OR view_dtpegawai.status_karyawan LIKE '" & opt & "%' " & _
                    "ORDER BY view_dtpegawai.nik"
                Case "Departemen"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY view_dtpegawai.nik  ASC) AS No,view_dtpegawai.nik, " & _
                    "view_dtpegawai.nama, view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                    "view_dtpegawai.status_karyawan, tbl_pegawai.sex, tbl_pegawai.agama, tbl_pegawai.no_telp, " & _
                    "tbl_pegawai.status_kawin, tbl_pegawai.faskes_tk1, tbl_pegawai.faskes_gigi " & _
                    "FROM view_dtpegawai LEFT OUTER JOIN tbl_pegawai ON view_dtpegawai.nik = tbl_pegawai.nik " & _
                    "WHERE (view_dtpegawai.status_karyawan IN (@status, @status2) OR view_dtpegawai.status_karyawan LIKE '" & opt & "%') " & _
                    "AND (view_dtpegawai.departemen = @condition OR view_dtpegawai.status_karyawan = @condition " & _
                    "OR tbl_pegawai.sex = @condition OR tbl_pegawai.status_kawin = @condition)"
                Case "Pencarian"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY view_dtpegawai.nik  ASC) AS No,view_dtpegawai.nik, " & _
                   "view_dtpegawai.nama, view_dtpegawai.departemen, view_dtpegawai.jabatan, " & _
                   "view_dtpegawai.status_karyawan, tbl_pegawai.sex, tbl_pegawai.agama, tbl_pegawai.no_telp, " & _
                   "tbl_pegawai.status_kawin, tbl_pegawai.faskes_tk1, tbl_pegawai.faskes_gigi " & _
                   "FROM view_dtpegawai LEFT OUTER JOIN tbl_pegawai ON view_dtpegawai.nik = tbl_pegawai.nik " & _
                   "WHERE (view_dtpegawai.status_karyawan IN (@status, @status2) OR view_dtpegawai.status_karyawan LIKE '" & opt & "%') " & _
                   "AND view_dtpegawai.nama LIKE '%" & Text_carifas.Text & "%' "
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                If Not condition = String.Empty Then
                    .AddWithValue("@condition", Combo_filerFK.Text)
                End If
                If opt = "KARYAWAN" Then
                    .Add("@status", SqlDbType.VarChar).Value = "Tetap"
                    .Add("@status2", SqlDbType.VarChar).Value = "Kontrak"
                Else
                    .Add("@status", SqlDbType.VarChar).Value = opt
                    .Add("@status2", SqlDbType.VarChar).Value = opt
                End If
            End With
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            grid.DataSource = DTab
            atur_gridfaskes(grid_faskes)
            grid.Refresh()
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data fasilitas kesehatan " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Private Sub atur_griddtkaryawan(ByVal grid As DataGridView)
        With grid
            .ReadOnly = True
            .Enabled = True
            .Columns(0).HeaderText = "No"
            .Columns(0).Width = "30"
            .Columns(0).Frozen = True
            .Columns(1).HeaderText = "NIK"
            .Columns(1).Width = "80"
            .Columns(2).HeaderText = "Nama"
            .Columns(2).Width = "180"
            .Columns(3).HeaderText = "Departemen"
            .Columns(3).Width = "155"
            .Columns(4).HeaderText = "Jabatan Awal"
            .Columns(4).Width = "155"
            .Columns(5).HeaderText = "Jabatan Akhir"
            .Columns(5).Width = "155"
            .Columns(6).HeaderText = "Status Karyawan"
            .Columns(6).Width = "90"
            .Columns(7).HeaderText = "Atasan"
            .Columns(7).Width = "90"
            .Columns(8).HeaderText = "Tgl Masuk (Recruitment)"
            .Columns(8).Width = "90"
            .Columns(9).HeaderText = "Tgl Masuk (Harian)"
            .Columns(9).Width = "90"
            .Columns(10).HeaderText = "Tgl Masuk (Borongan)"
            .Columns(10).Width = "90"
            .Columns(11).HeaderText = "Masa Kerja"
            .Columns(11).Width = "120"
            .Columns(12).HeaderText = "Tgl Kontrak"
            .Columns(12).Width = "90"
            .Columns(13).HeaderText = "Tgl Tetap"
            .Columns(13).Width = "90"
            .Columns(14).HeaderText = "Tgl Keluar"
            .Columns(14).Width = "90"
            .Columns(15).HeaderText = "cuti"
            .Columns(15).Visible = False
            .RowHeadersWidth = 5
            .Refresh()
        End With
    End Sub

    Private Sub atur_griddtkaryjab(ByVal grid As DataGridView)
        With grid
            .ReadOnly = True
            .Enabled = True
            .Columns(0).HeaderText = "No"
            .Columns(0).Width = "30"
            .Columns(0).Frozen = True
            .Columns(1).HeaderText = "NIK"
            .Columns(1).Width = "75"
            .Columns(1).Frozen = True
            .Columns(2).HeaderText = "Nama"
            .Columns(2).Width = "140"
            .Columns(2).Frozen = True
            .Columns(3).HeaderText = "Departemen"
            .Columns(3).Width = "140"
            .Columns(4).HeaderText = "Jabatan"
            .Columns(4).Width = "140"
            .Columns(5).HeaderText = "Status"
            .Columns(5).Width = "80"
            .Columns(6).HeaderText = "atasan"
            .Columns(6).Width = "120"
            .Columns(7).HeaderText = "Tgl Recruit"
            .Columns(7).Width = "80"
            .Columns(8).HeaderText = "Tgl Masuk Harian"
            .Columns(8).Width = "80"
            .Columns(9).HeaderText = "Tgl Masuk Borongan"
            .Columns(9).Width = "80"
            .Columns(10).HeaderText = "Masa Kerja"
            .Columns(10).Width = "120"
            .Columns(11).HeaderText = "Tgl Kontrak"
            .Columns(11).Width = "80"
            .Columns(12).HeaderText = "Tgl Tetap"
            .Columns(12).Width = "80"
            .Columns(13).HeaderText = "Tgl Keluar"
            .Columns(13).Width = "80"
            .Columns(14).HeaderText = "cuti"
            .Columns(14).Width = "50"
            .RowHeadersWidth = 5
        End With
    End Sub

    Private Sub atur_gridKTP(ByVal grid As DataGridView)
        With grid
            .ReadOnly = True
            .Enabled = True
            .Columns(0).HeaderText = "No"
            .Columns(0).Width = "30"
            .Columns(0).Frozen = True
            .Columns(1).HeaderText = "NIK"
            .Columns(1).Width = "75"
            .Columns(1).Frozen = True
            .Columns(2).HeaderText = "Nama"
            .Columns(2).Width = "140"
            .Columns(2).Frozen = True
            .Columns(3).HeaderText = "Departemen"
            .Columns(3).Width = "110"
            .Columns(4).HeaderText = "Status"
            .Columns(4).Width = "80"
            .Columns(5).HeaderText = "No KK"
            .Columns(5).Width = "120"
            .Columns(6).HeaderText = "No KTP"
            .Columns(6).Width = "120"
            .Columns(7).HeaderText = "Tempat Lahir"
            .Columns(7).Width = "100"
            .Columns(8).HeaderText = "TGL Lahir"
            .Columns(8).Width = "75"
            .Columns(9).HeaderText = "Umur"
            .Columns(9).Width = "100"
            .Columns(10).HeaderText = "Agama"
            .Columns(10).Width = "75"
            .Columns(11).HeaderText = "Jenis Kelamin"
            .Columns(11).Width = "75"
            .Columns(12).HeaderText = "Status Kawin"
            .Columns(12).Width = "100"
            .Columns(13).HeaderText = "Pendidikan"
            .Columns(13).Width = "110"
            .Columns(14).HeaderText = "Alamat"
            .Columns(14).Width = "140"
            .Columns(15).HeaderText = "Desa"
            .Columns(15).Width = "100"
            .Columns(16).HeaderText = "RT"
            .Columns(16).Width = "60"
            .Columns(17).HeaderText = "RW"
            .Columns(17).Width = "60"
            .Columns(18).HeaderText = "Kecamatan"
            .Columns(18).Width = "75"
            .Columns(19).HeaderText = "Kabupaten"
            .Columns(19).Width = "75"
            .Columns(20).HeaderText = "Kode POS"
            .Columns(20).Width = "75"
            .Columns(21).HeaderText = "No Telp"
            .Columns(21).Width = "75"
            .Columns(22).HeaderText = "Email"
            .Columns(22).Width = "75"
            .Columns(23).HeaderText = "Kerabat"
            .Columns(23).Width = "75"
            .Columns(24).HeaderText = "No Telp Kerabat"
            .Columns(24).Width = "75"
            .RowHeadersWidth = 5
        End With
    End Sub

    Private Sub atur_gridfaskes(ByVal grid As DataGridView)
        With grid
            .ReadOnly = True
            .Enabled = True
            .Columns(0).HeaderText = "No"
            .Columns(0).Width = "30"
            .Columns(0).Frozen = True
            .Columns(1).HeaderText = "NIK"
            .Columns(1).Width = "75"
            .Columns(1).Frozen = True
            .Columns(2).HeaderText = "Nama"
            .Columns(2).Width = "140"
            .Columns(2).Frozen = True
            .Columns(3).HeaderText = "Departemen"
            .Columns(3).Width = "140"
            .Columns(4).HeaderText = "Jabatan"
            .Columns(4).Width = "140"
            .Columns(5).HeaderText = "Status"
            .Columns(5).Width = "80"
            .Columns(6).HeaderText = "Jenis Kelamin"
            .Columns(6).Width = "120"
            .Columns(7).HeaderText = "Agama"
            .Columns(7).Width = "120"
            .Columns(8).HeaderText = "No Telp"
            .Columns(8).Width = "100"
            .Columns(9).HeaderText = "Status Kawin"
            .Columns(9).Width = "100"
            .Columns(10).HeaderText = "Faskes 1"
            .Columns(10).Width = "140"
            .Columns(11).HeaderText = "Faskes Gigi"
            .Columns(11).Width = "140"
            .RowHeadersWidth = 5
        End With
    End Sub

    Private Sub atur_griddtkeluarga(ByVal grid As DataGridView)
        With grid
            .ReadOnly = True
            .Enabled = True
            .Columns(0).HeaderText = "No"
            .Columns(0).Width = "30"
            .Columns(0).Frozen = True
            .Columns(1).HeaderText = "NIK"
            .Columns(1).Width = "75"
            .Columns(1).Frozen = True
            .Columns(2).HeaderText = "Nama"
            .Columns(2).Width = "140"
            .Columns(2).Frozen = True
            .Columns(3).HeaderText = "Departemen"
            .Columns(3).Width = "110"
            .Columns(4).HeaderText = "Status"
            .Columns(4).Width = "80"
            .Columns(5).HeaderText = "Nama (Pasangan)"
            .Columns(5).Width = "140"
            .Columns(6).HeaderText = "No KTP (pasangan)"
            .Columns(6).Width = "100"
            .Columns(7).HeaderText = "Tempat Lahir (Pasangan)"
            .Columns(7).Width = "100"
            .Columns(8).HeaderText = "TGL Lahir (Pasangan)"
            .Columns(8).Width = "75"
            .Columns(9).HeaderText = "Nama (Anak Pertama)"
            .Columns(9).Width = "140"
            .Columns(10).HeaderText = "No KTP (Anak pertama)"
            .Columns(10).Width = "100"
            .Columns(11).HeaderText = "Tempat Lahir (Anak Pertama)"
            .Columns(11).Width = "100"
            .Columns(12).HeaderText = "TGL Lahir (Anak Pertama)"
            .Columns(12).Width = "75"
            .Columns(13).HeaderText = "Nama (Anak Kedua)"
            .Columns(13).Width = "140"
            .Columns(14).HeaderText = "No KTP (Anak Kedua)"
            .Columns(14).Width = "100"
            .Columns(15).HeaderText = "Tempat Lahir (Anak Kedua)"
            .Columns(15).Width = "100"
            .Columns(16).HeaderText = "TGL Lahir (Anak Kedua)"
            .Columns(16).Width = "75"
            .Columns(17).HeaderText = "Nama (Anak Ketiga)"
            .Columns(17).Width = "140"
            .Columns(18).HeaderText = "No KTP (Anak Ketiga)"
            .Columns(18).Width = "100"
            .Columns(19).HeaderText = "Tempat Lahir (Anak Ketiga)"
            .Columns(19).Width = "100"
            .Columns(20).HeaderText = "TGL Lahir (Anak Ketiga)"
            .Columns(20).Width = "75"
            .RowHeadersWidth = 5
        End With
    End Sub

    Private Sub atur_gridharian(ByVal grid As DataGridView)
        With grid
            .ReadOnly = True
            .Enabled = True
            .Columns(0).HeaderText = "No"
            .Columns(0).Width = "30"
            .Columns(0).Frozen = True
            .Columns(1).HeaderText = "NIK"
            .Columns(1).Width = "75"
            .Columns(1).Frozen = True
            .Columns(2).HeaderText = "Nama"
            .Columns(2).Width = "200"
            .Columns(2).Frozen = True
            .Columns(3).HeaderText = "Departemen"
            .Columns(3).Width = "110"
            .Columns(4).HeaderText = "Jabatan"
            .Columns(4).Width = "200"
            .Columns(5).HeaderText = "Atasan"
            .Columns(5).Width = "120"
            .Columns(6).HeaderText = "Status Karyawan"
            .Columns(6).Width = "100"
            .Columns(7).HeaderText = "Tanggal Masuk"
            .Columns(7).Width = "75"
            .Columns(8).HeaderText = "Tanggal Keluar"
            .Columns(8).Width = "75"
            .Columns(9).HeaderText = "No_urut"
            .Columns(9).Visible = False
            .RowHeadersWidth = 5
        End With
    End Sub

    Private Sub load_karyawan(ByVal combo As ComboBox)
        With combo.Items
            .Add("KARYAWAN")
            '.Add("HARIAN TETAP")
            .Add("HARIAN")
            '.Add("TANPA STATUS")
            .Add("PERCOBAAN")
            .Add("KELUAR")
            '.Add("KELUAR - HARIAN SEMENTARA")
        End With
    End Sub

    Private Sub B_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Combo_kary_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_kary.SelectedIndexChanged
        Radio_fulljab.Checked = False
        Radio_singlejab.Checked = False
        grid_karyawan.DataSource = Nothing
        LoadDataDomisili(grid_DataDom, Combo_kary.Text, Nothing)
        LoadDataKTP(grid_dtKTP, Combo_kary.Text, Nothing)
        LoadDataKeluarga(grid_keluarga, Combo_kary.Text, Nothing)
        LoadDataFaskes(grid_faskes, Combo_kary.Text, Nothing)
    End Sub

    Private Sub load_filter(ByVal combo As ComboBox)
        With combo.Items
            .Add("Departemen")
            .Add("Jabatan")
            .Add("Masa Kerja")
            .Add("Status")
        End With
    End Sub

    Private Sub combo_opsi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboKategori.SelectedIndexChanged
        ComboFilter.Text = String.Empty
        Select Case ComboKategori.Text
            Case "Departemen"
                ComboFilter.Items.Clear()
                Label_filter.Text = "Departemen"
                load_combo(ComboFilter, "departemen", "tbl_jabatan")
            Case "Jabatan"
                ComboFilter.Items.Clear()
                Label_filter.Text = "Jabatan"
                load_combo(ComboFilter, "jabatan", " tbl_jabatan")
            Case "Masa Kerja"
                ComboFilter.Items.Clear()
                Label_filter.Text = "Masa Kerja"
                With ComboFilter.Items
                    .Add("2 tahun")
                    .Add("Kurang Dari 2 tahun")
                End With
            Case "Status"
                ComboFilter.Items.Clear()
                Label_filter.Text = "Status"
                load_combo(ComboFilter, "status_karyawan", "tbl_jabatan WHERE status_karyawan <> 'Harian Sementara'")
        End Select
    End Sub

    Private Sub load_filterKTP(ByVal combo As ComboBox)
        With combo.Items
            .Add("Departemen")
            .Add("Agama")
            .Add("Jenis Kelamin")
            .Add("Status Kawin")
            .Add("Pendidikan")
            .Add("Kabupaten")
            .Add("Kecamatan")
            .Add("Desa")
            '.Add("Usia")
        End With
    End Sub

    Private Sub Combo_opsiKTP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_opsiKTP.SelectedIndexChanged
        combo_filterKTP.Items.Clear()
        combo_filterKTP.Text = String.Empty
        Label_filterKTP.Text = Combo_opsiKTP.Text
        Select Case Combo_opsiKTP.Text
            Case "Departemen"
                load_combo(combo_filterKTP, "departemen", "tbl_jabatan")
            Case "Agama"
                load_combo(combo_filterKTP, "agama", "tbl_pegawai")
            Case "Jenis Kelamin"
                load_combo(combo_filterKTP, "sex", "tbl_pegawai")
            Case "Status Kawin"
                load_combo(combo_filterKTP, "status_kawin", "tbl_pegawai")
            Case "Pendidikan"
                load_combo(combo_filterKTP, "pendidikan", "tbl_pegawai")
            Case "Kabupaten"
                load_combo(combo_filterKTP, "kab_asal", "tbl_pegawai")
            Case "Kecamatan"
                load_combo(combo_filterKTP, "kec_asal", "tbl_pegawai")
            Case "Desa"
                load_combo(combo_filterKTP, "desa_asal", "tbl_pegawai")
            Case "Usia"
                combo_filterKTP.Items.Add("Usia Tahun ini 21 Tahun")
        End Select
    End Sub

    Private Sub load_filterDom(ByVal combo As ComboBox)
        With combo.Items
            .Add("Departemen")
            .Add("Agama")
            .Add("Jenis Kelamin")
            .Add("Status Kawin")
            .Add("Pendidikan")
            .Add("Kabupaten")
            .Add("Kecamatan")
            .Add("Desa")
        End With
    End Sub

    Private Sub Combo_opsiDom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_opsiDom.SelectedIndexChanged
        Combo_filterDom.Items.Clear()
        Combo_filterDom.Text = String.Empty
        Label_filterdom.Text = Combo_opsiDom.Text
        Select Case Combo_opsiDom.Text
            Case "Departemen"
                load_combo(Combo_filterDom, "departemen", "tbl_jabatan")
            Case "Agama"
                load_combo(Combo_filterDom, "agama", "tbl_pegawai")
            Case "Jenis Kelamin"
                load_combo(Combo_filterDom, "sex", "tbl_pegawai")
            Case "Status Kawin"
                load_combo(Combo_filterDom, "status_kawin", "tbl_pegawai")
            Case "Pendidikan"
                load_combo(Combo_filterDom, "pendidikan", "tbl_pegawai")
            Case "Kabupaten"
                load_combo(Combo_filterDom, "kab_asal", "tbl_pegawai")
            Case "Kecamatan"
                load_combo(Combo_filterDom, "kec_asal", "tbl_pegawai")
            Case "Desa"
                load_combo(Combo_filterDom, "desa_asal", "tbl_pegawai")
        End Select
    End Sub

    Private Sub load_filterKeluarga(ByVal combo As ComboBox)
        With combo.Items
            .Add("Departemen")
            .Add("Status karyawan")
        End With
    End Sub

    Private Sub Combo_opsiK_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_opsiK.SelectedIndexChanged
        Combo_filterKel.Items.Clear()
        Combo_filterKel.Text = String.Empty
        Label_IK.Text = Combo_opsiK.Text
        Select Case Combo_opsiK.Text
            Case "Departemen"
                load_combo(Combo_filterKel, "departemen", "tbl_jabatan")
            Case "Status karyawan"
                load_combo(Combo_filterKel, "Status_karyawan", "view_dtpegawai")
        End Select
    End Sub



    Private Sub B_go_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_go.Click
        If Combo_kary.Text = String.Empty Then
            MsgBox("Silahkan pilih karyawan terlebih dahulu ", MsgBoxStyle.Information, "INFO")
        Else
            If Combo_kary.Text = "KELUAR - HARIAN SEMENTARA" Or Combo_kary.Text = "HARIAN SEMENTARA" Then
                load_gridfullharians(grid_karyawan, String.Empty)
            Else
                load_gridkaryPeriod(grid_karyawan, Combo_kary.Text, Nothing)
            End If
        End If

    End Sub

    Private Sub DTawal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTawal.ValueChanged
        format_tanggal(DTawal)
    End Sub

    Private Sub DT_akhir_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_akhir.ValueChanged
        format_tanggal(DT_akhir)
    End Sub

    Private Sub combo_filterKTP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_filterKTP.SelectedIndexChanged
        LoadDataKTP(grid_dtKTP, Combo_kary.Text, "Departemen")
    End Sub

    Private Sub Combo_filterDom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_filterDom.SelectedIndexChanged
        LoadDataDomisili(grid_DataDom, Combo_kary.Text, "Departemen")
    End Sub

    Private Sub Radio_fulljab_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_fulljab.CheckedChanged
        If Radio_fulljab.Checked = True Then
            DTawal.Enabled = True
            DT_akhir.Enabled = True
            B_go.Enabled = True
        ElseIf Radio_singlejab.Checked = True Then
            DTawal.Enabled = False
            DT_akhir.Enabled = False
            B_go.Enabled = False
        End If
    End Sub

    Private Sub Radio_singlejab_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_singlejab.CheckedChanged
        If Radio_fulljab.Checked = True Then
            DTawal.Enabled = True
            DT_akhir.Enabled = True
            B_go.Enabled = True
        ElseIf Radio_singlejab.Checked = True Then
            DTawal.Enabled = False
            DT_akhir.Enabled = False
            B_go.Enabled = False
            If Combo_kary.Text = "HARIAN SEMENTARA" Or Combo_kary.Text = "KELUAR - HARIAN SEMENTARA" Then
                load_gridfullharians(grid_karyawan, String.Empty)
                ToolStripRiwayatKerja.Visible = True
                ToolStripRiwayatKerja.Enabled = True
            Else
                LoadDataFullKaryawan(grid_karyawan, Combo_kary.Text, Nothing)
                ToolStripRiwayatKerja.Visible = False
                ToolStripRiwayatKerja.Enabled = False
            End If
        End If
    End Sub

    Private Sub Combo_filterKel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_filterKel.SelectedIndexChanged
        LoadDataKeluarga(grid_keluarga, Combo_kary.Text, "Departemen")
    End Sub

    Private Sub load_filterFK(ByVal combo As ComboBox)
        With combo.Items
            .Add("Departemen")
            .Add("Status Karyawan")
            .Add("Jenis Kelamin")
            .Add("Status Kawin")
        End With
    End Sub

    Private Sub Combo_opsiFK_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_opsiFK.SelectedIndexChanged
        Combo_filerFK.Text = String.Empty
        Combo_filerFK.Items.Clear()
        Label_faskes.Text = Combo_opsiFK.Text
        Select Case Combo_opsiFK.Text
            Case "Departemen"
                load_combo(Combo_filerFK, "departemen", "tbl_jabatan")
            Case "Status Karyawan"
                load_combo(Combo_filerFK, "status_karyawan", "tbl_jabatan")
            Case "Jenis Kelamin"
                load_combo(Combo_filerFK, "sex", "tbl_pegawai")
            Case "Status Kawin"
                load_combo(Combo_filerFK, "status_kawin", "tbl_pegawai")
        End Select
    End Sub

    Private Sub Combo_filerFK_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_filerFK.SelectedIndexChanged
        LoadDataFaskes(grid_faskes, Combo_kary.Text, "Departemen")
    End Sub

    Private Sub grid_dtKTP_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grid_dtKTP.CellMouseUp
        With grid_dtKTP
            If e.Button = MouseButtons.Right Then
                If .Rows.Count > 1 Then
                    status_editdata = "dtpersonal"
                    .ContextMenuStrip = ContextMenuStrip1
                    rowindex = .CurrentRow.Index
                    nik_global = .Rows(rowindex).Cells(1).Value
                    Me.ContextMenuStrip1.Show(Me.grid_dtKTP, e.Location)
                    Me.ContextMenuStrip1.Show(Cursor.Position)
                Else
                    .ContextMenuStrip = Nothing
                End If
            End If
        End With
    End Sub



    Private Sub EditDataPersonalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditDataPersonalToolStripMenuItem.Click
        If status_editdata = "dtpersonal" Then
            Dim form_DTPersonal As New FormDTPersonal
            form_DTPersonal.load_DTPersonal(nik_global)
            form_DTPersonal.Show()
            form_DTPersonal.MdiParent = FormMenuUtama
            form_DTPersonal.WindowState = FormWindowState.Maximized
            Me.Close()
        ElseIf status_editdata = "dtpekerjaan" Then
            Dim form_DTJabatan As New FormEditDtPeg
            form_DTJabatan.load_editdatapeg(nik_global)
            form_DTJabatan.Show()
            form_DTJabatan.MdiParent = FormMenuUtama
            form_DTJabatan.WindowState = FormWindowState.Maximized
            Me.Close()
        End If
    End Sub


    Private Sub HapusDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HapusDataToolStripMenuItem.Click
        'MsgBox(nik_global)
        With grid_karyawan
            If MsgBox("Anda akan menghapus keseluruhan data, dengan " & vbCrLf & vbCrLf & _
                      "NIK          : " & nik_global & vbCrLf & _
                      "Nama         : " & .Rows(.CurrentRow.Index).Cells(2).Value & vbCrLf & _
                      "Departemen   : " & .Rows(.CurrentRow.Index).Cells(3).Value & vbCrLf & vbCrLf & _
                      "Lanjutkan penghapusan data ? ", MsgBoxStyle.Information & vbOKCancel, "INFO") = vbOK Then
                'hapus data
                Cursor.Current = Cursors.WaitCursor
                If hapus_data(nik_global, "tbl_anak") = True And
                    hapus_data(nik_global, "tbl_catatan") = True And
                    hapus_data(nik_global, "tbl_cuti") = True And
                    hapus_data(nik_global, "tbl_dataabsen") = True And
                    hapus_data(nik_global, "tbl_dinas") = True And
                    hapus_data(nik_global, "tbl_ijin") = True And
                    hapus_data(nik_global, "tbl_istri") = True And
                    hapus_data(nik_global, "tbl_pegawai") = True And
                    hapus_data(nik_global, "tbl_photopegawai") = True And
                    hapus_data(nik_global, "tbl_potongan") = True And
                    hapus_data(nik_global, "tbl_rawabsen") = True And
                    hapus_data(nik_global, "tbl_rekapkerja") = True And
                    hapus_data(nik_global, "tbl_riwayatkes") = True And
                    hapus_data(nik_global, "tbl_tanggalkerja") = True And
                    hapus_data(nik_global, "tbl_telat") = True And
                    hapus_data(nik_global, "tbl_tglharians") = True Then
                    MsgBox("Data telah berhasil di hapus ", MsgBoxStyle.Information, "INFO")
                    Cursor.Current = Cursors.Default
                Else
                    MsgBox("Gagal melakukan penghapusan data ", MsgBoxStyle.Information, "INFO")
                End If
            End If
        End With
    End Sub

    Private Function hapus_data(ByVal nik As String, ByVal tabel$) As Boolean
        Try
            clear_command()
            openDB()
            sql = "DELETE FROM " & tabel & " WHERE nik = @nik"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = nik
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("gagal dalam penghapusan data " & tabel & " " & ex.Message)
            Return False
        Finally
            Conn.Close()
        End Try
    End Function

    Private Sub grid_karyawan_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grid_karyawan.CellMouseUp
        EditDataPersonalToolStripMenuItem.Text = "Edit Data Pekerjaan "
        With (grid_karyawan)
            If e.Button = MouseButtons.Right Then
                If .Rows.Count > 1 Then
                    status_editdata = "dtpekerjaan"
                    .ContextMenuStrip = ContextMenuStrip1
                    rowindex = .CurrentRow.Index
                    nik_global = .Rows(rowindex).Cells(1).Value
                    Me.ContextMenuStrip1.Show(Me.grid_dtKTP, e.Location)
                    Me.ContextMenuStrip1.Show(Cursor.Position)
                Else
                    .ContextMenuStrip = Nothing
                End If
            End If
        End With
    End Sub


    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab Is TabDataPersonal Then
            EditDataPersonalToolStripMenuItem.Text = "Edit Data Personal"
            status_editdata = "dtpersonal"
            JenisExport = "Data Personal"
        ElseIf TabControl1.SelectedTab Is TabDTKaryawan Then
            EditDataPersonalToolStripMenuItem.Text = "Edit Data Jabatan"
            status_editdata = "dtpekerjaan"
            JenisExport = "Data Jabatan"
        ElseIf TabControl1.SelectedTab Is TabDataDomisili Then
            EditDataPersonalToolStripMenuItem.Text = "Edit Data Jabatan"
            status_editdata = "dtpekerjaan"
            JenisExport = "Data Domisili"
        ElseIf TabControl1.SelectedTab Is TabIndentitasKel Then
            EditDataPersonalToolStripMenuItem.Text = "Edit Data Jabatan"
            status_editdata = "dtpekerjaan"
            JenisExport = "Data Keluarga"
        ElseIf TabControl1.SelectedTab Is TabFaskes Then
            EditDataPersonalToolStripMenuItem.Text = "Edit Data Jabatan"
            status_editdata = "dtpekerjaan"
            JenisExport = "Data FasKes"
        End If
    End Sub

    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub grid_karyawan_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_karyawan.CellContentClick

    End Sub

    Private Sub Text_cari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_cari.TextChanged
        If Radio_fulljab.Checked = True Then
            If Combo_kary.Text = "KELUAR - HARIAN SEMENTARA" Or Combo_kary.Text = "HARIAN SEMENTARA" Then
                load_gridfullharians(grid_karyawan, "pencarian")
            Else
                load_gridkaryPeriod(grid_karyawan, Combo_kary.Text, "Pencarian")
            End If

        End If
        If Radio_singlejab.Checked = True Then
            If Combo_kary.Text = "KELUAR - HARIAN SEMENTARA" Or Combo_kary.Text = "HARIAN SEMENTARA" Then
                load_gridfullharians(grid_karyawan, "pencarian")
            Else
                LoadDataFullKaryawan(grid_karyawan, Combo_kary.Text, "Pencarian")
            End If
        End If
    End Sub

    Private Sub Text_cariktp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_cariktp.TextChanged
        LoadDataKTP(grid_dtKTP, Combo_kary.Text, "Pencarian")
    End Sub

    Private Sub Text_caridom_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_caridom.TextChanged
        LoadDataDomisili(grid_DataDom, Combo_kary.Text, "Pencarian")
    End Sub

    Private Sub Text_carifas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_carifas.TextChanged
        LoadDataFaskes(grid_faskes, Combo_kary.Text, "Pencarian")
    End Sub

    Private Sub Text_carikel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_carikel.TextChanged
        LoadDataKeluarga(grid_keluarga, Combo_kary.Text, "Pencarian")
    End Sub

    Private Sub TabDataPersonal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabDataPersonal.Click

    End Sub

    Private Sub ToolStripRiwayatKerja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripRiwayatKerja.Click
        Dim formRiwayatHS As New FormRiwayatHS
        nik_global = grid_karyawan.Rows(grid_karyawan.CurrentRow.Index).Cells(1).Value
        formRiwayatHS.load_dataharians(formRiwayatHS.grid_tampildata, nik_global, Nothing)
        formRiwayatHS.Show()
        formRiwayatHS.MdiParent = FormMenuUtama
        formRiwayatHS.WindowState = FormWindowState.Maximized
        Me.Close()
    End Sub

    Private Sub ExportExcelFile(ByVal grid As DataGridView)

        xlapp = New Excel.Application
        xlWorkBook = xlapp.Workbooks.Add(misValue)
        xlWorkSheet = CType(xlWorkBook.Sheets("Sheet1"), Excel.Worksheet)
        Try
            Cursor.Current = Cursors.AppStarting
            For k% = 0 To grid.ColumnCount - 1
                xlWorkSheet.Cells(1, k + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                xlWorkSheet.Cells(1, k + 1) = grid.Columns(k).Name
            Next
            For a% = 0 To grid.RowCount - 2
                For b% = 0 To grid.ColumnCount - 1
                    xlWorkSheet.Cells(a + 2, b + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    xlWorkSheet.Cells(a + 2, b + 1) =
                        grid(b, a).Value.ToString()
                Next
                worker1.ReportProgress(CInt(a * 100 / (grid.RowCount - 2)))
            Next

            Dim SaveFileDialog1 As New SaveFileDialog()
            SaveFileDialog1.Filter = "Execl files (*.xlsx)|*.xlsx"
            SaveFileDialog1.FilterIndex = 2
            SaveFileDialog1.RestoreDirectory = True
            If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                xlWorkSheet.SaveAs(SaveFileDialog1.FileName)
                MsgBox("file telah berhasil tersimpan")
                Label_progress.Visible = False
                ProgressBar1.Visible = False
                ProgressBar1.Value = Nothing
                Label_progress.Text = Nothing
            Else
                Return
            End If
            xlWorkBook.Close()
            xlapp.Quit()
            Cursor.Current = Cursors.Arrow
        Catch ex As Exception
            MsgBox("Gagal export data, " & vbCrLf & ex.Message, MsgBoxStyle.Information, "INFO")
            Cursor.Current = Cursors.Arrow
        End Try

    End Sub


    Private Sub worker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles worker1.DoWork
        ExportExcelFile(grid_karyawan)
    End Sub

    Private Sub worker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles worker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        Label_progress.Text = ProgressBar1.Value.ToString() & " %"
    End Sub

    Private Sub worker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles worker1.RunWorkerCompleted
        ProgressBar1.Visible = False
        Label_progress.Visible = False
        releaseObject(xlWorkSheet)
        releaseObject(xlWorkBook)
        releaseObject(xlapp)
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub ButtonExport_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExport.Click
        ProgressBar1.Visible = True
        Label_progress.Visible = True
        Select Case JenisExport
            Case "Data Jabatan"
                ExportExcelFile(grid_karyawan)
            Case "Data Personal"
                ExportExcelFile(grid_dtKTP)
            Case "Data Domisili"
                ExportExcelFile(grid_DataDom)
            Case "Data Keluarga"
                ExportExcelFile(grid_keluarga)
            Case "Data FasKes"
                ExportExcelFile(grid_faskes)
            Case Else
                ExportExcelFile(grid_karyawan)
        End Select

        'worker1.RunWorkerAsync()
    End Sub


    Private Sub ComboFilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboFilter.SelectedIndexChanged
        If Radio_fulljab.Checked = True Then
            If DTawal.Text = String.Empty And DT_akhir.Text = String.Empty Then
                MsgBox("periode tidak boleh kosong ", MsgBoxStyle.Information, "INFO")
            Else
                load_gridkaryPeriod(grid_karyawan, Combo_kary.Text, "Departemen")
            End If
        ElseIf Radio_singlejab.Checked = True Then
            LoadDataFullKaryawan(grid_karyawan, Combo_kary.Text, "Departemen")
        End If
    End Sub
End Class