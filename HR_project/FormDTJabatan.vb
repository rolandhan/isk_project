Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Globalization
Imports VB = Microsoft.VisualBasic.Strings

Public Class FormDTJabatan
    Dim periode_awal, periode_akhir, loc_cursor As String
    Dim rowindex As Integer
    Dim num As Integer = 0
    Private info As Integer
    Private no_urut As String


    Private Sub atur_gridkary()
        With grid_karyawan
            .ReadOnly = True
            .Enabled = True
            .Columns(0).HeaderText = "NIK"
            .Columns(0).Width = "60"
            .Columns(1).HeaderText = "Nama"
            .Columns(1).Width = "180"
            .Columns(2).HeaderText = "Departemen"
            .Columns(2).Width = "105"
            .Columns(3).HeaderText = "Jabatan"
            .Columns(3).Width = "155"
            .Columns(4).HeaderText = "status"
            .Columns(4).Width = "60"
            .Columns(5).HeaderText = "atasan"
            .Columns(5).Width = "75"
            .RowHeadersWidth = 5
        End With
    End Sub

    Private Sub load_combobox()
        Isi_combostatus_kary(Combo_status)
    End Sub

    Private Sub load_gridkaryawan(ByVal cond As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            Select Case cond
                Case String.Empty
                    sql = "select nik, nama, departemen, jabatan,  status_karyawan, atasan FROM view_dtpegawai"
                Case "Departemen"
                    sql = "select nik, nama, departemen, jabatan, status_karyawan, atasan  FROM view_dtpegawai" & _
                    " where departemen = '" & Combo_depart.Text & "'"
                Case "Pencarian"
                    sql = "select nik, nama, departemen, jabatan,  status_karyawan, atasan FROM view_dtpegawai " & _
                "WHERE nama LIKE '%" & Text_pencarian.Text & "%' OR nik LIKE '%" & Text_pencarian.Text & "%'"
            End Select
            sqladapter = New SqlDataAdapter(sql, Conn)
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            grid_karyawan.DataSource = DTab
            atur_gridkary()
            grid_karyawan.Refresh()
        Catch ex As Exception
            MsgBox("gagal menampilkan data", MsgBoxStyle.Information, "INFO")
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub Button_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_simpan.Click
        If Text_nik.Text = String.Empty Then
            MsgBox("NIK tidak boleh kosong !", MsgBoxStyle.Critical, "INFO")
        ElseIf Text_nama.Text = String.Empty Then
            MsgBox("Nama tidak boleh kosong !", MsgBoxStyle.Critical, "INFO")
        Else
            If MsgBox("Apakah data siap disimpan ? ", MsgBoxStyle.Information & MsgBoxStyle.OkCancel, "INFO") = MsgBoxResult.Ok Then
                Try
                    If checking_data("nik", "tbl_jabatan", Text_nik.Text, " AND tgl_awal = '" & DT_tglawal.Text & "'") = True Then
                        update_dtjabatan()
                    Else
                        'simpan tabel tbl_jabatan
                        simpan_dtjabatan()
                    End If
                    
                    If checking_data("nik", "tbl_tanggalkerja", Text_nik.Text, Nothing) = True Then
                        'update tbl_tglkerja
                        update_tglKerja()
                    Else
                        'simpan tgl_tglkerja
                        simpan_tglkerja()
                    End If
                    If checking_data("nik", "tbl_statuskerja", Text_nik.Text, Nothing) = True Then
                        'update tbl_statuskerja
                        update_dtstatusKerja()
                    Else
                        'simpan tbl_statuskerja
                        simpan_dtstatuskerja()
                    End If

                    If info = 1 Then
                        MsgBox("Data telah berhasil di simpan", MsgBoxStyle.Information, "INFO")
                        hapus()
                        reload()
                        load_gridkaryawan(Nothing)
                    Else
                        MsgBox("Gagal dalam penyimpanan data", MsgBoxStyle.Information, "INFO")
                    End If
                Catch ex As Exception
                    MsgBox("Gagal menyimpan data " & ex.Message, MsgBoxStyle.Information, "INFO")
                Finally
                    hapus()
                    Conn.Close()
                End Try
            Else
                Text_nik.Focus()
            End If
        End If
    End Sub

    Private Sub check_nourut(ByVal tabel As String)
        Try
            no_urut = String.Empty
            clear_command()
            openDB()
            sql = "select TOP(1) nik, nik_lama, no_urut from " & tabel & " where nik = @nik  ORDER BY no_urut DESC"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                '000000-0000
                Dim no$ = sqlreader.Item("no_urut")
                num = CInt(VB.Right(no, 4)) + 1
                no_urut = VB.Left(sqlreader.Item("no_urut"), 6) & "-" & VB.Right("000" & num, 4)
            Else
                no_urut = Text_nik.Text & "-000" & 1
            End If
            sqlreader.Close()
        Catch ex As Exception
            MsgBox("gagal dalam pencarian no urut " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Function nourut() As String '2112-300000-1
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = ""
            sqlcmd = New SqlCommand(sql, Conn)
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                If VB.Left(sqlreader.Item(""), 4) = VB.Right(Year(DT_tglawal.Text), 2) & _
                    VB.Right("00" & Month(DT_tglawal.Text), 2) Then
                    Return VB.Left(sqlreader.Item(""), 12) & CInt(VB.Right(sqlreader.Item(""), 1)) + 1
                Else
                    Return VB.Right(Year(DT_tglawal.Text), 2) & VB.Right("00" & Month(DT_tglawal.Text), 2) & "-" & _
                    Text_nik.Text & "-" & 1
                End If
            Else
                Return VB.Right(Year(DT_tglawal.Text), 2) & VB.Right("00" & Month(DT_tglawal.Text), 2) & "-" & _
                    Text_nik.Text & "-" & 1
            End If
        Catch ex As Exception
            MsgBox("gagal dalam membuat no urut", MsgBoxStyle.Information, "INFO")
            Return Nothing
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Sub simpan_dtjabatan()
        check_nourut("tbl_jabatan")
        Try
            clear_command()
            openDB()
            sql = "insert into tbl_jabatan(nik, departemen, jabatan, tgl_awal, tgl_akhir, status_karyawan,no_urut, atasan, nik_lama) " & _
                "values(@nik, @departemen, @jabatan, @tgl_awal, @tgl_akhir, @status_karyawan, @no_urut, @atasan, @nik_lama)"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                .Add("@departemen", SqlDbType.VarChar).Value = Combo_departemen.Text
                .Add("@jabatan", SqlDbType.VarChar).Value = combo_jbt.Text
                If DT_tglawal.Text = " " Then
                    .Add("@tgl_awal", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tgl_awal", SqlDbType.Date).Value = DT_tglawal.Text
                End If
                If DT_tglakhir.Text = " " Then
                    .Add("@tgl_akhir", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tgl_akhir", SqlDbType.Date).Value = DT_tglakhir.Text
                End If
                .Add("@status_karyawan", SqlDbType.VarChar).Value = Combo_status.Text
                .Add("@no_urut", SqlDbType.VarChar).Value = no_urut
                .Add("@atasan", SqlDbType.VarChar).Value = Combo_atasan.Text
                .Add("@nik_lama", SqlDbType.VarChar).Value = Text_nik.Text
            End With
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("gagal penyimpanan data jabatan " & ex.Message, MsgBoxStyle.Information, "INFO")
        End Try
    End Sub

    Private Function CekNIKLama() As String

    End Function

    Private Sub simpan_tglkerja()
        Try
            clear_command()
            openDB()
            sql = "insert into tbl_tanggalkerja( nik, tgl_masuk_rec, tgl_masuk_harian, tgl_kontrak, tgl_tetap, " & _
                "tgl_keluar) values(@nik, @tgl_masuk_rec, @tgl_masuk_harian, @tgl_kontrak, " & _
                "@tgl_tetap, @tgl_keluar)"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                If DT_masukrec.Text = " " Or DT_masukrec.Text = String.Empty Then
                    .Add("@tgl_masuk_rec", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tgl_masuk_rec", SqlDbType.Date).Value = DT_masukrec.Text
                End If
                If DT_tglawal.Text = " " Or DT_tglawal.Text = String.Empty Then
                    .Add("@tgl_masuk_harian", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tgl_masuk_harian", SqlDbType.Date).Value = DT_tglawal.Text
                End If
                If DT_kontrak.Text = " " Or DT_kontrak.Text = String.Empty Then
                    .Add("@tgl_kontrak", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tgl_kontrak", SqlDbType.Date).Value = DT_kontrak.Text
                End If
                If DT_tetap.Text = " " Or DT_kontrak.Text = String.Empty Then
                    .Add("@tgl_tetap", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tgl_tetap", SqlDbType.Date).Value = DT_tetap.Text
                End If
                If Combo_status.Text = "Harian" Or Combo_status.Text = "harian" Then
                    If DT_tglakhir.Text = " " Or DT_tglakhir.Text = String.Empty Then
                        .Add("@tgl_keluar", SqlDbType.Date).Value = DBNull.Value
                    Else
                        .Add("@tgl_keluar", SqlDbType.Date).Value = DT_tglakhir.Text
                    End If
                Else
                    If DT_Keluar.Text = " " Or DT_Keluar.Text = String.Empty Then
                        .Add("@tgl_keluar", SqlDbType.Date).Value = DBNull.Value
                    Else
                        .Add("@tgl_keluar", SqlDbType.Date).Value = DT_Keluar.Text
                    End If
                End If
                
                sqlcmd.ExecuteNonQuery()
                info = 1
            End With
        Catch ex As Exception
            MsgBox("Gagal dalam penyimpanan tabel tanggal kerja " & ex.Message, MsgBoxStyle.Information, "INFO")
        End Try
    End Sub

    Private Sub simpan_dtstatuskerja()
        Try
            clear_command()
            openDB()
            sql = "insert into tbl_statuskerja(nik, departemen, jabatan, status, atasan) " & _
                "values(@nik, @departemen, @jabatan, @status, @atasan)"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                .Add("@departemen", SqlDbType.VarChar).Value = Combo_departemen.Text
                .Add("@jabatan", SqlDbType.VarChar).Value = combo_jbt.Text
                .Add("@status", SqlDbType.VarChar).Value = Combo_status.Text
                .Add("@atasan", SqlDbType.VarChar).Value = Combo_atasan.Text
            End With
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("gagal dalam penyimpanan data status kerja " & ex.Message, MsgBoxStyle.Information, "INFO")
        End Try
    End Sub

    Private Sub update_dtjabatan()
        If Not combo_jbt.Text = String.Empty Then
            Try
                clear_command()
                openDB()
                sql = "update tbl_jabatan set departemen = @departemen, jabatan = @jabatan, " & _
                    "tgl_akhir = @tgl_akhir, status_karyawan = @status_karyawan, atasan = @atasan where nik = @nik and no_urut = @no_urut"
                sqlcmd = New SqlCommand(sql, Conn)
                With sqlcmd.Parameters
                    .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                    .Add("@departemen", SqlDbType.VarChar).Value = Combo_departemen.Text
                    .Add("@jabatan", SqlDbType.VarChar).Value = combo_jbt.Text
                    If DT_tglakhir.Text = " " Then
                        .Add("@tgl_akhir", SqlDbType.Date).Value = DBNull.Value
                    Else
                        .Add("@tgl_akhir", SqlDbType.Date).Value = DT_tglakhir.Text
                    End If
                    .Add("@status_karyawan", SqlDbType.VarChar).Value = Combo_status.Text
                    .Add("@no_urut", SqlDbType.VarChar).Value = no_urut
                    .Add("@atasan", SqlDbType.VarChar).Value = Combo_atasan.Text
                End With
                sqlcmd.ExecuteNonQuery()
            Catch ex As Exception
                MsgBox("gagal dalam update data jabatan " & ex.Message, MsgBoxStyle.Information, "INFO")
            End Try
        End If
    End Sub

    Private Sub update_dtstatusKerja()
        Try
            clear_command()
            openDB()
            sql = "update tbl_statuskerja set departemen = @departemen , jabatan = @jabatan, " & _
                "status = @status , atasan = @atasan where nik = @nik"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                .Add("@departemen", SqlDbType.VarChar).Value = Combo_departemen.Text
                .Add("@jabatan", SqlDbType.VarChar).Value = combo_jbt.Text
                .Add("@status", SqlDbType.VarChar).Value = Combo_status.Text
                .Add("@atasan", SqlDbType.VarChar).Value = Combo_atasan.Text
            End With
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("gagal dalam update data satus kerja " & ex.Message, "INFO")
        End Try
    End Sub

    Private Sub update_tglKerja()
        Try
            clear_command()
            openDB()
            sql = "update tbl_tanggalkerja set tgl_masuk_rec = @tgl_masuk_rec, " & _
                "tgl_kontrak = @tgl_kontrak, tgl_tetap = @tgl_tetap , tgl_keluar = @tgl_keluar " & _
                "where nik = @nik"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                If DT_masukrec.Text = " " Then
                    .Add("@tgl_masuk_rec", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tgl_masuk_rec", SqlDbType.Date).Value = DT_masukrec.Text
                End If
                If DT_kontrak.Text = " " Then
                    .Add("@tgl_kontrak", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tgl_kontrak", SqlDbType.Date).Value = DT_kontrak.Text
                End If
                If DT_tetap.Text = " " Then
                    .Add("@tgl_tetap", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tgl_tetap", SqlDbType.Date).Value = DT_tetap.Text
                End If
                If DT_Keluar.Text = " " Then
                    .Add("@tgl_keluar", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tgl_keluar", SqlDbType.Date).Value = DT_Keluar.Text
                End If
                sqlcmd.ExecuteNonQuery()
                info = 1
            End With
        Catch ex As Exception
            MsgBox("Gagal dalam update tabel tanggal kerja " & ex.Message, MsgBoxStyle.Information, "INFO")
        End Try
    End Sub

    Private Sub hapus()
        Clear_text(Nothing, Groupnik)
        Clear_text(Nothing, Groupjabatan)
        'clear_date(Me, Grouptanggal)
        clear_date(Me, Groupmasuk)
        clear_date(Me, Groupjabatan)
        Clear_combo(Me, Groupnik)
        Clear_combo(Me, Groupjabatan)
        no_urut = String.Empty
    End Sub


    Private Sub reload()
        load_combobox()
        load_gridkaryawan(Nothing)
        'clear_date(Me, Grouptanggal)
        clear_date(Me, Groupmasuk)
        load_combo(Combo_depart, "departemen", "tbl_statuskerja")
        fill_combo(combo_jbt, "jabatan", "tbl_jabatan")
        fill_combo(Combo_departemen, "departemen", "tbl_statuskerja")
    End Sub


    Private Sub DT_masukrec_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_masukrec.ValueChanged
        format_tanggal(DT_masukrec)
    End Sub

    Private Sub DT_kontrak_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        format_tanggal(DT_kontrak)
    End Sub

    Private Sub DT_tetap_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        format_tanggal(DT_tetap)
    End Sub

    Private Sub DT_Keluar_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        format_tanggal(DT_Keluar)
    End Sub

    Private Sub grid_karyawan_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_karyawan.CellContentDoubleClick
        hapus()
        With grid_karyawan
            rowindex = .CurrentRow.Index
            Text_nik.Text = .Rows(rowindex).Cells(0).Value
            Text_nama.Text = .Rows(rowindex).Cells(1).Value
            If IsDBNull(.Rows(rowindex).Cells(2).Value) = False Then
                Combo_departemen.Text = .Rows(rowindex).Cells(2).Value
            End If
            If Not IsDBNull(.Rows(rowindex).Cells(5).Value) Then
                Combo_atasan.Text = .Rows(rowindex).Cells(5).Value
            End If
            'tampil periode data jabatan
            Try
                Cursor.Current = Cursors.WaitCursor
                clear_command()
                openDB()
                sql = "SELECT TOP (1) nik, departemen, jabatan, status_karyawan, no_urut, tgl_awal, tgl_akhir, atasan, nik_lama FROM tbl_jabatan " & _
                    "WHERE nik = @nik ORDER BY no_urut DESC"
                sqlcmd = New SqlCommand(sql, Conn)
                sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = .Rows(rowindex).Cells(0).Value
                sqlreader = sqlcmd.ExecuteReader
                If sqlreader.Read Then
                    If Not IsDBNull(sqlreader.Item("jabatan")) Then
                        combo_jbt.Text = sqlreader.Item("jabatan")
                    End If
                    If Not IsDBNull(sqlreader.Item("status_karyawan")) Then
                        Combo_status.Text = sqlreader.Item("status_karyawan")
                    End If
                    If Not IsDBNull(sqlreader.Item("tgl_awal")) Then
                        DT_tglawal.Text = sqlreader.Item("tgl_awal")
                    End If
                    If Not IsDBNull(sqlreader.Item("tgl_akhir")) Then
                        DT_tglakhir.Text = sqlreader.Item("tgl_akhir")
                    End If
                    If Not IsDBNull(sqlreader.Item("no_urut")) Then
                        no_urut = sqlreader.Item("no_urut")
                    End If
                End If
            Catch ex As Exception
                MsgBox("gagal dalam memuat data jabatan" & ex.Message, MsgBoxStyle.Information, "INFO")
            Finally
                Conn.Close()
                Cursor.Current = Cursors.Arrow
            End Try
            ' tampil data dari tanggal recruit
            'cek status kerja (tetap, kontrak, harian tetap, harian_sementara)
            If Not IsDBNull(grid_karyawan.Rows(rowindex).Cells(4).Value) Then
                Try
                    Cursor.Current = Cursors.WaitCursor
                    clear_command()
                    openDB()
                    sql = "SELECT nik, tgl_masuk_rec, tgl_kontrak, tgl_tetap, tgl_keluar FROM tbl_tanggalkerja " & _
                        "WHERE nik = @nik"
                    sqlcmd = New SqlCommand(sql, Conn)
                    sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = .Rows(rowindex).Cells(0).Value
                    sqlreader = sqlcmd.ExecuteReader
                    If sqlreader.Read Then
                        If Not IsDBNull(sqlreader.Item("tgl_masuk_rec")) Then
                            DT_masukrec.Text = sqlreader.Item("tgl_masuk_rec")
                        End If
                        If Not IsDBNull(sqlreader.Item("tgl_kontrak")) Then
                            DT_kontrak.Text = sqlreader.Item("tgl_kontrak")
                        End If
                        If Not IsDBNull(sqlreader.Item("tgl_tetap")) Then
                            DT_tetap.Text = sqlreader.Item("tgl_tetap")
                        End If
                        If Not IsDBNull(sqlreader.Item("tgl_keluar")) Then
                            DT_Keluar.Text = sqlreader.Item("tgl_keluar")
                        End If
                    End If

                Catch ex As Exception
                    MsgBox("gagal menampilkan tanggal " & ex.Message)
                Finally
                    Cursor.Current = Cursors.Arrow
                    Conn.Close()
                End Try
                End If
        End With
    End Sub

    Private Sub grid_karyawan_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grid_karyawan.CellMouseUp
        With grid_karyawan
            If e.Button = MouseButtons.Right Then
                If .Rows.Count > 1 Then
                    .ContextMenuStrip = ContextMenuStrip1
                    rowindex = .CurrentRow.Index
                    Me.ContextMenuStrip1.Show(Me.grid_karyawan, e.Location)
                    Me.ContextMenuStrip1.Show(Cursor.Position)
                Else
                    .ContextMenuStrip = Nothing
                End If
            End If
        End With
    End Sub


    Private Sub UpdateDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateDataToolStripMenuItem.Click
        With grid_karyawan
            If IsDBNull(.Rows(rowindex).Cells(4).Value) = False Then
                If .Rows(rowindex).Cells(4).Value = "Percobaan" Then
                    Text_nik.Text = .Rows(rowindex).Cells(0).Value
                    Text_nama.Text = .Rows(rowindex).Cells(1).Value
                    Combo_departemen.Text = .Rows(rowindex).Cells(2).Value
                    Combo_atasan.Text = .Rows(rowindex).Cells(5).Value
                    combo_jbt.Text = .Rows(rowindex).Cells(3).Value
                    Combo_status.Text = .Rows(rowindex).Cells(4).Value
                    Try
                        clear_command()
                        openDB()
                        sql = "SELECT nik, tgl_masuk_rec, tgl_kontrak, tgl_tetap, tgl_keluar, jabatan, " & _
                            "periode_awal, periode_akhir, no_urut, status_karyawan FROM view_jabatankaryawan " & _
                            "where nik = '" & Text_nik.Text & "'"
                        sqlcmd = New SqlCommand(sql, Conn)
                        sqlreader = sqlcmd.ExecuteReader
                        If sqlreader.Read Then
                            no_urut = sqlreader.Item("no_urut")
                            If IsDBNull(sqlreader.Item("tgl_masuk_rec")) = False Then
                                DT_masukrec.Text = sqlreader.Item("tgl_masuk_rec")
                            End If
                            If IsDBNull(sqlreader.Item("tgl_kontrak")) = False Then
                                DT_kontrak.Text = sqlreader.Item("tgl_kontrak")
                            End If
                            If IsDBNull(sqlreader.Item("tgl_tetap")) = False Then
                                DT_tetap.Text = sqlreader.Item("tgl_tetap")
                            End If
                            If IsDBNull(sqlreader.Item("tgl_keluar")) = False Then
                                DT_Keluar.Text = sqlreader.Item("tgl_keluar")
                            End If
                        End If
                        sqlreader.Close()
                    Catch Ex As Exception
                        MsgBox("gagal menampilkan data tanggal kerja " & Ex.Message, MsgBoxStyle.Information, "INFO")
                    End Try
                Else
                End If
            End If
        End With
    End Sub

    Private Sub DT_tglawal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_tglawal.ValueChanged
        format_tanggal(DT_tglawal)
    End Sub

    Private Sub DT_tglakhir_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        format_tanggal(DT_tglakhir)
    End Sub

    Private Sub grid_karyawan_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_karyawan.CellContentClick

    End Sub

    Private Sub LihatDetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LihatDetailToolStripMenuItem.Click
        With FormDetail_Pegawai
            .Show()
            .MdiParent = FormMenuUtama
            .WindowState = FormWindowState.Maximized
        End With
    End Sub

    Private Sub Combo_depart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_depart.SelectedIndexChanged
        load_gridkaryawan("Departemen")
    End Sub

    Private Sub Text_pencarian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_pencarian.TextChanged
        load_gridkaryawan("Pencarian")
    End Sub

    Private Sub Button_baru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_baru.Click
        hapus()
        reload()
    End Sub

    Private Sub DT_tetap_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_tetap.ValueChanged
        format_tanggal(DT_tetap)
    End Sub

    Private Sub DT_Keluar_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_Keluar.ValueChanged
        format_tanggal(DT_Keluar)
    End Sub

    Private Sub DT_kontrak_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_kontrak.ValueChanged
        format_tanggal(DT_kontrak)
    End Sub

    Private Sub DT_tglakhir_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_tglakhir.ValueChanged
        format_tanggal(DT_tglakhir)
    End Sub


    Private Sub FormDTJabatan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_combobox()
        load_gridkaryawan(Nothing)
        clear_date(Me, Groupjabatan)
        clear_date(Me, Groupmasuk)
        load_combo(Combo_depart, "departemen", "tbl_jabatan")
        fill_combo(Combo_atasan, "atasan", "tbl_jabatan")
        fill_combo(combo_jbt, "jabatan", "tbl_jabatan")
        fill_combo(Combo_departemen, "departemen", "tbl_jabatan")
        'fill_combo(Combo_status, "status_karyawan", "view_dtpegawai")
        'Isi_combostatus_kary(Combo_status)
        Application.CurrentCulture = New CultureInfo("id-ID")
    End Sub

    Private Sub Combo_status_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_status.SelectedIndexChanged

    End Sub

    Private Sub Check_harian_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class