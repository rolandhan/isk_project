Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization

Public Class FormGantiNIK

    Private Sub FormGantiNIK_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New CultureInfo("id-ID")
        load_gridkaryawan(grid_karyawan, Nothing)
        load_combo(Combo_depart, "departemen", "tbl_jabatan")
    End Sub

    Private Sub load_gridkaryawan(ByVal grid As DataGridView, ByVal opt As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            Select Case opt
                Case String.Empty
                    sql = "SELECT nik, nama, departemen, jabatan, status, atasan from view_pegawai"
                Case "departemen"
                    sql = "SELECT nik, nama, departemen, jabatan, status, atasan from view_pegawai " & _
                    "WHERE departemen = '" & Combo_depart.Text & "'"
                Case "text"
                    sql = "SELECT nik, nama, departemen, jabatan, status, atasan from view_pegawai " & _
                    "WHERE nama LIKE '%" & Text_pencarian.Text & "%' OR nik LIKE '%" & Text_pencarian.Text & "%'"
            End Select
            sqladapter = New SqlDataAdapter(sql, Conn)
            DataTab = New DataTable
            DataTab.Clear()
            sqladapter.Fill(DataTab)
            grid_karyawan.DataSource = DataTab
            grid_karyawan.Refresh()
        Catch ex As Exception
            MsgBox("gagal menampilkan data " & ex.Message)
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    'simpan perubahan setelah melakukan pergantian NIK
    Private Function simpan_update(ByVal nik As String, ByVal tabel As String) As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "UPDATE " & tabel & " SET nik = @new_nik WHERE nik = @nik"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = nik
            sqlcmd.Parameters.Add("@new_nik", SqlDbType.VarChar).Value = Text_nikbaru.Text
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

    Private Sub Text_pencarian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_pencarian.TextChanged
        load_gridkaryawan(grid_karyawan, "text")
    End Sub

    Private Sub Combo_depart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_depart.SelectedIndexChanged
        load_gridkaryawan(grid_karyawan, "departemen")
    End Sub

    Private Sub grid_karyawan_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_karyawan.CellContentDoubleClick
        Try
            Cursor.Current = Cursors.WaitCursor
            With grid_karyawan
                Dim baris% = .CurrentRow.Index
                Text_nik.Text = .Rows(baris).Cells(0).Value
                Text_nama.Text = .Rows(baris).Cells(1).Value
                Text_dept.Text = .Rows(baris).Cells(2).Value
                Text_jabatan.Text = .Rows(baris).Cells(3).Value
                Text_status.Text = .Rows(baris).Cells(4).Value
            End With
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub hapus()
        Clear_combo(Me, Nothing)
        Clear_text(Me, Nothing)
        grid_karyawan.DataSource = Nothing
        grid_karyawan.Refresh()
        load_gridkaryawan(grid_karyawan, Nothing)
    End Sub

    Private Sub Button_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_simpan.Click
        If Text_nik.Text = String.Empty Then
            MsgBox("Silahkan pilih data terlebih dahulu ", MsgBoxStyle.Information, "INFO")
        Else
            If MsgBox("Data dengan NIK : " & Text_nik.Text & " " & vbCrLf & _
                      "Nama : " & Text_nama.Text & " " & vbCrLf & _
                      "Departemen : " & Text_dept.Text & " " & vbCrLf & _
                      "Ganti dengan NIK baru ? ", MsgBoxStyle.Information & vbOKCancel, "INFO") = vbOK Then
                If simpan_update(Text_nik.Text, "tbl_anak") = True And
                    simpan_update(Text_nik.Text, "tbl_catatan") = True And
                    simpan_update(Text_nik.Text, "tbl_covid") = True And
                    simpan_update(Text_nik.Text, "tbl_cuti") = True And
                    simpan_update(Text_nik.Text, "tbl_dataabsen") = True And
                    simpan_update(Text_nik.Text, "tbl_dinas") = True And
                    simpan_update(Text_nik.Text, "tbl_ijin") = True And
                    simpan_update(Text_nik.Text, "tbl_istri") = True And
                    simpan_update(Text_nik.Text, "tbl_jabatan") = True And
                    simpan_update(Text_nik.Text, "tbl_pegawai") = True And
                    simpan_update(Text_nik.Text, "tbl_photopegawai") = True And
                    simpan_update(Text_nik.Text, "tbl_potongan") = True And
                    simpan_update(Text_nik.Text, "tbl_rawabsen") = True And
                    simpan_update(Text_nik.Text, "tbl_rekapkerja") = True And
                    simpan_update(Text_nik.Text, "tbl_riwayatkes") = True And
                    simpan_update(Text_nik.Text, "tbl_statuscuti") = True And
                    simpan_update(Text_nik.Text, "tbl_statusijin") = True And
                    simpan_update(Text_nik.Text, "tbl_statuskerja") = True And
                    simpan_update(Text_nik.Text, "tbl_tanggalkerja") = True And
                    simpan_update(Text_nik.Text, "tbl_telat") = True And
                    simpan_update(Text_nik.Text, "tbl_tglharians") = True Then
                    MsgBox("Data telah berhasil di update ", MsgBoxStyle.Information, "INFO")
                    hapus()
                End If
            End If
            End If
    End Sub

    Private Function simpan_nikbaru() As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "INSERT INTO tbl_ubahnik(nik, no_ktp, no_urut, ket, tanggal) " & _
                "VALUES(@nik, @no_ktp, @no_urut, @ket, @tanggal)"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = ""
                .Add("@no_ktp", SqlDbType.VarChar).Value = ""
                .Add("@no_urut", SqlDbType.VarChar).Value = ""
                .Add("@ket", SqlDbType.VarChar).Value = ""
                .Add("@tanggal", SqlDbType.Date).Value = ""
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam melakukan penimpanan data ubah nik " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

End Class