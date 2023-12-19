Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Globalization
Public Class FormConnectFinger

    'Create Standalone SDK class dynamicly.
    Public axCZKEM1 As New zkemkeeper.CZKEM
    Public axCZKEM2 As New zkemkeeper.CZKEM

#Region "Communication"
    '****************************************************************************************************
    '* Before you refer to this demo,we strongly suggest you read the development manual deeply first.  *
    '* This part is for demonstrating the communication with your device.                               *
    '* **************************************************************************************************
    Private bIsConnected = False 'the boolean value identifies whether the device is connected
    Private bIsConnected2 = False
    Private iMachineNumber As Integer 'the serial number of the device.After connecting the device ,this value will be changed.
    Private iMachineNumber2 As Integer

    'If your device supports the TCP/IP communications, you can refer to this.
    'when you are using the tcp/ip communication,you can distinguish different devices by their IP address.

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Try
            If txtIP.Text.Trim() = "" Or txtPort.Text.Trim() = "" Then
                MsgBox("IP and Port cannot be null", MsgBoxStyle.Exclamation, "Error")
                Return
            End If
            Dim idwErrorCode As Integer
            Cursor = Cursors.WaitCursor
            If btnConnect.Text = "Disconnect" Then
                axCZKEM1.Disconnect()
                bIsConnected = False
                btnConnect.Text = "Connect"
                lblState.ForeColor = Color.Red
                lblState.Text = "Current State:Disconnected"
                Cursor = Cursors.Default
                Return
            End If

            bIsConnected = axCZKEM1.Connect_Net(txtIP.Text.Trim(), Convert.ToInt32(txtPort.Text.Trim()))
            If bIsConnected = True Then
                btnConnect.Text = "Disconnect"
                btnConnect.Refresh()
                lblState.ForeColor = Color.Green
                lblState.Text = "Current State:Connected"
                iMachineNumber = 1 'In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
                axCZKEM1.RegEvent(iMachineNumber, 65535) 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            Else
                axCZKEM1.GetLastError(idwErrorCode)
                MsgBox("Unable to connect the device,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
            End If
            Cursor = Cursors.Default
        Catch Ex As Exception
            MsgBox("Unable to connect the device,ErrorCode= " & Ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Private Sub btnconnect2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnconnect2.Click
        If Textip2.Text.Trim() = "" Or Textport2.Text.Trim() = "" Then
            MsgBox("IP dan Port tidak boleh kosong", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer
        Cursor = Cursors.WaitCursor
        If btnconnect2.Text = "Disconnect" Then
            axCZKEM2.Disconnect()
            bIsConnected2 = False
            btnconnect2.Text = "Connect"
            lblState2.ForeColor = Color.Red
            lblState2.Text = "Current State:Disconnected"
            Cursor = Cursors.Default
            Return
        End If

        bIsConnected2 = axCZKEM2.Connect_Net(Textip2.Text.Trim(), Convert.ToInt32(Textport2.Text.Trim()))
        If bIsConnected2 = True Then
            btnconnect2.Text = "Disconnect"
            lblState2.ForeColor = Color.Green
            btnconnect2.Refresh()
            lblState2.Text = "Current State:Connected"
            iMachineNumber = 2 'In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
            axCZKEM2.RegEvent(iMachineNumber2, 65535) 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
        Else
            axCZKEM2.GetLastError(idwErrorCode)
            MsgBox("Unable to connect the device,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub

    'If your device supports the SerialPort communications, you can refer to this.
    Private Sub btnRsConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRsConnect.Click
        If cbPort.Text.Trim() = "" Or cbBaudRate.Text.Trim() = "" Or txtMachineSN.Text.Trim() = "" Then
            MsgBox("Port,BaudRate and MachineSN cannot be null", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        'accept serialport number from string like "COMi"
        Dim iPort As Integer
        'Dim sPort = cbPort.Text.Trim()
        Dim sPort As String = cbPort.Text.Trim()
        For iPort = 1 To 9
            If sPort.IndexOf(iPort.ToString()) > -1 Then
                Exit For
            End If
        Next

        Cursor = Cursors.WaitCursor
        If btnRsConnect.Text = "Disconnect" Then
            axCZKEM1.Disconnect()
            bIsConnected = False
            btnRsConnect.Text = "Connect"
            lblState.ForeColor = Color.Red
            lblState.Text = "Current State:Disconnected"
            Cursor = Cursors.Default
            Return
        End If

        iMachineNumber = Convert.ToInt32(txtMachineSN.Text.Trim()) '//when you are using the serial port communication,you can distinguish different devices by their serial port number.
        bIsConnected = axCZKEM1.Connect_Com(iPort, iMachineNumber, Convert.ToInt32(cbBaudRate.Text.Trim()))

        If bIsConnected = True Then
            btnRsConnect.Text = "Disconnect"
            btnRsConnect.Refresh()
            lblState.ForeColor = Color.Green
            lblState.Text = "Current State:Connected"
            axCZKEM1.RegEvent(iMachineNumber, 65535) 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Unable to connect the device,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
#End Region

#Region "AttLogs"
    ' **************************************************************************************************
    ' * Before you refer to this demo,we strongly suggest you read the development manual deeply first.*
    ' * This part is for demonstrating operations with(read/get/clear) the attendance records.         *
    ' * ************************************************************************************************
    'Download the attendance records from the device.
    



    'Get the count of attendance records in from ternimal.
    Private Sub btnGetDeviceStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer
        Dim iValue = 0

        axCZKEM1.EnableDevice(iMachineNumber, False) 'disable the device
        If axCZKEM1.GetDeviceStatus(iMachineNumber, 6, iValue) = True Then 'Here we use the function "GetDeviceStatus" to get the record's count.The parameter "Status" is 6.
            MsgBox("The count of the AttLogs in the device is " + iValue.ToString(), MsgBoxStyle.Information, "Success")
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        End If

        axCZKEM1.EnableDevice(iMachineNumber, True) 'enable the device
    End Sub
    'Clear all attendance records from terminal.
    Private Sub btnClearGLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        'lvLogs.Items.Clear()
        axCZKEM1.EnableDevice(iMachineNumber, False) 'disable the device
        If axCZKEM1.ClearGLog(iMachineNumber) = True Then
            axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("All att Logs have been cleared from teiminal!", MsgBoxStyle.Information, "Success")
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        End If

        axCZKEM1.EnableDevice(iMachineNumber, True) 'enable the device
    End Sub
#End Region

    Private Sub FormConnectFinger_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New CultureInfo("EN-US")
        atur_grid()
    End Sub

    Private Sub atur_grid()
        With grid_tampilan
            .Enabled = True
            .ColumnCount = 3
            .Columns(0).HeaderText = "No"
            .Columns(0).Width = 50
            .Columns(1).HeaderText = "NIK"
            .Columns(1).Width = 75
            .Columns(2).HeaderText = "waktu"
            .Columns(2).Width = 200
        End With
    End Sub

    Private Sub Button_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_simpan.Click
        simpan_data()
    End Sub

    Private Sub simpan_data()
        Try
            clear_command()
            openDB()
            For A% = 0 To grid_tampilan.RowCount - 2
                sql = "INSERT INTO tbl_rawabsen( nik, tanggal) VALUES(@nik, @tanggal)"
                sqlcmd = New SqlCommand(sql, Conn)
                With sqlcmd.Parameters
                    .Add("@nik", SqlDbType.VarChar).Value = grid_tampilan.Rows(A).Cells(1).Value
                    .Add("@tanggal", SqlDbType.DateTime2).Value = grid_tampilan.Rows(A).Cells(2).Value
                End With
                sqlcmd.ExecuteNonQuery()
            Next
            MsgBox("penyimpanan sukses")
        Catch ex As Exception
            MsgBox("gagal dalam penyimpanan data " & ex.Message, MsgBoxStyle.Information, "INFO")
        End Try
    End Sub

    Private Sub Button_download_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_download.Click
        If bIsConnected = False And bIsConnected2 = False Then
            MsgBox("Mesin tidak terhubung, silahkan hubungkan terlebih dahulu", MsgBoxStyle.Exclamation, "Error")
            Return
        End If

        Dim sdwEnrollNumber As String = ""
        Dim idwVerifyMode As Integer
        Dim idwInOutMode As Integer
        Dim idwYear As Integer
        Dim idwMonth As Integer
        Dim idwDay As Integer
        Dim idwHour As Integer
        Dim idwMinute As Integer
        Dim idwSecond As Integer
        Dim idwWorkcode As Integer

        Dim idwErrorCode As Integer
        Dim iGLCount = 0
        Dim baris As Integer = 0



        Cursor = Cursors.WaitCursor
        grid_tampilan.Rows.Clear()

        axCZKEM1.EnableDevice(iMachineNumber, False) 'disable the device
        axCZKEM2.EnableDevice(iMachineNumber2, False) 'disable the device
        If axCZKEM1.ReadGeneralLogData(iMachineNumber) Or axCZKEM2.ReadGeneralLogData(iMachineNumber2) Then 'read all the attendance records to the memory
            'get records from the memory
            While axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, sdwEnrollNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond, idwWorkcode)
                'isi gridview
                With grid_tampilan
                    iGLCount += 1
                    .Rows.Add(1)
                    .Rows(.RowCount - 2).Cells(0).Value = iGLCount.ToString()
                    .Rows(.RowCount - 2).Cells(1).Value = sdwEnrollNumber
                    .Rows(.RowCount - 2).Cells(2).Value = idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString() & " " & idwHour.ToString() & ":" & idwMinute.ToString() & ":" & idwSecond.ToString()
                End With
            End While
            While axCZKEM2.SSR_GetGeneralLogData(iMachineNumber, sdwEnrollNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond, idwWorkcode)
                'isi gridview
                With grid_tampilan
                    iGLCount += 1
                    .Rows.Add(1)
                    .Rows(.RowCount - 2).Cells(0).Value = iGLCount.ToString()
                    .Rows(.RowCount - 2).Cells(1).Value = sdwEnrollNumber
                    .Rows(.RowCount - 2).Cells(2).Value = idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString() & " " & idwHour.ToString() & ":" & idwMinute.ToString() & ":" & idwSecond.ToString()
                End With
            End While
        Else
            Cursor = Cursors.Default
            axCZKEM1.GetLastError(idwErrorCode)
            axCZKEM2.GetLastError(idwErrorCode)
            If idwErrorCode <> 0 Then
                MsgBox("Reading data from terminal failed,ErrorCode: " & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
            Else
                MsgBox("No data from terminal returns!", MsgBoxStyle.Exclamation, "Error")
            End If
        End If

        axCZKEM1.EnableDevice(iMachineNumber, True)
        axCZKEM2.EnableDevice(iMachineNumber2, True) 'enable the device
        Cursor = Cursors.Default
    End Sub
End Class