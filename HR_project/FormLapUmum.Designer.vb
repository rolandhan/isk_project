<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLapUmum
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Combo_depart = New System.Windows.Forms.ComboBox()
        Me.Text_pencarian = New System.Windows.Forms.TextBox()
        Me.grid_karyawan = New System.Windows.Forms.DataGridView()
        Me.Group_periode = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DT_tglakhir = New System.Windows.Forms.DateTimePicker()
        Me.DT_tglawal = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Combo_departemen = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Combo_status = New System.Windows.Forms.ComboBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Text_nama = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Text_nik = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.RadioB_Pers = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Combo_jnsPer = New System.Windows.Forms.ComboBox()
        Me.RadioB_All = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Combo_jnsAll = New System.Windows.Forms.ComboBox()
        Me.Combo_filterS = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Button_cetak = New System.Windows.Forms.Button()
        CType(Me.grid_karyawan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Group_periode.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(904, 96)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 18)
        Me.Label3.TabIndex = 228
        Me.Label3.Text = "Departemen"
        '
        'Combo_depart
        '
        Me.Combo_depart.FormattingEnabled = True
        Me.Combo_depart.Location = New System.Drawing.Point(1013, 92)
        Me.Combo_depart.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Combo_depart.Name = "Combo_depart"
        Me.Combo_depart.Size = New System.Drawing.Size(303, 24)
        Me.Combo_depart.TabIndex = 227
        '
        'Text_pencarian
        '
        Me.Text_pencarian.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_pencarian.Location = New System.Drawing.Point(908, 127)
        Me.Text_pencarian.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_pencarian.Name = "Text_pencarian"
        Me.Text_pencarian.Size = New System.Drawing.Size(899, 26)
        Me.Text_pencarian.TabIndex = 226
        '
        'grid_karyawan
        '
        Me.grid_karyawan.BackgroundColor = System.Drawing.SystemColors.Control
        Me.grid_karyawan.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid_karyawan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grid_karyawan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_karyawan.Location = New System.Drawing.Point(908, 162)
        Me.grid_karyawan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grid_karyawan.Name = "grid_karyawan"
        Me.grid_karyawan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_karyawan.Size = New System.Drawing.Size(900, 555)
        Me.grid_karyawan.TabIndex = 225
        '
        'Group_periode
        '
        Me.Group_periode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Group_periode.Controls.Add(Me.Label11)
        Me.Group_periode.Controls.Add(Me.Label8)
        Me.Group_periode.Controls.Add(Me.DT_tglakhir)
        Me.Group_periode.Controls.Add(Me.DT_tglawal)
        Me.Group_periode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_periode.Location = New System.Drawing.Point(40, 96)
        Me.Group_periode.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Group_periode.Name = "Group_periode"
        Me.Group_periode.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Group_periode.Size = New System.Drawing.Size(797, 68)
        Me.Group_periode.TabIndex = 229
        Me.Group_periode.TabStop = False
        Me.Group_periode.Text = "Periode"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(388, 31)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 18)
        Me.Label11.TabIndex = 222
        Me.Label11.Text = "Periode Akhir"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(36, 31)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 18)
        Me.Label8.TabIndex = 221
        Me.Label8.Text = "Periode Awal"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DT_tglakhir
        '
        Me.DT_tglakhir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_tglakhir.Location = New System.Drawing.Point(503, 25)
        Me.DT_tglakhir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DT_tglakhir.Name = "DT_tglakhir"
        Me.DT_tglakhir.Size = New System.Drawing.Size(199, 24)
        Me.DT_tglakhir.TabIndex = 220
        '
        'DT_tglawal
        '
        Me.DT_tglawal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_tglawal.Location = New System.Drawing.Point(179, 28)
        Me.DT_tglawal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DT_tglawal.Name = "DT_tglawal"
        Me.DT_tglawal.Size = New System.Drawing.Size(199, 24)
        Me.DT_tglawal.TabIndex = 219
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.Controls.Add(Me.Combo_departemen)
        Me.GroupBox2.Controls.Add(Me.Label37)
        Me.GroupBox2.Controls.Add(Me.Combo_status)
        Me.GroupBox2.Controls.Add(Me.Label39)
        Me.GroupBox2.Controls.Add(Me.Text_nama)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Text_nik)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.RadioB_Pers)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Combo_jnsPer)
        Me.GroupBox2.Location = New System.Drawing.Point(40, 276)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(797, 220)
        Me.GroupBox2.TabIndex = 230
        Me.GroupBox2.TabStop = False
        '
        'Combo_departemen
        '
        Me.Combo_departemen.FormattingEnabled = True
        Me.Combo_departemen.Location = New System.Drawing.Point(180, 101)
        Me.Combo_departemen.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Combo_departemen.Name = "Combo_departemen"
        Me.Combo_departemen.Size = New System.Drawing.Size(277, 24)
        Me.Combo_departemen.TabIndex = 234
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(36, 107)
        Me.Label37.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(89, 18)
        Me.Label37.TabIndex = 227
        Me.Label37.Text = "Departemen"
        '
        'Combo_status
        '
        Me.Combo_status.FormattingEnabled = True
        Me.Combo_status.Location = New System.Drawing.Point(179, 134)
        Me.Combo_status.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Combo_status.Name = "Combo_status"
        Me.Combo_status.Size = New System.Drawing.Size(276, 24)
        Me.Combo_status.TabIndex = 229
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(36, 140)
        Me.Label39.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(119, 18)
        Me.Label39.TabIndex = 228
        Me.Label39.Text = "Status Karyawan"
        '
        'Text_nama
        '
        Me.Text_nama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_nama.Location = New System.Drawing.Point(180, 69)
        Me.Text_nama.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_nama.Name = "Text_nama"
        Me.Text_nama.Size = New System.Drawing.Size(571, 26)
        Me.Text_nama.TabIndex = 233
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(36, 74)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 18)
        Me.Label10.TabIndex = 232
        Me.Label10.Text = "Nama"
        '
        'Text_nik
        '
        Me.Text_nik.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_nik.Location = New System.Drawing.Point(180, 37)
        Me.Text_nik.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_nik.Name = "Text_nik"
        Me.Text_nik.Size = New System.Drawing.Size(340, 26)
        Me.Text_nik.TabIndex = 231
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(36, 41)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 18)
        Me.Label9.TabIndex = 230
        Me.Label9.Text = "NIK"
        '
        'RadioB_Pers
        '
        Me.RadioB_Pers.AutoSize = True
        Me.RadioB_Pers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioB_Pers.Location = New System.Drawing.Point(8, 1)
        Me.RadioB_Pers.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RadioB_Pers.Name = "RadioB_Pers"
        Me.RadioB_Pers.Size = New System.Drawing.Size(146, 22)
        Me.RadioB_Pers.TabIndex = 1
        Me.RadioB_Pers.TabStop = True
        Me.RadioB_Pers.Text = "Laporan Personal"
        Me.RadioB_Pers.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 174)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 18)
        Me.Label1.TabIndex = 226
        Me.Label1.Text = "Jenis Laporan"
        '
        'Combo_jnsPer
        '
        Me.Combo_jnsPer.FormattingEnabled = True
        Me.Combo_jnsPer.Location = New System.Drawing.Point(180, 166)
        Me.Combo_jnsPer.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Combo_jnsPer.Name = "Combo_jnsPer"
        Me.Combo_jnsPer.Size = New System.Drawing.Size(313, 24)
        Me.Combo_jnsPer.TabIndex = 225
        '
        'RadioB_All
        '
        Me.RadioB_All.AutoSize = True
        Me.RadioB_All.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioB_All.Location = New System.Drawing.Point(8, 2)
        Me.RadioB_All.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RadioB_All.Name = "RadioB_All"
        Me.RadioB_All.Size = New System.Drawing.Size(173, 22)
        Me.RadioB_All.TabIndex = 0
        Me.RadioB_All.TabStop = True
        Me.RadioB_All.Text = "Laporan  Keseluruhan"
        Me.RadioB_All.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Combo_jnsAll)
        Me.GroupBox3.Controls.Add(Me.RadioB_All)
        Me.GroupBox3.Location = New System.Drawing.Point(40, 175)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(797, 85)
        Me.GroupBox3.TabIndex = 231
        Me.GroupBox3.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(36, 41)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 18)
        Me.Label4.TabIndex = 227
        Me.Label4.Text = "Jenis Laporan"
        '
        'Combo_jnsAll
        '
        Me.Combo_jnsAll.FormattingEnabled = True
        Me.Combo_jnsAll.Location = New System.Drawing.Point(179, 38)
        Me.Combo_jnsAll.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Combo_jnsAll.Name = "Combo_jnsAll"
        Me.Combo_jnsAll.Size = New System.Drawing.Size(313, 24)
        Me.Combo_jnsAll.TabIndex = 226
        '
        'Combo_filterS
        '
        Me.Combo_filterS.FormattingEnabled = True
        Me.Combo_filterS.Location = New System.Drawing.Point(1427, 92)
        Me.Combo_filterS.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Combo_filterS.Name = "Combo_filterS"
        Me.Combo_filterS.Size = New System.Drawing.Size(303, 24)
        Me.Combo_filterS.TabIndex = 232
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1364, 96)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 18)
        Me.Label2.TabIndex = 233
        Me.Label2.Text = "Status"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox2.Location = New System.Drawing.Point(3, 750)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1823, 166)
        Me.PictureBox2.TabIndex = 336
        Me.PictureBox2.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label5.Location = New System.Drawing.Point(25, 20)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(528, 52)
        Me.Label5.TabIndex = 335
        Me.Label5.Text = "FORM RINCIAN LAPORAN"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox3.Location = New System.Drawing.Point(3, 7)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(1823, 80)
        Me.PictureBox3.TabIndex = 334
        Me.PictureBox3.TabStop = False
        '
        'Button_cetak
        '
        Me.Button_cetak.Location = New System.Drawing.Point(48, 725)
        Me.Button_cetak.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button_cetak.Name = "Button_cetak"
        Me.Button_cetak.Size = New System.Drawing.Size(85, 36)
        Me.Button_cetak.TabIndex = 337
        Me.Button_cetak.Text = "cetak"
        Me.Button_cetak.UseVisualStyleBackColor = True
        '
        'FormLapUmum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1827, 923)
        Me.Controls.Add(Me.Button_cetak)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Combo_filterS)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Group_periode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Combo_depart)
        Me.Controls.Add(Me.Text_pencarian)
        Me.Controls.Add(Me.grid_karyawan)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormLapUmum"
        Me.Text = "FormLapUmum"
        CType(Me.grid_karyawan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Group_periode.ResumeLayout(False)
        Me.Group_periode.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Combo_depart As System.Windows.Forms.ComboBox
    Friend WithEvents Text_pencarian As System.Windows.Forms.TextBox
    Friend WithEvents grid_karyawan As System.Windows.Forms.DataGridView
    Friend WithEvents Group_periode As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioB_All As System.Windows.Forms.RadioButton
    Friend WithEvents RadioB_Pers As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Combo_jnsPer As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Combo_jnsAll As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_filterS As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Combo_departemen As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Combo_status As System.Windows.Forms.ComboBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Text_nama As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Text_nik As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DT_tglakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents DT_tglawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button_cetak As System.Windows.Forms.Button
End Class
