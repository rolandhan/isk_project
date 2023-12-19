<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEditDtPeg
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Groupnik = New System.Windows.Forms.GroupBox()
        Me.Combo_departemen = New System.Windows.Forms.ComboBox()
        Me.Text_Atasan = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Combo_status = New System.Windows.Forms.ComboBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Text_nama = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Text_nik = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Tabtgl = New System.Windows.Forms.TabPage()
        Me.B_updateTR = New System.Windows.Forms.Button()
        Me.grid_recruit = New System.Windows.Forms.DataGridView()
        Me.Tabjab = New System.Windows.Forms.TabPage()
        Me.B_update = New System.Windows.Forms.Button()
        Me.grid_jabatan = New System.Windows.Forms.DataGridView()
        Me.Tabharian = New System.Windows.Forms.TabPage()
        Me.B_updateH = New System.Windows.Forms.Button()
        Me.grid_harian = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Combo_depart = New System.Windows.Forms.ComboBox()
        Me.Text_pencarian = New System.Windows.Forms.TextBox()
        Me.grid_karyawan = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TambahDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HapusDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Groupnik.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.Tabtgl.SuspendLayout()
        CType(Me.grid_recruit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tabjab.SuspendLayout()
        CType(Me.grid_jabatan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tabharian.SuspendLayout()
        CType(Me.grid_harian, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid_karyawan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Groupnik
        '
        Me.Groupnik.BackColor = System.Drawing.Color.White
        Me.Groupnik.Controls.Add(Me.Combo_departemen)
        Me.Groupnik.Controls.Add(Me.Text_Atasan)
        Me.Groupnik.Controls.Add(Me.Label2)
        Me.Groupnik.Controls.Add(Me.Label37)
        Me.Groupnik.Controls.Add(Me.Combo_status)
        Me.Groupnik.Controls.Add(Me.Label39)
        Me.Groupnik.Controls.Add(Me.Text_nama)
        Me.Groupnik.Controls.Add(Me.Label10)
        Me.Groupnik.Controls.Add(Me.Text_nik)
        Me.Groupnik.Controls.Add(Me.Label9)
        Me.Groupnik.Location = New System.Drawing.Point(16, 75)
        Me.Groupnik.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Groupnik.Name = "Groupnik"
        Me.Groupnik.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Groupnik.Size = New System.Drawing.Size(888, 186)
        Me.Groupnik.TabIndex = 215
        Me.Groupnik.TabStop = False
        '
        'Combo_departemen
        '
        Me.Combo_departemen.FormattingEnabled = True
        Me.Combo_departemen.Location = New System.Drawing.Point(151, 81)
        Me.Combo_departemen.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Combo_departemen.Name = "Combo_departemen"
        Me.Combo_departemen.Size = New System.Drawing.Size(277, 24)
        Me.Combo_departemen.TabIndex = 211
        '
        'Text_Atasan
        '
        Me.Text_Atasan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_Atasan.Location = New System.Drawing.Point(149, 116)
        Me.Text_Atasan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_Atasan.Name = "Text_Atasan"
        Me.Text_Atasan.Size = New System.Drawing.Size(277, 26)
        Me.Text_Atasan.TabIndex = 210
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 119)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 18)
        Me.Label2.TabIndex = 209
        Me.Label2.Text = "Atasan"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(13, 87)
        Me.Label37.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(89, 18)
        Me.Label37.TabIndex = 200
        Me.Label37.Text = "Departemen"
        '
        'Combo_status
        '
        Me.Combo_status.FormattingEnabled = True
        Me.Combo_status.Location = New System.Drawing.Point(149, 146)
        Me.Combo_status.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Combo_status.Name = "Combo_status"
        Me.Combo_status.Size = New System.Drawing.Size(276, 24)
        Me.Combo_status.TabIndex = 202
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(12, 151)
        Me.Label39.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(119, 18)
        Me.Label39.TabIndex = 201
        Me.Label39.Text = "Status Karyawan"
        '
        'Text_nama
        '
        Me.Text_nama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_nama.Location = New System.Drawing.Point(151, 49)
        Me.Text_nama.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_nama.Name = "Text_nama"
        Me.Text_nama.Size = New System.Drawing.Size(400, 26)
        Me.Text_nama.TabIndex = 207
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(13, 54)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 18)
        Me.Label10.TabIndex = 206
        Me.Label10.Text = "Nama"
        '
        'Text_nik
        '
        Me.Text_nik.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_nik.Location = New System.Drawing.Point(151, 17)
        Me.Text_nik.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_nik.Name = "Text_nik"
        Me.Text_nik.Size = New System.Drawing.Size(120, 26)
        Me.Text_nik.TabIndex = 205
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 21)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 18)
        Me.Label9.TabIndex = 204
        Me.Label9.Text = "NIK"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Tabtgl)
        Me.TabControl1.Controls.Add(Me.Tabjab)
        Me.TabControl1.Controls.Add(Me.Tabharian)
        Me.TabControl1.Location = New System.Drawing.Point(16, 290)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(888, 357)
        Me.TabControl1.TabIndex = 216
        '
        'Tabtgl
        '
        Me.Tabtgl.Controls.Add(Me.B_updateTR)
        Me.Tabtgl.Controls.Add(Me.grid_recruit)
        Me.Tabtgl.Location = New System.Drawing.Point(4, 25)
        Me.Tabtgl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tabtgl.Name = "Tabtgl"
        Me.Tabtgl.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tabtgl.Size = New System.Drawing.Size(880, 328)
        Me.Tabtgl.TabIndex = 0
        Me.Tabtgl.Text = "Tanggal Recruitmen"
        Me.Tabtgl.UseVisualStyleBackColor = True
        '
        'B_updateTR
        '
        Me.B_updateTR.Location = New System.Drawing.Point(12, 284)
        Me.B_updateTR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.B_updateTR.Name = "B_updateTR"
        Me.B_updateTR.Size = New System.Drawing.Size(100, 28)
        Me.B_updateTR.TabIndex = 232
        Me.B_updateTR.Text = "update"
        Me.B_updateTR.UseVisualStyleBackColor = True
        '
        'grid_recruit
        '
        Me.grid_recruit.BackgroundColor = System.Drawing.SystemColors.Control
        Me.grid_recruit.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid_recruit.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grid_recruit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_recruit.GridColor = System.Drawing.SystemColors.Control
        Me.grid_recruit.Location = New System.Drawing.Point(12, 46)
        Me.grid_recruit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grid_recruit.Name = "grid_recruit"
        Me.grid_recruit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_recruit.Size = New System.Drawing.Size(843, 230)
        Me.grid_recruit.TabIndex = 0
        '
        'Tabjab
        '
        Me.Tabjab.Controls.Add(Me.B_update)
        Me.Tabjab.Controls.Add(Me.grid_jabatan)
        Me.Tabjab.Location = New System.Drawing.Point(4, 25)
        Me.Tabjab.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tabjab.Name = "Tabjab"
        Me.Tabjab.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tabjab.Size = New System.Drawing.Size(880, 328)
        Me.Tabjab.TabIndex = 1
        Me.Tabjab.Text = "Riwayat Jabatan"
        Me.Tabjab.UseVisualStyleBackColor = True
        '
        'B_update
        '
        Me.B_update.Location = New System.Drawing.Point(17, 286)
        Me.B_update.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.B_update.Name = "B_update"
        Me.B_update.Size = New System.Drawing.Size(100, 28)
        Me.B_update.TabIndex = 231
        Me.B_update.Text = "update"
        Me.B_update.UseVisualStyleBackColor = True
        '
        'grid_jabatan
        '
        Me.grid_jabatan.BackgroundColor = System.Drawing.SystemColors.Control
        Me.grid_jabatan.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid_jabatan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grid_jabatan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_jabatan.GridColor = System.Drawing.SystemColors.Control
        Me.grid_jabatan.Location = New System.Drawing.Point(17, 43)
        Me.grid_jabatan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grid_jabatan.Name = "grid_jabatan"
        Me.grid_jabatan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_jabatan.Size = New System.Drawing.Size(843, 230)
        Me.grid_jabatan.TabIndex = 1
        '
        'Tabharian
        '
        Me.Tabharian.Controls.Add(Me.B_updateH)
        Me.Tabharian.Controls.Add(Me.grid_harian)
        Me.Tabharian.Location = New System.Drawing.Point(4, 25)
        Me.Tabharian.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Tabharian.Name = "Tabharian"
        Me.Tabharian.Size = New System.Drawing.Size(880, 328)
        Me.Tabharian.TabIndex = 2
        Me.Tabharian.Text = "Data Riwayat Harian"
        Me.Tabharian.UseVisualStyleBackColor = True
        '
        'B_updateH
        '
        Me.B_updateH.Location = New System.Drawing.Point(17, 289)
        Me.B_updateH.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.B_updateH.Name = "B_updateH"
        Me.B_updateH.Size = New System.Drawing.Size(100, 28)
        Me.B_updateH.TabIndex = 232
        Me.B_updateH.Text = "update"
        Me.B_updateH.UseVisualStyleBackColor = True
        '
        'grid_harian
        '
        Me.grid_harian.BackgroundColor = System.Drawing.SystemColors.Control
        Me.grid_harian.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grid_harian.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_harian.GridColor = System.Drawing.SystemColors.Control
        Me.grid_harian.Location = New System.Drawing.Point(17, 43)
        Me.grid_harian.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grid_harian.Name = "grid_harian"
        Me.grid_harian.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_harian.Size = New System.Drawing.Size(407, 239)
        Me.grid_harian.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(936, 96)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 18)
        Me.Label3.TabIndex = 228
        Me.Label3.Text = "Departemen"
        '
        'Combo_depart
        '
        Me.Combo_depart.FormattingEnabled = True
        Me.Combo_depart.Location = New System.Drawing.Point(1045, 91)
        Me.Combo_depart.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Combo_depart.Name = "Combo_depart"
        Me.Combo_depart.Size = New System.Drawing.Size(245, 24)
        Me.Combo_depart.TabIndex = 227
        '
        'Text_pencarian
        '
        Me.Text_pencarian.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_pencarian.Location = New System.Drawing.Point(940, 124)
        Me.Text_pencarian.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Text_pencarian.Name = "Text_pencarian"
        Me.Text_pencarian.Size = New System.Drawing.Size(841, 26)
        Me.Text_pencarian.TabIndex = 226
        '
        'grid_karyawan
        '
        Me.grid_karyawan.BackgroundColor = System.Drawing.SystemColors.Control
        Me.grid_karyawan.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid_karyawan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grid_karyawan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_karyawan.GridColor = System.Drawing.SystemColors.Control
        Me.grid_karyawan.Location = New System.Drawing.Point(940, 159)
        Me.grid_karyawan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grid_karyawan.Name = "grid_karyawan"
        Me.grid_karyawan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_karyawan.Size = New System.Drawing.Size(843, 555)
        Me.grid_karyawan.TabIndex = 225
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditDataToolStripMenuItem, Me.TambahDataToolStripMenuItem, Me.HapusDataToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(164, 76)
        '
        'EditDataToolStripMenuItem
        '
        Me.EditDataToolStripMenuItem.Name = "EditDataToolStripMenuItem"
        Me.EditDataToolStripMenuItem.Size = New System.Drawing.Size(163, 24)
        Me.EditDataToolStripMenuItem.Text = "Edit data"
        '
        'TambahDataToolStripMenuItem
        '
        Me.TambahDataToolStripMenuItem.Name = "TambahDataToolStripMenuItem"
        Me.TambahDataToolStripMenuItem.Size = New System.Drawing.Size(163, 24)
        Me.TambahDataToolStripMenuItem.Text = "tambah data"
        '
        'HapusDataToolStripMenuItem
        '
        Me.HapusDataToolStripMenuItem.Name = "HapusDataToolStripMenuItem"
        Me.HapusDataToolStripMenuItem.Size = New System.Drawing.Size(163, 24)
        Me.HapusDataToolStripMenuItem.Text = "hapus"
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(25, 20)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(537, 52)
        Me.Label4.TabIndex = 335
        Me.Label4.Text = "FORM DETAIL KARYAWAN"
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
        'FormEditDtPeg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1827, 923)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Combo_depart)
        Me.Controls.Add(Me.Text_pencarian)
        Me.Controls.Add(Me.grid_karyawan)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Groupnik)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormEditDtPeg"
        Me.Text = " "
        Me.Groupnik.ResumeLayout(False)
        Me.Groupnik.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.Tabtgl.ResumeLayout(False)
        CType(Me.grid_recruit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tabjab.ResumeLayout(False)
        CType(Me.grid_jabatan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tabharian.ResumeLayout(False)
        CType(Me.grid_harian, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid_karyawan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Groupnik As System.Windows.Forms.GroupBox
    Friend WithEvents Combo_departemen As System.Windows.Forms.ComboBox
    Friend WithEvents Text_Atasan As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Combo_status As System.Windows.Forms.ComboBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Text_nama As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Text_nik As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Tabtgl As System.Windows.Forms.TabPage
    Friend WithEvents Tabjab As System.Windows.Forms.TabPage
    Friend WithEvents grid_recruit As System.Windows.Forms.DataGridView
    Friend WithEvents Tabharian As System.Windows.Forms.TabPage
    Friend WithEvents grid_jabatan As System.Windows.Forms.DataGridView
    Friend WithEvents grid_harian As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Combo_depart As System.Windows.Forms.ComboBox
    Friend WithEvents Text_pencarian As System.Windows.Forms.TextBox
    Friend WithEvents grid_karyawan As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TambahDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HapusDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents B_update As System.Windows.Forms.Button
    Friend WithEvents B_updateTR As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents B_updateH As System.Windows.Forms.Button
End Class
