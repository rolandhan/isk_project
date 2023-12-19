<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMutasi
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.combo_dept = New System.Windows.Forms.ComboBox()
        Me.Text_pencarian = New System.Windows.Forms.TextBox()
        Me.GridTampilData = New System.Windows.Forms.DataGridView()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabMutasiKary = New System.Windows.Forms.TabPage()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.BSimpanMutasi = New System.Windows.Forms.Button()
        Me.GroupMutasBaru = New System.Windows.Forms.GroupBox()
        Me.CheckHarian = New System.Windows.Forms.CheckBox()
        Me.LabelSampai = New System.Windows.Forms.Label()
        Me.DTAkhir = New System.Windows.Forms.DateTimePicker()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.TextKet = New System.Windows.Forms.TextBox()
        Me.ComboStatusBaru = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.DTMutasi = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ComboDeptBaru = New System.Windows.Forms.ComboBox()
        Me.ComboJabBaru = New System.Windows.Forms.ComboBox()
        Me.ComboAtasan = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextNamaBaru = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextNikBaru = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupMutasiAwal = New System.Windows.Forms.GroupBox()
        Me.TextStatus = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextDeptLama = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextJabLama = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextNamaLama = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextNikLama = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TabGantiAtasan = New System.Windows.Forms.TabPage()
        Me.BSimpanAts = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupAtasanBaru = New System.Windows.Forms.GroupBox()
        Me.ComboDepAtsBaru = New System.Windows.Forms.ComboBox()
        Me.ComboJabAtsBaru = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextNamaAtsBaru = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TextNIKAtsBaru = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.GroupAtasanAwal = New System.Windows.Forms.GroupBox()
        Me.TextDepAtsAwal = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TextJabAtsAwal = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TextNamaAtsAwal = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TextNIKAtsAwal = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.WorkerCheckData = New System.ComponentModel.BackgroundWorker()
        Me.WorkerGantiAtasan = New System.ComponentModel.BackgroundWorker()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.ComboKary = New System.Windows.Forms.ComboBox()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridTampilData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabMutasiKary.SuspendLayout()
        Me.GroupMutasBaru.SuspendLayout()
        Me.GroupMutasiAwal.SuspendLayout()
        Me.TabGantiAtasan.SuspendLayout()
        Me.GroupAtasanBaru.SuspendLayout()
        Me.GroupAtasanAwal.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(24, 21)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(308, 52)
        Me.Label4.TabIndex = 327
        Me.Label4.Text = "FORM MUTASI"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox2.Location = New System.Drawing.Point(2, 748)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1823, 166)
        Me.PictureBox2.TabIndex = 326
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox1.Location = New System.Drawing.Point(2, 9)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1823, 80)
        Me.PictureBox1.TabIndex = 325
        Me.PictureBox1.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.HR_project.My.Resources.Resources.find_21
        Me.PictureBox3.Location = New System.Drawing.Point(1748, 212)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(27, 25)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 356
        Me.PictureBox3.TabStop = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(854, 179)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 18)
        Me.Label15.TabIndex = 355
        Me.Label15.Text = "Departemen"
        '
        'combo_dept
        '
        Me.combo_dept.FormattingEnabled = True
        Me.combo_dept.Location = New System.Drawing.Point(978, 175)
        Me.combo_dept.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_dept.Name = "combo_dept"
        Me.combo_dept.Size = New System.Drawing.Size(321, 24)
        Me.combo_dept.TabIndex = 354
        '
        'Text_pencarian
        '
        Me.Text_pencarian.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_pencarian.Location = New System.Drawing.Point(856, 212)
        Me.Text_pencarian.Margin = New System.Windows.Forms.Padding(4)
        Me.Text_pencarian.Name = "Text_pencarian"
        Me.Text_pencarian.Size = New System.Drawing.Size(919, 26)
        Me.Text_pencarian.TabIndex = 353
        '
        'GridTampilData
        '
        Me.GridTampilData.BackgroundColor = System.Drawing.SystemColors.Control
        Me.GridTampilData.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GridTampilData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GridTampilData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridTampilData.Location = New System.Drawing.Point(856, 260)
        Me.GridTampilData.Margin = New System.Windows.Forms.Padding(4)
        Me.GridTampilData.Name = "GridTampilData"
        Me.GridTampilData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GridTampilData.Size = New System.Drawing.Size(920, 486)
        Me.GridTampilData.TabIndex = 352
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabMutasiKary)
        Me.TabControl1.Controls.Add(Me.TabGantiAtasan)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(31, 108)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(816, 709)
        Me.TabControl1.TabIndex = 374
        '
        'TabMutasiKary
        '
        Me.TabMutasiKary.BackColor = System.Drawing.Color.White
        Me.TabMutasiKary.Controls.Add(Me.Label17)
        Me.TabMutasiKary.Controls.Add(Me.Label22)
        Me.TabMutasiKary.Controls.Add(Me.BSimpanMutasi)
        Me.TabMutasiKary.Controls.Add(Me.GroupMutasBaru)
        Me.TabMutasiKary.Controls.Add(Me.GroupMutasiAwal)
        Me.TabMutasiKary.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabMutasiKary.Location = New System.Drawing.Point(4, 29)
        Me.TabMutasiKary.Name = "TabMutasiKary"
        Me.TabMutasiKary.Padding = New System.Windows.Forms.Padding(3)
        Me.TabMutasiKary.Size = New System.Drawing.Size(808, 676)
        Me.TabMutasiKary.TabIndex = 0
        Me.TabMutasiKary.Text = "Mutasi Karyawan"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(194, 606)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(48, 18)
        Me.Label17.TabIndex = 381
        Me.Label17.Text = "Note :"
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(193, 626)
        Me.Label22.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(589, 39)
        Me.Label22.TabIndex = 380
        Me.Label22.Text = "Menu ini digunakan untuk mutasi karyawan, maupun pergantian status karyawan yang " & _
            "mengalami pergantian NIK"
        '
        'BSimpanMutasi
        '
        Me.BSimpanMutasi.FlatAppearance.BorderSize = 0
        Me.BSimpanMutasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BSimpanMutasi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BSimpanMutasi.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.BSimpanMutasi.Image = Global.HR_project.My.Resources.Resources.save
        Me.BSimpanMutasi.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BSimpanMutasi.Location = New System.Drawing.Point(40, 595)
        Me.BSimpanMutasi.Margin = New System.Windows.Forms.Padding(4)
        Me.BSimpanMutasi.Name = "BSimpanMutasi"
        Me.BSimpanMutasi.Size = New System.Drawing.Size(91, 70)
        Me.BSimpanMutasi.TabIndex = 376
        Me.BSimpanMutasi.Text = "simpan"
        Me.BSimpanMutasi.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BSimpanMutasi.UseVisualStyleBackColor = True
        '
        'GroupMutasBaru
        '
        Me.GroupMutasBaru.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupMutasBaru.Controls.Add(Me.CheckHarian)
        Me.GroupMutasBaru.Controls.Add(Me.LabelSampai)
        Me.GroupMutasBaru.Controls.Add(Me.DTAkhir)
        Me.GroupMutasBaru.Controls.Add(Me.Label27)
        Me.GroupMutasBaru.Controls.Add(Me.TextKet)
        Me.GroupMutasBaru.Controls.Add(Me.ComboStatusBaru)
        Me.GroupMutasBaru.Controls.Add(Me.Label12)
        Me.GroupMutasBaru.Controls.Add(Me.DTMutasi)
        Me.GroupMutasBaru.Controls.Add(Me.Label11)
        Me.GroupMutasBaru.Controls.Add(Me.ComboDeptBaru)
        Me.GroupMutasBaru.Controls.Add(Me.ComboJabBaru)
        Me.GroupMutasBaru.Controls.Add(Me.ComboAtasan)
        Me.GroupMutasBaru.Controls.Add(Me.Label10)
        Me.GroupMutasBaru.Controls.Add(Me.Label5)
        Me.GroupMutasBaru.Controls.Add(Me.Label6)
        Me.GroupMutasBaru.Controls.Add(Me.TextNamaBaru)
        Me.GroupMutasBaru.Controls.Add(Me.Label7)
        Me.GroupMutasBaru.Controls.Add(Me.TextNikBaru)
        Me.GroupMutasBaru.Controls.Add(Me.Label8)
        Me.GroupMutasBaru.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupMutasBaru.Location = New System.Drawing.Point(28, 263)
        Me.GroupMutasBaru.Name = "GroupMutasBaru"
        Me.GroupMutasBaru.Size = New System.Drawing.Size(752, 325)
        Me.GroupMutasBaru.TabIndex = 375
        Me.GroupMutasBaru.TabStop = False
        Me.GroupMutasBaru.Text = "Baru"
        '
        'CheckHarian
        '
        Me.CheckHarian.AutoSize = True
        Me.CheckHarian.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckHarian.Location = New System.Drawing.Point(637, 23)
        Me.CheckHarian.Name = "CheckHarian"
        Me.CheckHarian.Size = New System.Drawing.Size(81, 24)
        Me.CheckHarian.TabIndex = 385
        Me.CheckHarian.Text = "Harian"
        Me.CheckHarian.UseVisualStyleBackColor = True
        '
        'LabelSampai
        '
        Me.LabelSampai.AutoSize = True
        Me.LabelSampai.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSampai.Location = New System.Drawing.Point(387, 229)
        Me.LabelSampai.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelSampai.Name = "LabelSampai"
        Me.LabelSampai.Size = New System.Drawing.Size(58, 18)
        Me.LabelSampai.TabIndex = 384
        Me.LabelSampai.Text = "Sampai"
        '
        'DTAkhir
        '
        Me.DTAkhir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTAkhir.Location = New System.Drawing.Point(459, 224)
        Me.DTAkhir.Margin = New System.Windows.Forms.Padding(4)
        Me.DTAkhir.Name = "DTAkhir"
        Me.DTAkhir.Size = New System.Drawing.Size(201, 24)
        Me.DTAkhir.TabIndex = 12
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(43, 260)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(83, 18)
        Me.Label27.TabIndex = 382
        Me.Label27.Text = "Keterangan"
        '
        'TextKet
        '
        Me.TextKet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextKet.Location = New System.Drawing.Point(168, 256)
        Me.TextKet.Margin = New System.Windows.Forms.Padding(4)
        Me.TextKet.Multiline = True
        Me.TextKet.Name = "TextKet"
        Me.TextKet.Size = New System.Drawing.Size(550, 62)
        Me.TextKet.TabIndex = 13
        '
        'ComboStatusBaru
        '
        Me.ComboStatusBaru.FormattingEnabled = True
        Me.ComboStatusBaru.Location = New System.Drawing.Point(168, 191)
        Me.ComboStatusBaru.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboStatusBaru.Name = "ComboStatusBaru"
        Me.ComboStatusBaru.Size = New System.Drawing.Size(311, 26)
        Me.ComboStatusBaru.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(43, 197)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 18)
        Me.Label12.TabIndex = 379
        Me.Label12.Text = "Status"
        '
        'DTMutasi
        '
        Me.DTMutasi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTMutasi.Location = New System.Drawing.Point(168, 225)
        Me.DTMutasi.Margin = New System.Windows.Forms.Padding(4)
        Me.DTMutasi.Name = "DTMutasi"
        Me.DTMutasi.Size = New System.Drawing.Size(201, 24)
        Me.DTMutasi.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(43, 229)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 18)
        Me.Label11.TabIndex = 377
        Me.Label11.Text = "Tanggal"
        '
        'ComboDeptBaru
        '
        Me.ComboDeptBaru.FormattingEnabled = True
        Me.ComboDeptBaru.Location = New System.Drawing.Point(168, 122)
        Me.ComboDeptBaru.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboDeptBaru.Name = "ComboDeptBaru"
        Me.ComboDeptBaru.Size = New System.Drawing.Size(550, 26)
        Me.ComboDeptBaru.TabIndex = 8
        '
        'ComboJabBaru
        '
        Me.ComboJabBaru.FormattingEnabled = True
        Me.ComboJabBaru.Location = New System.Drawing.Point(168, 88)
        Me.ComboJabBaru.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboJabBaru.Name = "ComboJabBaru"
        Me.ComboJabBaru.Size = New System.Drawing.Size(550, 26)
        Me.ComboJabBaru.TabIndex = 7
        '
        'ComboAtasan
        '
        Me.ComboAtasan.FormattingEnabled = True
        Me.ComboAtasan.Location = New System.Drawing.Point(168, 157)
        Me.ComboAtasan.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboAtasan.Name = "ComboAtasan"
        Me.ComboAtasan.Size = New System.Drawing.Size(311, 26)
        Me.ComboAtasan.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(43, 163)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 18)
        Me.Label10.TabIndex = 373
        Me.Label10.Text = "Atasan"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(43, 134)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 18)
        Me.Label5.TabIndex = 371
        Me.Label5.Text = "Departemen"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(43, 96)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 18)
        Me.Label6.TabIndex = 369
        Me.Label6.Text = "Jabatan"
        '
        'TextNamaBaru
        '
        Me.TextNamaBaru.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNamaBaru.Location = New System.Drawing.Point(168, 57)
        Me.TextNamaBaru.Margin = New System.Windows.Forms.Padding(4)
        Me.TextNamaBaru.Name = "TextNamaBaru"
        Me.TextNamaBaru.Size = New System.Drawing.Size(340, 26)
        Me.TextNamaBaru.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(43, 61)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 18)
        Me.Label7.TabIndex = 367
        Me.Label7.Text = "Nama"
        '
        'TextNikBaru
        '
        Me.TextNikBaru.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNikBaru.Location = New System.Drawing.Point(168, 26)
        Me.TextNikBaru.Margin = New System.Windows.Forms.Padding(4)
        Me.TextNikBaru.Name = "TextNikBaru"
        Me.TextNikBaru.Size = New System.Drawing.Size(340, 26)
        Me.TextNikBaru.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(43, 29)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(32, 18)
        Me.Label8.TabIndex = 365
        Me.Label8.Text = "NIK"
        '
        'GroupMutasiAwal
        '
        Me.GroupMutasiAwal.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupMutasiAwal.Controls.Add(Me.TextStatus)
        Me.GroupMutasiAwal.Controls.Add(Me.Label13)
        Me.GroupMutasiAwal.Controls.Add(Me.TextDeptLama)
        Me.GroupMutasiAwal.Controls.Add(Me.Label3)
        Me.GroupMutasiAwal.Controls.Add(Me.TextJabLama)
        Me.GroupMutasiAwal.Controls.Add(Me.Label2)
        Me.GroupMutasiAwal.Controls.Add(Me.TextNamaLama)
        Me.GroupMutasiAwal.Controls.Add(Me.Label1)
        Me.GroupMutasiAwal.Controls.Add(Me.TextNikLama)
        Me.GroupMutasiAwal.Controls.Add(Me.Label9)
        Me.GroupMutasiAwal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupMutasiAwal.Location = New System.Drawing.Point(28, 23)
        Me.GroupMutasiAwal.Name = "GroupMutasiAwal"
        Me.GroupMutasiAwal.Size = New System.Drawing.Size(752, 228)
        Me.GroupMutasiAwal.TabIndex = 374
        Me.GroupMutasiAwal.TabStop = False
        Me.GroupMutasiAwal.Text = "Awal"
        '
        'TextStatus
        '
        Me.TextStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextStatus.Location = New System.Drawing.Point(169, 185)
        Me.TextStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.TextStatus.Name = "TextStatus"
        Me.TextStatus.Size = New System.Drawing.Size(340, 26)
        Me.TextStatus.TabIndex = 4
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(43, 189)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 18)
        Me.Label13.TabIndex = 381
        Me.Label13.Text = "Status"
        '
        'TextDeptLama
        '
        Me.TextDeptLama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDeptLama.Location = New System.Drawing.Point(168, 151)
        Me.TextDeptLama.Margin = New System.Windows.Forms.Padding(4)
        Me.TextDeptLama.Name = "TextDeptLama"
        Me.TextDeptLama.Size = New System.Drawing.Size(452, 26)
        Me.TextDeptLama.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(43, 157)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 18)
        Me.Label3.TabIndex = 371
        Me.Label3.Text = "Departemen"
        '
        'TextJabLama
        '
        Me.TextJabLama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextJabLama.Location = New System.Drawing.Point(168, 118)
        Me.TextJabLama.Margin = New System.Windows.Forms.Padding(4)
        Me.TextJabLama.Name = "TextJabLama"
        Me.TextJabLama.Size = New System.Drawing.Size(452, 26)
        Me.TextJabLama.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(43, 124)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 18)
        Me.Label2.TabIndex = 369
        Me.Label2.Text = "Jabatan"
        '
        'TextNamaLama
        '
        Me.TextNamaLama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNamaLama.Location = New System.Drawing.Point(168, 85)
        Me.TextNamaLama.Margin = New System.Windows.Forms.Padding(4)
        Me.TextNamaLama.Name = "TextNamaLama"
        Me.TextNamaLama.Size = New System.Drawing.Size(340, 26)
        Me.TextNamaLama.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 89)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 18)
        Me.Label1.TabIndex = 367
        Me.Label1.Text = "Nama"
        '
        'TextNikLama
        '
        Me.TextNikLama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNikLama.Location = New System.Drawing.Point(168, 54)
        Me.TextNikLama.Margin = New System.Windows.Forms.Padding(4)
        Me.TextNikLama.Name = "TextNikLama"
        Me.TextNikLama.Size = New System.Drawing.Size(340, 26)
        Me.TextNikLama.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(43, 57)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 18)
        Me.Label9.TabIndex = 365
        Me.Label9.Text = "NIK"
        '
        'TabGantiAtasan
        '
        Me.TabGantiAtasan.BackColor = System.Drawing.Color.White
        Me.TabGantiAtasan.Controls.Add(Me.BSimpanAts)
        Me.TabGantiAtasan.Controls.Add(Me.Label16)
        Me.TabGantiAtasan.Controls.Add(Me.Label14)
        Me.TabGantiAtasan.Controls.Add(Me.GroupAtasanBaru)
        Me.TabGantiAtasan.Controls.Add(Me.GroupAtasanAwal)
        Me.TabGantiAtasan.Location = New System.Drawing.Point(4, 29)
        Me.TabGantiAtasan.Name = "TabGantiAtasan"
        Me.TabGantiAtasan.Padding = New System.Windows.Forms.Padding(3)
        Me.TabGantiAtasan.Size = New System.Drawing.Size(808, 676)
        Me.TabGantiAtasan.TabIndex = 1
        Me.TabGantiAtasan.Text = "Pergantian Atasan Karyawan"
        '
        'BSimpanAts
        '
        Me.BSimpanAts.FlatAppearance.BorderSize = 0
        Me.BSimpanAts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BSimpanAts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BSimpanAts.Image = Global.HR_project.My.Resources.Resources.save
        Me.BSimpanAts.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BSimpanAts.Location = New System.Drawing.Point(19, 493)
        Me.BSimpanAts.Margin = New System.Windows.Forms.Padding(4)
        Me.BSimpanAts.Name = "BSimpanAts"
        Me.BSimpanAts.Size = New System.Drawing.Size(91, 70)
        Me.BSimpanAts.TabIndex = 380
        Me.BSimpanAts.Text = "simpan"
        Me.BSimpanAts.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BSimpanAts.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(17, 588)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 18)
        Me.Label16.TabIndex = 379
        Me.Label16.Text = "Note :"
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(17, 606)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(755, 54)
        Me.Label14.TabIndex = 378
        Me.Label14.Text = "Menu ini digunakan untuk pergantian posisi atasan, dimana atasan baru akan mengis" & _
            "i posisi baru, sehingga semua karyawan pada bagian terkait akan berganti atasan " & _
            "secara keseluruhan"
        '
        'GroupAtasanBaru
        '
        Me.GroupAtasanBaru.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupAtasanBaru.Controls.Add(Me.ComboDepAtsBaru)
        Me.GroupAtasanBaru.Controls.Add(Me.ComboJabAtsBaru)
        Me.GroupAtasanBaru.Controls.Add(Me.Label18)
        Me.GroupAtasanBaru.Controls.Add(Me.Label19)
        Me.GroupAtasanBaru.Controls.Add(Me.TextNamaAtsBaru)
        Me.GroupAtasanBaru.Controls.Add(Me.Label20)
        Me.GroupAtasanBaru.Controls.Add(Me.TextNIKAtsBaru)
        Me.GroupAtasanBaru.Controls.Add(Me.Label21)
        Me.GroupAtasanBaru.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupAtasanBaru.Location = New System.Drawing.Point(18, 249)
        Me.GroupAtasanBaru.Name = "GroupAtasanBaru"
        Me.GroupAtasanBaru.Size = New System.Drawing.Size(752, 192)
        Me.GroupAtasanBaru.TabIndex = 377
        Me.GroupAtasanBaru.TabStop = False
        Me.GroupAtasanBaru.Text = "Posisi Baru"
        '
        'ComboDepAtsBaru
        '
        Me.ComboDepAtsBaru.FormattingEnabled = True
        Me.ComboDepAtsBaru.Location = New System.Drawing.Point(168, 129)
        Me.ComboDepAtsBaru.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboDepAtsBaru.Name = "ComboDepAtsBaru"
        Me.ComboDepAtsBaru.Size = New System.Drawing.Size(550, 26)
        Me.ComboDepAtsBaru.TabIndex = 376
        '
        'ComboJabAtsBaru
        '
        Me.ComboJabAtsBaru.FormattingEnabled = True
        Me.ComboJabAtsBaru.Location = New System.Drawing.Point(168, 95)
        Me.ComboJabAtsBaru.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboJabAtsBaru.Name = "ComboJabAtsBaru"
        Me.ComboJabAtsBaru.Size = New System.Drawing.Size(550, 26)
        Me.ComboJabAtsBaru.TabIndex = 375
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(43, 133)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(89, 18)
        Me.Label18.TabIndex = 371
        Me.Label18.Text = "Departemen"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(43, 103)
        Me.Label19.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(60, 18)
        Me.Label19.TabIndex = 369
        Me.Label19.Text = "Jabatan"
        '
        'TextNamaAtsBaru
        '
        Me.TextNamaAtsBaru.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNamaAtsBaru.Location = New System.Drawing.Point(168, 64)
        Me.TextNamaAtsBaru.Margin = New System.Windows.Forms.Padding(4)
        Me.TextNamaAtsBaru.Name = "TextNamaAtsBaru"
        Me.TextNamaAtsBaru.Size = New System.Drawing.Size(340, 26)
        Me.TextNamaAtsBaru.TabIndex = 368
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(43, 68)
        Me.Label20.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(48, 18)
        Me.Label20.TabIndex = 367
        Me.Label20.Text = "Nama"
        '
        'TextNIKAtsBaru
        '
        Me.TextNIKAtsBaru.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNIKAtsBaru.Location = New System.Drawing.Point(168, 33)
        Me.TextNIKAtsBaru.Margin = New System.Windows.Forms.Padding(4)
        Me.TextNIKAtsBaru.Name = "TextNIKAtsBaru"
        Me.TextNIKAtsBaru.Size = New System.Drawing.Size(340, 26)
        Me.TextNIKAtsBaru.TabIndex = 366
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(43, 36)
        Me.Label21.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(32, 18)
        Me.Label21.TabIndex = 365
        Me.Label21.Text = "NIK"
        '
        'GroupAtasanAwal
        '
        Me.GroupAtasanAwal.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupAtasanAwal.Controls.Add(Me.TextDepAtsAwal)
        Me.GroupAtasanAwal.Controls.Add(Me.Label23)
        Me.GroupAtasanAwal.Controls.Add(Me.TextJabAtsAwal)
        Me.GroupAtasanAwal.Controls.Add(Me.Label24)
        Me.GroupAtasanAwal.Controls.Add(Me.TextNamaAtsAwal)
        Me.GroupAtasanAwal.Controls.Add(Me.Label25)
        Me.GroupAtasanAwal.Controls.Add(Me.TextNIKAtsAwal)
        Me.GroupAtasanAwal.Controls.Add(Me.Label26)
        Me.GroupAtasanAwal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupAtasanAwal.Location = New System.Drawing.Point(18, 28)
        Me.GroupAtasanAwal.Name = "GroupAtasanAwal"
        Me.GroupAtasanAwal.Size = New System.Drawing.Size(752, 201)
        Me.GroupAtasanAwal.TabIndex = 376
        Me.GroupAtasanAwal.TabStop = False
        Me.GroupAtasanAwal.Text = "Posisi Awal"
        '
        'TextDepAtsAwal
        '
        Me.TextDepAtsAwal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDepAtsAwal.Location = New System.Drawing.Point(168, 151)
        Me.TextDepAtsAwal.Margin = New System.Windows.Forms.Padding(4)
        Me.TextDepAtsAwal.Name = "TextDepAtsAwal"
        Me.TextDepAtsAwal.Size = New System.Drawing.Size(452, 26)
        Me.TextDepAtsAwal.TabIndex = 372
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(43, 157)
        Me.Label23.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(89, 18)
        Me.Label23.TabIndex = 371
        Me.Label23.Text = "Departemen"
        '
        'TextJabAtsAwal
        '
        Me.TextJabAtsAwal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextJabAtsAwal.Location = New System.Drawing.Point(168, 118)
        Me.TextJabAtsAwal.Margin = New System.Windows.Forms.Padding(4)
        Me.TextJabAtsAwal.Name = "TextJabAtsAwal"
        Me.TextJabAtsAwal.Size = New System.Drawing.Size(452, 26)
        Me.TextJabAtsAwal.TabIndex = 370
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(43, 124)
        Me.Label24.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(60, 18)
        Me.Label24.TabIndex = 369
        Me.Label24.Text = "Jabatan"
        '
        'TextNamaAtsAwal
        '
        Me.TextNamaAtsAwal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNamaAtsAwal.Location = New System.Drawing.Point(168, 85)
        Me.TextNamaAtsAwal.Margin = New System.Windows.Forms.Padding(4)
        Me.TextNamaAtsAwal.Name = "TextNamaAtsAwal"
        Me.TextNamaAtsAwal.Size = New System.Drawing.Size(340, 26)
        Me.TextNamaAtsAwal.TabIndex = 368
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(43, 89)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(48, 18)
        Me.Label25.TabIndex = 367
        Me.Label25.Text = "Nama"
        '
        'TextNIKAtsAwal
        '
        Me.TextNIKAtsAwal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNIKAtsAwal.Location = New System.Drawing.Point(168, 54)
        Me.TextNIKAtsAwal.Margin = New System.Windows.Forms.Padding(4)
        Me.TextNIKAtsAwal.Name = "TextNIKAtsAwal"
        Me.TextNIKAtsAwal.Size = New System.Drawing.Size(340, 26)
        Me.TextNIKAtsAwal.TabIndex = 366
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(43, 57)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(32, 18)
        Me.Label26.TabIndex = 365
        Me.Label26.Text = "NIK"
        '
        'WorkerCheckData
        '
        Me.WorkerCheckData.WorkerReportsProgress = True
        Me.WorkerCheckData.WorkerSupportsCancellation = True
        '
        'WorkerGantiAtasan
        '
        Me.WorkerGantiAtasan.WorkerReportsProgress = True
        Me.WorkerGantiAtasan.WorkerSupportsCancellation = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(854, 135)
        Me.Label28.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(112, 18)
        Me.Label28.TabIndex = 376
        Me.Label28.Text = "Jenis Karyawan"
        '
        'ComboKary
        '
        Me.ComboKary.FormattingEnabled = True
        Me.ComboKary.Location = New System.Drawing.Point(978, 138)
        Me.ComboKary.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboKary.Name = "ComboKary"
        Me.ComboKary.Size = New System.Drawing.Size(321, 24)
        Me.ComboKary.TabIndex = 375
        '
        'FormMutasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1827, 923)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.ComboKary)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.combo_dept)
        Me.Controls.Add(Me.Text_pencarian)
        Me.Controls.Add(Me.GridTampilData)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "FormMutasi"
        Me.Text = "Form Mutasi"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridTampilData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabMutasiKary.ResumeLayout(False)
        Me.TabMutasiKary.PerformLayout()
        Me.GroupMutasBaru.ResumeLayout(False)
        Me.GroupMutasBaru.PerformLayout()
        Me.GroupMutasiAwal.ResumeLayout(False)
        Me.GroupMutasiAwal.PerformLayout()
        Me.TabGantiAtasan.ResumeLayout(False)
        Me.TabGantiAtasan.PerformLayout()
        Me.GroupAtasanBaru.ResumeLayout(False)
        Me.GroupAtasanBaru.PerformLayout()
        Me.GroupAtasanAwal.ResumeLayout(False)
        Me.GroupAtasanAwal.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents combo_dept As System.Windows.Forms.ComboBox
    Friend WithEvents Text_pencarian As System.Windows.Forms.TextBox
    Friend WithEvents GridTampilData As System.Windows.Forms.DataGridView
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabMutasiKary As System.Windows.Forms.TabPage
    Friend WithEvents GroupMutasBaru As System.Windows.Forms.GroupBox
    Friend WithEvents ComboStatusBaru As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents DTMutasi As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ComboDeptBaru As System.Windows.Forms.ComboBox
    Friend WithEvents ComboJabBaru As System.Windows.Forms.ComboBox
    Friend WithEvents ComboAtasan As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextNamaBaru As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextNikBaru As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupMutasiAwal As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextDeptLama As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextJabLama As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextNamaLama As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextNikLama As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TabGantiAtasan As System.Windows.Forms.TabPage
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupAtasanBaru As System.Windows.Forms.GroupBox
    Friend WithEvents ComboDepAtsBaru As System.Windows.Forms.ComboBox
    Friend WithEvents ComboJabAtsBaru As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TextNamaAtsBaru As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TextNIKAtsBaru As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents GroupAtasanAwal As System.Windows.Forms.GroupBox
    Friend WithEvents TextDepAtsAwal As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TextJabAtsAwal As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TextNamaAtsAwal As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TextNIKAtsAwal As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents BSimpanMutasi As System.Windows.Forms.Button
    Friend WithEvents BSimpanAts As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TextStatus As System.Windows.Forms.TextBox
    Friend WithEvents WorkerCheckData As System.ComponentModel.BackgroundWorker
    Friend WithEvents WorkerGantiAtasan As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TextKet As System.Windows.Forms.TextBox
    Friend WithEvents LabelSampai As System.Windows.Forms.Label
    Friend WithEvents DTAkhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckHarian As System.Windows.Forms.CheckBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents ComboKary As System.Windows.Forms.ComboBox
End Class
