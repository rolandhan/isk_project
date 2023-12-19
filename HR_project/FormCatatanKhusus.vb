Imports System.Data.Sql
Imports System.Data.SqlClient
Imports VB = Microsoft.VisualBasic.Strings
Imports System.Globalization

Public Class FormCatatanKhusus
    Private info As Integer, rowindex As Integer, number As Integer
    Private periode, id_catatan As String
    Private no_urut As String
    Private num As Integer

    Private Sub FormPelanggaran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clear_date(Me, Nothing)
        clear_date(Me, GroupBox3)
        format_tgl(Nothing)
        format_tgl(GroupBox1)
        combo_peringatan(combo_jenis)
        load_combo(Combo_depart, "departemen", "tbl_jabatan")
        load_gridkaryawan(Nothing)
        load_cmbcov(Combo_anti)
        load_cmbcov(Combo_pcr)
        load_cmbcov(Combo_rapid)
        Application.CurrentCulture = New CultureInfo("id-ID")
    End Sub

    Private Sub load_cmbcov(ByVal combo As ComboBox)
        combo.Items.Add("Positif")
        combo.Items.Add("Negatif")
    End Sub

    Private Function check_nourut(ByVal tabel As String) As String
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "select TOP(1) nik, no_urut from " & tabel & " where nik = @nik  ORDER BY no_urut DESC"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                num = CInt(VB.Right(sqlreader.Item("no_urut"), (sqlreader.Item("no_urut").Length - (Text_nik.TextLength + 1)))) + 1
                Return Text_nik.Text & "-" & num
            Else
                Return Text_nik.Text & "-" & 1
            End If
            Return True
        Catch ex As Exception
            MsgBox("gagal dalam pencarian no urut " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function check_id(ByVal nik As String) As String
        Try
            '100460-00-000'
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "SELECT TOP (1) id_catatan FROM tbl_catatan WHERE nik = @nik"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = nik
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                If VB.Right(sqlreader.Item("id_catatan"), 3) = "999" Then
                    'cek nomor tengah
                    Return VB.Left(sqlreader.Item("id_catatan"), 6) &
                        VB.Right("00" & CInt(VB.Mid(sqlreader.Item("id_catatan"), 8, 2)) + 1, 2) & "-001"
                Else
                    Return VB.Left(sqlreader.Item("id_catatan"), 10) &
                        VB.Right("000" & CInt(VB.Right(sqlreader.Item("id_catatan"), 3)) + 1, 3)
                End If
            Else
                Return nik & "-00-001"
            End If
        Catch ex As Exception
            MsgBox("Gagal dalam pengecekan id tabel catatan " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return Nothing
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function simpan_data() As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            periode = cek_periode()
            id_catatan = check_id(Text_nik.Text)
            clear_command()
            openDB()
            sql = "insert into tbl_catatan( nik, jenis_peringatan, catatan, tanggal, periode, id_catatan) " & _
                "values( @nik, @jenis_peringatan, @catatan, @tanggal, @periode, @id_catatan)"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                .Add("@jenis_peringatan", SqlDbType.VarChar).Value = combo_jenis.Text
                .Add("@catatan", SqlDbType.VarChar).Value = Text_catatan.Text
                If DT_tgl.Text = " " Or DT_tgl.Text = String.Empty Then
                    .Add("@tanggal", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tanggal", SqlDbType.Date).Value = DT_tgl.Text
                End If
                .Add("@periode", SqlDbType.Char).Value = periode
                .Add("@id_catatan", SqlDbType.VarChar).Value = id_catatan
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam penyimpanan data catatan " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function simpan_rekapkerja() As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            sql = "insert into tbl_rekapkerja(nik, status, lama, tanggal, periode, catatan) " & _
                "values(@nik, @status, @lama, @tanggal, @periode, @catatan)"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                If combo_jenis.Text = "Kecelakaan Kerja" Then
                    .Add("@status", SqlDbType.VarChar).Value = "kecelakaan kerja"
                Else
                    .Add("@status", SqlDbType.VarChar).Value = "catatan"
                End If
                .Add("@lama", SqlDbType.Int).Value = 1
                If DT_tgl.Text = " " Or DT_tgl.Text = String.Empty Then
                    .Add("@tanggal", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tanggal", SqlDbType.Date).Value = DT_tgl.Text
                End If
                .Add("@periode", SqlDbType.Char).Value = Year(DT_tgl.Text)
                .Add("@catatan", SqlDbType.VarChar).Value = Text_catatan.Text
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Gagal dalam penyimpanan data " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Cursor.Current = Cursors.Default
            Conn.Close()
        End Try
    End Function

    Private Function simpan_dtcovid() As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            no_urut = check_nourut("tbl_covid")
            clear_command()
            openDB()
            sql = "INSERT INTO tbl_covid( nik, tgl_mulai, tgl_selesai, rapid, antigen, pcr, no_urut, ket) " & _
                "VALUES(@nik, @tgl_mulai, @tgl_selesai, @rapid, @antigen, @pcr, @no_urut, @ket)"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                If DT_mulai.Text = " " Or DT_mulai.Text = String.Empty Then
                    .Add("@tgl_mulai", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tgl_mulai", SqlDbType.Date).Value = DT_mulai.Text
                End If
                If DT_selesai.Text = " " Or DT_selesai.Text = String.Empty Then
                    .Add("@tgl_selesai", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tgl_selesai", SqlDbType.Date).Value = DT_selesai.Text
                End If
                .Add("@rapid", SqlDbType.VarChar).Value = Combo_rapid.Text
                .Add("@antigen", SqlDbType.VarChar).Value = Combo_anti.Text
                .Add("@pcr", SqlDbType.VarChar).Value = Combo_pcr.Text
                .Add("@no_urut", SqlDbType.VarChar).Value = no_urut
                .Add("@ket", SqlDbType.VarChar).Value = Text_ketcov.Text
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
            'clear_datetabs(GroupBox1, TabControl1)
            'Clear_combo(Me, GroupBox3)
        Catch ex As Exception
            MsgBox("Gagal dalam penyimpanan data covid " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            MsgBox("Data telah sukses di simpan ", MsgBoxStyle.Information, "INFO")
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Sub update_dtcovid()
        Try
            clear_command()
            openDB()
            sql = "UPDATE tbl_covid SET tgl_mulai = @tgl_mulai, tgl_selesai = @tgl_selesai, " & _
                "rapid = @rapid, antigen = @antigen, pcr = @pcr, ket = @ket " & _
                "WHERE nik = @nik AND no_urut = @no_urut"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = ""
                If DT_mulai.Text = " " Or DT_mulai.Text = String.Empty Then
                    .Add("@tgl_mulai", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tgl_mulai", SqlDbType.Date).Value = DT_mulai.Text
                End If
                If DT_selesai.Text = " " Or DT_selesai.Text = String.Empty Then
                    .Add("@tgl_selesai", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tgl_selesai", SqlDbType.Date).Value = DT_selesai.Text
                End If
                .Add("@rapid", SqlDbType.VarChar).Value = Combo_rapid.Text
                .Add("@antigen", SqlDbType.VarChar).Value = Combo_anti.Text
                .Add("@pcr", SqlDbType.VarChar).Value = Combo_pcr.Text
                .Add("@no_urut", SqlDbType.VarChar).Value = no_urut
                .Add("@ket", SqlDbType.VarChar).Value = Text_ketcov.Text
            End With
            ' nik, tgl_mulai, tgl_selesai, rapid, antigen, pcr, no_urut
        Catch ex As Exception

        End Try
    End Sub

    Private Sub update_data()
        Try
            clear_command()
            openDB()
            sql = "update tbl_catatan set catatan = @catatan " & _
                "where nik = @nik AND tanggal = @tanggal AND jenis_peringatan = @jenis_peringatan"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                .Add("@jenis_peringatan", SqlDbType.VarChar).Value = ""
                .Add("@catatan", SqlDbType.VarChar).Value = Text_catatan.Text
                If DT_tgl.Text = " " Then
                    .Add("@tanggal", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tanggal", SqlDbType.Date).Value = DT_tgl.Text
                End If
            End With
            sqlcmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Gagal dalam update data " & ex.Message, MsgBoxStyle.Information, "INFO")
        End Try
    End Sub

    Private Sub update_rekapkerja()
        Try
            clear_command()
            openDB()
            sql = "update tbl_rekapkerja set catatan = @catatan " & _
                "Where nik = @nik and status = @status and tanggal = '" & Format(CDate(DT_tgl.Text), "yyyy/M/d") & "'"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                .Add("@status", SqlDbType.VarChar).Value = "catatan"
                If DT_tgl.Text = " " Then
                    .Add("@tanggal", SqlDbType.Date).Value = DBNull.Value
                Else
                    .Add("@tanggal", SqlDbType.Date).Value = DT_tgl.Text
                End If
                .Add("@catatan", SqlDbType.VarChar).Value = Text_catatan.Text
                sqlcmd.ExecuteNonQuery()
            End With
        Catch ex As Exception
            MsgBox("Gagal dalam penyimpanan data", MsgBoxStyle.Information, "INFO")
        End Try
    End Sub

    Private Function cek_periode() As String
        If CDate(DT_tgl.Text) > CDate("25-09-" & Year(DT_tgl.Value)) And CDate(DT_tgl.Text) < CDate("26-12-" & Year(DT_tgl.Value)) Then
            Return "1"
        ElseIf CDate(DT_tgl.Text) > CDate("25-12-" & (CInt(Year(DT_tgl.Value)))) And CDate(DT_tgl.Text) < CDate("26-03-" & Year(DT_tgl.Value) + 1) Then
            Return "2"
        ElseIf CDate(DT_tgl.Text) > CDate("25-03-" & Year(DT_tgl.Value)) And CDate(DT_tgl.Text) < CDate("26-06-" & Year(DT_tgl.Value)) Then
            Return "3"
        ElseIf CDate(DT_tgl.Text) > CDate("25-06-" & Year(DT_tgl.Value)) And CDate(DT_tgl.Text) < CDate("26-09-" & Year(DT_tgl.Value)) Then
            Return "4"
        End If
        Return Nothing
    End Function

    Private Sub hapus(ByVal group As GroupBox)
        Clear_text(Me, Nothing)
        clear_date(Me, Nothing)
        Clear_combo(Me, Nothing)
        Clear_text(Me, group)
        clear_date(Me, group)
        ClearTabControl(TabControl1)
    End Sub

    Private Sub ClearTabControl(ByVal tb As TabControl)
        For Each page As TabPage In TabControl1.TabPages
            ClearFields(page)
        Next
    End Sub

    Private Sub ClearFields(ByVal cntr As Control)
        For Each ctl As Control In cntr.Controls
            If TypeOf ctl Is TextBox OrElse TypeOf ctl Is ComboBox Then
                ctl.Text = ""
            ElseIf ctl.HasChildren Then
                ClearFields(ctl)
            End If
            If TypeOf ctl Is DateTimePicker Then
                CType(ctl, DateTimePicker).Format = DateTimePickerFormat.Custom
                CType(ctl, DateTimePicker).CustomFormat = " "
            ElseIf ctl.HasChildren Then
                ClearFields(ctl)
            End If
        Next
    End Sub


    Private Sub format_tgl(ByVal group As GroupBox)
        Dim tb As TabPage
        For Each tb In TabControl1.TabPages
            For Each dttimepicker As Control In tb.Controls
                If TypeOf dttimepicker Is DateTimePicker Then
                    CType(dttimepicker, DateTimePicker).Format = DateTimePickerFormat.Custom
                    CType(dttimepicker, DateTimePicker).CustomFormat = " "
                End If
            Next
            If Not group Is Nothing Then
                For Each dttimepicker As Control In group.Controls
                    If TypeOf dttimepicker Is DateTimePicker Then
                        CType(dttimepicker, DateTimePicker).Format = DateTimePickerFormat.Custom
                        CType(dttimepicker, DateTimePicker).CustomFormat = " "
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub load_gridkaryawan(ByVal opt As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            Select Case opt
                Case String.Empty
                    sql = "SELECT dbo.view_pegawai.nik, dbo.view_pegawai.nama, dbo.view_pegawai.departemen, " & _
                    "dbo.view_pegawai.jabatan, dbo.view_pegawai.status_karyawan, " & _
                    "COALESCE (COUNT(CASE WHEN jenis_peringatan = 'Peringatan IMP' THEN 1 ELSE NULL END), 0) AS imp, " & _
                    "COALESCE (COUNT(CASE WHEN jenis_peringatan = 'Surat Peringatan' THEN 1 ELSE NULL END), 0) AS sp " & _
                    "FROM dbo.tbl_catatan RIGHT OUTER JOIN " & _
                    "dbo.view_pegawai ON dbo.tbl_catatan.nik = dbo.view_pegawai.nik " & _
                    "GROUP BY dbo.view_pegawai.nik, dbo.view_pegawai.nama, dbo.view_pegawai.departemen, " & _
                    "dbo.view_pegawai.jabatan, dbo.view_pegawai.status_karyawan ORDER BY dbo.view_pegawai.nik"
                Case "departemen"
                    sql = "SELECT dbo.view_pegawai.nik, dbo.view_pegawai.nama, dbo.view_pegawai.departemen, " & _
                    "dbo.view_pegawai.jabatan, dbo.view_pegawai.status_karyawan, " & _
                    "COALESCE (COUNT(CASE WHEN jenis_peringatan = 'Peringatan IMP' THEN 1 ELSE NULL END), 0) AS imp, " & _
                    "COALESCE (COUNT(CASE WHEN jenis_peringatan = 'Surat Peringatan' THEN 1 ELSE NULL END), 0) AS sp " & _
                    "FROM dbo.tbl_catatan RIGHT OUTER JOIN " & _
                    "dbo.view_pegawai ON dbo.tbl_catatan.nik = dbo.view_pegawai.nik " & _
                    "WHERE dbo.view_pegawai.departemen = '" & Combo_depart.Text & "'" & _
                    "GROUP BY dbo.view_pegawai.nik, dbo.view_pegawai.nama, dbo.view_pegawai.departemen, " & _
                    "dbo.view_pegawai.jabatan, dbo.view_pegawai.status_karyawan ORDER BY dbo.view_pegawai.nik "
                Case "pencarian"
                    sql = "SELECT dbo.view_pegawai.nik, dbo.view_pegawai.nama, dbo.view_pegawai.departemen, " & _
                    "dbo.view_pegawai.jabatan, dbo.view_pegawai.status_karyawan, " & _
                    "COALESCE (COUNT(CASE WHEN jenis_peringatan = 'Peringatan IMP' THEN 1 ELSE NULL END), 0) AS imp, " & _
                    "COALESCE (COUNT(CASE WHEN jenis_peringatan = 'Surat Peringatan' THEN 1 ELSE NULL END), 0) AS sp " & _
                    "FROM dbo.tbl_catatan RIGHT OUTER JOIN " & _
                    "dbo.view_pegawai ON dbo.tbl_catatan.nik = dbo.view_pegawai.nik " & _
                    "WHERE dbo.view_pegawai.nama like '%" & Text_pencarian.Text & "%' " & _
                    "GROUP BY dbo.view_pegawai.nik, dbo.view_pegawai.nama, dbo.view_pegawai.departemen, " & _
                    "dbo.view_pegawai.jabatan, dbo.view_pegawai.status_karyawan ORDER BY dbo.view_pegawai.nik "
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DataTab = New DataTable
            DataTab.Clear()
            sqladapter.Fill(DataTab)
            Grid_karyawan.DataSource = DataTab
            atur_grid(Grid_karyawan)
            Grid_karyawan.Refresh()
        Catch ex As Exception
            MsgBox("Gagal menampilkan data " & ex.Message, MsgBoxStyle.Information, "INFO")
        End Try
    End Sub

    Private Sub atur_grid(ByVal grid As DataGridView)
        With grid
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
            .Columns(5).HeaderText = "IMP"
            .Columns(5).Width = 80
            .Columns(6).HeaderText = "SP"
            .Columns(6).Width = 80
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


    Private Sub Combo_depart_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_depart.SelectedIndexChanged
        load_gridkaryawan("departemen")
    End Sub

    Private Sub Button_simpan_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_simpan.Click
        If Text_nik.Text = String.Empty Then
            MsgBox("NIK tidak boleh kosong ", MsgBoxStyle.Exclamation, "INFO")
        ElseIf checking_data("nik", "tbl_catatan", Text_nik.Text, " and tanggal = '" & Format(CDate(DT_tgl.Text), "yyyy/M/d") & "' and jenis_peringatan = '" & combo_jenis.Text & "'") = True Then
            MsgBox("Data sudah ada, untuk update data gunakan form edit data ", MsgBoxStyle.Information, "INFO")
        Else
            If MsgBox("Apakah data sudah siap di simpan ? ", MsgBoxStyle.OkCancel, "INFO") = vbOK Then
                'simpan data
                If simpan_data() = True And simpan_rekapkerja() = True Then
                    MsgBox("Data telah berhasil di simpan", MsgBoxStyle.Information, "INFO")
                End If
                hapus(Nothing)
                hapus(GroupBox3)
            Else
                Text_nik.Focus()
            End If
        End If
    End Sub

    Private Sub B_simpanIM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_simpanIM.Click
        If DT_mulai.Text = "" Or DT_mulai.Text = String.Empty Then
            MsgBox("tanggal tidak boleh kosong ", MsgBoxStyle.Information, "INFO")
        Else
            If checking_data("no_urut", "tbl_covid", Text_nik.Text, " AND no_urut = '" & no_urut & "'") = True Then
                'update data di tbl_covid
                
            Else
                'simpan data di tbl_covid
                If MsgBox("Apakah Data siap disimpan ? ", MsgBoxStyle.OkCancel, "INFO") = vbOK Then
                    If simpan_dtcovid() = True Then
                        MsgBox("Data telah berhasil di simpan", MsgBoxStyle.Information, "INFO")
                        hapus(GroupBox1)
                        hapus(GroupBox2)
                        hapus(GroupBox3)
                        hapus(Nothing)
                    End If
                Else
                    Text_nik.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub DT_mulai_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_mulai.ValueChanged
        format_tanggal(DT_mulai)
    End Sub

    Private Sub DT_selesai_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_selesai.ValueChanged
        format_tanggal(DT_selesai)
    End Sub


    Private Sub Button_baru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_baru.Click
        clear_datetabs(GroupBox1, TabControl1)
        Clear_combo(Me, GroupBox3)
    End Sub

    Private Sub DT_tgl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_tgl.ValueChanged
        format_tanggal(DT_tgl)
    End Sub

    Private Sub Text_pencarian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_pencarian.TextChanged
        load_gridkaryawan("pencarian")
    End Sub
End Class