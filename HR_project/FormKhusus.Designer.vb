<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKhusus
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Text_dept = New System.Windows.Forms.TextBox()
        Me.Text_nik = New System.Windows.Forms.TextBox()
        Me.Text_nama = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Combo_depart = New System.Windows.Forms.ComboBox()
        Me.Text_pencarian = New System.Windows.Forms.TextBox()
        Me.grid_karyawan = New System.Windows.Forms.DataGridView()
        Me.grid_kk = New System.Windows.Forms.TabControl()
        Me.Tab_keckerja = New System.Windows.Forms.TabPage()
        Me.Tab_covid = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DT_selesai = New System.Windows.Forms.DateTimePicker()
        Me.DT_mulai = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Combo_rapid = New System.Windows.Forms.ComboBox()
        Me.Combo_anti = New System.Windows.Forms.ComboBox()
        Me.Combo_pcr = New System.Windows.Forms.ComboBox()
        Me.B_simpanIM = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.grid_covid = New System.Windows.Forms.DataGridView()
        Me.Text_ket = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DT_tanggal = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.B_simpanKK = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grid_karyawan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grid_kk.SuspendLayout()
        Me.Tab_keckerja.SuspendLayout()
        Me.Tab_covid.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.grid_covid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Text_dept)
        Me.GroupBox2.Controls.Add(Me.Text_nik)
        Me.GroupBox2.Controls.Add(Me.Text_nama)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 72)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(346, 97)
        Me.GroupBox2.TabIndex = 34
        Me.GroupBox2.TabStop = False
        '
        'Text_dept
        '
        Me.Text_dept.Location = New System.Drawing.Point(109, 63)
        Me.Text_dept.Name = "Text_dept"
        Me.Text_dept.Size = New System.Drawing.Size(231, 20)
        Me.Text_dept.TabIndex = 27
        '
        'Text_nik
        '
        Me.Text_nik.Location = New System.Drawing.Point(109, 37)
        Me.Text_nik.Name = "Text_nik"
        Me.Text_nik.Size = New System.Drawing.Size(231, 20)
        Me.Text_nik.TabIndex = 26
        '
        'Text_nama
        '
        Me.Text_nama.Location = New System.Drawing.Point(109, 15)
        Me.Text_nama.Name = "Text_nama"
        Me.Text_nama.Size = New System.Drawing.Size(231, 20)
        Me.Text_nama.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 16)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Departemen "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 16)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "NIK "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Nama "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(671, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 15)
        Me.Label4.TabIndex = 228
        Me.Label4.Text = "Departemen"
        '
        'Combo_depart
        '
        Me.Combo_depart.FormattingEnabled = True
        Me.Combo_depart.Location = New System.Drawing.Point(753, 72)
        Me.Combo_depart.Name = "Combo_depart"
        Me.Combo_depart.Size = New System.Drawing.Size(228, 21)
        Me.Combo_depart.TabIndex = 227
        '
        'Text_pencarian
        '
        Me.Text_pencarian.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_pencarian.Location = New System.Drawing.Point(674, 100)
        Me.Text_pencarian.Name = "Text_pencarian"
        Me.Text_pencarian.Size = New System.Drawing.Size(675, 22)
        Me.Text_pencarian.TabIndex = 226
        '
        'grid_karyawan
        '
        Me.grid_karyawan.BackgroundColor = System.Drawing.SystemColors.Control
        Me.grid_karyawan.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid_karyawan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grid_karyawan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_karyawan.Location = New System.Drawing.Point(674, 129)
        Me.grid_karyawan.Name = "grid_karyawan"
        Me.grid_karyawan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_karyawan.Size = New System.Drawing.Size(675, 451)
        Me.grid_karyawan.TabIndex = 225
        '
        'grid_kk
        '
        Me.grid_kk.Controls.Add(Me.Tab_keckerja)
        Me.grid_kk.Controls.Add(Me.Tab_covid)
        Me.grid_kk.Location = New System.Drawing.Point(14, 188)
        Me.grid_kk.Name = "grid_kk"
        Me.grid_kk.SelectedIndex = 0
        Me.grid_kk.Size = New System.Drawing.Size(648, 467)
        Me.grid_kk.TabIndex = 229
        '
        'Tab_keckerja
        '
        Me.Tab_keckerja.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Tab_keckerja.Controls.Add(Me.B_simpanKK)
        Me.Tab_keckerja.Controls.Add(Me.GroupBox5)
        Me.Tab_keckerja.Controls.Add(Me.DT_tanggal)
        Me.Tab_keckerja.Controls.Add(Me.Text_ket)
        Me.Tab_keckerja.Controls.Add(Me.Label10)
        Me.Tab_keckerja.Controls.Add(Me.Label11)
        Me.Tab_keckerja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab_keckerja.Location = New System.Drawing.Point(4, 22)
        Me.Tab_keckerja.Name = "Tab_keckerja"
        Me.Tab_keckerja.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_keckerja.Size = New System.Drawing.Size(640, 441)
        Me.Tab_keckerja.TabIndex = 0
        Me.Tab_keckerja.Text = "Kecelakan kerja"
        '
        'Tab_covid
        '
        Me.Tab_covid.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Tab_covid.Controls.Add(Me.GroupBox4)
        Me.Tab_covid.Controls.Add(Me.B_simpanIM)
        Me.Tab_covid.Controls.Add(Me.GroupBox3)
        Me.Tab_covid.Controls.Add(Me.GroupBox1)
        Me.Tab_covid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tab_covid.Location = New System.Drawing.Point(4, 22)
        Me.Tab_covid.Name = "Tab_covid"
        Me.Tab_covid.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_covid.Size = New System.Drawing.Size(640, 441)
        Me.Tab_covid.TabIndex = 1
        Me.Tab_covid.Text = "Isoloasi Mandiri (COVID)"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.DT_selesai)
        Me.GroupBox1.Controls.Add(Me.DT_mulai)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(271, 91)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Isolasi Mandiri"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 16)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Tanggal Mulai"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 16)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Tanggal Selesai"
        '
        'DT_selesai
        '
        Me.DT_selesai.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_selesai.Location = New System.Drawing.Point(127, 55)
        Me.DT_selesai.Name = "DT_selesai"
        Me.DT_selesai.Size = New System.Drawing.Size(134, 21)
        Me.DT_selesai.TabIndex = 210
        '
        'DT_mulai
        '
        Me.DT_mulai.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_mulai.Location = New System.Drawing.Point(127, 25)
        Me.DT_mulai.Name = "DT_mulai"
        Me.DT_mulai.Size = New System.Drawing.Size(134, 21)
        Me.DT_mulai.TabIndex = 209
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.Combo_pcr)
        Me.GroupBox3.Controls.Add(Me.Combo_anti)
        Me.GroupBox3.Controls.Add(Me.Combo_rapid)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Location = New System.Drawing.Point(285, 13)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(338, 117)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Hasil Test"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 16)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Antigen"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(17, 26)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 16)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Rapid"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(20, 87)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 16)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "PCR"
        '
        'Combo_rapid
        '
        Me.Combo_rapid.FormattingEnabled = True
        Me.Combo_rapid.Location = New System.Drawing.Point(103, 21)
        Me.Combo_rapid.Name = "Combo_rapid"
        Me.Combo_rapid.Size = New System.Drawing.Size(179, 24)
        Me.Combo_rapid.TabIndex = 228
        '
        'Combo_anti
        '
        Me.Combo_anti.FormattingEnabled = True
        Me.Combo_anti.Location = New System.Drawing.Point(103, 51)
        Me.Combo_anti.Name = "Combo_anti"
        Me.Combo_anti.Size = New System.Drawing.Size(179, 24)
        Me.Combo_anti.TabIndex = 229
        '
        'Combo_pcr
        '
        Me.Combo_pcr.FormattingEnabled = True
        Me.Combo_pcr.Location = New System.Drawing.Point(103, 84)
        Me.Combo_pcr.Name = "Combo_pcr"
        Me.Combo_pcr.Size = New System.Drawing.Size(179, 24)
        Me.Combo_pcr.TabIndex = 230
        '
        'B_simpanIM
        '
        Me.B_simpanIM.Location = New System.Drawing.Point(10, 125)
        Me.B_simpanIM.Name = "B_simpanIM"
        Me.B_simpanIM.Size = New System.Drawing.Size(64, 29)
        Me.B_simpanIM.TabIndex = 223
        Me.B_simpanIM.Text = "simpan"
        Me.B_simpanIM.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.White
        Me.GroupBox4.Controls.Add(Me.grid_covid)
        Me.GroupBox4.Location = New System.Drawing.Point(10, 179)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(613, 256)
        Me.GroupBox4.TabIndex = 224
        Me.GroupBox4.TabStop = False
        '
        'grid_covid
        '
        Me.grid_covid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_covid.Location = New System.Drawing.Point(9, 23)
        Me.grid_covid.Name = "grid_covid"
        Me.grid_covid.Size = New System.Drawing.Size(589, 216)
        Me.grid_covid.TabIndex = 0
        '
        'Text_ket
        '
        Me.Text_ket.Location = New System.Drawing.Point(122, 72)
        Me.Text_ket.Multiline = True
        Me.Text_ket.Name = "Text_ket"
        Me.Text_ket.Size = New System.Drawing.Size(493, 73)
        Me.Text_ket.TabIndex = 30
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(19, 70)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 16)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Keterangan"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(19, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 16)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Tanggal"
        '
        'DT_tanggal
        '
        Me.DT_tanggal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_tanggal.Location = New System.Drawing.Point(122, 40)
        Me.DT_tanggal.Name = "DT_tanggal"
        Me.DT_tanggal.Size = New System.Drawing.Size(165, 21)
        Me.DT_tanggal.TabIndex = 210
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.White
        Me.GroupBox5.Controls.Add(Me.DataGridView2)
        Me.GroupBox5.Location = New System.Drawing.Point(22, 208)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(593, 227)
        Me.GroupBox5.TabIndex = 211
        Me.GroupBox5.TabStop = False
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(14, 19)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(564, 193)
        Me.DataGridView2.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox2.Location = New System.Drawing.Point(2, 609)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1367, 135)
        Me.PictureBox2.TabIndex = 336
        Me.PictureBox2.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label12.Location = New System.Drawing.Point(19, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(405, 41)
        Me.Label12.TabIndex = 335
        Me.Label12.Text = "FORM RIWAYAT KHUSUS"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox3.Location = New System.Drawing.Point(2, 6)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(1367, 65)
        Me.PictureBox3.TabIndex = 334
        Me.PictureBox3.TabStop = False
        '
        'B_simpanKK
        '
        Me.B_simpanKK.Location = New System.Drawing.Point(22, 156)
        Me.B_simpanKK.Name = "B_simpanKK"
        Me.B_simpanKK.Size = New System.Drawing.Size(64, 29)
        Me.B_simpanKK.TabIndex = 224
        Me.B_simpanKK.Text = "simpan"
        Me.B_simpanKK.UseVisualStyleBackColor = True
        '
        'FormKhusus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1370, 750)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.grid_kk)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Combo_depart)
        Me.Controls.Add(Me.Text_pencarian)
        Me.Controls.Add(Me.grid_karyawan)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PictureBox2)
        Me.Name = "FormKhusus"
        Me.Text = "FormKhusus"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.grid_karyawan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grid_kk.ResumeLayout(False)
        Me.Tab_keckerja.ResumeLayout(False)
        Me.Tab_keckerja.PerformLayout()
        Me.Tab_covid.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.grid_covid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Text_dept As System.Windows.Forms.TextBox
    Friend WithEvents Text_nik As System.Windows.Forms.TextBox
    Friend WithEvents Text_nama As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Combo_depart As System.Windows.Forms.ComboBox
    Friend WithEvents Text_pencarian As System.Windows.Forms.TextBox
    Friend WithEvents grid_karyawan As System.Windows.Forms.DataGridView
    Friend WithEvents grid_kk As System.Windows.Forms.TabControl
    Friend WithEvents Tab_keckerja As System.Windows.Forms.TabPage
    Friend WithEvents Tab_covid As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Combo_pcr As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_anti As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_rapid As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DT_selesai As System.Windows.Forms.DateTimePicker
    Friend WithEvents DT_mulai As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents DT_tanggal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Text_ket As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents grid_covid As System.Windows.Forms.DataGridView
    Friend WithEvents B_simpanIM As System.Windows.Forms.Button
    Friend WithEvents B_simpanKK As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
End Class
