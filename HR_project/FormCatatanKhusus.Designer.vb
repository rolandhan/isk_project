<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCatatanKhusus
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
        Me.Text_dept = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Text_jabatan = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Text_nama = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Text_nik = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Grid_karyawan = New System.Windows.Forms.DataGridView()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Combo_depart = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPgl = New System.Windows.Forms.TabPage()
        Me.DT_tgl = New System.Windows.Forms.DateTimePicker()
        Me.Text_catatan = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button_simpan = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.combo_jenis = New System.Windows.Forms.ComboBox()
        Me.Tabcovid = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Text_ketcov = New System.Windows.Forms.TextBox()
        Me.B_simpanIM = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Combo_pcr = New System.Windows.Forms.ComboBox()
        Me.Combo_anti = New System.Windows.Forms.ComboBox()
        Me.Combo_rapid = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DT_selesai = New System.Windows.Forms.DateTimePicker()
        Me.DT_mulai = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Button_baru = New System.Windows.Forms.Button()
        Me.Buttonkeluar = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Text_pencarian = New System.Windows.Forms.TextBox()
        CType(Me.Grid_karyawan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPgl.SuspendLayout()
        Me.Tabcovid.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Text_dept
        '
        Me.Text_dept.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_dept.Location = New System.Drawing.Point(155, 215)
        Me.Text_dept.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_dept.Name = "Text_dept"
        Me.Text_dept.Size = New System.Drawing.Size(340, 26)
        Me.Text_dept.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 219)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 18)
        Me.Label3.TabIndex = 256
        Me.Label3.Text = "Departemen"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Text_jabatan
        '
        Me.Text_jabatan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_jabatan.Location = New System.Drawing.Point(155, 182)
        Me.Text_jabatan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_jabatan.Name = "Text_jabatan"
        Me.Text_jabatan.Size = New System.Drawing.Size(340, 26)
        Me.Text_jabatan.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 188)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 18)
        Me.Label2.TabIndex = 254
        Me.Label2.Text = "Jabatan"
        '
        'Text_nama
        '
        Me.Text_nama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_nama.Location = New System.Drawing.Point(155, 146)
        Me.Text_nama.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_nama.Name = "Text_nama"
        Me.Text_nama.Size = New System.Drawing.Size(340, 26)
        Me.Text_nama.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 151)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 18)
        Me.Label1.TabIndex = 252
        Me.Label1.Text = "Nama"
        '
        'Text_nik
        '
        Me.Text_nik.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_nik.Location = New System.Drawing.Point(155, 111)
        Me.Text_nik.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_nik.Name = "Text_nik"
        Me.Text_nik.Size = New System.Drawing.Size(340, 26)
        Me.Text_nik.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 114)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 18)
        Me.Label9.TabIndex = 250
        Me.Label9.Text = "NIK"
        '
        'Grid_karyawan
        '
        Me.Grid_karyawan.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.Grid_karyawan.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grid_karyawan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid_karyawan.Location = New System.Drawing.Point(868, 182)
        Me.Grid_karyawan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Grid_karyawan.Name = "Grid_karyawan"
        Me.Grid_karyawan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid_karyawan.Size = New System.Drawing.Size(923, 420)
        Me.Grid_karyawan.TabIndex = 267
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(864, 114)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 18)
        Me.Label14.TabIndex = 296
        Me.Label14.Text = "Departemen"
        '
        'Combo_depart
        '
        Me.Combo_depart.FormattingEnabled = True
        Me.Combo_depart.Location = New System.Drawing.Point(972, 111)
        Me.Combo_depart.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Combo_depart.Name = "Combo_depart"
        Me.Combo_depart.Size = New System.Drawing.Size(311, 24)
        Me.Combo_depart.TabIndex = 295
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label8.Location = New System.Drawing.Point(12, 21)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 50)
        Me.Label8.TabIndex = 325
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label10.Location = New System.Drawing.Point(25, 21)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(517, 52)
        Me.Label10.TabIndex = 324
        Me.Label10.Text = "FORM CATATAN KHUSUS"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPgl)
        Me.TabControl1.Controls.Add(Me.Tabcovid)
        Me.TabControl1.Location = New System.Drawing.Point(23, 258)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(827, 447)
        Me.TabControl1.TabIndex = 326
        '
        'TabPgl
        '
        Me.TabPgl.Controls.Add(Me.DT_tgl)
        Me.TabPgl.Controls.Add(Me.Text_catatan)
        Me.TabPgl.Controls.Add(Me.Label6)
        Me.TabPgl.Controls.Add(Me.Button_simpan)
        Me.TabPgl.Controls.Add(Me.Label5)
        Me.TabPgl.Controls.Add(Me.Label4)
        Me.TabPgl.Controls.Add(Me.combo_jenis)
        Me.TabPgl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPgl.Location = New System.Drawing.Point(4, 25)
        Me.TabPgl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPgl.Name = "TabPgl"
        Me.TabPgl.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPgl.Size = New System.Drawing.Size(819, 418)
        Me.TabPgl.TabIndex = 0
        Me.TabPgl.Text = "Pemanggilan Khusus"
        Me.TabPgl.UseVisualStyleBackColor = True
        '
        'DT_tgl
        '
        Me.DT_tgl.Location = New System.Drawing.Point(163, 57)
        Me.DT_tgl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DT_tgl.Name = "DT_tgl"
        Me.DT_tgl.Size = New System.Drawing.Size(187, 24)
        Me.DT_tgl.TabIndex = 4
        '
        'Text_catatan
        '
        Me.Text_catatan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_catatan.Location = New System.Drawing.Point(164, 92)
        Me.Text_catatan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_catatan.Multiline = True
        Me.Text_catatan.Name = "Text_catatan"
        Me.Text_catatan.Size = New System.Drawing.Size(623, 109)
        Me.Text_catatan.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(28, 89)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 18)
        Me.Label6.TabIndex = 272
        Me.Label6.Text = "Catatan"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button_simpan
        '
        Me.Button_simpan.FlatAppearance.BorderSize = 0
        Me.Button_simpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_simpan.Image = Global.HR_project.My.Resources.Resources.save
        Me.Button_simpan.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_simpan.Location = New System.Drawing.Point(28, 322)
        Me.Button_simpan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button_simpan.Name = "Button_simpan"
        Me.Button_simpan.Size = New System.Drawing.Size(91, 70)
        Me.Button_simpan.TabIndex = 270
        Me.Button_simpan.Text = "simpan"
        Me.Button_simpan.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_simpan.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(25, 62)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 18)
        Me.Label5.TabIndex = 269
        Me.Label5.Text = "Tanggal "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 23)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 18)
        Me.Label4.TabIndex = 268
        Me.Label4.Text = "Jenis Catatan"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'combo_jenis
        '
        Me.combo_jenis.FormattingEnabled = True
        Me.combo_jenis.Location = New System.Drawing.Point(164, 20)
        Me.combo_jenis.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.combo_jenis.Name = "combo_jenis"
        Me.combo_jenis.Size = New System.Drawing.Size(340, 26)
        Me.combo_jenis.TabIndex = 3
        '
        'Tabcovid
        '
        Me.Tabcovid.Controls.Add(Me.GroupBox2)
        Me.Tabcovid.Controls.Add(Me.B_simpanIM)
        Me.Tabcovid.Controls.Add(Me.GroupBox3)
        Me.Tabcovid.Controls.Add(Me.GroupBox1)
        Me.Tabcovid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tabcovid.Location = New System.Drawing.Point(4, 25)
        Me.Tabcovid.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tabcovid.Name = "Tabcovid"
        Me.Tabcovid.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tabcovid.Size = New System.Drawing.Size(819, 418)
        Me.Tabcovid.TabIndex = 1
        Me.Tabcovid.Text = "Isolasi Mandiri (COVID)"
        Me.Tabcovid.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Text_ketcov)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(24, 175)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(765, 146)
        Me.GroupBox2.TabIndex = 273
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Keterangan"
        '
        'Text_ketcov
        '
        Me.Text_ketcov.Location = New System.Drawing.Point(21, 30)
        Me.Text_ketcov.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_ketcov.Multiline = True
        Me.Text_ketcov.Name = "Text_ketcov"
        Me.Text_ketcov.Size = New System.Drawing.Size(727, 99)
        Me.Text_ketcov.TabIndex = 0
        '
        'B_simpanIM
        '
        Me.B_simpanIM.FlatAppearance.BorderSize = 0
        Me.B_simpanIM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.B_simpanIM.Image = Global.HR_project.My.Resources.Resources.save
        Me.B_simpanIM.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.B_simpanIM.Location = New System.Drawing.Point(35, 329)
        Me.B_simpanIM.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.B_simpanIM.Name = "B_simpanIM"
        Me.B_simpanIM.Size = New System.Drawing.Size(91, 70)
        Me.B_simpanIM.TabIndex = 226
        Me.B_simpanIM.Text = "simpan"
        Me.B_simpanIM.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.B_simpanIM.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.Combo_pcr)
        Me.GroupBox3.Controls.Add(Me.Combo_anti)
        Me.GroupBox3.Controls.Add(Me.Combo_rapid)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Location = New System.Drawing.Point(396, 31)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(393, 144)
        Me.GroupBox3.TabIndex = 225
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Hasil Test"
        '
        'Combo_pcr
        '
        Me.Combo_pcr.FormattingEnabled = True
        Me.Combo_pcr.Location = New System.Drawing.Point(139, 97)
        Me.Combo_pcr.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Combo_pcr.Name = "Combo_pcr"
        Me.Combo_pcr.Size = New System.Drawing.Size(237, 26)
        Me.Combo_pcr.TabIndex = 230
        '
        'Combo_anti
        '
        Me.Combo_anti.FormattingEnabled = True
        Me.Combo_anti.Location = New System.Drawing.Point(139, 60)
        Me.Combo_anti.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Combo_anti.Name = "Combo_anti"
        Me.Combo_anti.Size = New System.Drawing.Size(237, 26)
        Me.Combo_anti.TabIndex = 229
        '
        'Combo_rapid
        '
        Me.Combo_rapid.FormattingEnabled = True
        Me.Combo_rapid.Location = New System.Drawing.Point(139, 25)
        Me.Combo_rapid.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Combo_rapid.Name = "Combo_rapid"
        Me.Combo_rapid.Size = New System.Drawing.Size(237, 26)
        Me.Combo_rapid.TabIndex = 228
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(27, 107)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 18)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "PCR"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(23, 69)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 18)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Antigen"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(23, 32)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 18)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Rapid"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.DT_selesai)
        Me.GroupBox1.Controls.Add(Me.DT_mulai)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 31)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(364, 144)
        Me.GroupBox1.TabIndex = 224
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Isolasi Mandiri"
        '
        'DT_selesai
        '
        Me.DT_selesai.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_selesai.Location = New System.Drawing.Point(161, 68)
        Me.DT_selesai.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DT_selesai.Name = "DT_selesai"
        Me.DT_selesai.Size = New System.Drawing.Size(177, 24)
        Me.DT_selesai.TabIndex = 210
        '
        'DT_mulai
        '
        Me.DT_mulai.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_mulai.Location = New System.Drawing.Point(161, 32)
        Me.DT_mulai.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DT_mulai.Name = "DT_mulai"
        Me.DT_mulai.Size = New System.Drawing.Size(177, 24)
        Me.DT_mulai.TabIndex = 209
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(17, 74)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 18)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Tanggal Selesai"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(17, 39)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(99, 18)
        Me.Label15.TabIndex = 26
        Me.Label15.Text = "Tanggal Mulai"
        '
        'Button_baru
        '
        Me.Button_baru.FlatAppearance.BorderSize = 0
        Me.Button_baru.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_baru.Image = Global.HR_project.My.Resources.Resources._new
        Me.Button_baru.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_baru.Location = New System.Drawing.Point(868, 630)
        Me.Button_baru.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button_baru.Name = "Button_baru"
        Me.Button_baru.Size = New System.Drawing.Size(91, 70)
        Me.Button_baru.TabIndex = 271
        Me.Button_baru.Text = "baru"
        Me.Button_baru.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_baru.UseVisualStyleBackColor = True
        '
        'Buttonkeluar
        '
        Me.Buttonkeluar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Buttonkeluar.FlatAppearance.BorderSize = 0
        Me.Buttonkeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buttonkeluar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buttonkeluar.Image = Global.HR_project.My.Resources.Resources.logout
        Me.Buttonkeluar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Buttonkeluar.Location = New System.Drawing.Point(988, 630)
        Me.Buttonkeluar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Buttonkeluar.Name = "Buttonkeluar"
        Me.Buttonkeluar.Size = New System.Drawing.Size(91, 70)
        Me.Buttonkeluar.TabIndex = 352
        Me.Buttonkeluar.Text = "keluar"
        Me.Buttonkeluar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Buttonkeluar.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox2.Location = New System.Drawing.Point(3, 748)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1823, 166)
        Me.PictureBox2.TabIndex = 323
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox1.Location = New System.Drawing.Point(3, 9)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1823, 80)
        Me.PictureBox1.TabIndex = 322
        Me.PictureBox1.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.HR_project.My.Resources.Resources.find_21
        Me.PictureBox3.Location = New System.Drawing.Point(1775, 148)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(13, 25)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 354
        Me.PictureBox3.TabStop = False
        '
        'Text_pencarian
        '
        Me.Text_pencarian.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_pencarian.Location = New System.Drawing.Point(868, 146)
        Me.Text_pencarian.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_pencarian.Name = "Text_pencarian"
        Me.Text_pencarian.Size = New System.Drawing.Size(921, 26)
        Me.Text_pencarian.TabIndex = 353
        '
        'FormCatatanKhusus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1827, 923)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Text_pencarian)
        Me.Controls.Add(Me.Buttonkeluar)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button_baru)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Combo_depart)
        Me.Controls.Add(Me.Grid_karyawan)
        Me.Controls.Add(Me.Text_dept)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Text_jabatan)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Text_nama)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Text_nik)
        Me.Controls.Add(Me.Label9)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormCatatanKhusus"
        Me.Text = "Form Panggilan"
        CType(Me.Grid_karyawan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPgl.ResumeLayout(False)
        Me.TabPgl.PerformLayout()
        Me.Tabcovid.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Text_dept As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Text_jabatan As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Text_nama As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Text_nik As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Grid_karyawan As System.Windows.Forms.DataGridView
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Combo_depart As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPgl As System.Windows.Forms.TabPage
    Friend WithEvents Text_catatan As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button_baru As System.Windows.Forms.Button
    Friend WithEvents Button_simpan As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents combo_jenis As System.Windows.Forms.ComboBox
    Friend WithEvents Tabcovid As System.Windows.Forms.TabPage
    Friend WithEvents B_simpanIM As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Combo_pcr As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_anti As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_rapid As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DT_selesai As System.Windows.Forms.DateTimePicker
    Friend WithEvents DT_mulai As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Text_ketcov As System.Windows.Forms.TextBox
    Friend WithEvents DT_tgl As System.Windows.Forms.DateTimePicker
    Friend WithEvents Buttonkeluar As System.Windows.Forms.Button
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Text_pencarian As System.Windows.Forms.TextBox
End Class
