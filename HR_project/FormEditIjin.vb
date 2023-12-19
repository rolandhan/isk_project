Imports System.Data.Sql
Imports System.Data.SqlClient
Imports VB = Microsoft.VisualBasic.Strings
Imports System.Globalization

Public Class FormEditIjin
    Dim rowindex, jumlah As Integer
    Dim tanggal As Date
    Private Sub FormEditIjin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New CultureInfo("id-ID")
        clear_date(Me, Nothing)
        load_cmb(Combo_jenis)
        load_combo(combo_dept, "departemen", "tbl_jabatan")
    End Sub

    Private Sub load_cmb(ByVal combo As ComboBox)
        With combo.Items
            .Add("Ijin Tidak Masuk Kerja")
            .Add("Ijin Meninggalkan Pekerjaan")
            .Add("Terlambat Kerja")
            .Add("Ijin Dinas Luar")
        End With
    End Sub

    Private Function hapus_data(ByVal id As String, ByVal tabel As String, ByVal id_value As String, ByVal kondisi As String) As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "DELETE FROM " & tabel & " WHERE " & id & " = @id" & kondisi
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id_value
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam penghapusan data di tabel " & tabel & " " & ex.Message)
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function HapusRekapKerja(ByVal tabel As String, ByVal nik As String, _
                                     ByVal tanggal As Date, ByVal status As String) As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "DELETE FROM " & tabel & " WHERE nik = @nik AND tanggal = @tanggal " & _
                "AND status = @status"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = nik
                .Add("@tanggal", SqlDbType.Date).Value = tanggal
                .Add("@status", SqlDbType.VarChar).Value = status
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam melakukan penghapusan data " & tabel & " " & ex.Message)
            Return False
        Finally
            Cursor.Current = Cursors.Default
            Conn.Close()
        End Try
    End Function

    Private Function HapusRekapAll(ByVal tabel As String, ByVal nik As String, _
                                     ByVal tgl As Date, ByVal status As String) As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            Dim A As Integer = 1
            jumlah = grid_tampildata.Rows(rowindex).Cells(10).Value
            tanggal = tgl
            Do While A < jumlah + 1
                If tanggal.AddDays(0).ToString("dddd") = "Sunday" Then
                    jumlah += 1
                    tanggal = DateAdd(DateInterval.Day, 1, tanggal)
                Else
                    sql = "DELETE FROM " & tabel & " WHERE nik = @nik AND tanggal = @tanggal " & _
                    "AND status = @status"
                    sqlcmd = New SqlCommand(sql, Conn)
                    With sqlcmd.Parameters
                        .Add("@nik", SqlDbType.VarChar).Value = nik
                        .Add("@tanggal", SqlDbType.Date).Value = tanggal
                        .Add("@status", SqlDbType.VarChar).Value = status
                    End With
                    sqlcmd.ExecuteNonQuery()
                    tanggal = DateAdd(DateInterval.Day, 1, tanggal)
                End If
                A += 1
            Loop
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam melakukan penghapusan data " & tabel & " " & ex.Message)
            Return False
        Finally
            Cursor.Current = Cursors.Default
            Conn.Close()
        End Try
    End Function

    Private Sub load_grid(ByVal grid As DataGridView, ByVal opt As String, ByVal filter As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            Select Case opt
                Case "Ijin Tidak Masuk Kerja"
                    Select Case filter
                        Case String.Empty
                            sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No,* FROM " & _
                                "(SELECT tbl_cuti.NIK,view_tglpegawai.nama, view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                                "tbl_cuti.ID_CUTI, tbl_cuti.TANGGAL,tbl_cuti.HARI, tbl_cuti.MULAI_CUTI, " & _
                                "(CASE WHEN datename(DW, MULAI_CUTI ) = 'Sunday' THEN 'Mingggu' " & _
                                "WHEN datename(DW, MULAI_CUTI ) = 'Monday' THEN 'Senin' " & _
                                "WHEN datename(DW, MULAI_CUTI ) = 'Tuesday' THEN 'Selasa' " & _
                                "WHEN datename(DW, MULAI_CUTI ) = 'Wednesday' THEN 'Rabu'  " & _
                                "WHEN datename(DW, MULAI_CUTI ) = 'Thursday' THEN 'Kamis'  " & _
                                "WHEN datename(DW, MULAI_CUTI ) = 'Friday' THEN 'Jumat'  " & _
                                "WHEN datename(DW, MULAI_CUTI ) = 'Saturday' THEN 'Sabtu' END ) as hari_mulai,  " & _
                                "tbl_cuti.LAMA_CUTI, tbl_cuti.TANGGAL_MASUK,  " & _
                                "(CASE WHEN datename(DW, TANGGAL_MASUK ) = 'Sunday' THEN 'Mingggu' " & _
                                "WHEN datename(DW, TANGGAL_MASUK) = 'Monday' THEN 'Senin'  " & _
                                "WHEN datename(DW, TANGGAL_MASUK ) = 'Tuesday' THEN 'Selasa' " & _
                                "WHEN datename(DW, TANGGAL_MASUK ) = 'Wednesday' THEN 'Rabu' " & _
                                "WHEN datename(DW, TANGGAL_MASUK ) = 'Thursday' THEN 'Kamis' " & _
                                "WHEN datename(DW, TANGGAL_MASUK ) = 'Friday' THEN 'Jumat' " & _
                                "WHEN datename(DW, TANGGAL_MASUK) = 'Saturday' THEN 'Sabtu' END ) as nm_hari, " & _
                                "tbl_cuti.STATUS,tbl_cuti.periode, tbl_cuti.ket, view_tglpegawai .tgl_keluar  FROM tbl_cuti " & _
                                "LEFT OUTER JOIN view_tglpegawai ON tbl_cuti.NIK = view_tglpegawai.nik  " & _
                                "WHERE  (view_tglpegawai.tgl_keluar > @awal OR view_tglpegawai.tgl_keluar IS NUll) " & _
                                "AND (tbl_cuti.MULAI_CUTI BETWEEN @awal AND @akhir)) as temp"
                        Case "departemen"
                            sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No,* FROM " & _
                                "(SELECT tbl_cuti.NIK,view_tglpegawai.nama, view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                                "tbl_cuti.ID_CUTI, tbl_cuti.TANGGAL,tbl_cuti.HARI, tbl_cuti.MULAI_CUTI, " & _
                                "(CASE WHEN datename(DW, MULAI_CUTI ) = 'Sunday' THEN 'Mingggu' " & _
                                "WHEN datename(DW, MULAI_CUTI ) = 'Monday' THEN 'Senin' " & _
                                "WHEN datename(DW, MULAI_CUTI ) = 'Tuesday' THEN 'Selasa' " & _
                                "WHEN datename(DW, MULAI_CUTI ) = 'Wednesday' THEN 'Rabu'  " & _
                                "WHEN datename(DW, MULAI_CUTI ) = 'Thursday' THEN 'Kamis'  " & _
                                "WHEN datename(DW, MULAI_CUTI ) = 'Friday' THEN 'Jumat'  " & _
                                "WHEN datename(DW, MULAI_CUTI ) = 'Saturday' THEN 'Sabtu' END ) as hari_mulai,  " & _
                                "tbl_cuti.LAMA_CUTI, tbl_cuti.TANGGAL_MASUK,  " & _
                                "(CASE WHEN datename(DW, TANGGAL_MASUK ) = 'Sunday' THEN 'Mingggu' " & _
                                "WHEN datename(DW, TANGGAL_MASUK) = 'Monday' THEN 'Senin'  " & _
                                "WHEN datename(DW, TANGGAL_MASUK ) = 'Tuesday' THEN 'Selasa' " & _
                                "WHEN datename(DW, TANGGAL_MASUK ) = 'Wednesday' THEN 'Rabu' " & _
                                "WHEN datename(DW, TANGGAL_MASUK ) = 'Thursday' THEN 'Kamis' " & _
                                "WHEN datename(DW, TANGGAL_MASUK ) = 'Friday' THEN 'Jumat' " & _
                                "WHEN datename(DW, TANGGAL_MASUK) = 'Saturday' THEN 'Sabtu' END ) as nm_hari, " & _
                                "tbl_cuti.STATUS,tbl_cuti.periode, tbl_cuti.ket, view_tglpegawai .tgl_keluar  FROM tbl_cuti " & _
                                "LEFT OUTER JOIN view_tglpegawai ON tbl_cuti.NIK = view_tglpegawai.nik  " & _
                                "WHERE  (view_tglpegawai.tgl_keluar > @awal OR view_tglpegawai.tgl_keluar IS NUll) " & _
                                "AND (tbl_cuti.MULAI_CUTI BETWEEN @awal AND @akhir)) as temp " & _
                                "WHERE temp.departemen = '" & combo_dept.Text & "' ORDER BY temp.nik, temp.tanggal"
                        Case "pencarian"
                            sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No,* FROM " & _
                                "(SELECT tbl_cuti.NIK,view_tglpegawai.nama, view_tglpegawai.departemen, view_tglpegawai.jabatan, " & _
                                "tbl_cuti.ID_CUTI, tbl_cuti.TANGGAL,tbl_cuti.HARI, tbl_cuti.MULAI_CUTI, " & _
                                "(CASE WHEN datename(DW, MULAI_CUTI ) = 'Sunday' THEN 'Mingggu' " & _
                                "WHEN datename(DW, MULAI_CUTI ) = 'Monday' THEN 'Senin' " & _
                                "WHEN datename(DW, MULAI_CUTI ) = 'Tuesday' THEN 'Selasa' " & _
                                "WHEN datename(DW, MULAI_CUTI ) = 'Wednesday' THEN 'Rabu'  " & _
                                "WHEN datename(DW, MULAI_CUTI ) = 'Thursday' THEN 'Kamis'  " & _
                                "WHEN datename(DW, MULAI_CUTI ) = 'Friday' THEN 'Jumat'  " & _
                                "WHEN datename(DW, MULAI_CUTI ) = 'Saturday' THEN 'Sabtu' END ) as hari_mulai,  " & _
                                "tbl_cuti.LAMA_CUTI, tbl_cuti.TANGGAL_MASUK,  " & _
                                "(CASE WHEN datename(DW, TANGGAL_MASUK ) = 'Sunday' THEN 'Mingggu' " & _
                                "WHEN datename(DW, TANGGAL_MASUK) = 'Monday' THEN 'Senin'  " & _
                                "WHEN datename(DW, TANGGAL_MASUK ) = 'Tuesday' THEN 'Selasa' " & _
                                "WHEN datename(DW, TANGGAL_MASUK ) = 'Wednesday' THEN 'Rabu' " & _
                                "WHEN datename(DW, TANGGAL_MASUK ) = 'Thursday' THEN 'Kamis' " & _
                                "WHEN datename(DW, TANGGAL_MASUK ) = 'Friday' THEN 'Jumat' " & _
                                "WHEN datename(DW, TANGGAL_MASUK) = 'Saturday' THEN 'Sabtu' END ) as nm_hari, " & _
                                "tbl_cuti.STATUS,tbl_cuti.periode, tbl_cuti.ket, view_tglpegawai .tgl_keluar  FROM tbl_cuti " & _
                                "LEFT OUTER JOIN view_tglpegawai ON tbl_cuti.NIK = view_tglpegawai.nik  " & _
                                "WHERE  (view_tglpegawai.tgl_keluar > @awal OR view_tglpegawai.tgl_keluar IS NUll) " & _
                                "AND (tbl_cuti.MULAI_CUTI BETWEEN @awal AND @akhir)) as temp " & _
                                "WHERE temp.nama LIKE '%" & Text_pencarian.Text & "%' OR temp.nik LIKE '%" & Text_pencarian.Text & "%' "
                    End Select
                Case "Ijin Meninggalkan Pekerjaan"
                    Select Case filter
                        Case String.Empty
                            sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, * FROM  " & _
                                "(SELECT tbl_ijin.nik, view_tglpegawai .nama , view_tglpegawai .departemen, " & _
                                "tbl_ijin.id_ijin, tbl_ijin.tanggal, tbl_ijin.hari, tbl_ijin.jam," & _
                                "tbl_ijin.jam_kembali, " & _
                                "tbl_ijin.status, tbl_ijin.alasan, view_tglpegawai.tgl_keluar FROM tbl_ijin " & _
                                "LEFT OUTER JOIN view_tglpegawai ON tbl_ijin.nik = view_tglpegawai.nik " & _
                                "WHERE (view_tglpegawai .tgl_keluar > @awal OR view_tglpegawai .tgl_keluar IS NULL) " & _
                                "AND (tbl_ijin.tanggal BETWEEN @awal AND @akhir)) AS temp "
                        Case "departemen"
                            sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, * FROM  " & _
                                "(SELECT tbl_ijin.nik, view_tglpegawai .nama , view_tglpegawai .departemen, " & _
                                "tbl_ijin.id_ijin, tbl_ijin.tanggal, tbl_ijin.hari, tbl_ijin.jam," & _
                                "tbl_ijin.jam_kembali, " & _
                                "tbl_ijin.status, tbl_ijin.alasan, view_tglpegawai.tgl_keluar FROM tbl_ijin " & _
                                "LEFT OUTER JOIN view_tglpegawai ON tbl_ijin.nik = view_tglpegawai.nik " & _
                                "WHERE (view_tglpegawai .tgl_keluar > @awal OR view_tglpegawai .tgl_keluar IS NULL) " & _
                                "AND (tbl_ijin.tanggal BETWEEN @awal AND @akhir)) AS temp " & _
                                "WHERE temp.departemen = '" & combo_dept.Text & "' ORDER BY temp.nik, temp.tanggal"
                        Case "pencarian"
                            sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, * FROM  " & _
                                "(SELECT tbl_ijin.nik, view_tglpegawai .nama , view_tglpegawai .departemen, " & _
                                "tbl_ijin.id_ijin, tbl_ijin.tanggal, tbl_ijin.hari, tbl_ijin.jam," & _
                                "tbl_ijin.jam_kembali, " & _
                                "tbl_ijin.status, tbl_ijin.alasan, view_tglpegawai.tgl_keluar FROM tbl_ijin " & _
                                "LEFT OUTER JOIN view_tglpegawai ON tbl_ijin.nik = view_tglpegawai.nik " & _
                                "WHERE (view_tglpegawai .tgl_keluar > @awal OR view_tglpegawai .tgl_keluar IS NULL) " & _
                                "AND (tbl_ijin.tanggal BETWEEN @awal AND @akhir)) AS temp " & _
                                "WHERE temp.nama LIKE '%" & Text_pencarian.Text & "%' OR temp.nik LIKE '%" & Text_pencarian.Text & "%' "
                    End Select
                Case "Terlambat Kerja"
                    Select Case filter
                        Case String.Empty
                            sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, * FROM " & _
                                "(SELECT tbl_telat.nik, view_tglpegawai.nama, view_tglpegawai.departemen, tbl_telat.id_telat, " & _
                                "tbl_telat.tanggal, tbl_telat.hari, tbl_telat.telat, tbl_telat.alasan, view_tglpegawai.tgl_keluar " & _
                                "FROM tbl_telat LEFT OUTER JOIN view_tglpegawai ON tbl_telat.nik = view_tglpegawai.nik " & _
                                "WHERE (view_tglpegawai .tgl_keluar > @awal OR view_tglpegawai .tgl_keluar IS NULL ) " & _
                                "AND tbl_telat.tanggal BETWEEN @awal AND @akhir) AS temp"
                        Case "departemen"
                            sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, * FROM " & _
                                "(SELECT tbl_telat.nik, view_tglpegawai.nama, view_tglpegawai.departemen, tbl_telat.id_telat, " & _
                                "tbl_telat.tanggal, tbl_telat.hari, tbl_telat.telat, tbl_telat.alasan, view_tglpegawai.tgl_keluar " & _
                                "FROM tbl_telat LEFT OUTER JOIN view_tglpegawai ON tbl_telat.nik = view_tglpegawai.nik " & _
                                "WHERE (view_tglpegawai .tgl_keluar > @awal OR view_tglpegawai .tgl_keluar IS NULL ) " & _
                                "AND tbl_telat.tanggal BETWEEN @awal AND @akhir) AS temp " & _
                                "WHERE temp.departemen = '" & combo_dept.Text & "'"
                        Case "pencarian"
                            sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, * FROM " & _
                                "(SELECT tbl_telat.nik, view_tglpegawai.nama, view_tglpegawai.departemen, tbl_telat.id_telat, " & _
                                "tbl_telat.tanggal, tbl_telat.hari, tbl_telat.telat, tbl_telat.alasan, view_tglpegawai.tgl_keluar " & _
                                "FROM tbl_telat LEFT OUTER JOIN view_tglpegawai ON tbl_telat.nik = view_tglpegawai.nik " & _
                                "WHERE (view_tglpegawai .tgl_keluar > @awal OR view_tglpegawai .tgl_keluar IS NULL) " & _
                                "AND tbl_telat.tanggal BETWEEN @awal AND @akhir) AS temp " & _
                                "WHERE temp.nama LIKE '%" & Text_pencarian.Text & "%' OR temp.nik LIKE '%" & Text_pencarian.Text & "%' "
                    End Select
                Case "Ijin Dinas Luar"
                    Select Case filter
                        Case String.Empty
                            sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, * FROM " & _
                                "(SELECT tbl_dinas.nik,  view_tglpegawai .nama , view_tglpegawai .departemen, " & _
                                "tbl_dinas.id_dinas, tbl_dinas.hari, tbl_dinas.tanggal, tbl_dinas.jam_berangkat, tbl_dinas.jam_pulang, " & _
                                "tbl_dinas.km_awal, tbl_dinas.km_akhir, tbl_dinas.no_pol, tbl_dinas.armada, " & _
                                "tbl_dinas.tujuan, tbl_dinas.keterangan,view_tglpegawai.tgl_keluar FROM tbl_dinas " & _
                                "LEFT OUTER JOIN view_tglpegawai ON tbl_dinas.nik = view_tglpegawai.nik " & _
                                "WHERE (view_tglpegawai .tgl_keluar > @awal OR view_tglpegawai.tgl_keluar IS NULL ) " & _
                                "AND (tbl_dinas.tanggal BETWEEN @awal AND @akhir)) AS temp "
                        Case "departemen"
                            sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, * FROM " & _
                                "(SELECT tbl_dinas.nik,  view_tglpegawai .nama , view_tglpegawai .departemen, " & _
                                "tbl_dinas.id_dinas, tbl_dinas.hari, tbl_dinas.tanggal, tbl_dinas.jam_berangkat, tbl_dinas.jam_pulang, " & _
                                "tbl_dinas.km_awal, tbl_dinas.km_akhir, tbl_dinas.no_pol, tbl_dinas.armada, " & _
                                "tbl_dinas.tujuan, tbl_dinas.keterangan,view_tglpegawai.tgl_keluar FROM tbl_dinas " & _
                                "LEFT OUTER JOIN view_tglpegawai ON tbl_dinas.nik = view_tglpegawai.nik " & _
                                "WHERE (view_tglpegawai .tgl_keluar > @awal OR view_tglpegawai.tgl_keluar IS NULL ) " & _
                                "AND (tbl_dinas.tanggal BETWEEN @awal AND @akhir)) AS temp " & _
                                "WHERE temp.departemen = '" & combo_dept.Text & "'"
                        Case "pencarian"
                            sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, * FROM " & _
                                "(SELECT tbl_dinas.nik,  view_tglpegawai .nama , view_tglpegawai .departemen, " & _
                                "tbl_dinas.id_dinas, tbl_dinas.hari, tbl_dinas.tanggal, tbl_dinas.jam_berangkat, tbl_dinas.jam_pulang, " & _
                                "tbl_dinas.km_awal, tbl_dinas.km_akhir, tbl_dinas.no_pol, tbl_dinas.armada, " & _
                                "tbl_dinas.tujuan, tbl_dinas.keterangan,view_tglpegawai.tgl_keluar FROM tbl_dinas " & _
                                "LEFT OUTER JOIN view_tglpegawai ON tbl_dinas.nik = view_tglpegawai.nik " & _
                                "WHERE (view_tglpegawai .tgl_keluar > @awal OR view_tglpegawai.tgl_keluar IS NULL ) " & _
                                "AND (tbl_dinas.tanggal BETWEEN @awal AND @akhir)) AS temp " & _
                                "WHERE temp.nama LIKE '%" & Text_pencarian.Text & "%' OR temp.nik= '%" & Text_pencarian.Text & "%' "
                    End Select
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("awal", SqlDbType.Date).Value = DT_awal.Text
                .Add("akhir", SqlDbType.Date).Value = DT_akhir.Text
            End With
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            grid.DataSource = DTab
            atur_grid(grid_tampildata, Combo_jenis.Text)
            grid.Refresh()
        Catch ex As Exception
            MsgBox("Gagal menampilkan data " & Combo_jenis.Text & " " & ex.Message)
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub atur_grid(ByVal grid As DataGridView, ByVal opt As String)
        With grid
            Select Case opt
                Case "Ijin Tidak Masuk Kerja"
                    .ReadOnly = True
                    .Enabled = True
                    .Columns(0).HeaderText = "No"
                    .Columns(0).Width = "30"
                    .Columns(0).Frozen = True
                    .Columns(1).HeaderText = "NIK"
                    .Columns(1).Width = "80"
                    .Columns(1).Frozen = True
                    .Columns(2).HeaderText = "Nama"
                    .Columns(2).Width = "180"
                    .Columns(2).Frozen = True
                    .Columns(3).HeaderText = "Departemen"
                    .Columns(3).Width = "155"
                    .Columns(4).HeaderText = "Jabatan"
                    .Columns(4).Width = "180"
                    .Columns(5).HeaderText = "ID Cuti"
                    .Columns(5).Visible = False
                    .Columns(6).HeaderText = "Tanggal"
                    .Columns(6).Width = "90"
                    .Columns(7).HeaderText = "Hari"
                    .Columns(7).Width = "90"
                    .Columns(8).HeaderText = "Mulai Cuti"
                    .Columns(8).Width = "90"
                    .Columns(9).HeaderText = "Hari"
                    .Columns(9).Width = "80"
                    .Columns(10).HeaderText = "Lama Cuti"
                    .Columns(10).Width = "50"
                    .Columns(11).HeaderText = "Tanggal Masuk"
                    .Columns(11).Width = "90"
                    .Columns(12).HeaderText = "hari"
                    .Columns(12).Width = "90"
                    .Columns(13).HeaderText = "Status Cuti"
                    .Columns(13).Width = "90"
                    .Columns(14).HeaderText = "Periode"
                    .Columns(14).Width = "90"
                    .Columns(15).HeaderText = "Keterangan"
                    .Columns(15).Width = "220"
                    .Columns(15).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    .Columns(16).HeaderText = "Tanggal Keluar"
                    .Columns(16).Visible = False
                    .RowHeadersWidth = 5
                    .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                    .Refresh()
                Case "Ijin Meninggalkan Pekerjaan"
                    .ReadOnly = True
                    .Enabled = True
                    .Columns(0).HeaderText = "No"
                    .Columns(0).Width = "30"
                    .Columns(0).Frozen = True
                    .Columns(1).HeaderText = "NIK"
                    .Columns(1).Width = "80"
                    .Columns(1).Frozen = True
                    .Columns(2).HeaderText = "Nama"
                    .Columns(2).Width = "180"
                    .Columns(2).Frozen = True
                    .Columns(3).HeaderText = "Departemen"
                    .Columns(3).Width = "155"
                    .Columns(4).HeaderText = "id ijin"
                    .Columns(4).Visible = False
                    .Columns(5).HeaderText = "Tanggal"
                    .Columns(5).Width = "90"
                    .Columns(6).HeaderText = "Hari"
                    .Columns(6).Width = "90"
                    .Columns(7).HeaderText = "jam awal"
                    .Columns(7).Width = "90"
                    .Columns(8).HeaderText = "jam akhir"
                    .Columns(8).Width = "90"
                    .Columns(9).HeaderText = "status"
                    .Columns(9).Width = "90"
                    .Columns(10).HeaderText = "Alasan"
                    .Columns(10).Width = "230"
                    .Columns(10).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    .Columns(11).HeaderText = "Tanggal Keluar"
                    .Columns(11).Visible = False
                    .RowHeadersWidth = 5
                    .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                    .Refresh()
                Case "Terlambat Kerja"
                    .ReadOnly = True
                    .Enabled = True
                    .Columns(0).HeaderText = "No"
                    .Columns(0).Width = "30"
                    .Columns(0).Frozen = True
                    .Columns(1).HeaderText = "NIK"
                    .Columns(1).Width = "80"
                    .Columns(1).Frozen = True
                    .Columns(2).HeaderText = "Nama"
                    .Columns(2).Width = "180"
                    .Columns(2).Frozen = True
                    .Columns(3).HeaderText = "Departemen"
                    .Columns(3).Width = "155"
                    .Columns(4).HeaderText = "id telat"
                    .Columns(4).Visible = False
                    .Columns(5).HeaderText = "tanggal"
                    .Columns(5).Width = "90"
                    .Columns(6).HeaderText = "Hari"
                    .Columns(6).Width = "90"
                    .Columns(7).HeaderText = "telat"
                    .Columns(7).Width = "90"
                    .Columns(8).HeaderText = "Alasan"
                    .Columns(8).Width = "160"
                    .Columns(8).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    .Columns(9).HeaderText = "Tanggal Keluar"
                    .Columns(9).Visible = False
                    .RowHeadersWidth = 5
                    .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                    .Refresh()
                Case "Ijin Dinas Luar"
                    .ReadOnly = True
                    .Enabled = True
                    .Columns(0).HeaderText = "No"
                    .Columns(0).Width = "30"
                    .Columns(0).Frozen = True
                    .Columns(1).HeaderText = "NIK"
                    .Columns(1).Width = "80"
                    .Columns(1).Frozen = True
                    .Columns(2).HeaderText = "Nama"
                    .Columns(2).Width = "180"
                    .Columns(2).Frozen = True
                    .Columns(3).HeaderText = "Departemen"
                    .Columns(3).Width = "155"
                    .Columns(4).HeaderText = "id dinas"
                    .Columns(4).Visible = False
                    .Columns(5).HeaderText = "hari"
                    .Columns(5).Width = "90"
                    .Columns(6).HeaderText = "Tanggal"
                    .Columns(6).Width = "90"
                    .Columns(7).HeaderText = "jam berangkat"
                    .Columns(7).Width = "90"
                    .Columns(8).HeaderText = "jam pulang"
                    .Columns(8).Width = "90"
                    .Columns(9).HeaderText = "KM awal"
                    .Columns(9).Width = "50"
                    .Columns(10).HeaderText = "KM akhir"
                    .Columns(10).Width = "50"
                    .Columns(11).HeaderText = "No Pol"
                    .Columns(11).Width = "80"
                    .Columns(12).HeaderText = "Armada"
                    .Columns(12).Width = "90"
                    .Columns(13).HeaderText = "Tujuan"
                    .Columns(13).Width = "150"
                    .Columns(14).HeaderText = "Keterangan"
                    .Columns(14).Width = "200"
                    .Columns(15).HeaderText = "Tanggal Keluar"
                    .Columns(15).Visible = False
                    .RowHeadersWidth = 5
                    .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                    .Refresh()
            End Select
        End With
    End Sub

    Private Sub Text_pencarian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_pencarian.TextChanged
        load_grid(grid_tampildata, Combo_jenis.Text, "pencarian")
    End Sub

    Private Sub DT_awal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_awal.ValueChanged
        format_tanggal(DT_awal)
    End Sub

    Private Sub DT_akhir_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_akhir.ValueChanged
        format_tanggal(DT_akhir)
    End Sub

    Private Sub combo_dept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_dept.SelectedIndexChanged
        load_grid(grid_tampildata, Combo_jenis.Text, "departemen")
    End Sub

    Private Sub Combo_jenis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_jenis.SelectedIndexChanged
        load_grid(grid_tampildata, Combo_jenis.Text, Nothing)
        combo_dept.DataSource = Nothing
        load_combo(combo_dept, "departemen", "tbl_jabatan")
    End Sub

    Private Sub HapusDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HapusDataToolStripMenuItem.Click
        With grid_tampildata
            If .Rows.Count > 1 Then
                Dim id, nik, status As String
                Dim tanggal As Date
                Select Case Combo_jenis.Text
                    Case "Ijin Tidak Masuk Kerja"
                        id = .Rows(rowindex).Cells(5).Value
                        nik = .Rows(rowindex).Cells(1).Value
                        tanggal = CDate(.Rows(rowindex).Cells(8).Value)
                        status = .Rows(rowindex).Cells(13).Value

                        If MsgBox("Apakah Data " & vbCrLf & _
                           "Nama : " & .Rows(rowindex).Cells(2).Value & vbCrLf & _
                           "NIK : " & .Rows(rowindex).Cells(1).Value & vbCrLf & _
                           "Departemen : " & .Rows(rowindex).Cells(3).Value & vbCrLf & _
                           "Tanggal : " & .Rows(rowindex).Cells(8).Value & vbCrLf & _
                           "Akah di hapus ?", MsgBoxStyle.Information & vbOKCancel, "INFO") = vbOK Then

                            'hapus tabel tbl_cuti dan hapus tabel tbl_rekapkerja
                            If grid_tampildata.Rows(rowindex).Cells(3).Value = "Satpam" Then
                                If hapus_data("id_Cuti", "tbl_cuti", id, Nothing) = True And
                                    HapusRekapKerja("tbl_rekapkerja", nik, tanggal, status) = True Then
                                    MsgBox("Data telah berhasil di hapus ", MsgBoxStyle.Information, "INFO")
                                    load_grid(grid_tampildata, Combo_jenis.Text, Nothing)
                                End If
                            Else
                                If hapus_data("id_Cuti", "tbl_cuti", id, Nothing) = True And
                                    HapusRekapAll("tbl_rekapkerja", nik, tanggal, status) = True Then
                                    MsgBox("Data telah berhasil di hapus ", MsgBoxStyle.Information, "INFO")
                                    load_grid(grid_tampildata, Combo_jenis.Text, Nothing)
                                End If
                            End If
                        End If

                    Case "Ijin Meninggalkan Pekerjaan"
                        id = .Rows(rowindex).Cells(4).Value
                        nik = .Rows(rowindex).Cells(1).Value
                        tanggal = CDate(.Rows(rowindex).Cells(5).Value)
                        status = .Rows(rowindex).Cells(9).Value

                        If MsgBox("Apakah Data " & vbCrLf & _
                           "Nama : " & .Rows(rowindex).Cells(2).Value & vbCrLf & _
                           "NIK : " & .Rows(rowindex).Cells(1).Value & vbCrLf & _
                           "Departemen : " & .Rows(rowindex).Cells(3).Value & vbCrLf & _
                           "Tanggal : " & .Rows(rowindex).Cells(5).Value & vbCrLf & _
                           "Akah di hapus ?", MsgBoxStyle.Information & vbOKCancel, "INFO") = vbOK Then

                            'hapus tabel tbl_ijin dan hapus tabel tbl_rekapkerja
                            If hapus_data("id_ijin", "tbl_ijin", id, Nothing) = True And
                                HapusRekapKerja("tbl_rekapkerja", nik, tanggal, status) = True Then
                                MsgBox("Data telah berhasil di hapus ", MsgBoxStyle.Information, "INFO")
                                load_grid(grid_tampildata, Combo_jenis.Text, Nothing)
                            End If
                        End If

                    Case "Terlambat Kerja"
                        id = .Rows(rowindex).Cells(4).Value
                        nik = .Rows(rowindex).Cells(1).Value
                        tanggal = CDate(.Rows(rowindex).Cells(5).Value)
                        status = "telat"

                        If MsgBox("Apakah Data " & vbCrLf & _
                               "Nama : " & .Rows(rowindex).Cells(2).Value & vbCrLf & _
                               "NIK : " & .Rows(rowindex).Cells(1).Value & vbCrLf & _
                               "Departemen : " & .Rows(rowindex).Cells(3).Value & vbCrLf & _
                               "Tanggal : " & .Rows(rowindex).Cells(5).Value & vbCrLf & _
                               "Akah di hapus ?", MsgBoxStyle.Information & vbOKCancel, "INFO") = vbOK Then

                            'hapus tabel tbl_cuti dan hapus tabel tbl_rekapkerja
                            If hapus_data("id_telat", "tbl_telat", id, Nothing) = True And
                                HapusRekapKerja("tbl_rekapkerja", nik, tanggal, status) = True Then
                                MsgBox("Data telah berhasil di hapus ", MsgBoxStyle.Information, "INFO")
                                load_grid(grid_tampildata, Combo_jenis.Text, Nothing)
                            End If
                        End If

                    Case "Ijin Dinas Luar"
                        id = .Rows(rowindex).Cells(4).Value
                        nik = .Rows(rowindex).Cells(1).Value
                        If MsgBox("Apakah Data " & vbCrLf & _
                           "Nama : " & .Rows(rowindex).Cells(2).Value & vbCrLf & _
                           "NIK : " & .Rows(rowindex).Cells(1).Value & vbCrLf & _
                           "Departemen : " & .Rows(rowindex).Cells(3).Value & vbCrLf & _
                           "Tanggal : " & .Rows(rowindex).Cells(5).Value & vbCrLf & _
                           "Akah di hapus ?", MsgBoxStyle.Information & vbOKCancel, "INFO") = vbOK Then

                            'hapus tabel tbl_cuti dan hapus tabel tbl_rekapkerja
                            If hapus_data("id_dinas", "tbl_dinas", id, " AND nik = " & nik) = True Then
                                MsgBox("Data telah berhasil di hapus ", MsgBoxStyle.Information, "INFO")
                                load_grid(grid_tampildata, Combo_jenis.Text, Nothing)
                            End If
                        End If

                End Select

            End If
        End With
    End Sub

    Private Sub grid_tampildata_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grid_tampildata.CellMouseUp
        With grid_tampildata
            If e.Button = MouseButtons.Right Then
                If .Rows.Count > 1 Then
                    .ContextMenuStrip = ContextMenuStrip1
                    rowindex = .CurrentRow.Index
                    nik_global = .Rows(rowindex).Cells(1).Value
                    Me.ContextMenuStrip1.Show(Me.grid_tampildata, e.Location)
                    Me.ContextMenuStrip1.Show(Cursor.Position)
                Else
                    .ContextMenuStrip = Nothing
                End If
            End If
        End With
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        grid_tampildata.ReadOnly = False
        grid_tampildata.SelectionMode = DataGridViewSelectionMode.CellSelect
    End Sub

    Private Sub grid_tampildata_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_tampildata.CellEndEdit
        With grid_tampildata
            Dim kolom% = .CurrentCell.ColumnIndex
            Dim nik$, status$
            Dim tanggal As Date

            If kolom < 4 Then
                MsgBox("Untuk merubah data ini, silahkan lewat form jabatan atau form data pegawai", MsgBoxStyle.Information, "INFO")
            Else
                Select Case Combo_jenis.Text
                    Case "Ijin Tidak Masuk Kerja"
                        If MsgBox("Data Ijin Tidak Masuk Kerja telah diedit, update data ke dalam database ?", _
                                  MsgBoxStyle.OkCancel, "INFO") = vbOK Then
                            'update data tabel tbl_cuti
                            nik = .Rows(rowindex).Cells(1).Value
                            tanggal = .Rows(rowindex).Cells(8).Value
                            status = .Rows(rowindex).Cells(13).Value

                            If update_TMK(grid_tampildata) = True And
                                update_rekapkerja(grid_tampildata, nik, tanggal, status) = True Then
                                MsgBox("Data Ijin Tidak Masuk Kerja telah di update", MsgBoxStyle.Information, "INFO")
                                load_grid(grid_tampildata, Combo_jenis.Text, Nothing)
                                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                            End If
                        End If

                    Case "Ijin Meninggalkan Pekerjaan"
                        If MsgBox("Data Ijin Meninggalkan Pekerjaan telah diedit, update data ke dalam database ?", _
                                  MsgBoxStyle.OkCancel, "INFO") = vbOK Then
                            'update data tabel tbl_ijin
                            nik = .Rows(rowindex).Cells(1).Value
                            tanggal = .Rows(rowindex).Cells(5).Value
                            status = .Rows(rowindex).Cells(9).Value

                            If update_IMP(grid_tampildata) = True And
                                update_rekapkerja(grid_tampildata, nik, tanggal, status) = True Then
                                MsgBox("Data Ijin Meninggalkan Pekerjaan telah di update", MsgBoxStyle.Information, "INFO")
                                load_grid(grid_tampildata, Combo_jenis.Text, Nothing)
                                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                            End If
                        End If

                    Case "Terlambat Kerja"
                        If MsgBox("Data Terlambat Kerja telah diedit, update data ke dalam database ?", _
                                 MsgBoxStyle.OkCancel, "INFO") = vbOK Then
                            'update data tabel tbl_telat
                            nik = .Rows(rowindex).Cells(1).Value
                            tanggal = .Rows(rowindex).Cells(5).Value
                            status = "telat"

                            If update_telat(grid_tampildata) = True And
                                update_rekapkerja(grid_tampildata, nik, tanggal, status) = True Then
                                MsgBox("Data Terlambat Kerja telah di update", MsgBoxStyle.Information, "INFO")
                                load_grid(grid_tampildata, Combo_jenis.Text, Nothing)
                                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                            End If
                        End If

                    Case "Ijin Dinas Luar"
                        If MsgBox("Data Ijin Dinas Luar telah diedit, update data ke dalam database ?", _
                                  MsgBoxStyle.OkCancel, "INFO") = vbOK Then
                            'update data tabel tbl_dinas
                            nik = .Rows(rowindex).Cells(1).Value
                            tanggal = .Rows(rowindex).Cells(6).Value

                            If update_dinas(grid_tampildata) = True Then
                                MsgBox("Data Dinas Luar telah di update", MsgBoxStyle.Information, "INFO")
                                load_grid(grid_tampildata, Combo_jenis.Text, Nothing)
                                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                            End If
                        End If
                End Select

            End If
        End With
    End Sub

    'upate data Ijin Tidak Masuk Kerja
    Private Function update_TMK(ByVal grid As DataGridView)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "update tbl_cuti SET HARI = @HARI, TANGGAL = @TANGGAL, LAMA_CUTI = @LAMA_CUTI , " & _
                "MULAI_CUTI = @MULAI_CUTI, TANGGAL_MASUK = @TANGGAL_MASUK, STATUS = @STATUS, " & _
                "PERIODE = @PERIODE, ket = @ket where NIK = @nik " & _
                "AND id_cuti = @id_cuti "
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@NIK", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(1).Value
                .Add("@id_Cuti", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(5).Value
                .Add("@HARI", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(7).Value
                .Add("@TANGGAL", SqlDbType.Date).Value = grid.Rows(rowindex).Cells(6).Value
                .Add("@LAMA_CUTI", SqlDbType.Int).Value = grid.Rows(rowindex).Cells(10).Value
                .Add("@MULAI_CUTI", SqlDbType.Date).Value = grid.Rows(rowindex).Cells(8).Value
                .Add("@TANGGAL_MASUK", SqlDbType.Date).Value = grid.Rows(rowindex).Cells(11).Value
                .Add("@STATUS", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(13).Value
                .Add("PERIODE", SqlDbType.Char).Value = grid.Rows(rowindex).Cells(14).Value
                .Add("@ket", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(15).Value
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam update data tabel tidak masuk kerja " & ex.Message)
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    'update data Ijin Meninggalkan Kerja
    Private Function update_IMP(ByVal grid As DataGridView) As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "update tbl_ijin set hari = @hari, jam = @jam, jam_kembali = @jam_kembali , status = @status, " & _
                "alasan = @alasan WHERE id_ijin = @id_ijin"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@hari", SqlDbType.Char).Value = grid.Rows(rowindex).Cells(6).Value
                If IsNothing(grid.Rows(rowindex).Cells(5).Value) Then
                    .Add("@tanggal", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tanggal", SqlDbType.Date).Value = grid.Rows(rowindex).Cells(5).Value
                End If
                If IsNothing(grid.Rows(rowindex).Cells(7).Value) Then
                    .Add("@jam", SqlDbType.Time).Value = DBNull.Value
                Else
                    .Add("@jam", SqlDbType.Time).Value = grid.Rows(rowindex).Cells(7).Value
                End If
                If IsNothing(grid.Rows(rowindex).Cells(8).Value) Then
                    .Add("@jam_kembali", SqlDbType.Time).Value = DBNull.Value
                Else
                    .Add("@jam_kembali", SqlDbType.Time).Value = grid.Rows(rowindex).Cells(8).Value
                End If
                .Add("@status", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(9).Value
                .Add("@alasan", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(10).Value
                .Add("@id_ijin", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(4).Value
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam update data " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Cursor.Current = Cursors.Default
            Conn.Close()
        End Try
    End Function

    'update data Terlambat Kerja
    Private Function update_telat(ByVal grid As DataGridView)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "update tbl_telat SET telat = @telat, alasan=@alasan, tanggal = @tanggal " & _
                "where nik = @nik AND id_telat = @id_telat "
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(1).Value
                .Add("@tanggal", SqlDbType.Date).Value = grid.Rows(rowindex).Cells(5).Value
                .Add("@telat", SqlDbType.Int).Value = grid.Rows(rowindex).Cells(7).Value
                .Add("@alasan", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(8).Value
                .Add("@id_telat", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(4).Value
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam update data terlambat kerja " & ex.Message)
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    'update data dinas keluar
    Private Function update_dinas(ByVal grid As DataGridView)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "UPDATE tbl_dinas SET hari = @hari, tanggal = @tanggal, jam_berangkat = @jam_berangkat, " & _
                "jam_pulang = @jam_pulang, tujuan = @tujuan, armada = @armada, km_awal = @km_awal, " & _
                "km_akhir = @km_akhir, keterangan = @keterangan, no_pol = @no_pol " & _
                "WHERE id_dinas = @id_dinas AND nik = @nik"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@hari", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(5).Value
                .Add("@tanggal", SqlDbType.Date).Value = grid.Rows(rowindex).Cells(6).Value
                .Add("@jam_berangkat", SqlDbType.Time).Value = grid.Rows(rowindex).Cells(7).Value
                .Add("@jam_pulang", SqlDbType.Time).Value = grid.Rows(rowindex).Cells(8).Value
                .Add("@tujuan", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(13).Value
                .Add("@armada", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(12).Value
                .Add("@km_awal", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(9).Value
                .Add("@km_akhir", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(10).Value
                .Add("@keterangan", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(14).Value
                .Add("@no_pol", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(11).Value
                .Add("@id_dinas", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(4).Value
                .Add("@nik", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(1).Value
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("gagal dalam update data dinas luar " & ex.Message)
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function


    'update tabel tbl_rekapkerja
    Private Function update_rekapkerja(ByVal grid As DataGridView, ByVal nik As String, _
                                  ByVal tanggal As Date, ByVal status As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "update tbl_rekapkerja set status = @status " & _
                "where nik = @nik and tanggal =  @tanggal"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@status", SqlDbType.VarChar).Value = status
                .Add("@tanggal", SqlDbType.Date).Value = tanggal
                .Add("@nik", SqlDbType.VarChar).Value = nik
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("gagal dalam update rekap kerja " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Sub grid_tampildata_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_tampildata.CellContentClick

    End Sub

    Private Sub Buttonkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonkeluar.Click
        Me.Close()
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub
End Class