Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Data.OleDb
Imports System.Net
Imports System
Imports System.IO
Imports System.Text
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization

Public Class FormDownloadData

    Public DB As OleDbConnection
    Public CMD As OleDbCommand
    Public CMD1 As OleDbCommand
    Public ADP As OleDbDataAdapter
    Public ARD As OleDbDataReader
    Public ARD1 As OleDbDataReader
    Public ADP1 As OleDbDataAdapter
    Public ADP2 As OleDbDataAdapter
    Public ADP3 As OleDbDataAdapter
    Public DS As New DataSet
    Public DS1 As New DataSet
    Public DS2 As New DataSet
    Public DS3 As New DataSet
    Dim SQL1 As String
    Dim rowcount, userrowcount As Integer
    Dim ServerPort_, serverIP_, DeviceSN_, ServerPort2_, serverIP2_, DeviceSN2_ As String

    Public Class WebClientExtended
        Inherits WebClient
        Public Property Timeout() As Integer
            Get
                Return m_Timeout
            End Get
            Set(ByVal value As Integer)
                m_Timeout = value
            End Set
        End Property
        Private m_Timeout As Integer

        Protected Overrides Function GetWebRequest(ByVal address As Uri) As WebRequest
            Dim request = MyBase.GetWebRequest(address)
            request.Timeout = Timeout
            Return request
        End Function
    End Class
    Private Function SendRequest(ByVal url As String, ByVal reqparm As Specialized.NameValueCollection, ByVal method As String) As String
        Using client As New WebClientExtended
            client.Timeout = -1
            Dim responsebytes = client.UploadValues(url, method, reqparm)
            Dim responsebody = (New Text.UTF8Encoding).GetString(responsebytes)
            Return responsebody
        End Using
    End Function

    Private Sub FormDownloadData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        load_default()
        atur_grid()
        Application.CurrentCulture = New CultureInfo("id-ID")
    End Sub

    Private Sub atur_grid()
        With DGV_scanlog
            .Enabled = True
            .ColumnCount = 7
            .Columns(0).HeaderText = "No"
            .Columns(0).Width = 50
            .Columns(1).HeaderText = "SN"
            .Columns(1).Width = 75
            .Columns(2).HeaderText = "Scandate"
            .Columns(2).Width = 75
            .Columns(3).HeaderText = "PIN"
            .Columns(3).Width = 75
            .Columns(4).HeaderText = "VerifyMode"
            .Columns(4).Width = 75
            .Columns(5).HeaderText = "IOMode"
            .Columns(5).Width = 75
            .Columns(6).HeaderText = "Workcode"
            .Columns(6).Width = 75
        End With
    End Sub


    Private Sub load_default()
        Dim FilePath As String = Application.StartupPath & "\setting.ini"
        Dim deflt_mesin As String = readini(FilePath, "default", "mesin", "")
        Combo_mesin.Text = deflt_mesin
        If deflt_mesin = "fingerspot" Then
            Text_msn1.Text = readini(FilePath, "fingerspot1", "nomesin", "")
            TB_serverIP.Text = readini(FilePath, "fingerspot1", "serverip", "")
            TB_serverPort.Text = readini(FilePath, "fingerspot1", "serverport", "")
            TB_deviceSN.Text = readini(FilePath, "fingerspot1", "devicesn", "")
            Text_msn2.Text = readini(FilePath, "fingerspot2", "nomesin", "")
            TB_serverIP2.Text = readini(FilePath, "fingerspot2", "serverip", "")
            TB_serverPort2.Text = readini(FilePath, "fingerspot2", "serverport", "")
            TB_deviceSN2.Text = readini(FilePath, "fingerspot2", "devicesn", "")
        ElseIf deflt_mesin = "solution" Then

        End If
    End Sub

    Private Sub RefreshDataUser()
        'Call koneksiDB()
        Try
            ADP = New OleDbDataAdapter("Select * from [user]", DB)
            DS = New DataSet
            ADP.Fill(DS, "user")
            DGV_user.DataSource = DS.Tables("user")

            ADP1 = New OleDbDataAdapter("Select * from [scanlog]", DB)
            DS1 = New DataSet
            ADP1.Fill(DS1, "scanlog")
            DGV_scanlog.DataSource = DS1.Tables("scanlog")

            ADP2 = New OleDbDataAdapter("Select * from [template]", DB)
            DS2 = New DataSet
            ADP2.Fill(DS2, "template")
            DGV_template.DataSource = DS2.Tables("template")

            userrowcount = DGV_user.Rows.Count()
            L_UserRecordCount.Text = "User Record : " & userrowcount
            rowcount = DGV_scanlog.Rows.Count()
            L_recordCount.Text = "Scanlog Record : " & rowcount
            DB.Close()
        Catch ex As Exception
            MsgBox("failed")
        End Try
    End Sub

    Private Sub B_getAllScanlog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TB_memo.Clear()
        'If Integer.Parse(edt_limit_user.Text) > 100) Then
        'MessageBox.Show("Maaf, max paging sampai 100 data.")
        'edt_limit_user.Clear()
        'edt_limit_user.Text = "100"
        'Else
        Dim jpin, jname, jrfid, jpwd, jpriv As String
        Dim data As New Specialized.NameValueCollection
        Dim location = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim appPath = Path.GetDirectoryName(location)
        Dim limit_paging = ""
        Dim jalan = False
        Dim status_ex = False
        'data.Add("sn", TB_deviceSN.Text)
        Dim snum = TB_deviceSN.Text
        Try
            If (edt_limit_user.Text <> "Limit paging") And (edt_limit_user.Text <> "") Then
                'data.Add("limit", edt_limit_user.Text)
                If edt_limit_user.Text > 100 Then
                    MessageBox.Show("Max paging 100.")
                    edt_limit_user.Text = "100"
                    jalan = False
                Else
                    limit_paging = CInt(edt_limit_user.Text)
                    jalan = True
                End If
            Else
                'data.Add("limit", 100)
                limit_paging = 100
                jalan = True
            End If

            If (jalan) Then
                Dim LogText As String = ""
                Dim isSession As Boolean = True
                'Call koneksiDB()
                SQL = "delete * from [user]"
                SQL1 = "delete * from [template]"
                CMD = New OleDbCommand(SQL, DB)
                CMD1 = New OleDbCommand(SQL1, DB)
                CMD.ExecuteNonQuery()
                CMD1.ExecuteNonQuery()
                Cursor.Current = Cursors.WaitCursor
                DB.Close()
                Cursor.Current = Cursors.Arrow
                While isSession
                    TB_memo.Text = "Harap Tunggu, sedang proses download data dari mesin."
                    'Dim result_post = SendRequest("http: //" + TB_serverIP.Text + ":" + TB_serverPort.Text + "/user/all/paging", data, "POST")
                    'TB_memo.Text = result_post
                    'Dim json As String = TB_memo.Text
                    'Dim json As String = result_post
                    'Dim ser = JObject.Parse(json)
                    'Dim jdata As List(Of JToken) = ser.Children().ToList
                    'Dim Rst As Boolean = ser.Item("Result")
                    'Dim Ses As Boolean = ser.Item("IsSession")
                    Dim param = "sn=" + snum + "&limit=" + limit_paging
                    Dim request = HttpWebRequest.Create("http://" + TB_serverIP.Text + ":" + TB_serverPort.Text + "/user/all/paging")
                    Dim rdata = Encoding.ASCII.GetBytes(param)
                    request.Timeout = ((1000 * 60) * 60) * 48
                    request.Method = "POST"
                    request.ContentType = "application/x-www-form-urlencoded"
                    request.ContentLength = rdata.Length

                    Using StreamType As Stream = request.GetRequestStream()
                        StreamType.Write(rdata, 0, rdata.Length)
                        StreamType.Close()
                    End Using

                    Dim response = request.GetResponse()
                    Dim responseString = New StreamReader(response.GetResponseStream()).ReadToEnd
                    response.Close()

                    Dim note_data As JObject = JsonConvert.DeserializeObject(responseString)
                    Dim note_b As Boolean = note_data("IsSession")
                    Dim note_r As Boolean = note_data("Result")

                    'If (Rst = True) Then
                    If note_r Then
                        'For Each item As JProperty In jdata
                        'item.CreateReader()
                        'Select Case item.Name
                        'Case "Data"
                        For Each comment In note_data.Item("Data").ToList()
                            jpin = comment("PIN")
                            jname = comment("Name")
                            jrfid = comment("RFID")
                            jpwd = comment("Password")
                            jpriv = comment("Privilege")
                            'Call koneksiDB()
                            SQL = "INSERT INTO [user] (pin, nama, pwd, rfid, privilege) VALUES ('" & jpin & "','" & jname.Replace("'", "''") & "','" & jpwd & "','" & jrfid & "','" & jpriv & "')"
                            CMD = New OleDbCommand(SQL, DB)
                            CMD.ExecuteNonQuery()
                            DB.Close()
                            'Call SaveTemplate(jpin, comment)
                        Next
                        ' End Select
                        'Next
                        LogText += responseString
                        TB_memo.Clear()
                        isSession = note_b
                        status_ex = True
                    Else
                        TB_memo.Text = responseString
                        status_ex = False
                        Exit While
                    End If

                End While
                'DB.Close()
                Call RefreshDataUser()
                'Call CompactDB()
                If (status_ex) Then
                    TB_memo.Text = "Download all user pagination finished. JSON text was saved to this path " + appPath + "\json_user.txt "
                    'menyimpan data json ke file text
                    Dim FILE_NAME As String = appPath + "\json_user.txt"
                    If System.IO.File.Exists(FILE_NAME) = False Then
                        System.IO.File.Create(FILE_NAME).Dispose()
                    End If
                    Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
                    objWriter.WriteLine(LogText)
                    objWriter.Close()
                    'TB_memo.Text = "Get All User Success ! " + vbNewLine + LogText
                    'End If
                End If
            End If
        Catch ex As Exception
            TB_memo.Text = ex.ToString()
        End Try
    End Sub

    Private Sub B_getNewScanlog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_getNewScanlog.Click
        TB_memo.Clear()
        clear_command()
        Dim iGLCount As Integer
        Call openDB()
        Dim jsn, jsn2 As String
        Dim jscandate, jscandate2 As String
        Dim jpin, jpin2 As String
        Dim jverifyMode, jverifymode2 As String
        Dim jIOMode, JIOMode2 As String
        Dim WorkCode, workcode2 As String
        Dim result_post, result_post2 As String
        Dim data, data2 As New Specialized.NameValueCollection

        If Check_1.Checked = True Then
            data.Add("sn", TB_deviceSN.Text)
            result_post = SendRequest("http://" + TB_serverIP.Text + ":" + TB_serverPort.Text + "/scanlog/new", data, "POST")
            TB_memo.Text = result_post
            Dim json As String = TB_memo.Text
            Dim ser As JObject = JObject.Parse(json)
            Dim jdata As List(Of JToken) = ser.Children().ToList
            Dim Rst As Boolean = ser.Item("Result")
            If (Rst = True) Then
                For Each item As JProperty In jdata
                    item.CreateReader()
                    Select Case item.Name
                        Case "Data"
                            For Each comment As JObject In item.Values
                                jsn = comment("SN")
                                jscandate = comment("ScanDate")
                                jpin = comment("PIN")
                                jverifyMode = comment("VerifyMode")
                                jIOMode = comment("IOMode")
                                WorkCode = comment("WorkCode")
                                sql = "INSERT INTO tbl_rawabsen(nik,tanggal) VALUES ('" & jpin & "','" & jscandate & "')"
                                sqlcmd = New SqlCommand(sql, Conn)
                                sqlcmd.ExecuteNonQuery()
                                iGLCount += 1
                                With DGV_scanlog
                                    .Rows.Add(1)
                                    .Rows(.RowCount - 2).Cells(0).Value = iGLCount.ToString()
                                    .Rows(.RowCount - 2).Cells(1).Value = jsn
                                    .Rows(.RowCount - 2).Cells(2).Value = jscandate
                                    .Rows(.RowCount - 2).Cells(3).Value = jpin
                                    .Rows(.RowCount - 2).Cells(4).Value = jverifyMode
                                    .Rows(.RowCount - 2).Cells(5).Value = jIOMode
                                    .Rows(.RowCount - 2).Cells(6).Value = WorkCode
                                End With
                            Next
                    End Select
                Next
                Conn.Close()
                TB_memo.Text = "Get New Scanlog Mesin 1 Success ! " + vbNewLine + result_post
            Else
                TB_memo.Text = "New Scanlog Mesin 1: 0 " + vbNewLine + result_post
            End If
        End If

        If Check_2.Checked = True Then
            clear_command()
            openDB()
            data2.Add("sn", TB_deviceSN2.Text)
            result_post2 = SendRequest("http://" + TB_serverIP2.Text + ":" + TB_serverPort2.Text + "/scanlog/new", data2, "POST")
            TB_memo.Text = TB_memo.Text & vbCrLf & result_post2
            Dim json2 As String = result_post2
            Dim ser2 As JObject = JObject.Parse(json2)
            Dim jdata2 As List(Of JToken) = ser2.Children().ToList
            Dim Rst2 As Boolean = ser2.Item("Result")
            If (Rst2 = True) Then
                For Each item2 As JProperty In jdata2
                    item2.CreateReader()
                    Select Case item2.Name
                        Case "Data"
                            For Each comment As JObject In item2.Values
                                jsn2 = comment("SN")
                                jscandate2 = comment("ScanDate")
                                jpin2 = comment("PIN")
                                jverifymode2 = comment("VerifyMode")
                                JIOMode2 = comment("IOMode")
                                workcode2 = comment("WorkCode")
                                sql = "INSERT INTO tbl_rawabsen(nik, tanggal) VALUES ('" & jpin2 & "','" & jscandate2 & "')"
                                sqlcmd = New SqlCommand(sql, Conn)
                                sqlcmd.ExecuteNonQuery()
                                iGLCount += 1
                                With DGV_scanlog
                                    .Rows.Add(1)
                                    .Rows(.RowCount - 2).Cells(0).Value = iGLCount.ToString()
                                    .Rows(.RowCount - 2).Cells(1).Value = jsn2
                                    .Rows(.RowCount - 2).Cells(2).Value = jscandate2
                                    .Rows(.RowCount - 2).Cells(3).Value = jpin2
                                    .Rows(.RowCount - 2).Cells(4).Value = jverifymode2
                                    .Rows(.RowCount - 2).Cells(5).Value = JIOMode2
                                    .Rows(.RowCount - 2).Cells(6).Value = workcode2
                                End With
                            Next
                    End Select
                Next
                Conn.Close()
                TB_memo.Text = "Get New Scanlog Mesin 2 Success ! " + vbNewLine + result_post2
            Else
                TB_memo.Text = "New Scanlog Mesin 2: 0 " + vbNewLine + result_post2
            End If
        End If
    End Sub

    Private Sub B_deviceInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_deviceInfo.Click
        Dim data As New Specialized.NameValueCollection
        Dim param, final_url, postData, param2, final_url2, postData2 As String
        Dim request, request2 As System.Net.WebRequest
        Dim infodata, infodata2 As Byte()
        Dim responseString, responseString2 As Object

        If Check_1.Checked = False And Check_2.Checked = False Then
            MsgBox("Silahkan pilih mesin terlebih dahulu ", MsgBoxStyle.Information, "INFO")
        Else
            Try
                TB_memo.Clear()
                TV_deviceInfo.Nodes.Clear()
                Cursor.Current = Cursors.WaitCursor
                If Check_1.Checked = True Then
                    ServerPort_ = TB_serverPort.Text
                    serverIP_ = TB_serverIP.Text
                    DeviceSN_ = TB_deviceSN.Text
                    param = "sn=" + DeviceSN_
                    'Data.Add("sn", TB_deviceSN.Text)
                    'Dim result_post = SendRequest("http://" + TB_serverIP.Text + ":" + TB_serverPort.Text + "/dev/info", data, "POST")
                    final_url = "http://" + serverIP_ + ":" + ServerPort_ + "/dev/info"
                    request = WebRequest.Create(final_url)
                    postData = param
                    infodata = Encoding.ASCII.GetBytes(postData)
                    request.Timeout = ((1000 * 60) * 60) * 48
                    request.Method = "POST"
                    request.ContentType = "application/x-www-form-urlencoded"
                    request.ContentLength = infodata.Length

                    Using streamtype As Stream = request.GetRequestStream()
                        streamtype.Write(infodata, 0, infodata.Length)
                        streamtype.Close()
                    End Using

                    Dim response = request.GetResponse()
                    responseString = New StreamReader(response.GetResponseStream()).ReadToEnd()
                    response.Close()
                End If

                If Check_2.Checked = True Then
                    ServerPort2_ = TB_serverPort2.Text
                    serverIP2_ = TB_serverIP2.Text
                    DeviceSN2_ = TB_deviceSN2.Text
                    param2 = "sn=" + DeviceSN2_
                    'Data.Add("sn", TB_deviceSN.Text)
                    'Dim result_post = SendRequest("http://" + TB_serverIP.Text + ":" + TB_serverPort.Text + "/dev/info", data, "POST")
                    final_url2 = "http://" + serverIP2_ + ":" + ServerPort2_ + "/dev/info"
                    request2 = WebRequest.Create(final_url2)
                    postData2 = param2
                    infodata2 = Encoding.ASCII.GetBytes(postData2)
                    request2.Timeout = ((1000 * 60) * 60) * 48
                    request2.Method = "POST"
                    request2.ContentType = "application/x-www-form-urlencoded"
                    request2.ContentLength = infodata2.Length

                    Using streamtype As Stream = request2.GetRequestStream()
                        streamtype.Write(infodata2, 0, infodata2.Length)
                        streamtype.Close()
                    End Using
                    Dim response2 = request2.GetResponse()
                    responseString2 = New StreamReader(response2.GetResponseStream()).ReadToEnd()
                    response2.Close()

                End If


                TB_memo.Text = "Mesin 1 : " & responseString & " Mesin 2 : " & responseString2
                'Dim json As String = TB_memo.Text
                'Dim ser As JObject = JObject.Parse(json)
                'Dim jdata As List(Of JToken) = ser.Children().ToList

                'Dim o As JObject = JObject.Parse(responseString)
                'Dim o2 As JObject = JObject.Parse(responseString2)
                'Dim Rst As Boolean = o.Item("Result")
                'Dim Rst2 As Boolean = o2.Item("Result")
                'If (Rst = True) Then
                'Dim devinfo As JObject = o.Item("DEVINFO")
                'TV_deviceInfo.Nodes.Add("DEVINFO")
                'For Each item In o
                'For Each item2 As JProperty In item.Value
                'TV_deviceInfo.Nodes(0).Nodes.Add(item2.Name & " : " & item2.Value.ToString)
                'Next
                'Next
                'TV_deviceInfo.ExpandAll()
                'ElseIf (Rst2 = True) Then
                'Dim devinfo As JObject = o2.Item("DEVINFO")
                'TV_deviceInfo.Nodes.Add("DEVINFO")
                'For Each item In o2
                'For Each item2 As JProperty In item.Value
                'TV_deviceInfo.Nodes(0).Nodes.Add(item2.Name & " : " & item2.Value.ToString)
                'Next
                'Next
                'TV_deviceInfo.ExpandAll()
                'Else
                'MsgBox("failed")

            Catch Ex As Exception
                MsgBox("gagal menghubungkan mesin " & Ex.Message)
            Finally
                Cursor.Current = Cursors.WaitCursor
            End Try
        End If

    End Sub

    Private Sub B_getAllScanlog_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_getAllScanlog.Click
        TB_memo.Clear()
        Dim iGLCount%
        Try
            Dim jsn, jscandate, jpin, jverifyMode, jIOMode, WorkCode As String
            Dim jsn2, jscandate2, jpin2, jverifyMode2, jIOMode2, WorkCode2 As String
            Dim limit_paging As Integer
            Dim jalan = False
            Dim status_er = False
            Dim data As New Specialized.NameValueCollection
            Dim location = System.Reflection.Assembly.GetExecutingAssembly().Location
            Dim appPath = Path.GetDirectoryName(location)
            'data.Add("sn", TB_deviceSN.Text)
            If (edt_limit_scanlog.Text <> "Limit paging") And (edt_limit_scanlog.Text <> "") Then
                'data.Add("limit", edt_limit_scanlog.Text)
                If (edt_limit_scanlog.Text > 100) Then
                    MessageBox.Show("Max paging 100.")
                    jalan = False
                    edt_limit_scanlog.Text = "100"
                Else
                    limit_paging = CInt(edt_limit_scanlog.Text)
                    jalan = True
                End If
            Else
                limit_paging = 100
                jalan = True
            End If
            If (jalan) Then
                Dim LogText As String = ""
                Dim isSession As Boolean = True
                Dim isSession2 As Boolean = True
                ' delete record 
                'Call koneksiDB()
                'sql = "delete * from [scanlog]"
                'CMD = New OleDbCommand(sql, DB)
                'CMD.ExecuteNonQuery()
                'DB.Close()
                If Check_1.Checked = True Then
                    While isSession
                        Cursor.Current = Cursors.WaitCursor
                        TB_memo.Text = "Harap tunggu, sedang download data dari mesin 1 "

                        Dim param = "sn=" + TB_deviceSN.Text + "&limit=" + limit_paging.ToString()
                        Dim request = HttpWebRequest.Create("http://" + TB_serverIP.Text + ":" + TB_serverPort.Text + "/scanlog/all/paging")

                        Dim rdata = Encoding.ASCII.GetBytes(param)
                        request.Timeout = ((1000 * 60) * 60) * 48
                        request.Method = "POST"
                        request.ContentType = "application/x-www-form-urlencoded"
                        request.ContentLength = rdata.Length

                        Using StreamType As Stream = request.GetRequestStream()
                            StreamType.Write(rdata, 0, rdata.Length)
                            StreamType.Close()
                        End Using

                        Dim response = request.GetResponse()
                        Dim responseString = New StreamReader(response.GetResponseStream()).ReadToEnd
                        response.Close()

                        Dim note_data As JObject = JsonConvert.DeserializeObject(responseString)
                        Dim note_b As Boolean = note_data("IsSession")
                        Dim note_r As Boolean = note_data("Result")

                        If note_r Then
                            For Each comment In note_data.Item("Data").ToList()
                                jsn = comment("SN")
                                jscandate = comment("ScanDate")
                                jpin = comment("PIN")
                                jverifyMode = comment("VerifyMode")
                                jIOMode = comment("IOMode")
                                WorkCode = comment("WorkCode")
                                clear_command()
                                openDB()
                                
                                sql = "INSERT INTO tbl_rawabsen(nik,tanggal) VALUES ('" & jpin & "','" & jscandate & "')"
                                sqlcmd = New SqlCommand(sql, Conn)
                                sqlcmd.ExecuteNonQuery()
                                Conn.Close()
                                iGLCount += 1
                                With DGV_scanlog
                                    .Rows.Add(1)
                                    .Rows(.RowCount - 2).Cells(0).Value = iGLCount.ToString
                                    .Rows(.RowCount - 2).Cells(1).Value = jsn
                                    .Rows(.RowCount - 2).Cells(2).Value = jscandate
                                    .Rows(.RowCount - 2).Cells(3).Value = jpin
                                    .Rows(.RowCount - 2).Cells(4).Value = jverifyMode
                                    .Rows(.RowCount - 2).Cells(5).Value = jIOMode
                                    .Rows(.RowCount - 2).Cells(6).Value = WorkCode
                                End With
                            Next
                            status_er = True
                        Else
                            TB_memo.Text = "Data Scanlog tidak ada pada Mesin 1."
                            status_er = False
                            Exit While
                        End If

                        LogText += responseString
                        isSession = note_b
                        TB_memo.Clear()
                    End While
                    Cursor.Current = Cursors.Arrow
                    'TB_memo.Text = LogText
                    If (status_er) Then
                        TB_memo.Text = "Download all user pagination finished. JSON text was saved to this path " + appPath + "\json_scanlog.txt "
                        'menyimpan data json ke file text
                        Dim FILE_NAME As String = appPath + "\json_scanlog.txt"
                        If System.IO.File.Exists(FILE_NAME) = False Then
                            System.IO.File.Create(FILE_NAME).Dispose()
                        End If
                        Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
                        objWriter.WriteLine(LogText)
                        objWriter.Close()
                    End If
                End If
                If Check_2.Checked = True Then
                    While isSession2
                        Cursor.Current = Cursors.WaitCursor
                        TB_memo.Text = TB_memo.Text & vbCrLf & " Harap tunggu, sedang download data dari mesin 2 "

                        Dim param2 = "sn=" + TB_deviceSN2.Text + "&limit=" + limit_paging.ToString()
                        Dim request2 = HttpWebRequest.Create("http://" + TB_serverIP2.Text + ":" + TB_serverPort2.Text + "/scanlog/all/paging")

                        Dim rdata2 = Encoding.ASCII.GetBytes(param2)
                        request2.Timeout = ((1000 * 60) * 60) * 48
                        request2.Method = "POST"
                        request2.ContentType = "application/x-www-form-urlencoded"
                        request2.ContentLength = rdata2.Length

                        Using StreamType2 As Stream = request2.GetRequestStream()
                            StreamType2.Write(rdata2, 0, rdata2.Length)
                            StreamType2.Close()
                        End Using

                        Dim response2 = request2.GetResponse()
                        Dim responseString2 = New StreamReader(response2.GetResponseStream()).ReadToEnd
                        response2.Close()

                        Dim note_data2 As JObject = JsonConvert.DeserializeObject(responseString2)
                        Dim note_b2 As Boolean = note_data2("IsSession")
                        Dim note_r2 As Boolean = note_data2("Result")

                        If note_r2 Then
                            For Each comment In note_data2.Item("Data").ToList()
                                jsn2 = comment("SN")
                                jscandate2 = comment("ScanDate")
                                jpin2 = comment("PIN")
                                jverifyMode2 = comment("VerifyMode")
                                jIOMode2 = comment("IOMode")
                                WorkCode2 = comment("WorkCode")
                                Call clear_command()
                                Call openDB()
                                sql = "INSERT INTO tbl_rawabsen(nik,tanggal) VALUES ('" & jpin2 & "','" & jscandate2 & "')"
                                sqlcmd = New SqlCommand(sql, Conn)
                                sqlcmd.ExecuteNonQuery()
                                Conn.Close()
                                iGLCount += 1
                                With DGV_scanlog
                                    .Rows.Add(1)
                                    .Rows(.RowCount - 2).Cells(0).Value = iGLCount.ToString
                                    .Rows(.RowCount - 2).Cells(1).Value = jsn2
                                    .Rows(.RowCount - 2).Cells(2).Value = jscandate2
                                    .Rows(.RowCount - 2).Cells(3).Value = jpin2
                                    .Rows(.RowCount - 2).Cells(4).Value = jverifyMode2
                                    .Rows(.RowCount - 2).Cells(5).Value = jIOMode2
                                    .Rows(.RowCount - 2).Cells(6).Value = WorkCode2
                                End With
                            Next
                            status_er = True
                        Else
                            TB_memo.Text = TB_memo.Text & vbCrLf & "Data Scanlog tidak ada pada Mesin 2."
                            status_er = False
                            Exit While
                        End If

                        LogText += responseString2
                        isSession2 = note_b2
                        TB_memo.Clear()
                    End While
                    Cursor.Current = Cursors.Arrow
                    'TB_memo.Text = LogText

                    If (status_er) Then
                        TB_memo.Text = "Download Mesin 2all user pagination finished . JSON text was saved to this path " + appPath + "\json_scanlog.txt "
                        'menyimpan data json ke file text
                        Dim FILE_NAME2 As String = appPath + "\json_scanlog.txt"
                        If System.IO.File.Exists(FILE_NAME2) = False Then
                            System.IO.File.Create(FILE_NAME2).Dispose()
                        End If
                        Dim objWriter2 As New System.IO.StreamWriter(FILE_NAME2, True)
                        objWriter2.WriteLine(LogText)
                        objWriter2.Close()
                    End If
                End If
            End If
        Catch ex As Exception
            TB_memo.Text = ex.ToString()
        End Try
    End Sub

    Private Sub btn_start_jadwal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_start_jadwal.Click

    End Sub

    Private Sub edt_limit_scanlog_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edt_limit_scanlog.TextChanged

    End Sub

    Private Sub B_syncDateTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_syncDateTime.Click
        If Check_1.Checked Then
            TB_memo.Clear()
            Dim data As New Specialized.NameValueCollection
            data.Add("sn", TB_deviceSN.Text)
            Dim result_post = SendRequest("http://" + TB_serverIP.Text + ":" + TB_serverPort.Text + "/dev/settime", data, "POST")
            TB_memo.Text = "Sync Date and Time Mesin 1 Success ! " + vbNewLine + result_post
        End If
        If Check_2.Checked Then
            TB_memo.Clear()
            Dim data2 As New Specialized.NameValueCollection
            data2.Add("sn", TB_deviceSN2.Text)
            Dim result_post = SendRequest("http://" + TB_serverIP2.Text + ":" + TB_serverPort2.Text + "/dev/settime", data2, "POST")
            TB_memo.Text = "Sync Date and Time Mesin 2 Success ! " + vbNewLine + result_post
        End If
    End Sub

    Private Sub B_delAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub B_initialization_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class