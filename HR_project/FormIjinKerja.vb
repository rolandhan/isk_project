Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports VB = Microsoft.VisualBasic.Strings
Imports System.Globalization

Public Class FormIjinKerja
    Dim id_ijin$, status$, statusijin%, periode$, status_simpan%
    Dim imp_satujam% = 0, imp_sethari% = 0
    Dim rowindex As Integer


    Private Sub Button_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_simpan.Click
        periode = Microsoft.VisualBasic.Right("00" & Month(DT_tanggal.Value) & Year(DT_tanggal.Value), 4)
        If Text_nik.Text = String.Empty Then
            MsgBox("NIK tidak boleh kosong !", MsgBoxStyle.Exclamation, "INFO")
        ElseIf DT_tanggal.Text = String.Empty Then
            MsgBox("Tanggal tidakboleh kosong ", MsgBoxStyle.Exclamation, "INFO")
        ElseIf checking_data("nik", "tbl_ijin", Text_nik.Text, " and tanggal = '" & Format(CDate(DT_tanggal.Text), "yyyy/M/d") & "'") = True Then
            MsgBox("Data sudah ada, dengan tanggal yang sama, " & vbCrLf & _
                   "edit data gunakan form edit data", MsgBoxStyle.Information & MsgBoxStyle.OkCancel, "INFO")
        Else
            If MsgBox("Apakah data siap untuk disimpan ? ", MsgBoxStyle.Information & MsgBoxStyle.OkCancel, "INFO") = vbOK Then
                If simpan_data() = True And simpan_rekapkerja() = True Then
                    MsgBox("Data telah berhasil disimpan", MsgBoxStyle.Information, "INFO")
                    loading_gridkaryawan(Nothing)
                    format_tanggal_kosong(DT_tanggal)
                Else
                    MsgBox("Gagal dalam penyimpanan data", MsgBoxStyle.Information, "INFO")
                End If
                hapus()
            Else
                Text_nik.Focus()
            End If
        End If
    End Sub

    Public Sub load_dataijinkerja(ByVal nik As String, ByVal id As String) 'loading data dari tabel tbl_ijin
        Try
            enable_text(Me, Nothing)
            enable_combo(Me, Nothing)
            DT_tanggaldari.Enabled = True
            DT_tanggalke.Enabled = True
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "SELECT ROW_NUMBER() OVER(ORDER BY tbl_ijin.nik ASC) AS No, tbl_ijin.nik, departemen, jabatan, " & _
                        "id_ijin, tanggal, hari, jam, jam_kembali,  status, alasan " & _
                        "FROM tbl_ijin LEFT OUTER JOIN view_dtpegawai ON " & _
                        "tbl_ijin.nik = view_dtpegawai.nik WHERE tbl_ijin.nik = '" & nik & "' " & _
                        "AND tbl_ijin.id_ijin = '" & id & "'"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                Text_nik.Text = nik
                Text_nama.Text = sqlreader.Item("nama")
                Text_dept.Text = sqlreader.Item("departemen")
                Text_jabatan.Text = sqlreader.Item("jabatan")
                Text_hari.Text = sqlreader.Item("hari")
                Select Case sqlreader.Item("status")
                    Case "1 jam"
                        Radio_kembali.Checked = True
                    Case "setengah hari"
                        Radio_tidak.Checked = True
                End Select
                If Not IsDBNull(sqlreader.Item("tanggal")) Then
                    DT_tanggal.Text = sqlreader.Item("tanggal")
                Else
                    format_tanggal_kosong(DT_tanggal)
                End If
                If Not IsDBNull(sqlreader.Item("jam")) Then
                    Masked_jam.Text = sqlreader.Item("jam")
                Else
                    Masked_jam.Text = String.Empty
                End If
                If Not IsDBNull(sqlreader.Item("kembali")) Then
                    Masked_kembali.Text = sqlreader.Item("jam_kembali")
                Else
                    Masked_kembali.Text = String.Empty
                End If
                Text_alasan.Text = sqlreader.Item("alasan")
            End If
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data " & ex.Message)
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Function simpan_data() As Boolean 'simpan data di table tbl_ijin
        If Radio_kembali.Checked = True Then
            status = "satu jam"
        ElseIf Radio_tidak.Checked = True Then
            status = "setengah hari"
        End If
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            id_ijin = Text_nik.Text & "-" & DT_tanggal.Value.AddDays(0).ToString("yyyy-M-d")
            sql = "insert into tbl_ijin(nik, hari, tanggal, jam, jam_kembali, status, alasan, id_ijin, periode) " & _
                "values(@nik, @hari, @tanggal, @jam, @jam_kembali, @status, @alasan, @id_ijin, @periode)"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                .Add("hari", SqlDbType.VarChar).Value = Text_hari.Text
                .Add("tanggal", SqlDbType.Date).Value = DT_tanggal.Text
                .Add("@jam", SqlDbType.Time).Value = Masked_jam.Text
                If Radio_tidak.Checked = True Then
                    .Add("@jam_kembali", SqlDbType.Time).Value = DBNull.Value
                Else
                    .Add("@jam_kembali", SqlDbType.Time).Value = Masked_kembali.Text
                End If
                .Add("@status", SqlDbType.VarChar).Value = status
                .Add("alasan", SqlDbType.VarChar).Value = Text_alasan.Text
                .Add("@id_ijin", SqlDbType.VarChar).Value = id_ijin
                .Add("@periode", SqlDbType.Char).Value = periode
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam penyimpanan data ijin kerja" & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function simpan_rekapkerja() As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            periode = VB.Right("00" & Month(DT_tanggal.Value) & Year(DT_tanggal.Value), 4)
            clear_command()
            openDB()

            sql = "insert into tbl_rekapkerja(nik, status, lama, tanggal, periode, catatan) " & _
                "values(@nik, @status, @lama, @tanggal, @periode, @catatan)"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("nik", SqlDbType.VarChar).Value = Text_nik.Text
                If Radio_kembali.Checked = True Then
                    .Add("@status", SqlDbType.VarChar).Value = "satu jam"
                ElseIf Radio_tidak.Checked = True Then
                    .Add("@status", SqlDbType.VarChar).Value = "setengah hari"
                End If
                .Add("@lama", SqlDbType.Int).Value = DBNull.Value
                .Add("@tanggal", SqlDbType.Date).Value = DT_tanggal.Text
                .Add("@periode", SqlDbType.Char).Value = periode
                .Add("@catatan", SqlDbType.VarChar).Value = DBNull.Value
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("gagal dalam penyimpanan rekap kerja " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Sub update_data()
        clear_command()
        openDB()

        Try
            sql = "update tbl_ijin set hari = @hari, jam = @jam, status = @status, alasan = @alasan " & _
                "where nik = @nik and tanggal = @tanggal"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                .Add("@hari", SqlDbType.Char).Value = Text_hari.Text
                .Add("@tanggal", SqlDbType.Date).Value = DT_tanggal.Text
                .Add("@jam", SqlDbType.Time).Value = Masked_jam.Text
                .Add("@status", SqlDbType.VarChar).Value = status
                .Add("@alasan", SqlDbType.VarChar).Value = Text_alasan.Text
            End With
            sqlcmd.ExecuteNonQuery()
            status_simpan = 1
        Catch ex As Exception
            MsgBox("Gagal dalam update data " & ex.Message, MsgBoxStyle.Information, "INFO")
            status_simpan = 0
        End Try
    End Sub

    Private Sub update_rekapkerja()
        Try
            periode = Microsoft.VisualBasic.Right("00" & Month(DT_tanggal.Value) & Year(DT_tanggal.Value), 4)
            clear_command()
            openDB()

            sql = "update tbl_rekapkerja set status = @status " & _
                "where nik = @nik and tanggal =  @tanggal"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("nik", SqlDbType.VarChar).Value = Text_nik.Text
                If Radio_kembali.Checked = True Then
                    .Add("@status", SqlDbType.VarChar).Value = "satu jam"
                ElseIf Radio_tidak.Checked = True Then
                    .Add("@status", SqlDbType.VarChar).Value = "setengah hari"
                End If
                .Add("@tanggal", SqlDbType.Date).Value = DT_tanggal.Text
            End With
            sqlcmd.ExecuteNonQuery()
            status_simpan = 1
        Catch ex As Exception
            status_simpan = 0
            MsgBox("gagal dalam update rekap kerja " & ex.Message, MsgBoxStyle.Information, "INFO")
        End Try
    End Sub

    Private Sub hapus()
        Clear_text(Me, Nothing)
        Grid_karyawan.Refresh()
        Radio_kembali.Checked = False
        Radio_tidak.Checked = False
        Masked_jam.Text = String.Empty
        Masked_kembali.Text = String.Empty
    End Sub


    Private Sub FormIjinKerja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New CultureInfo("id-ID")
        disable_combo(Me, Nothing)
        disable_text(Me, Nothing)
        DT_tanggaldari.Enabled = False
        DT_tanggalke.Enabled = False
        DT_tanggal.Enabled = False
    End Sub

    Private Sub DT_tanggal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_tanggal.ValueChanged
        format_tanggal(DT_tanggal)
        'Text_hari.Text = convert_daynames(DT_tanggal)
        Text_hari.Text = DT_tanggal.Value.AddDays(0).ToString("dddd")
    End Sub

    Private Sub loading_gridkaryawan(ByVal opt As String)
        Dim awal, akhir As Date
        If DT_tanggaldari.Text = " " Then
            awal = Now()
        ElseIf DT_tanggalke.Text = " " Then
            akhir = Now()
        Else
            awal = DT_tanggaldari.Text
            akhir = DT_tanggalke.Text
        End If
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            Select Case opt
                Case String.Empty
                    sql = "SELECT view_pegawai .nik, nama,departemen ,jabatan ,status_karyawan,imp_satujam, " & _
                        "imp_sethari, total_ijin ,periode FROM (SELECT nik, " & _
                        "COUNT(CASE WHEN status = 'satu jam' THEN 1 ELSE NULL END) AS imp_satujam, " & _
                        "COUNT(CASE WHEN status = 'setengah hari' THEN 1 ELSE NULL END) AS imp_sethari, " & _
                        "COUNT(CASE WHEN status = 'satu jam' THEN 1 ELSE NULL END) + " & _
                        "COUNT(CASE WHEN status = 'setengah hari' THEN 1 ELSE NULL END) AS total_ijin, periode,tanggal " & _
                        "FROM tbl_ijin WHERE tanggal BETWEEN @awal AND @akhir " & _
                        "GROUP BY nik, periode, tanggal) as temp RIGHT OUTER JOIN view_pegawai ON " & _
                        "temp.nik = view_pegawai .nik ORDER BY nik"
                Case "departemen"
                    sql = "SELECT view_pegawai .nik, nama,departemen ,jabatan ,status_karyawan,imp_satujam, " & _
                        "imp_sethari, total_ijin ,periode FROM (SELECT nik, " & _
                        "COUNT(CASE WHEN status = 'satu jam' THEN 1 ELSE NULL END) AS imp_satujam, " & _
                        "COUNT(CASE WHEN status = 'setengah hari' THEN 1 ELSE NULL END) AS imp_sethari, " & _
                        "COUNT(CASE WHEN status = 'satu jam' THEN 1 ELSE NULL END) + " & _
                        "COUNT(CASE WHEN status = 'setengah hari' THEN 1 ELSE NULL END) AS total_ijin, periode,tanggal " & _
                        "FROM tbl_ijin WHERE tanggal BETWEEN @awal AND @akhir " & _
                        "GROUP BY nik, periode, tanggal) as temp RIGHT OUTER JOIN view_pegawai ON " & _
                        "temp.nik = view_pegawai .nik WHERE view_pegawai.departemen = '" & Combo_depart.Text & "' ORDER BY nik"
                Case "pencarian"
                    sql = "SELECT view_pegawai .nik, nama,departemen ,jabatan ,status_karyawan,imp_satujam, " & _
                        "imp_sethari, total_ijin ,periode FROM (SELECT nik, " & _
                        "COUNT(CASE WHEN status = 'satu jam' THEN 1 ELSE NULL END) AS imp_satujam, " & _
                        "COUNT(CASE WHEN status = 'setengah hari' THEN 1 ELSE NULL END) AS imp_sethari, " & _
                        "COUNT(CASE WHEN status = 'satu jam' THEN 1 ELSE NULL END) + " & _
                        "COUNT(CASE WHEN status = 'setengah hari' THEN 1 ELSE NULL END) AS total_ijin, periode,tanggal " & _
                        "FROM tbl_ijin WHERE tanggal BETWEEN @awal AND @akhir " & _
                        "GROUP BY nik, periode, tanggal) as temp RIGHT OUTER JOIN view_pegawai ON " & _
                        "temp.nik = view_pegawai .nik WHERE view_pegawai.nik LIKE '%" & Text_pencarian.Text & "%' " & _
                        "OR view_pegawai.nama LIKE '%" & Text_pencarian.Text & "%' ORDER BY nik"
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@awal", SqlDbType.Date).Value = awal
                .Add("@akhir", SqlDbType.Date).Value = akhir
            End With
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            Grid_karyawan.DataSource = DTab
            atur_grid()
            Grid_karyawan.Refresh()
        Catch Ex As Exception
            MsgBox("Gagal dalam menampilkan data " & Ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub atur_grid()
        With Grid_karyawan
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
            .Columns(4).Width = 50
            .Columns(5).HeaderText = "imp_satujam"
            .Columns(5).Width = 50
            .Columns(6).HeaderText = "imp_sethari"
            .Columns(6).Width = 50
            .Columns(7).HeaderText = "total_ijin"
            .Columns(7).Width = 50
            .Columns(8).HeaderText = "periode"
            .Columns(8).Width = 50
            .RowHeadersWidth = 10
        End With
    End Sub

    Private Sub Grid_karyawan_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Grid_karyawan.CellContentDoubleClick
        With Grid_karyawan
            rowindex = .CurrentRow.Index
            Text_nik.Text = .Rows(rowindex).Cells(0).Value
            Text_nama.Text = .Rows(rowindex).Cells(1).Value
            Text_dept.Text = .Rows(rowindex).Cells(2).Value
            Text_jabatan.Text = .Rows(rowindex).Cells(3).Value
        End With
    End Sub

    Private Sub DT_tanggaldari_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_tanggaldari.ValueChanged
        format_tanggal(DT_tanggaldari)
    End Sub

    Private Sub DT_tanggalke_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_tanggalke.ValueChanged
        format_tanggal(DT_tanggalke)
    End Sub

    Private Sub Combo_depart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_depart.SelectedIndexChanged
        loading_gridkaryawan("departemen")
    End Sub

    Private Sub Text_pencarian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_pencarian.TextChanged
        loading_gridkaryawan("pencarian")
    End Sub

    Private Sub Button_baru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_baru.Click
        DT_tanggaldari.Enabled = True
        DT_tanggalke.Enabled = True
        DT_tanggal.Enabled = True
        id_global = String.Empty
        nik_global = String.Empty
        enable_combo(Me, Nothing)
        enable_text(Me, Nothing)
        clear_date(Me, group_periode)
        loading_gridkaryawan(Nothing)
        load_combo(Combo_depart, "departemen", "tbl_jabatan")
        hapus()
        DT_tanggaldari.Text = Now()
        DT_tanggalke.Text = Now()
    End Sub

    Private Sub Buttonkeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttonkeluar.Click
        Me.Close()
    End Sub


    Private Sub Radio_tidak_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_tidak.CheckedChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (Masked_jam.Text) = " :" Then
            MsgBox("data kosong")
        Else
            MsgBox("ada isi")
        End If
    End Sub
End Class