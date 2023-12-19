Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports VB = Microsoft.VisualBasic.Strings
Imports System.Globalization

Public Class FormDinas
    Dim id_dinas As String
    Dim rowindex As Integer


    Private Sub FormDinas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        disable_combo(Me, Nothing)
        disable_text(Me, Nothing)
        Application.CurrentCulture = New CultureInfo("id-ID")
    End Sub

    Private Function simpan_data() As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            For A = 0 To grid_cont.RowCount - 2
                sql = "insert into tbl_dinas(nik, hari, tanggal, jam_berangkat, jam_pulang, tujuan, armada, " & _
                    "km_awal, km_akhir, id_dinas, keterangan, no_pol) values( " & _
                    "@nik, @hari, @tanggal, @jam_berangkat, @jam_pulang, @tujuan, @armada, @km_awal, @km_akhir, @id_dinas, @keterangan, @no_pol)"
                sqlcmd = New SqlCommand(sql, Conn)
                With sqlcmd.Parameters
                    .Add("@nik", SqlDbType.VarChar).Value = grid_cont.Rows(A).Cells(0).Value
                    .Add("@hari", SqlDbType.VarChar).Value = Text_hari.Text
                    If DT_tanggal.Text = " " Then
                        .Add("@tanggal", SqlDbType.Date).Value = DBNull.Value
                    Else
                        .Add("@tanggal", SqlDbType.Date).Value = DT_tanggal.Text
                    End If
                    .Add("@jam_berangkat", SqlDbType.Time).Value = mask_brngkat.Text
                    .Add("@jam_pulang", SqlDbType.Time).Value = mask_pulang.Text
                    .Add("@tujuan", SqlDbType.VarChar).Value = Text_tujuan.Text
                    .Add("@armada", SqlDbType.VarChar).Value = Text_armada.Text
                    .Add("@km_awal", SqlDbType.Float).Value = Text_kmawal.Text
                    .Add("@km_akhir", SqlDbType.Float).Value = Text_kmakhir.Text
                    .Add("@id_dinas", SqlDbType.VarChar).Value = id_dinas
                    .Add("@keterangan", SqlDbType.VarChar).Value = Text_ket.Text
                    .Add("@no_pol", SqlDbType.VarChar).Value = Text_nopol.Text
                End With
                sqlcmd.ExecuteNonQuery()
            Next A
            Return True
        Catch ex As Exception
            MsgBox("data gagal untuk disimpan " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function edit_data() As Boolean
        Try
            clear_command()
            openDB()
            sql = "update tbl_dinas set hari = @hari, tanggal = @tanggal, jam_berangkat = @jam_berangkat , " & _
                "jam_pulang = @jam_pulang, tujuan = @tujuan, armada = @armada, km_awal =@km_awal, km_akhir = @km_akhir, " & _
                "keterangan = @keterangan WHERE nik = @nik AND id_dinas = @id_dinas"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                .Add("@hari", SqlDbType.VarChar).Value = Text_hari.Text
                If DT_tanggal.Text = " " Then
                    .Add("@tanggal", SqlDbType.VarChar).Value = SqlDateTime.Null
                Else
                    .Add("@tanggal", SqlDbType.VarChar).Value = DT_tanggal.Text
                End If
                .Add("@jam_berangkat", SqlDbType.Time).Value = mask_brngkat.Text
                .Add("@jam_pulang", SqlDbType.Time).Value = mask_pulang.Text
                .Add("@tujuan", SqlDbType.VarChar).Value = Text_tujuan.Text
                .Add("@armada", SqlDbType.VarChar).Value = Text_armada.Text
                .Add("@km_awal", SqlDbType.Float).Value = Text_kmawal.Text
                .Add("@km_akhir", SqlDbType.Float).Value = Text_kmakhir.Text
                .Add("@id_dinas", SqlDbType.VarChar).Value = id_dinas
                .Add("@keterangan", SqlDbType.VarChar).Value = Text_ket.Text
                sqlcmd.ExecuteNonQuery()
                MsgBox("data telah berhasil tersimpan", MsgBoxStyle.Information, "INFO")
            End With
        Catch ex As Exception
            MsgBox("data gagal untuk disimpan", MsgBoxStyle.Information, "INFO")
        End Try
    End Function

    Private Sub hapus()
        Clear_text(Me, Nothing)
        format_tanggal_kosong(DT_tanggal)
        mask_brngkat.Text = String.Empty
        mask_pulang.Text = String.Empty
    End Sub

    Private Sub load_gridkaryawan(ByVal opt As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            Select Case opt
                Case String.Empty
                    sql = "SELECT nik, nama, departemen, jabatan, status_karyawan, atasan FROM  view_dtpegawai"
                Case "departemen"
                    sql = "SELECT nik, nama, departemen, jabatan, status_karyawan, atasan FROM  view_dtpegawai " & _
                        "WHERE  departemen = '" & Combo_dept.Text & "'"
                Case "pencarian"
                    sql = "SELECT nik, nama, departemen, jabatan, status_karyawan, atasan FROM  view_dtpegawai " & _
                        "WHERE nama LIKE '%" & Text_pencarian.Text & "%' OR nik LIKE '%" & Text_pencarian.Text & "%'"
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            Grid_karyawan.DataSource = DTab
            atur_grid(Grid_karyawan, "karyawan")
            Grid_karyawan.Refresh()
        Catch ex As Exception
            MsgBox("Gagal menampilkan data " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub atur_grid(ByVal grid As DataGridView, ByVal opt As String)
        With grid
            Select Case opt
                Case "karyawan"
                    .ReadOnly = True
                    .Enabled = True
                    .ColumnHeadersVisible = True
                    .Columns(0).HeaderText = "NIK"
                    .Columns(0).Width = 70
                    .Columns(1).HeaderText = "Nama"
                    .Columns(1).Width = 150
                    .Columns(2).HeaderText = "Departemen"
                    .Columns(2).Width = 120
                    .Columns(3).HeaderText = "Jabatan"
                    .Columns(3).Width = 150
                    .Columns(4).HeaderText = "status"
                    .Columns(4).Width = 75
                    .Columns(5).HeaderText = "Atasan"
                    .Columns(5).Width = 100
                Case "personal"
                    .ReadOnly = True
                    .Enabled = True
                    .ColumnCount = 4
                    .ColumnHeadersVisible = True
                    .Columns(0).HeaderText = "NIK"
                    .Columns(0).Width = 70
                    .Columns(1).HeaderText = "Nama"
                    .Columns(1).Width = 150
                    .Columns(1).Frozen = True
                    .Columns(2).HeaderText = "Departemen"
                    .Columns(2).Width = 120
                    .Columns(3).HeaderText = "Jabatan"
                    .Columns(3).Width = 150
            End Select
            .RowHeadersWidth = 10
        End With
    End Sub

    Private Sub DT_tanggal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_tanggal.ValueChanged
        Text_hari.Text = convert_daynames(DT_tanggal)
        format_tanggal(DT_tanggal)
    End Sub

    Private Sub Button_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_simpan.Click
        If grid_cont.Rows.Count < 1 Then
            MsgBox("NIK tidak boleh kosong", MsgBoxStyle.Information, "INFO")
            Text_nik.Focus()
        ElseIf Text_hari.Text = String.Empty Then
            MsgBox("Tanggal dan hari tidak boleh kosong", MsgBoxStyle.Information, "INFO")
            DT_tanggal.Focus()
        Else
            If nik_global <> String.Empty Then
                MsgBox("Untuk melakukan update data gunakan form edit data", MsgBoxStyle.Information, "INFO")
            Else
                'simpan data
                If MsgBox("APakah data sudah siap di simpan ?", MsgBoxStyle.OkCancel, "INFO") = vbOK Then
                    If simpan_data() = True Then
                        MsgBox("Data telah berhasil di simpan", MsgBoxStyle.Information, "INFO")
                        hapus()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Combo_depart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_dept.SelectedIndexChanged
        load_gridkaryawan("departemen")
    End Sub

    Private Sub Grid_karyawan_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid_karyawan.CellContentDoubleClick
        With Grid_karyawan
            Text_nik.Text = .Rows(.CurrentRow.Index).Cells(0).Value
            Text_nama.Text = .Rows(.CurrentRow.Index).Cells(1).Value
            Text_dept.Text = .Rows(.CurrentRow.Index).Cells(2).Value
            Text_jabatan.Text = .Rows(.CurrentRow.Index).Cells(3).Value
        End With
    End Sub

    Private Sub Text_pencarian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_pencarian.TextChanged
        load_gridkaryawan("pencarian")
    End Sub

    Private Sub hapus_sub()
        Text_nama.Text = String.Empty
        Text_dept.Text = String.Empty
        Text_jabatan.Text = String.Empty
        Text_nik.Text = String.Empty
    End Sub

    Private Sub Buttontambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttontambah.Click
        With grid_cont
            .Rows.Add(1)
            .Rows(.RowCount - 2).Cells(0).Value = Text_nik.Text
            .Rows(.RowCount - 2).Cells(1).Value = Text_nama.Text
            .Rows(.RowCount - 2).Cells(2).Value = Text_dept.Text
            .Rows(.RowCount - 2).Cells(3).Value = Text_jabatan.Text
            .Update()
            .Refresh()
            hapus_sub()
        End With

    End Sub

    Private Sub Button_baru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_baru.Click
        enable_combo(Me, Nothing)
        enable_text(Me, Nothing)
        atur_grid(grid_cont, "personal")
        format_tanggal_kosong(DT_tanggal)
        load_gridkaryawan(Nothing)
        load_combo(Combo_dept, "departemen", "tbl_statuskerja")
        id_dinas = cek_id()
        id_global = String.Empty
        nik_global = String.Empty
    End Sub

    Public Sub load_dtdinas(ByVal nik As String, ByVal id As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "SELECT tbl_dinas.nik, nama, departemen ,jabatan, hari, tanggal, jam_berangkat, jam_pulang," & _
                "tujuan, armada, km_awal, km_akhir, id_dinas, keterangan, no_pol " & _
                "FROM  tbl_dinas LEFT OUTER JOIN view_dtpegawai ON tbl_dinas.nik = view_dtpegawai .nik " & _
                "WHERE nik = '" & nik & "' AND id_dinas = '" & id & "'"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                Text_nik.Text = sqlreader.Item("nik")
                Text_nama.Text = sqlreader.Item("nama")
                Text_dept.Text = sqlreader.Item("departemen")
                Text_jabatan.Text = sqlreader.Item("jabatan")
                If Not IsDBNull(sqlreader.Item("tanggal")) Then
                    DT_tanggal.Text = Format(sqlreader.Item("Tanggal"), "dd-MM-yyyy")
                Else
                    format_tanggal_kosong(DT_tanggal)
                End If
                If Not IsDBNull(sqlreader.Item("jam_berangkat")) Then
                    mask_brngkat.Text = sqlreader.Item("jam_berangkat")
                End If
                If Not IsDBNull(sqlreader.Item("jam_pulang")) Then
                    mask_pulang.Text = sqlreader.Item("jam_pulang")
                End If
                Text_tujuan.Text = sqlreader.Item("tujuan")
                Text_armada.Text = sqlreader.Item("armada")
                Text_kmawal.Text = sqlreader.Item("km_awal")
                Text_kmakhir.Text = sqlreader.Item("km_akhir")
                id_dinas = id_global
            End If
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data di tabel dinas " & ex.Message)
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function cek_id() As String
        Try
            clear_command()
            openDB()
            sql = "SELECT TOP (1) id_dinas FROM tbl_dinas ORDER BY id_dinas DESC"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                If VB.Right(sqlreader.Item("id_dinas"), 4) = VB.Left("00" & Now().Date, 2) & VB.Right(Now().Year, 2) Then
                    Return VB.Left("000" & CInt(VB.Left(sqlreader.Item("id_dinas"), 3)) + 1, 3) & _
                        "/ISK/DNS/" & VB.Left("00" & Now().Date, 2) & VB.Right(Now().Year, 2)
                Else
                    Return "001/ISK/DNS/" & VB.Left("00" & Now().Date, 2) & VB.Right(Now().Year, 2)
                End If
            Else
                Return "001/ISK/DNS/" & VB.Left("00" & Now().Date, 2) & VB.Right(Now().Year, 2)
            End If
        Catch ex As Exception
            MsgBox("Gagal dalam pengecekan no id_dinas " & ex.Message)
            Return Nothing
        Finally
            Conn.Close()
        End Try
    End Function

    Private Sub Buttonkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonkeluar.Click
        Me.Close()
    End Sub

    Private Sub HapusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HapusToolStripMenuItem.Click
        rowindex = grid_cont.CurrentRow.Index
        grid_cont.Rows.RemoveAt(rowindex)
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        rowindex = grid_cont.CurrentRow.Index
        With grid_cont
            Text_nik.Text = .Rows(rowindex).Cells(0).Value
            Text_nama.Text = .Rows(rowindex).Cells(1).Value
            Text_dept.Text = .Rows(rowindex).Cells(2).Value
            Text_jabatan.Text = .Rows(rowindex).Cells(3).Value
        End With
        grid_cont.Rows.RemoveAt(rowindex)
    End Sub

    Private Sub Grid_karyawan_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid_karyawan.CellContentClick

    End Sub
End Class