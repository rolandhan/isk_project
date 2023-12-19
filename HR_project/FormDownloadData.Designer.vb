<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDownloadData
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Check_2 = New System.Windows.Forms.CheckBox()
        Me.Text_msn2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TB_serverIP2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TB_serverPort2 = New System.Windows.Forms.TextBox()
        Me.TB_deviceSN2 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Text_msn1 = New System.Windows.Forms.TextBox()
        Me.Check_1 = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.L_serverIP = New System.Windows.Forms.Label()
        Me.TB_serverIP = New System.Windows.Forms.TextBox()
        Me.L_deviceSN = New System.Windows.Forms.Label()
        Me.L_serverPort = New System.Windows.Forms.Label()
        Me.TB_serverPort = New System.Windows.Forms.TextBox()
        Me.TB_deviceSN = New System.Windows.Forms.TextBox()
        Me.Combo_mesin = New System.Windows.Forms.ComboBox()
        Me.TB_memo = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TP_dataUser = New System.Windows.Forms.TabPage()
        Me.L_UserRecordCount = New System.Windows.Forms.Label()
        Me.btn_set_user_paging = New System.Windows.Forms.Button()
        Me.edt_limit_user_up = New System.Windows.Forms.TextBox()
        Me.edt_limit_user = New System.Windows.Forms.TextBox()
        Me.DGV_template = New System.Windows.Forms.DataGridView()
        Me.template_PIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.template_fingerIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.template_algVersion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.template_template = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGV_user = New System.Windows.Forms.DataGridView()
        Me.PIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nama = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PWD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RFID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Privilege = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.B_clearUserDB = New System.Windows.Forms.Button()
        Me.TB_PIN_del = New System.Windows.Forms.TextBox()
        Me.B_delUser = New System.Windows.Forms.Button()
        Me.B_setUser = New System.Windows.Forms.Button()
        Me.TB_PIN_get = New System.Windows.Forms.TextBox()
        Me.B_delAllUser = New System.Windows.Forms.Button()
        Me.B_getAllUser = New System.Windows.Forms.Button()
        Me.TP_dataScanlog = New System.Windows.Forms.TabPage()
        Me.DGV_scanlog = New System.Windows.Forms.DataGridView()
        Me.edt_limit_scanlog = New System.Windows.Forms.TextBox()
        Me.L_recordCount = New System.Windows.Forms.Label()
        Me.B_getNewScanlog = New System.Windows.Forms.Button()
        Me.B_getAllScanlog = New System.Windows.Forms.Button()
        Me.TP_info = New System.Windows.Forms.TabPage()
        Me.TV_deviceInfo = New System.Windows.Forms.TreeView()
        Me.B_deviceInfo = New System.Windows.Forms.Button()
        Me.TP_settings = New System.Windows.Forms.TabPage()
        Me.B_syncDateTime = New System.Windows.Forms.Button()
        Me.TP_auto = New System.Windows.Forms.TabPage()
        Me.edt_limit_scanlog_auto = New System.Windows.Forms.TextBox()
        Me.edt_limit_user_auto = New System.Windows.Forms.TextBox()
        Me.btn_start_jadwal = New System.Windows.Forms.Button()
        Me.btn_get_all_scan_auto = New System.Windows.Forms.Button()
        Me.btn_get_all_user_auto = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TP_dataUser.SuspendLayout()
        CType(Me.DGV_template, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_user, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TP_dataScanlog.SuspendLayout()
        CType(Me.DGV_scanlog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TP_info.SuspendLayout()
        Me.TP_settings.SuspendLayout()
        Me.TP_auto.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Check_2)
        Me.Panel2.Controls.Add(Me.Text_msn2)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.TB_serverIP2)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.TB_serverPort2)
        Me.Panel2.Controls.Add(Me.TB_deviceSN2)
        Me.Panel2.Location = New System.Drawing.Point(16, 110)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1125, 42)
        Me.Panel2.TabIndex = 14
        '
        'Check_2
        '
        Me.Check_2.AutoSize = True
        Me.Check_2.Location = New System.Drawing.Point(933, 11)
        Me.Check_2.Margin = New System.Windows.Forms.Padding(4)
        Me.Check_2.Name = "Check_2"
        Me.Check_2.Size = New System.Drawing.Size(60, 21)
        Me.Check_2.TabIndex = 7
        Me.Check_2.Text = "Pilih "
        Me.Check_2.UseVisualStyleBackColor = True
        '
        'Text_msn2
        '
        Me.Text_msn2.Location = New System.Drawing.Point(89, 7)
        Me.Text_msn2.Margin = New System.Windows.Forms.Padding(4)
        Me.Text_msn2.Name = "Text_msn2"
        Me.Text_msn2.Size = New System.Drawing.Size(63, 22)
        Me.Text_msn2.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 12)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 17)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "No Mesin"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(179, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Server IP"
        '
        'TB_serverIP2
        '
        Me.TB_serverIP2.Location = New System.Drawing.Point(255, 9)
        Me.TB_serverIP2.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_serverIP2.Name = "TB_serverIP2"
        Me.TB_serverIP2.Size = New System.Drawing.Size(145, 22)
        Me.TB_serverIP2.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(645, 10)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Device SN"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(436, 10)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 17)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Server Port"
        '
        'TB_serverPort2
        '
        Me.TB_serverPort2.Location = New System.Drawing.Point(529, 6)
        Me.TB_serverPort2.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_serverPort2.Name = "TB_serverPort2"
        Me.TB_serverPort2.Size = New System.Drawing.Size(76, 22)
        Me.TB_serverPort2.TabIndex = 1
        '
        'TB_deviceSN2
        '
        Me.TB_deviceSN2.Location = New System.Drawing.Point(733, 6)
        Me.TB_deviceSN2.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_deviceSN2.Name = "TB_deviceSN2"
        Me.TB_deviceSN2.Size = New System.Drawing.Size(159, 22)
        Me.TB_deviceSN2.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Text_msn1)
        Me.Panel1.Controls.Add(Me.Check_1)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.L_serverIP)
        Me.Panel1.Controls.Add(Me.TB_serverIP)
        Me.Panel1.Controls.Add(Me.L_deviceSN)
        Me.Panel1.Controls.Add(Me.L_serverPort)
        Me.Panel1.Controls.Add(Me.TB_serverPort)
        Me.Panel1.Controls.Add(Me.TB_deviceSN)
        Me.Panel1.Location = New System.Drawing.Point(16, 59)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1125, 43)
        Me.Panel1.TabIndex = 13
        '
        'Text_msn1
        '
        Me.Text_msn1.Location = New System.Drawing.Point(89, 10)
        Me.Text_msn1.Margin = New System.Windows.Forms.Padding(4)
        Me.Text_msn1.Name = "Text_msn1"
        Me.Text_msn1.Size = New System.Drawing.Size(63, 22)
        Me.Text_msn1.TabIndex = 5
        '
        'Check_1
        '
        Me.Check_1.AutoSize = True
        Me.Check_1.Location = New System.Drawing.Point(933, 10)
        Me.Check_1.Margin = New System.Windows.Forms.Padding(4)
        Me.Check_1.Name = "Check_1"
        Me.Check_1.Size = New System.Drawing.Size(60, 21)
        Me.Check_1.TabIndex = 4
        Me.Check_1.Text = "Pilih "
        Me.Check_1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 12)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "No Mesin"
        '
        'L_serverIP
        '
        Me.L_serverIP.AutoSize = True
        Me.L_serverIP.Location = New System.Drawing.Point(180, 11)
        Me.L_serverIP.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.L_serverIP.Name = "L_serverIP"
        Me.L_serverIP.Size = New System.Drawing.Size(66, 17)
        Me.L_serverIP.TabIndex = 0
        Me.L_serverIP.Text = "Server IP"
        '
        'TB_serverIP
        '
        Me.TB_serverIP.Location = New System.Drawing.Point(255, 7)
        Me.TB_serverIP.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_serverIP.Name = "TB_serverIP"
        Me.TB_serverIP.Size = New System.Drawing.Size(145, 22)
        Me.TB_serverIP.TabIndex = 0
        '
        'L_deviceSN
        '
        Me.L_deviceSN.AutoSize = True
        Me.L_deviceSN.Location = New System.Drawing.Point(645, 14)
        Me.L_deviceSN.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.L_deviceSN.Name = "L_deviceSN"
        Me.L_deviceSN.Size = New System.Drawing.Size(74, 17)
        Me.L_deviceSN.TabIndex = 1
        Me.L_deviceSN.Text = "Device SN"
        '
        'L_serverPort
        '
        Me.L_serverPort.AutoSize = True
        Me.L_serverPort.Location = New System.Drawing.Point(436, 11)
        Me.L_serverPort.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.L_serverPort.Name = "L_serverPort"
        Me.L_serverPort.Size = New System.Drawing.Size(80, 17)
        Me.L_serverPort.TabIndex = 2
        Me.L_serverPort.Text = "Server Port"
        '
        'TB_serverPort
        '
        Me.TB_serverPort.Location = New System.Drawing.Point(525, 7)
        Me.TB_serverPort.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_serverPort.Name = "TB_serverPort"
        Me.TB_serverPort.Size = New System.Drawing.Size(80, 22)
        Me.TB_serverPort.TabIndex = 1
        '
        'TB_deviceSN
        '
        Me.TB_deviceSN.Location = New System.Drawing.Point(733, 7)
        Me.TB_deviceSN.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_deviceSN.Name = "TB_deviceSN"
        Me.TB_deviceSN.Size = New System.Drawing.Size(159, 22)
        Me.TB_deviceSN.TabIndex = 2
        '
        'Combo_mesin
        '
        Me.Combo_mesin.FormattingEnabled = True
        Me.Combo_mesin.Location = New System.Drawing.Point(16, 15)
        Me.Combo_mesin.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_mesin.Name = "Combo_mesin"
        Me.Combo_mesin.Size = New System.Drawing.Size(247, 24)
        Me.Combo_mesin.TabIndex = 15
        '
        'TB_memo
        '
        Me.TB_memo.Location = New System.Drawing.Point(16, 708)
        Me.TB_memo.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_memo.Multiline = True
        Me.TB_memo.Name = "TB_memo"
        Me.TB_memo.Size = New System.Drawing.Size(1119, 110)
        Me.TB_memo.TabIndex = 20
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TP_dataUser)
        Me.TabControl1.Controls.Add(Me.TP_dataScanlog)
        Me.TabControl1.Controls.Add(Me.TP_info)
        Me.TabControl1.Controls.Add(Me.TP_settings)
        Me.TabControl1.Controls.Add(Me.TP_auto)
        Me.TabControl1.Location = New System.Drawing.Point(16, 174)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1125, 527)
        Me.TabControl1.TabIndex = 21
        '
        'TP_dataUser
        '
        Me.TP_dataUser.Controls.Add(Me.L_UserRecordCount)
        Me.TP_dataUser.Controls.Add(Me.btn_set_user_paging)
        Me.TP_dataUser.Controls.Add(Me.edt_limit_user_up)
        Me.TP_dataUser.Controls.Add(Me.edt_limit_user)
        Me.TP_dataUser.Controls.Add(Me.DGV_template)
        Me.TP_dataUser.Controls.Add(Me.DGV_user)
        Me.TP_dataUser.Controls.Add(Me.B_clearUserDB)
        Me.TP_dataUser.Controls.Add(Me.TB_PIN_del)
        Me.TP_dataUser.Controls.Add(Me.B_delUser)
        Me.TP_dataUser.Controls.Add(Me.B_setUser)
        Me.TP_dataUser.Controls.Add(Me.TB_PIN_get)
        Me.TP_dataUser.Controls.Add(Me.B_delAllUser)
        Me.TP_dataUser.Controls.Add(Me.B_getAllUser)
        Me.TP_dataUser.Location = New System.Drawing.Point(4, 25)
        Me.TP_dataUser.Margin = New System.Windows.Forms.Padding(4)
        Me.TP_dataUser.Name = "TP_dataUser"
        Me.TP_dataUser.Padding = New System.Windows.Forms.Padding(4)
        Me.TP_dataUser.Size = New System.Drawing.Size(1117, 498)
        Me.TP_dataUser.TabIndex = 0
        Me.TP_dataUser.Text = "Data User"
        Me.TP_dataUser.UseVisualStyleBackColor = True
        '
        'L_UserRecordCount
        '
        Me.L_UserRecordCount.AutoSize = True
        Me.L_UserRecordCount.Location = New System.Drawing.Point(732, 105)
        Me.L_UserRecordCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.L_UserRecordCount.Name = "L_UserRecordCount"
        Me.L_UserRecordCount.Size = New System.Drawing.Size(108, 17)
        Me.L_UserRecordCount.TabIndex = 14
        Me.L_UserRecordCount.Text = "User Record : 0"
        '
        'btn_set_user_paging
        '
        Me.btn_set_user_paging.Location = New System.Drawing.Point(124, 37)
        Me.btn_set_user_paging.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_set_user_paging.Name = "btn_set_user_paging"
        Me.btn_set_user_paging.Size = New System.Drawing.Size(223, 28)
        Me.btn_set_user_paging.TabIndex = 13
        Me.btn_set_user_paging.Text = "Set All User (With Pagination)"
        Me.btn_set_user_paging.UseVisualStyleBackColor = True
        '
        'edt_limit_user_up
        '
        Me.edt_limit_user_up.Location = New System.Drawing.Point(25, 41)
        Me.edt_limit_user_up.Margin = New System.Windows.Forms.Padding(4)
        Me.edt_limit_user_up.Name = "edt_limit_user_up"
        Me.edt_limit_user_up.Size = New System.Drawing.Size(89, 22)
        Me.edt_limit_user_up.TabIndex = 12
        Me.edt_limit_user_up.Text = "Limit paging"
        '
        'edt_limit_user
        '
        Me.edt_limit_user.Location = New System.Drawing.Point(25, 9)
        Me.edt_limit_user.Margin = New System.Windows.Forms.Padding(4)
        Me.edt_limit_user.Name = "edt_limit_user"
        Me.edt_limit_user.Size = New System.Drawing.Size(89, 22)
        Me.edt_limit_user.TabIndex = 11
        Me.edt_limit_user.Text = "Limit paging"
        '
        'DGV_template
        '
        Me.DGV_template.AllowUserToAddRows = False
        Me.DGV_template.AllowUserToDeleteRows = False
        Me.DGV_template.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_template.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.template_PIN, Me.template_fingerIndex, Me.template_algVersion, Me.template_template})
        Me.DGV_template.Location = New System.Drawing.Point(8, 348)
        Me.DGV_template.Margin = New System.Windows.Forms.Padding(4)
        Me.DGV_template.Name = "DGV_template"
        Me.DGV_template.ReadOnly = True
        Me.DGV_template.Size = New System.Drawing.Size(1099, 139)
        Me.DGV_template.TabIndex = 9
        '
        'template_PIN
        '
        Me.template_PIN.DataPropertyName = "pin"
        Me.template_PIN.HeaderText = "PIN"
        Me.template_PIN.Name = "template_PIN"
        Me.template_PIN.ReadOnly = True
        '
        'template_fingerIndex
        '
        Me.template_fingerIndex.DataPropertyName = "finger_idx"
        Me.template_fingerIndex.HeaderText = "Finger Index"
        Me.template_fingerIndex.Name = "template_fingerIndex"
        Me.template_fingerIndex.ReadOnly = True
        '
        'template_algVersion
        '
        Me.template_algVersion.DataPropertyName = "alg_ver"
        Me.template_algVersion.HeaderText = "Algoritma Version"
        Me.template_algVersion.Name = "template_algVersion"
        Me.template_algVersion.ReadOnly = True
        '
        'template_template
        '
        Me.template_template.DataPropertyName = "template"
        Me.template_template.HeaderText = "Template"
        Me.template_template.Name = "template_template"
        Me.template_template.ReadOnly = True
        Me.template_template.Width = 280
        '
        'DGV_user
        '
        Me.DGV_user.AllowUserToAddRows = False
        Me.DGV_user.AllowUserToDeleteRows = False
        Me.DGV_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_user.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PIN, Me.Nama, Me.PWD, Me.RFID, Me.Privilege})
        Me.DGV_user.Location = New System.Drawing.Point(7, 124)
        Me.DGV_user.Margin = New System.Windows.Forms.Padding(4)
        Me.DGV_user.Name = "DGV_user"
        Me.DGV_user.ReadOnly = True
        Me.DGV_user.Size = New System.Drawing.Size(1100, 217)
        Me.DGV_user.TabIndex = 8
        '
        'PIN
        '
        Me.PIN.DataPropertyName = "pin"
        Me.PIN.HeaderText = "PIN"
        Me.PIN.Name = "PIN"
        Me.PIN.ReadOnly = True
        '
        'Nama
        '
        Me.Nama.DataPropertyName = "nama"
        Me.Nama.HeaderText = "Nama"
        Me.Nama.Name = "Nama"
        Me.Nama.ReadOnly = True
        '
        'PWD
        '
        Me.PWD.DataPropertyName = "pwd"
        Me.PWD.HeaderText = "PWD"
        Me.PWD.Name = "PWD"
        Me.PWD.ReadOnly = True
        '
        'RFID
        '
        Me.RFID.DataPropertyName = "rfid"
        Me.RFID.HeaderText = "RFID"
        Me.RFID.Name = "RFID"
        Me.RFID.ReadOnly = True
        Me.RFID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Privilege
        '
        Me.Privilege.DataPropertyName = "privilege"
        Me.Privilege.HeaderText = "Privilege"
        Me.Privilege.Name = "Privilege"
        Me.Privilege.ReadOnly = True
        '
        'B_clearUserDB
        '
        Me.B_clearUserDB.Location = New System.Drawing.Point(371, 74)
        Me.B_clearUserDB.Margin = New System.Windows.Forms.Padding(4)
        Me.B_clearUserDB.Name = "B_clearUserDB"
        Me.B_clearUserDB.Size = New System.Drawing.Size(357, 28)
        Me.B_clearUserDB.TabIndex = 6
        Me.B_clearUserDB.Text = "Clear User In Database"
        Me.B_clearUserDB.UseVisualStyleBackColor = True
        '
        'TB_PIN_del
        '
        Me.TB_PIN_del.Location = New System.Drawing.Point(371, 42)
        Me.TB_PIN_del.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_PIN_del.Name = "TB_PIN_del"
        Me.TB_PIN_del.Size = New System.Drawing.Size(132, 22)
        Me.TB_PIN_del.TabIndex = 5
        Me.TB_PIN_del.Text = "PIN"
        '
        'B_delUser
        '
        Me.B_delUser.Location = New System.Drawing.Point(512, 39)
        Me.B_delUser.Margin = New System.Windows.Forms.Padding(4)
        Me.B_delUser.Name = "B_delUser"
        Me.B_delUser.Size = New System.Drawing.Size(216, 27)
        Me.B_delUser.TabIndex = 4
        Me.B_delUser.Text = "Delete User PIN"
        Me.B_delUser.UseVisualStyleBackColor = True
        '
        'B_setUser
        '
        Me.B_setUser.Location = New System.Drawing.Point(512, 6)
        Me.B_setUser.Margin = New System.Windows.Forms.Padding(4)
        Me.B_setUser.Name = "B_setUser"
        Me.B_setUser.Size = New System.Drawing.Size(216, 28)
        Me.B_setUser.TabIndex = 3
        Me.B_setUser.Text = "Set User"
        Me.B_setUser.UseVisualStyleBackColor = True
        '
        'TB_PIN_get
        '
        Me.TB_PIN_get.Location = New System.Drawing.Point(371, 10)
        Me.TB_PIN_get.Margin = New System.Windows.Forms.Padding(4)
        Me.TB_PIN_get.Name = "TB_PIN_get"
        Me.TB_PIN_get.Size = New System.Drawing.Size(132, 22)
        Me.TB_PIN_get.TabIndex = 2
        Me.TB_PIN_get.Text = "PIN"
        '
        'B_delAllUser
        '
        Me.B_delAllUser.Location = New System.Drawing.Point(25, 74)
        Me.B_delAllUser.Margin = New System.Windows.Forms.Padding(4)
        Me.B_delAllUser.Name = "B_delAllUser"
        Me.B_delAllUser.Size = New System.Drawing.Size(321, 28)
        Me.B_delAllUser.TabIndex = 1
        Me.B_delAllUser.Text = "Delete All User"
        Me.B_delAllUser.UseVisualStyleBackColor = True
        '
        'B_getAllUser
        '
        Me.B_getAllUser.Location = New System.Drawing.Point(124, 7)
        Me.B_getAllUser.Margin = New System.Windows.Forms.Padding(4)
        Me.B_getAllUser.Name = "B_getAllUser"
        Me.B_getAllUser.Size = New System.Drawing.Size(223, 28)
        Me.B_getAllUser.TabIndex = 0
        Me.B_getAllUser.Text = "Get All User (With Pagination) "
        Me.B_getAllUser.UseVisualStyleBackColor = True
        '
        'TP_dataScanlog
        '
        Me.TP_dataScanlog.Controls.Add(Me.DGV_scanlog)
        Me.TP_dataScanlog.Controls.Add(Me.edt_limit_scanlog)
        Me.TP_dataScanlog.Controls.Add(Me.L_recordCount)
        Me.TP_dataScanlog.Controls.Add(Me.B_getNewScanlog)
        Me.TP_dataScanlog.Controls.Add(Me.B_getAllScanlog)
        Me.TP_dataScanlog.Location = New System.Drawing.Point(4, 25)
        Me.TP_dataScanlog.Margin = New System.Windows.Forms.Padding(4)
        Me.TP_dataScanlog.Name = "TP_dataScanlog"
        Me.TP_dataScanlog.Padding = New System.Windows.Forms.Padding(4)
        Me.TP_dataScanlog.Size = New System.Drawing.Size(1117, 498)
        Me.TP_dataScanlog.TabIndex = 1
        Me.TP_dataScanlog.Text = "Data Scanlog"
        Me.TP_dataScanlog.UseVisualStyleBackColor = True
        '
        'DGV_scanlog
        '
        Me.DGV_scanlog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_scanlog.Location = New System.Drawing.Point(27, 82)
        Me.DGV_scanlog.Margin = New System.Windows.Forms.Padding(4)
        Me.DGV_scanlog.Name = "DGV_scanlog"
        Me.DGV_scanlog.Size = New System.Drawing.Size(832, 314)
        Me.DGV_scanlog.TabIndex = 17
        '
        'edt_limit_scanlog
        '
        Me.edt_limit_scanlog.Location = New System.Drawing.Point(27, 9)
        Me.edt_limit_scanlog.Margin = New System.Windows.Forms.Padding(4)
        Me.edt_limit_scanlog.Name = "edt_limit_scanlog"
        Me.edt_limit_scanlog.Size = New System.Drawing.Size(132, 22)
        Me.edt_limit_scanlog.TabIndex = 6
        Me.edt_limit_scanlog.Text = "Limit paging"
        '
        'L_recordCount
        '
        Me.L_recordCount.AutoSize = True
        Me.L_recordCount.Location = New System.Drawing.Point(684, 63)
        Me.L_recordCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.L_recordCount.Name = "L_recordCount"
        Me.L_recordCount.Size = New System.Drawing.Size(129, 17)
        Me.L_recordCount.TabIndex = 4
        Me.L_recordCount.Text = "Scanlog Record : 0"
        Me.L_recordCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'B_getNewScanlog
        '
        Me.B_getNewScanlog.Location = New System.Drawing.Point(168, 42)
        Me.B_getNewScanlog.Margin = New System.Windows.Forms.Padding(4)
        Me.B_getNewScanlog.Name = "B_getNewScanlog"
        Me.B_getNewScanlog.Size = New System.Drawing.Size(291, 28)
        Me.B_getNewScanlog.TabIndex = 1
        Me.B_getNewScanlog.Text = "Get New Scanlog"
        Me.B_getNewScanlog.UseVisualStyleBackColor = True
        '
        'B_getAllScanlog
        '
        Me.B_getAllScanlog.Location = New System.Drawing.Point(168, 7)
        Me.B_getAllScanlog.Margin = New System.Windows.Forms.Padding(4)
        Me.B_getAllScanlog.Name = "B_getAllScanlog"
        Me.B_getAllScanlog.Size = New System.Drawing.Size(291, 28)
        Me.B_getAllScanlog.TabIndex = 0
        Me.B_getAllScanlog.Text = "Get All Scanlog (With Pagination)"
        Me.B_getAllScanlog.UseVisualStyleBackColor = True
        '
        'TP_info
        '
        Me.TP_info.Controls.Add(Me.TV_deviceInfo)
        Me.TP_info.Controls.Add(Me.B_deviceInfo)
        Me.TP_info.Location = New System.Drawing.Point(4, 25)
        Me.TP_info.Margin = New System.Windows.Forms.Padding(4)
        Me.TP_info.Name = "TP_info"
        Me.TP_info.Size = New System.Drawing.Size(1117, 498)
        Me.TP_info.TabIndex = 2
        Me.TP_info.Text = "Info"
        Me.TP_info.UseVisualStyleBackColor = True
        '
        'TV_deviceInfo
        '
        Me.TV_deviceInfo.Location = New System.Drawing.Point(11, 55)
        Me.TV_deviceInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.TV_deviceInfo.Name = "TV_deviceInfo"
        Me.TV_deviceInfo.Size = New System.Drawing.Size(856, 354)
        Me.TV_deviceInfo.TabIndex = 1
        '
        'B_deviceInfo
        '
        Me.B_deviceInfo.Location = New System.Drawing.Point(20, 17)
        Me.B_deviceInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.B_deviceInfo.Name = "B_deviceInfo"
        Me.B_deviceInfo.Size = New System.Drawing.Size(171, 28)
        Me.B_deviceInfo.TabIndex = 0
        Me.B_deviceInfo.Text = "Device Info"
        Me.B_deviceInfo.UseVisualStyleBackColor = True
        '
        'TP_settings
        '
        Me.TP_settings.Controls.Add(Me.B_syncDateTime)
        Me.TP_settings.Location = New System.Drawing.Point(4, 25)
        Me.TP_settings.Margin = New System.Windows.Forms.Padding(4)
        Me.TP_settings.Name = "TP_settings"
        Me.TP_settings.Size = New System.Drawing.Size(1117, 498)
        Me.TP_settings.TabIndex = 3
        Me.TP_settings.Text = "-"
        Me.TP_settings.UseVisualStyleBackColor = True
        '
        'B_syncDateTime
        '
        Me.B_syncDateTime.Location = New System.Drawing.Point(43, 22)
        Me.B_syncDateTime.Margin = New System.Windows.Forms.Padding(4)
        Me.B_syncDateTime.Name = "B_syncDateTime"
        Me.B_syncDateTime.Size = New System.Drawing.Size(160, 28)
        Me.B_syncDateTime.TabIndex = 0
        Me.B_syncDateTime.Text = "Sync Date Time"
        Me.B_syncDateTime.UseVisualStyleBackColor = True
        '
        'TP_auto
        '
        Me.TP_auto.Controls.Add(Me.edt_limit_scanlog_auto)
        Me.TP_auto.Controls.Add(Me.edt_limit_user_auto)
        Me.TP_auto.Controls.Add(Me.btn_start_jadwal)
        Me.TP_auto.Controls.Add(Me.btn_get_all_scan_auto)
        Me.TP_auto.Controls.Add(Me.btn_get_all_user_auto)
        Me.TP_auto.Location = New System.Drawing.Point(4, 25)
        Me.TP_auto.Margin = New System.Windows.Forms.Padding(4)
        Me.TP_auto.Name = "TP_auto"
        Me.TP_auto.Size = New System.Drawing.Size(1117, 498)
        Me.TP_auto.TabIndex = 4
        Me.TP_auto.Text = "Auto"
        Me.TP_auto.UseVisualStyleBackColor = True
        '
        'edt_limit_scanlog_auto
        '
        Me.edt_limit_scanlog_auto.Location = New System.Drawing.Point(25, 57)
        Me.edt_limit_scanlog_auto.Margin = New System.Windows.Forms.Padding(4)
        Me.edt_limit_scanlog_auto.Name = "edt_limit_scanlog_auto"
        Me.edt_limit_scanlog_auto.Size = New System.Drawing.Size(132, 22)
        Me.edt_limit_scanlog_auto.TabIndex = 4
        Me.edt_limit_scanlog_auto.Text = "Limit paging"
        '
        'edt_limit_user_auto
        '
        Me.edt_limit_user_auto.Location = New System.Drawing.Point(25, 20)
        Me.edt_limit_user_auto.Margin = New System.Windows.Forms.Padding(4)
        Me.edt_limit_user_auto.Name = "edt_limit_user_auto"
        Me.edt_limit_user_auto.Size = New System.Drawing.Size(132, 22)
        Me.edt_limit_user_auto.TabIndex = 3
        Me.edt_limit_user_auto.Text = "Limit paging"
        '
        'btn_start_jadwal
        '
        Me.btn_start_jadwal.Location = New System.Drawing.Point(167, 94)
        Me.btn_start_jadwal.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_start_jadwal.Name = "btn_start_jadwal"
        Me.btn_start_jadwal.Size = New System.Drawing.Size(220, 28)
        Me.btn_start_jadwal.TabIndex = 2
        Me.btn_start_jadwal.Text = "Start Download Scheduler"
        Me.btn_start_jadwal.UseVisualStyleBackColor = True
        '
        'btn_get_all_scan_auto
        '
        Me.btn_get_all_scan_auto.Location = New System.Drawing.Point(167, 57)
        Me.btn_get_all_scan_auto.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_get_all_scan_auto.Name = "btn_get_all_scan_auto"
        Me.btn_get_all_scan_auto.Size = New System.Drawing.Size(220, 28)
        Me.btn_get_all_scan_auto.TabIndex = 1
        Me.btn_get_all_scan_auto.Text = "Get All Scanlog in All Device"
        Me.btn_get_all_scan_auto.UseVisualStyleBackColor = True
        '
        'btn_get_all_user_auto
        '
        Me.btn_get_all_user_auto.Location = New System.Drawing.Point(167, 20)
        Me.btn_get_all_user_auto.Margin = New System.Windows.Forms.Padding(4)
        Me.btn_get_all_user_auto.Name = "btn_get_all_user_auto"
        Me.btn_get_all_user_auto.Size = New System.Drawing.Size(220, 28)
        Me.btn_get_all_user_auto.TabIndex = 0
        Me.btn_get_all_user_auto.Text = "Get All User in All Device"
        Me.btn_get_all_user_auto.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox1.Location = New System.Drawing.Point(3, 9)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1823, 80)
        Me.PictureBox1.TabIndex = 324
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox2.Location = New System.Drawing.Point(3, 748)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1823, 166)
        Me.PictureBox2.TabIndex = 325
        Me.PictureBox2.TabStop = False
        '
        'FormDownloadData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1827, 923)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.TB_memo)
        Me.Controls.Add(Me.Combo_mesin)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormDownloadData"
        Me.Text = "FormDownloadData"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TP_dataUser.ResumeLayout(False)
        Me.TP_dataUser.PerformLayout()
        CType(Me.DGV_template, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_user, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TP_dataScanlog.ResumeLayout(False)
        Me.TP_dataScanlog.PerformLayout()
        CType(Me.DGV_scanlog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TP_info.ResumeLayout(False)
        Me.TP_settings.ResumeLayout(False)
        Me.TP_auto.ResumeLayout(False)
        Me.TP_auto.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Check_2 As System.Windows.Forms.CheckBox
    Friend WithEvents Text_msn2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TB_serverIP2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TB_serverPort2 As System.Windows.Forms.TextBox
    Friend WithEvents TB_deviceSN2 As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Text_msn1 As System.Windows.Forms.TextBox
    Friend WithEvents Check_1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents L_serverIP As System.Windows.Forms.Label
    Friend WithEvents TB_serverIP As System.Windows.Forms.TextBox
    Friend WithEvents L_deviceSN As System.Windows.Forms.Label
    Friend WithEvents L_serverPort As System.Windows.Forms.Label
    Friend WithEvents TB_serverPort As System.Windows.Forms.TextBox
    Friend WithEvents TB_deviceSN As System.Windows.Forms.TextBox
    Friend WithEvents Combo_mesin As System.Windows.Forms.ComboBox
    Friend WithEvents TB_memo As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TP_dataUser As System.Windows.Forms.TabPage
    Friend WithEvents L_UserRecordCount As System.Windows.Forms.Label
    Friend WithEvents btn_set_user_paging As System.Windows.Forms.Button
    Friend WithEvents edt_limit_user_up As System.Windows.Forms.TextBox
    Friend WithEvents edt_limit_user As System.Windows.Forms.TextBox
    Friend WithEvents DGV_template As System.Windows.Forms.DataGridView
    Friend WithEvents template_PIN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents template_fingerIndex As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents template_algVersion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents template_template As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGV_user As System.Windows.Forms.DataGridView
    Friend WithEvents PIN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PWD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RFID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Privilege As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B_clearUserDB As System.Windows.Forms.Button
    Friend WithEvents TB_PIN_del As System.Windows.Forms.TextBox
    Friend WithEvents B_delUser As System.Windows.Forms.Button
    Friend WithEvents B_setUser As System.Windows.Forms.Button
    Friend WithEvents TB_PIN_get As System.Windows.Forms.TextBox
    Friend WithEvents B_delAllUser As System.Windows.Forms.Button
    Friend WithEvents B_getAllUser As System.Windows.Forms.Button
    Friend WithEvents TP_dataScanlog As System.Windows.Forms.TabPage
    Friend WithEvents edt_limit_scanlog As System.Windows.Forms.TextBox
    Friend WithEvents L_recordCount As System.Windows.Forms.Label
    Friend WithEvents B_getNewScanlog As System.Windows.Forms.Button
    Friend WithEvents B_getAllScanlog As System.Windows.Forms.Button
    Friend WithEvents TP_info As System.Windows.Forms.TabPage
    Friend WithEvents TV_deviceInfo As System.Windows.Forms.TreeView
    Friend WithEvents B_deviceInfo As System.Windows.Forms.Button
    Friend WithEvents TP_settings As System.Windows.Forms.TabPage
    Friend WithEvents B_syncDateTime As System.Windows.Forms.Button
    Friend WithEvents TP_auto As System.Windows.Forms.TabPage
    Friend WithEvents edt_limit_scanlog_auto As System.Windows.Forms.TextBox
    Friend WithEvents edt_limit_user_auto As System.Windows.Forms.TextBox
    Friend WithEvents btn_start_jadwal As System.Windows.Forms.Button
    Friend WithEvents btn_get_all_scan_auto As System.Windows.Forms.Button
    Friend WithEvents btn_get_all_user_auto As System.Windows.Forms.Button
    Friend WithEvents DGV_scanlog As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
