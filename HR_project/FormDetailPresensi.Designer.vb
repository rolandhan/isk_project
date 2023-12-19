<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDetailPresensi
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
        Me.grid_tampil = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.combo_dept = New System.Windows.Forms.ComboBox()
        Me.DTakhir = New System.Windows.Forms.DateTimePicker()
        Me.DTawal = New System.Windows.Forms.DateTimePicker()
        Me.Button_tampil = New System.Windows.Forms.Button()
        Me.grid_detaildata = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.combo_status = New System.Windows.Forms.ComboBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CekHistoriToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CekLaporanPersonalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Text_nama = New System.Windows.Forms.TextBox()
        CType(Me.grid_tampil, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid_detaildata, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grid_tampil
        '
        Me.grid_tampil.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grid_tampil.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grid_tampil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_tampil.Location = New System.Drawing.Point(22, 181)
        Me.grid_tampil.Name = "grid_tampil"
        Me.grid_tampil.Size = New System.Drawing.Size(824, 455)
        Me.grid_tampil.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 16)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Ke:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Dari:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(262, 121)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Status"
        '
        'combo_dept
        '
        Me.combo_dept.FormattingEnabled = True
        Me.combo_dept.Location = New System.Drawing.Point(351, 89)
        Me.combo_dept.Name = "combo_dept"
        Me.combo_dept.Size = New System.Drawing.Size(191, 21)
        Me.combo_dept.TabIndex = 12
        '
        'DTakhir
        '
        Me.DTakhir.Location = New System.Drawing.Point(67, 43)
        Me.DTakhir.Name = "DTakhir"
        Me.DTakhir.Size = New System.Drawing.Size(138, 20)
        Me.DTakhir.TabIndex = 11
        '
        'DTawal
        '
        Me.DTawal.Location = New System.Drawing.Point(67, 18)
        Me.DTawal.Name = "DTawal"
        Me.DTawal.Size = New System.Drawing.Size(138, 20)
        Me.DTawal.TabIndex = 10
        '
        'Button_tampil
        '
        Me.Button_tampil.Location = New System.Drawing.Point(18, 72)
        Me.Button_tampil.Name = "Button_tampil"
        Me.Button_tampil.Size = New System.Drawing.Size(43, 23)
        Me.Button_tampil.TabIndex = 16
        Me.Button_tampil.Text = "Go"
        Me.Button_tampil.UseVisualStyleBackColor = True
        '
        'grid_detaildata
        '
        Me.grid_detaildata.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grid_detaildata.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grid_detaildata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_detaildata.Location = New System.Drawing.Point(866, 181)
        Me.grid_detaildata.Name = "grid_detaildata"
        Me.grid_detaildata.Size = New System.Drawing.Size(435, 188)
        Me.grid_detaildata.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(262, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 16)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Departemen"
        '
        'combo_status
        '
        Me.combo_status.FormattingEnabled = True
        Me.combo_status.Location = New System.Drawing.Point(351, 116)
        Me.combo_status.Name = "combo_status"
        Me.combo_status.Size = New System.Drawing.Size(191, 21)
        Me.combo_status.TabIndex = 20
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CekHistoriToolStripMenuItem, Me.ToolStripMenuItem1, Me.CekLaporanPersonalToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(184, 54)
        '
        'CekHistoriToolStripMenuItem
        '
        Me.CekHistoriToolStripMenuItem.Name = "CekHistoriToolStripMenuItem"
        Me.CekHistoriToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.CekHistoriToolStripMenuItem.Text = "cek histori"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(180, 6)
        '
        'CekLaporanPersonalToolStripMenuItem
        '
        Me.CekLaporanPersonalToolStripMenuItem.Name = "CekLaporanPersonalToolStripMenuItem"
        Me.CekLaporanPersonalToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.CekLaporanPersonalToolStripMenuItem.Text = "cek laporan personal"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button_tampil)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.DTakhir)
        Me.GroupBox2.Controls.Add(Me.DTawal)
        Me.GroupBox2.Location = New System.Drawing.Point(22, 75)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(222, 101)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox2.Location = New System.Drawing.Point(2, 609)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1367, 135)
        Me.PictureBox2.TabIndex = 329
        Me.PictureBox2.TabStop = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label14.Location = New System.Drawing.Point(9, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(10, 41)
        Me.Label14.TabIndex = 328
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label5.Location = New System.Drawing.Point(19, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(351, 41)
        Me.Label5.TabIndex = 327
        Me.Label5.Text = "FORM DATA ABSENSI"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox1.Location = New System.Drawing.Point(2, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1367, 65)
        Me.PictureBox1.TabIndex = 326
        Me.PictureBox1.TabStop = False
        '
        'Text_nama
        '
        Me.Text_nama.Location = New System.Drawing.Point(265, 149)
        Me.Text_nama.Name = "Text_nama"
        Me.Text_nama.Size = New System.Drawing.Size(277, 20)
        Me.Text_nama.TabIndex = 23
        '
        'FormDetailPresensi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1370, 750)
        Me.Controls.Add(Me.grid_tampil)
        Me.Controls.Add(Me.Text_nama)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.combo_status)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.grid_detaildata)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.combo_dept)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "FormDetailPresensi"
        Me.Text = "FormDetailPresensi"
        CType(Me.grid_tampil, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid_detaildata, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grid_tampil As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents combo_dept As System.Windows.Forms.ComboBox
    Friend WithEvents DTakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button_tampil As System.Windows.Forms.Button
    Friend WithEvents grid_detaildata As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents combo_status As System.Windows.Forms.ComboBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CekHistoriToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CekLaporanPersonalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Text_nama As System.Windows.Forms.TextBox
End Class
