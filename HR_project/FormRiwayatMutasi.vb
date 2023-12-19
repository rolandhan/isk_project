Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports VB = Microsoft.VisualBasic.Strings

Public Class FormRiwayatMutasi
    Dim RowIndex As Integer
    Dim IdMutasi, JenisData As String
    Private Sub FormRiwayatMutasi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        IsiCmbJenis()
    End Sub

    Private Sub IsiCmbJenis()
        With ComboJenis.Items
            .Add("Riwayat Harian")
            .Add("Riwayat Mutasi")
        End With
    End Sub

    Private Sub LoadDaftarKary(ByVal Filter As String)
        Try
            clear_command()
            openDB()
            Select Case Filter
                Case Nothing
                    sql = "SELECT DISTINCT tbl_mutasi.nik, nama ,status_karyawan ,depart_awal ,jabatan_awal , depart_akhir ,jabatan_akhir, " & _
                "no_ktp, idmutasi FROM tbl_mutasi LEFT OUTER JOIN view_dtpegawai ON tbl_mutasi.nik = view_dtpegawai.nik ORDER BY tbl_mutasi.nik"
                Case "Pencarian"
                    sql = "SELECT DISTINCT tbl_mutasi.nik, nama ,status_karyawan ,depart_awal ,jabatan_awal , depart_akhir ,jabatan_akhir, " & _
                        "no_ktp, idmutasi FROM tbl_mutasi LEFT OUTER JOIN view_dtpegawai ON tbl_mutasi.nik = view_dtpegawai.nik " & _
                        "WHERE tbl_mutasi.nik LIKE '%" & Text_pencarian.Text & "%' OR nama LIKE '%" & Text_pencarian.Text & "%' ORDER BY tbl_mutasi.nik"
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            GridDaftar.DataSource = DTab
            AturGrid(GridDaftar, "Daftar Karyawan")
            GridDaftar.Refresh()
        Catch ex As Exception
            MsgBox("gagal dalam menampilkan daftar karyawan " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub LoadDaftarMutasi(ByVal no_ktp As String)
        Try
            clear_command()
            openDB()
            sql = "SELECT nik, depart_awal, jabatan_awal, depart_akhir, jabatan_akhir, tgl_mutasi, atasan, " & _
                "ket, no_ktp, nik_lama, idmutasi FROM tbl_mutasi WHERE no_ktp = @no_ktp"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@no_ktp", SqlDbType.VarChar).Value = no_ktp
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            GridTampilData.DataSource = DTab
            AturGrid(GridTampilData, "Daftar Mutasi")
            GridTampilData.Refresh()
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data riwayat mutasi " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub LoadDaftarHarian(ByVal Filter As String)
        Try
            clear_command()
            openDB()
            Select Case Filter
                Case Nothing
                    sql = "SELECT DISTINCT nik, nama, no_ktp, departemen, jabatan, status_karyawan, atasan FROM view_pegawai " & _
                "WHERE status_karyawan LIKE '%harian%'"
                Case "Pencarian"
                    sql = "SELECT DISTINCT nik, nama, no_ktp, departemen, jabatan, status_karyawan, atasan FROM view_pegawai " & _
                "WHERE status_karyawan LIKE '%harian%' AND (nik LIKE '%" & Text_pencarian.Text & "%' OR nama LIKE '%" & Text_pencarian.Text & "%')"
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            GridDaftar.DataSource = DTab
            AturGrid(GridDaftar, "Daftar Harian")
            GridDaftar.Refresh()
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan daftar karyawan harian " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub LoadRiwayatHarian(ByVal no_ktp As String)
        Try
            clear_command()
            openDB()
            sql = "SELECT * FROM (SELECT tbl_jabatan.nik, Temp.nama, tbl_jabatan.departemen, tbL_jabatan.jabatan, tbl_jabatan.atasan, " & _
                "tbl_jabatan.status_karyawan,tbl_jabatan.tgl_awal, tbl_jabatan.tgl_akhir,  " & _
                "tbl_jabatan.nik_lama, tbl_jabatan.no_urut,Temp.no_ktp FROM (SELECT tbl_pegawai.nik, tbl_pegawai.nama, no_ktp FROM tbl_pegawai " & _
                "WHERE nik IN (SELECT tbl_jabatan.nik_lama FROM tbl_jabatan)) AS Temp " & _
                "RIGHT OUTER JOIN tbl_jabatan ON Temp.nik = tbl_jabatan.nik_lama) AS Temp2 WHERE Temp2.no_ktp = @no_ktp ORDER BY Temp2.tgl_akhir DESC"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@no_ktp", SqlDbType.VarChar).Value = no_ktp
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            GridTampilData.DataSource = DTab
            GridTampilData.Refresh()
        Catch ex As Exception
            MsgBox("Gagal dalam memuat daftar riwayat harian " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub AturGrid(ByVal Grid As DataGridView, ByVal Pilihan As String)
        With Grid
            Select Case Pilihan
                Case "Daftar Karyawan"
                    .ReadOnly = True
                    .Enabled = True
                    'SELECT nik, depart_awal, jabatan_awal, depart_akhir, jabatan_akhir, tgl_mutasi, atasan,ket, no_ktp, nik_lama, idmutasi
                    .Columns(0).HeaderText = "NIK"
                    .Columns(0).Width = "70"
                    .Columns(0).Frozen = True
                    .Columns(1).HeaderText = "Nama"
                    .Columns(1).Width = "200"
                    .Columns(1).Frozen = True
                    .Columns(2).HeaderText = "Status"
                    .Columns(2).Width = "100"
                    .Columns(3).HeaderText = "Dep Awal"
                    .Columns(3).Width = "110"
                    .Columns(4).HeaderText = "Jab Awal"
                    .Columns(4).Width = "200"
                    .Columns(5).HeaderText = "Dep Akhir"
                    .Columns(5).Width = "110"
                    .Columns(6).HeaderText = "Jab Akhir"
                    .Columns(6).Width = "200"
                    .Columns(7).HeaderText = "No KTP"
                    .Columns(7).Width = "80"
                    .Columns(8).HeaderText = "id mutasi"
                    .Columns(8).Visible = False
                    .RowHeadersWidth = 5
                Case "Daftar Harian"
                    .ReadOnly = True
                    .Enabled = True
                    .Columns(0).HeaderText = "NIK"
                    .Columns(0).Width = "70"
                    .Columns(0).Frozen = True
                    .Columns(1).HeaderText = "Nama"
                    .Columns(1).Width = "200"
                    .Columns(1).Frozen = True
                    .Columns(2).HeaderText = "No KTP"
                    .Columns(2).Width = "100"
                    .Columns(3).HeaderText = "Departemen"
                    .Columns(3).Width = "110"
                    .Columns(4).HeaderText = "Jabatan"
                    .Columns(4).Width = "200"
                    .Columns(5).HeaderText = "Status Karyawan"
                    .Columns(5).Width = "80"
                    .Columns(6).HeaderText = "Atasan"
                    .Columns(6).Width = "200"
                    .RowHeadersWidth = 5
                Case "Daftar Mutasi"
                    'nik, depart_awal, jabatan_awal, depart_akhir, jabatan_akhir, tgl_mutasi, atasan, ket, no_ktp, nik_lama, idmutasi FROM tbl_mutasi WHERE no_ktp = @no_ktp
                    .ReadOnly = True
                    .Enabled = True
                    .Columns(0).HeaderText = "NIK"
                    .Columns(0).Width = "70"
                    .Columns(0).Frozen = True
                    .Columns(1).HeaderText = "Dep Awal"
                    .Columns(1).Width = "100"
                    .Columns(1).Frozen = True
                    .Columns(2).HeaderText = "Jab Awal"
                    .Columns(2).Width = "100"
                    .Columns(3).HeaderText = "Dep Akhir"
                    .Columns(3).Width = "100"
                    .Columns(4).HeaderText = "Jab Akhir"
                    .Columns(4).Width = "100"
                    .Columns(5).HeaderText = "Tanggal Mutasi"
                    .Columns(5).Width = "80"
                    .Columns(6).HeaderText = "Atasan"
                    .Columns(6).Width = "100"
                    .Columns(7).HeaderText = "Ket"
                    .Columns(7).Width = "200"
                    .Columns(8).HeaderText = "No KTP"
                    .Columns(8).Width = "100"
                    .Columns(9).HeaderText = "NIK lama"
                    .Columns(9).Width = "80"
                    .Columns(10).HeaderText = "ID Mutasi"
                    .Columns(10).Visible = False
                    .RowHeadersWidth = 5
            End Select


        End With
    End Sub

    Private Sub ComboJenis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboJenis.SelectedIndexChanged
        Select Case ComboJenis.Text
            Case "Riwayat Harian"
                LoadDaftarHarian(Nothing)
            Case "Riwayat Mutasi"
                LoadDaftarKary(Nothing)
        End Select
    End Sub

    Private Sub Text_pencarian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_pencarian.TextChanged
        Select Case ComboJenis.Text
            Case "Riwayat Harian"
                LoadDaftarHarian("Pencarian")
            Case "Riwayat Mutasi"
                LoadDaftarKary("Pencarian")
        End Select
    End Sub

    Private Sub GridDaftar_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridDaftar.CellContentDoubleClick
        With GridDaftar
            If .Rows.Count > 0 Then
                RowIndex = .CurrentRow.Index
                Select Case ComboJenis.Text
                    Case "Riwayat Harian"
                        Text_nik.Text = .Rows(RowIndex).Cells(0).Value
                        Text_nama.Text = .Rows(RowIndex).Cells(1).Value
                        Text_dept.Text = .Rows(RowIndex).Cells(3).Value
                        Text_jabatan.Text = .Rows(RowIndex).Cells(4).Value
                        LoadRiwayatHarian(.Rows(RowIndex).Cells(2).Value)
                    Case "Riwayat Mutasi"
                        Text_nik.Text = .Rows(RowIndex).Cells(0).Value
                        Text_nama.Text = .Rows(RowIndex).Cells(1).Value
                        Text_dept.Text = .Rows(RowIndex).Cells(5).Value
                        Text_jabatan.Text = .Rows(RowIndex).Cells(6).Value
                        LoadDaftarMutasi(.Rows(RowIndex).Cells(7).Value)
                End Select
            End If
        End With
    End Sub

    Private Sub GridDaftar_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridDaftar.CellContentClick

    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        GridDaftar.SelectionMode = DataGridViewSelectionMode.CellSelect
        IdMutasi = GridDaftar.Rows(RowIndex).Cells(10).Value
    End Sub

    Private Sub GridDaftar_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles GridDaftar.CellMouseUp
        With GridDaftar
            If e.Button = MouseButtons.Right Then
                If .Rows.Count > 1 Then
                    ContextMenuStrip = ContextMenuStrip1
                    RowIndex = .CurrentRow.Index
                    Me.ContextMenuStrip1.Show(Me.GridDaftar, e.Location)
                    Me.ContextMenuStrip1.Show(Cursor.Position)
                End If
            Else
                ContextMenuStrip = Nothing
            End If
        End With
    End Sub

    Private Sub GridDaftar_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridDaftar.CellEndEdit
        
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox(IdMutasi)
    End Sub
End Class