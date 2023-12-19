<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormIjinCuti
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
        Me.Text_hari = New System.Windows.Forms.TextBox()
        Me.Button_simpan = New System.Windows.Forms.Button()
        Me.DT_tanggal = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Text_dept = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Text_jabatan = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Text_nama = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Text_nik = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Text_mulai = New System.Windows.Forms.TextBox()
        Me.DT_mulai = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Text_lama = New System.Windows.Forms.TextBox()
        Me.Text_masuk = New System.Windows.Forms.TextBox()
        Me.DT_masuk = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Groupcuti = New System.Windows.Forms.GroupBox()
        Me.Radio_ctkusus = New System.Windows.Forms.RadioButton()
        Me.Radio_kd = New System.Windows.Forms.RadioButton()
        Me.Radio_sakit = New System.Windows.Forms.RadioButton()
        Me.Radio_ijin = New System.Windows.Forms.RadioButton()
        Me.Radio_alfa = New System.Windows.Forms.RadioButton()
        Me.Radio_cuti = New System.Windows.Forms.RadioButton()
        Me.Button_baru = New System.Windows.Forms.Button()
        Me.Text_ket = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Button_go = New System.Windows.Forms.Button()
        Me.DT_akhir = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DT_awal = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.combo_dept = New System.Windows.Forms.ComboBox()
        Me.Text_pencarian = New System.Windows.Forms.TextBox()
        Me.grid_tampildata = New System.Windows.Forms.DataGridView()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Buttonkeluar = New System.Windows.Forms.Button()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Groupcuti.SuspendLayout()
        CType(Me.grid_tampildata, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Text_hari
        '
        Me.Text_hari.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_hari.Location = New System.Drawing.Point(149, 111)
        Me.Text_hari.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_hari.Name = "Text_hari"
        Me.Text_hari.Size = New System.Drawing.Size(140, 26)
        Me.Text_hari.TabIndex = 271
        '
        'Button_simpan
        '
        Me.Button_simpan.FlatAppearance.BorderSize = 0
        Me.Button_simpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_simpan.Image = Global.HR_project.My.Resources.Resources.save
        Me.Button_simpan.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_simpan.Location = New System.Drawing.Point(157, 650)
        Me.Button_simpan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button_simpan.Name = "Button_simpan"
        Me.Button_simpan.Size = New System.Drawing.Size(91, 70)
        Me.Button_simpan.TabIndex = 269
        Me.Button_simpan.Text = "Simpan"
        Me.Button_simpan.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_simpan.UseVisualStyleBackColor = True
        '
        'DT_tanggal
        '
        Me.DT_tanggal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_tanggal.Location = New System.Drawing.Point(376, 112)
        Me.DT_tanggal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DT_tanggal.Name = "DT_tanggal"
        Me.DT_tanggal.Size = New System.Drawing.Size(201, 24)
        Me.DT_tanggal.TabIndex = 259
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(299, 114)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 18)
        Me.Label11.TabIndex = 258
        Me.Label11.Text = "Tanggal"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(23, 114)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 18)
        Me.Label5.TabIndex = 251
        Me.Label5.Text = "Hari"
        '
        'Text_dept
        '
        Me.Text_dept.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_dept.Location = New System.Drawing.Point(161, 192)
        Me.Text_dept.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_dept.Name = "Text_dept"
        Me.Text_dept.Size = New System.Drawing.Size(340, 26)
        Me.Text_dept.TabIndex = 249
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(36, 203)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 18)
        Me.Label3.TabIndex = 248
        Me.Label3.Text = "Departemen"
        '
        'Text_jabatan
        '
        Me.Text_jabatan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_jabatan.Location = New System.Drawing.Point(161, 159)
        Me.Text_jabatan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_jabatan.Name = "Text_jabatan"
        Me.Text_jabatan.Size = New System.Drawing.Size(452, 26)
        Me.Text_jabatan.TabIndex = 247
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(36, 165)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 18)
        Me.Label2.TabIndex = 246
        Me.Label2.Text = "Jabatan"
        '
        'Text_nama
        '
        Me.Text_nama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_nama.Location = New System.Drawing.Point(161, 126)
        Me.Text_nama.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_nama.Name = "Text_nama"
        Me.Text_nama.Size = New System.Drawing.Size(340, 26)
        Me.Text_nama.TabIndex = 245
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 130)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 18)
        Me.Label1.TabIndex = 244
        Me.Label1.Text = "Nama"
        '
        'Text_nik
        '
        Me.Text_nik.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_nik.Location = New System.Drawing.Point(161, 95)
        Me.Text_nik.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_nik.Name = "Text_nik"
        Me.Text_nik.Size = New System.Drawing.Size(340, 26)
        Me.Text_nik.TabIndex = 243
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(36, 98)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 18)
        Me.Label9.TabIndex = 242
        Me.Label9.Text = "NIK"
        '
        'Text_mulai
        '
        Me.Text_mulai.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_mulai.Location = New System.Drawing.Point(148, 175)
        Me.Text_mulai.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_mulai.Name = "Text_mulai"
        Me.Text_mulai.Size = New System.Drawing.Size(140, 26)
        Me.Text_mulai.TabIndex = 277
        '
        'DT_mulai
        '
        Me.DT_mulai.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_mulai.Location = New System.Drawing.Point(376, 176)
        Me.DT_mulai.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DT_mulai.Name = "DT_mulai"
        Me.DT_mulai.Size = New System.Drawing.Size(201, 24)
        Me.DT_mulai.TabIndex = 276
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(299, 178)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 18)
        Me.Label6.TabIndex = 275
        Me.Label6.Text = "Tanggal"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(23, 182)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 18)
        Me.Label7.TabIndex = 274
        Me.Label7.Text = "Mulai "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(20, 145)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 18)
        Me.Label8.TabIndex = 279
        Me.Label8.Text = "Lama"
        '
        'Text_lama
        '
        Me.Text_lama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_lama.Location = New System.Drawing.Point(149, 142)
        Me.Text_lama.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_lama.Name = "Text_lama"
        Me.Text_lama.Size = New System.Drawing.Size(139, 26)
        Me.Text_lama.TabIndex = 278
        '
        'Text_masuk
        '
        Me.Text_masuk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_masuk.Location = New System.Drawing.Point(148, 207)
        Me.Text_masuk.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_masuk.Name = "Text_masuk"
        Me.Text_masuk.Size = New System.Drawing.Size(140, 26)
        Me.Text_masuk.TabIndex = 283
        '
        'DT_masuk
        '
        Me.DT_masuk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_masuk.Location = New System.Drawing.Point(375, 208)
        Me.DT_masuk.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DT_masuk.Name = "DT_masuk"
        Me.DT_masuk.Size = New System.Drawing.Size(201, 24)
        Me.DT_masuk.TabIndex = 282
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(297, 210)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 18)
        Me.Label10.TabIndex = 281
        Me.Label10.Text = "Tanggal"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(21, 214)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 18)
        Me.Label12.TabIndex = 280
        Me.Label12.Text = "Tanggal Masuk"
        '
        'Groupcuti
        '
        Me.Groupcuti.Controls.Add(Me.Radio_ctkusus)
        Me.Groupcuti.Controls.Add(Me.Radio_kd)
        Me.Groupcuti.Controls.Add(Me.Radio_sakit)
        Me.Groupcuti.Controls.Add(Me.Radio_ijin)
        Me.Groupcuti.Controls.Add(Me.Radio_alfa)
        Me.Groupcuti.Controls.Add(Me.Radio_cuti)
        Me.Groupcuti.Controls.Add(Me.Text_masuk)
        Me.Groupcuti.Controls.Add(Me.DT_masuk)
        Me.Groupcuti.Controls.Add(Me.Label10)
        Me.Groupcuti.Controls.Add(Me.Label12)
        Me.Groupcuti.Controls.Add(Me.Label8)
        Me.Groupcuti.Controls.Add(Me.Text_lama)
        Me.Groupcuti.Controls.Add(Me.Text_mulai)
        Me.Groupcuti.Controls.Add(Me.DT_mulai)
        Me.Groupcuti.Controls.Add(Me.Label6)
        Me.Groupcuti.Controls.Add(Me.Label7)
        Me.Groupcuti.Controls.Add(Me.Text_hari)
        Me.Groupcuti.Controls.Add(Me.DT_tanggal)
        Me.Groupcuti.Controls.Add(Me.Label11)
        Me.Groupcuti.Controls.Add(Me.Label5)
        Me.Groupcuti.Location = New System.Drawing.Point(12, 250)
        Me.Groupcuti.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Groupcuti.Name = "Groupcuti"
        Me.Groupcuti.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Groupcuti.Size = New System.Drawing.Size(603, 256)
        Me.Groupcuti.TabIndex = 284
        Me.Groupcuti.TabStop = False
        Me.Groupcuti.Text = "LAMA TIDAK MASUK KERJA"
        '
        'Radio_ctkusus
        '
        Me.Radio_ctkusus.AutoSize = True
        Me.Radio_ctkusus.Location = New System.Drawing.Point(375, 60)
        Me.Radio_ctkusus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Radio_ctkusus.Name = "Radio_ctkusus"
        Me.Radio_ctkusus.Size = New System.Drawing.Size(96, 21)
        Me.Radio_ctkusus.TabIndex = 289
        Me.Radio_ctkusus.TabStop = True
        Me.Radio_ctkusus.Text = "Cuti Kusus"
        Me.Radio_ctkusus.UseVisualStyleBackColor = True
        '
        'Radio_kd
        '
        Me.Radio_kd.AutoSize = True
        Me.Radio_kd.Location = New System.Drawing.Point(176, 60)
        Me.Radio_kd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Radio_kd.Name = "Radio_kd"
        Me.Radio_kd.Size = New System.Drawing.Size(149, 21)
        Me.Radio_kd.TabIndex = 288
        Me.Radio_kd.TabStop = True
        Me.Radio_kd.Text = "Keterangan Dokter"
        Me.Radio_kd.UseVisualStyleBackColor = True
        '
        'Radio_sakit
        '
        Me.Radio_sakit.AutoSize = True
        Me.Radio_sakit.Location = New System.Drawing.Point(176, 32)
        Me.Radio_sakit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Radio_sakit.Name = "Radio_sakit"
        Me.Radio_sakit.Size = New System.Drawing.Size(60, 21)
        Me.Radio_sakit.TabIndex = 287
        Me.Radio_sakit.TabStop = True
        Me.Radio_sakit.Text = "Sakit"
        Me.Radio_sakit.UseVisualStyleBackColor = True
        '
        'Radio_ijin
        '
        Me.Radio_ijin.AutoSize = True
        Me.Radio_ijin.Location = New System.Drawing.Point(27, 60)
        Me.Radio_ijin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Radio_ijin.Name = "Radio_ijin"
        Me.Radio_ijin.Size = New System.Drawing.Size(46, 21)
        Me.Radio_ijin.TabIndex = 286
        Me.Radio_ijin.TabStop = True
        Me.Radio_ijin.Text = "Ijin"
        Me.Radio_ijin.UseVisualStyleBackColor = True
        '
        'Radio_alfa
        '
        Me.Radio_alfa.AutoSize = True
        Me.Radio_alfa.Location = New System.Drawing.Point(375, 32)
        Me.Radio_alfa.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Radio_alfa.Name = "Radio_alfa"
        Me.Radio_alfa.Size = New System.Drawing.Size(148, 21)
        Me.Radio_alfa.TabIndex = 285
        Me.Radio_alfa.TabStop = True
        Me.Radio_alfa.Text = "Tanpa Keterangan"
        Me.Radio_alfa.UseVisualStyleBackColor = True
        '
        'Radio_cuti
        '
        Me.Radio_cuti.AutoSize = True
        Me.Radio_cuti.Location = New System.Drawing.Point(27, 32)
        Me.Radio_cuti.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Radio_cuti.Name = "Radio_cuti"
        Me.Radio_cuti.Size = New System.Drawing.Size(53, 21)
        Me.Radio_cuti.TabIndex = 284
        Me.Radio_cuti.TabStop = True
        Me.Radio_cuti.Text = "Cuti"
        Me.Radio_cuti.UseVisualStyleBackColor = True
        '
        'Button_baru
        '
        Me.Button_baru.FlatAppearance.BorderSize = 0
        Me.Button_baru.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_baru.Image = Global.HR_project.My.Resources.Resources._new
        Me.Button_baru.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_baru.Location = New System.Drawing.Point(36, 650)
        Me.Button_baru.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button_baru.Name = "Button_baru"
        Me.Button_baru.Size = New System.Drawing.Size(91, 70)
        Me.Button_baru.TabIndex = 287
        Me.Button_baru.Text = "Baru"
        Me.Button_baru.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_baru.UseVisualStyleBackColor = True
        '
        'Text_ket
        '
        Me.Text_ket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_ket.Location = New System.Drawing.Point(163, 513)
        Me.Text_ket.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_ket.Multiline = True
        Me.Text_ket.Name = "Text_ket"
        Me.Text_ket.Size = New System.Drawing.Size(425, 84)
        Me.Text_ket.TabIndex = 288
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(36, 517)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 18)
        Me.Label13.TabIndex = 289
        Me.Label13.Text = "Keterangan"
        '
        'Button_go
        '
        Me.Button_go.Location = New System.Drawing.Point(1221, 90)
        Me.Button_go.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button_go.Name = "Button_go"
        Me.Button_go.Size = New System.Drawing.Size(48, 27)
        Me.Button_go.TabIndex = 317
        Me.Button_go.Text = "Go !"
        Me.Button_go.UseVisualStyleBackColor = True
        '
        'DT_akhir
        '
        Me.DT_akhir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_akhir.Location = New System.Drawing.Point(996, 90)
        Me.DT_akhir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DT_akhir.Name = "DT_akhir"
        Me.DT_akhir.Size = New System.Drawing.Size(201, 24)
        Me.DT_akhir.TabIndex = 316
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(952, 95)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(26, 18)
        Me.Label16.TabIndex = 315
        Me.Label16.Text = "Ke"
        '
        'DT_awal
        '
        Me.DT_awal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_awal.Location = New System.Drawing.Point(725, 91)
        Me.DT_awal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DT_awal.Name = "DT_awal"
        Me.DT_awal.Size = New System.Drawing.Size(201, 24)
        Me.DT_awal.TabIndex = 314
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(673, 95)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(35, 18)
        Me.Label17.TabIndex = 313
        Me.Label17.Text = "Dari"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(675, 133)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 18)
        Me.Label15.TabIndex = 312
        Me.Label15.Text = "Departemen"
        '
        'combo_dept
        '
        Me.combo_dept.FormattingEnabled = True
        Me.combo_dept.Location = New System.Drawing.Point(784, 129)
        Me.combo_dept.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.combo_dept.Name = "combo_dept"
        Me.combo_dept.Size = New System.Drawing.Size(311, 24)
        Me.combo_dept.TabIndex = 311
        '
        'Text_pencarian
        '
        Me.Text_pencarian.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_pencarian.Location = New System.Drawing.Point(677, 162)
        Me.Text_pencarian.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_pencarian.Name = "Text_pencarian"
        Me.Text_pencarian.Size = New System.Drawing.Size(919, 26)
        Me.Text_pencarian.TabIndex = 310
        '
        'grid_tampildata
        '
        Me.grid_tampildata.BackgroundColor = System.Drawing.SystemColors.Control
        Me.grid_tampildata.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid_tampildata.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grid_tampildata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_tampildata.Location = New System.Drawing.Point(677, 210)
        Me.grid_tampildata.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grid_tampildata.Name = "grid_tampildata"
        Me.grid_tampildata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_tampildata.Size = New System.Drawing.Size(920, 486)
        Me.grid_tampildata.TabIndex = 309
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox2.Location = New System.Drawing.Point(3, 742)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1823, 166)
        Me.PictureBox2.TabIndex = 319
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox1.Location = New System.Drawing.Point(3, 2)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1823, 80)
        Me.PictureBox1.TabIndex = 318
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(25, 15)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(674, 52)
        Me.Label4.TabIndex = 320
        Me.Label4.Text = "FORM IJIN TIDAK MASUK KERJA"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label14.Location = New System.Drawing.Point(12, 15)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(13, 50)
        Me.Label14.TabIndex = 321
        '
        'Buttonkeluar
        '
        Me.Buttonkeluar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Buttonkeluar.FlatAppearance.BorderSize = 0
        Me.Buttonkeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buttonkeluar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buttonkeluar.Image = Global.HR_project.My.Resources.Resources.logout
        Me.Buttonkeluar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Buttonkeluar.Location = New System.Drawing.Point(289, 650)
        Me.Buttonkeluar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Buttonkeluar.Name = "Buttonkeluar"
        Me.Buttonkeluar.Size = New System.Drawing.Size(91, 70)
        Me.Buttonkeluar.TabIndex = 349
        Me.Buttonkeluar.Text = "keluar"
        Me.Buttonkeluar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Buttonkeluar.UseVisualStyleBackColor = True
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.HR_project.My.Resources.Resources.find_21
        Me.PictureBox3.Location = New System.Drawing.Point(1569, 160)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(27, 25)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 351
        Me.PictureBox3.TabStop = False
        '
        'FormIjinCuti
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1827, 923)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Buttonkeluar)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button_go)
        Me.Controls.Add(Me.DT_akhir)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.DT_awal)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.combo_dept)
        Me.Controls.Add(Me.Text_pencarian)
        Me.Controls.Add(Me.grid_tampildata)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Text_ket)
        Me.Controls.Add(Me.Button_baru)
        Me.Controls.Add(Me.Groupcuti)
        Me.Controls.Add(Me.Button_simpan)
        Me.Controls.Add(Me.Text_dept)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Text_jabatan)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Text_nama)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Text_nik)
        Me.Controls.Add(Me.Label9)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormIjinCuti"
        Me.Groupcuti.ResumeLayout(False)
        Me.Groupcuti.PerformLayout()
        CType(Me.grid_tampildata, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Text_hari As System.Windows.Forms.TextBox
    Friend WithEvents Button_simpan As System.Windows.Forms.Button
    Friend WithEvents DT_tanggal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Text_dept As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Text_jabatan As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Text_nama As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Text_nik As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Text_mulai As System.Windows.Forms.TextBox
    Friend WithEvents DT_mulai As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Text_lama As System.Windows.Forms.TextBox
    Friend WithEvents Text_masuk As System.Windows.Forms.TextBox
    Friend WithEvents DT_masuk As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Groupcuti As System.Windows.Forms.GroupBox
    Friend WithEvents Radio_alfa As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_cuti As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_kd As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_sakit As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_ijin As System.Windows.Forms.RadioButton
    Friend WithEvents Button_baru As System.Windows.Forms.Button
    Friend WithEvents Radio_ctkusus As System.Windows.Forms.RadioButton
    Friend WithEvents Text_ket As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Button_go As System.Windows.Forms.Button
    Friend WithEvents DT_akhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DT_awal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents combo_dept As System.Windows.Forms.ComboBox
    Friend WithEvents Text_pencarian As System.Windows.Forms.TextBox
    Friend WithEvents grid_tampildata As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Buttonkeluar As System.Windows.Forms.Button
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
End Class
