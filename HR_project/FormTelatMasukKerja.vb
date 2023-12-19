Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports VB = Microsoft.VisualBasic.Strings
Imports System.Globalization

Public Class FormTelatMasukKerja
    Dim id_telat, periode As String
    Dim info, rowindex As Integer

    Private Sub Button_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_simpan.Click
        If Text_nik.Text = String.Empty Then
            MsgBox("NIK tidak boleh kosong ! ", MsgBoxStyle.Information, "INFO")
        ElseIf checking_data("nik", "tbl_telat", Text_nik.Text, " and tanggal = '" & Format(CDate(DT_tanggal.Text), "yyyy/M/d") & "'") = True Then
            If MsgBox("Data sudah ada, update data?", MsgBoxStyle.Information & MsgBoxStyle.OkCancel, "INFO") = vbOK Then
                edit_data()
            Else
                Text_nik.Focus()
            End If
        Else
            If MsgBox("Apakah data siap untuk disimpan ? ", MsgBoxStyle.Information & MsgBoxStyle.OkCancel, "INFO") = vbOK Then
                If simpan_data() = True And simpan_rekapkerja() = True Then
                    MsgBox("Data telah berhasil di simpan", MsgBoxStyle.Information, "INFO")
                    hapus()
                    loading_gridkaryawan(Nothing, Nothing)
                Else
                    MsgBox("Gagal dalam penyimpanan data", MsgBoxStyle.Information, "INFO")
                    hapus()
                End If
            Else
                Text_nik.Focus()
            End If
            End If
    End Sub

    Private Function cek_idtelat(ByVal nik As String) As String
        Try
            clear_command()
            openDB()
            sql = "SELECT TOP (1) nik, id_telat FROM tbl_telat " & _
                "WHERE nik = @nik ORDER BY tanggal DESC "
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = nik
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then '100000-0000-00'
                If Mid(sqlreader.Item("id_telat"), 8, 4) = VB.Right(Year(DT_tanggal.Text), 2) & _
                    VB.Right("00" & Month(DT_tanggal.Text), 2) Then
                    Return nik & "-" & VB.Right(Year(DT_tanggal.Text), 2) & VB.Right("00" & Month(DT_tanggal.Text), 2) & _
                    "-" & VB.Right("00" & CInt(VB.Right(sqlreader.Item("id_telat"), 2)) + 1, 2)
                Else
                    Return nik & "-" & VB.Right(Year(DT_tanggal.Text), 2) & VB.Right("00" & Month(DT_tanggal.Text), 2) & _
                    "-" & "01"
                End If
            Else
                Return nik & "-" & VB.Right(Year(DT_tanggal.Text), 2) & VB.Right("00" & Month(DT_tanggal.Text), 2) & _
                    "-" & "01"
            End If
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan id telat " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return Nothing
        Finally
            Conn.Close()
        End Try
    End Function

    Private Function simpan_data() As Boolean 'simpan data tbl_telat
        id_telat = cek_idtelat(Text_nik.Text)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "insert into tbl_telat(nik, hari, tanggal, telat, alasan, id_telat) " & _
                "values(@nik, @hari, @tanggal, @telat, @alasan, @id_telat)"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                .Add("@hari", SqlDbType.VarChar).Value = Text_hari.Text
                .Add("@tanggal", SqlDbType.Date).Value = DT_tanggal.Text
                .Add("@telat", SqlDbType.Int).Value = Text_telat.Text
                .Add("@alasan", SqlDbType.VarChar).Value = Text_alasan.Text
                .Add("@id_telat", SqlDbType.VarChar).Value = id_telat
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Data tidak dapat disimpan " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function simpan_rekapkerja() As Boolean 'simpan tbl_rekapkerja
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            periode = Microsoft.VisualBasic.Right("00" & Month(DT_tanggal.Value) & Year(DT_tanggal.Value), 4)
            sql = "insert into tbl_rekapkerja(nik, status, lama, tanggal, periode, catatan) " & _
                "values(@nik, @status, @lama, @tanggal, @periode, @catatan)"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                .Add("@status", SqlDbType.VarChar).Value = "telat"
                .Add("@lama", SqlDbType.Int).Value = DBNull.Value
                If DT_tanggal.Text = " " Then
                    .Add("@tanggal", SqlDbType.Date).Value = DT_tanggal.Text
                Else
                    .Add("@tanggal", SqlDbType.Date).Value = DT_tanggal.Text
                End If
                .Add("@periode", SqlDbType.Char).Value = periode
                .Add("@catatan", SqlDbType.VarChar).Value = DBNull.Value
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("gagal dalam penyimpanan rekap kerja " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function edit_data() As Boolean 'update table tbl_telat
        id_telat = Text_nik.Text & Text_nik.Text & DT_tanggal.Value.AddDays(0).ToString("yyyy-M-d") & "TL"
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "update tbl_telat telat = @telat, alasan=@alasan " & _
                "where nik = @nik, tanggal = @tanggal"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                .Add("@tanggal", SqlDbType.Date).Value = DT_tanggal.Text
                .Add("@telat", SqlDbType.Int).Value = Text_telat.Text
                .Add("@alasan", SqlDbType.VarChar).Value = Text_alasan.Text
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal update data " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Sub loading_gridkaryawan(ByVal Opt As String, ByVal departemen As String)
        Try
            clear_command()
            openDB()
            With Grid_karyawan
                Select Case Opt
                    Case String.Empty
                        sql = "SELECT dbo.view_pegawai.nik, dbo.view_pegawai.nama, dbo.view_pegawai.departemen, dbo.view_pegawai.jabatan, " & _
                        "dbo.view_pegawai.status_karyawan, " & _
                        "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' THEN 1 ELSE NULL END) AS total_telat " & _
                        "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                        "dbo.view_pegawai ON dbo.tbl_rekapkerja.nik = dbo.view_pegawai.nik " & _
                        "GROUP BY dbo.view_pegawai.nik, dbo.view_pegawai.nama, dbo.view_pegawai.departemen, dbo.view_pegawai.jabatan, " & _
                        "dbo.view_pegawai.status_karyawan"

                    Case "departemen"
                        sql = "SELECT dbo.view_pegawai.nik, dbo.view_pegawai.nama, dbo.view_pegawai.departemen, dbo.view_pegawai.jabatan, " & _
                        "dbo.view_pegawai.status_karyawan, " & _
                        "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' THEN 1 ELSE NULL END) AS total_telat " & _
                        "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                        "dbo.view_pegawai ON dbo.tbl_rekapkerja.nik = dbo.view_pegawai.nik " & _
                        "where dbo.view_pegawai.departemen = '" & departemen & "' " & _
                        "GROUP BY dbo.view_pegawai.nik, dbo.view_pegawai.nama, dbo.view_pegawai.departemen, dbo.view_pegawai.jabatan, " & _
                        "dbo.view_pegawai.status_karyawan"
                    Case "pencarian"
                        sql = "SELECT dbo.view_pegawai.nik, dbo.view_pegawai.nama, dbo.view_pegawai.departemen, dbo.view_pegawai.jabatan, " & _
                       "dbo.view_pegawai.status_karyawan, " & _
                       "COUNT(CASE WHEN dbo.tbl_rekapkerja.status = 'telat' THEN 1 ELSE NULL END) AS total_telat " & _
                       "FROM dbo.tbl_rekapkerja RIGHT OUTER JOIN " & _
                       "dbo.view_pegawai ON dbo.tbl_rekapkerja.nik = dbo.view_pegawai.nik " & _
                       "WHERE dbo.view_pegawai.nik LIKE '%" & Text_pencarian.Text & "%' OR view_pegawai.nama  LIKE '%" & Text_pencarian.Text & "%' " & _
                       "GROUP BY dbo.view_pegawai.nik, dbo.view_pegawai.nama, dbo.view_pegawai.departemen, dbo.view_pegawai.jabatan, " & _
                       "dbo.view_pegawai.status_karyawan"
                End Select
                sqladapter = New SqlDataAdapter(sql, Conn)
                DataTab = New DataTable
                DataTab.Clear()
                sqladapter.Fill(DataTab)
                Grid_karyawan.DataSource = DataTab
                atur_grid()
                Grid_karyawan.Refresh()
            End With
        Catch Ex As Exception
            MsgBox("Gagal menampilkan data " & Ex.Message, MsgBoxStyle.Information, "INFO")
        End Try
    End Sub

    Private Sub atur_grid()
        With Grid_karyawan
            .ReadOnly = True
            .Enabled = True
            .RowHeadersWidth = 4
            .ColumnHeadersVisible = True
            .Columns(0).HeaderText = "NIK"
            .Columns(0).Width = 70
            .Columns(1).HeaderText = "Nama"
            .Columns(1).Width = 150
            .Columns(2).HeaderText = "Departemen"
            .Columns(2).Width = 150
            .Columns(3).HeaderText = "Jabatan"
            .Columns(3).Width = 170
            .Columns(4).HeaderText = "status"
            .Columns(4).Width = 50
            .Columns(5).HeaderText = "total telat"
            .Columns(5).Width = 50
        End With
    End Sub

    Private Sub FormTelatMasukKerja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New CultureInfo("id-ID")
        disable_text(Me, Nothing)
        disable_combo(Me, Nothing)
    End Sub


    Private Sub Grid_karyawan_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid_karyawan.CellContentDoubleClick
        With Grid_karyawan
            rowindex = .CurrentRow.Index
            Text_nik.Text = .Rows(rowindex).Cells(0).Value
            Text_nama.Text = .Rows(rowindex).Cells(1).Value
            Text_jabatan.Text = .Rows(rowindex).Cells(2).Value
            Text_dept.Text = .Rows(rowindex).Cells(3).Value
        End With
    End Sub

    Private Sub hapus()
        Clear_text(Me, Nothing)
        clear_date(Me, Nothing)
    End Sub

    Private Sub DT_tanggal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_tanggal.ValueChanged
        format_tanggal(DT_tanggal)
        Text_hari.Text = DT_tanggal.Value.AddDays(0).ToString("dddd")
    End Sub

    Private Sub Grid_karyawan_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid_karyawan.CellContentClick

    End Sub

    Private Sub Combo_depart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_depart.SelectedIndexChanged
        loading_gridkaryawan("departemen", Combo_depart.Text)
    End Sub

    Private Sub Text_pencarian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_pencarian.TextChanged
        loading_gridkaryawan("pencarian", Nothing)
    End Sub

    Private Sub Button_baru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_baru.Click
        enable_text(Me, Nothing)
        enable_combo(Me, Nothing)
        clear_date(Me, Nothing)
        loading_gridkaryawan(Nothing, Nothing)
        load_combo(Combo_depart, "departemen", "tbl_jabatan")
    End Sub

    Private Sub Buttonkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonkeluar.Click
        Me.Close()
    End Sub
End Class