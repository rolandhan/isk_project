Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data
Imports System.Globalization

Public Class FormImportFile
    Private excelconn As OleDbConnection
    Private oleAdapter As OleDbDataAdapter
    Private openfile As OpenFileDialog
    Private strname, namefile As String

    Private Sub FormImportFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New CultureInfo("EN-US")

    End Sub

    Private Sub browsefile(ByVal grid As DataGridView)
        Try
            openfile = New OpenFileDialog
            openfile.Filter = "document 2007 doc(*.xls)|*.xls|Document 2010 doc(*.xlsx)|*.xlsx"
            openfile.FilterIndex = 1
            If openfile.ShowDialog = Windows.Forms.DialogResult.OK Then
                strname = openfile.FileName
                namefile = openfile.SafeFileName
                load_excel(grid)
                'Label1.Text = strname & " " & namefile
            Else
                strname = Nothing
            End If
        Catch Ex As Exception
            MsgBox("gagal membuka file" & Ex.Message, MsgBoxStyle.Information, "INFO")
        End Try
    End Sub

    Private Sub load_excel(ByVal grid As DataGridView)
        Try
            Dim sConn As String
            sConn = "provider=Microsoft.ACE.OLEDB.12.0;Data Source= " & _
                    "'" & strname & "';Extended Properties=Excel 12.0;;"

            excelconn = New OleDbConnection(sConn)
            oleAdapter = New OleDbDataAdapter("select * from [" & Text_sheet.Text & "$]", excelconn)
            oleAdapter.TableMappings.Add("Table", "Data")
            dtset = New DataSet
            oleAdapter.Fill(dtset)
            grid.DataSource = dtset.Tables(0)
            excelconn.Close()
        Catch ex As Exception
            MsgBox("gagal menampilkan file excel " & ex.Message)
        End Try
    End Sub

    Private Sub simpan_data(ByVal grid As DataGridView, ByVal NamaTabel As String)
        Try
            clear_command()
            openDB()
            With grid
                Select Case NamaTabel
                    Case "DataPasangan"
                        For A% = 0 To .RowCount - 2
                            sql = "INSERT INTO tbl_rawabsen(nik, tanggal) VALUES(@nik, @tanggal)"
                            sqlcmd = New SqlCommand(sql, Conn)
                            sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = .Rows(A).Cells(1).Value
                            sqlcmd.Parameters.Add("@tanggal", SqlDbType.DateTime2).Value = .Rows(A).Cells(0).Value
                            sqlcmd.ExecuteNonQuery()
                        Next A
                    Case "DataAnak"
                        For A% = 0 To .RowCount - 2
                            sql = "INSERT INTO tbl_rawabsen(nik, tanggal) VALUES(@nik, @tanggal)"
                            sqlcmd = New SqlCommand(sql, Conn)
                            sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = .Rows(A).Cells(1).Value
                            sqlcmd.Parameters.Add("@tanggal", SqlDbType.DateTime2).Value = .Rows(A).Cells(0).Value
                            sqlcmd.ExecuteNonQuery()
                        Next A
                End Select
                
                Cursor.Current = Cursors.WaitCursor
                clear_command()
                'For B% = 0 To .RowCount - 2
                'sql = "INSERT INTO tbl_statuskerja(nik, departemen, jabatan) " & _
                '    "VALUES(@nik, @departemen, @jabatan)"
                'sqlcmd = New SqlCommand(sql, Conn)
                'sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = .Rows(B).Cells(1).Value
                'sqlcmd.Parameters.Add("@departemen", SqlDbType.VarChar).Value = .Rows(B).Cells(2).Value
                'sqlcmd.Parameters.Add("@jabatan", SqlDbType.VarChar).Value = .Rows(B).Cells(3).Value
                'sqlcmd.ExecuteNonQuery()
                'Next B
                MsgBox("Sukses dalam penyimpanan data ", MsgBoxStyle.Information, "INFO")
            End With
        Catch ex As Exception
            MsgBox("gagal dalam penyimpanan data " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Private Sub Button_browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_browse.Click
        browsefile(grid_tampilan)
    End Sub

    Private Sub Button_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_simpan.Click
        simpan_data(grid_tampilan, Nothing)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class