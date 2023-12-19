Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Data.OleDb
Imports System.Net
Imports System
Imports System.IO
Imports System.Text

Public Class FormSettingFingerSpot
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
    Dim SQL As String
    Dim SQL1 As String
    Dim rowcount, userrowcount As Integer
    Dim ServerPort_, serverIP_, DeviceSN_ As String


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

    Public Sub koneksiDB()
        Dim lokasiDB As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=db.mdb;"
        DB = New OleDbConnection(lokasiDB)
        If DB.State = ConnectionState.Closed Then
            DB.Open()
        End If
    End Sub

    Public Sub CompactDB()
        Dim location = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim appPath = Path.GetDirectoryName(location)
        DB.Close()
        'Dim lokasiDB As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=db.mdb;"
        'Dim LockedDbFileInfo As New System.IO.FileInfo(lokasiDB.Replace(".mdb", ".ldb"))
        'If LockedDbFileInfo.Exists Then
        '   Warn user that the db is in use.
        Dim JRO As JRO.JetEngine
        JRO = New JRO.JetEngine()
        JRO.CompactDatabase("Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source= " & appPath & "\" & "db.mdb",
                    "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source= " & appPath & "\" & "db_temp.mdb;Jet OLEDB:Engine Type=5")
        Kill(appPath + "\" + "db.mdb")
        Rename(appPath + "\" + "db_temp.mdb", appPath + "\" + "db.mdb")
        'End If
    End Sub

    Private Sub B_getAllUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_getAllUser.Click
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
                Call koneksiDB()
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
                            Call koneksiDB()
                            SQL = "INSERT INTO [user] (pin, nama, pwd, rfid, privilege) VALUES ('" & jpin & "','" & jname.Replace("'", "''") & "','" & jpwd & "','" & jrfid & "','" & jpriv & "')"
                            CMD = New OleDbCommand(SQL, DB)
                            CMD.ExecuteNonQuery()
                            DB.Close()
                            Call SaveTemplate(jpin, comment)
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

    Private Sub SaveTemplate(ByVal pin As String, ByVal ser As JObject)
        Dim alg_ver As Integer
        Dim idx As Integer
        Dim template As String
        'Dim jdata As List(Of JToken) = ser.Children().ToList
        'Dim xdata As List(Of JToken) = ser.Item("Template").ToList
        'For Each item As JProperty In jdata
        'item.CreateReader()
        'Select Case item.Name
        'Case "Template"
        For Each comment In ser.Item("Template").ToList()
            alg_ver = comment("alg_ver")
            idx = comment("idx")
            template = comment("template")
            Call koneksiDB()
            SQL = "INSERT INTO [template] (pin, finger_idx, alg_ver, template) VALUES ('" & pin & "','" & idx.ToString & "','" & alg_ver.ToString & "','" & template.ToString() & "')"
            CMD = New OleDbCommand(SQL, DB)
            CMD.ExecuteNonQuery()
            DB.Close()
        Next
        '   End Select
        'Next
    End Sub

    Private Function GetTemplate(ByVal pin As String) As String
        Dim header As String
        Dim content As String
        Dim footer As String
        Dim alg_ver As Integer
        Dim idx As Integer
        Call koneksiDB()
        CMD = New OleDbCommand("SELECT * FROM [template] where pin = '" & pin & "'", DB)
        ARD = CMD.ExecuteReader
        header = "["
        footer = "]"
        content = ""
        While ARD.Read()
            alg_ver = ARD.GetInt32(2)
            idx = ARD.GetInt32(1)
            If (content <> "") Then
                content = content + ","
            End If
            content = content + "{" + """" + "pin" + """" + ":" + """" + ARD.GetString(0) + """" + "," + """" + "idx" + """" + ":" + """" + ARD.GetInt32(1).ToString + """" + "," + """" + "alg_ver" + """" + ":" + """" + ARD.GetInt32(2).ToString + """" + "," + """" + "template" + """" + ":" + """" + ARD.GetString(3).Replace("/", "%2F") + """" + "}"
        End While
        ARD.Close()
        Return (header + content + footer)
    End Function

    Private Function GetTemplateAll(ByVal pin As String) As String
        Dim header As String
        Dim content As String
        Dim footer As String
        Dim temp As String
        Dim alg_ver As Integer
        Dim idx As Integer
        Call koneksiDB()
        CMD1 = New OleDbCommand("SELECT * FROM [template] where pin = '" & pin & "'", DB)
        ARD1 = CMD1.ExecuteReader
        header = """Template"":["
        footer = "]"
        content = ""
        While ARD1.Read()
            alg_ver = ARD1.GetInt32(2)
            idx = ARD1.GetInt32(1)
            'temp = ARD1.GetString(3).Replace("/", "%2F")
            If (content <> "") Then
                content = content + ","
            End If
            content = content + "{" + """" + "pin" + """" + ":" + """" + ARD1.GetString(0) + """" + "," + """" + "idx" + """" + ":" + """" + ARD1.GetInt32(1).ToString + """" + "," + """" + "alg_ver" + """" + ":" + """" + ARD1.GetInt32(2).ToString + """" + "," + """" + "template" + """" + ":" + """" + (ARD1.GetString(3).Replace("/", "%2F")).Replace("+", "%2B") + """" + "}"
        End While
        ARD1.Close()
        DB.Close()
        Return (header + content + footer)
    End Function

    Private Function CreateUserJSON() As String
        Dim header As String
        Dim content As String
        Dim footer As String
        Call koneksiDB()
        CMD = New OleDbCommand("SELECT * FROM [user]", DB)
        ARD = CMD.ExecuteReader
        header = "{""Result"":true,""Data"":["
        footer = "]}"
        content = ""
        While ARD.Read()
            If (content <> "") Then
                content = content + ","
            End If
            content = content + "{" + """" + "PIN" + """" + ":" + """" + ARD.GetString(0) + """" +
                                "," + """" + "Name" + """" + ":" + """" + ARD.GetString(1) + """" +
                                "," + """" + "RFID" + """" + ":" + """" + ARD.GetString(3) + """" +
                                "," + """" + "Password" + """" + ":" + """" + ARD.GetString(2) + """" +
                                "," + """" + "Privilege" + """" + ":" + """" + ARD.GetInt32(4).ToString + """" +
                                "," + GetTemplateAll(ARD.GetString(0)) + "}"
            '"," + """" + "Template" + """" + ":" + """" + GetTemplate(ARD.GetString(0)) + """" + "}"

        End While
        ARD.Close()
        Return (header + content + footer)
    End Function

    Private Function CreateUserJSONEx(ByVal start_idx As Integer, ByVal limit_paging As Integer) As String
        Dim header, content, footer As String
        Call koneksiDB()
        'CMD = New OleDbCommand("SELECT * FROM [user]", DB)
        'ARD = CMD.ExecuteReader
        'ARD.Close()
        'CMD = New OleDbCommand("SELECT * FROM (SELECT *, (SELECT COUNT(us.pin) FROM [user] AS us WHERE us.pin <= usl.pin) AS rownumber " +
        '                       "FROM [user] as usl) " +
        '                     "WHERE rownumber BETWEEN '" + start_idx.ToString() + "' AND '" + Convert.ToString(start_idx + (limit_paging - 1)) + "' ", DB)
        CMD = New OleDbCommand("select * from (select *,(select count(us.pin) from [user] as us where us.pin <= usl.pin) as rownumber from [user] as usl) where rownumber between " + start_idx.ToString() + " and " + (start_idx + (limit_paging - 1)).ToString() + " ", DB)
        ARD = CMD.ExecuteReader
        header = "{""Result"":true,""Data"":["
        footer = "]}"
        content = ""
        While ARD.Read()
            If (content <> "") Then
                content = content + ","
            End If
            content = content + "{" + """" + "PIN" + """" + ":" + """" + ARD.GetString(1) + """" +
                                   "," + """" + "Name" + """" + ":" + """" + ARD.GetString(2) + """" +
                                  "," + """" + "RFID" + """" + ":" + """" + ARD.GetString(4) + """" +
                                 "," + """" + "Password" + """" + ":" + """" + ARD.GetString(3) + """" +
                                "," + """" + "Privilege" + """" + ":" + """" + ARD.GetInt32(5).ToString() + """" +
                                "," + GetTemplateAll(ARD.GetString(1)) + "}"


        End While
        ARD.Close()
        DB.Close()
        Return (header + content + footer)
    End Function

    Private Sub B_setUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_setUser.Click
        TB_memo.Clear()
        Dim pin As String
        Dim nama As String
        Dim pwd As String
        Dim privilege As Integer
        Dim template1 As String
        Dim rfid As String
        Try
            Call koneksiDB()
            If (TB_PIN_get.Text = "PIN") Or (TB_PIN_get.Text = "pin") Or (TB_PIN_get.Text = "") Then
                CMD = New OleDbCommand("Select * from [user]", DB)
                ADP = New OleDbDataAdapter("Select * from [user]", DB)
                ADP1 = New OleDbDataAdapter("Select * from [template]", DB)
            Else
                CMD = New OleDbCommand("Select * from [user] where pin='" & TB_PIN_get.Text & "'", DB)
                ADP = New OleDbDataAdapter("Select * from [user] where pin='" & TB_PIN_get.Text & "'", DB)
                ADP1 = New OleDbDataAdapter("Select * from [template] where pin='" & TB_PIN_get.Text & "'", DB)
            End If
            DS = New DataSet
            DS1 = New DataSet
            ADP.Fill(DS, "user")
            ADP1.Fill(DS1, "template")
            DGV_user.DataSource = DS.Tables("user")
            DGV_template.DataSource = DS1.Tables("template")
            ARD1 = CMD.ExecuteReader
            While (ARD1.Read())
                pin = ARD1.GetString(0)
                nama = ARD1.GetString(1)
                pwd = ARD1.GetString(2)
                If String.IsNullOrEmpty(ARD1.GetString(3)) Then
                    rfid = ""
                Else
                    rfid = ARD1.GetString(3)
                End If
                'If Not IsDBNull(ARD1.GetString(3)) Then
                'rfid = ""
                'Else
                'rfid = ARD1.GetString(3)
                'End If
                privilege = ARD1.GetInt32(4)
                template1 = (GetTemplate(ARD1.GetString(0))).Replace("+", "%2B")
                'Dim data As New Specialized.NameValueCollection
                'data.Add("sn", TB_deviceSN.Text)
                'data.Add("pin", pin)
                'data.Add("nama", nama)
                'data.Add("pwd", pwd)
                'data.Add("rfid", rfid)
                'data.Add("priv", privilege.ToString)
                'data.Add("tmp", template1)
                'Dim result_post = SendRequest("http://" + TB_serverIP.Text + ":" + TB_serverPort.Text + "/user/set", data, "POST")
                Dim param = "sn=" + TB_deviceSN.Text + "&pin=" + pin.Trim() + "&nama=" + nama.Trim() + "&pwd=" + pwd.Trim() + "&rfid=" + rfid.Trim() + "&priv=" + privilege.ToString.Trim() + "&tmp=" + template1.Trim()
                Dim final_url = "http://" + TB_serverIP.Text + ":" + TB_serverPort.Text + "/user/set"
                Dim request = WebRequest.Create(final_url)

                Dim postData = param
                Dim xdata = Encoding.ASCII.GetBytes(postData)
                request.Timeout = ((1000 * 60) * 60) * 48
                request.Method = "POST"
                request.ContentType = "application/x-www-form-urlencoded"
                request.ContentLength = xdata.Length

                Using StreamType As Stream = request.GetRequestStream()
                    StreamType.Write(xdata, 0, xdata.Length)
                    StreamType.Close()
                End Using

                Dim response = request.GetResponse()
                Dim responseString = New StreamReader(response.GetResponseStream()).ReadToEnd

                response.Close()
                TB_memo.Text = "Upload User Success ! " + vbNewLine + responseString
            End While
            ARD1.Close()
        Catch ex As Exception
            TB_memo.Text = ex.ToString()
        End Try
    End Sub

    Private Sub B_delAllUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_delAllUser.Click
        TB_memo.Clear()
        Dim data As New Specialized.NameValueCollection
        data.Add("sn", TB_deviceSN.Text)
        Dim result_post = SendRequest("http://" + TB_serverIP.Text + ":" + TB_serverPort.Text + "/user/delall", data, "POST")
        TB_memo.Text = "Delete All User Success ! " + vbNewLine + result_post
    End Sub

    Private Sub B_delUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_delUser.Click
        TB_memo.Clear()
        Dim data As New Specialized.NameValueCollection
        data.Add("sn", TB_deviceSN.Text)
        data.Add("pin", TB_PIN_del.Text)
        Dim result_post = SendRequest("http://" + TB_serverIP.Text + ":" + TB_serverPort.Text + "/user/del", data, "POST")
        TB_memo.Text = "Delete PIN " + TB_PIN_del.Text + " Success ! " + vbNewLine + result_post
    End Sub


    Private Sub B_getAllScanlog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_getAllScanlog.Click
        TB_memo.Clear()
        Try
            Dim jsn, jscandate, jpin, jverifyMode, jIOMode, WorkCode As String
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
                ' delete record 
                Call koneksiDB()
                SQL = "delete * from [scanlog]"
                CMD = New OleDbCommand(SQL, DB)
                CMD.ExecuteNonQuery()
                DB.Close()

                While isSession
                    Cursor.Current = Cursors.WaitCursor
                    TB_memo.Text = "Harap tunggu, sedang download data dari mesin."

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
                            Call koneksiDB()
                            SQL = "INSERT INTO [scanlog] (sn, scan_date, pin, verifymode, iomode, workcode) VALUES ('" & jsn & "','" & jscandate & "','" & jpin & "','" & jverifyMode & "','" & jIOMode & "','" & WorkCode & "')"
                            CMD = New OleDbCommand(SQL, DB)
                            CMD.ExecuteNonQuery()
                            DB.Close()
                        Next
                        status_er = True
                    Else
                        TB_memo.Text = "Data Scanlog tidak ada pada Mesin."
                        status_er = False
                        Exit While
                    End If

                    LogText += responseString
                    isSession = note_b
                    TB_memo.Clear()
                End While
                Cursor.Current = Cursors.Arrow
                'TB_memo.Text = LogText
                Call RefreshDataUser()

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
        Catch ex As Exception
            TB_memo.Text = ex.ToString()
        End Try
    End Sub

    Private Sub B_deviceInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_deviceInfo.Click
        Dim data As New Specialized.NameValueCollection
        Dim param, final_url, postData As String
        Dim request As System.Net.WebRequest
        Dim infodata As Byte()
        Dim responseString As Object



        If Check_1.Checked = False And Check_2.Checked = False Then
            MsgBox("Silahkan pilih mesin terlebih dahulu ", MsgBoxStyle.Information, "INFO")
        Else
            If Check_1.Checked = True Then
                ServerPort_ = TB_serverPort.Text
                serverIP_ = TB_serverIP.Text
                DeviceSN_ = TB_deviceSN.Text
            ElseIf Check_2.Checked = True Then
                ServerPort_ = TB_serverPort2.Text
                serverIP_ = TB_serverIP2.Text
                DeviceSN_ = TB_deviceSN2.Text
            End If
            TB_memo.Clear()
            TV_deviceInfo.Nodes.Clear()
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

            'TB_memo.Text = result_post
            TB_memo.Text = responseString
            Dim json As String = TB_memo.Text
            Dim ser As JObject = JObject.Parse(json)
            Dim jdata As List(Of JToken) = ser.Children().ToList
            'Dim o As JObject = JObject.Parse(result_post)
            Dim o As JObject = JObject.Parse(responseString)
            Dim Rst As Boolean = o.Item("Result")
            If (Rst = True) Then
                Dim devinfo As JObject = o.Item("DEVINFO")
                TV_deviceInfo.Nodes.Add("DEVINFO")
                For Each item In o
                    For Each item2 As JProperty In item.Value
                        TV_deviceInfo.Nodes(0).Nodes.Add(item2.Name & " : " & item2.Value.ToString)
                    Next
                Next
                TV_deviceInfo.ExpandAll()
            Else
                MsgBox("failed")
            End If
        End If
        

    End Sub

    Private Sub B_clearUserDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_clearUserDB.Click
        TB_memo.Clear()
        Call koneksiDB()
        SQL = "delete * from [user]"
        SQL1 = "delete * from [template]"
        CMD = New OleDbCommand(SQL, DB)
        CMD1 = New OleDbCommand(SQL1, DB)
        CMD.ExecuteNonQuery()
        CMD1.ExecuteNonQuery()
        DB.Close()
        Call RefreshDataUser()
        TB_memo.Text = "Delete All User in Database Success ! "
    End Sub

    Private Sub B_clearScanlogDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_clearScanlogDB.Click
        TB_memo.Clear()
        Call koneksiDB()
        SQL = "delete * from [scanlog]"
        CMD = New OleDbCommand(SQL, DB)
        CMD.ExecuteNonQuery()
        DB.Close()
        TB_memo.Text = "Delete All Scanlog in Database Success ! "
        Call RefreshDataUser()
    End Sub

    Private Sub B_getNewScanlog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_getNewScanlog.Click
        TB_memo.Clear()
        Call koneksiDB()
        Dim jsn As String
        Dim jscandate As String
        Dim jpin As String
        Dim jverifyMode As String
        Dim jIOMode As String
        Dim WorkCode As String
        Dim data As New Specialized.NameValueCollection
        data.Add("sn", TB_deviceSN.Text)
        Dim result_post = SendRequest("http://" + TB_serverIP.Text + ":" + TB_serverPort.Text + "/scanlog/new", data, "POST")
        TB_memo.Text = result_post
        Dim json As String = TB_memo.Text
        Dim ser As JObject = JObject.Parse(json)
        Dim jdata As List(Of JToken) = ser.Children().ToList
        Dim Rst As Boolean = ser.Item("Result")
        If (Rst = True) Then
            SQL = "delete * from [scanlog]"
            CMD = New OleDbCommand(SQL, DB)
            CMD.ExecuteNonQuery()
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
                            SQL = "INSERT INTO [scanlog] (sn, scan_date, pin, verifymode, iomode, workcode) VALUES ('" & jsn & "','" & jscandate & "','" & jpin & "','" & jverifyMode & "','" & jIOMode & "','" & WorkCode & "')"
                            CMD = New OleDbCommand(SQL, DB)
                            CMD.ExecuteNonQuery()
                        Next
                End Select
            Next
            DB.Close()
            TB_memo.Text = "Get New Scanlog Success ! " + vbNewLine + result_post
        Else
            TB_memo.Text = "New Scanlog : 0 " + vbNewLine + result_post
        End If
        Call RefreshDataUser()
    End Sub

    Private Sub B_deleteScanlog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_deleteScanlog.Click
        TB_memo.Clear()
        Dim data As New Specialized.NameValueCollection
        data.Add("sn", TB_deviceSN.Text)
        Dim result_post = SendRequest("http://" + TB_serverIP.Text + ":" + TB_serverPort.Text + "/scanlog/del", data, "POST")
        TB_memo.Text = "Delete All Scanlog Success ! " + vbNewLine + result_post
    End Sub

    Private Sub B_syncDateTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_syncDateTime.Click
        TB_memo.Clear()
        Dim data As New Specialized.NameValueCollection
        data.Add("sn", TB_deviceSN.Text)
        Dim result_post = SendRequest("http://" + TB_serverIP.Text + ":" + TB_serverPort.Text + "/dev/settime", data, "POST")
        TB_memo.Text = "Sync Date and Time Success ! " + vbNewLine + result_post
    End Sub

    Private Sub B_delAdmin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_delAdmin.Click
        TB_memo.Clear()
        Dim data As New Specialized.NameValueCollection
        data.Add("sn", TB_deviceSN.Text)
        Dim result_post = SendRequest("http://" + TB_serverIP.Text + ":" + TB_serverPort.Text + "/dev/deladmin", data, "POST")
        TB_memo.Text = "Delete Admin Success ! " + vbNewLine + result_post
        Call RefreshDataUser()
    End Sub

    Private Sub B_delDeviceLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_delDeviceLog.Click
        TB_memo.Clear()
        Dim data As New Specialized.NameValueCollection
        data.Add("sn", TB_deviceSN.Text)
        Dim result_post = SendRequest("http://" + TB_serverIP.Text + ":" + TB_serverPort.Text + "/log/del", data, "POST")
        TB_memo.Text = "Delete Device Log Success ! " + vbNewLine + result_post
    End Sub

    Private Sub B_initialization_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_initialization.Click
        TB_memo.Clear()
        Dim data As New Specialized.NameValueCollection
        data.Add("sn", TB_deviceSN.Text)
        Dim result_post = SendRequest("http://" + TB_serverIP.Text + ":" + TB_serverPort.Text + "/dev/init", data, "POST")
        TB_memo.Text = "Initialization Success ! " + vbNewLine + result_post
    End Sub

    Private Sub RefreshDataUser()
        Call koneksiDB()
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

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Call RefreshDataUser()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GetTemplate("1")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TB_memo.Text = """" + "pin :" + """"
    End Sub

    Private Sub DGV_user_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGV_user.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Call CType(DGV_template.DataSource, DataTable).Rows.Clear()
            Call koneksiDB()
            ADP3 = New OleDbDataAdapter("Select * from [template] where pin='" & DGV_user.Rows(e.RowIndex).Cells(0).Value & "'", DB)
            DS3 = New DataSet
            ADP3.Fill(DS3, "template")
            DGV_template.DataSource = DS3.Tables("template")
        End If
    End Sub

    'Private Sub B_selAllUser_Click(sender As Object, e As EventArgs) Handles B_selAllUser.Click
    '   TB_memo.Clear()
    'Dim data As New Specialized.NameValueCollection
    '   data.Add("sn", TB_deviceSN.Text)
    '  data.Add("data", CreateUserJSON)
    'Dim result_post = SendRequest("http://" + TB_serverIP.Text + ":" + TB_serverPort.Text + "/user/set-all", data, "POST")
    '   TB_memo.Text = "Set All User Success ! " + vbNewLine + result_post
    'End Sub

    Private Sub btn_set_user_paging_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_set_user_paging.Click
        TB_memo.Clear()
        'If (CInt(edt_limit_user_up.Text) > 100) Then
        'MessageBox.Show("Maaf, max paging sampai 100 data.")
        'edt_limit_user_up.Clear()
        'edt_limit_user_up.Text = "100"
        'Else
        Try

            Dim data As New Specialized.NameValueCollection
            Dim location = System.Reflection.Assembly.GetExecutingAssembly().Location
            Dim appPath = Path.GetDirectoryName(location)
            Dim last_idx, looptotal, i, limit_int, result, totalrow, divrow, modrow As Integer
            Dim result_post = ""
            Dim jalan = False

            Call koneksiDB()
            CMD = New OleDbCommand("select count(pin) from [user]", DB)
            result = CMD.ExecuteNonQuery()
            totalrow = CMD.ExecuteScalar()
            DB.Close()
            Dim TextData As String
            TextData = ""
            last_idx = 1
            If (edt_limit_user_up.Text <> "Limit paging") And (edt_limit_user_up.Text <> "") Then
                If (edt_limit_user_up.Text > 100) Then
                    MessageBox.Show("Max paging 100.")
                    edt_limit_user_up.Text = 100
                    jalan = False
                Else
                    limit_int = CInt(edt_limit_user_up.Text)
                    jalan = True
                End If
            Else
                limit_int = 100
                jalan = True
            End If

            If (totalrow > 0) Then
                divrow = totalrow \ limit_int
                modrow = totalrow Mod limit_int

                If divrow >= 0 Then
                    If modrow >= 0 Then
                        looptotal = Val(divrow) + 1
                    Else
                        looptotal = divrow
                    End If
                Else
                    looptotal = 0
                End If
            End If


            If (jalan) Then
                For i = 1 To looptotal
                    TB_memo.Text = "Harap Tunggu, sedang proses upload data ke mesin."
                    Dim param = "sn=" + TB_deviceSN.Text + "&data=" + CreateUserJSONEx(last_idx, limit_int)
                    Dim request = HttpWebRequest.Create("http://" + TB_serverIP.Text + ":" + TB_serverPort.Text + "/user/set-all")


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

                    Dim note_data As JObject = JsonConvert.DeserializeObject(responseString)
                    Dim note_r As Boolean = note_data("Result")

                    If note_r = False Then
                        TB_memo.Text = responseString
                        Exit For
                    End If

                    response.Close()
                    last_idx = Val(last_idx) + Val(limit_int)
                    TextData = TextData + responseString
                    TB_memo.Clear()
                Next

                If looptotal = 0 Then
                    TB_memo.Text = "Tidak ada data pada database."
                Else
                    TB_memo.Text = TextData
                End If

                'Call CompactDB()
                'End If
                Call RefreshDataUser()
            End If
        Catch ex As Exception
            TB_memo.Text = ex.ToString()
        End Try
    End Sub

    Private Declare Auto Function GetPrivateProfileString Lib "kernel32" (ByVal lpAppName As String,
            ByVal lpKeyName As String,
            ByVal lpDefault As String,
            ByVal lpReturnedString As StringBuilder,
            ByVal nSize As Integer,
            ByVal lpFileName As String) As Integer


    Private Sub btn_get_all_user_auto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_get_all_user_auto.Click
        TB_memo.Clear()
        Try
            Dim data As New Specialized.NameValueCollection
            Dim location = System.Reflection.Assembly.GetExecutingAssembly().Location
            Dim appPath = Path.GetDirectoryName(location)
            Dim iniFile = appPath + "\Device.ini"
            Dim res As Integer
            Dim sb As StringBuilder
            sb = New StringBuilder(500)
            'membaca file *.ini
            res = GetPrivateProfileString("Mesin", "sn", "", sb, sb.Capacity, iniFile)
            Dim count As Integer
            Dim sbArr() = sb.ToString().Split(";")
            Dim result_post = ""
            Dim LogText = ""
            Dim jpin, jname, jrfid, jpwd, jpriv, limit_paging As String
            Dim IsSess As Boolean = True
            Call koneksiDB()
            SQL = "delete * from [user]"
            SQL1 = "delete * from [template]"
            CMD = New OleDbCommand(SQL, DB)
            CMD1 = New OleDbCommand(SQL1, DB)
            CMD.ExecuteNonQuery()
            CMD1.ExecuteNonQuery()
            DB.Close()
            For count = 0 To sbArr.Length - 1
                TB_memo.Text = "Harap Tunggu, sedang proses download data dari mesin."

                Dim snum = sbArr(count)
                'data.Add("sn", snum)
                'pembatasan pembacaan data dari mesin max 100 baris
                If (edt_limit_user_auto.Text <> "Limit paging") And (edt_limit_user_auto.Text <> "") Then
                    'data.Add("limit", edt_limit_user_auto.Text)
                    limit_paging = CInt(edt_limit_user_auto.Text)
                Else
                    limit_paging = 100
                End If
                Dim param = "sn=" + snum + "&limit=" + limit_paging
                While IsSess
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

                    If note_r Then
                        For Each comment In note_data.Item("Data").ToList()
                            jpin = comment("PIN")
                            jname = comment("Name")
                            jrfid = comment("RFID")
                            jpwd = comment("Password")
                            jpriv = comment("Privilege")
                            Call koneksiDB()
                            SQL = "INSERT INTO [user] (pin, nama, pwd, rfid, privilege) VALUES ('" & jpin & "','" & jname.Replace("'", "''") & "','" & jpwd & "','" & jrfid & "','" & jpriv & "')"
                            CMD = New OleDbCommand(SQL, DB)
                            CMD.ExecuteNonQuery()
                            DB.Close()
                            Call SaveTemplate(jpin, comment)
                        Next
                    Else
                        TB_memo.Text = responseString
                        Exit While
                    End If

                    LogText += responseString
                    IsSess = note_b
                End While

                TB_memo.Clear()
                If count = (sbArr.Length - 1) Then
                    IsSess = False
                Else
                    IsSess = True
                End If
            Next

            Call RefreshDataUser()
            'Call CompactDB()
            TB_memo.Text = "Download all user pagination finished. JSON text was saved to this path " + appPath + "\json_user_alldevice.txt "
            'menyimpan data json ke file text
            Dim FILE_NAME As String = appPath + "\json_user_alldevice.txt"
            If System.IO.File.Exists(FILE_NAME) = False Then
                System.IO.File.Create(FILE_NAME).Dispose()
            End If
            Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
            objWriter.WriteLine(LogText)
            objWriter.Close()
        Catch ex As Exception
            TB_memo.Text = ex.ToString()
        End Try
    End Sub


    Private Sub btn_get_all_scan_auto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_get_all_scan_auto.Click
        TB_memo.Clear()
        Try
            Dim data As New Specialized.NameValueCollection
            Dim location = System.Reflection.Assembly.GetExecutingAssembly().Location
            Dim appPath = Path.GetDirectoryName(location)
            Dim iniFile = appPath + "\Device.ini"
            Dim res As Integer
            Dim sb As StringBuilder
            sb = New StringBuilder(500)
            'membaca file *.ini
            res = GetPrivateProfileString("Mesin", "sn", "", sb, sb.Capacity, iniFile)
            Dim sbArr() As String
            Dim count As Integer
            sbArr = sb.ToString().Split(";")
            Dim result_post = ""
            Dim Logtext = ""
            Dim jsn, jscandate, jpin, jverifyMode, jIOMode, WorkCode, limit_paging As String
            Dim IsSession As Boolean = True

            Call koneksiDB()
            SQL = "delete * from [scanlog]"
            CMD = New OleDbCommand(SQL, DB)
            CMD.ExecuteNonQuery()
            DB.Close()

            For count = 0 To sbArr.Length - 1
                TB_memo.Text = "Harap Tunggu, sedang proses download data dari mesin."
                Dim snum = sbArr(count)
                'data.Add("sn", snum)
                If (edt_limit_scanlog_auto.Text <> "Limit paging") And (edt_limit_scanlog_auto.Text <> "") Then
                    limit_paging = CInt(edt_limit_scanlog_auto.Text)
                    'data.Add("limit", edt_limit_scanlog_auto.Text)
                Else
                    limit_paging = 100
                End If

                While IsSession
                    Dim param = "sn=" + snum + "&limit=" + limit_paging
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
                            Call koneksiDB()
                            SQL = "INSERT INTO [scanlog] (sn, scan_date, pin, verifymode, iomode, workcode) VALUES ('" & jsn & "','" & jscandate & "','" & jpin & "','" & jverifyMode & "','" & jIOMode & "','" & WorkCode & "')"
                            CMD = New OleDbCommand(SQL, DB)
                            CMD.ExecuteNonQuery()
                            DB.Close()
                        Next
                    End If

                    Logtext += responseString
                    IsSession = note_b
                End While

                TB_memo.Clear()
                If count = (sbArr.Length - 1) Then
                    IsSession = False
                Else
                    IsSession = True
                End If
            Next

            Call RefreshDataUser()
            'Call CompactDB()
            TB_memo.Text = "Download all scanlog pagination finished. JSON text was saved to this path " + appPath + "\json_scanlog_alldevice.txt "
            'menyimpan data json ke file text
            Dim FILE_NAME As String = appPath + "\json_scanlog_alldevice.txt"
            If System.IO.File.Exists(FILE_NAME) = False Then
                System.IO.File.Create(FILE_NAME).Dispose()
            End If
            Dim objWriter As New System.IO.StreamWriter(FILE_NAME, True)
            objWriter.WriteLine(Logtext)
            objWriter.Close()
        Catch ex As Exception
            TB_memo.Text = ex.ToString()
        End Try
    End Sub

    Private Sub btn_start_jadwal_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_start_jadwal.Click
        TB_memo.Clear()
        If btn_start_jadwal.Tag = 0 Then
            btn_start_jadwal.Tag = 1
            btn_start_jadwal.Text = "Stop Download Scheduler"
            timer_jadwal.Start()
        Else
            btn_start_jadwal.Tag = 0
            btn_start_jadwal.Text = "Start Download Scheduler"
            timer_jadwal.Stop()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles timer_jadwal.Tick
        TB_memo.Clear()
        timer_jadwal.Stop()
        Dim data As New Specialized.NameValueCollection
        Dim location = System.Reflection.Assembly.GetExecutingAssembly().Location
        Dim appPath = Path.GetDirectoryName(location)
        Dim iniFile = appPath + "\Device.ini"
        Dim res As Integer
        Dim sb As StringBuilder
        sb = New StringBuilder(500)
        'membaca file *.ini
        res = GetPrivateProfileString("Jadwal", "jam", "", sb, sb.Capacity, iniFile)
        Dim sbArr() As String
        sbArr = sb.ToString().Split(";")
        Dim schedule_idx = -1
        Dim schedule_status As Boolean
        schedule_status = False
        For i = 0 To sbArr.Length - 1
            If TimeOfDay.ToString("hh:mm") = sbArr(i) Then
                If (i > schedule_idx) Then
                    schedule_status = True
                    schedule_idx = i
                Else
                    Stop
                End If
            End If
        Next
        If schedule_status Then
            btn_get_all_user_auto_Click(Nothing, EventArgs.Empty)
            btn_get_all_scan_auto_Click(Nothing, EventArgs.Empty)
        End If
        timer_jadwal.Start()
    End Sub

    Private Sub Check_1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_1.CheckedChanged
        If Check_1.Checked = True Then
            Check_2.Checked = False
            serverIP_ = TB_serverIP.Text
            ServerPort_ = TB_serverPort.Text
            DeviceSN_ = TB_deviceSN.Text
        End If
    End Sub

    Private Sub Check_2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_2.CheckedChanged
        If Check_2.Checked = True Then
            Check_1.Checked = False
            serverIP_ = TB_serverIP2.Text
            ServerPort_ = TB_serverPort2.Text
            DeviceSN_ = TB_deviceSN2.Text
        End If
    End Sub

    Private Sub edt_limit_scanlog_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edt_limit_scanlog.TextChanged

    End Sub

    Private Sub FormSettingFingerSpot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class