Imports System.Data.SqlClient
Imports System.Data.Sql
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports VB = Microsoft.VisualBasic.Strings
Imports System.Globalization

Public Class FormDaftarPotongan
    Dim jmlhari As Long
    Private Sub FormDaftarPotongan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New CultureInfo("EN-US")
        load_combojenis()
        clear_date(Me, Group_periode)
    End Sub

    Private Sub load_combojenis()
        With combo_jenis.Items
            .Add("Pemotongan Absensi")
            .Add("Pemotongan Kartu Makan")
            .Add("Pemotongan Ijin 1 Jam Meninggalkan Pekerjaan (Security)")
            .Add("Pemotongan Sanksi Tata Tertib dan Disiplin Kerja")
            .Add("Pengembalian Potongan")
        End With
    End Sub

    Private Sub load_grid(ByVal grid As DataGridView, ByVal status As String)
        Try
            clear_command()
            openDB()
            sql = "SELECT ROW_NUMBER() OVER(ORDER BY view_dtpegawai.nik ASC) AS No, " & _
                "view_dtpegawai.nama, view_dtpegawai.nik,view_dtpegawai.departemen,view_dtpegawai.jabatan, " & _
                "view_dtpegawai.status_karyawan, tbl_p.tanggal, COALESCE(SUM(CASE WHEN tbl_p.status = @status AND " & _
                "tbl_p.tanggal BETWEEN @tglawal AND @tglakhir THEN 1 ELSE NULL END),0) as jumlah, tbl_p.status, tbl_p.keterangan " & _
                "FROM (SELECT nik, tanggal, keterangan, no_id, status FROM tbl_potongan " & _
                "WHERE tbl_potongan.status  = @status AND (tanggal BETWEEN @tglawal AND @tglakhir) ) as tbl_p " & _
                "LEFT OUTER JOIN view_dtpegawai ON tbl_p.nik = view_dtpegawai.nik " & _
                "GROUP BY view_dtpegawai.nama, view_dtpegawai.nik,view_dtpegawai.departemen, " & _
                "view_dtpegawai.jabatan, view_dtpegawai.status_karyawan, tbl_p.tanggal, tbl_p.status, tbl_p.keterangan"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@tglawal", SqlDbType.Date).Value = DTawal.Text
                .Add("@tglakhir", SqlDbType.Date).Value = DTakhir.Text
                .Add("@status", SqlDbType.VarChar).Value = status
            End With
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            grid.DataSource = DTab
            atur_grid(grid_tampilan)
            grid.Refresh()
        Catch Ex As Exception
            MsgBox("Gagal dalam menampilkan data " & Ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub load_judul(ByVal combo As ComboBox)
        jmlhari = DateDiff("d", DTawal.Text, DTakhir.Text)
        Select Case combo.Text
            Case "Pemotongan Absensi"
                If jmlhari > 5 And jmlhari < 8 Then
                    Label_judul.Text = "DAFTAR PEMOTONGAN ABSENSI - MINGGUAN"
                ElseIf jmlhari > 27 And jmlhari < 32 Then
                    Label_judul.Text = "DAFTAR PEMOTONGAN ABSENSI - BULANAN"
                End If
            Case "Pemotongan Kartu Makan"
                If jmlhari > 5 And jmlhari < 8 Then
                    Label_judul.Text = "DAFTAR PEMOTONGAN KARTU MAKAN - MINGGUAN"
                ElseIf jmlhari > 27 And jmlhari < 32 Then
                    Label_judul.Text = "DAFTAR PEMOTONGAN KARTU MAKAN - BULANAN"
                End If
            Case "Pemotongan Ijin 1 Jam Meninggalkan Pekerjaan (Security)"
                If jmlhari > 5 And jmlhari < 8 Then
                    Label_judul.Text = "DAFTAR POTONGAN IJIN 1 JAM MENINGGALKAN PEKERJAAN (SECURITY) - MINGGUAN"
                ElseIf jmlhari > 27 And jmlhari < 32 Then
                    Label_judul.Text = "DAFTAR POTONGAN IJIN 1 JAM MENINGGALKAN PEKERJAAN (SECURITY) - BULANAN"
                End If
            Case "Pemotongan Sanksi Tata Tertib dan Disiplin Kerja"
                If jmlhari > 5 And jmlhari < 8 Then
                    Label_judul.Text = "DAFTAR POTONGAN SANKSI TATA TERTIB DAN DISIPLIN KERJA - MINGGUAN"
                ElseIf jmlhari > 27 And jmlhari < 32 Then
                    Label_judul.Text = "DAFTAR POTONGAN SANKSI TATA TERTIB DAN DISIPLIN KERJA - BULANAN"
                End If
            Case "Pengembalian Potongan"
                If jmlhari > 5 And jmlhari < 8 Then
                    Label_judul.Text = "DAFTAR PENGEMBALIAN POTONGAN ABSEN - MINGGUAN"
                ElseIf jmlhari > 27 And jmlhari < 32 Then
                    Label_judul.Text = "DAFTAR PENGEMBALIAN POTONGAN ABSEN - BULANAN"
                End If
        End Select
    End Sub

    Private Sub atur_grid(ByVal grid As DataGridView)
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
            .Columns(4).HeaderText = "Jabatan"
            .Columns(4).Visible = False
            .Columns(5).HeaderText = "Status"
            .Columns(5).Visible = False
            .Columns(6).HeaderText = "Tanggal"
            .Columns(6).Width = "80"
            .Columns(7).HeaderText = "Jumlah"
            .Columns(7).Width = "50"
            .Columns(8).HeaderText = "status"
            .Columns(8).Visible = False
            .Columns(9).HeaderText = "Keterangan"
            .Columns(9).Width = "312"
            .RowHeadersWidth = 5
        End With
    End Sub


    Private Sub combo_jenis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_jenis.SelectedIndexChanged
        load_grid(grid_tampilan, combo_jenis.Text)
        load_judul(combo_jenis)
    End Sub

    Private Sub DTawal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTawal.ValueChanged
        format_tanggal(DTawal)
    End Sub

    Private Sub DTakhir_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTakhir.ValueChanged
        format_tanggal(DTakhir)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim days As Long = DateDiff("d", DTawal.Text, DTakhir.Text)
        MsgBox(days)
    End Sub
End Class