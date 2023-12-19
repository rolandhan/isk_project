<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRekapTahunan
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
        Me.grid_karyawan = New System.Windows.Forms.DataGridView()
        Me.DT_tglke = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DT_tgldari = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Button_go = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.grid_karyawan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grid_karyawan
        '
        Me.grid_karyawan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_karyawan.Location = New System.Drawing.Point(21, 138)
        Me.grid_karyawan.Name = "grid_karyawan"
        Me.grid_karyawan.Size = New System.Drawing.Size(1212, 453)
        Me.grid_karyawan.TabIndex = 0
        '
        'DT_tglke
        '
        Me.DT_tglke.Location = New System.Drawing.Point(355, 92)
        Me.DT_tglke.Name = "DT_tglke"
        Me.DT_tglke.Size = New System.Drawing.Size(200, 20)
        Me.DT_tglke.TabIndex = 205
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(322, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 15)
        Me.Label2.TabIndex = 204
        Me.Label2.Text = "Ke"
        '
        'DT_tgldari
        '
        Me.DT_tgldari.Location = New System.Drawing.Point(93, 93)
        Me.DT_tgldari.Name = "DT_tgldari"
        Me.DT_tgldari.Size = New System.Drawing.Size(200, 20)
        Me.DT_tgldari.TabIndex = 203
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(43, 92)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(30, 15)
        Me.Label13.TabIndex = 202
        Me.Label13.Text = "Dari"
        '
        'Button_go
        '
        Me.Button_go.Location = New System.Drawing.Point(575, 88)
        Me.Button_go.Name = "Button_go"
        Me.Button_go.Size = New System.Drawing.Size(39, 22)
        Me.Button_go.TabIndex = 206
        Me.Button_go.Text = "Go !"
        Me.Button_go.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label14.Location = New System.Drawing.Point(9, 17)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(10, 41)
        Me.Label14.TabIndex = 325
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(19, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(495, 41)
        Me.Label4.TabIndex = 324
        Me.Label4.Text = "FORM REKAPITULASI KHUSUS"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox2.Location = New System.Drawing.Point(2, 608)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1367, 135)
        Me.PictureBox2.TabIndex = 323
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox1.Location = New System.Drawing.Point(2, 7)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1367, 65)
        Me.PictureBox1.TabIndex = 322
        Me.PictureBox1.TabStop = False
        '
        'FormRekapTahunan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1370, 750)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button_go)
        Me.Controls.Add(Me.DT_tglke)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DT_tgldari)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.grid_karyawan)
        Me.Name = "FormRekapTahunan"
        Me.Text = "FormRekapTahunan"
        CType(Me.grid_karyawan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grid_karyawan As System.Windows.Forms.DataGridView
    Friend WithEvents DT_tglke As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DT_tgldari As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Button_go As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
