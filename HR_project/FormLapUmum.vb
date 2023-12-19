Imports System.Data.Sql
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class FormLapUmum
    Dim laporan As String
    Private Sub FormLapUmum_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_cmbjnsALL()
        load_cmbjnsPer()
        load_gridkaryawan(Combo_depart.Text, Combo_filterS.Text)

    End Sub

    Private Sub load_cmbjnsALL()
        With Combo_jnsAll
            .Items.Add("Laporan Isolasi Mandiri")
        End With
    End Sub

    Private Sub load_cmbjnsPer()
        With Combo_jnsPer
            .Items.Add("Laporan Kecelakaan Kerja")
            .Items.Add("Presensi Bulanan")
            .Items.Add("Daftar Isolasi Mandiri")
            .Items.Add("Laporan Rincian Bulanan")
        End With
    End Sub

    Private Sub load_gridkaryawan(ByVal cond_dept As String, ByVal status As String)
        Try
            clear_command()
            openDB()
            If cond_dept = String.Empty Then
                If status = String.Empty Then
                    sql = "select nik, nama, departemen, jabatan, status, atasan from view_pegawai"
                Else
                    sql = "select nik, nama, departemen, jabatan, status, atasan from view_pegawai " & _
                    "where status = '" & status & "'"
                End If
            Else
                If status = String.Empty Then
                    sql = "select nik, nama, departemen, jabatan, status, atasan from view_pegawai " & _
                        "where departemen = '" & cond_dept & "'"
                Else
                    sql = "select nik, nama, departemen, jabatan, status, atasan from view_pegawai " & _
                        "where departemen = '" & cond_dept & "' AND status = '" & status & "'"
                End If
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
            Conn.Close()
        End Try
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


    Private Sub Combo_jnsAll_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_jnsAll.SelectedIndexChanged
        laporan = Combo_jnsAll.Text
    End Sub

    Private Sub Combo_jnsPer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_jnsPer.SelectedIndexChanged
        laporan = Combo_jnsPer.Text
    End Sub

    Private Sub Button_cetak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_cetak.Click
        If RadioB_All.Checked = True Then
            'cetak laporan keseluruhan
            If laporan = "Laporan Isolasi Mandiri" Then
                'load laporan isolasi mandiri
            End If
        ElseIf RadioB_Pers.Checked = True Then
            'cetak laporan personal
            Select Case laporan
                Case "Laporan Kecelakaan Kerja"
                    'load laporan
                Case "Presensi Bulanan"
                    'load laporan
                Case "Daftar Isolasi Mandiri"
                    'load laporan isolasi mandiri personal
                Case "Laporan Rincian Bulanan"
                    'load laporan rincian bulanan
            End Select
        End If
    End Sub
End Class