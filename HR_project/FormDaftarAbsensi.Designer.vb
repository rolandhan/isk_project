﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDaftarAbsensi
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grid_absen = New System.Windows.Forms.DataGridView()
        Me.combo_dept = New System.Windows.Forms.ComboBox()
        Me.DTanggal = New System.Windows.Forms.DateTimePicker()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button_go = New System.Windows.Forms.Button()
        Me.Text_pencarian = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        CType(Me.grid_absen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Tanggal : "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(303, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 16)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Departemen :"
        '
        'grid_absen
        '
        Me.grid_absen.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grid_absen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_absen.Location = New System.Drawing.Point(25, 147)
        Me.grid_absen.Name = "grid_absen"
        Me.grid_absen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_absen.Size = New System.Drawing.Size(774, 390)
        Me.grid_absen.TabIndex = 14
        '
        'combo_dept
        '
        Me.combo_dept.FormattingEnabled = True
        Me.combo_dept.Location = New System.Drawing.Point(398, 86)
        Me.combo_dept.Name = "combo_dept"
        Me.combo_dept.Size = New System.Drawing.Size(401, 21)
        Me.combo_dept.TabIndex = 12
        '
        'DTanggal
        '
        Me.DTanggal.Location = New System.Drawing.Point(118, 86)
        Me.DTanggal.Name = "DTanggal"
        Me.DTanggal.Size = New System.Drawing.Size(136, 20)
        Me.DTanggal.TabIndex = 10
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox2.Location = New System.Drawing.Point(2, 609)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1367, 135)
        Me.PictureBox2.TabIndex = 327
        Me.PictureBox2.TabStop = False
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
        'Button_go
        '
        Me.Button_go.Location = New System.Drawing.Point(118, 112)
        Me.Button_go.Name = "Button_go"
        Me.Button_go.Size = New System.Drawing.Size(32, 23)
        Me.Button_go.TabIndex = 328
        Me.Button_go.Text = "Go"
        Me.Button_go.UseVisualStyleBackColor = True
        '
        'Text_pencarian
        '
        Me.Text_pencarian.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_pencarian.Location = New System.Drawing.Point(306, 119)
        Me.Text_pencarian.Name = "Text_pencarian"
        Me.Text_pencarian.Size = New System.Drawing.Size(493, 22)
        Me.Text_pencarian.TabIndex = 329
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label14.Location = New System.Drawing.Point(9, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(10, 41)
        Me.Label14.TabIndex = 331
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(19, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(388, 41)
        Me.Label4.TabIndex = 330
        Me.Label4.Text = "FORM ABSENSI HARIAN"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(95, 26)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(94, 22)
        Me.EditToolStripMenuItem.Text = "edit"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(35, 548)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 16)
        Me.Label3.TabIndex = 332
        Me.Label3.Text = "INFO :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(92, 548)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(388, 16)
        Me.Label5.TabIndex = 333
        Me.Label5.Text = "untuk keterangan hanya data libur yang bisa di masukan / di edit"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.HR_project.My.Resources.Resources.find_21
        Me.PictureBox3.Location = New System.Drawing.Point(779, 121)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 349
        Me.PictureBox3.TabStop = False
        '
        'FormDaftarAbsensi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1370, 750)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Text_pencarian)
        Me.Controls.Add(Me.Button_go)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grid_absen)
        Me.Controls.Add(Me.combo_dept)
        Me.Controls.Add(Me.DTanggal)
        Me.Name = "FormDaftarAbsensi"
        Me.Text = "FORM ABSENSI HARIAN"
        CType(Me.grid_absen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grid_absen As System.Windows.Forms.DataGridView
    Friend WithEvents combo_dept As System.Windows.Forms.ComboBox
    Friend WithEvents DTanggal As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button_go As System.Windows.Forms.Button
    Friend WithEvents Text_pencarian As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
End Class
