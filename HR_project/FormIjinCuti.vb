Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports VB = Microsoft.VisualBasic.Strings
Imports System.Globalization

Public Class FormIjinCuti
    Dim status, id_cuti, periode As String
    Dim status_pencarian As Boolean
    Dim total_cuti, total_ijin, total_sakit, total_kd, total_alfa, sisa_cuti, total_ctks, info, rowindex As Integer
    Dim awal, akhir, tanggal As Date
    Dim jumlah As Integer

    Private Sub Button_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_simpan.Click
        If Text_nik.Text = String.Empty Then
            MsgBox("NIK tidak boleh kosong ", MsgBoxStyle.Information, "INFO")
        ElseIf Text_hari.Text = String.Empty Then
            MsgBox("Hari tidak boleh kosong ", MsgBoxStyle.Information, "INFO")
        ElseIf checking_data("NIK", "tbl_cuti", Text_nik.Text, "and MULAI_CUTI = '" & Format(CDate(DT_mulai.Text), "yyyy/M/d") & "'") = True Then
            If MsgBox("Tanggal mulai cuti sama dengan data yang sudah ada, untuk melakukan edit data silahkan via form edit", _
                      MsgBoxStyle.Information & MsgBoxStyle.OkCancel, "INFO") = vbOK Then
                'udpate data
                'If edit_data() = True And edit_rekapkerja() = True Then
                'MsgBox("Data telah berhasil di update ", MsgBoxStyle.Information, "INFO")
                ' hapus()
                'Else
                'MsgBox("Gagal proses update data ", MsgBoxStyle.Information, "INFO")
                ' End If
        Else
            Text_nik.Focus()
        End If
            Else
                If MsgBox("Apakah data siap untuk di simpan ? ", MsgBoxStyle.Information & vbOKCancel, "INFO") = vbOK Then
                If SimpanData() = True And SimpanRekapKerja() = True Then
                    MsgBox("Data telah berhasil di simpan ", MsgBoxStyle.Information, "INFO")
                    hapus()
                Else
                    MsgBox("Gagal proses simpan data ", MsgBoxStyle.Information, "INFO")
                End If
                Else
                    Text_nik.Focus()
                End If
            End If
    End Sub

    'simpan data ke dalam tbl_cuti
    Private Function SimpanData() As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            status = StatusCuti()
            periode = VB.Right("0" & Month(DT_tanggal.Value) & VB.Right(Year(DT_tanggal.Value), 2), 4)
            id_cuti = Text_nik.Text & DT_tanggal.Value.AddDays(0).ToString("yyyy-M-d")
            clear_command()
            openDB()
            sql = "insert into tbl_cuti(NIK, HARI, TANGGAL, LAMA_CUTI, MULAI_CUTI, TANGGAL_MASUK, " & _
                "ID_CUTI, STATUS, periode, ket) values(@NIK, @HARI, @TANGGAL, @LAMA_CUTI, @MULAI_CUTI, " & _
                "@TANGGAL_MASUK, @ID_CUTI, @STATUS, @periode, @ket)"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@NIK", SqlDbType.VarChar).Value = Text_nik.Text
                .Add("@HARI", SqlDbType.VarChar).Value = Text_hari.Text
                .Add("@TANGGAL", SqlDbType.Date).Value = DT_tanggal.Text
                .Add("@LAMA_CUTI", SqlDbType.Int).Value = Text_lama.Text
                .Add("@MULAI_CUTI", SqlDbType.Date).Value = DT_mulai.Text
                .Add("@TANGGAL_MASUK", SqlDbType.Date).Value = DT_masuk.Text
                .Add("@ID_CUTI", SqlDbType.VarChar).Value = id_cuti
                .Add("@STATUS", SqlDbType.VarChar).Value = status
                .Add("PERIODE", SqlDbType.Char).Value = periode
                .Add("@ket", SqlDbType.VarChar).Value = Text_ket.Text
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Data gagal disimpan cuti" & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    'simpan data ke dalam tbl_rekapkerja
    Private Function SimpanRekapKerja() As Boolean
        Try
            Dim A As Integer = 1
            Cursor.Current = Cursors.WaitCursor
            periode = VB.Right("00" & Month(DT_tanggal.Value) & Year(DT_tanggal.Value), 4)
            clear_command()
            openDB()
            StatusCuti()
            jumlah = CInt(Text_lama.Text)
            tanggal = CDate(DT_mulai.Text)
            'Penyimpanan dengan perulangan untuk data 
            Do While A < jumlah + 1
                If Text_dept.Text = "Satpam" Then
                    sql = "insert into tbl_rekapkerja(nik, status, lama, tanggal, periode,catatan) " & _
                        "values(@nik, @status, @lama, @tanggal, @periode, @catatan)"
                    sqlcmd = New SqlCommand(sql, Conn)
                    With sqlcmd.Parameters
                        .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                        .Add("@status", SqlDbType.VarChar).Value = status
                        .Add("@lama", SqlDbType.Int).Value = 1
                        If DT_mulai.Text = " " Then
                            .Add("@tanggal", SqlDbType.Date).Value = DBNull.Value
                        Else
                            .Add("@tanggal", SqlDbType.Date).Value = tanggal
                        End If
                        .Add("@periode", SqlDbType.Char).Value = periode
                        .Add("@catatan", SqlDbType.VarChar).Value = DBNull.Value
                    End With
                    sqlcmd.ExecuteNonQuery()
                    tanggal = DateAdd(DateInterval.Day, 1, tanggal)
                Else
                    If tanggal.AddDays(0).ToString("dddd") = "Sunday" Then
                        jumlah += 1
                        tanggal = DateAdd(DateInterval.Day, 1, tanggal)
                    Else
                        sql = "insert into tbl_rekapkerja(nik, status, lama, tanggal, periode,catatan) " & _
                            "values(@nik, @status, @lama, @tanggal, @periode, @catatan)"
                        sqlcmd = New SqlCommand(sql, Conn)
                        With sqlcmd.Parameters
                            .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                            .Add("@status", SqlDbType.VarChar).Value = status
                            .Add("@lama", SqlDbType.Int).Value = 1
                            If DT_mulai.Text = " " Then
                                .Add("@tanggal", SqlDbType.Date).Value = DBNull.Value
                            Else
                                .Add("@tanggal", SqlDbType.Date).Value = tanggal
                            End If
                            .Add("@periode", SqlDbType.Char).Value = periode
                            .Add("@catatan", SqlDbType.VarChar).Value = DBNull.Value
                        End With
                        sqlcmd.ExecuteNonQuery()
                        tanggal = DateAdd(DateInterval.Day, 1, tanggal)
                    End If
                End If

                A += 1
            Loop
            Return True
        Catch Ex As Exception
            MsgBox("gagal penyimpanan rekap data " & Ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try

    End Function

    'update data di table tbl_cuti
    Private Function UpdateData() As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            status = StatusCuti()
            periode = VB.Right("00" & Month(DT_tanggal.Value) & Year(DT_tanggal.Value), 4)
            clear_command()
            openDB()
            sql = "update tbl_cuti SET HARI = @HARI, TANGGAL = @TANGGAL, LAMA_CUTI = @LAMA_CUTI , " & _
                "TANGGAL_MASUK = @TANGGAL_MASUK  , STATUS = @STATUS, " & _
                "PERIODE = @PERIODE, ket = @ket where NIK = '" & Text_nik.Text & "' " & _
                "AND MULAI_CUTI = @MULAI_CUTI"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@NIK", SqlDbType.VarChar).Value = Text_nik.Text
                .Add("@HARI", SqlDbType.VarChar).Value = Text_hari.Text
                .Add("@TANGGAL", SqlDbType.Date).Value = DT_tanggal.Text
                .Add("@LAMA_CUTI", SqlDbType.Int).Value = Text_lama.Text
                .Add("@MULAI_CUTI", SqlDbType.Date).Value = DT_mulai.Text
                .Add("@TANGGAL_MASUK", SqlDbType.Date).Value = DT_masuk.Text
                .Add("@STATUS", SqlDbType.VarChar).Value = status
                .Add("PERIODE", SqlDbType.Char).Value = periode
                .Add("@ket", SqlDbType.VarChar).Value = Text_ket.Text
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("Data gagal di update " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Function UpdateRekapKerja() As Boolean
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            StatusCuti()
            sql = "update tbl_rekapkerja set status = @status, lama = @lama where nik = @nik and tanggal = @tanggal"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = Text_nik.Text
                .Add("@status", SqlDbType.VarChar).Value = status
                .Add("@lama", SqlDbType.Int).Value = Text_lama.Text
                .Add("@tanggal", SqlDbType.Date).Value = DT_mulai.Text
            End With
            sqlcmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            MsgBox("gagal update rekap kerja " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Function

    'Cek status cuti
    Private Function StatusCuti() As String
        If Radio_cuti.Checked = True Then
            Return "cuti"
        ElseIf Radio_ijin.Checked = True Then
            Return "ijin"
        ElseIf Radio_sakit.Checked = True Then
            Return "sakit"
        ElseIf Radio_kd.Checked = True Then
            Return "kd"
        ElseIf Radio_alfa.Checked = True Then
            Return "alfa"
        ElseIf Radio_ctkusus.Checked = True Then
            Return "cuti kusus"
        Else
            Return False
        End If
    End Function

    Private Sub load_griddata(ByVal opt As String)
        If DT_awal.Text = " " Then
            awal = Now()
        ElseIf DT_akhir.Text = " " Then
            akhir = Now()
        Else
            awal = DT_awal.Text
            akhir = DT_akhir.Text
        End If
        Try
            Cursor.Current = Cursors.WaitCursor
            clear_command()
            openDB()
            Select Case opt
                Case String.Empty
                    sql = "SELECT DISTINCT temp2.nik , temp2.nama, temp2.departemen , @awal as tanggal, " & _
                    "temp2.timein , temp2.timeout, keterangan = (SELECT cuti.STATUS  FROM [tbl_cuti] as cuti " & _
                    "WHERE cuti.NIK = temp2.nik AND ((cuti.LAMA_CUTI > 0 AND @awal = cuti.MULAI_CUTI ) OR " & _
                    "(@awal > cuti.MULAI_CUTI AND @awal < DATEADD(DAY, cuti.lama_cuti,cuti.mulai_cuti)))) " & _
                    "FROM (SELECT view_pegawai.nik, view_pegawai.nama, view_pegawai.departemen, " & _
                    "temp.tanggal, temp.timein, temp.timeout FROM (SELECT tbl_dataabsen. nik, tbl_dataabsen.tanggal, " & _
                    "tbl_dataabsen.timein , tbl_dataabsen .timeout FROM tbl_dataabsen " & _
                    "WHERE tbl_dataabsen.tanggal BETWEEN @awal AND @akhir) AS temp RIGHT OUTER JOIN view_pegawai ON " & _
                    "temp.nik = view_pegawai.nik ) AS temp2 "
                Case "departemen"
                    sql = "SELECT DISTINCT temp2.nik , temp2.nama, temp2.departemen , @awal as tanggal, " & _
                    "temp2.timein , temp2.timeout, keterangan = (SELECT cuti.STATUS  FROM [tbl_cuti] as cuti " & _
                    "WHERE cuti.NIK = temp2.nik AND ((cuti.LAMA_CUTI > 0 AND @awal = cuti.MULAI_CUTI ) OR " & _
                    "(@awal > cuti.MULAI_CUTI AND @awal < DATEADD(DAY, cuti.lama_cuti,cuti.mulai_cuti)))) " & _
                    "FROM (SELECT view_pegawai.nik, view_pegawai.nama, view_pegawai.departemen, " & _
                    "temp.tanggal, temp.timein, temp.timeout FROM (SELECT tbl_dataabsen. nik, tbl_dataabsen.tanggal, " & _
                    "tbl_dataabsen.timein , tbl_dataabsen .timeout FROM tbl_dataabsen " & _
                    "WHERE tbl_dataabsen.tanggal BETWEEN @awal AND @akhir) AS temp RIGHT OUTER JOIN view_pegawai ON " & _
                    "temp.nik = view_pegawai.nik ) AS temp2 WHERE temp2.departemen = @departemen"
                Case "pencarian"
                    sql = "SELECT DISTINCT temp2.nik , temp2.nama, temp2.departemen , @awal as tanggal, " & _
                    "temp2.timein , temp2.timeout, keterangan = (SELECT cuti.STATUS  FROM [tbl_cuti] as cuti " & _
                    "WHERE cuti.NIK = temp2.nik AND ((cuti.LAMA_CUTI > 0 AND @awal = cuti.MULAI_CUTI ) OR " & _
                    "(@awal > cuti.MULAI_CUTI AND @awal < DATEADD(DAY, cuti.lama_cuti,cuti.mulai_cuti)))) " & _
                    "FROM (SELECT view_pegawai.nik, view_pegawai.nama, view_pegawai.departemen, " & _
                    "temp.tanggal, temp.timein, temp.timeout FROM (SELECT tbl_dataabsen. nik, tbl_dataabsen.tanggal, " & _
                    "tbl_dataabsen.timein , tbl_dataabsen .timeout FROM tbl_dataabsen " & _
                    "WHERE tbl_dataabsen.tanggal BETWEEN @awal AND @akhir) AS temp RIGHT OUTER JOIN view_pegawai ON " & _
                    "temp.nik = view_pegawai.nik ) AS temp2 WHERE temp2.nik LIKE '%" & Text_pencarian.Text & "%' OR " & _
                    "temp2.nama LIKE '%" & Text_pencarian.Text & "%'"
            End Select
            sqlcmd = New SqlCommand(sql, Conn)
            sqlcmd.Parameters.Add("@awal", SqlDbType.Date).Value = awal
            sqlcmd.Parameters.Add("@akhir", SqlDbType.Date).Value = akhir
            If opt = "departemen" Then
                sqlcmd.Parameters.Add("@departemen", SqlDbType.VarChar).Value = combo_dept.Text
            End If
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DataTab = New DataTable
            DataTab.Clear()
            sqladapter.Fill(DataTab)
            grid_tampildata.DataSource = DataTab
            atur_grid(grid_tampildata)
            grid_tampildata.Refresh()
        Catch ex As Exception
            MsgBox("gagal dalam menampilkan data ", MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub atur_grid(ByVal grid As DataGridView)
        With grid
            .ReadOnly = True
            .Enabled = True
            .RowHeadersWidth = 8
            .ColumnHeadersVisible = True
            .Columns(0).HeaderText = "NIK"
            .Columns(0).Width = 55
            .Columns(1).HeaderText = "Nama"
            .Columns(1).Width = 150
            .Columns(2).HeaderText = "Departemen"
            .Columns(2).Width = 150
            .Columns(3).HeaderText = "tanggal"
            .Columns(3).Width = 80
            .Columns(4).HeaderText = "timein"
            .Columns(4).Width = 80
            .Columns(5).HeaderText = "timeout"
            .Columns(5).Width = 80
            .Columns(6).HeaderText = "keterangan"
            .Columns(6).Width = 70
        End With
    End Sub

    Private Sub hapus()
        Clear_text(Me, Groupcuti)
        Radio_cuti.Checked = False
        Radio_alfa.Checked = False
        Radio_ijin.Checked = False
        Radio_ctkusus.Checked = False
        Radio_kd.Checked = False
        Radio_sakit.Checked = False
        clear_date(Me, Groupcuti)
        Clear_combo(Me, Nothing)

    End Sub

    Private Sub DT_tanggal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_tanggal.ValueChanged
        Text_hari.Text = DT_tanggal.Value.AddDays(0).ToString("dddd")
        format_tanggal(DT_tanggal)
    End Sub

    Private Sub DT_mulai_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_mulai.ValueChanged
        Text_mulai.Text = DT_mulai.Value.AddDays(0).ToString("dddd")
        format_tanggal(DT_mulai)
    End Sub

    Private Sub DT_masuk_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_masuk.ValueChanged
        'convert_daynames(DT_masuk)
        Text_masuk.Text = DT_masuk.Value.AddDays(0).ToString("dddd")
        format_tanggal(DT_masuk)
        Text_lama.Text = hitung_hari()
    End Sub

    Private Sub Radio_cuti_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio_cuti.CheckedChanged

    End Sub

    Private Sub FormIjinCuti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New CultureInfo("id-ID")
        disable_text(Me, Groupcuti)
        disable_text(Me, Nothing)
        disable_combo(Me, Nothing)
    End Sub

    Private Sub set_date()
        DT_awal.Text = Now()
        DT_akhir.Text = Now()
    End Sub

    Private Sub DT_awal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        format_tanggal(DT_awal)
    End Sub

    Private Sub DT_akhir_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        format_tanggal(DT_akhir)
    End Sub

    Private Sub Button_go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        load_griddata(String.Empty)
    End Sub

    Private Sub DT_awal_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_awal.ValueChanged
        format_tanggal(DT_awal)
    End Sub

    Private Sub DT_akhir_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DT_akhir.ValueChanged
        format_tanggal(DT_akhir)
    End Sub

    Private Sub combo_dept_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_dept.SelectedIndexChanged
        load_griddata("departemen")
    End Sub

    Private Sub Text_pencarian_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_pencarian.TextChanged
        load_griddata("pencarian")
    End Sub

    Private Sub Button_go_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_go.Click
        load_griddata(String.Empty)
    End Sub

    Private Sub grid_tampildata_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_tampildata.CellContentDoubleClick
        Try
            clear_command()
            openDB()
            With grid_tampildata
                sql = "SELECT nik, nama, departemen, jabatan FROM view_pegawai " & _
                    "WHERE nik = @nik"
                sqlcmd = New SqlCommand(sql, Conn)
                sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = .Rows(.CurrentRow.Index).Cells(0).Value
                sqlreader = sqlcmd.ExecuteReader
                If sqlreader.Read Then
                    Text_nik.Text = sqlreader.Item("nik")
                    Text_nama.Text = sqlreader.Item("nama")
                    Text_dept.Text = sqlreader.Item("departemen")
                    Text_jabatan.Text = sqlreader.Item("jabatan")
                End If
                sqlreader.Close()
            End With
        Catch ex As Exception
            MsgBox("gagal dalam menampilkan data " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button_baru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_baru.Click
        enable_text(Me, Groupcuti)
        enable_text(Me, Nothing)
        enable_combo(Me, Nothing)
        Call load_combo(combo_dept, "departemen", "tbl_statuskerja")
        Call clear_date(Me, Groupcuti)
        Call clear_date(Me, Nothing)
        load_griddata(Nothing)
        set_date()
    End Sub

    Private Sub Text_dept_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_dept.TextChanged

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Text_nik_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_nik.TextChanged

    End Sub

    Private Sub Text_nama_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_nama.TextChanged

    End Sub

    Private Sub Text_jabatan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Text_jabatan.TextChanged

    End Sub

    Private Function hitung_hari() As Integer
        Dim jumlah% = DateDiff(DateInterval.Day, DT_mulai.Value, DT_masuk.Value)
        Dim libur% = 0
        Dim tanggal As Date = DT_mulai.Text
        Dim A% = 1
        Do While A < jumlah + 1
            If tanggal.AddDays(0).ToString("dddd") = "Sunday" Then
                libur += 1
                tanggal = DateAdd(DateInterval.Day, 1, tanggal)
            Else
                tanggal = DateAdd(DateInterval.Day, 1, tanggal)
            End If
            A += 1
        Loop
        Return jumlah - libur
    End Function

End Class