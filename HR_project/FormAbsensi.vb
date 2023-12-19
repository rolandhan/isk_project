Imports System.Data.SqlClient
Imports System.Data.Sql
Imports System.IO
Imports System.Globalization

Public Class FormAbsensi
    Private tglawal, tglakhir As Date
    Private rowindex As Integer
    Private nik, hasil As String
    Private baris As Integer
    Private SQL_ As String
    Private SQLcmd_ As SqlCommand
    Private SQLReader_ As SqlDataReader

    Private Sub FormAbsensi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New CultureInfo("id-ID")
        clear_date(Me, Nothing)
        load_combo(combo_Departemen, "departemen", "tbl_statuskerja")
    End Sub

    Private Sub loading_datafinger() 'tampil data absensi dari raw download fingerprint
        With grid_tampil
            clear_command()
            openDB()
            Try
                If combo_Departemen.Text = String.Empty Then
                    sql = "SELECT temp.nik, temp.nama, temp.departemen, temp.tanggal, temp.timein," & _
                        "temp.timeout FROM(SELECT view_pegawai.nik, view_pegawai.nama, " & _
                        "view_pegawai.departemen ,view_pegawai.status_karyawan, convert(date,table_view .tanggal) as tanggal, " & _
                        "CONVERT(time, max(CASE WHEN seqnum = 1 THEN table_view .tanggal END)) AS timein, " & _
                        "CONVERT(time, max(CASE WHEN seqnum > 1 THEN table_view .tanggal END)) AS timeout " & _
                        "FROM " & _
                        "(SELECT tbl_rawabsen.*, row_number() OVER " & _
                        "(partition BY tbl_rawabsen.nik, CONVERT(date, tbl_rawabsen.tanggal) " & _
                        "ORDER BY tbl_rawabsen.tanggal) AS seqnum " & _
                        "FROM tbl_rawabsen " & _
                        "WHERE convert(date,tanggal) BETWEEN @tglawal AND @tglakhir) AS table_view " & _
                        "RIGHT OUTER JOIN view_pegawai ON table_view.nik = view_pegawai.nik " & _
                        "GROUP BY view_pegawai.nik, CONVERT(date, table_view.tanggal), view_pegawai.nama, view_pegawai.status_karyawan, " & _
                        "view_pegawai.departemen) AS temp WHERE temp.status_karyawan <> 'keluar' "
                Else
                    sql = "SELECT temp.nik, temp.nama, temp.departemen, temp.tanggal, " & _
                        "temp.timein, temp.timeout FROM(SELECT view_pegawai.nik, view_pegawai.nama, " & _
                        "view_pegawai.departemen ,view_pegawai.status_karyawan, convert(date,table_view .tanggal) as tanggal, " & _
                        "CONVERT(time, max(CASE WHEN seqnum = 1 THEN table_view .tanggal END)) AS timein, " & _
                        "CONVERT(time, max(CASE WHEN seqnum > 1 THEN table_view .tanggal END)) AS timeout " & _
                        "FROM " & _
                        "(SELECT tbl_rawabsen.*, row_number() OVER " & _
                        "(partition BY tbl_rawabsen.nik, CONVERT(date, tbl_rawabsen.tanggal) " & _
                        "ORDER BY tbl_rawabsen.tanggal) AS seqnum " & _
                        "FROM tbl_rawabsen " & _
                        "WHERE convert(date,tanggal) BETWEEN @tglawal AND @tglakhir) AS table_view " & _
                        "RIGHT OUTER JOIN view_pegawai ON table_view.nik = view_pegawai.nik " & _
                        "WHERE view_pegawai.departemen = @departemen " & _
                        "GROUP BY view_pegawai.nik, CONVERT(date, table_view.tanggal), view_pegawai.nama, " & _
                        "view_pegawai.departemen, view_pegawai.status_karyawan) AS temp WHERE temp.status_karyawan <> 'keluar' "
                End If
                sqlcmd = New SqlCommand(sql, Conn)
                With sqlcmd.Parameters
                    .Add("@tglawal", SqlDbType.Date).Value = DTawal.Text
                    .Add("@tglakhir", SqlDbType.Date).Value = DTakhir.Text
                    .Add("@departemen", SqlDbType.VarChar).Value = combo_Departemen.Text
                End With
                sqladapter = New SqlDataAdapter
                sqladapter.SelectCommand = sqlcmd
                DataTab = New DataTable
                DataTab.Clear()
                sqladapter.Fill(DataTab)
                grid_tampil.DataSource = DataTab
                Cursor.Current = Cursors.WaitCursor
            Catch ex As Exception
                MsgBox("Gagal menampilkan data " & ex.Message, MsgBoxStyle.Information, "INFO")
            Finally
                Cursor.Current = Cursors.Arrow
            End Try
        End With
    End Sub

    Private Sub loading_detaildata() 'load detail dari tiap karyawan 
        Try
            clear_command()
            openDB()
            sql = "SELECT view_pegawai.nik, view_pegawai.nama, " & _
                "CONVERT(date,tbl_rawabsen.tanggal) AS tgl, " & _
                "CONVERT(time, tbl_rawabsen.tanggal) as waktu " & _
                "FROM tbl_rawabsen LEFT OUTER JOIN view_pegawai ON tbl_rawabsen .nik = view_pegawai.nik " & _
                "WHERE view_pegawai.nik = @nik AND " & _
                "CONVERT(date,tbl_rawabsen .tanggal) BETWEEN @tglawal AND @tglakhir " & _
                "ORDER BY CONVERT(time, tbl_rawabsen.tanggal),view_pegawai.nik"
            sqlcmd = New SqlCommand(sql, Conn)
            With sqlcmd.Parameters
                .Add("@nik", SqlDbType.VarChar).Value = nik
                .Add("@tglawal", SqlDbType.Date).Value = DTawal.Text
                .Add("tglakhir", SqlDbType.Date).Value = DTakhir.Text
            End With
            sqladapter = New SqlDataAdapter
            sqladapter.SelectCommand = sqlcmd
            DataTab = New DataTable
            DataTab.Clear()
            sqladapter.Fill(DataTab)
            grid_detabsensi.DataSource = DataTab
        Catch ex As Exception
            MsgBox("Gagal dalam menampilkan data " & ex.Message, MsgBoxStyle.Information, "INFO")
        End Try
    End Sub

    Private Sub simpan_data(ByVal grid As DataGridView, ByVal baris As Integer)
        Try
            clear_command()
            openDB()
            With grid
                sql = "INSERT INTO tbl_dataabsen(nik, tanggal, timein, timeout) " & _
                    "VALUES('" & .Rows(baris).Cells(0).Value & "', @tanggal, @timein, @timeout)"
                sqlcmd = New SqlCommand(sql, Conn)
                If IsDBNull(.Rows(baris).Cells(3).Value) Then
                    sqlcmd.Parameters.Add("@tanggal", SqlDbType.Date).Value = DBNull.Value
                Else
                    sqlcmd.Parameters.Add("@tanggal", SqlDbType.Date).Value = .Rows(baris).Cells(3).Value
                End If
                sqlcmd.Parameters.Add("@timein", SqlDbType.Time).Value = .Rows(baris).Cells(4).Value
                sqlcmd.Parameters.Add("@timeout", SqlDbType.Time).Value = .Rows(baris).Cells(5).Value
                sqlcmd.ExecuteNonQuery()
            End With
        Catch ex As Exception
            MsgBox("Gagal dalam penyimpanan data simpan" & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Sub update_data(ByVal grid As DataGridView, ByVal baris As Integer)
        Try
            clear_command()
            openDB()
            With grid
                If IsNothing(.Rows(baris).Cells(4).Value) Then
                    sql = "UPDATE tbl_dataabsen SET timeout = @timeout " & _
                        "WHERE nik =  @nik AND tanggal = @tanggal"
                ElseIf IsNothing(.Rows(baris).Cells(5).Value) Then
                    sql = "UPDATE tbl_dataabsen SET timein = @timein" & _
                        "WHERE nik =  @nik AND tanggal = @tanggal"
                Else
                    sql = "UPDATE tbl_dataabsen SET timein = @timein , timeout = @timeout " & _
                        "WHERE nik =  @nik AND tanggal = @tanggal"
                End If
                sqlcmd = New SqlCommand(sql, Conn)
                sqlcmd.Parameters.Add("@nik", SqlDbType.VarChar).Value = .Rows(baris).Cells(0).Value
                If IsDBNull(.Rows(baris).Cells(3).Value) Then
                    sqlcmd.Parameters.Add("@tanggal", SqlDbType.Date).Value = DBNull.Value
                Else
                    sqlcmd.Parameters.Add("@tanggal", SqlDbType.Date).Value = .Rows(baris).Cells(3).Value
                End If
                sqlcmd.Parameters.Add("@timein", SqlDbType.Time).Value = .Rows(baris).Cells(4).Value
                sqlcmd.Parameters.Add("@timeout", SqlDbType.Time).Value = .Rows(baris).Cells(5).Value
                sqlcmd.ExecuteNonQuery()
                Cursor.Current = Cursors.WaitCursor
            End With
        Catch ex As Exception
            MsgBox("Gagal dalam penyimpanan data " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Sub

    Private Function cek_data(ByVal grid As DataGridView, ByVal baris As Integer) As Boolean
        Try
            openDB()
            With grid
                SQL_ = "SELECT nik FROM tbl_dataabsen " & _
                    "WHERE nik = @nik AND tanggal = @tanggal"
                SQLcmd_ = New SqlCommand(SQL_, Conn)
                With grid
                    SQLcmd_.Parameters.Add("@nik", SqlDbType.VarChar)
                    SQLcmd_.Parameters("@nik").Value = .Rows(baris).Cells(0).Value
                    If IsDBNull(.Rows(baris).Cells(3).Value) Then
                        SQLcmd_.Parameters.Add("@tanggal", SqlDbType.Date).Value = DBNull.Value
                    Else
                        SQLcmd_.Parameters.Add("@tanggal", SqlDbType.Date).Value = .Rows(baris).Cells(3).Value
                    End If
                End With
                SQLReader_ = SQLcmd_.ExecuteReader
                If SQLReader_.Read Then
                    Return True
                Else
                    Return False
                End If
                SQLReader_.Close()
            End With
        Catch ex As Exception
            MsgBox("gagal dalam pengecekan data " & ex.Message, MsgBoxStyle.Information, "INFO")
        Finally
            Conn.Close()
        End Try
    End Function


    Private Sub DTawal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTawal.ValueChanged
        format_tanggal(DTawal)
    End Sub

    Private Sub DTakhir_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTakhir.ValueChanged
        format_tanggal(DTakhir)
    End Sub

    Private Sub Button_tampil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_tampil.Click
        loading_datafinger()

    End Sub

    Private Sub grid_tampil_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grid_tampil.CellMouseUp
        With grid_tampil
            If e.Button = MouseButtons.Right Then
                If .Rows.Count > 1 Then
                    .ContextMenuStrip = ContextMenuStrip1
                    rowindex = .CurrentRow.Index
                    nik = .Rows(rowindex).Cells(0).Value
                    Me.ContextMenuStrip1.Show(Me.grid_tampil, e.Location)
                    Me.ContextMenuStrip1.Show(Cursor.Position)
                Else
                    .ContextMenuStrip = Nothing
                End If
            End If
        End With
    End Sub

    Private Sub CekHistoriToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CekHistoriToolStripMenuItem.Click
        nik = grid_tampil.Rows(rowindex).Cells(0).Value
        loading_detaildata()
    End Sub

    Private Sub Button_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_simpan.Click
        If grid_tampil.RowCount > 1 Then
            If MsgBox("Apakah data siap di simpan ? ", MsgBoxStyle.Information & vbOKCancel, "INFO") = vbOK Then
                Try
                    For baris = 0 To grid_tampil.RowCount - 2
                        If cek_data(grid_tampil, baris) = True Then
                            'update data
                            With grid_tampil
                                If Not IsDBNull(.Rows(baris).Cells(3).Value) Then
                                    update_data(grid_tampil, baris)
                                End If
                            End With
                        Else
                            'simpan data
                            With grid_tampil
                                If Not IsDBNull(.Rows(baris).Cells(3).Value) Then
                                    simpan_data(grid_tampil, baris)
                                End If
                            End With

                        End If
                        hasil = 1
                    Next baris
                    Cursor.Current = Cursors.WaitCursor
                Catch Ex As Exception
                    hasil = 0
                    MsgBox("Gagal dalam penyimpanan data " & Ex.Message, MsgBoxStyle.Information, "INFO")
                Finally
                    Cursor.Current = Cursors.Arrow
                End Try
                If hasil = 1 Then
                    MsgBox("Data telah berhasil di simpan ", MsgBoxStyle.Information, "INFO")
                End If
            End If
        End If
    End Sub

    Private Sub grid_tampil_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid_tampil.CellContentClick

    End Sub
End Class