<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEditIjin
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DT_akhir = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DT_awal = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.combo_dept = New System.Windows.Forms.ComboBox()
        Me.Text_pencarian = New System.Windows.Forms.TextBox()
        Me.grid_tampildata = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Combo_jenis = New System.Windows.Forms.ComboBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HapusDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Buttonkeluar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid_tampildata, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(19, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(884, 41)
        Me.Label4.TabIndex = 323
        Me.Label4.Text = "FORM DATA PERIJINAN, DINAS LUAR  DAN TERLAMBAT"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox2.Location = New System.Drawing.Point(2, 608)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1367, 135)
        Me.PictureBox2.TabIndex = 322
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox1.Location = New System.Drawing.Point(2, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1367, 65)
        Me.PictureBox1.TabIndex = 321
        Me.PictureBox1.TabStop = False
        '
        'DT_akhir
        '
        Me.DT_akhir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_akhir.Location = New System.Drawing.Point(265, 88)
        Me.DT_akhir.Name = "DT_akhir"
        Me.DT_akhir.Size = New System.Drawing.Size(152, 21)
        Me.DT_akhir.TabIndex = 331
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(232, 92)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(22, 15)
        Me.Label16.TabIndex = 330
        Me.Label16.Text = "Ke"
        '
        'DT_awal
        '
        Me.DT_awal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_awal.Location = New System.Drawing.Point(62, 89)
        Me.DT_awal.Name = "DT_awal"
        Me.DT_awal.Size = New System.Drawing.Size(152, 21)
        Me.DT_awal.TabIndex = 329
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(23, 92)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(30, 15)
        Me.Label17.TabIndex = 328
        Me.Label17.Text = "Dari"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(399, 122)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 15)
        Me.Label15.TabIndex = 327
        Me.Label15.Text = "Departemen"
        '
        'combo_dept
        '
        Me.combo_dept.FormattingEnabled = True
        Me.combo_dept.Location = New System.Drawing.Point(481, 119)
        Me.combo_dept.Name = "combo_dept"
        Me.combo_dept.Size = New System.Drawing.Size(234, 21)
        Me.combo_dept.TabIndex = 326
        '
        'Text_pencarian
        '
        Me.Text_pencarian.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_pencarian.Location = New System.Drawing.Point(26, 147)
        Me.Text_pencarian.Name = "Text_pencarian"
        Me.Text_pencarian.Size = New System.Drawing.Size(690, 22)
        Me.Text_pencarian.TabIndex = 325
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
        Me.grid_tampildata.Location = New System.Drawing.Point(26, 186)
        Me.grid_tampildata.Name = "grid_tampildata"
        Me.grid_tampildata.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_tampildata.Size = New System.Drawing.Size(1066, 354)
        Me.grid_tampildata.TabIndex = 324
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 15)
        Me.Label1.TabIndex = 334
        Me.Label1.Text = "Jenis "
        '
        'Combo_jenis
        '
        Me.Combo_jenis.FormattingEnabled = True
        Me.Combo_jenis.Location = New System.Drawing.Point(105, 119)
        Me.Combo_jenis.Name = "Combo_jenis"
        Me.Combo_jenis.Size = New System.Drawing.Size(234, 21)
        Me.Combo_jenis.TabIndex = 333
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.HR_project.My.Resources.Resources.find_21
        Me.PictureBox3.Location = New System.Drawing.Point(694, 148)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 350
        Me.PictureBox3.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.HapusDataToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(133, 48)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.EditToolStripMenuItem.Text = "edit"
        '
        'HapusDataToolStripMenuItem
        '
        Me.HapusDataToolStripMenuItem.Name = "HapusDataToolStripMenuItem"
        Me.HapusDataToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.HapusDataToolStripMenuItem.Text = "hapus data"
        '
        'Buttonkeluar
        '
        Me.Buttonkeluar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Buttonkeluar.FlatAppearance.BorderSize = 0
        Me.Buttonkeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buttonkeluar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buttonkeluar.Image = Global.HR_project.My.Resources.Resources.logout
        Me.Buttonkeluar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Buttonkeluar.Location = New System.Drawing.Point(44, 578)
        Me.Buttonkeluar.Name = "Buttonkeluar"
        Me.Buttonkeluar.Size = New System.Drawing.Size(68, 57)
        Me.Buttonkeluar.TabIndex = 351
        Me.Buttonkeluar.Text = "keluar"
        Me.Buttonkeluar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Buttonkeluar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(80, 547)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(446, 16)
        Me.Label5.TabIndex = 353
        Me.Label5.Text = "untuk edit perijinan IMP gunakan penulisan ""satu jam"" atau ""setengah hari"""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(23, 547)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 16)
        Me.Label3.TabIndex = 352
        Me.Label3.Text = "INFO :"
        '
        'FormEditIjin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1370, 750)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Buttonkeluar)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Combo_jenis)
        Me.Controls.Add(Me.DT_akhir)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.DT_awal)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.combo_dept)
        Me.Controls.Add(Me.Text_pencarian)
        Me.Controls.Add(Me.grid_tampildata)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "FormEditIjin"
        Me.Text = "FormEditIjin"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid_tampildata, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents DT_akhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DT_awal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents combo_dept As System.Windows.Forms.ComboBox
    Friend WithEvents Text_pencarian As System.Windows.Forms.TextBox
    Friend WithEvents grid_tampildata As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Combo_jenis As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HapusDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Buttonkeluar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
