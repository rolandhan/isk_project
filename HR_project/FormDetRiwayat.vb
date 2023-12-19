Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Globalization

Public Class FormDetRiwayat

    Private Sub FormDetRiwayat_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        format_tanggal_kosong(DTawal)
        format_tanggal_kosong(DTakhir)
        Application.CurrentCulture = New CultureInfo("EN-US")
    End Sub

    Private Sub isi_cmblaporan()
        With Combo_laporan
            .Items.Add("Presensi Bulanan")
            .Items.Add("Rincian Perijinan")
        End With
    End Sub

    Private Sub atur_gridabsen()
        With grid_absen
            .ReadOnly = True
            .Enabled = True
            .ColumnHeadersVisible = True
            .RowHeadersWidth = 5
            .Columns(0).HeaderText = "No"
            .Columns(0).Width = 30
            .Columns(1).HeaderText = "NIK"
            .Columns(1).Visible = False
            .Columns(2).HeaderText = "HARI"
            .Columns(2).Width = 80
            .Columns(3).HeaderText = "TANGGAL"
            .Columns(3).Width = 80
            .Columns(4).HeaderText = "MASUK"
            .Columns(4).Width = 80
            .Columns(5).HeaderText = "KELUAR"
            .Columns(5).Width = 80

        End With
    End Sub

    Private Sub atur_gridimp()
        With grid_imp
            .ReadOnly = True
            .Enabled = True
            .ColumnHeadersVisible = True
            .RowHeadersWidth = 5
            .Columns(0).HeaderText = "No"
            .Columns(0).Width = 30
            .Columns(1).HeaderText = "NIK"
            .Columns(1).Visible = False
            .Columns(2).HeaderText = "HARI"
            .Columns(2).Width = 80
            .Columns(3).HeaderText = "TANGGAL"
            .Columns(3).Width = 80
            .Columns(4).HeaderText = "MASUK"
            .Columns(4).Width = 80
            .Columns(5).HeaderText = "KELUAR"
            .Columns(5).Width = 80
        End With
    End Sub

    Private Sub atur_gridpencarian()
        With grid_cari
            .ReadOnly = True
            .Enabled = True
            .ColumnHeadersVisible = True
            .RowHeadersWidth = 5
            .Columns(0).HeaderText = "NIK"
            .Columns(0).Width = 50
            .Columns(1).HeaderText = "Nama"
            .Columns(1).Width = 150
            .Columns(2).HeaderText = "Departemen"
            .Columns(2).Width = 95
        End With
    End Sub

    Private Sub atur_gridtdkmasuk()

    End Sub

    Private Sub atur_gridtelat()

    End Sub

    Private Sub load_gridabsen()
        Try
            clear_command()
            openDB()
            sql = "SELECT ROW_NUMBER() OVER(ORDER BY nik DESC) AS No, " & _
                "nik, (CASE WHEN DATENAME(WEEKDAY ,tanggal)= 'Sunday' THEN 'Minggu' " & _
                "WHEN DATENAME(WEEKDAY ,tanggal)= 'Monday' THEN 'Senin' " & _
                "WHEN DATENAME(WEEKDAY ,tanggal)= 'Tuesday'THEN 'Selasa' " & _
                "WHEN DATENAME(WEEKDAY ,tanggal)= 'Wednesday' THEN 'Rabu' " & _
                "WHEN DATENAME(WEEKDAY ,tanggal)= 'Thursday' THEN 'Kamis'" & _
                "WHEN DATENAME(WEEKDAY ,tanggal)= 'Friday' THEN 'Jumat' " & _
                "WHEN DATENAME(WEEKDAY ,tanggal)= 'Saturday' THEN 'sabtu'END) as hari, " & _
                "tanggal, timein, timeout FROM dbo.tbl_dataabsen " & _
                "WHERE tbl_dataabsen.tanggal BETWEEN @awal AND @akhir AND dbo.tbl_dataabsen.nik = @nik"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = nik_global
                .Add("@awal", SqlDbType.Date).Value = DTawal.Text
                .Add("@akhir", SqlDbType.Date).Value = DTakhir.Text
            End With
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DataTab = New DataTable
            DataTab.Clear()
            sqladapter.Fill(DataTab)
            grid_absen.DataSource = DataTab
            atur_gridabsen()
            grid_absen.Refresh()
            Cursor.Current = Cursors.WaitCursor
        Catch ex As Exception
            MsgBox("Gagal menampilkan data " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Private Sub load_dtdiri()
        Try
            clear_command()
            openDB()
            sql = "SELECT nik, nama, departemen, status, atasan, jabatan FROM view_pegawai WHERE " & _
                "nik = '" & nik_global & "'"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                Text_nik.Text = nik_global
                Text_nama.Text = sqlreader.Item("nama")
                Text_dept.Text = sqlreader.Item("departemen")
                Text_stat.Text = sqlreader.Item("status")
                Text_atasan.Text = sqlreader.Item("atasan")
                Text_jbt.Text = sqlreader.Item("jabatan")
                Cursor.Current = Cursors.WaitCursor
            End If
            sqlreader.Close()
        Catch ex As Exception
            MsgBox("gagal menampilkan data " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Private Sub load_gridimp()
        Try
            clear_command()
            openDB()
            sql = "SELECT ROW_NUMBER() OVER(ORDER BY nik DESC) AS No, nik, hari, tanggal, jam, status, alasan " & _
                "FROM tbl_ijin WHERE tanggal BETWEEN @awal AND @akhir AND nik = @nik ORDER BY tanggal"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@awal", SqlDbType.Date).Value = DTawal.Text
            sqlcmd.Parameters.Add("@akhir", SqlDbType.Date).Value = DTakhir.Text
            sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = nik_global
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DataTab = New DataTable
            DataTab.Clear()
            sqladapter.Fill(DataTab)
            grid_imp.DataSource = DataTab
            Cursor.Current = Cursors.WaitCursor
        Catch ex As Exception
            MsgBox("Gagal menampilkan data keterangan IMP " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Private Sub load_gridtdkmasuk()
        Try
            clear_command()
            openDB()
            sql = "SELECT ROW_NUMBER() OVER(ORDER BY nik DESC) AS No, nik, hari, tanggal, " & _
                "{ fn CONCAT(CONVERT(VARCHAR(5),lama_cuti),' hari') }  AS lama, mulai_cuti, status, " & _
                "tanggal_masuk, ket FROM tbl_cuti WHERE mulai_cuti BETWEEN @awal AND @akhir AND nik = @nik "
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@awal", SqlDbType.Date).Value = DTawal.Text
            sqlcmd.Parameters.Add("@akhir", SqlDbType.Date).Value = DTakhir.Text
            sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = nik_global
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DataTab = New DataTable
            DataTab.Clear()
            sqladapter.Fill(DataTab)
            grid_tdkmsk.DataSource = DataTab
            Cursor.Current = Cursors.WaitCursor
        Catch ex As Exception
            MsgBox("Gagal menampilkan data keterangan tidak masuk " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Private Sub load_gridtelat()
        Try
            clear_command()
            openDB()
            sql = "SELECT ROW_NUMBER() OVER(ORDER BY nik DESC) AS No, nik, hari, tanggal, " & _
                "{ fn CONCAT(CONVERT(VARCHAR(5),telat),' menit') } as telat, alasan " & _
                "FROM tbl_telat WHERE tanggal BETWEEN @awal AND @akhir AND nik = @nik ORDER BY tanggal"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@awal", SqlDbType.Date).Value = DTawal.Text
            sqlcmd.Parameters.Add("@akhir", SqlDbType.Date).Value = DTakhir.Text
            sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = nik_global
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DataTab = New DataTable
            DataTab.Clear()
            sqladapter.Fill(DataTab)
            grid_telat.DataSource = DataTab
            Cursor.Current = Cursors.WaitCursor
        Catch ex As Exception
            MsgBox("Gagal menampilkan data keterangan telat " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Private Sub load_gridpgl()
        Try
            clear_command()
            openDB()
            sql = "SELECT ROW_NUMBER() OVER(ORDER BY nik DESC) AS No, nik, " & _
                "jenis_peringatan, catatan, tanggal, periode " & _
                "FROM tbl_catatan WHERE tanggal BETWEEN @awal AND @akhir AND nik = @nik ORDER BY tanggal"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@awal", SqlDbType.Date).Value = DTawal.Text
            sqlcmd.Parameters.Add("@akhir", SqlDbType.Date).Value = DTakhir.Text
            sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = nik_global
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DataTab = New DataTable
            DataTab.Clear()
            sqladapter.Fill(DataTab)
            grid_panggil.DataSource = DataTab
            Cursor.Current = Cursors.WaitCursor
        Catch ex As Exception
            MsgBox("Gagal menampilkan data keterangan catatan " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Private Sub hapus()
        Clear_text(Me, GroupBox2)
        Clear_text(Me, GroupBox3)
        Clear_text(Me, GroupBox5)
        Clear_text(Me, GroupBox7)
        Clear_text(Me, GroupBox8)
    End Sub

    Private Sub load_jml()
        Try
            clear_command()
            openDB()
            sql = "SELECT view_pegawai .nik, COALESCE(tbl_temp.cuti,0) AS cuti, COALESCE(tbl_temp.ijin,0) AS ijin, " & _
                "COALESCE(tbl_temp.sakit,0) AS sakit, " & _
                "COALESCE(tbl_temp.kd,0) AS kd, COALESCE(tbl_temp.alfa,0) AS alfa, " & _
                "COALESCE(tbl_temp.cuti_khusus,0) AS cuti_khusus, " & _
                "COALESCE(tbl_temp.telat,0) AS telat, COALESCE(tbl_temp.imp_1,0) AS imp_1, " & _
                "COALESCE(tbl_temp.imp_set,0) AS imp_set, tbl_tanggalkerja .tgl_masuk_rec , " & _
                "(CASE WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_masuk_rec, GETDATE()) = 1 THEN " & _
                "CASE WHEN day(dbo.tbl_tanggalkerja.tgl_masuk_rec) < 16 THEN " & _
                "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 1 THEN 6 " & _
                "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 2 THEN 5 " & _
                "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 3 THEN 4  " & _
                "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 4 THEN 3  " & _
                "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 5 THEN 2 " & _
                "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 6 THEN 1 END " & _
                "WHEN day(dbo.tbl_tanggalkerja.tgl_masuk_rec) > 15 THEN " & _
                "CASE WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 1 THEN 5 " & _
                "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 2 THEN 4 " & _
                "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 3 THEN 3 " & _
                "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 4 THEN 2 " & _
                "WHEN month(dbo.tbl_tanggalkerja.tgl_masuk_rec) = 5 THEN 1 END END " & _
                "WHEN DATEDIFF(year, dbo.tbl_tanggalkerja.tgl_masuk_rec, GETDATE()) > 1 THEN 6 ELSE 0 END) AS total_cuti " & _
                "FROM (SELECT tbl_rekapkerja.nik, " & _
                "SUM(CASE WHEN tbl_rekapkerja.status ='cuti' THEN LAMA ELSE NULL END) AS cuti, " & _
                "SUM(CASE WHEN tbl_rekapkerja.status = 'ijin' THEN lama ELSE NULL END) AS ijin, " & _
                "SUM(CASE WHEN tbl_rekapkerja.status = 'sakit' THEN tbl_rekapkerja.lama ELSE NULL END) AS sakit, " & _
                "SUM(CASE WHEN tbl_rekapkerja.status = 'kd' THEN tbl_rekapkerja.lama ELSE NULL END) as kd, " & _
                "SUM(CASE WHEN tbl_rekapkerja.status = 'alfa' THEN tbl_rekapkerja.lama ELSE NULL END) as alfa, " & _
                "SUM(CASE WHEN tbl_rekapkerja.status = 'cuti kusus' THEN tbl_rekapkerja.lama ELSE NULL END) AS cuti_khusus," & _
                "COUNT(CASE WHEN tbl_rekapkerja.status = 'telat' THEN tbl_rekapkerja.status ELSE NULL END) as telat, " & _
                "COUNT(CASE WHEN tbl_rekapkerja.status = 'setengah hari' THEN tbl_rekapkerja.status ELSE NULL END) AS imp_set, " & _
                "COUNT(CASE WHEN tbl_rekapkerja.status = '1 jam' THEN tbl_rekapkerja.status ELSE NULL END) AS imp_1 " & _
                "FROM tbl_rekapkerja WHERE tbl_rekapkerja.tanggal BETWEEN @awal AND @akhir " & _
                "GROUP BY tbl_rekapkerja.nik) AS tbl_temp RIGHT OUTER JOIN view_pegawai " & _
                "ON tbl_temp.nik = view_pegawai .nik LEFT OUTER JOIN tbl_tanggalkerja " & _
                "ON view_pegawai.nik = tbl_tanggalkerja .nik"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@awal", SqlDbType.Date).Value = DTawal.Text
                .Add("@akhir", SqlDbType.Date).Value = DTakhir.Text
            End With
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                Text_cuti.Text = sqlreader.Item("cuti")
                Text_ijin.Text = sqlreader.Item("ijin")
                Text_sakit.Text = sqlreader.Item("sakit")
                Text_kd.Text = sqlreader.Item("kd")
                Text_alfa.Text = sqlreader.Item("alfa")
                Text_cutikhusus.Text = sqlreader.Item("cuti_khusus")
                Text_sisa.Text = sqlreader.Item("total_cuti") - sqlreader.Item("cuti")
                Text_imp1.Text = sqlreader.Item("imp_1")
                text_impset.Text = sqlreader.Item("imp_set")
                Text_telat.Text = sqlreader.Item("telat")
            End If
            sqlreader.Close()
        Catch ex As Exception
            MsgBox("gagal menampilkan data total " & ex.Message)
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub Text_cari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_cari.TextChanged
        Try
            clear_command()
            openDB()
            grid_cari.Visible = True
            sql = "SELECT nik, nama, departemen FROM view_pegawai WHERE nik LIKE '%" & Text_cari.Text & "%' " & _
                "OR nama LIKE '%" & Text_cari.Text & "%' OR departemen LIKE '%" & Text_cari.Text & "%' "
            sqladapter = New SqlDataAdapter(sql, Conn)
            DataTab = New DataTable
            DataTab.Clear()
            sqladapter.Fill(DataTab)
            grid_cari.DataSource = DataTab
            atur_gridpencarian()
            grid_cari.Refresh()
        Catch ex As Exception
            MsgBox("gagal dalam menampilkan pencarian data " & ex.Message, MsgBoxStyle.Information, "INFO")
        End Try
    End Sub

    Private Sub grid_cari_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_cari.CellContentDoubleClick
        Try
            nik_global = grid_cari.Rows(grid_cari.CurrentRow.Index).Cells(0).Value
            grid_cari.Visible = False
            hapus()
            load_gridabsen()
            load_dtdiri()
            load_gridtdkmasuk()
            load_gridimp()
            load_gridtelat()
            load_gridpgl()
            load_jml()
            Cursor.Current = Cursors.WaitCursor
            grid_cari.Visible = False
        Catch ex As Exception
            MsgBox("error dalam penampilan data ")
        Finally
            Cursor.Current = Cursors.Arrow
            grid_cari.Visible = False
        End Try
    End Sub

    Private Sub DTawal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTawal.ValueChanged
        format_tanggal(DTawal)
    End Sub

    Private Sub DTakhir_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTakhir.ValueChanged
        format_tanggal(DTakhir)

    End Sub

    Private Sub grid_cari_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_cari.CellContentClick

    End Sub

    Private Sub Button_cetak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_cetak.Click
        Try
            If Combo_laporan.Text = String.Empty Then
                MsgBox("silahkan pilih terlebih dahulu", MsgBoxStyle.Information, "INFO")
            Else
                clear_command()
                openDB()
                sql = ""

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class