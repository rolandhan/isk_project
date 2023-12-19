Imports System.Data.Sql
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Globalization

Public Class FormDaftarAbsensiFull

    Dim baris As Integer

    Private Sub load_gridabsen(ByVal grid As DataGridView, ByVal opt As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            Select Case opt
                Case String.Empty
                    sql = "SELECT DISTINCT ROW_NUMBER() OVER(ORDER BY t.nik ASC) AS No, " & _
                        "t.nik, t.nama, t.departemen, t.status_karyawan, @tgl AS tgl1, " & _
                        "CONVERT(VARCHAR(50), A1.[timein], 108) AS in1, CONVERT(VARCHAR(50), A1.[timeout], 108)  AS out1, " & _
                        "(CASE WHEN C1.status <> 'catatan' THEN c1.status ELSE NULL END) as ket1, " & _
                        "DATEADD(day,1,@tgl) AS tgl2, CONVERT(VARCHAR(50), A2.[timein], 108) AS in2, " & _
                        "CONVERT(VARCHAR(50), A2.[timeout], 108)   AS out2, " & _
                        "(CASE WHEN C2.status <> 'catatan' THEN c2.status ELSE NULL END) as ket2, " & _
                        "DATEADD(day,2,@tgl)  AS tgl3, CONVERT(VARCHAR(50), A3.[timein], 108)   AS in3, " & _
                        "CONVERT(VARCHAR(50), A3.[timeout], 108)   AS out3, " & _
                        "(CASE WHEN C3.status <> 'catatan' THEN c3.status ELSE NULL END) as ket3, " & _
                        "DATEADD(day,3,@tgl)  AS tgl4, CONVERT(VARCHAR(50), A4.[timein], 108)   AS in4, " & _
                        "CONVERT(VARCHAR(50), A4.[timeout], 108)   AS out4, " & _
                        "(CASE WHEN C4.status <> 'catatan' THEN c4.status ELSE NULL END) as ket4 FROM view_dtpegawai t " & _
                        "OUTER APPLY (SELECT TOP 1 [nik], [tanggal], [timein],[timeout] FROM tbl_dataabsen " & _
                        "WHERE [nik] = t.nik AND [tanggal] = @tgl ) A1 " & _
                        "OUTER APPLY (SELECT TOP 1 [nik], [tanggal], [timein],[timeout] FROM tbl_dataabsen " & _
                        "WHERE [nik] = t.nik  AND [tanggal] = DATEADD(day,1,@tgl) ) A2 " & _
                        "OUTER APPLY (SELECT TOP 1 [nik], [tanggal], [timein],[timeout] " &
                        "FROM tbl_dataabsen WHERE [nik] = t.nik AND [tanggal] = DATEADD(day,2,@tgl) ) A3 " & _
                        "OUTER APPLY (SELECT TOP 1 [nik], [tanggal], [timein],[timeout] FROM tbl_dataabsen " & _
                        "WHERE [nik] = t.nik AND [tanggal] = DATEADD(day,3,@tgl) ) A4 " &
                        "OUTER APPLY ( SELECT TOP 1 [nik],[status] FROM tbl_rekapkerja " & _
                        "WHERE [nik] = t.nik AND [tanggal] = @tgl ) C1 " & _
                        "OUTER APPLY ( SELECT TOP 1 [nik],[status] FROM tbl_rekapkerja " & _
                        "WHERE [nik] = t.nik AND [tanggal] = DATEADD(day,1,@tgl) ) C2 " & _
                        "OUTER APPLY ( SELECT TOP 1 [nik],[status] FROM tbl_rekapkerja " & _
                        "WHERE [nik] = t.nik AND [tanggal] = DATEADD(day,2,@tgl) ) C3 " & _
                        "OUTER APPLY ( SELECT TOP 1 [nik],[status] FROM tbl_rekapkerja " & _
                        "WHERE [nik] = t.nik AND [tanggal] = DATEADD(day,3,@tgl)) C4"
                Case "departemen"
                    sql = "SELECT DISTINCT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, * FROM " & _
                        "(SELECT t.nik, t.nama, t.departemen, t.status_karyawan, @tgl AS tgl1, " & _
                        "CONVERT(VARCHAR(50), A1.[timein], 108) AS in1, CONVERT(VARCHAR(50), A1.[timeout], 108)  AS out1, " & _
                        "(CASE WHEN C1.status <> 'catatan' THEN c1.status ELSE NULL END) as ket1, " & _
                        "DATEADD(day,1,@tgl) AS tgl2, CONVERT(VARCHAR(50), A2.[timein], 108) AS in2, " & _
                        "CONVERT(VARCHAR(50), A2.[timeout], 108)   AS out2, " & _
                        "(CASE WHEN C2.status <> 'catatan' THEN c2.status ELSE NULL END) as ket2, " & _
                        "DATEADD(day,2,@tgl)  AS tgl3, CONVERT(VARCHAR(50), A3.[timein], 108)   AS in3, " & _
                        "CONVERT(VARCHAR(50), A3.[timeout], 108)   AS out3, " & _
                        "(CASE WHEN C3.status <> 'catatan' THEN c3.status ELSE NULL END) as ket3, " & _
                        "DATEADD(day,3,@tgl)  AS tgl4, CONVERT(VARCHAR(50), A4.[timein], 108)   AS in4, " & _
                        "CONVERT(VARCHAR(50), A4.[timeout], 108)   AS out4, " & _
                        "(CASE WHEN C4.status <> 'catatan' THEN c4.status ELSE NULL END) as ket4 FROM view_dtpegawai t " & _
                        "OUTER APPLY (SELECT TOP 1 [nik], [tanggal], [timein],[timeout] FROM tbl_dataabsen " & _
                        "WHERE [nik] = t.nik AND [tanggal] = @tgl ) A1 " & _
                        "OUTER APPLY (SELECT TOP 1 [nik], [tanggal], [timein],[timeout] FROM tbl_dataabsen " & _
                        "WHERE [nik] = t.nik  AND [tanggal] = DATEADD(day,1,@tgl) ) A2 " & _
                        "OUTER APPLY (SELECT TOP 1 [nik], [tanggal], [timein],[timeout] " &
                        "FROM tbl_dataabsen WHERE [nik] = t.nik AND [tanggal] = DATEADD(day,2,@tgl) ) A3 " & _
                        "OUTER APPLY (SELECT TOP 1 [nik], [tanggal], [timein],[timeout] FROM tbl_dataabsen " & _
                        "WHERE [nik] = t.nik AND [tanggal] = DATEADD(day,3,@tgl) ) A4 " &
                        "OUTER APPLY ( SELECT TOP 1 [nik],[status] FROM tbl_rekapkerja " & _
                        "WHERE [nik] = t.nik AND [tanggal] = @tgl ) C1 " & _
                        "OUTER APPLY ( SELECT TOP 1 [nik],[status] FROM tbl_rekapkerja " & _
                        "WHERE [nik] = t.nik AND [tanggal] = DATEADD(day,1,@tgl) ) C2 " & _
                        "OUTER APPLY ( SELECT TOP 1 [nik],[status] FROM tbl_rekapkerja " & _
                        "WHERE [nik] = t.nik AND [tanggal] = DATEADD(day,2,@tgl) ) C3 " & _
                        "OUTER APPLY ( SELECT TOP 1 [nik],[status] FROM tbl_rekapkerja " & _
                        "WHERE [nik] = t.nik AND [tanggal] = DATEADD(day,3,@tgl)) C4) AS temp " & _
                        "WHERE temp.departemen = '" & combodept.Text & "'"
                Case "pencarian"
                    sql = "SELECT DISTINCT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, * FROM " & _
                        "(SELECT t.nik, t.nama, t.departemen, t.status_karyawan, @tgl AS tgl1, " & _
                        "CONVERT(VARCHAR(50), A1.[timein], 108) AS in1, CONVERT(VARCHAR(50), A1.[timeout], 108)  AS out1, " & _
                        "(CASE WHEN C1.status <> 'catatan' THEN c1.status ELSE NULL END) as ket1, " & _
                        "DATEADD(day,1,@tgl) AS tgl2, CONVERT(VARCHAR(50), A2.[timein], 108) AS in2, " & _
                        "CONVERT(VARCHAR(50), A2.[timeout], 108)   AS out2, " & _
                        "(CASE WHEN C2.status <> 'catatan' THEN c2.status ELSE NULL END) as ket2, " & _
                        "DATEADD(day,2,@tgl)  AS tgl3, CONVERT(VARCHAR(50), A3.[timein], 108)   AS in3, " & _
                        "CONVERT(VARCHAR(50), A3.[timeout], 108)   AS out3, " & _
                        "(CASE WHEN C3.status <> 'catatan' THEN c3.status ELSE NULL END) as ket3, " & _
                        "DATEADD(day,3,@tgl)  AS tgl4, CONVERT(VARCHAR(50), A4.[timein], 108)   AS in4, " & _
                        "CONVERT(VARCHAR(50), A4.[timeout], 108)   AS out4, " & _
                        "(CASE WHEN C4.status <> 'catatan' THEN c4.status ELSE NULL END) as ket4 FROM view_dtpegawai t " & _
                        "OUTER APPLY (SELECT TOP 1 [nik], [tanggal], [timein],[timeout] FROM tbl_dataabsen " & _
                        "WHERE [nik] = t.nik AND [tanggal] = @tgl ) A1 " & _
                        "OUTER APPLY (SELECT TOP 1 [nik], [tanggal], [timein],[timeout] FROM tbl_dataabsen " & _
                        "WHERE [nik] = t.nik  AND [tanggal] = DATEADD(day,1,@tgl) ) A2 " & _
                        "OUTER APPLY (SELECT TOP 1 [nik], [tanggal], [timein],[timeout] " &
                        "FROM tbl_dataabsen WHERE [nik] = t.nik AND [tanggal] = DATEADD(day,2,@tgl) ) A3 " & _
                        "OUTER APPLY (SELECT TOP 1 [nik], [tanggal], [timein],[timeout] FROM tbl_dataabsen " & _
                        "WHERE [nik] = t.nik AND [tanggal] = DATEADD(day,3,@tgl) ) A4 " &
                        "OUTER APPLY ( SELECT TOP 1 [nik],[status] FROM tbl_rekapkerja " & _
                        "WHERE [nik] = t.nik AND [tanggal] = @tgl ) C1 " & _
                        "OUTER APPLY ( SELECT TOP 1 [nik],[status] FROM tbl_rekapkerja " & _
                        "WHERE [nik] = t.nik AND [tanggal] = DATEADD(day,1,@tgl) ) C2 " & _
                        "OUTER APPLY ( SELECT TOP 1 [nik],[status] FROM tbl_rekapkerja " & _
                        "WHERE [nik] = t.nik AND [tanggal] = DATEADD(day,2,@tgl) ) C3 " & _
                        "OUTER APPLY ( SELECT TOP 1 [nik],[status] FROM tbl_rekapkerja " & _
                        "WHERE [nik] = t.nik AND [tanggal] = DATEADD(day,3,@tgl)) C4) AS temp " & _
                        "WHERE temp.nama LIKE '%" & Text_pencarian.Text & "%' OR temp.nik LIKE '%" & Text_pencarian.Text & "%'"
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@tgl", SqlDbType.Date).Value = DTgl.Text
            End With
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            grid.DataSource = DTab
            atur_grid(grid_absen)
            color_grid(grid_absen)
            grid.Refresh()
        Catch ex As Exception
            MsgBox("gagal dalam menampilkan data " & ex.Message)
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub atur_grid(ByVal grid As DataGridView)
        With grid
            .ReadOnly = True
            .Enabled = True
            .Columns(0).HeaderText = "No"
            .Columns(0).Width = "30"
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).Frozen = True
            .Columns(1).HeaderText = "NIK"
            .Columns(1).Width = "80"
            .Columns(1).Frozen = True
            .Columns(2).HeaderText = "Nama"
            .Columns(2).Width = "180"
            .Columns(2).Frozen = True
            .Columns(3).HeaderText = "Departemen"
            .Columns(3).Width = "100"
            .Columns(4).HeaderText = "status karyawan"
            .Columns(4).Visible = False
            .Columns(5).HeaderText = "tanggal"
            .Columns(5).Width = "80"
            .Columns(6).HeaderText = "timein"
            .Columns(6).Width = "80"
            .Columns(7).HeaderText = "timeout"
            .Columns(7).Width = "80"
            .Columns(8).HeaderText = "ket"
            .Columns(8).Width = "120"
            .Columns(9).HeaderText = "tanggal"
            .Columns(9).Width = "80"
            .Columns(10).HeaderText = "timein"
            .Columns(10).Width = "80"
            .Columns(11).HeaderText = "timeout"
            .Columns(11).Width = "80"
            .Columns(12).HeaderText = "ket"
            .Columns(12).Width = "120"
            .Columns(13).HeaderText = "tanggal"
            .Columns(13).Width = "80"
            .Columns(14).HeaderText = "timein"
            .Columns(14).Width = "80"
            .Columns(15).HeaderText = "timeout"
            .Columns(15).Width = "80"
            .Columns(16).HeaderText = "ket"
            .Columns(16).Width = "120"
            .Columns(17).HeaderText = "tanggal"
            .Columns(17).Width = "80"
            .Columns(18).HeaderText = "timein"
            .Columns(18).Width = "80"
            .Columns(19).HeaderText = "timeout"
            .Columns(19).Width = "80"
            .Columns(20).HeaderText = "ket"
            .Columns(20).Width = "120"
            .RowHeadersWidth = 5
        End With
    End Sub

    Private Sub color_grid(ByVal grid As DataGridView)
        With grid
            For A% = 0 To .Rows.Count - 1
                If CDate(.Rows(A).Cells(5).Value).AddDays(0).ToString("dddd") = "Sunday" Then
                    .Columns(5).DefaultCellStyle.BackColor = Color.LightYellow
                    .Columns(6).DefaultCellStyle.BackColor = Color.LightYellow
                    .Columns(7).DefaultCellStyle.BackColor = Color.LightYellow
                    .Columns(8).DefaultCellStyle.BackColor = Color.LightYellow
                Else
                    .Columns(5).DefaultCellStyle.BackColor = Color.White
                    .Columns(6).DefaultCellStyle.BackColor = Color.White
                    .Columns(7).DefaultCellStyle.BackColor = Color.White
                    .Columns(8).DefaultCellStyle.BackColor = Color.White
                End If
                If CDate(.Rows(A).Cells(9).Value).AddDays(0).ToString("dddd") = "Sunday" Then
                    .Columns(9).DefaultCellStyle.BackColor = Color.LightYellow
                    .Columns(10).DefaultCellStyle.BackColor = Color.LightYellow
                    .Columns(11).DefaultCellStyle.BackColor = Color.LightYellow
                    .Columns(12).DefaultCellStyle.BackColor = Color.LightYellow
                Else
                    .Columns(9).DefaultCellStyle.BackColor = Color.White
                    .Columns(10).DefaultCellStyle.BackColor = Color.White
                    .Columns(11).DefaultCellStyle.BackColor = Color.White
                    .Columns(12).DefaultCellStyle.BackColor = Color.White
                End If
                If CDate(.Rows(A).Cells(13).Value).AddDays(0).ToString("dddd") = "Sunday" Then
                    .Columns(13).DefaultCellStyle.BackColor = Color.LightYellow
                    .Columns(14).DefaultCellStyle.BackColor = Color.LightYellow
                    .Columns(15).DefaultCellStyle.BackColor = Color.LightYellow
                    .Columns(16).DefaultCellStyle.BackColor = Color.LightYellow
                Else
                    .Columns(13).DefaultCellStyle.BackColor = Color.White
                    .Columns(14).DefaultCellStyle.BackColor = Color.White
                    .Columns(15).DefaultCellStyle.BackColor = Color.White
                    .Columns(16).DefaultCellStyle.BackColor = Color.White
                End If
                If CDate(.Rows(A).Cells(17).Value).AddDays(0).ToString("dddd") = "Sunday" Then
                    .Columns(17).DefaultCellStyle.BackColor = Color.LightYellow
                    .Columns(18).DefaultCellStyle.BackColor = Color.LightYellow
                    .Columns(19).DefaultCellStyle.BackColor = Color.LightYellow
                    .Columns(20).DefaultCellStyle.BackColor = Color.LightYellow
                Else
                    .Columns(17).DefaultCellStyle.BackColor = Color.White
                    .Columns(18).DefaultCellStyle.BackColor = Color.White
                    .Columns(19).DefaultCellStyle.BackColor = Color.White
                    .Columns(20).DefaultCellStyle.BackColor = Color.White
                End If
            Next
            .Refresh()
        End With
    End Sub

    Private Sub Button_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_go.Click
        load_gridabsen(grid_absen, Nothing)
        Text_pencarian.Enabled = True
    End Sub

    Private Sub combo_dept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        load_gridabsen(grid_absen, "departemen")
    End Sub


    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        With grid_absen
            .ReadOnly = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
        End With
    End Sub



    Private Sub Text_pencarian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_pencarian.TextChanged
        load_gridabsen(grid_absen, "pencarian")
    End Sub

    '======create keypress event id cells datagridview ====================
    'Private WithEvents EditControl As DataGridViewTextBoxEditingControl

    'Private Sub grid_absen_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles grid_absen.EditingControlShowing
    'EditControl = CType(grid_absen.EditingControl, DataGridViewTextBoxEditingControl)
    'End Sub

    'Private Sub EditControl_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles EditControl.Leave
    'EditControl = Nothing
    'End Sub

    'Private Sub EditControl_PreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs) Handles EditControl.PreviewKeyDown
    'If e.KeyCode = Keys.Enter Then 'check if the Enter key is pressed
    'simpan update
    'Button1_Click_1(sender, e)
    ' update_data()
    'grid_absen.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    'End If
    'End Sub
    '=====end=============================================================

    Private Function update_data() As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "UPDATE tbl_dataabsen SET timein = @timein, timeout = @timeout " & _
                "WHERE nik = @nik AND tanggal = @tanggal"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = grid_absen.Rows(baris).Cells(1).Value
                .Add("@tanggal", SqlDbType.Date).Value = grid_absen.Rows(baris).Cells(5).Value
                .Add("@timein", SqlDbType.Time).Value = grid_absen.Rows(baris).Cells(6).Value
                .Add("@timeout", SqlDbType.Time).Value = grid_absen.Rows(baris).Cells(7).Value
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam update data absen " & ex.Message)
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function update_tblrekapkerja() As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "UPDATE tbl_rekapkerja SET status = @status WHERE nik = @nik AND tanggal = @tanggal"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = grid_absen.Rows(baris).Cells(1).Value
                .Add("@tanggal", SqlDbType.Date).Value = grid_absen.Rows(baris).Cells(6).Value
                .Add("@tstatus", SqlDbType.VarChar).Value = grid_absen.Rows(baris).Cells(8).Value
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam update data di tabel rekap kerja " & ex.Message)
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function simpan_tblrekapkerja(ByVal grid As DataGridView) As Boolean
        Try
            Dim kolom% = grid.CurrentCell.ColumnIndex
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "INSERT INTO tbl_rekapkerja(nik,tanggal,status) VALUES(@nik, @tanggal, @status)"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                If Not IsDBNull(grid.Rows(baris).Cells(8).Value) Then
                    If grid.Rows(baris).Cells(8).Value = "libur" Then
                        .Add("@nik", SqlDbType.VarChar).Value = grid.Rows(baris).Cells(1).Value
                        .Add("@tanggal", SqlDbType.Date).Value = grid.Rows(baris).Cells(6).Value
                        .Add("@status", SqlDbType.VarChar).Value = grid.Rows(baris).Cells(8).Value
                    End If
                ElseIf Not IsDBNull(grid.Rows(baris).Cells(12).Value) Then
                    If grid.Rows(baris).Cells(12).Value = "libur" Then
                        .Add("@nik", SqlDbType.VarChar).Value = grid.Rows(baris).Cells(1).Value
                        .Add("@tanggal", SqlDbType.Date).Value = grid.Rows(baris).Cells(9).Value
                        .Add("@status", SqlDbType.VarChar).Value = grid.Rows(baris).Cells(12).Value
                    End If
                ElseIf Not IsDBNull(grid.Rows(baris).Cells(16).Value) Then
                    If grid.Rows(baris).Cells(16).Value = "libur" Then
                        .Add("@nik", SqlDbType.VarChar).Value = grid.Rows(baris).Cells(1).Value
                        .Add("@tanggal", SqlDbType.Date).Value = grid.Rows(baris).Cells(13).Value
                        .Add("@status", SqlDbType.VarChar).Value = grid.Rows(baris).Cells(16).Value
                    End If
                ElseIf Not IsDBNull(grid.Rows(baris).Cells(20).Value) Then
                    If grid.Rows(baris).Cells(20).Value = "libur" Then
                        .Add("@nik", SqlDbType.VarChar).Value = grid.Rows(baris).Cells(1).Value
                        .Add("@tanggal", SqlDbType.Date).Value = grid.Rows(baris).Cells(17).Value
                        .Add("@status", SqlDbType.VarChar).Value = grid.Rows(baris).Cells(20).Value
                    End If
                End If
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam penyimpanan data di tabel rekap kerja " & ex.Message)
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function


    Private Sub grid_absen_Endedit(ByVal sender As Object, ByVal e As System.EventArgs) Handles grid_absen.CellEndEdit
        Dim kolom% = grid_absen.CurrentCell.ColumnIndex
        Select Case kolom
            Case 6
                If MsgBox("Update data untuk kolom time in ? ", MsgBoxStyle.Information & vbOKCancel, "INFO") = MsgBoxResult.Ok Then
                    If update_data() = True Then
                        MsgBox("Data time in berhasil di update ")
                    End If
                End If
            Case 7
                If MsgBox("Update data untuk kolom time out ? ", MsgBoxStyle.Information & vbOKCancel, "INFO") = MsgBoxResult.Ok Then
                    If update_data() = True Then
                        MsgBox("Data time out berhasil di update ")
                    End If
                End If
            Case 8
                If IsDBNull(grid_absen.Rows(baris).Cells(8).Value) Then
                    If MsgBox("Update data keterangan menjadi 'libur' ? ", MsgBoxStyle.Information & vbOKCancel, "INFO") = MsgBoxResult.Ok Then
                        If simpan_tblrekapkerja(grid_absen) = True Then
                            MsgBox("Data telah berhasil di update ")
                        End If
                    End If
                ElseIf grid_absen.Rows(baris).Cells(8).Value = "libur" Then
                    If MsgBox("Update data keterangan menjadi 'libur' ? ", MsgBoxStyle.Information & vbOKCancel, "INFO") = MsgBoxResult.Ok Then
                        If simpan_tblrekapkerja(grid_absen) = True Then
                            MsgBox("Data telah berhasil di update ")
                        End If
                    End If
                    Else
                        MsgBox("Hanya bisa di  input libur", MsgBoxStyle.Information & vbOKCancel, "INFO")
                End If
            Case 12
                If IsDBNull(grid_absen.Rows(baris).Cells(12).Value) Then
                    If MsgBox("Update data keterangan menjadi 'libur' ? ", MsgBoxStyle.Information & vbOKCancel, "INFO") = MsgBoxResult.Ok Then
                        If simpan_tblrekapkerja(grid_absen) = True Then
                            MsgBox("Data telah berhasil di update ")
                        End If
                    End If
                ElseIf grid_absen.Rows(baris).Cells(12).Value = "libur" Then
                    If MsgBox("Update data keterangan menjadi 'libur' ? ", MsgBoxStyle.Information & vbOKCancel, "INFO") = MsgBoxResult.Ok Then
                        If simpan_tblrekapkerja(grid_absen) = True Then
                            MsgBox("Data telah berhasil di update ")
                        End If
                    End If
                Else
                    MsgBox("Hanya bisa di  input libur", MsgBoxStyle.Information & vbOKCancel, "INFO")
                End If
            Case 16
                If IsDBNull(grid_absen.Rows(baris).Cells(16).Value) Then
                    If MsgBox("Update data keterangan menjadi 'libur' ? ", MsgBoxStyle.Information & vbOKCancel, "INFO") = MsgBoxResult.Ok Then
                        If simpan_tblrekapkerja(grid_absen) = True Then
                            MsgBox("Data telah berhasil di update ")
                        End If
                    End If
                ElseIf grid_absen.Rows(baris).Cells(16).Value = "libur" Then
                    If MsgBox("Update data keterangan menjadi 'libur' ? ", MsgBoxStyle.Information & vbOKCancel, "INFO") = MsgBoxResult.Ok Then
                        If simpan_tblrekapkerja(grid_absen) = True Then
                            MsgBox("Data telah berhasil di update ")
                        End If
                    End If
                Else
                    MsgBox("Hanya bisa di  input libur", MsgBoxStyle.Information & vbOKCancel, "INFO")
                End If
            Case 20
                If IsDBNull(grid_absen.Rows(baris).Cells(20).Value) Then
                    If MsgBox("Update data keterangan menjadi 'libur' ? ", MsgBoxStyle.Information & vbOKCancel, "INFO") = MsgBoxResult.Ok Then
                        If simpan_tblrekapkerja(grid_absen) = True Then
                            MsgBox("Data telah berhasil di update ")
                        End If
                    End If
                ElseIf grid_absen.Rows(baris).Cells(20).Value = "libur" Then
                    If MsgBox("Update data keterangan menjadi 'libur' ? ", MsgBoxStyle.Information & vbOKCancel, "INFO") = MsgBoxResult.Ok Then
                        If simpan_tblrekapkerja(grid_absen) = True Then
                            MsgBox("Data telah berhasil di update ")
                        End If
                    End If
                Else
                    MsgBox("Hanya bisa di  input libur", MsgBoxStyle.Information & vbOKCancel, "INFO")
                End If
        End Select

        grid_absen.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub grid_absen_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_absen.CellContentClick

    End Sub

    Private Sub FormDaftarAbsensiFull_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clear_date(Me, Nothing)
        Application.CurrentCulture = New CultureInfo("id-ID")
        load_combo(combodept, "departemen", "tbl_jabatan")
        Text_pencarian.Enabled = False
    End Sub

    Private Sub combo_dept_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DTgl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTgl.ValueChanged
        format_tanggal(DTgl)
    End Sub

    Private Sub combodept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combodept.SelectedIndexChanged
        load_gridabsen(grid_absen, "departemen")
    End Sub

    Private Sub grid_absen_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grid_absen.CellMouseUp
        With grid_absen
            If e.Button = MouseButtons.Right Then
                If .Rows.Count > 1 Then
                    .ContextMenuStrip = ContextMenuStrip1
                    baris = .CurrentRow.Index
                    nik_global = .Rows(baris).Cells(1).Value
                    Me.ContextMenuStrip1.Show(Me.grid_absen, e.Location)
                    Me.ContextMenuStrip1.Show(Cursor.Position)
                Else
                    .ContextMenuStrip = Nothing
                End If
            End If
        End With
    End Sub
End Class