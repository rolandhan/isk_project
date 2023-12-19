Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization

Public Class FormEditPeringatan
    Dim rowindex As Integer

    Private Sub FormEditPeringatan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New CultureInfo("id-ID")
        load_combojenis(Combo_jenis)
        fill_combo(combo_dept, "departemen", "tbl_jabatan")
        clear_date(Me, Nothing)
    End Sub

    Private Sub load_combojenis(ByVal combo As ComboBox)
        With combo
            .Items.Add("Catatan Khusus")
            .Items.Add("Peringatan IMP")
            .Items.Add("Surat Pernyataan")
            .Items.Add("Surat Peringatan")
            .Items.Add("Kecelakaan Kerja")
            '.Items.Add("isolasi COVID")
        End With
    End Sub

    Private Sub load_grid(ByVal grid As DataGridView, ByVal opt As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No,*  FROM " & _
                "(SELECT tbl_catatan.nik, nama, departemen, jabatan, status_karyawan, " & _
                "jenis_peringatan, catatan, tanggal, periode, id_catatan, view_tglpegawai .tgl_keluar  FROM tbl_catatan " & _
                "LEFT OUTER JOIN view_tglpegawai ON tbl_catatan.nik = view_tglpegawai.nik " & _
                "WHERE (view_tglpegawai .tgl_keluar > @awal OR view_tglpegawai .tgl_keluar IS NULL) " & _
                "AND (tanggal BETWEEN @awal AND @akhir )) AS temp " & _
                "WHERE temp.jenis_peringatan = '" & opt & "'"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@awal", SqlDbType.Date).Value = DT_awal.Text
            sqlcmd.Parameters.Add("@akhir", SqlDbType.Date).Value = DT_akhir.Text
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            grid.DataSource = DTab
            atur_grid(GridTampilData, opt)
            grid.Refresh()
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data " & opt & " " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub LoadDataPeringatan(ByVal Pilihan As String, ByVal Filter As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            Select Case Filter
                Case Nothing
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No,*  FROM " & _
                        "(SELECT tbl_catatan.nik, nama, departemen, jabatan, status_karyawan, " & _
                        "jenis_peringatan, catatan, tanggal, periode, id_catatan, view_tglpegawai.tgl_keluar  FROM tbl_catatan " & _
                        "LEFT OUTER JOIN view_tglpegawai ON tbl_catatan.nik = view_tglpegawai.nik " & _
                        "WHERE (view_tglpegawai .tgl_keluar > @awal OR view_tglpegawai .tgl_keluar IS NULL) " & _
                        "AND (tanggal BETWEEN @awal AND @akhir) ) AS temp " & _
                        "WHERE temp.jenis_peringatan = '" & Pilihan & "'"
                Case "Departemen"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No,*  FROM " & _
                        "(SELECT tbl_catatan.nik, nama, departemen, jabatan, status_karyawan, " & _
                        "jenis_peringatan, catatan, tanggal, periode, id_catatan, view_tglpegawai.tgl_keluar  FROM tbl_catatan " & _
                        "LEFT OUTER JOIN view_tglpegawai ON tbl_catatan.nik = view_tglpegawai.nik " & _
                        "WHERE (view_tglpegawai.tgl_keluar > @awal OR view_tglpegawai.tgl_keluar IS NULL) " & _
                        "AND (tanggal BETWEEN @awal AND @akhir) ) AS temp " & _
                        "WHERE temp.jenis_peringatan = '" & Pilihan & "' AND temp.departemen = '" & Filter & "'"
                Case "Pencarian"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No,*  FROM " & _
                        "(SELECT tbl_catatan.nik, nama, departemen, jabatan, status_karyawan, " & _
                        "jenis_peringatan, catatan, tanggal, periode, id_catatan, view_tglpegawai.tgl_keluar  FROM tbl_catatan " & _
                        "LEFT OUTER JOIN view_tglpegawai ON tbl_catatan.nik = view_tglpegawai.nik " & _
                        "WHERE (view_tglpegawai.tgl_keluar > @awal OR view_tglpegawai.tgl_keluar IS NULL) " & _
                        "AND (tanggal BETWEEN @awal AND @akhir) ) AS temp " & _
                        "WHERE temp.jenis_peringatan = '" & Pilihan & "' " & _
                        "AND (temp.nama LIKE '%" & Text_pencarian.Text & "%' OR temp.nik LIKE '%" & Text_pencarian.Text & "%')"
            End Select
            
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@awal", SqlDbType.Date).Value = DT_awal.Text
            sqlcmd.Parameters.Add("@akhir", SqlDbType.Date).Value = DT_akhir.Text
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            GridTampilData.DataSource = DTab
            atur_grid(GridTampilData, Pilihan)
            GridTampilData.Refresh()
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data " & Pilihan & " " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function HapusCatatan(ByVal grid As DataGridView) As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "DELETE FROM tbl_catatan WHERE id_catatan = @id_catatan"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@id_catatan", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(0).Value
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam penghapusan data " & Combo_jenis.Text & "karena " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function hapus_covid(ByVal grid As DataGridView) As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "DELETE FROM tbl_covid WHERE no_urut = @nu_urut"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@no_urut", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(0).Value
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam proses penghapusan data covid" & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function UpdateCatatan(ByVal grid As DataGridView) As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "UPDATE tbl_catatan SET catatan = @catatan, " & _
                "tanggal = @tanggal, periode = @Periode WHERE id_catatan = @id_catatan AND jenis_peringatan = @jenis_peringatan"
            sqlcmd = New SqlCommand(sql, Conn)

            With sqlcmd.Parameters
                .Add("@id_catatan", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(10).Value
                .Add("@jenis_peringatan", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(6).Value
                .Add("@catatan", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(7).Value
                If IsNothing(GridTampilData.Rows(rowindex).Cells(8).Value) Then
                    .Add("@tanggal", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tanggal", SqlDbType.Date).Value = grid.Rows(rowindex).Cells(8).Value
                End If
                .Add("@periode", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(9).Value
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam update data " & Combo_jenis.Text & "karena " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function update_covid(ByVal grid As DataGridView) As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            '  nik, tgl_mulai, tgl_selesai, rapid, antigen, pcr, no_urut, ket
            sql = "UPDATE tbl_covid SET tgl_mulai = @tgl_mulai, tgl_selesai = @tgl_selesai, rapid = @rapid " & _
                "antigen = @antigen, pcr = @pcr, ket= @ket WHERE no_urut = @no_urut"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@tgl_mulai", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(0).Value
                .Add("@tgl_selesai", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(0).Value
                .Add("@rapid", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(0).Value
                .Add("@antigen", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(0).Value
                .Add("@pcr", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(0).Value
                .Add("@ket", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(0).Value
                .Add("@antigen", SqlDbType.VarChar).Value = grid.Rows(rowindex).Cells(0).Value
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam penghapusan data " & Combo_jenis.Text & "karena " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function update_rekapkerja(ByVal grid As DataGridView) As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = ""

        Catch ex As Exception

        End Try
    End Function

    Private Sub atur_grid(ByVal grid As DataGridView, ByVal opt As String)
        With grid
                .ReadOnly = True
                .Enabled = True
                .Columns(0).HeaderText = "No"
                .Columns(0).Width = "30"
                .Columns(0).Frozen = True
                .Columns(1).HeaderText = "NIK"
                .Columns(1).Width = "80"
                .Columns(1).Frozen = True
                .Columns(2).HeaderText = "Nama"
                .Columns(2).Width = "180"
                .Columns(2).Frozen = True
                .Columns(3).HeaderText = "Departemen"
                .Columns(3).Width = "155"
                .Columns(4).HeaderText = "Jabatan"
                .Columns(4).Visible = False
                .Columns(5).HeaderText = "Status Karyawan"
                .Columns(5).Width = "120"
                .Columns(6).HeaderText = "Jenis Peringatan"
                .Columns(6).Width = "200"
                .Columns(7).HeaderText = "Catatan"
                .Columns(7).Width = "200"
                .Columns(7).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .Columns(8).HeaderText = "Tanggal"
                .Columns(8).Width = "90"
                .Columns(9).HeaderText = "Periode"
                .Columns(9).Width = "90"
                .Columns(10).HeaderText = "id catatan"
            .Columns(10).Visible = False
            .Columns(11).HeaderText = "Tanggal Keluar"
            .Columns(11).Visible = False
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                .RowHeadersWidth = 5
                .Refresh()
        End With
    End Sub

    Private Sub Combo_jenis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_jenis.SelectedIndexChanged
        load_grid(GridTampilData, Combo_jenis.Text)
    End Sub

    Private Sub DT_awal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_awal.ValueChanged
        format_tanggal(DT_awal)
    End Sub

    Private Sub DT_akhir_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_akhir.ValueChanged
        format_tanggal(DT_akhir)
    End Sub

    Private Sub grid_tampildata_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridTampilData.CellEndEdit
        With GridTampilData
            If .Rows.Count > 1 Then
                    If MsgBox("Apakah data " & Combo_jenis.Text & " siap untuk di update ? ", MsgBoxStyle.OkCancel, "INFO") = vbOK Then
                        'update data
                        If UpdateCatatan(GridTampilData) = True Then
                            MsgBox("Data telah berhasil di update", MsgBoxStyle.Information, "INFO")
                        load_grid(GridTampilData, Combo_jenis.Text)
                        .ReadOnly = True
                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                        End If
                    End If
                End If
        End With
    End Sub

    Private Sub grid_tampildata_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GridTampilData.CellMouseUp
        With GridTampilData
            If e.Button = MouseButtons.Right Then
                If .Rows.Count > 1 Then
                    .ContextMenuStrip = ContextMenuStrip1
                    rowindex = .CurrentRow.Index
                    nik_global = .Rows(rowindex).Cells(1).Value
                    Me.ContextMenuStrip1.Show(Me.GridTampilData, e.Location)
                    Me.ContextMenuStrip1.Show(Cursor.Position)
                Else
                    .ContextMenuStrip = Nothing
                End If
            End If
        End With
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        GridTampilData.ReadOnly = False
        GridTampilData.SelectionMode = DataGridViewSelectionMode.CellSelect
    End Sub

    '
    Private Sub auto_tahun(ByVal combo As ComboBox)
        combo.Items.Clear()
        For i As Integer = 0 To 3
            combo.Items.Add(Year(Now) - i)
        Next i
        combo.SelectedIndex = 0
    End Sub

    Private Sub HapusDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HapusDataToolStripMenuItem.Click
        With GridTampilData
            If .Rows.Count > 1 Then
                Dim id, nik, status As String
                Dim tanggal As Date
                id = .Rows(rowindex).Cells(5).Value
                nik = .Rows(rowindex).Cells(1).Value
                tanggal = CDate(.Rows(rowindex).Cells(8).Value)
                status = .Rows(rowindex).Cells(13).Value

                If MsgBox("Apakah Data " & vbCrLf & _
                   "Nama : " & .Rows(rowindex).Cells(2).Value & vbCrLf & _
                   "NIK : " & .Rows(rowindex).Cells(1).Value & vbCrLf & _
                   "Departemen : " & .Rows(rowindex).Cells(3).Value & vbCrLf & _
                   "Tanggal : " & .Rows(rowindex).Cells(8).Value & vbCrLf & _
                   "Akan di hapus ?", MsgBoxStyle.Information & vbOKCancel, "INFO") = vbOK Then
                    If HapusCatatan(GridTampilData) = True Then
                        MsgBox("data telah berhasil di hapus", MsgBoxStyle.Information, "INFO")
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub Text_pencarian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_pencarian.TextChanged
        LoadDataPeringatan(Combo_jenis.Text, "Pencarian")
    End Sub

    Private Sub combo_dept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_dept.SelectedIndexChanged
        LoadDataPeringatan(Combo_jenis.Text, "Departemen")
    End Sub
End Class