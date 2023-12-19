Imports System.IO
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports VB = Microsoft.VisualBasic.Strings
Imports System.Globalization

Public Class FormMutasi
    Private MenuMutasi As String = "MutasiKaryawan"
    Private DtTabel As DataTable
    Private NoKTP As String

    Private Sub FormMutasi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fill_combo(combo_dept, "departemen", "tbl_jabatan")
        fill_combo(ComboJabBaru, "jabatan", "tbl_jabatan")
        fill_combo(ComboDeptBaru, "departemen", "tbl_jabatan")
        fill_combo(ComboAtasan, "atasan", "tbl_jabatan")
        fill_combo(ComboStatusBaru, "status_karyawan", "tbl_jabatan")
        IsiJenisComboKary()
        format_tanggal_kosong(DTMutasi)
        format_tanggal_kosong(DTAkhir)
    End Sub

    Private Sub IsiJenisComboKary()
        With ComboKary.Items
            .Add("KARYAWAN")
            .Add("HARIAN")
        End With
    End Sub

    Private Function Simpan_TblMutasi(ByVal IdMutasi As String) As Boolean
        Dim tanggal As Object = GetDateTimePickerValue(DTMutasi)
        Try
            Dim NikLama = CekNIKLama()
            clear_command()
            openDB()
            sql = "INSERT INTO tbl_mutasi( idmutasi, nik, depart_awal, depart_akhir, jabatan_awal, " & _
                "jabatan_akhir, tgl_mutasi, atasan, ket, no_ktp, nik_lama) " & _
                "VALUES(@idmutasi, @nik, @depart_awal, @depart_akhir, @jabatan_awal, @jabatan_akhir, " & _
                "@tgl_mutasi, @atasan, @ket, @no_ktp, @nik_lama)"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@idmutasi", SqlDbType.VarChar).Value = IdMutasi
                .Add("@NIK", SqlDbType.VarChar).Value = TextNikBaru.Text
                .Add("@depart_awal", SqlDbType.VarChar).Value = TextDeptLama.Text
                .Add("@depart_akhir", SqlDbType.VarChar).Value = ComboDeptBaru.Text
                .Add("@jabatan_awal", SqlDbType.VarChar).Value = TextJabLama.Text
                .Add("@jabatan_akhir", SqlDbType.VarChar).Value = ComboJabBaru.Text
                .Add("@tgl_mutasi", SqlDbType.Date).Value = tanggal.ToString
                .Add("@atasan", SqlDbType.VarChar).Value = ComboAtasan.Text
                .Add("@ket", SqlDbType.VarChar).Value = TextKet.Text
                .Add("@no_ktp", SqlDbType.VarChar).Value = NoKTP
                .Add("@nik_lama", SqlDbType.VarChar).Value = NikLama
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
            'MsgBox("Data telah berhasil di simpan", MsgBoxStyle.Information, "INFO")
        Catch ex As Exception
            MsgBox("Gagal dalam menyimpan data tabel mutasi" & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
        End Try
    End Function

    Private Function CekNIKLama() As String
        Try
            clear_command()
            openDB()
            sql = "select TOP(1) nik_lama, no_urut FROM tbl_jabatan WHERE nik_lama = '" & TextNikLama.Text & "'  ORDER BY no_urut DESC"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                Return sqlreader.Item("nik_lama")
            Else
                Return TextNikLama.Text
            End If
        Catch ex As Exception
            MsgBox("Gagal dalam pencarian id " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
        End Try
    End Function

    'Simpan pergantian NIK
    Private Function UpdateNIK() As Boolean
        If CheckHarian.Checked = True Then
            If SimpanUpdateNIK(TextNikLama.Text, "tbl_pegawai") = True And
                SimpanUpdateNIK(TextNikLama.Text, "tbl_istri") = True And
                SimpanUpdateNIK(TextNikLama.Text, "tbl_anak") = True And
                SimpanUpdateNIK(TextNikLama.Text, "tbl_photopegawai") = True And
                SimpanUpdateNIK(TextNikLama.Text, "tbl_riwayatKes") = True Then
                Return True
            Else
                Return False
            End If
        Else
            If SimpanUpdateNIK(TextNikLama.Text, "tbl_pegawai") = True And
            SimpanUpdateNIK(TextNikLama.Text, "tbl_istri") = True And
            SimpanUpdateNIK(TextNikLama.Text, "tbl_anak") = True And
            SimpanUpdateNIK(TextNikLama.Text, "tbl_photopegawai") = True And
            SimpanUpdateNIK(TextNikLama.Text, "tbl_riwayatKes") = True And
            SimpanUpdateNIK(TextNikLama.Text, "tbl_catatan") = True And
            SimpanUpdateNIK(TextNikLama.Text, "tbl_cuti") = True And
            SimpanUpdateNIK(TextNikLama.Text, "tbl_dataabsen") = True And
            SimpanUpdateNIK(TextNikLama.Text, "tbl_dinas") = True And
            SimpanUpdateNIK(TextNikLama.Text, "tbl_ijin") = True And
            SimpanUpdateNIK(TextNikLama.Text, "tbl_rawabsen") = True And
            SimpanUpdateNIK(TextNikLama.Text, "tbl_rekapkerja") = True And
            SimpanUpdateNIK(TextNikLama.Text, "tbl_statuscuti") = True And
            SimpanUpdateNIK(TextNikLama.Text, "tbl_statusijin") = True And
            SimpanUpdateNIK(TextNikLama.Text, "tbl_statuskerja") = True And
            SimpanUpdateNIK(TextNikLama.Text, "tbl_tanggalkerja") = True And
            SimpanUpdateNIK(TextNikLama.Text, "tbl_telat") = True Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    'simpan perubahan setelah melakukan pergantian NIK
    Private Function SimpanUpdateNIK(ByVal nik As String, ByVal tabel As String) As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "UPDATE " & tabel & " SET nik = @new_nik WHERE nik = @nik"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = nik
            sqlcmd.Parameters.Add("@new_nik", SqlDbType.VarChar).Value = TextNikBaru.Text
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam update data tabel " & tabel & " " & ex.Message)
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function SimpanTblJabatan(ByVal NoUrut As String) As Boolean
        Dim NIKLama = CekNIKLama()
        'Dim TglAkhir As Object = GetDateTimePickerValue(DTMutasi)
        Try
            clear_command()
            openDB()
            sql = "INSERT INTO tbl_jabatan(nik, departemen, jabatan, status_karyawan, no_urut, tgl_awal, tgl_akhir, atasan, nik_lama) " & _
                "VALUES(@nik, @departemen, @jabatan, @status_karyawan, @no_urut, @tgl_awal, @tgl_akhir, @atasan, @nik_lama)"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@no_urut", SqlDbType.VarChar).Value = NoUrut
                .Add("@NIK", SqlDbType.VarChar).Value = TextNikBaru.Text
                .Add("@departemen", SqlDbType.VarChar).Value = ComboDeptBaru.Text
                .Add("@jabatan", SqlDbType.VarChar).Value = ComboJabBaru.Text
                .Add("@status_karyawan", SqlDbType.VarChar).Value = ComboStatusBaru.Text
                .Add("@tgl_awal", SqlDbType.Date).Value = DTMutasi.Text
                If DTAkhir.Text = " " Or IsNothing(DTAkhir.Text) Then
                    .Add("@tgl_akhir", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tgl_akhir", SqlDbType.Date).Value = DTAkhir.Text
                End If
                .Add("@atasan", SqlDbType.VarChar).Value = ComboAtasan.Text
                .Add("@nik_lama", SqlDbType.VarChar).Value = NIKLama
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
            'MsgBox("Data telah berhasil di simpan", MsgBoxStyle.Information, "INFO")
        Catch ex As Exception
            MsgBox("Gagal dalam menyimpan data tabel jabatan " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
        End Try
    End Function

    Private Function SimpanTglKerja() As Boolean
        Try
            clear_command()
            openDB()
            sql = "INSERT INTO tbl_tanggalkerja(nik, tgl_masuk_rec, tgl_masuk_harian, tgl_kontrak, tgl_tetap, tgl_keluar, tgl_borongan) " & _
                "VALUES(@nik, @tgl_masuk_rec, @tgl_masuk_harian, @tgl_kontrak, @tgl_tetap, @tgl_keluar, @tgl_borongan)"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@NIK", SqlDbType.VarChar).Value = TextNikBaru.Text
                .Add("@tgl_masuk_rec", SqlDbType.Date).Value = DBNull.Value
                If DTMutasi.Text = " " Or DTMutasi.Text = String.Empty Then
                    .Add("@tgl_masuk_harian", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tgl_masuk_harian", SqlDbType.Date).Value = DTMutasi.Text
                End If
                .Add("@tgl_kontrak", SqlDbType.Date).Value = DBNull.Value
                .Add("@tgl_tetap", SqlDbType.Date).Value = DBNull.Value
                If DTAkhir.Text = " " Or IsNothing(DTAkhir.Text) Then
                    .Add("@tgl_keluar", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tgl_keluar", SqlDbType.Date).Value = DTAkhir.Text
                End If
                .Add("@tgl_borongan", SqlDbType.Date).Value = DBNull.Value
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
            'MsgBox("Data telah berhasil di simpan", MsgBoxStyle.Information, "INFO")
        Catch ex As Exception
            MsgBox("Gagal dalam menyimpan data tabel tanggal kerja harian " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
        End Try
    End Function

    

    Private Sub UpdateAtasan()
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "UPDATE tbl_jabatan SET atasan=@atasan WHERE departemen=@departemen"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@atasan", SqlDbType.VarChar).Value = TextNamaAtsBaru.Text
                .Add("@departemen", SqlDbType.VarChar).Value = ComboDepAtsBaru.Text
            End With
            sqlcmd.ExecuteNonQuery()
            MsgBox("Pergantian atasan telah berhasil di update", MsgBoxStyle.Information, "INFO")
            ClearField()
        Catch ex As Exception
            Cursor.Current = Cursors.Arrow
            MsgBox("Gagal dalam menyimpan data " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Cursor.Current = Cursors.Arrow
            Conn.Close()
        End Try
    End Sub

    Private Function GetIdMutasi() As String
        Try
            Dim TempNo As String = check_id("no_ktp", "tbl_mutasi", TextNikBaru.Text, Nothing, "idmutasi")
            If TempNo IsNot Nothing Then
                '100460-001'
                Dim temp$ = (CInt(VB.Right(TempNo, 3)) + 1).ToString
                Return VB.Left(TempNo, 16) & "-" & VB.Right("00" & temp, 3)
            Else
                Return NoKTP & "-001"
            End If
        Catch ex As Exception
            MsgBox("Gagal dalam pembuatan id mutasi " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return Nothing
        End Try
    End Function

    Private Function GetNoUrut() As String
        Try
            Dim NIKLama$ = CekNIKLama()
            Dim Temp$ = check_id("NIK", "tbl_jabatan", NIKLama, Nothing, "no_urut")
            If Temp IsNot Nothing Then
                '100460-0001
                Return NIKLama & "-" & VB.Right("000" & (CInt(VB.Right(Temp, 4)) + 1).ToString, 4)
            Else
                Return NIKLama & "-0001"
            End If
        Catch ex As Exception
            MsgBox("gagal dalam pencarian data no urut " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return Nothing
        End Try
    End Function

    Private Sub DTMutasi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        format_tanggal(DTMutasi)
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.SelectedTab Is TabMutasiKary Then
            MenuMutasi = "MutasiKaryawan"
        ElseIf TabControl1.SelectedTab Is TabGantiAtasan Then
            MenuMutasi = "MutasiAtasan"
            fill_combo(ComboDepAtsBaru, "departemen", "tbl_jabatan")
            fill_combo(ComboJabAtsBaru, "jabatan", "tbl_jabatan")
        End If
    End Sub

    Private Sub UpdateUI()
        If Me.InvokeRequired Then
            Me.Invoke(New Action(AddressOf UpdateUI))
        Else
            ' Kode untuk memperbarui antarmuka pengguna di sini
            ' Misalnya, menampilkan stopwatch timer
        End If
    End Sub

    Private Sub EnableButton(ByVal enable As Boolean)
        If BSimpanAts.InvokeRequired Then
            BSimpanAts.Invoke(Sub() EnableButton(enable))
        Else
            BSimpanAts.Enabled = enable
        End If
    End Sub

    Private Sub Tampillabel(ByVal Label_ As Label, ByVal tampil As Boolean)
        If Label_.InvokeRequired Then
            Label_.Invoke(Sub() Tampillabel(Label_, tampil))
        Else
            Label_.Visible = True
        End If
    End Sub


    Private Function GetDeptValue() As String
        If ComboDepAtsBaru.InvokeRequired Then
            Return ComboDepAtsBaru.Invoke(Sub() GetDeptValue())
        Else
            Return ComboDepAtsBaru.Text
        End If
    End Function

    Private Function GetTxtValue() As String
        If TextNamaAtsBaru.InvokeRequired Then
            Return TextNamaAtsBaru.Invoke(Sub() GetTxtValue())
        Else
            Return TextNamaAtsBaru.Text
        End If
    End Function

    Private Sub LoadGridKaryawan(ByVal Pilihan As String, ByVal JnsKary As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            Select Case JnsKary
                Case "KARYAWAN"
                    Select Case Pilihan
                        Case String.Empty
                            sql = "SELECT nik, nama, departemen, jabatan, status_karyawan, atasan, no_ktp FROM  view_pegawai " & _
                                "WHERE status_karyawan <> 'Keluar' OR status_karyawan <>'Harian Sementara'"
                        Case "departemen"
                            sql = "SELECT * FROM (SELECT nik, nama, departemen, jabatan, status_karyawan, atasan, no_ktp FROM  view_pegawai WHERE " & _
                                "status_karyawan <> 'Keluar' OR status_karyawan <> 'Harian Sementara') AS Temp " & _
                                "WHERE  Temp.departemen = '" & combo_dept.Text & "'"
                        Case "pencarian"
                            sql = "SELECT * FROM (SELECT nik, nama, departemen, jabatan, status_karyawan, atasan, no_ktp FROM  view_pegawai WHERE " & _
                                "status_karyawan <> 'Keluar' OR status_karyawan <> 'Harian Sementara') AS Temp " & _
                                "WHERE  Temp.nik  LIKE '%" & Text_pencarian.Text & "%' OR Temp.nama LIKE '%" & Text_pencarian.Text & "%'"
                    End Select
                Case "HARIAN"
                    Select Case Pilihan
                        Case String.Empty
                            sql = "SELECT nik, nama, departemen, jabatan, status_karyawan, atasan, no_ktp FROM  view_pegawai " & _
                                "WHERE status_karyawan LIKE '%Keluar%' OR status_karyawan LIKE '%Harian%'"
                        Case "departemen"
                            sql = "SELECT * FROM (SELECT nik, nama, departemen, jabatan, status_karyawan, atasan, no_ktp FROM  view_pegawai WHERE " & _
                                "status_karyawan LIKE '%Keluar%' OR status_karyawan LIKE '%Harian%') AS Temp " & _
                                "WHERE  Temp.departemen = '" & combo_dept.Text & "'"
                        Case "pencarian"
                            sql = "SELECT * FROM (SELECT nik, nama, departemen, jabatan, status_karyawan, atasan, no_ktp FROM  view_pegawai WHERE " & _
                                "status_karyawan LIKE '%Keluar%' OR status_karyawan LIKE '%Harian%') AS Temp " & _
                                "WHERE  Temp.nik  LIKE '%" & Text_pencarian.Text & "%' OR Temp.nama LIKE '%" & Text_pencarian.Text & "%'"
                    End Select
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            GridTampilData.DataSource = DTab
            atur_grid(GridTampilData)
        Catch ex As Exception
            MsgBox("Gagal menampilkan data daftar karyawan" & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub atur_grid(ByVal grid As DataGridView)
        With grid
            .ReadOnly = True
            .Enabled = True
            .ColumnHeadersVisible = True
            .Columns(0).HeaderText = "NIK"
            .Columns(0).Width = 70
            .Columns(1).HeaderText = "Nama"
            .Columns(1).Width = 150
            .Columns(2).HeaderText = "Departemen"
            .Columns(2).Width = 120
            .Columns(3).HeaderText = "Jabatan"
            .Columns(3).Width = 150
            .Columns(4).HeaderText = "status"
            .Columns(4).Width = 75
            .Columns(5).HeaderText = "Atasan"
            .Columns(5).Width = 100
            .Columns(6).HeaderText = "No KTP"
            .Columns(6).Visible = False
            .RowHeadersWidth = 10
        End With
    End Sub

    Private Sub Text_pencarian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_pencarian.TextChanged
        LoadGridKaryawan("pencarian", ComboKary.Text)
    End Sub

    Private Sub combo_dept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_dept.SelectedIndexChanged
        LoadGridKaryawan("departemen", ComboKary.Text)
    End Sub

    Private Sub GridTampilData_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridTampilData.CellContentDoubleClick

    End Sub

    Private Sub GridTampilData_CellMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GridTampilData.CellMouseDoubleClick
        With GridTampilData
            If MenuMutasi = "MutasiKaryawan" Then
                If .Rows(.CurrentRow.Index).Cells(6).Value = String.Empty Then
                    MsgBox("No KTP belum di input, silahkan input di menu pegawai terlebih dahulu", MsgBoxStyle.Exclamation, "INFO")
                ElseIf Len(.Rows(.CurrentRow.Index).Cells(6).Value).ToString < 16 Then
                    MsgBox("No KTP kurang dari 16 digit, silahkan edit terlebih dahulu", MsgBoxStyle.Exclamation, "INFO")
                Else

                    NoKTP = (.Rows(.CurrentRow.Index).Cells(6).Value).ToString
                    TextNikLama.Text = .Rows(.CurrentRow.Index).Cells(0).Value
                    TextNamaLama.Text = .Rows(.CurrentRow.Index).Cells(1).Value
                    TextDeptLama.Text = .Rows(.CurrentRow.Index).Cells(2).Value
                    TextJabLama.Text = .Rows(.CurrentRow.Index).Cells(3).Value
                    TextStatus.Text = .Rows(.CurrentRow.Index).Cells(4).Value
                    TextNikBaru.Text = .Rows(.CurrentRow.Index).Cells(0).Value
                    TextNamaBaru.Text = .Rows(.CurrentRow.Index).Cells(1).Value
                End If
                
            Else
                TextNIKAtsAwal.Text = .Rows(.CurrentRow.Index).Cells(0).Value
                TextNamaAtsAwal.Text = .Rows(.CurrentRow.Index).Cells(1).Value
                TextDepAtsAwal.Text = .Rows(.CurrentRow.Index).Cells(2).Value
                TextJabAtsAwal.Text = .Rows(.CurrentRow.Index).Cells(3).Value
                TextNIKAtsBaru.Text = .Rows(.CurrentRow.Index).Cells(0).Value
                TextNamaAtsBaru.Text = .Rows(.CurrentRow.Index).Cells(1).Value
            End If
        End With
    End Sub

    Private Sub ClearField()
        CheckHarian.Checked = False
        combo_dept.DataSource = Nothing
        'combo_dept.Items.Clear()
        'ComboKary.Items.Clear()
        ComboKary.Text = String.Empty
        combo_dept.Text = String.Empty
        GridTampilData.DataSource = Nothing
        GridTampilData.Refresh()
        If MenuMutasi = "MutasiKaryawan" Then
            Clear_combo(Me, GroupMutasBaru)
            Clear_text(Me, GroupMutasiAwal)
            Clear_text(Me, GroupMutasBaru)
            DTMutasi.ResetText()
            format_tanggal_kosong(DTMutasi)
            DTAkhir.ResetText()
            format_tanggal_kosong(DTAkhir)
        Else
            Clear_combo(Me, GroupAtasanBaru)
            Clear_text(Me, GroupAtasanAwal)
            Clear_text(Me, GroupAtasanBaru)
        End If
    End Sub

    Private Sub BSimpanAts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSimpanAts.Click
        If TextNIKAtsBaru.Text = String.Empty Then
            MsgBox("Silahkan lengkapi data terlebih dahulu", MsgBoxStyle.Information, "INFO")
        ElseIf TextNamaAtsBaru.Text = String.Empty Then
            MsgBox("Silahkan lengkapi data terlebih dahulu", MsgBoxStyle.Information, "INFO")
        ElseIf ComboDepAtsBaru.Text = String.Empty Then
            MsgBox("Silahkan lengkapi data terlebih dahulu", MsgBoxStyle.Information, "INFO")
        ElseIf ComboJabAtsBaru.Text = String.Empty Then
            MsgBox("Silahkan lengkapi data terlebih dahulu", MsgBoxStyle.Information, "INFO")
        Else
            If MsgBox("Apakah data siap untuk disimpan ? ", vbOKCancel, "INFO") = vbOK Then
                UpdateAtasan()
            End If
        End If
    End Sub

    Private Sub BSimpanMutasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSimpanMutasi.Click
        Try
            Cursor.Current = Cursors.WaitCursor
            If TextNikBaru.Text = String.Empty Then
                MsgBox("Silahkan lengkapi data terlebih dahulu", MsgBoxStyle.Information, "INFO")
            ElseIf TextNamaBaru.Text = String.Empty Then
                MsgBox("SIlahkan lengkapi data terlebih dahulu", MsgBoxStyle.Information, "INFO")
            ElseIf ComboDeptBaru.Text = String.Empty Then
                MsgBox("Silahkan lengkapi data terlebih dahulu", MsgBoxStyle.Information, "INFO")
            ElseIf ComboJabBaru.Text = String.Empty Then
                MsgBox("Silahkan lengkapi data terlebih dahulu", MsgBoxStyle.Information, "INFO")
            ElseIf DTMutasi.Text = " " Or IsNothing(DTMutasi.Text) Then
                MsgBox("Tanggal awal tidak boleh kosong", MsgBoxStyle.Exclamation, "INFO")
            ElseIf CheckHarian.Checked = True Then
                If MsgBox("apakah data karyawan harian dengan NIK baru siap disimpan?", vbOKCancel, "INFO") = vbOK Then
                    If Simpan_TblMutasi(GetIdMutasi()) = True And SimpanTblJabatan(GetNoUrut()) = True _
                            And UpdateNIK() = True And SimpanTglKerja() = True Then
                        MsgBox("data telah berhasil disimpan", MsgBoxStyle.Information, "INFO")
                        ClearField()
                    End If
                End If
            ElseIf checking_data("nik", "view_dtpegawai", TextNikBaru.Text, Nothing) = True Then
                If MsgBox("NIK sudah digunakan, Simpan Data mutasi tanpa pergantian NIK ?", MsgBoxStyle.OkCancel, "INFO") = vbOK Then
                    If Simpan_TblMutasi(GetIdMutasi()) = True And SimpanTblJabatan(GetNoUrut()) = True Then
                        MsgBox("data telah berhasil disimpan", MsgBoxStyle.Information, "INFO")
                        ClearField()
                    End If
                End If
            Else
                If MsgBox("apakah data siap disimpan?", vbOKCancel, "INFO") = vbOK Then
                    If Simpan_TblMutasi(GetIdMutasi()) = True And SimpanTblJabatan(GetNoUrut()) = True _
                            And UpdateNIK() = True Then
                        MsgBox("data telah berhasil disimpan", MsgBoxStyle.Information, "INFO")
                        ClearField()
                    End If
                End If
            End If
        Catch ex As Exception
            Cursor.Current = Cursors.Arrow
            MsgBox("gagal dalam proses penyimpanan " & ex.Message, MsgBoxStyle.Information, "INFO")
        End Try
    End Sub



    Private Sub DTMutasi_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTMutasi.ValueChanged
        format_tanggal(DTMutasi)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox(TextNikBaru.Text & " dengan nomor urut = " & check_id("NIK", "tbl_jabatan", TextNikLama.Text, Nothing, "no_urut") & " dan no id mutasi = " & GetIdMutasi())
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox(NoKTP)
    End Sub

    Private Sub GridTampilData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridTampilData.CellContentClick

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox(NoKTP)
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim TglAwal As Object = GetDateTimePickerValue(DTMutasi)
        MsgBox(TglAwal.ToString)
    End Sub


    Private Sub ComboStatusBaru_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboStatusBaru.KeyDown
        If e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            DTMutasi.Focus()
        End If
    End Sub

    Private Sub ComboStatusBaru_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ComboStatusBaru.MouseDoubleClick
        If ComboStatusBaru.Text = "Kontrak" Or " kontrak" Then
            LabelSampai.Visible = True
            DTAkhir.Visible = True
        Else
            LabelSampai.Visible = False
            DTAkhir.Visible = False
        End If
    End Sub


    Private Sub ComboStatusBaru_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboStatusBaru.SelectedIndexChanged
        If ComboStatusBaru.Text = "Kontrak" Or " kontrak" Then
            LabelSampai.Visible = True
            DTAkhir.Visible = True
        Else
            LabelSampai.Visible = False
            DTAkhir.Visible = False
        End If
    End Sub

    Private Sub DTAkhir_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTAkhir.ValueChanged
        format_tanggal(DTAkhir)
    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("nilai tangal adalah = " & DTAkhir.Text & "dan untuk tanggal awal adalah = " & DTMutasi.Text)
    End Sub

    Private Sub ComboJabBaru_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboJabBaru.KeyDown
        If e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            ComboDeptBaru.Focus()
        End If
    End Sub

    Private Sub ComboJabBaru_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboJabBaru.SelectedIndexChanged

    End Sub

    Private Sub ComboDeptBaru_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboDeptBaru.KeyDown
        If e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            ComboAtasan.Focus()
        End If
    End Sub

    Private Sub ComboAtasan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboAtasan.KeyDown
        If e.KeyCode = Keys.Tab Then
            e.SuppressKeyPress = True
            ComboStatusBaru.Focus()
        End If
    End Sub

    Private Sub ComboKary_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboKary.SelectedIndexChanged
        If Not ComboKary.Text = String.Empty Then
            LoadGridKaryawan(Nothing, ComboKary.Text)
        End If
    End Sub
End Class