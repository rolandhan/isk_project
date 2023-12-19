Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization

Public Class FormEditDtPeg

    Dim rowindex, info_ As Integer
    Dim edit_tools, status_, no_urut As String
    Dim datatab2, DtTab_cont As DataTable
    Private Sub FormEditDtPeg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New CultureInfo("id-ID")
        load_gridkaryawan(Nothing)
        load_combo(Combo_depart, "departemen", "tbl_statuskerja")
    End Sub

    Private Sub load_gridkaryawan(ByVal cond_dept As String)
        Try
            clear_command()
            openDB()
            Cursor.Current = Cursors.WaitCursor
            If cond_dept = String.Empty Then
                sql = "select nik, nama, departemen, jabatan, status_karyawan, atasan from view_pegawai"
            Else
                sql = "select nik, nama, departemen, jabatan, status_karyawan, atasan from view_pegawai " & _
                    "where departemen = '" & cond_dept & "'"
            End If
            sqladapter = New SqlDataAdapter(sql, Conn)
            dtset = New DataSet
            dtset.Clear()
            sqladapter.Fill(dtset, "view_pegawai")
            grid_karyawan.DataSource = dtset.Tables("view_pegawai")
            atur_gridkary()
            grid_karyawan.Refresh()
        Catch ex As Exception
            MsgBox("gagal menampilkan data", MsgBoxStyle.Information, "INFO")
        Finally
            Cursor.Current = Cursors.Arrow
            Conn.Close()
        End Try

    End Sub

    Public Sub load_editdatapeg(ByVal nik As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "select nik, nama, departemen, jabatan, status_karyawan, atasan from view_pegawai WHERE nik = @nik"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = nik
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                Text_nik.Text = nik
                Text_nama.Text = sqlreader.Item("nama")
                Combo_departemen.Text = sqlreader.Item("departemen")
                Text_Atasan.Text = sqlreader.Item("atasan")
                Combo_status.Text = sqlreader.Item("status_karyawan")
            End If
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data " & ex.Message)
        Finally
            Conn.Close()
        End Try

        'cek data tanggal recruitmen dan lainnya
        With grid_recruit
            If .RowCount > 0 Then
                .DataSource = Nothing
                .Columns.Clear()
                .Refresh()
                load_gridrecruit()
            Else
                load_gridrecruit()
            End If
        End With
        'cek riwayat jabatan
        With grid_jabatan
            If .RowCount > 0 Then
                .DataSource = Nothing
                .Columns.Clear()
                .Refresh()
                load_gridjabatan()
            Else
                load_gridjabatan()
            End If
        End With

        'cek riwayat harian
        With grid_harian
            If .RowCount > 0 Then
                .DataSource = Nothing
                .Columns.Clear()
                .Refresh()
                load_gridharian()
            Else
                load_gridharian()
            End If
        End With
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub atur_gridkary()
        With grid_karyawan
            .ReadOnly = True
            .Enabled = True
            .Columns(0).HeaderText = "NIK"
            .Columns(0).Width = "60"
            .Columns(1).HeaderText = "Nama"
            .Columns(1).Width = "180"
            .Columns(2).HeaderText = "Departemen"
            .Columns(2).Width = "105"
            .Columns(3).HeaderText = "Jabatan"
            .Columns(3).Width = "155"
            .Columns(4).HeaderText = "status"
            .Columns(4).Width = "60"
            .Columns(5).HeaderText = "atasan"
            .Columns(5).Width = "75"
            .RowHeadersWidth = 5
        End With
    End Sub

    Private Sub atur_gridrecruit()
        With grid_recruit
            .ReadOnly = True
            .Enabled = True
            .Columns(0).HeaderText = "NIK"
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Tgl Recruit"
            .Columns(1).Width = "90"
            .Columns(2).HeaderText = "Tgl Harian"
            .Columns(2).Width = "90"
            .Columns(3).HeaderText = "Tgl Borongan"
            .Columns(3).Width = "90"
            .Columns(4).HeaderText = "Tgl Kontrak"
            .Columns(4).Width = "90"
            .Columns(5).HeaderText = "Tgl tetap"
            .Columns(5).Width = "90"
            .Columns(6).HeaderText = "Tgl Keluar"
            .Columns(6).Width = "90"
            'Dim btn As New DataGridViewButtonColumn()
            '.Columns.Add(btn)
            'btn.HeaderText = "Click Data"
            'btn.Text = "simpan"
            'btn.Name = "btn"
            'btn.UseColumnTextForButtonValue = True
            .RowHeadersWidth = 7

        End With
    End Sub

    Private Sub atur_gridjabatan()
        With grid_jabatan
            .ReadOnly = True
            .Enabled = True
            .Columns(0).HeaderText = "NIK"
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "Departemen"
            .Columns(1).Width = "100"
            .Columns(2).HeaderText = "Jabatan"
            .Columns(2).Width = "180"
            .Columns(3).HeaderText = "Status"
            .Columns(3).Width = "60"
            .Columns(4).HeaderText = "Tgl Awal"
            .Columns(4).Width = "65"
            .Columns(5).HeaderText = "Tgl Akhir"
            .Columns(5).Width = "65"
            .Columns(6).HeaderText = "Atasan"
            .Columns(6).Width = "130"
            .Columns(7).HeaderText = "No Urut"
            .Columns(7).Visible = False
            .Columns(8).HeaderText = "NIK Lama"
            .Columns(8).Width = "60"
            'Dim btn As New DataGridViewButtonColumn()
            '.Columns.Add(btn)
            '.Columns(8).Width = "45"
            'btn.HeaderText = "Click Data"
            'btn.Text = "simpan"
            'btn.Name = "btn"
            'btn.UseColumnTextForButtonValue = True
            .RowHeadersWidth = 8
        End With
    End Sub

    Private Sub atur_gridharian()
        With grid_harian
            .ReadOnly = True
            .Enabled = True
            .Columns(0).HeaderText = "NIK"
            .Columns(0).Visible = False
            .Columns(1).HeaderText = "No urut"
            .Columns(1).Width = "100"
            .Columns(2).HeaderText = "Tanggal Masuk"
            .Columns(2).Width = "100"
            .Columns(3).HeaderText = "Tanggal Keluar"
            .Columns(3).Width = "100"
            .RowHeadersWidth = 4
        End With
    End Sub

    Private Sub Combo_depart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_depart.SelectedIndexChanged
        load_gridkaryawan(Combo_depart.Text)
    End Sub

    Private Sub grid_karyawan_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_karyawan.CellContentDoubleClick
        Try
            Cursor.Current = Cursors.WaitCursor
            With grid_karyawan
                rowindex = .CurrentRow.Index
                Text_nik.Text = .Rows(rowindex).Cells(0).Value
                nik_global = .Rows(rowindex).Cells(0).Value
                Text_nama.Text = .Rows(rowindex).Cells(1).Value
                Combo_departemen.Text = .Rows(rowindex).Cells(2).Value
                Text_Atasan.Text = .Rows(rowindex).Cells(5).Value
                Combo_status.Text = .Rows(rowindex).Cells(4).Value
            End With
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data", MsgBoxStyle.Information, "INFO")
        Finally
            Cursor.Current = Cursors.Arrow
        End Try

        'cek data tanggal recruitmen dan lainnya
        With grid_recruit
            If .RowCount > 0 Then
                .DataSource = Nothing
                .Columns.Clear()
                .Refresh()
                load_gridrecruit()
            Else
                load_gridrecruit()
            End If
        End With
        'cek riwayat jabatan
        With grid_jabatan
            If .RowCount > 0 Then
                .DataSource = Nothing
                .Columns.Clear()
                .Refresh()
                load_gridjabatan()
            Else
                load_gridjabatan()
            End If
        End With

        'cek riwayat harian
        With grid_harian
            If .RowCount > 0 Then
                .DataSource = Nothing
                .Columns.Clear()
                .Refresh()
                load_gridharian()
            Else
                load_gridharian()
            End If
        End With

    End Sub

    Private Sub load_gridrecruit()
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()

            sql = "SELECT  nik, CONVERT(varchar, tgl_masuk_rec, 105) AS tgl_masuk_rec, " & _
                "CONVERT(varchar, tgl_masuk_harian, 105) AS tgl_harian, " & _
                "CONVERT(varchar, tgl_borongan, 105) AS tgl_borongan, CONVERT(varchar, tgl_kontrak, 105) AS tgl_kontrak, " & _
                "CONVERT(varchar, tgl_tetap, 105) AS tgl_tetap, CONVERT(varchar, tgl_keluar, 105) AS tgl_keluar " & _
                "FROM tbl_tanggalkerja WHERE nik = '" & nik_global & "'"
            sqlcmd = New SqlCommand(sql)
            sqladapter = New SqlDataAdapter(sql, Conn)
            DataTab = New DataTable
            DataTab.Clear()
            sqladapter.Fill(DataTab)
            grid_recruit.DataSource = DataTab
            atur_gridrecruit()
            grid_recruit.Refresh()
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data tanggal " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
            Cursor.Current = Cursors.WaitCursor
        End Try
    End Sub

    Private Sub load_gridjabatan()
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "SELECT nik, departemen, jabatan, status_karyawan, CONVERT(varchar, tgl_awal, 105) AS tgl_awal, " & _
                "CONVERT(varchar, tgl_akhir, 105) AS tgl_akhir, atasan, no_urut, nik_lama  FROM tbl_jabatan " & _
                "WHERE (nik_lama = (SELECT TOP (1) nik_lama  FROM tbl_jabatan WHERE nik = @nik) OR LEFT(no_urut,6) = @nik ) ORDER BY no_urut DESC"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = nik_global
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            datatab2 = New DataTable
            DtTab_cont = New DataTable
            datatab2.Clear()
            DtTab_cont.Clear()
            sqladapter.Fill(datatab2)
            sqladapter.Fill(DtTab_cont)
            grid_jabatan.DataSource = datatab2
            atur_gridjabatan()
            grid_jabatan.Refresh()
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data jabatan " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Private Sub load_gridharian()
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "SELECT nik, no_urut, tgl_masuk, tgl_keluar FROM tbl_tglharians " & _
                "WHERE nik = '" & nik_global & "' ORDER BY no_urut"
            sqladapter = New SqlDataAdapter(sql, Conn)
            DataTab = New DataTable
            DataTab.Clear()
            sqladapter.Fill(DataTab)
            grid_harian.DataSource = DataTab
            atur_gridharian()
            grid_harian.Refresh()
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data harian " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub grid_karyawan_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_karyawan.CellContentClick

    End Sub

    Private Sub EditDataToolStripMenuItem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles EditDataToolStripMenuItem.DoubleClick

    End Sub

    Private Sub grid_recruit_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grid_recruit.CellMouseUp
        With grid_recruit
            If e.Button = MouseButtons.Right Then
                If .Rows.Count > 1 Then
                    edit_tools = "recruit"
                    .ContextMenuStrip = ContextMenuStrip1
                    rowindex = .CurrentRow.Index
                    Me.ContextMenuStrip1.Show(Me.grid_recruit, e.Location)
                    Me.ContextMenuStrip1.Show(Cursor.Position)
                    Me.HapusDataToolStripMenuItem.Visible = False
                    Me.TambahDataToolStripMenuItem.Visible = False
                Else
                    .ContextMenuStrip = Nothing
                End If
            End If
        End With
    End Sub

    Private Sub grid_jabatan_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_jabatan.CellContentDoubleClick
        With grid_jabatan
                If .Rows.Count > 1 Then
                    If e.ColumnIndex = 8 Then
                        If MsgBox("Apakah data siap di update?", MsgBoxStyle.OkCancel, "INFO") = vbOK Then
                            'update data
                            Try
                                clear_command()
                                openDB()
                                For A = 0 To .Rows.Count - 2
                                sql = "UPDATE tbl_jabatan SET departemen, jabatan, status_karyawan, " & _
                                    "tgl_awal, tgl_akhir, atasan " & _
                                    "WHERE nik = @nik_lama and no_urut = @no_urut"
                                    sqlcmd = New SqlCommand(sql, Conn)
                                sqlcmd.Parameters.Add("@nik_lama", SqlDbType.VarChar).Value = Text_nik.Text
                                    sqlcmd.Parameters.Add("@departemen", SqlDbType.VarChar).Value = .Rows(A).Cells(1).Value
                                    sqlcmd.Parameters.Add("@jabatan", SqlDbType.VarChar).Value = .Rows(A).Cells(2).Value
                                    sqlcmd.Parameters.Add("@status_karyawan", SqlDbType.VarChar).Value = .Rows(A).Cells(3).Value
                                If IsDBNull(.Rows(A).Cells(4).Value) Then
                                    sqlcmd.Parameters.Add("@tgl_awal", SqlDbType.Date).Value = DBNull.Value
                                Else
                                    sqlcmd.Parameters.Add("@tgl_awal", SqlDbType.Date).Value = CDate(.Rows(A).Cells(4).Value)
                                End If
                                If IsDBNull(.Rows(A).Cells(5).Value) Then
                                    sqlcmd.Parameters.Add("@tgl_akhir", SqlDbType.Date).Value = DBNull.Value
                                Else
                                    sqlcmd.Parameters.Add("@tgl_akhir", SqlDbType.Date).Value = CDate(.Rows(A).Cells(5).Value)
                                End If
                                    sqlcmd.Parameters.Add("@atasan", SqlDbType.VarChar).Value = .Rows(A).Cells(6).Value
                                    sqlcmd.Parameters.Add("@no_urut", SqlDbType.VarChar).Value = .Rows(A).Cells(7).Value
                                    sqlcmd.ExecuteNonQuery()
                                Next A
                                MsgBox("Data jabatan telah berhasil di update", MsgBoxStyle.Information, "INFO")
                            Catch ex As Exception
                                MsgBox("Gagal dalam update data tanggal jabatan kerja " & ex.Message, MsgBoxStyle.Information, "INFO")
                                info_ = 0
                            Finally
                                Conn.Close()
                            End Try
                            'reload grid_recruit
                            load_gridjabatan()
                            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        Else
                            load_gridjabatan()
                            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        End If
                    End If
                Else
                    grid_jabatan.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
                    grid_jabatan.ReadOnly = False
                    status_ = "edit"
                End If
        End With

    End Sub


    Private Sub grid_jabatan_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grid_jabatan.CellMouseUp
        With grid_jabatan
            If e.Button = MouseButtons.Right Then
                If .Rows.Count > 1 Then
                    edit_tools = "jabatan"
                    ContextMenuStrip = ContextMenuStrip1
                    rowindex = .CurrentRow.Index
                    Me.ContextMenuStrip1.Show(Me.grid_jabatan, e.Location)
                    Me.ContextMenuStrip1.Show(Cursor.Position)
                End If
            Else
                ContextMenuStrip = Nothing
            End If
        End With
    End Sub

    Private Sub grid_harian_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_harian.CellContentDoubleClick
        grid_harian.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
        grid_harian.ReadOnly = False
    End Sub

    Private Sub grid_harian_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grid_harian.CellMouseUp
        With grid_harian
            If e.Button = MouseButtons.Right Then
                If .Rows.Count > 1 Then
                    edit_tools = "harian"
                    .ContextMenuStrip = ContextMenuStrip1
                    rowindex = .CurrentRow.Index
                    Me.ContextMenuStrip1.Show(Me.grid_harian, e.Location)
                    Me.ContextMenuStrip1.Show(Cursor.Position)
                Else
                    .ContextMenuStrip = Nothing
                End If
            End If
        End With
    End Sub

    Private Sub EditDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditDataToolStripMenuItem.Click

    End Sub

    Private Sub grid_recruit_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grid_recruit.DoubleClick
        grid_recruit.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
        grid_recruit.ReadOnly = False
        status_ = "edit"
    End Sub

    'Private Sub grid_jabatan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grid_jabatan.KeyDown
    'If e.KeyCode = Keys.Then Then
    '       If grid_recruit.ReadOnly = True Then
    '           e.SuppressKeyPress = True
    '           MsgBox("sukses")
    '           grid_recruit.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    '           grid_recruit.ReadOnly = True
    '       End If
    'End If
    'End Sub

    'Private WithEvents txtmontant As DataGridViewTextBoxEditingControl
    'Private Sub grid_jabatan_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles grid_jabatan.EditingControlShowing
    '    If grid_jabatan.CurrentCell.ColumnIndex = 1 Then
    'Dim txtmontant = CType(e.Control, DataGridViewTextBoxEditingControl)
    '        AddHandler txtmontant.KeyPress, AddressOf txtmontant_keypress
    '   Else
    'RemoveHandler txtmontant.KeyPress, AddressOf txtmontant_keypress
    '   End If
    'End Sub

    'Private Sub txtmontant_keypress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtmontant.KeyPress
    'If e.KeyChar = vbCr Then
    'grid_jabatan.Rows.Add()
    'Exit Sub
    'End If
    'If e.KeyChar = vbBack Then
    'Exit Sub
    'End If
    'If InStr("0123456789.,", e.KeyChar) = 0 Then
    'e.KeyChar = ""
    'End If
    '    If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    'End Sub


    Private Sub grid_recruit_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_recruit.CellContentClick
        
    End Sub

    Private Sub grid_jabatan_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_jabatan.CellContentClick
        
    End Sub

    Private Sub TambahDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TambahDataToolStripMenuItem.Click
        FormDTJabatan.Show()
        FormDTJabatan.MdiParent = FormMenuUtama
        FormDTJabatan.WindowState = FormWindowState.Maximized
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If IsDBNull(grid_jabatan.Rows(grid_jabatan.RowCount - 2).Cells(1).Value) Then
            MsgBox("silahkan isi data terlebih dahulu")
        Else
            With datatab2.Rows
                .Add()
                grid_jabatan.DataSource = datatab2
            End With
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("datatab2 = " & datatab2.Rows.Count & " baris - 2 = " & grid_jabatan.RowCount - 2)
    End Sub

    Private Sub grid_jabatan_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_jabatan.CellDoubleClick
        grid_jabatan.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
        grid_jabatan.ReadOnly = False
        status_ = "edit"
    End Sub

    Private Sub HapusDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HapusDataToolStripMenuItem.Click
        'Dim baris_ As Integer
        'baris_ = DtTab_cont.Rows.Count 'hitung baris yang terdapat di tbl_jabatan
        'If rowindex + 1 = datatab2.Rows.Count Then
        'MsgBox("Untuk menghapus data di database silahkan gunakan hapus data ", MsgBoxStyle.Information, "INFO")
        'Else
        'datatab2.Rows.Remove(datatab2.Rows(rowindex))
        'grid_jabatan.DataSource = datatab2
        'grid_jabatan.Refresh()
        'MsgBox("Row index = " & rowindex)
        'End If
        If edit_tools = "jabatan" Then
            With grid_jabatan
                If rowindex = .RowCount - 1 Then
                    MsgBox("tidak bisa menghapus baris ini", MsgBoxStyle.Information, "INFO")
                Else
                    grid_jabatan.Rows.Remove(grid_jabatan.Rows(rowindex))
                End If
            End With
        End If

        If edit_tools = "harian" Then
            With grid_harian
                If rowindex < .RowCount - 1 Then
                    If MsgBox("Data " & vbCrLf & _
                              "NIK = " & Text_nik.Text & vbCrLf & _
                              "Nama = " & Text_nama.Text & vbCrLf & _
                              "No Urut = " & .Rows(rowindex).Cells(1).Value & vbCrLf & _
                              "Tanggal Masuk = " & .Rows(rowindex).Cells(2).Value & vbCrLf & _
                              "Tanggal keluar = " & .Rows(rowindex).Cells(3).Value & vbCrLf & _
                              "Akan dihapus?", MsgBoxStyle.OkCancel, "INFO") = vbOK Then
                        'hapus dta
                    End If
                End If
            End With
        End If
    End Sub


    Private Sub B_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_update.Click
        With grid_jabatan
            If .Rows.Count > 1 Then
                If MsgBox("Apakah data siap di update?", MsgBoxStyle.OkCancel, "INFO") = vbOK Then
                    'update data
                    Try
                        clear_command()
                        openDB()
                        For A = 0 To .Rows.Count - 2
                            sql = "UPDATE tbl_jabatan SET departemen = @departemen, jabatan = @jabatan, " & _
                                "status_karyawan = @status_karyawan, " & _
                                "tgl_awal = @tgl_awal, tgl_akhir = @tgl_akhir, atasan = @atasan " & _
                                "WHERE nik = @nik and no_urut = @no_urut"
                            sqlcmd = New SqlCommand(sql, Conn)
                            sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                            sqlcmd.Parameters.Add("@departemen", SqlDbType.VarChar).Value = .Rows(A).Cells(1).Value
                            sqlcmd.Parameters.Add("@jabatan", SqlDbType.VarChar).Value = .Rows(A).Cells(2).Value
                            sqlcmd.Parameters.Add("@status_karyawan", SqlDbType.VarChar).Value = .Rows(A).Cells(3).Value
                            If IsDBNull(.Rows(A).Cells(4).Value) Then
                                sqlcmd.Parameters.Add("@tgl_awal", SqlDbType.Date).Value = DBNull.Value
                            Else
                                sqlcmd.Parameters.Add("@tgl_awal", SqlDbType.Date).Value = CDate(.Rows(A).Cells(4).Value)
                            End If
                            If IsDBNull(.Rows(A).Cells(5).Value) Then
                                sqlcmd.Parameters.Add("@tgl_akhir", SqlDbType.Date).Value = DBNull.Value
                            Else
                                sqlcmd.Parameters.Add("@tgl_akhir", SqlDbType.Date).Value = CDate(.Rows(A).Cells(5).Value)
                            End If
                            sqlcmd.Parameters.Add("@atasan", SqlDbType.VarChar).Value = .Rows(A).Cells(6).Value
                            sqlcmd.Parameters.Add("@no_urut", SqlDbType.VarChar).Value = .Rows(A).Cells(7).Value
                            sqlcmd.ExecuteNonQuery()
                        Next A
                        MsgBox("Data jabatan telah berhasil di update", MsgBoxStyle.Information, "INFO")
                    Catch ex As Exception
                        MsgBox("Gagal dalam update data tanggal jabatan kerja " & ex.Message, MsgBoxStyle.Information, "INFO")
                        info_ = 0
                    Finally
                        Conn.Close()
                    End Try
                    '.Columns.Clear()
                    load_gridjabatan()
                    grid_jabatan.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                Else
                    '.Columns.Clear()
                    load_gridjabatan()
                    grid_jabatan.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                End If
            End If
        End With
    End Sub

    Private Sub B_updateTR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_updateTR.Click
        With grid_recruit
            If .ReadOnly = False Then
                If .Rows.Count > 1 Then
                        If MsgBox("Apakah data siap di update?", MsgBoxStyle.OkCancel, "INFO") = vbOK Then
                            'update data
                            Try
                                clear_command()
                                openDB()
                                For A = 0 To .Rows.Count - 2
                                    sql = "UPDATE tbl_tanggalkerja SET tgl_masuk_rec = @tgl_masuk_rec, " & _
                                        "tgl_masuk_harian = @tgl_masuk_harian, tgl_kontrak = @tgl_kontrak, " & _
                                        "tgl_tetap = @tgl_tetap, tgl_keluar = @tgl_keluar, tgl_borongan = @tgl_borongan " & _
                                        "WHERE nik = @nik"
                                    sqlcmd = New SqlCommand(sql, Conn)
                                    With sqlcmd.Parameters
                                        .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                                        If IsDBNull(grid_recruit.Rows(A).Cells(1).Value) Then
                                            .Add("@tgl_masuk_rec", SqlDbType.Date).Value = DBNull.Value
                                        Else
                                            .Add("@tgl_masuk_rec", SqlDbType.Date).Value = grid_recruit.Rows(A).Cells(1).Value
                                        End If
                                        If IsDBNull(grid_recruit.Rows(A).Cells(2).Value) Then
                                            .Add("@tgl_masuk_harian", SqlDbType.Date).Value = DBNull.Value
                                        Else
                                            .Add("@tgl_masuk_harian", SqlDbType.Date).Value = grid_recruit.Rows(A).Cells(2).Value
                                        End If
                                        If IsDBNull(grid_recruit.Rows(A).Cells(3).Value) Then
                                            .Add("@tgl_borongan", SqlDbType.Date).Value = DBNull.Value
                                        Else
                                            .Add("@tgl_borongan", SqlDbType.Date).Value = grid_recruit.Rows(A).Cells(3).Value
                                        End If
                                        If IsDBNull(grid_recruit.Rows(A).Cells(4).Value) Then
                                            .Add("@tgl_kontrak", SqlDbType.Date).Value = DBNull.Value
                                        Else
                                            .Add("@tgl_kontrak", SqlDbType.Date).Value = grid_recruit.Rows(A).Cells(4).Value
                                        End If
                                        If IsDBNull(grid_recruit.Rows(A).Cells(5).Value) Then
                                            .Add("@tgl_tetap", SqlDbType.Date).Value = DBNull.Value
                                        Else
                                            .Add("@tgl_tetap", SqlDbType.Date).Value = grid_recruit.Rows(A).Cells(5).Value
                                        End If
                                        If IsDBNull(grid_recruit.Rows(A).Cells(6).Value) Then
                                            .Add("@tgl_keluar", SqlDbType.Date).Value = DBNull.Value
                                        Else
                                            .Add("@tgl_keluar", SqlDbType.Date).Value = grid_recruit.Rows(A).Cells(6).Value
                                        End If
                                    End With
                                    sqlcmd.ExecuteNonQuery()
                                Next A
                                MsgBox("Data telah berhasil di update", MsgBoxStyle.Information, "INFO")
                            Catch ex As Exception
                                MsgBox("Gagal dalam update data tanggal recruitmen kerja " & ex.Message, MsgBoxStyle.Information, "INFO")
                                info_ = 0
                            Finally
                                Conn.Close()
                            End Try
                            'reload grid_recruit
                            load_gridrecruit()
                            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        Else
                            load_gridrecruit()
                            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        End If
                    End If
                End If
        End With
    End Sub

    Private Sub hapus_dtharian()
        Try
            clear_command()
            openDB()
            With grid_harian

            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub B_updateH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_updateH.Click
        With grid_harian
            If .ReadOnly = False Then
                If .Rows.Count > 1 Then
                    If MsgBox("Apakah data siap di update?", MsgBoxStyle.OkCancel, "INFO") = vbOK Then
                        'update data
                        Try
                            clear_command()
                            openDB()
                            For A = 0 To .Rows.Count - 2
                                'nik, tgl_masuk, tgl_keluar, no_urut
                                sql = "UPDATE tbl_tglharians SET tgl_masuk = @tgl_masuk, " & _
                                    "tgl_keluar = @tgl_keluar WHERE nik = @nik AND no_urut = @no_urut"
                                sqlcmd = New SqlCommand(sql, Conn)
                                With sqlcmd.Parameters
                                    .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                                    If IsDBNull(grid_recruit.Rows(A).Cells(1).Value) Then
                                        .Add("@tgl_masuk", SqlDbType.Date).Value = DBNull.Value
                                    Else
                                        .Add("@tgl_masuk", SqlDbType.Date).Value = grid_harian.Rows(A).Cells(2).Value
                                    End If
                                    If IsDBNull(grid_recruit.Rows(A).Cells(2).Value) Then
                                        .Add("@tgl_keluar", SqlDbType.Date).Value = DBNull.Value
                                    Else
                                        .Add("@tgl_keluar", SqlDbType.Date).Value = grid_harian.Rows(A).Cells(3).Value
                                    End If
                                    .Add("@no_urut", SqlDbType.VarChar).Value = grid_harian.Rows(A).Cells(1).Value
                                End With
                                sqlcmd.ExecuteNonQuery()
                            Next A
                            MsgBox("Data telah berhasil di update", MsgBoxStyle.Information, "INFO")
                        Catch ex As Exception
                            MsgBox("Gagal dalam update data tanggal harian sementara " & ex.Message, MsgBoxStyle.Information, "INFO")
                            info_ = 0
                        Finally
                            Conn.Close()
                        End Try
                        'reload grid_recruit
                        load_gridharian()
                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    Else
                        load_gridharian()
                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub grid_harian_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_harian.CellContentClick

    End Sub

    Private Sub Text_pencarian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_pencarian.TextChanged
        Try
            clear_command()
            openDB()
            sql = "SELECT nik, nama, departemen, jabatan, status_karyawan, atasan from view_dtpegawai " & _
                "WHERE nama LIKE '%" & Text_pencarian.Text & "%' OR nik LIKE '%" & Text_pencarian.Text & "%'"
            sqladapter = New SqlDataAdapter(sql, Conn)
            DataTab = New DataTable
            DataTab.Clear()
            sqladapter.Fill(DataTab)
            grid_karyawan.DataSource = DataTab
            grid_karyawan.Refresh()
        Catch ex As Exception
            MsgBox("gagal menampilkan data " & ex.Message)
        End Try
    End Sub

    Private Sub Tabjab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tabjab.Click

    End Sub
End Class