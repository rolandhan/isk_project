<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAbsensi
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
        Me.DTawal = New System.Windows.Forms.DateTimePicker()
        Me.DTakhir = New System.Windows.Forms.DateTimePicker()
        Me.combo_Departemen = New System.Windows.Forms.ComboBox()
        Me.Button_tampil = New System.Windows.Forms.Button()
        Me.grid_tampil = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.grid_detabsensi = New System.Windows.Forms.DataGridView()
        Me.Button_reload = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CekHistoriToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button_simpan = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.grid_tampil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grid_detabsensi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DTawal
        '
        Me.DTawal.Location = New System.Drawing.Point(115, 84)
        Me.DTawal.Name = "DTawal"
        Me.DTawal.Size = New System.Drawing.Size(136, 20)
        Me.DTawal.TabIndex = 0
        '
        'DTakhir
        '
        Me.DTakhir.Location = New System.Drawing.Point(115, 110)
        Me.DTakhir.Name = "DTakhir"
        Me.DTakhir.Size = New System.Drawing.Size(136, 20)
        Me.DTakhir.TabIndex = 1
        '
        'combo_Departemen
        '
        Me.combo_Departemen.FormattingEnabled = True
        Me.combo_Departemen.Location = New System.Drawing.Point(115, 134)
        Me.combo_Departemen.Name = "combo_Departemen"
        Me.combo_Departemen.Size = New System.Drawing.Size(185, 21)
        Me.combo_Departemen.TabIndex = 2
        '
        'Button_tampil
        '
        Me.Button_tampil.Location = New System.Drawing.Point(306, 132)
        Me.Button_tampil.Name = "Button_tampil"
        Me.Button_tampil.Size = New System.Drawing.Size(43, 23)
        Me.Button_tampil.TabIndex = 3
        Me.Button_tampil.Text = "Go"
        Me.Button_tampil.UseVisualStyleBackColor = True
        '
        'grid_tampil
        '
        Me.grid_tampil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_tampil.Location = New System.Drawing.Point(23, 171)
        Me.grid_tampil.Name = "grid_tampil"
        Me.grid_tampil.Size = New System.Drawing.Size(774, 390)
        Me.grid_tampil.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grid_detabsensi)
        Me.GroupBox1.Location = New System.Drawing.Point(822, 83)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(452, 499)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detail Absensi"
        '
        'grid_detabsensi
        '
        Me.grid_detabsensi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_detabsensi.Location = New System.Drawing.Point(17, 31)
        Me.grid_detabsensi.Name = "grid_detabsensi"
        Me.grid_detabsensi.Size = New System.Drawing.Size(406, 442)
        Me.grid_detabsensi.TabIndex = 0
        '
        'Button_reload
        '
        Me.Button_reload.Location = New System.Drawing.Point(23, 574)
        Me.Button_reload.Name = "Button_reload"
        Me.Button_reload.Size = New System.Drawing.Size(56, 34)
        Me.Button_reload.TabIndex = 6
        Me.Button_reload.Text = "Reload"
        Me.Button_reload.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CekHistoriToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(129, 26)
        '
        'CekHistoriToolStripMenuItem
        '
        Me.CekHistoriToolStripMenuItem.Name = "CekHistoriToolStripMenuItem"
        Me.CekHistoriToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.CekHistoriToolStripMenuItem.Text = "cek histori"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Departemen :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Dari:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Ke:"
        '
        'Button_simpan
        '
        Me.Button_simpan.Location = New System.Drawing.Point(85, 574)
        Me.Button_simpan.Name = "Button_simpan"
        Me.Button_simpan.Size = New System.Drawing.Size(56, 34)
        Me.Button_simpan.TabIndex = 10
        Me.Button_simpan.Text = "Simpan"
        Me.Button_simpan.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label14.Location = New System.Drawing.Point(9, 10)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(10, 41)
        Me.Label14.TabIndex = 324
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(19, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(578, 41)
        Me.Label4.TabIndex = 323
        Me.Label4.Text = "FORM PENGOLAHAN DATA ABSENSI"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox1.Location = New System.Drawing.Point(2, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1367, 65)
        Me.PictureBox1.TabIndex = 322
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox2.Location = New System.Drawing.Point(2, 603)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1367, 135)
        Me.PictureBox2.TabIndex = 325
        Me.PictureBox2.TabStop = False
        '
        'FormAbsensi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1370, 750)
        Me.Controls.Add(Me.Button_reload)
        Me.Controls.Add(Me.Button_simpan)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grid_tampil)
        Me.Controls.Add(Me.Button_tampil)
        Me.Controls.Add(Me.combo_Departemen)
        Me.Controls.Add(Me.DTakhir)
        Me.Controls.Add(Me.DTawal)
        Me.Name = "FormAbsensi"
        Me.Text = "FormAbsensi"
        CType(Me.grid_tampil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grid_detabsensi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DTawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents combo_Departemen As System.Windows.Forms.ComboBox
    Friend WithEvents Button_tampil As System.Windows.Forms.Button
    Friend WithEvents grid_tampil As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents grid_detabsensi As System.Windows.Forms.DataGridView
    Friend WithEvents Button_reload As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CekHistoriToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button_simpan As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
