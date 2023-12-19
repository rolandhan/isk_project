Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization

Public Class FormDetailPresensi
    Private rowindex As Integer
    Private nik As String
    Private WithEvents txtNumeric As New DataGridViewTextBoxEditingControl

    Private Sub FormDetailPresensi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        format_tgl()
        load_combo(combo_dept, "departemen", "tbl_statuskerja")
        load_combo(combo_status, "status", "tbl_statuskerja")
        Application.CurrentCulture = New CultureInfo("EN-US")
    End Sub

    Private Sub format_tgl()
        format_tanggal_kosong(DTawal)
        format_tanggal_kosong(DTakhir)
    End Sub

    Private Sub tampil_data(ByVal cond_dept As String, ByVal cond_status As String)
        Try
            clear_command()
            openDB()
            If combo_dept.Text = String.Empty And combo_status.Text = String.Empty Then
                sql = "SELECT view_pegawai.nik, view_pegawai.nama, view_pegawai.departemen , " & _
                "view_pegawai.jabatan, tbl_temp.tanggal, tbl_temp .timein ,tbl_temp .timeout  " & _
                "FROM (SELECT tbl_dataabsen .nik, tbl_dataabsen .tanggal , tbl_dataabsen .timein , " & _
                "tbl_dataabsen .timeout FROM tbl_dataabsen " & _
                "WHERE tbl_dataabsen .tanggal BETWEEN @awal AND @akhir) AS tbl_temp " & _
                "RIGHT OUTER JOIN view_pegawai ON tbl_temp.nik = view_pegawai.nik " & _
                "ORDER BY view_pegawai.nik, tbl_temp.tanggal"
            ElseIf Not combo_dept.Text = String.Empty And combo_status.Text = String.Empty Then
                sql = "SELECT view_pegawai.nik, view_pegawai.nama, view_pegawai.departemen , " & _
                "view_pegawai.jabatan, tbl_temp.tanggal, tbl_temp .timein ,tbl_temp .timeout  " & _
                "FROM (SELECT tbl_dataabsen .nik, tbl_dataabsen .tanggal , tbl_dataabsen .timein , " & _
                "tbl_dataabsen .timeout FROM tbl_dataabsen " & _
                "WHERE tbl_dataabsen .tanggal BETWEEN @awal AND @akhir) AS tbl_temp " & _
                "RIGHT OUTER JOIN view_pegawai ON tbl_temp.nik = view_pegawai.nik " & _
                "WHERE view_pegawai.departemen = @departemen ORDER BY view_pegawai.nik, tbl_temp.tanggal"
            ElseIf combo_dept.Text = String.Empty And Not combo_status.Text = String.Empty Then
                sql = "SELECT view_pegawai.nik, view_pegawai.nama, view_pegawai.departemen , " & _
                "view_pegawai.jabatan, tbl_temp.tanggal, tbl_temp .timein ,tbl_temp .timeout  " & _
                "FROM (SELECT tbl_dataabsen .nik, tbl_dataabsen .tanggal , tbl_dataabsen .timein , " & _
                "tbl_dataabsen .timeout FROM tbl_dataabsen " & _
                "WHERE tbl_dataabsen .tanggal BETWEEN @awal AND @akhir) AS tbl_temp " & _
                "RIGHT OUTER JOIN view_pegawai ON tbl_temp.nik = view_pegawai.nik " & _
                "WHERE view_pegawai.status = @status " & _
                "ORDER BY view_pegawai.nik, tbl_temp.tanggal"
            ElseIf Not combo_dept.Text = String.Empty And Not combo_status.Text = String.Empty Then
                sql = "SELECT view_pegawai.nik, view_pegawai.nama, view_pegawai.departemen , " & _
                "view_pegawai.jabatan, tbl_temp.tanggal, tbl_temp .timein ,tbl_temp .timeout  " & _
                "FROM (SELECT tbl_dataabsen .nik, tbl_dataabsen .tanggal , tbl_dataabsen .timein , " & _
                "tbl_dataabsen .timeout FROM tbl_dataabsen " & _
                "WHERE tbl_dataabsen .tanggal BETWEEN @awal AND @akhir) AS tbl_temp " & _
                "RIGHT OUTER JOIN view_pegawai ON tbl_temp.nik = view_pegawai.nik " & _
                "WHERE view_pegawai.departemen = @departemen AND view_pegawai.status = @status " & _
                "ORDER BY view_pegawai.nik, tbl_temp.tanggal"
            End If
            sqlcmd = New SqlCommand(sql, Conn)
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            With sqlcmd.Parameters
                .Add("@awal", SqlDbType.Date).Value = DTawal.Text
                .Add("@akhir", SqlDbType.Date).Value = DTakhir.Text
                .Add("@departemen", SqlDbType.VarChar).Value = combo_dept.Text
                .Add("@status", SqlDbType.VarChar).Value = combo_status.Text
            End With
            DataTab = New DataTable
            DataTab.Clear()
            sqladapter.Fill(DataTab)
            grid_tampil.DataSource = DataTab
            Cursor.Current = Cursors.WaitCursor
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Private Sub tampil_detail()
        Try
            clear_command()
            openDB()
            sql = "SELECT view_pegawai.nik, view_pegawai.nama, " & _
                "CONVERT(date,tbl_rawabsen.tanggal) AS tgl, " & _
                "CONVERT(time, tbl_rawabsen.tanggal) as waktu " & _
                "FROM tbl_rawabsen LEFT OUTER JOIN view_pegawai ON tbl_rawabsen .nik = view_pegawai.nik " & _
                "WHERE view_pegawai.nik = @nik AND " & _
                "CONVERT(date,tbl_rawabsen .tanggal) BETWEEN @awal AND @akhir " & _
                "ORDER BY CONVERT(time, tbl_rawabsen.tanggal)"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = grid_tampil.Rows(rowindex).cells(0).value
                .Add("@awal", SqlDbType.Date).Value = DTawal.Text
                .Add("@akhir", SqlDbType.Date).Value = DTakhir.Text
            End With
            sqladapter.SelectCommand = sqlcmd
            sqladapter = New SqlDataAdapter(sql, Conn)
            DataTab = New DataTable
            DataTab.Clear()
            sqladapter.Fill(DataTab)
            grid_detaildata.DataSource = DataTab
        Catch Ex As Exception
        End Try
    End Sub

    Private Sub DTawal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTawal.ValueChanged
        format_tanggal(DTawal)
    End Sub

    Private Sub DTakhir_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTakhir.ValueChanged
        format_tanggal(DTakhir)
    End Sub

    Private Sub CekHistoriToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CekHistoriToolStripMenuItem.Click

    End Sub

    Private Sub combo_dept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_dept.SelectedIndexChanged
        If grid_tampil.RowCount < 1 Then
            MsgBox("silahkan jalankan terlebih dahulu ", MsgBoxStyle.Information, "INFO")
        Else
        If combo_status.Text = String.Empty Then
            tampil_data("AND view_pegawai.departemen = '" & combo_dept.Text & "'", Nothing)
        Else
            tampil_data("AND view_pegawai.departemen = '" & combo_dept.Text & "'", "AND view_pegawai.status = '" & combo_status.Text & "'")
            End If
        End If
    End Sub

    Private Sub combo_status_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_status.SelectedIndexChanged
        If grid_tampil.RowCount < 1 Then
            MsgBox("Silahkan jalankan terlebih dahulu", MsgBoxStyle.Information, "INFO")
        Else
            If combo_dept.Text = String.Empty Then
                tampil_data("AND view_pegawai.status = '" & combo_status.Text & "'", Nothing)
            Else
                tampil_data("AND view_pegawai.departemen = '" & combo_dept.Text & "'", "AND view_pegawai.status = '" & combo_status.Text & "'")
            End If
        End If
        
    End Sub

    Private Sub Button_tampil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_tampil.Click
        tampil_data(Nothing, Nothing)
    End Sub

    Private Sub grid_tampil_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grid_tampil.CellMouseUp
        With grid_tampil
            If e.Button = MouseButtons.Right Then
                If .Rows.Count > 1 Then
                    .ContextMenuStrip = ContextMenuStrip1
                    rowindex = .CurrentRow.Index
                    nik = .Rows(rowindex).Cells(0).Value
                    Me.ContextMenuStrip1.Show(Me.grid_tampil, e.Location)
                    Me.ContextMenuStrip1.Show(Cursor.Position)
                Else
                    .ContextMenuStrip = Nothing
                End If
            End If
        End With
    End Sub

    Private Sub Text_nama_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_nama.TextChanged
        Try
            clear_command()
            openDB()
            If combo_dept.Text = String.Empty And combo_status.Text = String.Empty Then
                sql = "SELECT view_pegawai.nik, view_pegawai.nama, view_pegawai.departemen , " & _
                "view_pegawai.jabatan, tbl_temp.tanggal, tbl_temp .timein ,tbl_temp .timeout  " & _
                "FROM (SELECT tbl_dataabsen .nik, tbl_dataabsen .tanggal , tbl_dataabsen .timein , " & _
                "tbl_dataabsen .timeout FROM tbl_dataabsen " & _
                "WHERE tbl_dataabsen .tanggal BETWEEN @awal AND @akhir) AS tbl_temp " & _
                "RIGHT OUTER JOIN view_pegawai ON tbl_temp.nik = view_pegawai.nik " & _
                "WHERE view_pegawai.nama LIKE '%" & Text_nama.Text & "%' " & _
                "ORDER BY view_pegawai.nik, tbl_temp.tanggal"
            ElseIf Not combo_dept.Text = String.Empty And combo_status.Text = String.Empty Then
                sql = "SELECT view_pegawai.nik, view_pegawai.nama, view_pegawai.departemen , " & _
                "view_pegawai.jabatan, tbl_temp.tanggal, tbl_temp .timein ,tbl_temp .timeout  " & _
                "FROM (SELECT tbl_dataabsen .nik, tbl_dataabsen .tanggal , tbl_dataabsen .timein , " & _
                "tbl_dataabsen .timeout FROM tbl_dataabsen " & _
                "WHERE tbl_dataabsen .tanggal BETWEEN @awal AND @akhir) AS tbl_temp " & _
                "RIGHT OUTER JOIN view_pegawai ON tbl_temp.nik = view_pegawai.nik " & _
                "WHERE view_pegawai.departemen = @departemen AND view_pegawai.nama LIKE '%" & Text_nama.Text & "%' " & _
                "ORDER BY view_pegawai.nik, tbl_temp.tanggal"
            ElseIf combo_dept.Text = String.Empty And Not combo_status.Text = String.Empty Then
                sql = "SELECT view_pegawai.nik, view_pegawai.nama, view_pegawai.departemen , " & _
                "view_pegawai.jabatan, tbl_temp.tanggal, tbl_temp .timein ,tbl_temp .timeout  " & _
                "FROM (SELECT tbl_dataabsen .nik, tbl_dataabsen .tanggal , tbl_dataabsen .timein , " & _
                "tbl_dataabsen .timeout FROM tbl_dataabsen " & _
                "WHERE tbl_dataabsen .tanggal BETWEEN @awal AND @akhir) AS tbl_temp " & _
                "RIGHT OUTER JOIN view_pegawai ON tbl_temp.nik = view_pegawai.nik " & _
                "WHERE view_pegawai.status = @status AND view_Pegawai.nama LIKE '%" & Text_nama.Text & "%' " & _
                "ORDER BY view_pegawai.nik, tbl_temp.tanggal"
            ElseIf Not combo_dept.Text = String.Empty And Not combo_status.Text = String.Empty Then
                sql = "SELECT view_pegawai.nik, view_pegawai.nama, view_pegawai.departemen , " & _
                "view_pegawai.jabatan, tbl_temp.tanggal, tbl_temp .timein ,tbl_temp .timeout  " & _
                "FROM (SELECT tbl_dataabsen .nik, tbl_dataabsen .tanggal , tbl_dataabsen .timein , " & _
                "tbl_dataabsen .timeout FROM tbl_dataabsen " & _
                "WHERE tbl_dataabsen .tanggal BETWEEN @awal AND @akhir) AS tbl_temp " & _
                "RIGHT OUTER JOIN view_pegawai ON tbl_temp.nik = view_pegawai.nik " & _
                "WHERE view_pegawai.departemen = @departemen AND view_pegawai.status = @status " & _
                "AND view_pegawai.nama LIKE '%" & Text_nama.Text & "%' " & _
                "ORDER BY view_pegawai.nik, tbl_temp.tanggal"
            End If
            sqlcmd = New SqlCommand(sql, Conn)
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            With sqlcmd.Parameters
                .Add("@awal", SqlDbType.Date).Value = DTawal.Text
                .Add("@akhir", SqlDbType.Date).Value = DTakhir.Text
                .Add("@departemen", SqlDbType.VarChar).Value = combo_dept.Text
                .Add("@status", SqlDbType.VarChar).Value = combo_status.Text
            End With
            DataTab = New DataTable
            DataTab.Clear()
            sqladapter.Fill(DataTab)
            grid_tampil.DataSource = DataTab
            Cursor.Current = Cursors.WaitCursor
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Private Sub CekLaporanPersonalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CekLaporanPersonalToolStripMenuItem.Click
        nik_global = grid_tampil.Rows(rowindex).Cells(0).Value
        FormDetRiwayat.Show()
        FormDetRiwayat.WindowState = FormWindowState.Maximized
        FormDetRiwayat.MdiParent = FormMenuUtama
    End Sub
End Class