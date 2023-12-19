<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTelatMasukKerja
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
        Me.Text_pencarian = New System.Windows.Forms.TextBox()
        Me.Grid_karyawan = New System.Windows.Forms.DataGridView()
        Me.Text_hari = New System.Windows.Forms.TextBox()
        Me.Button_simpan = New System.Windows.Forms.Button()
        Me.Text_alasan = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DT_tanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Text_dept = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Text_jabatan = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Text_nama = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Text_nik = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Text_telat = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Combo_depart = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button_baru = New System.Windows.Forms.Button()
        Me.Buttonkeluar = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        CType(Me.Grid_karyawan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Text_pencarian
        '
        Me.Text_pencarian.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_pencarian.Location = New System.Drawing.Point(708, 153)
        Me.Text_pencarian.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_pencarian.Name = "Text_pencarian"
        Me.Text_pencarian.Size = New System.Drawing.Size(839, 26)
        Me.Text_pencarian.TabIndex = 273
        '
        'Grid_karyawan
        '
        Me.Grid_karyawan.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.Grid_karyawan.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grid_karyawan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid_karyawan.Location = New System.Drawing.Point(708, 190)
        Me.Grid_karyawan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Grid_karyawan.Name = "Grid_karyawan"
        Me.Grid_karyawan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid_karyawan.Size = New System.Drawing.Size(839, 484)
        Me.Grid_karyawan.TabIndex = 272
        '
        'Text_hari
        '
        Me.Text_hari.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_hari.Location = New System.Drawing.Point(168, 316)
        Me.Text_hari.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_hari.Name = "Text_hari"
        Me.Text_hari.Size = New System.Drawing.Size(140, 26)
        Me.Text_hari.TabIndex = 271
        '
        'Button_simpan
        '
        Me.Button_simpan.BackColor = System.Drawing.Color.Transparent
        Me.Button_simpan.FlatAppearance.BorderSize = 0
        Me.Button_simpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_simpan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_simpan.Image = Global.HR_project.My.Resources.Resources.save
        Me.Button_simpan.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_simpan.Location = New System.Drawing.Point(164, 603)
        Me.Button_simpan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button_simpan.Name = "Button_simpan"
        Me.Button_simpan.Size = New System.Drawing.Size(91, 70)
        Me.Button_simpan.TabIndex = 269
        Me.Button_simpan.Text = "simpan"
        Me.Button_simpan.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_simpan.UseVisualStyleBackColor = False
        '
        'Text_alasan
        '
        Me.Text_alasan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_alasan.Location = New System.Drawing.Point(168, 382)
        Me.Text_alasan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_alasan.Multiline = True
        Me.Text_alasan.Name = "Text_alasan"
        Me.Text_alasan.Size = New System.Drawing.Size(357, 74)
        Me.Text_alasan.TabIndex = 268
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(45, 390)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(52, 18)
        Me.Label15.TabIndex = 267
        Me.Label15.Text = "Alasan"
        '
        'DT_tanggal
        '
        Me.DT_tanggal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_tanggal.Location = New System.Drawing.Point(395, 318)
        Me.DT_tanggal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DT_tanggal.Name = "DT_tanggal"
        Me.DT_tanggal.Size = New System.Drawing.Size(201, 24)
        Me.DT_tanggal.TabIndex = 259
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(317, 320)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 18)
        Me.Label11.TabIndex = 258
        Me.Label11.Text = "Tanggal"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(43, 350)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 18)
        Me.Label7.TabIndex = 254
        Me.Label7.Text = "Waktu"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(41, 320)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 18)
        Me.Label5.TabIndex = 251
        Me.Label5.Text = "Hari"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(39, 265)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(510, 36)
        Me.Label4.TabIndex = 250
        Me.Label4.Text = "Menyatakan dengan sebenarnya bahwa saya telah melakukan keterlambatan" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "masuk kerj" & _
            "a pada :"
        '
        'Text_dept
        '
        Me.Text_dept.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_dept.Location = New System.Drawing.Point(164, 217)
        Me.Text_dept.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_dept.Name = "Text_dept"
        Me.Text_dept.Size = New System.Drawing.Size(340, 26)
        Me.Text_dept.TabIndex = 249
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(39, 228)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 18)
        Me.Label3.TabIndex = 248
        Me.Label3.Text = "Departemen"
        '
        'Text_jabatan
        '
        Me.Text_jabatan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_jabatan.Location = New System.Drawing.Point(164, 183)
        Me.Text_jabatan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_jabatan.Name = "Text_jabatan"
        Me.Text_jabatan.Size = New System.Drawing.Size(340, 26)
        Me.Text_jabatan.TabIndex = 247
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(39, 190)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 18)
        Me.Label2.TabIndex = 246
        Me.Label2.Text = "Jabatan"
        '
        'Text_nama
        '
        Me.Text_nama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_nama.Location = New System.Drawing.Point(164, 150)
        Me.Text_nama.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_nama.Name = "Text_nama"
        Me.Text_nama.Size = New System.Drawing.Size(340, 26)
        Me.Text_nama.TabIndex = 245
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 155)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 18)
        Me.Label1.TabIndex = 244
        Me.Label1.Text = "Nama"
        '
        'Text_nik
        '
        Me.Text_nik.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_nik.Location = New System.Drawing.Point(164, 119)
        Me.Text_nik.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_nik.Name = "Text_nik"
        Me.Text_nik.Size = New System.Drawing.Size(340, 26)
        Me.Text_nik.TabIndex = 243
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(39, 123)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 18)
        Me.Label9.TabIndex = 242
        Me.Label9.Text = "NIK"
        '
        'Text_telat
        '
        Me.Text_telat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_telat.Location = New System.Drawing.Point(168, 348)
        Me.Text_telat.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_telat.Name = "Text_telat"
        Me.Text_telat.Size = New System.Drawing.Size(51, 26)
        Me.Text_telat.TabIndex = 274
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(228, 352)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 18)
        Me.Label8.TabIndex = 275
        Me.Label8.Text = "menit"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(704, 121)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 18)
        Me.Label14.TabIndex = 296
        Me.Label14.Text = "Departemen"
        '
        'Combo_depart
        '
        Me.Combo_depart.FormattingEnabled = True
        Me.Combo_depart.Location = New System.Drawing.Point(808, 117)
        Me.Combo_depart.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Combo_depart.Name = "Combo_depart"
        Me.Combo_depart.Size = New System.Drawing.Size(311, 24)
        Me.Combo_depart.TabIndex = 295
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label6.Location = New System.Drawing.Point(12, 21)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 50)
        Me.Label6.TabIndex = 325
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label10.Location = New System.Drawing.Point(25, 21)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(579, 52)
        Me.Label10.TabIndex = 324
        Me.Label10.Text = "FORM TELAT MASUK KERJA"
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
        'Button_baru
        '
        Me.Button_baru.FlatAppearance.BorderSize = 0
        Me.Button_baru.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_baru.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_baru.Image = Global.HR_project.My.Resources.Resources._new
        Me.Button_baru.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_baru.Location = New System.Drawing.Point(45, 603)
        Me.Button_baru.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button_baru.Name = "Button_baru"
        Me.Button_baru.Size = New System.Drawing.Size(91, 70)
        Me.Button_baru.TabIndex = 326
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
        Me.Buttonkeluar.Location = New System.Drawing.Point(285, 603)
        Me.Buttonkeluar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Buttonkeluar.Name = "Buttonkeluar"
        Me.Buttonkeluar.Size = New System.Drawing.Size(91, 70)
        Me.Buttonkeluar.TabIndex = 350
        Me.Buttonkeluar.Text = "keluar"
        Me.Buttonkeluar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Buttonkeluar.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.HR_project.My.Resources.Resources.find_21
        Me.PictureBox3.Location = New System.Drawing.Point(1520, 148)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(27, 25)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 351
        Me.PictureBox3.TabStop = False
        '
        'FormTelatMasukKerja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1827, 923)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Buttonkeluar)
        Me.Controls.Add(Me.Button_baru)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Combo_depart)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Text_telat)
        Me.Controls.Add(Me.Text_pencarian)
        Me.Controls.Add(Me.Grid_karyawan)
        Me.Controls.Add(Me.Text_hari)
        Me.Controls.Add(Me.Button_simpan)
        Me.Controls.Add(Me.Text_alasan)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.DT_tanggal)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Text_dept)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Text_jabatan)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Text_nama)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Text_nik)
        Me.Controls.Add(Me.Label9)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormTelatMasukKerja"
        Me.Text = "FormTelatMasukKerja"
        CType(Me.Grid_karyawan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Text_pencarian As System.Windows.Forms.TextBox
    Friend WithEvents Grid_karyawan As System.Windows.Forms.DataGridView
    Friend WithEvents Text_hari As System.Windows.Forms.TextBox
    Friend WithEvents Button_simpan As System.Windows.Forms.Button
    Friend WithEvents Text_alasan As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DT_tanggal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Text_dept As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Text_jabatan As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Text_nama As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Text_nik As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Text_telat As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Combo_depart As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button_baru As System.Windows.Forms.Button
    Friend WithEvents Buttonkeluar As System.Windows.Forms.Button
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
End Class
