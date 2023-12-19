Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FormLogIn
    Private Sub FormLogIn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isicomboauth()
        txtuserid.Focus()
    End Sub

    Private Sub Button_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_cancel.Click
        Me.Close()
    End Sub

    Private Sub Bsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsimpan.Click
        clear_command()
        openDB()
        Try
            sql = "SELECT username FROM tbl_user WHERE " & _
                "password = '" & txtpassword.Text & "' AND status = '" & cmbAuth.Text & "'"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                MsgBox("Login berhasil", MsgBoxStyle.Information, "INFO")
                enable_menu()
                FormMenuUtama.LinkLabel1.Visible = True
                FormMenuUtama.LinkLabel1.Text = CekStatusKontrak()
                FormMenuUtama.StartBlink()

                Me.Hide()
                Clear_text(Me, GroupBox1)
                Clear_combo(Me, GroupBox1)
            Else
                MsgBox("Username dan password tidak sesuai ", MsgBoxStyle.Critical, "PERINGATAN")
                txtpassword.Focus()
                disable_menu()
            End If
        Catch Ex As Exception
            MessageBox.Show("Gagal log in " & Ex.Message)
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub isicomboauth()
        With cmbAuth
            .Items.Add("super admin")
            .Items.Add("admin")
        End With
    End Sub

    Private Sub Checkpass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Checkpass.CheckedChanged
        If Checkpass.Checked = True Then
            txtpassword.PasswordChar = Nothing
        Else
            txtpassword.PasswordChar = "*"
        End If
    End Sub

    'cek status kontrak dan status harian
    Private Function CekStatusKontrak() As String
        Try
            Dim Selisih As Integer
            clear_command()
            openDB()
            sql = "SELECT * FROM  (SELECT tbl_pegawai.nik, tbl_pegawai.nama, jab.departemen, jab.jabatan, jab.atasan, jab.status_karyawan, " & _
                "jab.tgl_awal,jab.tgl_akhir,DATEDIFF(day, GETDATE(), tgl_akhir) AS selisih " & _
                "FROM tbl_pegawai OUTER APPLY " & _
                "(SELECT  TOP (1) tbl_jabatan.nik, tbl_jabatan.departemen, tbl_jabatan.jabatan, tbl_jabatan.atasan, " & _
                "tbl_jabatan.status_karyawan, tbl_jabatan.tgl_awal , tbl_jabatan.tgl_akhir " & _
                "FROM tbl_jabatan " & _
                "WHERE tbl_jabatan.nik = tbl_pegawai.nik " & _
                "ORDER BY tbl_jabatan.no_urut DESC) AS jab) As Temp " & _
                "where (Temp.status_karyawan = 'Kontrak' OR temp.status_karyawan = 'Harian' " & _
                "OR temp.status_karyawan = 'Harian Sementara' " & _
                "OR temp.status_karyawan = 'Harian Tetap') AND (temp.selisih < 7 AND temp.selisih > 0) " & _
                "AND temp.status_karyawan <> 'keluar'"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                Selisih = sqlreader.Item("selisih")
            Else
                Selisih = Nothing
            End If
            If Selisih <= 7 And Selisih > 0 Then
                Return "masa kerja habis, cek disini"
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("gagal dalam melakukan pengecekan masa kontrak " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return Nothing
        Finally
            Conn.Close()
        End Try
    End Function

End Class