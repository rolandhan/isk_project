Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports System.Security.AccessControl
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Diagnostics

Module ModuleData
    Public sqlcmd As SqlCommand
    Public sqlreader As SqlDataReader
    Public sqladapter As SqlDataAdapter
    Public dtset As DataSet
    Public DataTab, DTtab_container, DTab, Dtab2 As DataTable
    Public txt_server, txt_db, cmb_auth, txt_id, txt_pwd As String
    Public CRReportDocument As ReportDocument
    Public sql, nama_hari As String
    Public nik_global, dept_global, id_global As String

    'cek untuk memberikan akses edit ke file di windows directory
    Public Function CheckPermissionFile(ByVal FilePath As String) As Boolean
        Try
            ' Get the existing access control permissions
            Dim fileSecurity As FileSecurity = File.GetAccessControl(FilePath)

            ' Add write and modify permissions for the current user
            Dim user As String = Environment.UserDomainName & "\" & Environment.UserName
            fileSecurity.AddAccessRule(New FileSystemAccessRule(user, FileSystemRights.Write Or FileSystemRights.Modify, AccessControlType.Allow))

            ' Apply the new access control settings
            File.SetAccessControl(FilePath, fileSecurity)
            Return True
        Catch Ex As Exception
            MsgBox("gagal akses permission file " & Ex.Message, MsgBoxStyle.Exclamation, "INFO")
            Return False
        End Try
    End Function
   

    Public Sub clear_command()
        sqlcmd = Nothing
        sqladapter = Nothing
        sql = String.Empty
        dtset = Nothing
    End Sub

    Public Sub combo_peringatan(ByVal combo As ComboBox)
        With combo
            .Items.Add("Catatan Khusus")
            .Items.Add("Peringatan IMP")
            .Items.Add("Surat Pernyataan")
            .Items.Add("Surat Peringatan")
            .Items.Add("Kecelakaan Kerja")
        End With
    End Sub

    Public Sub combojenis_k(ByVal combo As ComboBox)
        With combo
            .Items.Add("laki - laki")
            .Items.Add("perempuan")
        End With
    End Sub

    Public Sub comboagama(ByVal combo As ComboBox)
        With combo
            .Items.Add("Budha")
            .Items.Add("Hindu")
            .Items.Add("Islam")
            .Items.Add("Katolik")
            .Items.Add("Kristen")
        End With
    End Sub

    Public Sub Isi_combostatus_kary(ByVal combo As ComboBox)
        With combo
            .Items.Add("Harian Sementara")
            .Items.Add("Harian Tetap")
            .Items.Add("Percobaan")
            .Items.Add("Kontrak")
            .Items.Add("Tetap")
            .Items.Add("Keluar")
            .Items.Add("Keluar - Harian Sementara")
            .Items.Add("Tanpa Status")
        End With
    End Sub


    Public Sub combostatus_kawin(ByVal combo As ComboBox)
        With combo
            .Items.Add("belum kawin")
            .Items.Add("kawin")
        End With
    End Sub

    Public Function ConvertTanggal(ByVal tgl As Date) As String
        Select Case Month(tgl)
            Case 1
                Return tgl.Day & " Januari " & Year(tgl)
            Case 2
                Return tgl.Day & " Februari " & Year(tgl)
            Case 3
                Return tgl.Day & " Maret " & Year(tgl)
            Case 4
                Return tgl.Day & " April " & Year(tgl)
            Case 5
                Return tgl.Day & " Mei " & Year(tgl)
            Case 6
                Return tgl.Day & " Juni " & Year(tgl)
            Case 7
                Return tgl.Day & " Juli " & Year(tgl)
            Case 8
                Return tgl.Day & " Agustus " & Year(tgl)
            Case 9
                Return tgl.Day & " September " & Year(tgl)
            Case 10
                Return tgl.Day & " Oktober " & Year(tgl)
            Case 11
                Return tgl.Day & " November " & Year(tgl)
            Case 12
                Return tgl.Day & " Desember " & Year(tgl)
        End Select
        Return Nothing
    End Function 'rubah tanggal menjadi format indonesia

    Public Function ConvertBlnTahun(ByVal tgl As Date) As String
        Select Case Month(tgl)
            Case 1
                Return " Januari " & Year(tgl)
            Case 2
                Return " Februari " & Year(tgl)
            Case 3
                Return " Maret " & Year(tgl)
            Case 4
                Return " April " & Year(tgl)
            Case 5
                Return " Mei " & Year(tgl)
            Case 6
                Return " Juni " & Year(tgl)
            Case 7
                Return " Juli " & Year(tgl)
            Case 8
                Return " Agustus " & Year(tgl)
            Case 9
                Return " September " & Year(tgl)
            Case 10
                Return " Oktober " & Year(tgl)
            Case 11
                Return " November " & Year(tgl)
            Case 12
                Return " Desember " & Year(tgl)
        End Select
        Return Nothing
    End Function

    Public Function ConvertBln(ByVal tgl As Date) As String
        Select Case Month(tgl)
            Case 1
                Return " Januari "
            Case 2
                Return " Februari "
            Case 3
                Return " Maret "
            Case 4
                Return " April "
            Case 5
                Return " Mei "
            Case 6
                Return " Juni "
            Case 7
                Return " Juli "
            Case 8
                Return " Agustus "
            Case 9
                Return " September "
            Case 10
                Return " Oktober "
            Case 11
                Return " November "
            Case 12
                Return " Desember "
        End Select
        Return Nothing
    End Function

    Public Sub isi_combobulan(ByVal combo As ComboBox)
        With combo
            .MaxDropDownItems = 5
            .Items.Add("01")
            .Items.Add("02")
            .Items.Add("03")
            .Items.Add("04")
            .Items.Add("05")
            .Items.Add("06")
            .Items.Add("07")
            .Items.Add("08")
            .Items.Add("09")
            .Items.Add("10")
        End With
    End Sub

    Public Sub isi_combotahun(ByVal combo As ComboBox)
        For A% = Year(Now) To 2010 Step -1
            With combo
                .Items.Add(A)
                .IntegralHeight = False
                .MaxDropDownItems = 5
            End With
        Next A
    End Sub

    Public Function convert_daynames(ByVal dt_picker As DateTimePicker) As String
        Dim name$
        name = dt_picker.Value.AddDays(0).ToString("dddd")
        Select Case name
            Case "Monday"
                Return "Senin"
            Case "Tuesday"
                Return "Selasa"
            Case "Wednesday"
                Return "Rabu"
            Case "Thursday"
                Return "Kamis"
            Case "Friday"
                Return "Jum'at"
            Case "Saturday"
                Return "Sabtu"
            Case "Sunday"
                Return "Minggu"
        End Select
        Return Nothing
    End Function

    Public Sub format_tanggal(ByVal dt_picker As DateTimePicker)
        dt_picker.Format = DateTimePickerFormat.Custom
        dt_picker.CustomFormat = "dd-MM-yyyy"
    End Sub

    Public Sub format_tanggal_kosong(ByVal dt_picker As DateTimePicker)
        dt_picker.Format = DateTimePickerFormat.Custom
        dt_picker.CustomFormat = " "
    End Sub

    'fungsi untuk mengecek apakah nilai dari DateTimePicker kosong
    Public Function GetDateTimePickerValue(ByVal dateTimePicker As DateTimePicker) As Object
        If dateTimePicker.Text = " " Or dateTimePicker.Text = Nothing Then
            ' Jika DateTimePicker kosong, kembalikan DBNull.Value
            Return DBNull.Value
        Else
            ' Jika DateTimePicker memiliki nilai yang valid
            Return dateTimePicker.Text
        End If
    End Function

    Public Sub fill_combo(ByVal combo As ComboBox, ByVal field$, ByVal table$)
        combo.AutoCompleteMode = AutoCompleteMode.Suggest
        combo.AutoCompleteSource = AutoCompleteSource.CustomSource
        Dim combData As New AutoCompleteStringCollection()
        getData(combData, field, table)
        combo.AutoCompleteCustomSource = combData
    End Sub

    Public Sub load_combo(ByVal combo As ComboBox, ByVal _field$, ByVal _table$)

        clear_command()
        openDB()
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim Sql$ = "SELECT DISTINCT " & _field & " FROM " & _table
        Try
            command = New SqlCommand(Sql, Conn)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            For Each row As DataRow In ds.Tables(0).Rows
                combo.Items.Add(row(0).ToString())
            Next
        Catch Ex As Exception
            MsgBox("gagal tampil " & Ex.Message)
        Finally
            Conn.Close()
        End Try
    End Sub

    Public Sub load_viewpeg(ByVal grid As DataGridView)  'tampilkan view pegawai di datagrid
        Try
            clear_command()
            openDB()
            sql = "SELECT tbl_pegawai.nik, tbl_pegawai.nama,jab.departemen, jab.jabatan, " & _
                "jab.atasan, jab.status_karyawan FROM tbl_pegawai OUTER APPLY " & _
                "(SELECT TOP (1) tbl_jabatan.nik, tbl_jabatan.departemen, " & _
                "tbl_jabatan.jabatan, tbl_jabatan.atasan, tbl_jabatan.status_karyawan " & _
                "FROM tbl_jabatan WHERE tbl_jabatan.nik = tbl_pegawai.nik " & _
                "ORDER BY tbl_jabatan.no_urut DESC) AS jab ORDER BY nik"
            sqladapter = New SqlDataAdapter(sql, Conn)
            DTab = New DataTable
            DTab.Clear()
            sqladapter.Fill(DTab)
            grid.DataSource = DTab
            atur_gridview(grid)
            grid.Refresh()
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan view data", MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub atur_gridview(ByVal grid As DataGridView)
        With grid
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

    Private Sub getData(ByVal dataCollection As AutoCompleteStringCollection, ByVal field$, ByVal table$)
        openDB()
        Dim command As SqlCommand
        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()
        Dim Sql$ = "SELECT DISTINCT " & field & " FROM " & table
        Try
            command = New SqlCommand(Sql, Conn)
            adapter.SelectCommand = command
            adapter.Fill(ds)
            adapter.Dispose()
            command.Dispose()
            For Each row As DataRow In ds.Tables(0).Rows
                dataCollection.Add(row(0).ToString())
            Next
        Catch ex As Exception
            MessageBox.Show("Can not open connection ! ")
        End Try
    End Sub

    'cek data apakah sudah ada"
    Public Function checking_data(ByVal _field$, ByVal _table$, ByVal text$, ByVal add_condition$) As Boolean
        Try
            clear_command()
            openDB()
            sql = "select " & _field & " from " & _table & " where " & _field & " = '" & text & "' " & add_condition
            sqlcmd = New SqlCommand(sql, Conn)
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox(" gagal dalam pengecekan data " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
        End Try
    End Function

    'cek id digunakan untuk mengecek apakah sudah ada data id yang dicari
    Public Function check_id(ByVal _field$, ByVal _table$, ByVal _text$, ByVal add_condition$, ByVal _idfield$) As String
        Try
            clear_command()
            openDB()
            sql = "select TOP(1) " & _field & "," & _idfield & " FROM " & _table & " WHERE " & _field & " = '" & _text & "'  ORDER BY " & _idfield & " DESC"
            sqlcmd = New SqlCommand(sql, Conn)
            sqlreader = sqlcmd.ExecuteReader
            If sqlreader.Read Then
                Return sqlreader.Item(_idfield)
            Else
                Return Nothing
            End If
        Catch ex As Exception
            MsgBox("Gagal dalam pencarian id " & ex.Message, MsgBoxStyle.Information, "INFO")
            Return False
        Finally
            Conn.Close()
        End Try
    End Function


    Public Sub load_grid(ByVal grid As DataGridView, ByVal _field$, ByVal _table$, ByVal _text$)
        Try
            clear_command()
            openDB()
            sql = "select " & _field & " from " & _table
            sqladapter = New SqlDataAdapter(sql, Conn)
            dtset = New DataSet
            dtset.Clear()
            sqladapter.Fill(dtset, "tbl_pegawai")
            grid.DataSource = dtset.Tables("tbl_pegawai")
            atur_grid(grid)
            grid.Refresh()
        Catch ex As Exception
            MsgBox("gagal menampilkan data", MsgBoxStyle.Information, "INFO")
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
            .Columns(2).Width = 150
            .Columns(3).HeaderText = "Jabatan"
            .Columns(3).Width = 150
            .Columns(4).HeaderText = "status"
            .Columns(4).Width = 150
        End With
    End Sub

    Public Sub enable_menu()
        With FormMenuUtama
            .PengaturanToolStripMenuItem.Enabled = True
            .DataKaryawanToolStripMenuItem1.Enabled = True
            .PerijinanToolStripMenuItem.Enabled = True
            .AbsensiToolStripMenuItem1.Enabled = True
            .LaporanToolStripMenuItem1.Enabled = True
            .SamplePotonganToolStripMenuItem.Enabled = True
        End With
    End Sub

    Public Sub disable_menu()
        With FormMenuUtama
            .PengaturanToolStripMenuItem.Enabled = False
            .DataKaryawanToolStripMenuItem1.Enabled = False
            .PerijinanToolStripMenuItem.Enabled = False
            .AbsensiToolStripMenuItem1.Enabled = False
            .LaporanToolStripMenuItem1.Enabled = False
            .SamplePotonganToolStripMenuItem.Enabled = False
        End With
    End Sub

    Public Sub clear_date(ByVal form As System.Windows.Forms.Form, ByVal group As System.Windows.Forms.GroupBox)
        For Each dttimepicker As Control In form.Controls
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
    End Sub

    Public Sub clear_datetabs(ByVal group As GroupBox, ByVal tabs As TabControl)
        Dim tb As TabPage
        For Each tb In tabs.TabPages
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

    Public Sub Clear_text(ByVal form As System.Windows.Forms.Form, ByVal group As System.Windows.Forms.GroupBox)
        If Not form Is Nothing Then
            For Each Txt As Control In form.Controls
                If TypeOf Txt Is TextBox Then
                    CType(Txt, TextBox).Text = String.Empty
                End If
            Next
        End If
        If Not group Is Nothing Then
            For Each Txt As Control In group.Controls
                If TypeOf Txt Is TextBox Then
                    CType(Txt, TextBox).Text = String.Empty
                End If
            Next
        End If
    End Sub

    Public Sub disable_text(ByVal form As System.Windows.Forms.Form, ByVal group As System.Windows.Forms.GroupBox)
        For Each txt As Control In form.Controls
            If TypeOf txt Is TextBox Then
                CType(txt, TextBox).Enabled = False
            End If
        Next

        If Not group Is Nothing Then
            For Each txt As Control In group.Controls
                If TypeOf txt Is TextBox Then
                    CType(txt, TextBox).Enabled = False
                End If
            Next
        End If
    End Sub

    Public Sub enable_text(ByVal form As System.Windows.Forms.Form, ByVal group As System.Windows.Forms.GroupBox)
        For Each txt As Control In form.Controls
            If TypeOf txt Is TextBox Then
                CType(txt, TextBox).Enabled = True
            End If
        Next

        If Not group Is Nothing Then
            For Each txt As Control In group.Controls
                If TypeOf txt Is TextBox Then
                    CType(txt, TextBox).Enabled = True
                End If
            Next
        End If
    End Sub

    Public Sub Clear_combo(ByVal form As System.Windows.Forms.Form, ByVal group As System.Windows.Forms.GroupBox)
        For Each combo As Control In form.Controls
            If TypeOf combo Is ComboBox Then
                CType(combo, ComboBox).Text = String.Empty
            End If
        Next
        If Not group Is Nothing Then
            For Each combo As Control In group.Controls
                If TypeOf combo Is ComboBox Then
                    CType(combo, ComboBox).Text = String.Empty
                End If
            Next
        End If
    End Sub

    Public Sub disable_combo(ByVal form As System.Windows.Forms.Form, ByVal group As System.Windows.Forms.GroupBox)
        For Each combo As Control In form.Controls
            If TypeOf combo Is ComboBox Then
                CType(combo, ComboBox).Enabled = False
            End If
        Next
        If Not group Is Nothing Then
            For Each combo As Control In group.Controls
                If TypeOf combo Is ComboBox Then
                    CType(combo, ComboBox).Enabled = False
                End If
            Next
        End If
    End Sub

    Public Sub enable_combo(ByVal form As System.Windows.Forms.Form, ByVal group As System.Windows.Forms.GroupBox)
        For Each combo As Control In form.Controls
            If TypeOf combo Is ComboBox Then
                CType(combo, ComboBox).Enabled = True
            End If
        Next
        If Not group Is Nothing Then
            For Each combo As Control In group.Controls
                If TypeOf combo Is ComboBox Then
                    CType(combo, ComboBox).Enabled = True
                End If
            Next
        End If

    End Sub

    Public Function convert_namabulan(ByVal tanggal As Date) As String
        Select Case Month(tanggal)
            Case 1
                Return "JANUARI"
            Case 2
                Return "FEBRUARI"
            Case 3
                Return "MARET"
            Case 4
                Return "APRIL"
            Case 5
                Return "MEI"
            Case 6
                Return "JUNI"
            Case 7
                Return "JULI"
            Case 8
                Return "AGUSTUS"
            Case 9
                Return "SEPTEMBER"
            Case 10
                Return "OKTOBER"
            Case 11
                Return "NOVEMBER"
            Case 12
                Return "DESEMBER"
        End Select
        Return Nothing
    End Function

    Public Function convert_namahari(ByVal dt_picker As DateTimePicker) As String
        Select Case dt_picker.Value.AddDays(0).ToString("dddd")
            Case "Monday"
                Return "Senin"
            Case "Tuesday"
                Return "Selasa"
            Case "Wednesday"
                Return "Rabu"
            Case "Thursday"
                Return "Kamis"
            Case "Friday"
                Return "Jum'at"
            Case "Saturday"
                Return "Sabtu"
            Case "Sunday"
                Return "Minggu"
            Case "Senin"
                Return "Senin"
            Case "Selasa"
                Return "Selasa"
            Case "Rabu"
                Return "Rabu"
            Case "Kamis"
                Return "Kamis"
            Case "Jumat"
                Return "Jum'at"
            Case "Sabtu"
                Return "Sabtu"
            Case "Minggu"
                Return "Minggu"
        End Select
        Return Nothing
    End Function

End Module
