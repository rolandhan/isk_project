Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO


Module ModuleConnection
    Public Conn As SqlConnection
    Private Str As String
    Public server, provider, uid, protocol, database, auth, pass As String
    Public hak_akses As String

    Sub openDB()
        Try
            If auth = "Windows Authentication" Then
                Str = "server=" & txt_server & ";initial catalog=" & txt_db & ";Integrated Security=True"
            Else
                Str = "server=" & txt_server & ";database=" & txt_db & ";user id=" & txt_id & ";password=" & txt_pwd & ""
            End If
            Conn = New SqlConnection(Str)

            Try
                If Conn.State = ConnectionState.Closed Then
                    Conn.Open()
                End If
            Catch ex As Exception
                'MsgBox(Err.Description, MsgBoxStyle.Critical, "Error3")
                'Formlogdatabase.Show()
                'Formlogdatabase.MdiParent = FormMenuUtama
            End Try
        Catch ex As SqlException
            MsgBox(Err.Description, MsgBoxStyle.Critical, "Error2")
        End Try
    End Sub
End Module
