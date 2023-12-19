Imports System.Globalization
Public Class FormConnectDevices

    Private Sub FormConnectDevices_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Application.CurrentCulture = New CultureInfo("EN-US")
        load_mesin()
    End Sub

    Private Sub load_mesin()
        With Combo_mesin
            .Items.Add("fingerspot")
            .Items.Add("solution")
        End With
    End Sub


    Private Sub button_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button_add.Click
        Try
            Dim FilePath As String = Application.StartupPath & "\setting.ini"
            writeini(FilePath, Combo_mesin.Text & Text_msn.Text, "nomesin", Text_msn.Text)
            writeini(FilePath, Combo_mesin.Text & Text_msn.Text, "serverIP", text_serverip.Text)
            writeini(FilePath, Combo_mesin.Text & Text_msn.Text, "serverport", text_serverport.Text)
            writeini(FilePath, Combo_mesin.Text & Text_msn.Text, "devicesn", text_deviceSN.Text)

        Catch Ex As Exception
            MsgBox("Gagal dalam menyimpan " & Ex.Message)
        Finally
            MsgBox("penyimpanan sukses")
            hapus()
        End Try
    End Sub

    Private Sub hapus()
        Clear_text(Me, Nothing)
        Clear_combo(Me, Nothing)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim FilePath As String = Application.StartupPath & "\setting.ini"
        Dim nomsn As String = readini(FilePath, "fingerspot2", "nomesin", "")
        Dim serverip As String = readini(FilePath, "fingerspot2", "serverip", "")
        Dim serverport As String = readini(FilePath, "fingerspot2", "serverport", "")
        Dim devicesn As String = readini(FilePath, "fingerspot2", "devicesn", "")
        MsgBox("No mesin : " & nomsn & ", ServerIP : " & serverip & ", serverPort : " & serverport & ", devicesn : " & devicesn)
    End Sub

    Private Sub Button_defl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_defl.Click
        If Combo_mesin.Text = String.Empty Then
            MsgBox("Mohon pilih merk mesin scan yang digunakan")
        Else
            Try
                Dim FilePath As String = Application.StartupPath & "\setting.ini"
                writeini(FilePath, "default", "mesin", Combo_mesin.Text)
            Catch ex As Exception
                MsgBox("gagal dalam pemilihan " & ex.Message)
            Finally
                MsgBox("sukses " & Combo_mesin.Text & " sebagai default mesin")
            End Try
        End If

    End Sub
End Class