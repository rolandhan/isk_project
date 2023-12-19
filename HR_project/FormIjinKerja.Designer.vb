<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormIjinKerja
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
        Me.Text_alasan = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DT_tanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Text_dept = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Text_jabatan = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Text_nama = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Text_nik = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Radio_kembali = New System.Windows.Forms.RadioButton()
        Me.Radio_tidak = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Masked_jam = New System.Windows.Forms.MaskedTextBox()
        Me.DT_tanggaldari = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DT_tanggalke = New System.Windows.Forms.DateTimePicker()
        Me.group_periode = New System.Windows.Forms.GroupBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Combo_depart = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Masked_kembali = New System.Windows.Forms.MaskedTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Buttonkeluar = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button_baru = New System.Windows.Forms.Button()
        Me.Button_simpan = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        CType(Me.Grid_karyawan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.group_periode.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Text_pencarian
        '
        Me.Text_pencarian.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_pencarian.Location = New System.Drawing.Point(532, 157)
        Me.Text_pencarian.Name = "Text_pencarian"
        Me.Text_pencarian.Size = New System.Drawing.Size(780, 22)
        Me.Text_pencarian.TabIndex = 274
        '
        'Grid_karyawan
        '
        Me.Grid_karyawan.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.Grid_karyawan.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grid_karyawan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid_karyawan.Location = New System.Drawing.Point(532, 189)
        Me.Grid_karyawan.Name = "Grid_karyawan"
        Me.Grid_karyawan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid_karyawan.Size = New System.Drawing.Size(780, 434)
        Me.Grid_karyawan.TabIndex = 273
        '
        'Text_hari
        '
        Me.Text_hari.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_hari.Location = New System.Drawing.Point(134, 253)
        Me.Text_hari.Name = "Text_hari"
        Me.Text_hari.Size = New System.Drawing.Size(106, 22)
        Me.Text_hari.TabIndex = 272
        '
        'Text_alasan
        '
        Me.Text_alasan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_alasan.Location = New System.Drawing.Point(133, 335)
        Me.Text_alasan.Multiline = True
        Me.Text_alasan.Name = "Text_alasan"
        Me.Text_alasan.Size = New System.Drawing.Size(269, 61)
        Me.Text_alasan.TabIndex = 269
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(42, 335)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(44, 15)
        Me.Label15.TabIndex = 268
        Me.Label15.Text = "Alasan"
        '
        'DT_tanggal
        '
        Me.DT_tanggal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_tanggal.Location = New System.Drawing.Point(304, 254)
        Me.DT_tanggal.Name = "DT_tanggal"
        Me.DT_tanggal.Size = New System.Drawing.Size(152, 21)
        Me.DT_tanggal.TabIndex = 260
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(246, 256)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 15)
        Me.Label11.TabIndex = 259
        Me.Label11.Text = "Tanggal"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(41, 286)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 15)
        Me.Label6.TabIndex = 252
        Me.Label6.Text = "Tujuan"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(39, 256)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 15)
        Me.Label5.TabIndex = 251
        Me.Label5.Text = "Hari"
        '
        'Text_dept
        '
        Me.Text_dept.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_dept.Location = New System.Drawing.Point(133, 186)
        Me.Text_dept.Name = "Text_dept"
        Me.Text_dept.Size = New System.Drawing.Size(256, 22)
        Me.Text_dept.TabIndex = 249
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(39, 195)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 15)
        Me.Label3.TabIndex = 248
        Me.Label3.Text = "Departemen"
        '
        'Text_jabatan
        '
        Me.Text_jabatan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_jabatan.Location = New System.Drawing.Point(133, 159)
        Me.Text_jabatan.Name = "Text_jabatan"
        Me.Text_jabatan.Size = New System.Drawing.Size(256, 22)
        Me.Text_jabatan.TabIndex = 247
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(39, 164)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 15)
        Me.Label2.TabIndex = 246
        Me.Label2.Text = "Jabatan"
        '
        'Text_nama
        '
        Me.Text_nama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_nama.Location = New System.Drawing.Point(133, 132)
        Me.Text_nama.Name = "Text_nama"
        Me.Text_nama.Size = New System.Drawing.Size(256, 22)
        Me.Text_nama.TabIndex = 245
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 244
        Me.Label1.Text = "Nama"
        '
        'Text_nik
        '
        Me.Text_nik.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_nik.Location = New System.Drawing.Point(133, 107)
        Me.Text_nik.Name = "Text_nik"
        Me.Text_nik.Size = New System.Drawing.Size(256, 22)
        Me.Text_nik.TabIndex = 243
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(39, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(27, 15)
        Me.Label9.TabIndex = 242
        Me.Label9.Text = "NIK"
        '
        'Radio_kembali
        '
        Me.Radio_kembali.AutoSize = True
        Me.Radio_kembali.Location = New System.Drawing.Point(134, 285)
        Me.Radio_kembali.Name = "Radio_kembali"
        Me.Radio_kembali.Size = New System.Drawing.Size(50, 17)
        Me.Radio_kembali.TabIndex = 275
        Me.Radio_kembali.TabStop = True
        Me.Radio_kembali.Text = "1 jam"
        Me.Radio_kembali.UseVisualStyleBackColor = True
        '
        'Radio_tidak
        '
        Me.Radio_tidak.AutoSize = True
        Me.Radio_tidak.Location = New System.Drawing.Point(230, 285)
        Me.Radio_tidak.Name = "Radio_tidak"
        Me.Radio_tidak.Size = New System.Drawing.Size(93, 17)
        Me.Radio_tidak.TabIndex = 276
        Me.Radio_tidak.TabStop = True
        Me.Radio_tidak.Text = "Setengah Hari"
        Me.Radio_tidak.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(41, 310)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 15)
        Me.Label4.TabIndex = 277
        Me.Label4.Text = "Jam"
        '
        'Masked_jam
        '
        Me.Masked_jam.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Masked_jam.Location = New System.Drawing.Point(134, 308)
        Me.Masked_jam.Mask = "00:00"
        Me.Masked_jam.Name = "Masked_jam"
        Me.Masked_jam.Size = New System.Drawing.Size(46, 21)
        Me.Masked_jam.TabIndex = 278
        Me.Masked_jam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Masked_jam.ValidatingType = GetType(Date)
        '
        'DT_tanggaldari
        '
        Me.DT_tanggaldari.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_tanggaldari.Location = New System.Drawing.Point(51, 20)
        Me.DT_tanggaldari.Name = "DT_tanggaldari"
        Me.DT_tanggaldari.Size = New System.Drawing.Size(152, 21)
        Me.DT_tanggaldari.TabIndex = 279
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 15)
        Me.Label7.TabIndex = 280
        Me.Label7.Text = "Dari"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(226, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 15)
        Me.Label8.TabIndex = 281
        Me.Label8.Text = "Ke"
        '
        'DT_tanggalke
        '
        Me.DT_tanggalke.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_tanggalke.Location = New System.Drawing.Point(254, 19)
        Me.DT_tanggalke.Name = "DT_tanggalke"
        Me.DT_tanggalke.Size = New System.Drawing.Size(152, 21)
        Me.DT_tanggalke.TabIndex = 282
        '
        'group_periode
        '
        Me.group_periode.Controls.Add(Me.DT_tanggalke)
        Me.group_periode.Controls.Add(Me.Label8)
        Me.group_periode.Controls.Add(Me.Label7)
        Me.group_periode.Controls.Add(Me.DT_tanggaldari)
        Me.group_periode.Location = New System.Drawing.Point(532, 101)
        Me.group_periode.Name = "group_periode"
        Me.group_periode.Size = New System.Drawing.Size(461, 49)
        Me.group_periode.TabIndex = 283
        Me.group_periode.TabStop = False
        Me.group_periode.Text = "Periode"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(1000, 122)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 15)
        Me.Label14.TabIndex = 294
        Me.Label14.Text = "Departemen"
        '
        'Combo_depart
        '
        Me.Combo_depart.FormattingEnabled = True
        Me.Combo_depart.Location = New System.Drawing.Point(1078, 119)
        Me.Combo_depart.Name = "Combo_depart"
        Me.Combo_depart.Size = New System.Drawing.Size(234, 21)
        Me.Combo_depart.TabIndex = 293
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SteelBlue
        Me.Label10.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label10.Location = New System.Drawing.Point(9, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(10, 41)
        Me.Label10.TabIndex = 325
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label12.Location = New System.Drawing.Point(19, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(641, 41)
        Me.Label12.TabIndex = 324
        Me.Label12.Text = "FORM IJIN MENINGGALKAN PEKERJAAN"
        '
        'Masked_kembali
        '
        Me.Masked_kembali.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Masked_kembali.Location = New System.Drawing.Point(301, 308)
        Me.Masked_kembali.Mask = "00:00"
        Me.Masked_kembali.Name = "Masked_kembali"
        Me.Masked_kembali.Size = New System.Drawing.Size(46, 21)
        Me.Masked_kembali.TabIndex = 326
        Me.Masked_kembali.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(209, 312)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 15)
        Me.Label13.TabIndex = 327
        Me.Label13.Text = "Jam kembali"
        '
        'Buttonkeluar
        '
        Me.Buttonkeluar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Buttonkeluar.FlatAppearance.BorderSize = 0
        Me.Buttonkeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buttonkeluar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buttonkeluar.Image = Global.HR_project.My.Resources.Resources.logout
        Me.Buttonkeluar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Buttonkeluar.Location = New System.Drawing.Point(225, 528)
        Me.Buttonkeluar.Name = "Buttonkeluar"
        Me.Buttonkeluar.Size = New System.Drawing.Size(68, 57)
        Me.Buttonkeluar.TabIndex = 348
        Me.Buttonkeluar.Text = "keluar"
        Me.Buttonkeluar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Buttonkeluar.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox2.Location = New System.Drawing.Point(2, 608)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1367, 135)
        Me.PictureBox2.TabIndex = 323
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox1.Location = New System.Drawing.Point(2, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1367, 65)
        Me.PictureBox1.TabIndex = 322
        Me.PictureBox1.TabStop = False
        '
        'Button_baru
        '
        Me.Button_baru.FlatAppearance.BorderSize = 0
        Me.Button_baru.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_baru.Image = Global.HR_project.My.Resources.Resources._new
        Me.Button_baru.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_baru.Location = New System.Drawing.Point(42, 528)
        Me.Button_baru.Name = "Button_baru"
        Me.Button_baru.Size = New System.Drawing.Size(68, 57)
        Me.Button_baru.TabIndex = 295
        Me.Button_baru.Text = "baru"
        Me.Button_baru.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_baru.UseVisualStyleBackColor = True
        '
        'Button_simpan
        '
        Me.Button_simpan.FlatAppearance.BorderSize = 0
        Me.Button_simpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_simpan.Image = Global.HR_project.My.Resources.Resources.save
        Me.Button_simpan.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_simpan.Location = New System.Drawing.Point(134, 528)
        Me.Button_simpan.Name = "Button_simpan"
        Me.Button_simpan.Size = New System.Drawing.Size(68, 57)
        Me.Button_simpan.TabIndex = 270
        Me.Button_simpan.Text = "simpan"
        Me.Button_simpan.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_simpan.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.HR_project.My.Resources.Resources.find_21
        Me.PictureBox3.Location = New System.Drawing.Point(1292, 157)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 349
        Me.PictureBox3.TabStop = False
        '
        'FormIjinKerja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1370, 750)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Buttonkeluar)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Masked_kembali)
        Me.Controls.Add(Me.Grid_karyawan)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button_baru)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Combo_depart)
        Me.Controls.Add(Me.group_periode)
        Me.Controls.Add(Me.Masked_jam)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Radio_tidak)
        Me.Controls.Add(Me.Radio_kembali)
        Me.Controls.Add(Me.Text_pencarian)
        Me.Controls.Add(Me.Text_hari)
        Me.Controls.Add(Me.Button_simpan)
        Me.Controls.Add(Me.Text_alasan)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.DT_tanggal)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Text_dept)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Text_jabatan)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Text_nama)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Text_nik)
        Me.Controls.Add(Me.Label9)
        Me.Name = "FormIjinKerja"
        Me.Text = "FormIjinKerja"
        CType(Me.Grid_karyawan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.group_periode.ResumeLayout(False)
        Me.group_periode.PerformLayout()
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Text_dept As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Text_jabatan As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Text_nama As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Text_nik As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Radio_kembali As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_tidak As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Masked_jam As System.Windows.Forms.MaskedTextBox
    Friend WithEvents DT_tanggaldari As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DT_tanggalke As System.Windows.Forms.DateTimePicker
    Friend WithEvents group_periode As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Combo_depart As System.Windows.Forms.ComboBox
    Friend WithEvents Button_baru As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Masked_kembali As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Buttonkeluar As System.Windows.Forms.Button
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
End Class
