<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAbsensiKhusus
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
        Me.Group_periode = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DT_tglakhir = New System.Windows.Forms.DateTimePicker()
        Me.DT_tglawal = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Combo_Opt = New System.Windows.Forms.ComboBox()
        Me.Text_pencarian = New System.Windows.Forms.TextBox()
        Me.Grid_karyawan = New System.Windows.Forms.DataGridView()
        Me.Label_filter = New System.Windows.Forms.Label()
        Me.Combo_filter = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grid_dtabsen = New System.Windows.Forms.DataGridView()
        Me.Group_cetak = New System.Windows.Forms.GroupBox()
        Me.Label_catatan = New System.Windows.Forms.Label()
        Me.Text_ket = New System.Windows.Forms.TextBox()
        Me.Button_cetak = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Combo_JLaporan = New System.Windows.Forms.ComboBox()
        Me.Group_periode.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid_karyawan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grid_dtabsen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Group_cetak.SuspendLayout()
        Me.SuspendLayout()
        '
        'Group_periode
        '
        Me.Group_periode.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Group_periode.Controls.Add(Me.Label11)
        Me.Group_periode.Controls.Add(Me.Label8)
        Me.Group_periode.Controls.Add(Me.DT_tglakhir)
        Me.Group_periode.Controls.Add(Me.DT_tglawal)
        Me.Group_periode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_periode.Location = New System.Drawing.Point(39, 97)
        Me.Group_periode.Margin = New System.Windows.Forms.Padding(4)
        Me.Group_periode.Name = "Group_periode"
        Me.Group_periode.Padding = New System.Windows.Forms.Padding(4)
        Me.Group_periode.Size = New System.Drawing.Size(836, 68)
        Me.Group_periode.TabIndex = 230
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
        Me.DT_tglakhir.Margin = New System.Windows.Forms.Padding(4)
        Me.DT_tglakhir.Name = "DT_tglakhir"
        Me.DT_tglakhir.Size = New System.Drawing.Size(199, 24)
        Me.DT_tglakhir.TabIndex = 1
        '
        'DT_tglawal
        '
        Me.DT_tglawal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_tglawal.Location = New System.Drawing.Point(179, 28)
        Me.DT_tglawal.Margin = New System.Windows.Forms.Padding(4)
        Me.DT_tglawal.Name = "DT_tglawal"
        Me.DT_tglawal.Size = New System.Drawing.Size(199, 24)
        Me.DT_tglawal.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox2.Location = New System.Drawing.Point(3, 750)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1823, 166)
        Me.PictureBox2.TabIndex = 329
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox1.Location = New System.Drawing.Point(3, 7)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1823, 80)
        Me.PictureBox1.TabIndex = 328
        Me.PictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(920, 119)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 18)
        Me.Label3.TabIndex = 333
        Me.Label3.Text = "Filter"
        '
        'Combo_Opt
        '
        Me.Combo_Opt.FormattingEnabled = True
        Me.Combo_Opt.Location = New System.Drawing.Point(976, 116)
        Me.Combo_Opt.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_Opt.Name = "Combo_Opt"
        Me.Combo_Opt.Size = New System.Drawing.Size(239, 24)
        Me.Combo_Opt.TabIndex = 332
        '
        'Text_pencarian
        '
        Me.Text_pencarian.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_pencarian.Location = New System.Drawing.Point(924, 150)
        Me.Text_pencarian.Margin = New System.Windows.Forms.Padding(4)
        Me.Text_pencarian.Name = "Text_pencarian"
        Me.Text_pencarian.Size = New System.Drawing.Size(839, 26)
        Me.Text_pencarian.TabIndex = 331
        '
        'Grid_karyawan
        '
        Me.Grid_karyawan.BackgroundColor = System.Drawing.SystemColors.Control
        Me.Grid_karyawan.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Grid_karyawan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Grid_karyawan.Location = New System.Drawing.Point(924, 186)
        Me.Grid_karyawan.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid_karyawan.Name = "Grid_karyawan"
        Me.Grid_karyawan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Grid_karyawan.Size = New System.Drawing.Size(840, 586)
        Me.Grid_karyawan.TabIndex = 330
        '
        'Label_filter
        '
        Me.Label_filter.AutoSize = True
        Me.Label_filter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_filter.Location = New System.Drawing.Point(1228, 118)
        Me.Label_filter.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_filter.Name = "Label_filter"
        Me.Label_filter.Size = New System.Drawing.Size(0, 18)
        Me.Label_filter.TabIndex = 335
        '
        'Combo_filter
        '
        Me.Combo_filter.FormattingEnabled = True
        Me.Combo_filter.Location = New System.Drawing.Point(1412, 116)
        Me.Combo_filter.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_filter.Name = "Combo_filter"
        Me.Combo_filter.Size = New System.Drawing.Size(351, 24)
        Me.Combo_filter.TabIndex = 334
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox1.Controls.Add(Me.grid_dtabsen)
        Me.GroupBox1.Location = New System.Drawing.Point(39, 180)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(836, 443)
        Me.GroupBox1.TabIndex = 336
        Me.GroupBox1.TabStop = False
        '
        'grid_dtabsen
        '
        Me.grid_dtabsen.BackgroundColor = System.Drawing.Color.White
        Me.grid_dtabsen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grid_dtabsen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_dtabsen.Location = New System.Drawing.Point(19, 21)
        Me.grid_dtabsen.Margin = New System.Windows.Forms.Padding(4)
        Me.grid_dtabsen.Name = "grid_dtabsen"
        Me.grid_dtabsen.Size = New System.Drawing.Size(797, 406)
        Me.grid_dtabsen.TabIndex = 1
        '
        'Group_cetak
        '
        Me.Group_cetak.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Group_cetak.Controls.Add(Me.Label_catatan)
        Me.Group_cetak.Controls.Add(Me.Text_ket)
        Me.Group_cetak.Controls.Add(Me.Button_cetak)
        Me.Group_cetak.Controls.Add(Me.Label1)
        Me.Group_cetak.Controls.Add(Me.Combo_JLaporan)
        Me.Group_cetak.Location = New System.Drawing.Point(37, 629)
        Me.Group_cetak.Margin = New System.Windows.Forms.Padding(4)
        Me.Group_cetak.Name = "Group_cetak"
        Me.Group_cetak.Padding = New System.Windows.Forms.Padding(4)
        Me.Group_cetak.Size = New System.Drawing.Size(836, 164)
        Me.Group_cetak.TabIndex = 337
        Me.Group_cetak.TabStop = False
        '
        'Label_catatan
        '
        Me.Label_catatan.AutoSize = True
        Me.Label_catatan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_catatan.Location = New System.Drawing.Point(16, 54)
        Me.Label_catatan.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_catatan.Name = "Label_catatan"
        Me.Label_catatan.Size = New System.Drawing.Size(59, 18)
        Me.Label_catatan.TabIndex = 338
        Me.Label_catatan.Text = "Catatan"
        Me.Label_catatan.Visible = False
        '
        'Text_ket
        '
        Me.Text_ket.Location = New System.Drawing.Point(139, 54)
        Me.Text_ket.Margin = New System.Windows.Forms.Padding(4)
        Me.Text_ket.Multiline = True
        Me.Text_ket.Name = "Text_ket"
        Me.Text_ket.Size = New System.Drawing.Size(360, 88)
        Me.Text_ket.TabIndex = 337
        Me.Text_ket.Visible = False
        '
        'Button_cetak
        '
        Me.Button_cetak.Location = New System.Drawing.Point(396, 16)
        Me.Button_cetak.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_cetak.Name = "Button_cetak"
        Me.Button_cetak.Size = New System.Drawing.Size(100, 28)
        Me.Button_cetak.TabIndex = 336
        Me.Button_cetak.Text = "cetak"
        Me.Button_cetak.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 18)
        Me.Label1.TabIndex = 335
        Me.Label1.Text = "Jenis Laporan"
        '
        'Combo_JLaporan
        '
        Me.Combo_JLaporan.FormattingEnabled = True
        Me.Combo_JLaporan.Location = New System.Drawing.Point(139, 18)
        Me.Combo_JLaporan.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_JLaporan.Name = "Combo_JLaporan"
        Me.Combo_JLaporan.Size = New System.Drawing.Size(239, 24)
        Me.Combo_JLaporan.TabIndex = 334
        '
        'FormAbsensiKhusus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1827, 923)
        Me.Controls.Add(Me.Group_cetak)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label_filter)
        Me.Controls.Add(Me.Combo_filter)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Combo_Opt)
        Me.Controls.Add(Me.Text_pencarian)
        Me.Controls.Add(Me.Grid_karyawan)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Group_periode)
        Me.Controls.Add(Me.PictureBox1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormAbsensiKhusus"
        Me.Text = "Form1Sample"
        Me.Group_periode.ResumeLayout(False)
        Me.Group_periode.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid_karyawan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grid_dtabsen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Group_cetak.ResumeLayout(False)
        Me.Group_cetak.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Group_periode As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DT_tglakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents DT_tglawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Combo_Opt As System.Windows.Forms.ComboBox
    Friend WithEvents Text_pencarian As System.Windows.Forms.TextBox
    Friend WithEvents Grid_karyawan As System.Windows.Forms.DataGridView
    Friend WithEvents Label_filter As System.Windows.Forms.Label
    Friend WithEvents Combo_filter As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grid_dtabsen As System.Windows.Forms.DataGridView
    Friend WithEvents Group_cetak As System.Windows.Forms.GroupBox
    Friend WithEvents Button_cetak As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Combo_JLaporan As System.Windows.Forms.ComboBox
    Friend WithEvents Label_catatan As System.Windows.Forms.Label
    Friend WithEvents Text_ket As System.Windows.Forms.TextBox
End Class
