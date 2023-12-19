<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConnectDevices
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Combo_mesin = New System.Windows.Forms.ComboBox()
        Me.Text_msn = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.L_serverIP = New System.Windows.Forms.Label()
        Me.text_serverip = New System.Windows.Forms.TextBox()
        Me.L_deviceSN = New System.Windows.Forms.Label()
        Me.L_serverPort = New System.Windows.Forms.Label()
        Me.text_serverport = New System.Windows.Forms.TextBox()
        Me.text_deviceSN = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.button_add = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button_defl = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Merk Mesin"
        '
        'Combo_mesin
        '
        Me.Combo_mesin.FormattingEnabled = True
        Me.Combo_mesin.Location = New System.Drawing.Point(112, 55)
        Me.Combo_mesin.Name = "Combo_mesin"
        Me.Combo_mesin.Size = New System.Drawing.Size(176, 21)
        Me.Combo_mesin.TabIndex = 1
        '
        'Text_msn
        '
        Me.Text_msn.Location = New System.Drawing.Point(112, 93)
        Me.Text_msn.Name = "Text_msn"
        Me.Text_msn.Size = New System.Drawing.Size(48, 20)
        Me.Text_msn.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(45, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "No Mesin"
        '
        'L_serverIP
        '
        Me.L_serverIP.AutoSize = True
        Me.L_serverIP.Location = New System.Drawing.Point(45, 122)
        Me.L_serverIP.Name = "L_serverIP"
        Me.L_serverIP.Size = New System.Drawing.Size(51, 13)
        Me.L_serverIP.TabIndex = 6
        Me.L_serverIP.Text = "Server IP"
        '
        'text_serverip
        '
        Me.text_serverip.Location = New System.Drawing.Point(112, 119)
        Me.text_serverip.Name = "text_serverip"
        Me.text_serverip.Size = New System.Drawing.Size(110, 20)
        Me.text_serverip.TabIndex = 7
        '
        'L_deviceSN
        '
        Me.L_deviceSN.AutoSize = True
        Me.L_deviceSN.Location = New System.Drawing.Point(45, 173)
        Me.L_deviceSN.Name = "L_deviceSN"
        Me.L_deviceSN.Size = New System.Drawing.Size(59, 13)
        Me.L_deviceSN.TabIndex = 8
        Me.L_deviceSN.Text = "Device SN"
        '
        'L_serverPort
        '
        Me.L_serverPort.AutoSize = True
        Me.L_serverPort.Location = New System.Drawing.Point(45, 149)
        Me.L_serverPort.Name = "L_serverPort"
        Me.L_serverPort.Size = New System.Drawing.Size(60, 13)
        Me.L_serverPort.TabIndex = 10
        Me.L_serverPort.Text = "Server Port"
        '
        'text_serverport
        '
        Me.text_serverport.Location = New System.Drawing.Point(114, 145)
        Me.text_serverport.Name = "text_serverport"
        Me.text_serverport.Size = New System.Drawing.Size(61, 20)
        Me.text_serverport.TabIndex = 9
        '
        'text_deviceSN
        '
        Me.text_deviceSN.Location = New System.Drawing.Point(114, 170)
        Me.text_deviceSN.Name = "text_deviceSN"
        Me.text_deviceSN.Size = New System.Drawing.Size(234, 20)
        Me.text_deviceSN.TabIndex = 11
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(48, 246)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(542, 150)
        Me.DataGridView1.TabIndex = 14
        '
        'button_add
        '
        Me.button_add.Location = New System.Drawing.Point(48, 207)
        Me.button_add.Name = "button_add"
        Me.button_add.Size = New System.Drawing.Size(75, 23)
        Me.button_add.TabIndex = 15
        Me.button_add.Text = "Button1"
        Me.button_add.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(515, 217)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button_defl
        '
        Me.Button_defl.Location = New System.Drawing.Point(294, 53)
        Me.Button_defl.Name = "Button_defl"
        Me.Button_defl.Size = New System.Drawing.Size(75, 23)
        Me.Button_defl.TabIndex = 17
        Me.Button_defl.Text = "Button1"
        Me.Button_defl.UseVisualStyleBackColor = True
        '
        'FormConnectDevices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1131, 750)
        Me.Controls.Add(Me.Button_defl)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.button_add)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Text_msn)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.L_serverIP)
        Me.Controls.Add(Me.text_serverip)
        Me.Controls.Add(Me.L_deviceSN)
        Me.Controls.Add(Me.L_serverPort)
        Me.Controls.Add(Me.text_serverport)
        Me.Controls.Add(Me.text_deviceSN)
        Me.Controls.Add(Me.Combo_mesin)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormConnectDevices"
        Me.Text = "FormConnectDevices"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Combo_mesin As System.Windows.Forms.ComboBox
    Friend WithEvents Text_msn As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents L_serverIP As System.Windows.Forms.Label
    Friend WithEvents text_serverip As System.Windows.Forms.TextBox
    Friend WithEvents L_deviceSN As System.Windows.Forms.Label
    Friend WithEvents L_serverPort As System.Windows.Forms.Label
    Friend WithEvents text_serverport As System.Windows.Forms.TextBox
    Friend WithEvents text_deviceSN As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents button_add As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button_defl As System.Windows.Forms.Button
End Class
