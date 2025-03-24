Imports System.IO
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Xml.Serialization
Imports System.Xml
Imports System.Security.Permissions
Imports System.Security.AccessControl

Public Class FormPengaturanLaporan
    Dim Ds As DataSet
    Dim Dt As DataTable
    Dim Dtrow As DataRow
    Dim FilePath As String = Application.StartupPath & "\config_report.txt"
    Dim FilePathConfig As String = Application.StartupPath & "\config_report.ini"
    Dim RowIndex As Integer

    Private Sub Combo_JnsLap_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_JnsLap.SelectedIndexChanged
        Select Case Combo_JnsLap.Text
            Case "Laporan Bulanan"
                GetDataConfig(Combo_JnsLap.Text, FilePathConfig)
            Case "Laporan Triwulan"
                GetDataConfig(Combo_JnsLap.Text, FilePathConfig)
            Case "Laporan Tahunan"
                GetDataConfig(Combo_JnsLap.Text, FilePathConfig)
            Case "Laporan Kecelakaan Kerja"
                ComboStaff.Text = String.Empty
                ComboStaff.Enabled = False
                GetDataConfig(Combo_JnsLap.Text, FilePathConfig)

        End Select
    End Sub

    Private Sub FormPengaturanLaporan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillComboLaporan(Combo_JnsLap)
        fill_combo(Combo_nama, "atasan", "tbl_jabatan")
        fill_combo(ComboStaff, "nama", "view_pegawai WHERE status_karyawan <>'keluar'")
        fill_combo(ComboManager, "nama", "view_pegawai WHERE status_karyawan <>'keluar'")
    End Sub

    Private Sub FillComboLaporan(ByVal cmb As ComboBox)
        With cmb.Items
            .Add("Laporan Bulanan")
            .Add("Laporan Triwulan")
            .Add("Laporan Tahunan")
            .Add("Laporan Kecelakaan Kerja")
        End With
    End Sub

    Private Sub Buttontambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttontambah.Click
        atur_grid(grid_nama)
        With grid_nama
            .Rows.Add(1)
            .Rows(.RowCount - 2).Cells(0).Value = Combo_nama.Text
            .Refresh()
        End With
        Combo_nama.Text = Nothing
    End Sub

    Private Sub Button_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If grid_nama.Rows.Count = 0 Then
            MsgBox("silahkan isikan data terlebih dahulu", MsgBoxStyle.Information, "")
        Else
            If MsgBox("Apakah data siap untuk disimpan?", vbOKCancel, "") = vbOK Then
                If AllowFilePermission(FilePath) = True Then
                    If AddToXMLFile(FilePath) = True Then
                        MsgBox("data telah berhasil tersimpan", MsgBoxStyle.Information, "")
                    End If
                End If
            End If
        End If
    End Sub

    'memberikan akses ke dalam direktori untuk dapat di edit
    Private Function AllowFilePermission(ByVal FilePath As String) As Boolean
        Dim FileTarget As New FileIOPermission(FileIOPermissionAccess.Read, FilePath)
        FileTarget.AddPathList(FileIOPermissionAccess.Write Or FileIOPermissionAccess.Read, FilePath)
        Try
            FileTarget.Demand()
            Return True
        Catch Ex As Exception
            Console.WriteLine(Ex.Message)
            Return False
        End Try
    End Function

    Private Sub atur_grid(ByVal grid As DataGridView)
        With grid
            .ReadOnly = True
            .Enabled = True
            .ColumnCount = 1
            .ColumnHeadersVisible = True
            .Columns(0).HeaderText = "Nama"
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).Width = 550
        End With
    End Sub

    'menambahkan data dari datagrid ke dalam dataSet
    Private Function AddToDataSet() As DataSet
        Ds = New DataSet
        Ds.Clear()
        Try
            ' Add Table
            Ds.Tables.Add("daftar_nama")

            ' Add Columns
            Dim col As DataColumn
            For Each gridCol As DataGridViewColumn In grid_nama.Columns
                col = New DataColumn(gridCol.Name)
                Ds.Tables("daftar_nama").Columns.Add(col)
            Next

            'Add Rows from the datagridview
            Dim row As DataRow
            Dim colcount As Integer = grid_nama.Columns.Count - 1
            For i As Integer = 0 To grid_nama.Rows.Count - 1
                row = Ds.Tables("daftar_nama").Rows.Add
                For Each column As DataGridViewColumn In grid_nama.Columns
                    row.Item(column.Index) = grid_nama.Rows.Item(i).Cells(column.Index).Value
                Next
            Next
            Return Ds
        Catch ex As Exception
            MsgBox("CRITICAL ERROR : Exception caught while converting dataGridView to DataSet (dgvtods).. " & Chr(10) & ex.Message)
            Return Nothing
        End Try
    End Function

    'Memuat File XML ke dalam datagridview
    Private Sub ReadXMLtoDataset(ByVal FilePath As String)
        Ds = New DataSet
        Ds.Clear()
        Ds.ReadXml(FilePath)
        atur_grid(grid_nama)
        grid_nama.DataSource = Ds
    End Sub

    'menambahkan dataset kedalam XML
    Private Function AddToXMLFile(ByVal FileName As String) As Boolean
        If File.Exists(FileName) Then
            If AllowFilePermission(FileName) = True Then
                My.Computer.FileSystem.DeleteFile(FilePath)
                Dim DtSetXML As New DataSet
                DtSetXML.Clear()
                Dim Stream As New FileStream(FileName, FileMode.Create)
                Dim XMLWriter As New XmlTextWriter(Stream, System.Text.Encoding.Unicode)
                Try
                    If AddToDataSet() Is Nothing Then
                        Return False
                    Else
                        DtSetXML = AddToDataSet()
                        DtSetXML.WriteXml(XMLWriter)
                        XMLWriter.Close()
                        Return True
                    End If
                Catch ex As Exception
                    MsgBox("gagal dalam menyimpan ke dalam XML " & ex.Message, MsgBoxStyle.Information, "INFO")
                    Return False
                Finally
                    Stream.Dispose()
                End Try
            Else
                MsgBox("gagal mendapatkan akses keamanan", MsgBoxStyle.Information, "INFO")
            End If
        Else
            Dim DtSetXML As New DataSet
            DtSetXML.Clear()
            Dim Stream As New FileStream(FileName, FileMode.Create)
            Dim XMLWriter As New XmlTextWriter(Stream, System.Text.Encoding.Unicode)
            Try
                If AddToDataSet() Is Nothing Then
                    Return False
                Else

                    DtSetXML = AddToDataSet()
                    DtSetXML.WriteXml(XMLWriter)
                    XMLWriter.Close()
                    Return True
                End If
            Catch ex As Exception
                MsgBox("gagal dalam menyimpan ke dalam XML " & ex.Message, MsgBoxStyle.Information, "INFO")
                Return False
            Finally
                Stream.Dispose()
            End Try
        End If
    End Function

    'memuat file XML
    Private Sub LoadFromXMLfile(ByVal filename As String)
        Dim xmldoc As New XmlDocument
        Dim xmlnode As XmlNodeList
        Dim fs As New FileStream(FilePath, FileMode.Open, FileAccess.Read)
        Try

            xmldoc.Load(fs)
            xmlnode = xmldoc.GetElementsByTagName("daftar_nama")
            atur_grid(grid_nama)
            For i% = 0 To xmlnode.Count - 1
                xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
                With grid_nama
                    .Rows.Add(1)
                    .Rows(.RowCount - 2).Cells(0).Value = xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
                    .Update()
                End With
            Next
        Catch ex As Exception
        Finally
            xmldoc = Nothing
            fs.Dispose()
        End Try
    End Sub
    '----------------------------------------------------------------------------
    ' Daftar nama yang ingin Anda simpan
    Dim names As New List(Of String)()
    Private Sub SimpanDaftarNama()
        ' Mengambil daftar nama dari DataGridView
        For Each row As DataGridViewRow In grid_nama.Rows
            If Not row.IsNewRow Then
                ' Kolom 0 berisi nama dalam contoh ini, ganti dengan kolom yang sesuai
                Dim name As String = row.Cells(0).Value.ToString()
                names.Add(name)
            End If
        Next

        Try
            ' Membuka file untuk penulisan (file akan dibuat jika belum ada)
            Using writer As New StreamWriter(filePath)
                For Each name As String In names
                    ' Menulis setiap nama ke dalam file teks
                    writer.WriteLine(name)
                Next
            End Using
            MessageBox.Show("Daftar nama telah disimpan.")
            Dim fileInfo As New FileInfo(FilePath)
            Dim fileSecurity As FileSecurity = fileInfo.GetAccessControl()
            fileSecurity.AddAccessRule(New FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow))
            fileInfo.SetAccessControl(fileSecurity)
        Catch ex As UnauthorizedAccessException
            MessageBox.Show("Izin ditolak. Jalankan aplikasi sebagai Administrator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat menyimpan file: " & ex.Message)
        End Try
    End Sub

    Private Sub MuatDaftarnama()
        Try
            ' Membaca daftar nama dari file .txt
            Dim names As New List(Of String)()
            Using reader As New StreamReader(FilePath)
                Dim line As String
                Do
                    line = reader.ReadLine()
                    If line IsNot Nothing Then
                        names.Add(line)
                    End If
                Loop Until line Is Nothing
            End Using

            ' Menampilkan daftar nama di DataGridView
            grid_nama.Rows.Clear()
            atur_grid(grid_nama)
            For Each name As String In names
                grid_nama.Rows.Add(name)
            Next

            ' MessageBox.Show("Daftar nama telah dimuat dari file .txt.")
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat membaca file: " & ex.Message)
        End Try
    End Sub
    '-----------------------------------------------------------------------------------

    Private Sub Button_baru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("tampilkan daftar nama bagian khusus?", MsgBoxStyle.OkCancel, "") = vbOK Then
            If File.Exists(FilePath) Then
                LoadFromXMLfile(FilePath)
            Else
                MsgBox("file tidak tersedia", MsgBoxStyle.Information, "INFO")
            End If
        End If
    End Sub


    Private Sub HapusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HapusToolStripMenuItem.Click
        grid_nama.Rows.RemoveAt(RowIndex)
    End Sub

    Private Sub Label1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseUp
        With Label1
            If e.Button = MouseButtons.Right Then
                .ContextMenuStrip = ContextMenuStrip1
                Me.ContextMenuStrip1.Show(Me.Label1, e.Location)
                Me.ContextMenuStrip1.Show(Cursor.Position)
            Else
                .ContextMenuStrip = Nothing
            End If
        End With
    End Sub


    Private Sub grid_nama_CellMouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grid_nama.CellMouseUp
        With grid_nama
            If e.Button = MouseButtons.Right Then
                If .Rows.Count > 1 Then
                    .ContextMenuStrip = ContextMenuStrip1
                    RowIndex = .CurrentRow.Index
                    Me.ContextMenuStrip1.Show(Me.grid_nama, e.Location)
                    Me.ContextMenuStrip1.Show(Cursor.Position)
                Else
                    .ContextMenuStrip = Nothing
                End If
            End If
        End With
    End Sub

    'mendapatkan file pengatuan yang telah tersimpan sebelumnya
    Private Sub GetDataConfig(ByVal JenisLaporan As String, ByVal FilePath As String)
        Try
            If AllowFilePermission(FilePath) = True Then
                Select Case JenisLaporan
                    Case "laporan Bulanan"
                        Return
                    Case "Laporan Triwulan"
                        TextKode.Text = readini(FilePath, "setting config triwulan", "kode_laporan", "")
                        ComboStaff.Text = readini(FilePath, "setting config triwulan", "bag_administrasi", "")
                        ComboManager.Text = readini(FilePath, "setting config triwulan", "manager", "")
                    Case "Laporan Tahunan"
                        TextKode.Text = readini(FilePath, "setting config triwulan", "kode_laporan", "")
                        ComboStaff.Text = readini(FilePath, "setting config triwulan", "bag_administrasi", "")
                        ComboManager.Text = readini(FilePath, "setting config triwulan", "manager", "")
                    Case "Laporan Kecelakaan Kerja"
                        TextKode.Text = readini(FilePath, "setting Config KecKerja", "kode_laporan", "")
                        ComboManager.Text = readini(FilePath, "setting Config KecKerja", "manager", "")
                End Select
            End If
        Catch ex As Exception

        End Try
        txt_server = readini(FilePath, "Setting Config", "server", "")
        txt_db = readini(FilePath, "Setting Config", "database", "")
        cmb_auth = readini(FilePath, "Setting Config", "auth", "")
        txt_id = readini(FilePath, "Setting Config", "userid", "")
        txt_pwd = readini(FilePath, "Setting Config", "password", "")

    End Sub

    'menyimpan pengaturan di config_report.ini file untuk di panggil pada saat mencetak laporan
    Private Sub writeDataConfig(ByVal JenisLaporan As String, ByVal FilePath As String)
        Try
            If AllowFilePermission(FilePath) = True Then
                Cursor.Current = Cursors.WaitCursor
                Select Case JenisLaporan
                    Case "Laporan Bulanan"
                        writeini(FilePath, "setting Config bulanan", "kode_laporan", TextKode.Text)
                        writeini(FilePath, "setting Config bulanan", "manager", ComboManager.Text)
                        writeini(FilePath, "setting Config bulanan", "bag_administrasi", ComboStaff.Text)
                    Case "Laporan Triwulan"
                        writeini(FilePath, "setting Config triwulan", "kode_laporan", TextKode.Text)
                        writeini(FilePath, "setting Config triwulan", "manager", ComboManager.Text)
                        writeini(FilePath, "setting Config triwulan", "bag_administrasi", ComboStaff.Text)
                    Case "laporan Tahunan"
                        writeini(FilePath, "setting Config tahunan", "kode_laporan", TextKode.Text)
                        writeini(FilePath, "setting Config tahunan", "manager", ComboManager.Text)
                        writeini(FilePath, "setting Config tahunan", "bag_administrasi", ComboStaff.Text)
                    Case "laporan Kecelakaan Kerja"
                        writeini(FilePath, "setting Config KecKerja", "kode_laporan", TextKode.Text)
                        writeini(FilePath, "setting Config KecKerja", "manager", ComboManager.Text)
                End Select
            Else
                MsgBox("gagal mendapatkan akses ", MsgBoxStyle.Information, "INFO")
            End If

            MsgBox("pengaturan tersimpan", MsgBoxStyle.Information, "INFO")
            Clear_text(Me, Nothing)
            Cursor.Current = Cursors.Arrow
        Catch exs As Exception
            MsgBox("gagal menyimpan pengaturan", MsgBoxStyle.Information, "INFO")
            Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Private Sub BSaveLap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSaveLap.Click
        If MsgBox("Apakah data sudah siap untuk disimpan?", MsgBoxStyle.OkCancel, "INFO") = vbOK Then
            writeDataConfig(Combo_JnsLap.Text, FilePathConfig)
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SimpanDaftarNama()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MuatDaftarnama()
    End Sub

    Private Sub Combo_nama_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Combo_nama.SelectedIndexChanged

    End Sub
End Class