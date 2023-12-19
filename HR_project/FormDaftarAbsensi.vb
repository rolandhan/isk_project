Imports System.Data.Sql
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Globalization
Public Class FormDaftarAbsensi

    Dim baris As Integer
    Private Sub FormDaftarAbsensi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New CultureInfo("id-ID")
        format_tanggal_kosong(DTanggal)
        load_combo(combo_dept, "departemen", "tbl_jabatan")
        Text_pencarian.Enabled = False
    End Sub

    Private Sub load_gridabsen(ByVal grid As DataGridView, ByVal opt As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            Select Case opt
                Case String.Empty
                    sql = "SELECT DISTINCT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, " & _
                        "temp.nik, temp.nama, temp.departemen , temp.status_karyawan , temp.tanggal, " & _
                        "CONVERT(VARCHAR(50), temp.timein, 108) as timein, " & _
                        "CONVERT(VARCHAR(50), temp.timeout, 108) as timeout, " & _
                        "(CASE WHEN tbl_rekapkerja.status <> 'catatan' THEN tbl_rekapkerja.status ELSE NULL END) as ket FROM " & _
                        "(SELECT view_dtpegawai.nik, view_dtpegawai.nama, view_dtpegawai.departemen, " & _
                        "view_dtpegawai.status_karyawan, @tanggal as tanggal, absen.timein, absen.timeout FROM " & _
                        "(SELECT tbl_dataabsen.nik, tbl_dataabsen.tanggal, tbl_dataabsen.timein, tbl_dataabsen.timeout " & _
                        "FROM tbl_dataabsen WHERE tbl_dataabsen.tanggal = @tanggal) AS absen " & _
                        "RIGHT OUTER JOIN view_dtpegawai ON absen.nik = view_dtpegawai.nik) as temp " & _
                        "LEFT OUTER JOIN tbl_rekapkerja ON temp.nik = tbl_rekapkerja .nik AND " & _
                        "temp.tanggal = tbl_rekapkerja.tanggal order by temp.nik"
                Case "departemen"
                    sql = "SELECT DISTINCT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, " & _
                        "temp.nik, temp.nama, temp.departemen , temp.status_karyawan , temp.tanggal, " & _
                        "CONVERT(VARCHAR(50), temp.timein, 108) as timein, " & _
                        "CONVERT(VARCHAR(50), temp.timeout, 108) as timeout, " & _
                        "(CASE WHEN tbl_rekapkerja.status <> 'catatan' THEN tbl_rekapkerja.status ELSE NULL END) as ket FROM " & _
                        "(SELECT view_dtpegawai.nik, view_dtpegawai.nama, view_dtpegawai.departemen, " & _
                        "view_dtpegawai.status_karyawan, @tanggal as tanggal, absen.timein, absen.timeout FROM " & _
                        "(SELECT tbl_dataabsen.nik, tbl_dataabsen.tanggal, tbl_dataabsen.timein, tbl_dataabsen.timeout " & _
                        "FROM tbl_dataabsen WHERE tbl_dataabsen.tanggal = @tanggal) AS absen " & _
                        "RIGHT OUTER JOIN view_dtpegawai ON absen.nik = view_dtpegawai.nik) as temp " & _
                        "LEFT OUTER JOIN tbl_rekapkerja ON temp.nik = tbl_rekapkerja .nik AND " & _
                        "temp.tanggal = tbl_rekapkerja.tanggal WHERE temp.departemen = '" & combo_dept.Text & "' " & _
                        "order by temp.nik"
                Case "pencarian"
                    sql = "SELECT DISTINCT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, " & _
                        "temp.nik, temp.nama, temp.departemen , temp.status_karyawan , temp.tanggal, " & _
                        "CONVERT(VARCHAR(50), temp.timein, 108) as timein, " & _
                        "CONVERT(VARCHAR(50), temp.timeout, 108) as timeout, " & _
                        "(CASE WHEN tbl_rekapkerja.status <> 'catatan' THEN tbl_rekapkerja.status ELSE NULL END) as ket FROM " & _
                        "(SELECT view_dtpegawai.nik, view_dtpegawai.nama, view_dtpegawai.departemen, " & _
                        "view_dtpegawai.status_karyawan, @tanggal as tanggal, absen.timein, absen.timeout FROM " & _
                        "(SELECT tbl_dataabsen.nik, tbl_dataabsen.tanggal, tbl_dataabsen.timein, tbl_dataabsen.timeout " & _
                        "FROM tbl_dataabsen WHERE tbl_dataabsen.tanggal = @tanggal) AS absen " & _
                        "RIGHT OUTER JOIN view_dtpegawai ON absen.nik = view_dtpegawai.nik) as temp " & _
                        "LEFT OUTER JOIN tbl_rekapkerja ON temp.nik = tbl_rekapkerja .nik AND " & _
                        "temp.tanggal = tbl_rekapkerja.tanggal WHERE temp.nama LIKE  '%" & Text_pencarian.Text & "%' OR temp.NIK LIKE '%" & Text_pencarian.Text & "%' " & _
                        "order by temp.nik"
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("tanggal", SqlDbType.Date).Value = DTanggal.Text
            End With
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            grid.DataSource = DTab
            atur_grid(grid_absen)
            grid.Refresh()
        Catch ex As Exception
            MsgBox("gagal dalam menampilkan data " & ex.Message, "INFO")
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
            .Columns(5).HeaderText = "Tanggal"
            .Columns(5).Width = "80"
            .Columns(6).HeaderText = "timein"
            .Columns(6).Width = "80"
            .Columns(7).HeaderText = "timeout"
            .Columns(7).Width = "80"
            .Columns(8).HeaderText = "ket"
            .Columns(8).Width = "120"
            .RowHeadersWidth = 5
        End With
    End Sub

    Private Sub DTanggal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTanggal.ValueChanged
        format_tanggal(DTanggal)
    End Sub

    Private Sub Button_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_go.Click
        load_gridabsen(grid_absen, Nothing)
        Text_pencarian.Enabled = True
    End Sub

    Private Sub combo_dept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_dept.SelectedIndexChanged
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

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        With grid_absen
            .ReadOnly = False
            .SelectionMode = DataGridViewSelectionMode.CellSelect
        End With
    End Sub

    

    Private Sub Text_pencarian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_pencarian.TextChanged
        load_gridabsen(grid_absen, "pencarian")
    End Sub

    '======create leypress event id cells datagridview ====================
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

    Private Function simpan_tblrekapkerja() As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "INSER INTO tbl_rekapkerja(nik,tanggal,status) VALUES(@nik, @tanggal, @status)"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = grid_absen.Rows(baris).Cells(1).Value
                .Add("@tanggal", SqlDbType.Date).Value = grid_absen.Rows(baris).Cells(6).Value
                .Add("@satus", SqlDbType.VarChar).Value = grid_absen.Rows(baris).Cells(8).Value
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam pneyimpanan data di tabel rekap kerja " & ex.Message)
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
                        If simpan_tblrekapkerja() = True Then
                            MsgBox("Data telah berhasil di update ")
                        End If
                    End If
                ElseIf grid_absen.Rows(baris).Cells(8).Value = "Libur" Then
                    MsgBox("Update data keterangan menjadi 'libur' ? ", MsgBoxStyle.Information & vbOKCancel, "INFO")
                Else
                    MsgBox("Hanya bisa di  input libur", MsgBoxStyle.Information & vbOKCancel, "INFO")

                End If
        End Select

        grid_absen.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub grid_absen_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_absen.CellContentClick

    End Sub
End Class