Imports System.Data.Sql
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Globalization

Public Class FormDetail_Pegawai
    Dim Rpt As New ReportDocument

    Private rowindex As Integer
    Private Sub FormDetail_Pegawai_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New CultureInfo("EN-US")
        load_gridkaryawan(Nothing)
        load_combo(Combo_depart, "departemen", "tbl_statuskerja")
    End Sub

    Private Sub load_gridkaryawan(ByVal cond_dept As String)
        Try
            clear_command()
            openDB()
            If cond_dept = String.Empty Then
                sql = "select nik, nama, departemen, jabatan, status, atasan from view_pegawai"
            Else
                sql = "select nik, nama, departemen, jabatan, status, atasan from view_pegawai " & _
                    "WHERE departemen = '" & cond_dept & "'"
            End If
            sqladapter = New SqlDataAdapter(sql, Conn)
            dtset = New DataSet
            dtset.Clear()
            sqladapter.Fill(dtset, "view_pegawai")
            Grid_karyawan.DataSource = dtset.Tables("view_pegawai")
            atur_gridkaryawan()
            Grid_karyawan.Refresh()
        Catch ex As Exception
            MsgBox("gagal menampilkan data", MsgBoxStyle.Information, "INFO")
        End Try
    End Sub

    Private Sub load_gridriwayat()
        Try
            clear_command()
            openDB()
            sql = "select  departemen, jabatan, status_karyawan, tgl_awal, tgl_akhir,  no_urut, atasan " & _
                "FROM tbl_jabatan where nik = '" & Text_nik.Text & "'"
            sqladapter = New SqlDataAdapter(sql, Conn)
            dtset = New DataSet
            dtset.Clear()
            sqladapter.Fill(dtset, "tbl_jabatan")
            grid_riwayat.DataSource = dtset.Tables("tbl_jabatan")
            atur_gridriwayat()
            grid_riwayat.Refresh()
        Catch ex As Exception
            MsgBox("Gagal menampilkan riwayata jabatan " & ex.Message, MsgBoxStyle.Information, "INFO")
        End Try
    End Sub

    Private Sub atur_gridkaryawan()
        With Grid_karyawan
            .ReadOnly = True
            .Enabled = True
            .Columns(0).HeaderText = "NIK"
            .Columns(0).Width = "75"
            .Columns(1).HeaderText = "Nama"
            .Columns(1).Width = "150"
            .Columns(2).HeaderText = "Departemen"
            .Columns(2).Width = "100"
            .Columns(3).HeaderText = "Jabatan"
            .Columns(3).Width = "150"
            .Columns(4).HeaderText = "status"
            .Columns(4).Width = "55"
            .Columns(5).HeaderText = "atasan"
            .Columns(5).Width = "75"
            .RowHeadersWidth = 5
        End With
    End Sub

    Private Sub atur_gridriwayat()
        With grid_riwayat
            .ReadOnly = True
            .Enabled = True
            .Columns(0).HeaderText = "departemen"
            .Columns(0).Width = "100"
            .Columns(1).HeaderText = "jabatan"
            .Columns(1).Width = "200"
            .Columns(2).HeaderText = "status_karyawan"
            .Columns(2).Width = "75"
            .Columns(3).HeaderText = "Periode Awal"
            .Columns(3).Width = "75"
            .Columns(4).HeaderText = "Periode Akhir"
            .Columns(4).Width = "75"
            .Columns(5).HeaderText = "no_urut"
            .Columns(5).Visible = False
            .Columns(6).HeaderText = "Atasan"
            .Columns(6).Visible = False
            .RowHeadersWidth = 5
        End With
    End Sub

    Private Sub Grid_karyawan_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid_karyawan.CellContentDoubleClick
        With Grid_karyawan
            Text_nik.Text = .Rows(.CurrentRow.Index).Cells(0).Value
            Text_nama.Text = .Rows(.CurrentRow.Index).Cells(1).Value
            Text_dept.Text = .Rows(.CurrentRow.Index).Cells(2).Value
            Text_Atasan.Text = .Rows(.CurrentRow.Index).Cells(5).Value
            Combo_status.Text = .Rows(.CurrentRow.Index).Cells(4).Value
        End With
        load_gridriwayat()
    End Sub

    Private Sub grid_riwayat_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grid_riwayat.CellMouseUp
        With grid_riwayat
            If e.Button = MouseButtons.Right Then
                If .Rows.Count > 1 Then
                    .ContextMenuStrip = ContextMenuStrip1
                    rowindex = .CurrentRow.Index
                    Me.ContextMenuStrip1.Show(Me.grid_riwayat, e.Location)
                    Me.ContextMenuStrip1.Show(Cursor.Position)
                Else
                    .ContextMenuStrip = Nothing
                End If
            End If
        End With
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click

    End Sub

    Private Sub ButtonCetak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetak.Click
        Try
            clear_command()
            openDB()
            sql = "SELECT view_pegawai .nik, view_pegawai.nama, view_pegawai .departemen, " & _
                "view_pegawai.jabatan, view_pegawai.status, view_pegawai.atasan, " & _
                "tbl_jabatan.departemen As Depart, tbl_jabatan.jabatan As Jabt , tbl_jabatan.status_karyawan As Stat, " & _
                "tbl_jabatan.tgl_awal, tbl_jabatan.tgl_akhir, tbl_jabatan.no_urut " & _
                "FROM view_pegawai RIGHT OUTER JOIN tbl_jabatan ON view_pegawai .nik = tbl_jabatan .nik " & _
                "WHERE view_pegawai.nik = @nik"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DataTab = New DataTable
            DataTab.Clear()
            sqladapter.Fill(DataTab)

            Rpt.Load(Application.StartupPath & "\reports\LporanDtJbtan.rpt")
            Rpt.SetDatabaseLogon(user:=uid, password:=pass)
            Rpt.SetDataSource(DataTab)
            FormLaporan.CrystalReportViewer1.ReportSource = Rpt
            FormLaporan.ShowDialog()
            FormLaporan.Dispose()
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data" & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub Text_pencarian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_pencarian.TextChanged
        Try
            clear_command()
            openDB()
            sql = "SELECT nik, nama, departemen, jabatan, status, atasan from view_pegawai " & _
                "WHERE nama LIKE '%" & Text_pencarian.Text & "%' OR nik LIKE '%" & Text_pencarian.Text & "%'"
            sqladapter = New SqlDataAdapter(sql, Conn)
            DataTab = New DataTable
            DataTab.Clear()
            sqladapter.Fill(DataTab)
            Grid_karyawan.DataSource = DataTab
            Grid_karyawan.Refresh()
        Catch ex As Exception
            MsgBox("gagal menampilkan data " & ex.Message)
        End Try
    End Sub

    Private Sub Combo_depart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_depart.SelectedIndexChanged
        load_gridkaryawan(Combo_depart.Text)
    End Sub

    Private Sub Grid_karyawan_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid_karyawan.CellContentClick

    End Sub

    Private Sub grid_riwayat_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_riwayat.CellContentClick

    End Sub
End Class