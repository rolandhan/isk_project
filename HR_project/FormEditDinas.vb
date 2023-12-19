Imports System.Data.Sql
Imports System.Data.SqlClient
Imports VB = Microsoft.VisualBasic.Strings
Public Class FormEditDinas

    Dim rowindex As String
    Private Sub FormEditDinas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_combo(Combo_jenis, "tbl_dinas", "armada")
    End Sub

    Private Sub load_datagrid(ByVal grid As DataGridView, ByVal opt As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            Select Case opt
                Case String.Empty
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, * FROM (SELECT view_dtpegawai.nama, " & _
                "view_dtpegawai.nik , view_dtpegawai.departemen, " & _
                "view_dtpegawai.status_karyawan, hari, tanggal, jam_berangkat, jam_pulang, tujuan, " & _
                "armada, km_awal, km_akhir, id_dinas, keterangan, no_pol " & _
                "FROM tbl_dinas LEFT OUTER JOIN view_dtpegawai ON tbl_dinas.nik = view_dtpegawai .nik) AS temp " & _
                "WHERE temp.tanggal BETWEEN @awal AND @akhir"
                Case "Departemen"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, * FROM (SELECT view_dtpegawai.nama, " & _
                "view_dtpegawai.nik , view_dtpegawai.departemen, " & _
                "view_dtpegawai.status_karyawan, hari, tanggal, jam_berangkat, jam_pulang, tujuan, " & _
                "armada, km_awal, km_akhir, id_dinas, keterangan, no_pol " & _
                "FROM tbl_dinas LEFT OUTER JOIN view_dtpegawai ON tbl_dinas.nik = view_dtpegawai .nik) AS temp " & _
                "WHERE temp.tanggal BETWEEN @awal AND @akhir AND departemen = '" & combo_dept.Text & "'"
                Case "Armada"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, * FROM (SELECT view_dtpegawai.nama, " & _
                "view_dtpegawai.nik , view_dtpegawai.departemen, " & _
                "view_dtpegawai.status_karyawan, hari, tanggal, jam_berangkat, jam_pulang, tujuan, " & _
                "armada, km_awal, km_akhir, id_dinas, keterangan, no_pol " & _
                "FROM tbl_dinas LEFT OUTER JOIN view_dtpegawai ON tbl_dinas.nik = view_dtpegawai .nik) AS temp " & _
                "WHERE temp.tanggal BETWEEN @awal AND @akhir AND Armada = '" & Combo_jenis.Text & "' AND departemen = '" & combo_dept.Text & "'"
                Case "Pencarian"
                    sql = "SELECT ROW_NUMBER() OVER(ORDER BY temp.nik ASC) AS No, * FROM (SELECT * FROM (SELECT view_dtpegawai.nama, " & _
                "view_dtpegawai.nik , view_dtpegawai.departemen, " & _
                "view_dtpegawai.status_karyawan, hari, tanggal, jam_berangkat, jam_pulang, tujuan, " & _
                "armada, km_awal, km_akhir, id_dinas, keterangan, no_pol " & _
                "FROM tbl_dinas LEFT OUTER JOIN view_dtpegawai ON tbl_dinas.nik = view_dtpegawai .nik) AS temp " & _
                "WHERE temp.tanggal BETWEEN @awal AND @akhir) AS temp2 " & _
                "WHERE temp2.nama LIKE '%" & Text_pencarian.Text & "%' OR temp2.nik LIKE '%" & Text_pencarian.Text & "%' "
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@awal", SqlDbType.Date).Value = DT_awal.Text
            sqlcmd.Parameters.Add("@akhir", SqlDbType.Date).Value = DT_akhir.Text

            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            grid.DataSource = DTab
            atur_grid(grid_tampildata)
            grid.Refresh()
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data ", MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Function update_data(ByVal nik As String, ByVal id_dinas As String) As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()

            sql = "UPDATE tbl_dinas SET hari = @hari, tanggal = @tanggal, jam_berangkat = @jam_berangkat, " & _
                "jam_pulang = @jam_pulang, tujuan = @tujuan, armada = @armada, km_awal = @km_awal, km_akhir = @km_akhir, " & _
                "keterangan = @keterangan, no_pol = @no_pol WHERE id_dinas = @id_dinas AND nik = @Nik"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = nik
                .Add("@id_dinas", SqlDbType.VarChar).Value = id_dinas
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam update data dinas " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function hapus_data(ByVal id_dinas As String) As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "DELETE FROM tbl_dinas WHERE id_dinas = @id_dinas"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@id_dinas", SqlDbType.VarChar).Value = id_dinas
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam penghapusan data " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
        End Try
    End Function

    Private Sub atur_grid(ByVal grid As DataGridView)
        'no, nama, nik, departemen, status_kary, hari, tanggal, jam_berangkat, jam_pulang, 
        'tujuan, armada, km_awal, km_akhir, id_dinas, keterangan, no_pol
        With grid
            .ReadOnly = True
            .Enabled = True
            .Columns(0).HeaderText = "No"
            .Columns(0).Width = "30"
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).Frozen = True
            .Columns(1).HeaderText = "Nama"
            .Columns(1).Width = "180"
            .Columns(1).Frozen = True
            .Columns(2).HeaderText = "NIK"
            .Columns(2).Width = "80"
            .Columns(2).Frozen = True
            .Columns(3).HeaderText = "Departemen"
            .Columns(3).Width = "140"
            .Columns(4).HeaderText = "status karyawan"
            .Columns(4).Visible = False
            .Columns(5).HeaderText = "Hari"
            .Columns(5).Width = "80"
            .Columns(6).HeaderText = "Tanggal"
            .Columns(6).Width = "80"
            .Columns(7).HeaderText = "Jam Berangkat"
            .Columns(7).Width = "80"
            .Columns(8).HeaderText = "Jam Pulang"
            .Columns(8).Width = "80"
            .Columns(9).HeaderText = "Tujuan"
            .Columns(9).Width = "80"
            .Columns(10).HeaderText = "Armada"
            .Columns(10).Width = "100"
            .Columns(11).HeaderText = "KM Awal"
            .Columns(11).Width = "80"
            .Columns(12).HeaderText = "KM Akhir"
            .Columns(12).Width = "80"
            .Columns(13).HeaderText = "id_dinas"
            .Columns(13).Width = "80"
            .Columns(14).HeaderText = "Keterangan"
            .Columns(14).Width = "200"
            .Columns(15).HeaderText = "No POL"
            .Columns(15).Width = "80"
            .RowHeadersWidth = 5
        End With
    End Sub

    Private Sub grid_tampildata_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_tampildata.CellEndEdit
        With grid_tampildata
            Dim kolom% = .CurrentCell.ColumnIndex
            Dim nik$, id_dinas$

            If kolom < 4 Then
                MsgBox("Untuk merubah data ini, silahkan lewat form jabatan atau form data pegawai", MsgBoxStyle.Information, "INFO")
            Else
                If MsgBox("Data Dinas Luar telah diedit, update data ke dalam database ?", _
                          MsgBoxStyle.OkCancel, "INFO") = vbOK Then
                    'update data tabel tbl_cuti
                    nik = .Rows(rowindex).Cells(2).Value
                    id_dinas = .Rows(rowindex).Cells(13).Value

                    If update_data(nik, id_dinas) = True Then
                        MsgBox("Data DInas Luar telah di update", MsgBoxStyle.Information, "INFO")
                        load_datagrid(grid_tampildata, Nothing)
                        .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    End If
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
                    nik_global = .Rows(rowindex).Cells(1).Value
                    Me.ContextMenuStrip1.Show(Me.grid_tampildata, e.Location)
                    Me.ContextMenuStrip1.Show(Cursor.Position)
                Else
                    .ContextMenuStrip = Nothing
                End If
            End If
        End With
    End Sub

    Private Sub Combo_jenis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_jenis.SelectedIndexChanged

    End Sub

    Private Sub combo_dept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_dept.SelectedIndexChanged
        If Combo_jenis.Text = String.Empty Then
            load_datagrid(grid_tampildata, "Departemen")
        Else
            load_datagrid(grid_tampildata, "Armada")
        End If
    End Sub

    Private Sub Text_pencarian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_pencarian.TextChanged
        load_datagrid(grid_tampildata, "Pencarian")
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        grid_tampildata.ReadOnly = False
        grid_tampildata.SelectionMode = DataGridViewSelectionMode.CellSelect

    End Sub

    Private Sub HapusDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HapusDataToolStripMenuItem.Click
        With grid_tampildata
            If .Rows.Count > 1 Then
                Dim id_dinas, nik As String
                Dim tanggal As Date

                id_dinas = .Rows(rowindex).Cells(13).Value
                nik = .Rows(rowindex).Cells(2).Value


                If MsgBox("Apakah Data " & vbCrLf & _
                   "Nama : " & .Rows(rowindex).Cells(1).Value & vbCrLf & _
                   "NIK : " & .Rows(rowindex).Cells(2).Value & vbCrLf & _
                   "Departemen : " & .Rows(rowindex).Cells(3).Value & vbCrLf & _
                   "Tanggal : " & .Rows(rowindex).Cells(6).Value & vbCrLf & _
                   "Akah di hapus ?", MsgBoxStyle.Information & vbOKCancel, "INFO") = vbOK Then

                    'hapus data di tabel tbl_dinas
                    If hapus_data(id_dinas) = True Then
                        MsgBox("Data telah berhasil di hapus ", MsgBoxStyle.Information, "INFO")
                        load_datagrid(grid_tampildata, Nothing)
                    End If
                End If
            End If
     End With 
    End Sub

    Private Sub DT_awal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_awal.ValueChanged

    End Sub
End Class