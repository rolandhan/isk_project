Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FormPencarian

    Private Sub Text_cari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_cari.TextChanged
        If Text_cari.TextLength > 2 Then
            Try
                openDB()
                clear_command()
                sql = "SELECT nama, nik,bagian FROM tbl_pegawai" & _
                    "WHERE nik LIKE '%" & Text_cari.Text & "%' OR " & _
                    "nama like '%" & Text_cari.Text & "%' OR " & _
                    "bagian like '%" & Text_cari.Text & "%' ORDER BY nik ASC"


                sqladapter = New SqlDataAdapter(sql, Conn)
                dtset = New DataSet
                dtset.Clear()
                sqladapter.Fill(dtset, "tbl_pegawai")

                grid_pencarian.DataSource = (dtset.Tables("tbl_pegawai"))
                'atur_gridcarisoki()
                grid_pencarian.Refresh()
            Catch ex As Exception
                MessageBox.Show("error grid : " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub FormPencarian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class