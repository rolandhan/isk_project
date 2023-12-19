<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormImportData
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
        Me.Button_simpan = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Text_sheet = New System.Windows.Forms.TextBox()
        Me.Button_browse = New System.Windows.Forms.Button()
        Me.grid_tampilan = New System.Windows.Forms.DataGridView()
        Me.Combo_jenis = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.grid_tampilan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button_simpan
        '
        Me.Button_simpan.Location = New System.Drawing.Point(803, 194)
        Me.Button_simpan.Name = "Button_simpan"
        Me.Button_simpan.Size = New System.Drawing.Size(75, 23)
        Me.Button_simpan.TabIndex = 14
        Me.Button_simpan.Text = "simpan"
        Me.Button_simpan.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "sheet name"
        '
        'Text_sheet
        '
        Me.Text_sheet.Location = New System.Drawing.Point(137, 149)
        Me.Text_sheet.Name = "Text_sheet"
        Me.Text_sheet.Size = New System.Drawing.Size(179, 20)
        Me.Text_sheet.TabIndex = 12
        '
        'Button_browse
        '
        Me.Button_browse.Location = New System.Drawing.Point(344, 147)
        Me.Button_browse.Name = "Button_browse"
        Me.Button_browse.Size = New System.Drawing.Size(75, 23)
        Me.Button_browse.TabIndex = 10
        Me.Button_browse.Text = "browse"
        Me.Button_browse.UseVisualStyleBackColor = True
        '
        'grid_tampilan
        '
        Me.grid_tampilan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_tampilan.Location = New System.Drawing.Point(41, 194)
        Me.grid_tampilan.Name = "grid_tampilan"
        Me.grid_tampilan.Size = New System.Drawing.Size(746, 434)
        Me.grid_tampilan.TabIndex = 11
        '
        'Combo_jenis
        '
        Me.Combo_jenis.FormattingEnabled = True
        Me.Combo_jenis.Location = New System.Drawing.Point(137, 122)
        Me.Combo_jenis.Name = "Combo_jenis"
        Me.Combo_jenis.Size = New System.Drawing.Size(179, 21)
        Me.Combo_jenis.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(43, 125)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Jenis Data"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SteelBlue
        Me.Label1.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label1.Location = New System.Drawing.Point(9, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 41)
        Me.Label1.TabIndex = 337
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label12.Location = New System.Drawing.Point(19, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(326, 41)
        Me.Label12.TabIndex = 336
        Me.Label12.Text = "FORM IMPORT FILE"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox2.Location = New System.Drawing.Point(2, 608)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1367, 135)
        Me.PictureBox2.TabIndex = 335
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox1.Location = New System.Drawing.Point(2, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1367, 65)
        Me.PictureBox1.TabIndex = 334
        Me.PictureBox1.TabStop = False
        '
        'FormImportData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1370, 750)
        Me.Controls.Add(Me.grid_tampilan)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Combo_jenis)
        Me.Controls.Add(Me.Button_simpan)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Text_sheet)
        Me.Controls.Add(Me.Button_browse)
        Me.Name = "FormImportData"
        CType(Me.grid_tampilan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button_simpan As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Text_sheet As System.Windows.Forms.TextBox
    Friend WithEvents Button_browse As System.Windows.Forms.Button
    Friend WithEvents grid_tampilan As System.Windows.Forms.DataGridView
    Friend WithEvents Combo_jenis As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
