Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Data
Imports System.Globalization

Public Class FormImportData
    Private excelconn As OleDbConnection
    Private oleAdapter As OleDbDataAdapter
    Private openfile As OpenFileDialog
    Private strname, namefile As String

    Private Sub FormImportData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New CultureInfo("EN-US")
        load_dtcombo()
    End Sub

    Private Sub load_dtcombo()
        With Combo_jenis
            .Items.Add("data absen")
            .Items.Add("data pegawai")
            .Items.Add("data istri")
        End With
    End Sub

    Private Sub browsefile(ByVal grid As DataGridView)
        Try
            openfile = New OpenFileDialog
            openfile.Filter = "document 2007 doc(*.xls)|*.xls|Document 2010 doc(*.xlsx)|*.xlsx"
            openfile.FilterIndex = 1
            If openfile.ShowDialog = Windows.Forms.DialogResult.OK Then
                strname = openfile.FileName
                namefile = openfile.SafeFileName
                load_excel(grid)
                'Label1.Text = strname & " " & namefile
            Else
                strname = Nothing
            End If
        Catch Ex As Exception
            MsgBox("gagal membuka file" & Ex.Message, MsgBoxStyle.Information, "INFO")
        End Try
    End Sub

    Private Sub load_excel(ByVal grid As DataGridView)
        Try
            Dim sConn As String
            sConn = "provider=Microsoft.ACE.OLEDB.12.0;Data Source= " & _
                    "'" & strname & "';Extended Properties=Excel 12.0;;"

            excelconn = New OleDbConnection(sConn)
            oleAdapter = New OleDbDataAdapter("select * from [" & Text_sheet.Text & "$]", excelconn)
            oleAdapter.TableMappings.Add("Table", "Tabel Karyawan")
            dtset = New DataSet
            oleAdapter.Fill(dtset)
            grid.DataSource = dtset.Tables(0)
            excelconn.Close()
        Catch ex As Exception
            MsgBox("gagal menampilkan file excel " & ex.Message)
        End Try
    End Sub

    Private Sub simpan_data(ByVal grid As DataGridView)
        Try
            clear_command()
            openDB()
            With grid
                For A% = 0 To .RowCount - 2
                    If Combo_jenis.Text = "data absen" Then
                        sql = "INSERT INTO tbl_rawabsen(nik, tanggal) VALUES(@nik, @tanggal)"
                        sqlcmd = New SqlCommand(sql, Conn)
                        sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = .Rows(A).Cells(1).Value
                        sqlcmd.Parameters.Add("@tanggal", SqlDbType.DateTime2).Value = .Rows(A).Cells(0).Value
                    ElseIf Combo_jenis.Text = "data pegawai" Then
                        sql = "INSERT INTO tbl_pegawai(nik, nama, no_kk, no_ktp, tempat_lahir, tgl_lahir, agama, sex, " & _
                            "pendidikan, alamat_asal, rt_asal, rw_asal, desa_asal, kec_asal, kab_asal, kdpos_asal, " & _
                            "alamat_dom, rt_dom, rw_dom, desa_dom, kec_dom, kab_dom, kdpos_dom, no_telp, email, " & _
                            "status_kawin, faskes_tk1, faskes_gigi, kerabat, telp_kerabat) " & _
                            "VALUES(@nik, @nama, @no_kk, @no_ktp, @tempat_lahir, @tgl_lahir, @agama, @sex, " & _
                            "@pendidikan, @alamat_asal, @rt_asal, @rw_asal, @desa_asal, @kec_asal, @kab_asal, @kdpos_asal, " & _
                            "@alamat_dom, @rt_dom, @rw_dom, @desa_dom, @kec_dom, @kab_dom, @kdpos_dom, @no_telp, @email, " & _
                            "@status_kawin, @faskes_tk1, @faskes_gigi, @kerabat, @telp_kerabat)"
                        sqlcmd = New SqlCommand(sql, Conn)
                        sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = .Rows(A).Cells(0).Value
                        sqlcmd.Parameters.Add("@nama", SqlDbType.VarChar).Value = .Rows(A).Cells(1).Value
                        sqlcmd.Parameters.Add("@no_kk", SqlDbType.VarChar).Value = .Rows(A).Cells(2).Value
                        sqlcmd.Parameters.Add("@no_ktp", SqlDbType.VarChar).Value = .Rows(A).Cells(3).Value
                        sqlcmd.Parameters.Add("@tempat_lahir", SqlDbType.VarChar).Value = .Rows(A).Cells(4).Value
                        sqlcmd.Parameters.Add("@tgl_lahir", SqlDbType.DateTime2).Value = .Rows(A).Cells(5).Value
                        sqlcmd.Parameters.Add("@agama", SqlDbType.VarChar).Value = .Rows(A).Cells(6).Value
                        sqlcmd.Parameters.Add("@sex", SqlDbType.VarChar).Value = .Rows(A).Cells(7).Value
                        sqlcmd.Parameters.Add("@pendidikan", SqlDbType.VarChar).Value = .Rows(A).Cells(8).Value
                        sqlcmd.Parameters.Add("@alamat_asal", SqlDbType.VarChar).Value = .Rows(A).Cells(9).Value
                        sqlcmd.Parameters.Add("@rt_asal", SqlDbType.VarChar).Value = .Rows(A).Cells(10).Value
                        sqlcmd.Parameters.Add("@rw_asal", SqlDbType.VarChar).Value = .Rows(A).Cells(11).Value
                        sqlcmd.Parameters.Add("@desa_asal", SqlDbType.VarChar).Value = .Rows(A).Cells(12).Value
                        sqlcmd.Parameters.Add("@kec_asal", SqlDbType.VarChar).Value = .Rows(A).Cells(13).Value
                        sqlcmd.Parameters.Add("@kab_asal", SqlDbType.VarChar).Value = .Rows(A).Cells(14).Value
                        sqlcmd.Parameters.Add("@kdpos_asal", SqlDbType.VarChar).Value = .Rows(A).Cells(15).Value
                        sqlcmd.Parameters.Add("@alamat_dom", SqlDbType.VarChar).Value = .Rows(A).Cells(16).Value
                        sqlcmd.Parameters.Add("@rt_dom", SqlDbType.VarChar).Value = .Rows(A).Cells(17).Value
                        sqlcmd.Parameters.Add("@rw_dom", SqlDbType.VarChar).Value = .Rows(A).Cells(18).Value
                        sqlcmd.Parameters.Add("@desa_dom", SqlDbType.VarChar).Value = .Rows(A).Cells(19).Value
                        sqlcmd.Parameters.Add("@kec_dom", SqlDbType.VarChar).Value = .Rows(A).Cells(20).Value
                        sqlcmd.Parameters.Add("@kab_dom", SqlDbType.VarChar).Value = .Rows(A).Cells(21).Value
                        sqlcmd.Parameters.Add("@kdpos_dom", SqlDbType.VarChar).Value = .Rows(A).Cells(22).Value
                        sqlcmd.Parameters.Add("@no_telp", SqlDbType.VarChar).Value = .Rows(A).Cells(23).Value
                        sqlcmd.Parameters.Add("@email", SqlDbType.VarChar).Value = .Rows(A).Cells(24).Value
                        sqlcmd.Parameters.Add("@status_kawin", SqlDbType.VarChar).Value = .Rows(A).Cells(25).Value
                        sqlcmd.Parameters.Add("@faskes_tk1", SqlDbType.VarChar).Value = .Rows(A).Cells(26).Value
                        sqlcmd.Parameters.Add("@faskes_gigi", SqlDbType.VarChar).Value = .Rows(A).Cells(27).Value
                        sqlcmd.Parameters.Add("@kerabat", SqlDbType.VarChar).Value = .Rows(A).Cells(28).Value
                        sqlcmd.Parameters.Add("@telp_kerabat", SqlDbType.VarChar).Value = .Rows(A).Cells(29).Value
                    ElseIf Combo_jenis.Text = "data istri" Then
                        sql = "INSERT INTO tbl_istri( nik, nama, no_ktp, tempat_lahir, tgl_lahir) " & _
                            "VALUES( @nik, @nama, @no_ktp, @tempat_lahir, @tgl_lahir)"
                        sqlcmd = New SqlCommand(sql, Conn)
                        sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = .Rows(A).Cells(0).Value
                        sqlcmd.Parameters.Add("@nama", SqlDbType.VarChar).Value = .Rows(A).Cells(1).Value
                        sqlcmd.Parameters.Add("@no_ktp", SqlDbType.VarChar).Value = .Rows(A).Cells(2).Value
                        sqlcmd.Parameters.Add("@tempat_lahir", SqlDbType.VarChar).Value = .Rows(A).Cells(3).Value
                        sqlcmd.Parameters.Add("@tgl_lahir", SqlDbType.DateTime2).Value = .Rows(A).Cells(4).Value
                    End If
                    sqlcmd.ExecuteNonQuery()
                Next A
                Cursor.Current = Cursors.WaitCursor
                clear_command()
                'For B% = 0 To .RowCount - 2
                'sql = "INSERT INTO tbl_statuskerja(nik, departemen, jabatan) " & _
                '    "VALUES(@nik, @departemen, @jabatan)"
                'sqlcmd = New SqlCommand(sql, Conn)
                'sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = .Rows(B).Cells(1).Value
                'sqlcmd.Parameters.Add("@departemen", SqlDbType.VarChar).Value = .Rows(B).Cells(2).Value
                'sqlcmd.Parameters.Add("@jabatan", SqlDbType.VarChar).Value = .Rows(B).Cells(3).Value
                'sqlcmd.ExecuteNonQuery()
                'Next B
                MsgBox("Sukses dalam penyimpanan data ", MsgBoxStyle.Information, "INFO")
            End With
        Catch ex As Exception
            MsgBox("gagal dalam penyimpanan data " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Cursor.Current = Cursors.Arrow
        End Try
    End Sub

    Private Sub Button_browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_browse.Click
        browsefile(grid_tampilan)
    End Sub

    Private Sub Button_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_simpan.Click
        simpan_data(grid_tampilan)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class