<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPengaturanLaporan
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Combo_JnsLap = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.Tab_BagKhusus = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.grid_nama = New System.Windows.Forms.DataGridView()
        Me.Buttontambah = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Combo_nama = New System.Windows.Forms.ComboBox()
        Me.TabLap = New System.Windows.Forms.TabPage()
        Me.BSaveLap = New System.Windows.Forms.Button()
        Me.ComboManager = New System.Windows.Forms.ComboBox()
        Me.ComboStaff = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextKode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.HapusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.Tab_BagKhusus.SuspendLayout()
        CType(Me.grid_nama, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabLap.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(24, 20)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(630, 52)
        Me.Label4.TabIndex = 335
        Me.Label4.Text = "FORM PENGATURAN LAPORAN"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox2.Location = New System.Drawing.Point(2, 750)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1823, 166)
        Me.PictureBox2.TabIndex = 336
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox3.Location = New System.Drawing.Point(2, 7)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(1823, 80)
        Me.PictureBox3.TabIndex = 334
        Me.PictureBox3.TabStop = False
        '
        'Combo_JnsLap
        '
        Me.Combo_JnsLap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_JnsLap.FormattingEnabled = True
        Me.Combo_JnsLap.Location = New System.Drawing.Point(24, 45)
        Me.Combo_JnsLap.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_JnsLap.Name = "Combo_JnsLap"
        Me.Combo_JnsLap.Size = New System.Drawing.Size(560, 28)
        Me.Combo_JnsLap.TabIndex = 337
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 21)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 20)
        Me.Label1.TabIndex = 338
        Me.Label1.Text = "Jenis Laporan"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Tab_BagKhusus)
        Me.TabControl1.Controls.Add(Me.TabLap)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(33, 146)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1170, 566)
        Me.TabControl1.TabIndex = 339
        '
        'Tab_BagKhusus
        '
        Me.Tab_BagKhusus.BackColor = System.Drawing.Color.White
        Me.Tab_BagKhusus.Controls.Add(Me.Button2)
        Me.Tab_BagKhusus.Controls.Add(Me.Button1)
        Me.Tab_BagKhusus.Controls.Add(Me.grid_nama)
        Me.Tab_BagKhusus.Controls.Add(Me.Buttontambah)
        Me.Tab_BagKhusus.Controls.Add(Me.Label2)
        Me.Tab_BagKhusus.Controls.Add(Me.Combo_nama)
        Me.Tab_BagKhusus.Location = New System.Drawing.Point(4, 29)
        Me.Tab_BagKhusus.Name = "Tab_BagKhusus"
        Me.Tab_BagKhusus.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab_BagKhusus.Size = New System.Drawing.Size(1162, 533)
        Me.Tab_BagKhusus.TabIndex = 0
        Me.Tab_BagKhusus.Text = "Pengaturan Bagian Khusus"
        '
        'Button2
        '
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = Global.HR_project.My.Resources.Resources._new
        Me.Button2.Location = New System.Drawing.Point(766, 29)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(48, 42)
        Me.Button2.TabIndex = 352
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.HR_project.My.Resources.Resources.save
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(766, 436)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 70)
        Me.Button1.TabIndex = 351
        Me.Button1.Text = "simpan"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'grid_nama
        '
        Me.grid_nama.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_nama.Location = New System.Drawing.Point(185, 153)
        Me.grid_nama.Name = "grid_nama"
        Me.grid_nama.RowTemplate.Height = 24
        Me.grid_nama.Size = New System.Drawing.Size(556, 362)
        Me.grid_nama.TabIndex = 350
        '
        'Buttontambah
        '
        Me.Buttontambah.BackgroundImage = Global.HR_project.My.Resources.Resources.add
        Me.Buttontambah.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Buttontambah.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Buttontambah.FlatAppearance.BorderSize = 0
        Me.Buttontambah.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.Buttontambah.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.Buttontambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buttontambah.Location = New System.Drawing.Point(183, 85)
        Me.Buttontambah.Margin = New System.Windows.Forms.Padding(4)
        Me.Buttontambah.Name = "Buttontambah"
        Me.Buttontambah.Size = New System.Drawing.Size(32, 32)
        Me.Buttontambah.TabIndex = 346
        Me.Buttontambah.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 47)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 20)
        Me.Label2.TabIndex = 339
        Me.Label2.Text = "Jenis Laporan"
        '
        'Combo_nama
        '
        Me.Combo_nama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_nama.FormattingEnabled = True
        Me.Combo_nama.Location = New System.Drawing.Point(183, 39)
        Me.Combo_nama.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_nama.Name = "Combo_nama"
        Me.Combo_nama.Size = New System.Drawing.Size(560, 28)
        Me.Combo_nama.TabIndex = 338
        '
        'TabLap
        '
        Me.TabLap.Controls.Add(Me.BSaveLap)
        Me.TabLap.Controls.Add(Me.ComboManager)
        Me.TabLap.Controls.Add(Me.ComboStaff)
        Me.TabLap.Controls.Add(Me.Label7)
        Me.TabLap.Controls.Add(Me.Label1)
        Me.TabLap.Controls.Add(Me.Combo_JnsLap)
        Me.TabLap.Controls.Add(Me.Label6)
        Me.TabLap.Controls.Add(Me.TextKode)
        Me.TabLap.Controls.Add(Me.Label5)
        Me.TabLap.Location = New System.Drawing.Point(4, 29)
        Me.TabLap.Name = "TabLap"
        Me.TabLap.Padding = New System.Windows.Forms.Padding(3)
        Me.TabLap.Size = New System.Drawing.Size(1162, 533)
        Me.TabLap.TabIndex = 1
        Me.TabLap.Text = "Pengaturan Laporan Triwulan"
        Me.TabLap.UseVisualStyleBackColor = True
        '
        'BSaveLap
        '
        Me.BSaveLap.FlatAppearance.BorderSize = 0
        Me.BSaveLap.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BSaveLap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BSaveLap.Image = Global.HR_project.My.Resources.Resources.save
        Me.BSaveLap.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BSaveLap.Location = New System.Drawing.Point(24, 407)
        Me.BSaveLap.Margin = New System.Windows.Forms.Padding(4)
        Me.BSaveLap.Name = "BSaveLap"
        Me.BSaveLap.Size = New System.Drawing.Size(91, 70)
        Me.BSaveLap.TabIndex = 350
        Me.BSaveLap.Text = "simpan"
        Me.BSaveLap.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BSaveLap.UseVisualStyleBackColor = True
        '
        'ComboManager
        '
        Me.ComboManager.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboManager.FormattingEnabled = True
        Me.ComboManager.Location = New System.Drawing.Point(24, 305)
        Me.ComboManager.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboManager.Name = "ComboManager"
        Me.ComboManager.Size = New System.Drawing.Size(560, 28)
        Me.ComboManager.TabIndex = 349
        '
        'ComboStaff
        '
        Me.ComboStaff.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboStaff.FormattingEnabled = True
        Me.ComboStaff.Location = New System.Drawing.Point(24, 203)
        Me.ComboStaff.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboStaff.Name = "ComboStaff"
        Me.ComboStaff.Size = New System.Drawing.Size(560, 28)
        Me.ComboStaff.TabIndex = 348
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(20, 271)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(123, 20)
        Me.Label7.TabIndex = 346
        Me.Label7.Text = "Nama Manager"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(20, 168)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(177, 20)
        Me.Label6.TabIndex = 344
        Me.Label6.Text = "Nama Staff Personalia"
        '
        'TextKode
        '
        Me.TextKode.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextKode.Location = New System.Drawing.Point(24, 114)
        Me.TextKode.Margin = New System.Windows.Forms.Padding(4)
        Me.TextKode.Name = "TextKode"
        Me.TextKode.Size = New System.Drawing.Size(560, 29)
        Me.TextKode.TabIndex = 343
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 90)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(157, 20)
        Me.Label5.TabIndex = 342
        Me.Label5.Text = "Kode Form Laporan"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HapusToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(118, 28)
        '
        'HapusToolStripMenuItem
        '
        Me.HapusToolStripMenuItem.Name = "HapusToolStripMenuItem"
        Me.HapusToolStripMenuItem.Size = New System.Drawing.Size(117, 24)
        Me.HapusToolStripMenuItem.Text = "hapus"
        '
        'FormPengaturanLaporan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1827, 923)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Name = "FormPengaturanLaporan"
        Me.Text = "FormPengaturanLaporan"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.Tab_BagKhusus.ResumeLayout(False)
        Me.Tab_BagKhusus.PerformLayout()
        CType(Me.grid_nama, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabLap.ResumeLayout(False)
        Me.TabLap.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Combo_JnsLap As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Tab_BagKhusus As System.Windows.Forms.TabPage
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Combo_nama As System.Windows.Forms.ComboBox
    Friend WithEvents TabLap As System.Windows.Forms.TabPage
    Friend WithEvents Buttontambah As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextKode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents HapusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grid_nama As System.Windows.Forms.DataGridView
    Friend WithEvents BSaveLap As System.Windows.Forms.Button
    Friend WithEvents ComboManager As System.Windows.Forms.ComboBox
    Friend WithEvents ComboStaff As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
