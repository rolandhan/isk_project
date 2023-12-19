Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports VB = Microsoft.VisualBasic.Strings

Public Class FormRiwayatHS
    Dim rowindex As Integer
    Dim nourut As String
    Dim nik As String
    Private Sub FormRiwayatHS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    'procedur pemanggilan data harian sementara
    Public Sub load_dataharians(ByVal grid As DataGridView, ByVal nik As String, ByVal condition As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            Select Case condition
                Case String.Empty
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, " & _
                        "temp.nik, nama, departemen ,jabatan,status_karyawan, atasan, tgl_masuk, " & _
                        "tgl_keluar, no_urut FROM (SELECT tbl_jabatan .nik,departemen ,jabatan,status_karyawan, " & _
                        "atasan ,tgl_masuk , tgl_keluar ,tbl_tglharians.no_urut FROM tbl_jabatan " & _
                        "INNER JOIN tbl_tglharians ON tbl_jabatan.nik = tbl_tglharians .nik AND " & _
                        "tbl_jabatan .no_urut = tbl_tglharians .no_urut) AS temp LEFT OUTER JOIN tbl_pegawai ON " & _
                        "temp.nik = tbl_pegawai.nik WHERE temp.nik = @nik ORDER BY temp.nik, temp.no_urut"
                Case "pencarian"
                    sql = "SELECT nik, nama, departemen, jabatan, atasan, status_karyawan FROM view_dtpegawai " & _
                        "WHERE nik LIKE '%" & Text_pencarian.Text & "%' OR " & _
                        "nama LIKE '%d" & Text_pencarian.Text & "%'  ORDER BY temp.nik, temp.no_urut"
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            If IsNothing(condition) Then
                sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = nik
            End If
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            grid.DataSource = DTab
            atur_grid(grid, condition)
            grid.Refresh()
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data harian sementara karena " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    'fungsi penghapusan data
    Private Function hapus_data(ByVal id As String, _
                                    ByVal tabel As String, ByVal id_value As String, ByVal kondisi As String) As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "DELETE FROM " & tabel & " WHERE " & id & " = @id" & kondisi
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id_value
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam penghapusan data di tabel " & tabel & " " & ex.Message)
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    'update data tbl_tanggalharianS
    Private Function update_data(ByVal grid As DataGridView) As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            'SELECT nik, tgl_masuk, tgl_keluar, no_urut FROM tbl_tglharians
            sql = "update tbl_tglharians tgl_masuk = @tgl_masuk, tgl_keluar = @tgl_keluar " & _
                "WHERE no_urut = @no_urut"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@no_urut", SqlDbType.Char).Value = grid.Rows(rowindex).Cells(9).Value
                If IsNothing(grid.Rows(rowindex).Cells(7).Value) Then
                    .Add("@tgl_masuk", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tgl_masuk", SqlDbType.Date).Value = grid.Rows(rowindex).Cells(7).Value
                End If
                If IsNothing(grid.Rows(rowindex).Cells(8).Value) Then
                    .Add("tgl_keluar", SqlDbType.Time).Value = DBNull.Value
                Else
                    .Add("tgl_keluar", SqlDbType.Time).Value = grid.Rows(rowindex).Cells(8).Value
                End If
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam update data " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Cursor.Current = Cursors.Default
            Conn.Close()
        End Try
    End Function

    Private Sub atur_grid(ByVal grid As DataGridView, ByVal condition As String)
        Select Case condition
            Case String.Empty
                With grid
                    .ReadOnly = True
                    .Enabled = True
                    .Columns(0).HeaderText = "No"
                    .Columns(0).Width = "30"
                    .Columns(1).HeaderText = "NIK"
                    .Columns(1).Width = "75"
                    .Columns(2).HeaderText = "Nama"
                    .Columns(2).Width = "200"
                    .Columns(3).HeaderText = "Departemen"
                    .Columns(3).Width = "160"
                    .Columns(4).HeaderText = "Jabatan"
                    .Columns(4).Width = "200"
                    .Columns(5).HeaderText = "Status Karyawan"
                    .Columns(5).Width = "80"
                    .Columns(6).HeaderText = "Atasan"
                    .Columns(6).Width = "200"
                    .Columns(7).HeaderText = "Tgl masuk"
                    .Columns(7).Width = "80"
                    .Columns(8).HeaderText = "Tgl keluar"
                    .Columns(8).Width = "80"
                    .Columns(9).HeaderText = "no urut"
                    .Columns(9).Visible = False
                    .RowHeadersWidth = 5
                End With
            Case "pencarian"
                With grid
                    .ReadOnly = True
                    .Enabled = True
                    .Columns(0).HeaderText = "No"
                    .Columns(0).Width = "30"
                    .Columns(1).HeaderText = "NIK"
                    .Columns(1).Width = "75"
                    .Columns(2).HeaderText = "Nama"
                    .Columns(2).Width = "200"
                    .Columns(3).HeaderText = "Departemen"
                    .Columns(3).Width = "110"
                    .RowHeadersWidth = 5
                End With
        End Select
    End Sub

    Private Sub grid_pencarian_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_pencarian.CellContentDoubleClick
        With grid_pencarian
            load_dataharians(grid_tampildata, .Rows(.CurrentRow.Index).Cells(0).Value, Nothing)
            .Visible = False
            .DataSource = Nothing
        End With
    End Sub

    Private Sub Text_pencarian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_pencarian.TextChanged
        load_dataharians(grid_pencarian, Nothing, "pencarian")
    End Sub

    Private Sub grid_tampildata_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_tampildata.CellEndEdit
        With grid_tampildata
            If MsgBox("Data dengan : " & vbCrLf & _
                      "NIK : " & .Rows(rowindex).Cells(1).Value & vbCrLf & _
                      "Nama : " & .Rows(rowindex).Cells(2).Value & vbCrLf & _
                      "Siap di update ? ", MsgBoxStyle.OkCancel, "INFO") = MsgBoxResult.Ok Then
                nik = .Rows(rowindex).Cells(1).Value
                If update_data(grid_tampildata) = True Then
                    MsgBox("Data telah berhasil di update", MsgBoxStyle.Information, "INFO")
                    load_dataharians(grid_tampildata, nik, Nothing)
                End If
            End If
        End With
    End Sub

    Private Sub grid_tampildata_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grid_tampildata.CellMouseUp
        With grid_tampildata
            If e.Button = MouseButtons.Right Then
                If .Rows.Count > 1 Then
                    .ContextMenuStrip = ContextMenuStrip1
                    rowindex = .CurrentRow.Index
                    nourut = .Rows(rowindex).Cells(9).Value
                    Me.ContextMenuStrip1.Show(Me.grid_tampildata, e.Location)
                    Me.ContextMenuStrip1.Show(Cursor.Position)
                Else
                    .ContextMenuStrip = Nothing
                End If
            End If
        End With
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        grid_tampildata.SelectionMode = DataGridViewSelectionMode.CellSelect
        grid_tampildata.ReadOnly = False
    End Sub

    Private Sub HapusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HapusToolStripMenuItem.Click
        With grid_tampildata
            If MsgBox("Data dengan : " & vbCrLf & _
                  "NIK : " & .Rows(rowindex).Cells(1).Value & vbCrLf & _
                  "Nama : " & .Rows(rowindex).Cells(2).Value & vbCrLf & _
                  "Siap di hapus ? ", MsgBoxStyle.OkCancel, "INFO") = MsgBoxResult.Ok Then
                nik = .Rows(rowindex).Cells(1).Value
                If hapus_data("no_urut", "tbl_tglharians", .Rows(rowindex).Cells(9).Value, Nothing) = True Then
                    MsgBox("Data telah berhasil di hapus", MsgBoxStyle.Information, "INFO")
                    load_dataharians(grid_tampildata, nik, Nothing)
                End If
            End If
        End With
    End Sub
End Class