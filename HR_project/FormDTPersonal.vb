Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports System.Globalization

Public Class FormDTPersonal
    Dim OpenFile As OpenFileDialog
    Dim Ms() As MemoryStream
    Dim rowindex, num As Integer
    Dim no_nik As String

    Private id_anak, id_status, status_data As String
    Private StrImageName As String
    Private ImageBytes As Byte = Nothing
    Private filesize As UInt32
    Private rawDataPict() As Byte
    Private fsPict As FileStream
    Private Fs As FileStream


    Private Sub Button_buka_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_buka.Click
        'Menampilkan dialog form untuk mencari gambar di komputer
        Try
            Pict_photo.Image = Nothing
            OpenFile = New OpenFileDialog
            OpenFile.Filter = "JBitmaps(*.bmp)|*.bmp|GIF images(*.gif)|*.gif" _
            + "|JPEG images(*.jpg)|*.jpg"
            OpenFile.FilterIndex = 1
            If OpenFile.ShowDialog = Windows.Forms.DialogResult.OK Then
                StrImageName = OpenFile.FileName

                'Picture_box.SizeMode = PictureBoxSizeMode.AutoSize
                Pict_photo.Image = Image.FromFile(StrImageName)

            Else
                StrImageName = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error Menampilkan Photo", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub saving_pict(ByVal StrImageName As String)
        fsPict = New FileStream(StrImageName, FileMode.Open, FileAccess.Read)
        filesize = fsPict.Length
        rawDataPict = New Byte(filesize) {}
        fsPict.Read(rawDataPict, 0, filesize)
        fsPict.Close()
    End Sub

    Private Function check_data(ByVal _field$, ByVal _table$, ByVal _text$) As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "select " & _field & " from " & _table & " where " & _field & " = '" & _text & "'"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("Gagal dalam pencarian data" & ex.Message)
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Sub hapus_table(ByVal _field$, ByVal _table$, ByVal _value$)
        Try
            clear_command()
            openDB()
            sql = "delete from " & _table & " where " & _field & " = '" & _value & "'"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("gagal dalam penghapusan data " & ex.Message, MsgBoxStyle.Information, "INFO")
        End Try
    End Sub

    Private Sub Button_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_simpan.Click
        If text_nik.Text = String.Empty Then
            MsgBox("NIK tidak boleh kosong", MsgBoxStyle.Critical, "INFO")
        ElseIf text_nama.Text = String.Empty Then
            MsgBox("Nama tidak boleh kosong", MsgBoxStyle.Critical, "INFO")
        ElseIf Text_ktp.Text = String.Empty Then
            MsgBox("No KTP tidak boleh kosong", MsgBoxStyle.Information, "INFO")
        ElseIf (Text_ktp.Text).Length < 16 Then
            MsgBox("NO KTP wajib 16 digit angka", MsgBoxStyle.Exclamation, "INFO")
        ElseIf check_data("nik", "tbl_pegawai", text_nik.Text) = True Then
            If MsgBox("Data telah ada simpan sebagai edit data ? ", MsgBoxStyle.OkCancel, "INFO") = MsgBoxResult.Ok Then
                'simpan update dt pegawai
                Try
                    update_pegawai()

                    If check_data("nik", "tbl_istri", text_nik.Text) = True Then
                        update_dtistri()
                    Else
                        simpan_dtistri()
                    End If
                    If check_data("nik", "tbl_anak", text_nik.Text) = True Then
                        'update dt anak
                        update_dtanak(grid_anak)
                    Else
                        simpan_dtanak()
                    End If
                    If check_data("nik", "tbl_riwayatkes", text_nik.Text) = True Then
                        'update dt riwayat kesehatan
                        update_dtriwayat()
                    Else
                        simpan_riwayat()
                    End If
                    If check_data("nik", "tbl_photopegawai", text_nik.Text) = True Then
                        'update dt photo
                        update_foto()
                    Else
                        'simpan dt photo
                        simpan_foto()
                    End If
                Catch ex As Exception

                Finally
                    MsgBox("Data telah berhasi di update ", MsgBoxStyle.Information, "INFO")
                    hapus()
                End Try

            Else
                text_nik.Focus()
            End If
        Else
            If MsgBox("Apakah data siap disimpan ? ", MsgBoxStyle.Information & MsgBoxStyle.OkCancel, "INFO") = MsgBoxResult.Ok Then

                Try
                    openDB()
                    'simpan data di tbl_pegawai
                    simpan_dtpegawai()

                    'simpan data di tabel tbl_istri
                    simpan_dtistri()

                    'smipan data di tbl_anak
                    simpan_dtanak()

                    'simpan data di tbl_photopegawai
                    simpan_foto()

                    'simpan data riwayat kesehatan
                    simpan_riwayat()
                Catch ex As Exception
                    MsgBox("Data gagal disimpan " & ex.Message, MsgBoxStyle.Critical, "INFO")
                Finally
                    MsgBox("Data telah berhasil di simpan", MsgBoxStyle.Information, "INFO")
                    hapus()
                End Try
            Else
                text_nama.Focus()
            End If
        End If
    End Sub

    Private Function simpan_dtpegawai() As Boolean  'simpan data di tabel tbl_pegawai
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "insert into tbl_pegawai(nik, nama, no_kk, no_ktp, tempat_lahir, tgl_lahir, agama, sex, " & _
                        "pendidikan, alamat_asal, rt_asal, rw_asal, desa_asal, kec_asal, kab_asal, kdpos_asal, " & _
                        "alamat_dom, rt_dom, rw_dom, desa_dom, kec_dom, kab_dom, kdpos_dom, no_telp, email, " & _
                        "status_kawin, faskes_tk1, faskes_gigi, kerabat, telp_kerabat) " & _
                        "values(@nik, @nama, @no_kk, @no_ktp, @tempat_lahir, @tgl_lahir, @agama, @sex, " & _
                        "@pendidikan, @alamat_asal, @rt_asal, @rw_asal, @desa_asal, @kec_asal, @kab_asal, @kdpos_asal, " & _
                        "@alamat_dom, @rt_dom, @rw_dom, @desa_dom, @kec_dom, @kab_dom, @kdpos_dom, @no_telp, @email, " & _
                        "@status_kawin, @faskes_tk1, @faskes_gigi, @kerabat, @telp_kerabat)"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = text_nik.Text
                .Add("@nama", SqlDbType.VarChar).Value = text_nama.Text
                .Add("@no_kk", SqlDbType.VarChar).Value = Text_kk.Text
                .Add("@no_ktp", SqlDbType.VarChar).Value = Text_ktp.Text
                .Add("@tempat_lahir", SqlDbType.VarChar).Value = Text_tlahir.Text
                If DT_lahir.Text = " " Then
                    .Add("@tgl_lahir", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tgl_lahir", SqlDbType.Date).Value = DT_lahir.Text
                End If
                .Add("@agama", SqlDbType.VarChar).Value = Combo_agama.Text
                .Add("@sex", SqlDbType.VarChar).Value = Combo_jeniskel.Text
                .Add("@pendidikan", SqlDbType.VarChar).Value = Combo_pend.Text
                .Add("@alamat_asal", SqlDbType.VarChar).Value = Text_alamatk.Text
                .Add("@rt_asal", SqlDbType.VarChar).Value = Text_rtk.Text
                .Add("@rw_asal", SqlDbType.VarChar).Value = Text_rwk.Text
                .Add("@desa_asal", SqlDbType.VarChar).Value = Combo_desaK.Text
                .Add("@kec_asal", SqlDbType.VarChar).Value = Combo_kecK.Text
                .Add("@kab_asal", SqlDbType.VarChar).Value = Combo_kabK.Text
                .Add("@kdpos_asal", SqlDbType.VarChar).Value = Combo_kodeposK.Text
                .Add("@alamat_dom", SqlDbType.VarChar).Value = Text_alamatd.Text
                .Add("@rt_dom", SqlDbType.VarChar).Value = Text_rtd.Text
                .Add("@rw_dom", SqlDbType.VarChar).Value = Text_rwd.Text
                .Add("@desa_dom", SqlDbType.VarChar).Value = Combo_desaD.Text
                .Add("@kec_dom", SqlDbType.VarChar).Value = Combo_kecD.Text
                .Add("@kab_dom", SqlDbType.VarChar).Value = Combo_kabD.Text
                .Add("@kdpos_dom", SqlDbType.VarChar).Value = Combo_kodeD.Text
                .Add("@no_telp", SqlDbType.VarChar).Value = Text_telp.Text
                .Add("@email", SqlDbType.VarChar).Value = Text_email.Text
                .Add("@status_kawin", SqlDbType.VarChar).Value = Combo_kawin.Text
                .Add("@faskes_tk1", SqlDbType.VarChar).Value = Text_faskestk.Text
                .Add("@faskes_gigi", SqlDbType.VarChar).Value = Text_faskesgg.Text
                .Add("@kerabat", SqlDbType.VarChar).Value = Text_kerabat.Text
                .Add("@telp_kerabat", SqlDbType.VarChar).Value = Text_telpkerabat.Text
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("gagal melakukan penyimpanan data personal " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function simpan_dtanak() As Boolean
        If grid_anak.RowCount > 1 Then
            Try
                Cursor.Current = Cursors.WaitCursor
                clear_command()
                openDB()
                With grid_anak

                    For baris = 0 To .RowCount - 2
                        sql = "insert into tbl_anak(nik, id_anak, nama, no_ktp, tempat_lahir, tgl_lahir) " & _
                            "values(@nik, @id_anak, @nama, @no_ktp, @tempat_lahir, @tgl_lahir)"
                        sqlcmd = New SqlCommand(sql, Conn)
                        With sqlcmd.Parameters
                            .Add("@nik", SqlDbType.VarChar).Value = text_nik.Text
                            .Add("@id_anak", SqlDbType.VarChar).Value = grid_anak.Rows(baris).Cells(1).Value
                            .Add("@nama", SqlDbType.VarChar).Value = grid_anak.Rows(baris).Cells(2).Value
                            .Add("@no_ktp", SqlDbType.VarChar).Value = grid_anak.Rows(baris).Cells(5).Value
                            .Add("@tempat_lahir", SqlDbType.VarChar).Value = grid_anak.Rows(baris).Cells(3).Value
                            If grid_anak.Rows(baris).Cells(4).Value = " " Then
                                .Add("@tgl_lahir", SqlDbType.Date).Value = DBNull.Value
                            Else
                                .Add("@tgl_lahir", SqlDbType.Date).Value = CDate(grid_anak.Rows(baris).Cells(4).Value)
                            End If
                        End With
                        sqlcmd.ExecuteNonQuery()
                        Return True
                    Next
                End With
            Catch ex As Exception
                MsgBox("gagal dalam penyimpanan data anak " & ex.Message, MsgBoxStyle.Information, "INFO")
                Return False
            Finally
                Conn.Close()
            End Try
        End If
    End Function

    Private Function simpan_dtistri() As Boolean
        If Not Text_namapas.Text = String.Empty Then
            Try
                Cursor.Current = Cursors.WaitCursor
                clear_command()
                openDB()
                sql = "insert into tbl_istri(nik, nama, no_ktp, tempat_lahir, tgl_lahir) " & _
                    "values(@nik, @nama, @no_ktp, @tempat_lahir, @tgl_lahir)"
                sqlcmd = New SqlCommand(sql, Conn)
                With sqlcmd.Parameters
                    .Add("@nik", SqlDbType.VarChar).Value = text_nik.Text
                    .Add("@nama", SqlDbType.VarChar).Value = Text_namapas.Text
                    .Add("@no_ktp", SqlDbType.VarChar).Value = Text_ktppas.Text
                    .Add("@tempat_lahir", SqlDbType.VarChar).Value = Text_tlahirpas.Text
                    If DT_lahirpas.Text = " " Then
                        .Add("@tgl_lahir", SqlDbType.Date).Value = DBNull.Value
                    Else
                        .Add("@tgl_lahir", SqlDbType.Date).Value = DT_lahirpas.Text
                    End If
                End With
                sqlcmd.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                MsgBox("gagal dalam penyimpanan data istri " & ex.Message, MsgBoxStyle.Information, "INFO")
                Return False
            Finally
                Conn.Close()
                Cursor.Current = Cursors.Default
            End Try
        End If
    End Function

    Private Function simpan_foto() As Boolean
        If Pict_photo.Image IsNot Nothing Then
            saving_pict(StrImageName)
            Try
                Cursor.Current = Cursors.WaitCursor
                clear_command()
                openDB()
                sql = "insert into tbl_photopegawai(nik, nama_photo, photo) values(@nik, @nama_photo, @photo)"
                sqlcmd = New SqlCommand(sql, Conn)
                With sqlcmd.Parameters
                    .Add("@nik", SqlDbType.VarChar).Value = text_nik.Text
                    .Add("nama_photo", SqlDbType.VarChar).Value = "img-" & text_nik.Text
                    .Add("@photo", SqlDbType.Image).Value = rawDataPict
                End With
                sqlcmd.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                MsgBox("gagal dalam penyimpanan foto " & ex.Message, MsgBoxStyle.Information, "INFO")
                Return False
            Finally
                Conn.Close()
                Cursor.Current = Cursors.Default
            End Try
        End If
    End Function

    Private Function simpan_riwayat() As Boolean
        If Not Text_riwayat.Text = String.Empty Then
            Try
                Cursor.Current = Cursors.WaitCursor
                clear_command()
                openDB()
                sql = "insert into tbl_riwayatkes(nik, riwayat) values('" & text_nik.Text & "', '" & Text_riwayat.Text & "')"
                sqlcmd = New SqlCommand(sql, Conn)
                sqlcmd.ExecuteNonQuery()
                Return True
            Catch ex As Exception
                MsgBox("Gagal penyimpanan data riwayat kesehatan " & ex.Message, MsgBoxStyle.Information, "INFO")
                Return False
            Finally
                Conn.Close()
                Cursor.Current = Cursors.Default
            End Try
        End If
    End Function

    Private Function update_dtanak(ByVal grid As DataGridView) As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            With grid
                For A% = 0 To grid.RowCount - 2
                    'cek apakah data anak di update tanpa tambah data baru
                    If cari_data(.Rows(A).Cells(0).Value, "tbl_anak", "nik = '" & .Rows(A).Cells(0).Value & "' AND " & _
                               "id_anak = '" & .Rows(A).Cells(1).Value & "'") = True Then
                        'update data tanpa tambah data baru'
                        update_anak(A, grid)
                    Else
                        'update data dengan tambah data baru
                        update_anakbaru(A, grid)
                    End If
                Next A
            End With
            Return True
        Catch ex As Exception
            MsgBox("Gagal melakukan update data anak" & ex.Message)
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Sub update_anak(ByVal baris As Integer, ByVal grid As DataGridView)
        Try
            clear_command()
            openDB()
                sql = "UPDATE tbl_anak SET nama = @nama, tempat_lahir = @tempat_lahir, " & _
                    "tgl_lahir = @tgl_lahir, no_ktp = @no_ktp WHERE id_anak = @id_anak AND nik = @nik"
                sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = grid.Rows(baris).Cells(0).Value
                .Add("@id_anak", SqlDbType.VarChar).Value = grid.Rows(baris).Cells(1).Value
                .Add("@nama", SqlDbType.VarChar).Value = grid.Rows(baris).Cells(2).Value
                .Add("@tempat_lahir", SqlDbType.VarChar).Value = grid.Rows(baris).Cells(3).Value
                .Add("tgl_lahir", SqlDbType.Date).Value = grid.Rows(baris).Cells(4).Value
                .Add("no_ktp", SqlDbType.VarChar).Value = grid.Rows(baris).Cells(5).Value
            End With
                sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("gagal dalam update data anak " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub update_anakbaru(ByVal baris As Integer, ByVal grid As DataGridView)
        Try
            clear_command()
            openDB()
            sql = "INSERT INTO tbl_anak(nik, id_anak, nama, tempat_lahir, tgl_lahir, no_ktp) " & _
                "VALUES(@nik, @id_anak, @nama, @tempat_lahir, @tgl_lahir, @no_ktp)"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = grid.Rows(baris).Cells(0).Value
                .Add("@id_anak", SqlDbType.VarChar).Value = grid.Rows(baris).Cells(1).Value
                .Add("@nama", SqlDbType.VarChar).Value = grid.Rows(baris).Cells(2).Value
                .Add("@tempat_lahir", SqlDbType.VarChar).Value = grid.Rows(baris).Cells(3).Value
                .Add("tgl_lahir", SqlDbType.Date).Value = grid.Rows(baris).Cells(4).Value
                .Add("no_ktp", SqlDbType.VarChar).Value = grid.Rows(baris).Cells(5).Value
            End With
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("gagal dalam update data anak baru " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Function update_dtistri() As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "update tbl_istri set nama = @nama, no_ktp = @no_ktp, " & _
                "tempat_lahir = @tempat_lahir, " & _
                "tgl_lahir = @tgl_lahir " & _
                "where nik = '" & text_nik.Text & "'"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nama", SqlDbType.VarChar).Value = Text_namapas.Text
                .Add("@no_ktp", SqlDbType.VarChar).Value = Text_ktppas.Text
                .Add("@tempat_lahir", SqlDbType.VarChar).Value = Text_tlahirpas.Text
                If DT_lahirpas.Text = " " Then
                    .Add("@tgl_lahir", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tgl_lahir", SqlDbType.Date).Value = DT_lahirpas.Text
                End If
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("gagal update data istri " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
        End Try
    End Function

    Private Function update_pegawai() As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "update tbl_pegawai set nama = @nama , no_kk = @no_kk, no_ktp = @no_ktp , tempat_lahir = @tempat_lahir , " & _
                "tgl_lahir = @tgl_lahir, agama = @agama, sex = @sex, pendidikan = @pendidikan , alamat_asal = @alamat_asal, " & _
                "rt_asal = @rt_asal , rw_asal = @rw_asal , desa_asal = @desa_asal, kec_asal = @kec_asal, kab_asal = @kab_asal , " & _
                "kdpos_asal = @kdpos_asal , alamat_dom = @alamat_dom , rt_dom = @rt_dom , rw_dom = @rw_dom, " & _
                "desa_dom = @desa_dom , kec_dom = @kec_dom , kab_dom = @kab_dom, " & _
                "kdpos_dom = @kdpos_dom, no_telp = @no_telp, email = @email, " & _
                "status_kawin = @status_kawin , faskes_tk1 = @faskes_tk1, " & _
                "faskes_gigi = @faskes_gigi, kerabat = @kerabat, telp_kerabat = @telp_kerabat " & _
                "where nik = '" & text_nik.Text & "'"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nama", SqlDbType.VarChar).Value = text_nama.Text
                .Add("@no_kk", SqlDbType.VarChar).Value = Text_kk.Text
                .Add("@no_ktp", SqlDbType.VarChar).Value = Text_ktp.Text
                .Add("@tempat_lahir", SqlDbType.VarChar).Value = Text_tlahir.Text
                If DT_lahir.Text = " " Then
                    .Add("@tgl_lahir", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tgl_lahir", SqlDbType.Date).Value = DT_lahir.Text
                End If
                .Add("@agama", SqlDbType.VarChar).Value = Combo_agama.Text
                .Add("@sex", SqlDbType.VarChar).Value = Combo_jeniskel.Text
                .Add("@pendidikan", SqlDbType.VarChar).Value = Combo_pend.Text
                .Add("@alamat_asal", SqlDbType.VarChar).Value = Text_alamatk.Text
                .Add("@rt_asal", SqlDbType.VarChar).Value = Text_rtk.Text
                .Add("@rw_asal", SqlDbType.VarChar).Value = Text_rwk.Text
                .Add("@desa_asal", SqlDbType.VarChar).Value = Combo_desaK.Text
                .Add("@kec_asal", SqlDbType.VarChar).Value = Combo_kecK.Text
                .Add("@kab_asal", SqlDbType.VarChar).Value = Combo_kabK.Text
                .Add("@kdpos_asal", SqlDbType.VarChar).Value = Combo_kodeposK.Text
                .Add("@alamat_dom", SqlDbType.VarChar).Value = Text_alamatd.Text
                .Add("@rt_dom", SqlDbType.VarChar).Value = Text_rtd.Text
                .Add("@rw_dom", SqlDbType.VarChar).Value = Text_rwd.Text
                .Add("@desa_dom", SqlDbType.VarChar).Value = Combo_desaD.Text
                .Add("@kec_dom", SqlDbType.VarChar).Value = Combo_kecD.Text
                .Add("@kab_dom", SqlDbType.VarChar).Value = Combo_kabD.Text
                .Add("@kdpos_dom", SqlDbType.VarChar).Value = Combo_kodeD.Text
                .Add("@no_telp", SqlDbType.VarChar).Value = Text_telp.Text
                .Add("@email", SqlDbType.VarChar).Value = Text_email.Text
                .Add("@status_kawin", SqlDbType.VarChar).Value = Combo_kawin.Text
                .Add("@faskes_tk1", SqlDbType.VarChar).Value = Text_faskestk.Text
                .Add("@faskes_gigi", SqlDbType.VarChar).Value = Text_faskesgg.Text
                .Add("@kerabat", SqlDbType.VarChar).Value = Text_kerabat.Text
                .Add("@telp_kerabat", SqlDbType.VarChar).Value = Text_telpkerabat.Text
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam update data pegawai " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function update_foto() As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            If Pict_photo.Image IsNot Nothing Then
                clear_command()
                openDB()
                sql = "update tbl_photopegawai set nama_photo = @nama, photo = @photo where nik = @nik"
                sqlcmd = New SqlCommand(sql, Conn)
                With sqlcmd.Parameters
                    .Add("@nik", SqlDbType.VarChar).Value = text_nik.Text
                    .Add("nama_photo", SqlDbType.VarChar).Value = "img-" & text_nik.Text
                    .Add("@photo", SqlDbType.Image).Value = rawDataPict
                End With
                sqlcmd.ExecuteNonQuery()
            End If
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam update photo " & ex.Message)
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function update_dtriwayat() As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "update tbl_riwayatkes set riwayat = '" & Text_riwayat.Text & "' where nik = '" & text_nik.Text & "'"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal update data riwayat kesehatan " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Sub hapus()
        Clear_text(Me, Group_asal)
        Clear_text(Me, Group_domisili)
        Clear_text(Me, Groupanak)
        Clear_text(Me, Group_pas)
        Clear_text(Me, Group_data)
        Clear_combo(Me, Group_asal)
        Clear_combo(Me, Group_domisili)
        Clear_combo(Me, Groupanak)
        Clear_combo(Me, Group_pas)
        Clear_combo(Me, Group_data)
        Pict_photo.Image = Nothing
        grid_anak.DataSource = Nothing
        grid_anak.Rows.Clear()
        clear_date(Me, Groupanak)
        clear_date(Me, Group_pas)
        clear_date(Me, Group_data)
    End Sub

    Private Sub hapus_fieldanak()
        Text_nmanak.Text = String.Empty
        Text_ktpanak.Text = String.Empty
        Text_tlahiranak.Text = String.Empty
        format_tanggal_kosong(DT_tlahiranak)
    End Sub

    Private Sub atur_gridanak(ByVal status As String)
        With grid_anak
            Select Case status
                Case "baru"
                    .ReadOnly = True
                    .Enabled = True
                    .ColumnCount = 6
                    .ColumnHeadersVisible = True
                    .Columns(0).HeaderText = "NIK"
                    .Columns(0).Width = 80
                    .Columns(1).HeaderText = "ID"
                    .Columns(1).Visible = False
                    .Columns(2).HeaderText = "Nama"
                    .Columns(2).Width = 120
                    .Columns(3).HeaderText = "Tempat Lahir"
                    .Columns(3).Width = 80
                    .Columns(4).HeaderText = "tgl lahir"
                    .Columns(4).Width = 75
                    .Columns(5).HeaderText = "No KTP"
                    .Columns(5).Width = 75
                Case "edit"
                    .ReadOnly = True
                    .Enabled = True
                    .ColumnHeadersVisible = True
                    .Columns(0).HeaderText = "NIK"
                    .Columns(0).Width = 80
                    .Columns(1).HeaderText = "ID"
                    .Columns(1).Visible = False
                    .Columns(2).HeaderText = "Nama"
                    .Columns(2).Width = 120
                    .Columns(3).HeaderText = "Tempat Lahir"
                    .Columns(3).Width = 80
                    .Columns(4).HeaderText = "tgl lahir"
                    .Columns(4).Width = 75
                    .Columns(5).HeaderText = "No KTP"
                    .Columns(5).Width = 75
            End Select
            
        End With
    End Sub

    Private Sub Buttoncopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Buttontambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttontambah.Click
        If nik_global <> String.Empty Then
            If check_data("nik", "tbl_anak", text_nik.Text) = True Then
                Dim row As DataRow
                Dim tgl As String
                row = DTab.NewRow
                ' Add Values to Row here 
                DTab.Rows.Add(row)
                grid_anak.DataSource = DTab
                atur_gridanak("edit")
                grid_anak.Refresh()
                With grid_anak
                    If id_status <> "edit" Then
                        id_anak = (.RowCount - 2) + 1
                    End If
                    .Rows(.RowCount - 2).Cells(0).Value = text_nik.Text
                    .Rows(.RowCount - 2).Cells(1).Value = id_anak
                    .Rows(.RowCount - 2).Cells(2).Value = Text_nmanak.Text
                    .Rows(.RowCount - 2).Cells(3).Value = Text_tlahiranak.Text
                    .Rows(.RowCount - 2).Cells(5).Value = Text_ktpanak.Text
                    .Rows(.RowCount - 2).Cells(4).Value = CDate((Format(CDate(DT_tlahiranak.Text), "yyyy/M/d")))
                End With
            Else
                With grid_anak
                    With grid_anak
                        atur_gridanak("baru")
                        id_anak = num + 1
                        .Rows.Add(1)
                        .Rows(.RowCount - 2).Cells(0).Value = text_nik.Text
                        .Rows(.RowCount - 2).Cells(1).Value = id_anak
                        .Rows(.RowCount - 2).Cells(2).Value = Text_nmanak.Text
                        .Rows(.RowCount - 2).Cells(3).Value = Text_tlahiranak.Text
                        .Rows(.RowCount - 2).Cells(4).Value = Format(CDate(DT_tlahiranak.Text), "yyyy/M/d")
                        .Rows(.RowCount - 2).Cells(5).Value = Text_ktpanak.Text
                    End With
                End With
            End If
        Else
            With grid_anak
                atur_gridanak("baru")
                id_anak = num + 1
                .Rows.Add(1)
                .Rows(.RowCount - 2).Cells(0).Value = text_nik.Text
                .Rows(.RowCount - 2).Cells(1).Value = id_anak
                .Rows(.RowCount - 2).Cells(2).Value = Text_nmanak.Text
                .Rows(.RowCount - 2).Cells(3).Value = Text_tlahiranak.Text
                .Rows(.RowCount - 2).Cells(4).Value = Format(CDate(DT_tlahiranak.Text), "yyyy/M/d")
                .Rows(.RowCount - 2).Cells(5).Value = Text_ktpanak.Text
            End With
            grid_anak.Refresh()
            DT_lahir.Format = DateTimePickerFormat.Custom
            DT_tlahiranak.CustomFormat = " "
        End If
    End Sub

    Private Sub DT_tlahiranak_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_tlahiranak.ValueChanged
        format_tanggal(DT_tlahiranak)
    End Sub

    Private Sub DT_lahirpas_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_lahirpas.ValueChanged
        format_tanggal(DT_lahirpas)
    End Sub

    Private Sub Button_baru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_baru.Click
        nik_global = String.Empty
        Application.CurrentCulture = New CultureInfo("EN-US")
        combojenis_k(Combo_jeniskel)
        comboagama(Combo_agama)
        combostatus_kawin(Combo_kawin)
        atur_gridanak("baru")
        If nik_global = String.Empty Then
            clear_date(Me, Groupanak)
        End If
        If cek_status(nik_global, "tbl_istri") = False Then
            clear_date(Me, Group_pas)
        End If
        fill_combo(Combo_pend, "pendidikan", "tbl_pegawai")
        fill_combo(Combo_desaD, "desa_dom", "tbl_pegawai")
        fill_combo(Combo_kecD, "kec_dom", "tbl_pegawai")
        fill_combo(Combo_kabD, "kab_dom", "tbl_pegawai")
        fill_combo(Combo_kodeD, "kdpos_dom", "tbl_pegawai")
        fill_combo(Combo_desaK, "desa_asal", "tbl_pegawai")
        fill_combo(Combo_kecK, "kec_asal", "tbl_pegawai")
        fill_combo(Combo_kabK, "kab_asal", "tbl_pegawai")
        fill_combo(Combo_kodeposK, "kdpos_asal", "tbl_pegawai")
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged

        If CheckBox1.Checked = True Then
            Text_alamatd.Text = Text_alamatk.Text
            Text_rtd.Text = Text_rtk.Text
            Text_rwd.Text = Text_rwk.Text
            Combo_desaD.Text = Combo_desaK.Text
            Combo_kecD.Text = Combo_kecK.Text
            Combo_kabD.Text = Combo_kabK.Text
            Combo_kodeD.Text = Combo_kodeposK.Text
        Else
            Text_alamatd.Text = String.Empty
            Text_rtd.Text = String.Empty
            Text_rwd.Text = String.Empty
            Combo_desaD.Text = String.Empty
            Combo_kecD.Text = String.Empty
            Combo_kabD.Text = String.Empty
            Combo_kodeD.Text = String.Empty
        End If
       
    End Sub

    Private Sub FormDTPersonal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New CultureInfo("id-ID")
        If Not IsNothing(nik_global) Then
            fill_combo(Combo_pend, "pendidikan", "tbl_pegawai")
            fill_combo(Combo_desaD, "desa_dom", "tbl_pegawai")
            fill_combo(Combo_kecD, "kec_dom", "tbl_pegawai")
            fill_combo(Combo_kabD, "kab_dom", "tbl_pegawai")
            fill_combo(Combo_kodeD, "kdpos_dom", "tbl_pegawai")
            fill_combo(Combo_desaK, "desa_asal", "tbl_pegawai")
            fill_combo(Combo_kecK, "kec_asal", "tbl_pegawai")
            fill_combo(Combo_kabK, "kab_asal", "tbl_pegawai")
            fill_combo(Combo_kodeposK, "kdpos_asal", "tbl_pegawai")
        End If
    End Sub

    Private Function cek_status(ByVal nik As String, ByVal tabel As String) As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = ""
            sqlcmd = New SqlCommand(sql, Conn)

        Catch ex As Exception
            MsgBox("gagal dalam pengecekan status " & ex.Message)
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Public Sub load_DTPersonal(ByVal nik As String)
        If cari_data(nik, "tbl_pegawai", Nothing) = True Then
            'load data tabel pegawai
            load_tblkarywan(nik)
        End If
        If cari_data(nik, "tbl_istri", Nothing) = True Then
            'load data tabel istri
            load_tblistri(nik)
        Else
            clear_date(Me, Group_pas)
        End If
        If cari_data(nik, "tbl_anak", Nothing) = True Then
            'load data tabel anak
            load_tblanak(nik, grid_anak)
        Else
            clear_date(Me, Groupanak)
        End If
        If cari_data(nik, "tbl_photopegawai", Nothing) = True Then
            'load data tabel photo"
            load_tblphoto(nik)
        End If
        If cari_data(nik, "tbl_riwayatkes", Nothing) = True Then
            'load data tabel riwayat
            load_riwayatkes(nik)
        End If
    End Sub

    Private Function cari_data(ByVal nik As String, ByVal nm_tabel As String, ByVal condition As String) As Boolean
        Try
            clear_command()
            openDB()
            If condition = Nothing Then
                sql = "SELECT " & nik & " FROM " & nm_tabel
            Else
                sql = "SELECT " & nik & " FROM " & nm_tabel & " WHERE " & condition
            End If
            sqlcmd = New SqlCommand(sql, Conn)
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                Return True
            Else
                Return False
            End If
            Conn.Close()
        Catch ex As Exception
            MsgBox("Gagal dalam pencarian data " & nm_tabel & " " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Function

    Private Sub load_tblkarywan(ByVal nik As String)
        Try
            clear_command()
            openDB()
            sql = "SELECT nik, nama, no_kk, no_ktp, tempat_lahir, tgl_lahir, agama, sex, pendidikan, " & _
                "alamat_asal, rt_asal, rw_asal, desa_asal, kec_asal, kab_asal, kdpos_asal, alamat_dom, " & _
                "rt_dom, rw_dom, desa_dom, kec_dom, kab_dom, kdpos_dom, no_telp, email, status_kawin, " & _
                "faskes_tk1, faskes_gigi, kerabat, telp_kerabat FROM tbl_pegawai WHERE nik = '" & nik & "'"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                If Not IsDBNull(sqlreader.Item("tgl_lahir")) Then
                    DT_lahir.Text = sqlreader.Item("tgl_lahir")
                Else
                    clear_date(Me, Nothing)
                End If
                text_nik.Text = nik
                If Not IsDBNull(sqlreader.Item("nama")) Then
                    text_nama.Text = sqlreader.Item("nama")
                End If
                If Not IsDBNull(sqlreader.Item("no_kk")) Then
                    Text_kk.Text = sqlreader.Item("no_kk")
                End If
                If Not IsDBNull(sqlreader.Item("no_ktp")) Then
                    Text_ktp.Text = sqlreader.Item("no_ktp")
                End If
                If Not IsDBNull(sqlreader.Item("tempat_lahir")) Then
                    Text_tlahir.Text = sqlreader.Item("tempat_lahir")
                End If
                If Not IsDBNull(sqlreader.Item("agama")) Then
                    Combo_agama.Text = sqlreader.Item("agama")
                End If
                If Not IsDBNull(sqlreader.Item("sex")) Then
                    Combo_jeniskel.Text = sqlreader.Item("sex")
                End If
                If Not IsDBNull(sqlreader.Item("pendidikan")) Then
                    Combo_pend.Text = sqlreader.Item("pendidikan")
                End If
                If Not IsDBNull(sqlreader.Item("alamat_asal")) Then
                    Text_alamatk.Text = sqlreader.Item("alamat_asal")
                End If
                If Not IsDBNull(sqlreader.Item("rt_asal")) Then
                    Text_rtk.Text = sqlreader.Item("rt_asal")
                End If
                If Not IsDBNull(sqlreader.Item("rw_asal")) Then
                    Text_rwk.Text = sqlreader.Item("rw_asal")
                End If
                If Not IsDBNull(sqlreader.Item("desa_asal")) Then
                    Combo_desaK.Text = sqlreader.Item("desa_asal")
                End If
                If Not IsDBNull(sqlreader.Item("kec_asal")) Then
                    Combo_kecK.Text = sqlreader.Item("kec_asal")
                End If
                If Not IsDBNull(sqlreader.Item("kab_asal")) Then
                    Combo_kabK.Text = sqlreader.Item("kab_asal")
                End If
                If Not IsDBNull(sqlreader.Item("kdpos_asal")) Then
                    Text_alamatd.Text = sqlreader.Item("kdpos_asal")
                End If
                If Not IsDBNull(sqlreader.Item("kdpos_asal")) Then
                    Combo_kodeposK.Text = sqlreader.Item("kdpos_asal")
                Else
                    Combo_kodeposK.Text = String.Empty
                End If
                If Not IsDBNull(sqlreader.Item("rt_dom")) Then
                    Text_rtd.Text = sqlreader.Item("rt_dom")
                Else
                    Text_rtd.Text = String.Empty
                End If
                If Not IsDBNull(sqlreader.Item("rw_dom")) Then
                    Text_rwd.Text = sqlreader.Item("rw_dom")
                Else
                    Text_rwd.Text = String.Empty
                End If
                If Not IsDBNull(sqlreader.Item("desa_dom")) Then
                    Combo_desaD.Text = sqlreader.Item("desa_dom")
                End If
                If Not IsDBNull(sqlreader.Item("kec_dom")) Then
                    Combo_kecD.Text = sqlreader.Item("kec_dom")
                End If
                If Not IsDBNull(sqlreader.Item("kab_dom")) Then
                    Combo_kabD.Text = sqlreader.Item("kab_dom")
                End If
                If Not IsDBNull(sqlreader.Item("kdpos_dom")) Then
                    Combo_kodeD.Text = sqlreader.Item("kdpos_dom")
                End If
                If Not IsDBNull(sqlreader.Item("no_telp")) Then
                    Text_telp.Text = sqlreader.Item("no_telp")
                End If
                If Not IsDBNull(sqlreader.Item("email")) Then
                    Text_email.Text = sqlreader.Item("email")
                End If
                If Not IsDBNull(sqlreader.Item("no_telp")) Then
                    Text_telp.Text = sqlreader.Item("no_telp")
                End If
                If Not IsDBNull(sqlreader.Item("status_kawin")) Then
                    Combo_kawin.Text = sqlreader.Item("status_kawin")
                End If
                If Not IsDBNull(sqlreader.Item("faskes_tk1")) Then
                    Text_faskestk.Text = sqlreader.Item("faskes_tk1")
                End If
                If Not IsDBNull(sqlreader.Item("faskes_gigi")) Then
                    Text_faskesgg.Text = sqlreader.Item("faskes_gigi")
                End If
                If Not IsDBNull(sqlreader.Item("kerabat")) Then
                    Text_kerabat.Text = sqlreader.Item("kerabat")
                End If
                If Not IsDBNull(sqlreader.Item("telp_kerabat")) Then
                    Text_telpkerabat.Text = sqlreader.Item("telp_kerabat")
                End If
            End If
        Catch ex As Exception
            MsgBox("gagal dalam pencarian data tabel karyawan tabel pegawai " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub load_tblistri(ByVal nik As String)
        Try
            clear_command()
            openDB()
            sql = "SELECT nik, nama, no_ktp, tempat_lahir, tgl_lahir FROM tbl_istri WHERE nik = '" & nik & "'"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                If Not IsDBNull(sqlreader.Item("nama")) Then
                    Text_namapas.Text = sqlreader.Item("nama")
                End If
                If Not IsDBNull(sqlreader.Item("no_ktp")) Then
                    Text_ktppas.Text = sqlreader.Item("no_ktp")
                End If
                If Not IsDBNull(sqlreader.Item("tempat_lahir")) Then
                    Text_tlahirpas.Text = sqlreader.Item("tempat_lahir")
                End If
                If Not IsDBNull(sqlreader.Item("tgl_lahir")) Then
                    DT_lahirpas.Text = sqlreader.Item("tgl_lahir")
                Else
                    clear_date(Me, Group_pas)
                End If
            End If
        Catch ex As Exception
            MsgBox("gagal dalam menampilkan data tabel istri " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub load_tblanak(ByVal nik As String, ByVal grid As DataGridView)
        Try
            clear_command()
            openDB()
            format_tanggal_kosong(DT_tlahiranak)
            sql = "SELECT nik, id_anak, nama, tempat_lahir, tgl_lahir, no_ktp FROM tbl_anak WHERE nik = '" & nik & "'"
            sqlcmd = New SqlCommand(sql, Conn)
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            grid.DataSource = DTab
            grid.Refresh()
            num = DTab.Rows.Count
        Catch ex As Exception
            MsgBox("gagal dalam menampilkan data tbl anak " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub load_tblphoto(ByVal nik As String)
        Try
            clear_command()
            openDB()
            sql = "SELECT nik, nama_photo, photo FROM tbl_photopegawai"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                Dim ms As New IO.MemoryStream(CType(sqlreader.Item("photo"), Byte()))
                Pict_photo.SizeMode = PictureBoxSizeMode.StretchImage
                Pict_photo.Image = Image.FromStream(ms)
            End If
        Catch ex As Exception
            MsgBox("gagal dalam menampilkan photo " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub load_riwayatkes(ByVal nik As String)
        Try
            clear_command()
            openDB()
            sql = "SELECT nik, riwayat FROM tbl_riwayatkes WHERE nik = '" & nik & "'"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                Text_riwayat.Text = sqlreader.Item("riwayat")
            End If
        Catch ex As Exception
            MsgBox("gagal dalam menampilkan data riwayat " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub grid_anak_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grid_anak.CellMouseUp
        With grid_anak
            If e.Button = MouseButtons.Right Then
                If .Rows.Count > 1 Then
                    .ContextMenuStrip = ContextMenuStrip1
                    rowindex = .CurrentRow.Index
                    no_nik = .Rows(rowindex).Cells(0).Value
                    Me.ContextMenuStrip1.Show(Me.grid_anak, e.Location)
                    Me.ContextMenuStrip1.Show(Cursor.Position)
                Else
                    .ContextMenuStrip = Nothing
                End If
            End If
        End With
    End Sub

    Private Sub EditDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditDataToolStripMenuItem.Click
        'delete baris di data table yang terhubung di grid
        With grid_anak
            Text_nmanak.Text = .Rows(rowindex).Cells(2).Value
            Text_tlahiranak.Text = .Rows(rowindex).Cells(3).Value
            DT_tlahiranak.Text = .Rows(rowindex).Cells(4).Value
            Text_ktpanak.Text = .Rows(rowindex).Cells(5).Value
            id_anak = .Rows(rowindex).Cells(1).Value
            id_status = "edit"
            DTab.Rows(rowindex).Delete()
            .Refresh()
        End With
    End Sub

    Private Sub DT_lahir_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_lahir.ValueChanged
        format_tanggal(DT_lahir)
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click

    End Sub

    Private Sub grid_anak_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_anak.CellContentClick

    End Sub

    Private Function CheckKTP() As String
        Try
            clear_command()
            openDB()
            sql = "SELECT TOP(1) nik,nama,no_ktp FROM tbl_pegawai WHERE no_ktp = @no_ktp ORDER BY nik DESC"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@no_ktp", SqlDbType.VarChar).Value = Text_ktp.Text
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                Return sqlreader.Item("nik")
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("gagal dalam pengecekan no ktp" & ex.Message, MsgBoxStyle.Exclamation, "INFO")
            Return Nothing
        End Try
    End Function

    Private Sub Bcheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bcheck.Click
        Dim NoNIK As String = CheckKTP()
        If NoNIK IsNot Nothing Then
            load_DTPersonal(NoNIK)
        Else
            MsgBox("No KTP belum pernah di input", MsgBoxStyle.Information, "INFO")
        End If
    End Sub

    Private Sub ButtonTst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            clear_command()
            openDB()
            sql = "SELECT nik, nama, no_kk, no_k[tp, tempat_lahir, tgl_lahir, agama, sex, pendidikan, alamat_asal, rt_asal, " & _
                "rw_asal, desa_asal, kec_asal, kab_asal, kdpos_asal, alamat_dom, rt_dom, rw_dom, desa_dom, kec_dom, kab_dom, " & _
                "kdpos_dom, no_telp, email, status_kawin, faskes_tk1, faskes_gigi, kerabat, telp_kerabat FROM tbl_pegawai " & _
                "WHERE nik = '" & text_nik.Text & "'"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                If Not sqlreader.IsDBNull(sqlreader.GetOrdinal("nama")) Then
                    Text_kerabat.Text = sqlreader.Item("nama")
                Else
                    MsgBox("kosong")
                End If
                If Not sqlreader.IsDBNull(sqlreader.GetOrdinal("telp_kerabat")) Then
                    Text_telpkerabat.Text = sqlreader.Item("telp_kerabat")
                End If
            Else
                MsgBox("pencarian data tidak ditemukan")
            End If
        Catch ex As Exception
            MsgBox("gagal dalam pencarian data tabel karyawan tabel pegawai " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub
End Class
