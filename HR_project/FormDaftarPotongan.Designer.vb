<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDaftarPotongan
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Group_periode = New System.Windows.Forms.GroupBox()
        Me.DTakhir = New System.Windows.Forms.DateTimePicker()
        Me.DTawal = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.combo_jenis = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.grid_tampilan = New System.Windows.Forms.DataGridView()
        Me.Label_judul = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Group_periode.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.grid_tampilan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label2.Location = New System.Drawing.Point(26, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(754, 41)
        Me.Label2.TabIndex = 361
        Me.Label2.Text = "FORM DAFTAR POTONGAN DAN PELANGGARAN"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox1.Location = New System.Drawing.Point(2, 608)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1367, 135)
        Me.PictureBox1.TabIndex = 360
        Me.PictureBox1.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.White
        Me.PictureBox3.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox3.Location = New System.Drawing.Point(2, 5)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(1367, 65)
        Me.PictureBox3.TabIndex = 359
        Me.PictureBox3.TabStop = False
        '
        'Group_periode
        '
        Me.Group_periode.Controls.Add(Me.DTakhir)
        Me.Group_periode.Controls.Add(Me.DTawal)
        Me.Group_periode.Controls.Add(Me.Label4)
        Me.Group_periode.Controls.Add(Me.Label3)
        Me.Group_periode.Location = New System.Drawing.Point(12, 76)
        Me.Group_periode.Name = "Group_periode"
        Me.Group_periode.Size = New System.Drawing.Size(396, 44)
        Me.Group_periode.TabIndex = 362
        Me.Group_periode.TabStop = False
        '
        'DTakhir
        '
        Me.DTakhir.Location = New System.Drawing.Point(227, 15)
        Me.DTakhir.Name = "DTakhir"
        Me.DTakhir.Size = New System.Drawing.Size(133, 20)
        Me.DTakhir.TabIndex = 350
        '
        'DTawal
        '
        Me.DTawal.Location = New System.Drawing.Point(58, 17)
        Me.DTawal.Name = "DTawal"
        Me.DTawal.Size = New System.Drawing.Size(133, 20)
        Me.DTawal.TabIndex = 349
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(197, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 16)
        Me.Label4.TabIndex = 347
        Me.Label4.Text = "Ke"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 16)
        Me.Label3.TabIndex = 345
        Me.Label3.Text = "Dari"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.combo_jenis)
        Me.GroupBox1.Location = New System.Drawing.Point(414, 76)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(504, 44)
        Me.GroupBox1.TabIndex = 369
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 16)
        Me.Label5.TabIndex = 369
        Me.Label5.Text = "Jenis"
        '
        'combo_jenis
        '
        Me.combo_jenis.FormattingEnabled = True
        Me.combo_jenis.Location = New System.Drawing.Point(64, 15)
        Me.combo_jenis.Name = "combo_jenis"
        Me.combo_jenis.Size = New System.Drawing.Size(425, 21)
        Me.combo_jenis.TabIndex = 370
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label_judul)
        Me.GroupBox2.Controls.Add(Me.grid_tampilan)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 141)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(906, 474)
        Me.GroupBox2.TabIndex = 370
        Me.GroupBox2.TabStop = False
        '
        'grid_tampilan
        '
        Me.grid_tampilan.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grid_tampilan.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid_tampilan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grid_tampilan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_tampilan.Location = New System.Drawing.Point(14, 56)
        Me.grid_tampilan.Name = "grid_tampilan"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid_tampilan.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grid_tampilan.Size = New System.Drawing.Size(877, 405)
        Me.grid_tampilan.TabIndex = 0
        '
        'Label_judul
        '
        Me.Label_judul.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_judul.Location = New System.Drawing.Point(9, 16)
        Me.Label_judul.Name = "Label_judul"
        Me.Label_judul.Size = New System.Drawing.Size(882, 23)
        Me.Label_judul.TabIndex = 1
        Me.Label_judul.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FormDaftarPotongan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1370, 749)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Group_periode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Name = "FormDaftarPotongan"
        Me.Text = "FormDaftarPotongan"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Group_periode.ResumeLayout(False)
        Me.Group_periode.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.grid_tampilan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Group_periode As System.Windows.Forms.GroupBox
    Friend WithEvents DTakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents combo_jenis As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents grid_tampilan As System.Windows.Forms.DataGridView
    Friend WithEvents Label_judul As System.Windows.Forms.Label
End Class
