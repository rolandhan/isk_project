Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Public Class FormKontrak
    Dim RowIndex As Integer
    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub FormKontrak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CekStatusKontrak(Nothing, Nothing)
    End Sub

    Private Sub CekStatusKontrak(ByVal Pilihan As String, ByVal Cari As String)
        Try
            clear_command()
            openDB()
            Select Case Pilihan
                Case Nothing
                    sql = "SELECT * FROM  (SELECT tbl_pegawai.nik, tbl_pegawai.nama, jab.departemen, jab.jabatan, jab.atasan, jab.status_karyawan, " & _
                "jab.tgl_awal,jab.tgl_akhir,DATEDIFF(day, GETDATE(), tgl_akhir) AS hari " & _
                "FROM tbl_pegawai OUTER APPLY " & _
                "(SELECT  TOP (1) tbl_jabatan.nik, tbl_jabatan.departemen, tbl_jabatan.jabatan, tbl_jabatan.atasan, " & _
                "tbl_jabatan.status_karyawan, tbl_jabatan.tgl_awal , tbl_jabatan.tgl_akhir " & _
                "FROM tbl_jabatan " & _
                "WHERE tbl_jabatan.nik = tbl_pegawai.nik " & _
                "ORDER BY tbl_jabatan.no_urut DESC) AS jab) As Temp " & _
                "where (Temp.status_karyawan = 'Kontrak' OR temp.status_karyawan LIKE 'Harian%') AND (temp.hari < 7 AND temp.hari > 0) " & _
                "AND temp.status_karyawan <> 'keluar'"
                Case "Departemen"
                    sql = "SELECT * FROM  (SELECT tbl_pegawai.nik, tbl_pegawai.nama, jab.departemen, jab.jabatan, jab.atasan, jab.status_karyawan, " & _
                "jab.tgl_awal,jab.tgl_akhir,DATEDIFF(day, GETDATE(), tgl_akhir) AS hari " & _
                "FROM tbl_pegawai OUTER APPLY " & _
                "(SELECT  TOP (1) tbl_jabatan.nik, tbl_jabatan.departemen, tbl_jabatan.jabatan, tbl_jabatan.atasan, " & _
                "tbl_jabatan.status_karyawan, tbl_jabatan.tgl_awal , tbl_jabatan.tgl_akhir " & _
                "FROM tbl_jabatan " & _
                "WHERE tbl_jabatan.nik = tbl_pegawai.nik " & _
                "ORDER BY tbl_jabatan.no_urut DESC) AS jab) As Temp " & _
                "where (Temp.status_karyawan = 'Kontrak' OR temp.status_karyawan LIKE 'Harian%') AND (temp.hari < 7 AND temp.hari > 0) " & _
                "AND Temp.status_karyawan <> 'keluar' AND Temp.departemen = '" & Cari & "'"
                Case "Pencarian"
                    sql = "SELECT * FROM  (SELECT tbl_pegawai.nik, tbl_pegawai.nama, jab.departemen, jab.jabatan, jab.atasan, jab.status_karyawan, " & _
                "jab.tgl_awal,jab.tgl_akhir,DATEDIFF(day, GETDATE(), tgl_akhir) AS hari " & _
                "FROM tbl_pegawai OUTER APPLY " & _
                "(SELECT  TOP (1) tbl_jabatan.nik, tbl_jabatan.departemen, tbl_jabatan.jabatan, tbl_jabatan.atasan, " & _
                "tbl_jabatan.status_karyawan, tbl_jabatan.tgl_awal , tbl_jabatan.tgl_akhir " & _
                "FROM tbl_jabatan " & _
                "WHERE tbl_jabatan.nik = tbl_pegawai.nik " & _
                "ORDER BY tbl_jabatan.no_urut DESC) AS jab) As Temp " & _
                "where (Temp.status_karyawan = 'Kontrak' OR temp.status_karyawan LIKE 'Harian%') AND (temp.hari < 7 AND temp.hari > 0) " & _
                "AND Temp.status_karyawan <> 'keluar' AND Temp.nama LIKE '%" & Cari & "%'"
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            GridKaryawan.DataSource = DTab
            AturGrid()
            GridKaryawan.Refresh()
        Catch ex As Exception
            MsgBox("gagal dalam melakukan memuat daftar masa kontrak " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub AturGrid()
        With GridKaryawan
            .ReadOnly = True
            .Columns(0).HeaderText = "NIK"
            .Columns(0).Width = 70
            .Columns(0).Frozen = True
            .Columns(1).HeaderText = "Nama"
            .Columns(1).Width = 200
            .Columns(1).Frozen = True
            .Columns(2).HeaderText = "Departemen"
            .Columns(2).Width = 100
            .Columns(3).HeaderText = "Jabatan"
            .Columns(3).Width = 180
            '.Columns(3).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            '.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .Columns(4).HeaderText = "Atasan"
            .Columns(4).Width = 120
            .Columns(5).HeaderText = "Status Karyawan"
            .Columns(5).Width = 100
            .Columns(6).HeaderText = "Tanggal Awal"
            .Columns(6).Width = 100
            .Columns(7).HeaderText = "Tanggal Akhir"
            .Columns(7).Width = 100
            .Columns(8).HeaderText = "Sisa Hari Kontrak Habis"
            .Columns(8).Width = 80
            '.Columns(17).DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .RowHeadersWidth = 60
        End With
    End Sub

    Private Sub Text_pencarian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_pencarian.TextChanged
        CekStatusKontrak("Pencarian", Text_pencarian.Text)
    End Sub

    Private Sub combo_dept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_dept.SelectedIndexChanged
        CekStatusKontrak("Departemen", combo_dept.Text)
    End Sub

    Private Sub RenewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenewToolStripMenuItem.Click
        nik_global = GridKaryawan.Rows(RowIndex).Cells(0).Value
        FormDTJabatan.Show()
        FormDTJabatan.MdiParent = Me
        FormDTJabatan.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub GridKaryawan_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GridKaryawan.CellMouseUp
        With GridKaryawan
            If e.Button = MouseButtons.Right Then
                If .Rows.Count > 1 Then
                    .ContextMenuStrip = ContextMenuStrip1
                    rowindex = .CurrentRow.Index
                    Me.ContextMenuStrip1.Show(Me.GridKaryawan, e.Location)
                    Me.ContextMenuStrip1.Show(Cursor.Position)
                Else
                    .ContextMenuStrip = Nothing
                End If
            End If
        End With
    End Sub
End Class