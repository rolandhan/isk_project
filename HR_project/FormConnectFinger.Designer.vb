<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConnectFinger
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
        Me.tabControl1 = New System.Windows.Forms.TabControl()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.btnconnect2 = New System.Windows.Forms.Button()
        Me.Textip2 = New System.Windows.Forms.TextBox()
        Me.lblState = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Textport2 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtIP = New System.Windows.Forms.TextBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.groupBox5 = New System.Windows.Forms.GroupBox()
        Me.cbBaudRate = New System.Windows.Forms.ComboBox()
        Me.label5 = New System.Windows.Forms.Label()
        Me.txtMachineSN = New System.Windows.Forms.TextBox()
        Me.cbPort = New System.Windows.Forms.ComboBox()
        Me.label7 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.btnRsConnect = New System.Windows.Forms.Button()
        Me.lblState2 = New System.Windows.Forms.Label()
        Me.grid_tampilan = New System.Windows.Forms.DataGridView()
        Me.Button_simpan = New System.Windows.Forms.Button()
        Me.Button_download = New System.Windows.Forms.Button()
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.groupBox5.SuspendLayout()
        CType(Me.grid_tampilan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Location = New System.Drawing.Point(12, 23)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(545, 102)
        Me.tabControl1.TabIndex = 8
        '
        'tabPage1
        '
        Me.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tabPage1.Controls.Add(Me.btnconnect2)
        Me.tabPage1.Controls.Add(Me.Textip2)
        Me.tabPage1.Controls.Add(Me.lblState)
        Me.tabPage1.Controls.Add(Me.Label4)
        Me.tabPage1.Controls.Add(Me.Textport2)
        Me.tabPage1.Controls.Add(Me.Label8)
        Me.tabPage1.Controls.Add(Me.txtIP)
        Me.tabPage1.Controls.Add(Me.label2)
        Me.tabPage1.Controls.Add(Me.btnConnect)
        Me.tabPage1.Controls.Add(Me.txtPort)
        Me.tabPage1.Controls.Add(Me.label1)
        Me.tabPage1.Cursor = System.Windows.Forms.Cursors.Default
        Me.tabPage1.ForeColor = System.Drawing.Color.DarkBlue
        Me.tabPage1.Location = New System.Drawing.Point(4, 22)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(537, 76)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "TCP/IP"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'btnconnect2
        '
        Me.btnconnect2.Location = New System.Drawing.Point(295, 40)
        Me.btnconnect2.Name = "btnconnect2"
        Me.btnconnect2.Size = New System.Drawing.Size(68, 23)
        Me.btnconnect2.TabIndex = 14
        Me.btnconnect2.Text = "Connect"
        Me.btnconnect2.UseVisualStyleBackColor = True
        '
        'Textip2
        '
        Me.Textip2.Location = New System.Drawing.Point(55, 43)
        Me.Textip2.Name = "Textip2"
        Me.Textip2.Size = New System.Drawing.Size(95, 20)
        Me.Textip2.TabIndex = 10
        Me.Textip2.Text = "192.168.1.94"
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.ForeColor = System.Drawing.Color.Crimson
        Me.lblState.Location = New System.Drawing.Point(376, 18)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(138, 13)
        Me.lblState.TabIndex = 13
        Me.lblState.Text = "Current State:Disconnected"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(176, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Port"
        '
        'Textport2
        '
        Me.Textport2.Location = New System.Drawing.Point(217, 42)
        Me.Textport2.Name = "Textport2"
        Me.Textport2.Size = New System.Drawing.Size(53, 20)
        Me.Textport2.TabIndex = 11
        Me.Textport2.Text = "4370"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(26, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "IP"
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(55, 16)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(95, 20)
        Me.txtIP.TabIndex = 6
        Me.txtIP.Text = "192.168.1.92"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(174, 19)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(26, 13)
        Me.label2.TabIndex = 9
        Me.label2.Text = "Port"
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(295, 12)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(68, 23)
        Me.btnConnect.TabIndex = 4
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(217, 15)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(53, 20)
        Me.txtPort.TabIndex = 7
        Me.txtPort.Text = "4370"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(24, 20)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(17, 13)
        Me.label1.TabIndex = 8
        Me.label1.Text = "IP"
        '
        'tabPage2
        '
        Me.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tabPage2.Controls.Add(Me.groupBox5)
        Me.tabPage2.Controls.Add(Me.btnRsConnect)
        Me.tabPage2.ForeColor = System.Drawing.Color.DarkBlue
        Me.tabPage2.Location = New System.Drawing.Point(4, 22)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(537, 76)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "RS232/485"
        Me.tabPage2.UseVisualStyleBackColor = True
        '
        'groupBox5
        '
        Me.groupBox5.Controls.Add(Me.cbBaudRate)
        Me.groupBox5.Controls.Add(Me.label5)
        Me.groupBox5.Controls.Add(Me.txtMachineSN)
        Me.groupBox5.Controls.Add(Me.cbPort)
        Me.groupBox5.Controls.Add(Me.label7)
        Me.groupBox5.Controls.Add(Me.label6)
        Me.groupBox5.Location = New System.Drawing.Point(17, -1)
        Me.groupBox5.Name = "groupBox5"
        Me.groupBox5.Size = New System.Drawing.Size(406, 40)
        Me.groupBox5.TabIndex = 12
        Me.groupBox5.TabStop = False
        '
        'cbBaudRate
        '
        Me.cbBaudRate.FormattingEnabled = True
        Me.cbBaudRate.Items.AddRange(New Object() {"1200", "2400", "4800", "9600", "19200", "38400", "115200"})
        Me.cbBaudRate.Location = New System.Drawing.Point(187, 14)
        Me.cbBaudRate.Name = "cbBaudRate"
        Me.cbBaudRate.Size = New System.Drawing.Size(65, 21)
        Me.cbBaudRate.TabIndex = 6
        Me.cbBaudRate.Text = "115200"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(10, 18)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(26, 13)
        Me.label5.TabIndex = 7
        Me.label5.Text = "Port"
        '
        'txtMachineSN
        '
        Me.txtMachineSN.Location = New System.Drawing.Point(337, 14)
        Me.txtMachineSN.Name = "txtMachineSN"
        Me.txtMachineSN.Size = New System.Drawing.Size(56, 20)
        Me.txtMachineSN.TabIndex = 10
        Me.txtMachineSN.Text = "1"
        '
        'cbPort
        '
        Me.cbPort.FormattingEnabled = True
        Me.cbPort.Items.AddRange(New Object() {"COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9"})
        Me.cbPort.Location = New System.Drawing.Point(52, 14)
        Me.cbPort.Name = "cbPort"
        Me.cbPort.Size = New System.Drawing.Size(56, 21)
        Me.cbPort.TabIndex = 5
        Me.cbPort.Text = "COM1"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(265, 18)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(63, 13)
        Me.label7.TabIndex = 9
        Me.label7.Text = "MachineSN"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(121, 18)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(55, 13)
        Me.label6.TabIndex = 8
        Me.label6.Text = "BaudRate"
        '
        'btnRsConnect
        '
        Me.btnRsConnect.Location = New System.Drawing.Point(183, 47)
        Me.btnRsConnect.Name = "btnRsConnect"
        Me.btnRsConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnRsConnect.TabIndex = 11
        Me.btnRsConnect.Text = "Connect"
        Me.btnRsConnect.UseVisualStyleBackColor = True
        '
        'lblState2
        '
        Me.lblState2.AutoSize = True
        Me.lblState2.ForeColor = System.Drawing.Color.Crimson
        Me.lblState2.Location = New System.Drawing.Point(392, 91)
        Me.lblState2.Name = "lblState2"
        Me.lblState2.Size = New System.Drawing.Size(138, 13)
        Me.lblState2.TabIndex = 15
        Me.lblState2.Text = "Current State:Disconnected"
        '
        'grid_tampilan
        '
        Me.grid_tampilan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_tampilan.Location = New System.Drawing.Point(16, 146)
        Me.grid_tampilan.Name = "grid_tampilan"
        Me.grid_tampilan.Size = New System.Drawing.Size(525, 320)
        Me.grid_tampilan.TabIndex = 16
        '
        'Button_simpan
        '
        Me.Button_simpan.Location = New System.Drawing.Point(107, 486)
        Me.Button_simpan.Name = "Button_simpan"
        Me.Button_simpan.Size = New System.Drawing.Size(75, 23)
        Me.Button_simpan.TabIndex = 18
        Me.Button_simpan.Text = "Simpan"
        Me.Button_simpan.UseVisualStyleBackColor = True
        '
        'Button_download
        '
        Me.Button_download.Location = New System.Drawing.Point(16, 486)
        Me.Button_download.Name = "Button_download"
        Me.Button_download.Size = New System.Drawing.Size(75, 23)
        Me.Button_download.TabIndex = 19
        Me.Button_download.Text = "Download"
        Me.Button_download.UseVisualStyleBackColor = True
        '
        'FormConnectFinger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1370, 601)
        Me.Controls.Add(Me.Button_download)
        Me.Controls.Add(Me.Button_simpan)
        Me.Controls.Add(Me.grid_tampilan)
        Me.Controls.Add(Me.lblState2)
        Me.Controls.Add(Me.tabControl1)
        Me.Name = "FormConnectFinger"
        Me.Text = "FormConnectFinger"
        Me.tabControl1.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.tabPage1.PerformLayout()
        Me.tabPage2.ResumeLayout(False)
        Me.groupBox5.ResumeLayout(False)
        Me.groupBox5.PerformLayout()
        CType(Me.grid_tampilan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents txtIP As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents btnConnect As System.Windows.Forms.Button
    Private WithEvents txtPort As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents groupBox5 As System.Windows.Forms.GroupBox
    Private WithEvents cbBaudRate As System.Windows.Forms.ComboBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents txtMachineSN As System.Windows.Forms.TextBox
    Private WithEvents cbPort As System.Windows.Forms.ComboBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents btnRsConnect As System.Windows.Forms.Button
    Private WithEvents lblState As System.Windows.Forms.Label
    Private WithEvents btnconnect2 As System.Windows.Forms.Button
    Private WithEvents Textip2 As System.Windows.Forms.TextBox
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Textport2 As System.Windows.Forms.TextBox
    Private WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents lblState2 As System.Windows.Forms.Label
    Friend WithEvents grid_tampilan As System.Windows.Forms.DataGridView
    Friend WithEvents Button_simpan As System.Windows.Forms.Button
    Friend WithEvents Button_download As System.Windows.Forms.Button
End Class
