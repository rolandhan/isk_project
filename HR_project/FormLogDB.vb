Imports System.IO
Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FormLogDB

    Private Sub Bsimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bsimpan.Click
        isicombo()
        If Bsimpan.Text = "Log in" Then
            If GetLogDB() = True Then
                FormMenuUtama.Show()
                FormMenuUtama.WindowState = FormWindowState.Maximized
                Me.Hide()
            Else
                'MsgBox("koneksi database gagal,cek koneksi", MsgBoxStyle.Information, "INFO")
                Bsimpan.Text = "simpan"
            End If
        Else
            writeDataConfig()
            Bsimpan.Text = "Log in"
            'Me.Close()
        End If
        
    End Sub

    Private Function GetLogDB() As Boolean
        Try
            Cursor.Current = Cursors.AppStarting
            GetDataConfig()
            If auth = "Windows Authentication" Then
                sql = "server=" & txt_server & ";initial catalog=" & txt_db & ";Integrated Security=True"
            Else
                sql = "server=" & txt_server & ";database=" & txt_db & ";user id=" & txt_id & ";password=" & txt_pwd & ""
            End If
            Conn = New SqlConnection(sql)
            If Conn.State = ConnectionState.Closed Then
                Conn.Open()
                If MsgBox("Selamat Datang", MsgBoxStyle.Information, "INFO") = vbOK Then
                    Return True
                End If
                'Return True
            Else
                Return False
            End If
            Cursor.Current = Cursors.Arrow
            Return True
        Catch ex As SqlException
            MsgBox("Koneksi gagal silahkan cek konfigurasi database,  " & vbCrLf & Err.Description, MsgBoxStyle.Critical, "INFO")
            Cursor.Current = Cursors.Arrow
            Return False
        End Try
    End Function

    Private Sub GetDataConfig()

        Dim FilePath As String = Application.StartupPath & "\config_db.ini"
        txt_server = readini(FilePath, "Setting Config", "server", "")
        txt_db = readini(FilePath, "Setting Config", "database", "")
        cmb_auth = readini(FilePath, "Setting Config", "auth", "")
        txt_id = readini(FilePath, "Setting Config", "userid", "")
        txt_pwd = readini(FilePath, "Setting Config", "password", "")

    End Sub

    Private Sub writeDataConfig()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim FilePath As String = Application.StartupPath & "\config_db.ini"
            writeini(FilePath, "Setting Config", "server", txtserver.Text)
            writeini(FilePath, "Setting Config", "database", txtdatabase.Text)
            writeini(FilePath, "Setting Config", "auth", cmbAuthentication.Text)
            writeini(FilePath, "Setting Config", "userid", txtuserid.Text)
            writeini(FilePath, "Setting Config", "password", txtpassword.Text)
            MsgBox("pengaturan tersimpan, silahkan Log in kembali", MsgBoxStyle.Information, "INFO")
            Cursor.Current = Cursors.Arrow
        Catch exs As Exception
            MsgBox("gagal menyimpan pengaturan", MsgBoxStyle.Information, "INFO")
            Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Private Sub FormLogDB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isicombo()
        Dim FilePath As String = Application.StartupPath & "\config_db.ini"
        txtserver.Text = readini(FilePath, "Setting Config", "server", "")
        txtdatabase.Text = readini(FilePath, "Setting Config", "database", "")
        cmbAuthentication.Text = readini(FilePath, "Setting Config", "auth", "")
        txtuserid.Text = readini(FilePath, "Setting Config", "userid", "")
        txtpassword.Text = readini(FilePath, "Setting Config", "password", "")
    End Sub

    Private Sub isicombo()
        With cmbAuthentication.Items
            .Add("Windows Authentication")
            .Add("SQL")
        End With
    End Sub



    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtpassword.PasswordChar = ""
        Else
            txtpassword.PasswordChar = "*"
        End If
    End Sub

    Private Sub Buttoncancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttoncancel.Click
        Close()
    End Sub

End Class