<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLogIn
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
        Me.Checkpass = New System.Windows.Forms.CheckBox()
        Me.Button_cancel = New System.Windows.Forms.Button()
        Me.Labelpass = New System.Windows.Forms.Label()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.txtuserid = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Labeluser = New System.Windows.Forms.Label()
        Me.Bsimpan = New System.Windows.Forms.Button()
        Me.cmbAuth = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Checkpass
        '
        Me.Checkpass.AutoSize = True
        Me.Checkpass.Location = New System.Drawing.Point(339, 100)
        Me.Checkpass.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Checkpass.Name = "Checkpass"
        Me.Checkpass.Size = New System.Drawing.Size(154, 21)
        Me.Checkpass.TabIndex = 90
        Me.Checkpass.Text = "tampilkan password"
        Me.Checkpass.UseVisualStyleBackColor = True
        '
        'Button_cancel
        '
        Me.Button_cancel.Location = New System.Drawing.Point(451, 176)
        Me.Button_cancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button_cancel.Name = "Button_cancel"
        Me.Button_cancel.Size = New System.Drawing.Size(108, 36)
        Me.Button_cancel.TabIndex = 89
        Me.Button_cancel.Text = "cancel"
        Me.Button_cancel.UseVisualStyleBackColor = True
        '
        'Labelpass
        '
        Me.Labelpass.AutoSize = True
        Me.Labelpass.BackColor = System.Drawing.Color.White
        Me.Labelpass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelpass.ForeColor = System.Drawing.Color.DarkBlue
        Me.Labelpass.Location = New System.Drawing.Point(160, 64)
        Me.Labelpass.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Labelpass.Name = "Labelpass"
        Me.Labelpass.Size = New System.Drawing.Size(106, 25)
        Me.Labelpass.TabIndex = 88
        Me.Labelpass.Text = "Password"
        '
        'txtpassword
        '
        Me.txtpassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpassword.Location = New System.Drawing.Point(336, 59)
        Me.txtpassword.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassword.Size = New System.Drawing.Size(221, 29)
        Me.txtpassword.TabIndex = 1
        '
        'txtuserid
        '
        Me.txtuserid.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtuserid.Location = New System.Drawing.Point(336, 23)
        Me.txtuserid.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtuserid.Name = "txtuserid"
        Me.txtuserid.Size = New System.Drawing.Size(221, 29)
        Me.txtuserid.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.GroupBox1.Controls.Add(Me.Checkpass)
        Me.GroupBox1.Controls.Add(Me.Button_cancel)
        Me.GroupBox1.Controls.Add(Me.Labelpass)
        Me.GroupBox1.Controls.Add(Me.txtpassword)
        Me.GroupBox1.Controls.Add(Me.txtuserid)
        Me.GroupBox1.Controls.Add(Me.Labeluser)
        Me.GroupBox1.Controls.Add(Me.Bsimpan)
        Me.GroupBox1.Controls.Add(Me.cmbAuth)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.PictureBox2)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBox1.Location = New System.Drawing.Point(33, 174)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(576, 230)
        Me.GroupBox1.TabIndex = 103
        Me.GroupBox1.TabStop = False
        '
        'Labeluser
        '
        Me.Labeluser.AutoSize = True
        Me.Labeluser.BackColor = System.Drawing.Color.White
        Me.Labeluser.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labeluser.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Labeluser.Location = New System.Drawing.Point(160, 28)
        Me.Labeluser.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Labeluser.Name = "Labeluser"
        Me.Labeluser.Size = New System.Drawing.Size(57, 25)
        Me.Labeluser.TabIndex = 85
        Me.Labeluser.Text = "User"
        '
        'Bsimpan
        '
        Me.Bsimpan.Location = New System.Drawing.Point(335, 176)
        Me.Bsimpan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Bsimpan.Name = "Bsimpan"
        Me.Bsimpan.Size = New System.Drawing.Size(108, 36)
        Me.Bsimpan.TabIndex = 84
        Me.Bsimpan.Text = "Log in"
        Me.Bsimpan.UseVisualStyleBackColor = True
        '
        'cmbAuth
        '
        Me.cmbAuth.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAuth.FormattingEnabled = True
        Me.cmbAuth.Location = New System.Drawing.Point(335, 128)
        Me.cmbAuth.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbAuth.Name = "cmbAuth"
        Me.cmbAuth.Size = New System.Drawing.Size(223, 32)
        Me.cmbAuth.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(160, 135)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(150, 25)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "Authentication"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label1.Location = New System.Drawing.Point(332, 23)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 30)
        Me.Label1.TabIndex = 91
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label2.Location = New System.Drawing.Point(332, 59)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 30)
        Me.Label2.TabIndex = 92
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label4.Location = New System.Drawing.Point(331, 128)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 30)
        Me.Label4.TabIndex = 93
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.HR_project.My.Resources.Resources.key
        Me.PictureBox2.Location = New System.Drawing.Point(8, 41)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(149, 139)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 94
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Image = Global.HR_project.My.Resources.Resources.judul
        Me.PictureBox1.Location = New System.Drawing.Point(5, 31)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(489, 129)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 104
        Me.PictureBox1.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.HR_project.My.Resources.Resources.bg_isk
        Me.PictureBox3.Location = New System.Drawing.Point(0, 1)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(713, 428)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 105
        Me.PictureBox3.TabStop = False
        '
        'FormLogIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(716, 431)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FormLogIn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Checkpass As System.Windows.Forms.CheckBox
    Friend WithEvents Button_cancel As System.Windows.Forms.Button
    Friend WithEvents Labelpass As System.Windows.Forms.Label
    Friend WithEvents txtpassword As System.Windows.Forms.TextBox
    Friend WithEvents txtuserid As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Labeluser As System.Windows.Forms.Label
    Friend WithEvents Bsimpan As System.Windows.Forms.Button
    Friend WithEvents cmbAuth As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
End Class
