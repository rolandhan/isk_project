<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLogDB
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
        Me.txtdatabase = New System.Windows.Forms.TextBox()
        Me.txtserver = New System.Windows.Forms.TextBox()
        Me.cmbAuthentication = New System.Windows.Forms.ComboBox()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.txtuserid = New System.Windows.Forms.TextBox()
        Me.Labelpass = New System.Windows.Forms.Label()
        Me.Labeluser = New System.Windows.Forms.Label()
        Me.Buttoncancel = New System.Windows.Forms.Button()
        Me.Bsimpan = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtdatabase
        '
        Me.txtdatabase.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdatabase.Location = New System.Drawing.Point(152, 102)
        Me.txtdatabase.Name = "txtdatabase"
        Me.txtdatabase.Size = New System.Drawing.Size(184, 24)
        Me.txtdatabase.TabIndex = 138
        '
        'txtserver
        '
        Me.txtserver.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtserver.Location = New System.Drawing.Point(152, 72)
        Me.txtserver.Name = "txtserver"
        Me.txtserver.Size = New System.Drawing.Size(184, 24)
        Me.txtserver.TabIndex = 137
        '
        'cmbAuthentication
        '
        Me.cmbAuthentication.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAuthentication.FormattingEnabled = True
        Me.cmbAuthentication.Location = New System.Drawing.Point(152, 132)
        Me.cmbAuthentication.Name = "cmbAuthentication"
        Me.cmbAuthentication.Size = New System.Drawing.Size(184, 26)
        Me.cmbAuthentication.TabIndex = 139
        '
        'txtpassword
        '
        Me.txtpassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpassword.Location = New System.Drawing.Point(153, 200)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassword.Size = New System.Drawing.Size(183, 24)
        Me.txtpassword.TabIndex = 144
        '
        'txtuserid
        '
        Me.txtuserid.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtuserid.Location = New System.Drawing.Point(153, 171)
        Me.txtuserid.Name = "txtuserid"
        Me.txtuserid.Size = New System.Drawing.Size(183, 24)
        Me.txtuserid.TabIndex = 143
        '
        'Labelpass
        '
        Me.Labelpass.AutoSize = True
        Me.Labelpass.BackColor = System.Drawing.Color.White
        Me.Labelpass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labelpass.ForeColor = System.Drawing.Color.DarkBlue
        Me.Labelpass.Location = New System.Drawing.Point(16, 204)
        Me.Labelpass.Name = "Labelpass"
        Me.Labelpass.Size = New System.Drawing.Size(86, 20)
        Me.Labelpass.TabIndex = 145
        Me.Labelpass.Text = "Password"
        '
        'Labeluser
        '
        Me.Labeluser.AutoSize = True
        Me.Labeluser.BackColor = System.Drawing.Color.White
        Me.Labeluser.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Labeluser.ForeColor = System.Drawing.Color.DarkBlue
        Me.Labeluser.Location = New System.Drawing.Point(16, 175)
        Me.Labeluser.Name = "Labeluser"
        Me.Labeluser.Size = New System.Drawing.Size(47, 20)
        Me.Labeluser.TabIndex = 142
        Me.Labeluser.Text = "User"
        '
        'Buttoncancel
        '
        Me.Buttoncancel.Location = New System.Drawing.Point(254, 251)
        Me.Buttoncancel.Name = "Buttoncancel"
        Me.Buttoncancel.Size = New System.Drawing.Size(82, 29)
        Me.Buttoncancel.TabIndex = 141
        Me.Buttoncancel.Text = "Cancel"
        Me.Buttoncancel.UseVisualStyleBackColor = True
        '
        'Bsimpan
        '
        Me.Bsimpan.Location = New System.Drawing.Point(163, 252)
        Me.Bsimpan.Name = "Bsimpan"
        Me.Bsimpan.Size = New System.Drawing.Size(81, 29)
        Me.Bsimpan.TabIndex = 140
        Me.Bsimpan.Text = "Log in"
        Me.Bsimpan.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(16, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 20)
        Me.Label3.TabIndex = 136
        Me.Label3.Text = "Authentication"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(16, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 20)
        Me.Label2.TabIndex = 135
        Me.Label2.Text = "Database"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(16, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 20)
        Me.Label1.TabIndex = 134
        Me.Label1.Text = "Server"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CheckBox1.Location = New System.Drawing.Point(153, 230)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(71, 17)
        Me.CheckBox1.TabIndex = 146
        Me.CheckBox1.Text = "tampilkan"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.HR_project.My.Resources.Resources.bg_isk
        Me.PictureBox1.Location = New System.Drawing.Point(1, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(495, 302)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 147
        Me.PictureBox1.TabStop = False
        '
        'FormLogDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 305)
        Me.ControlBox = False
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.txtdatabase)
        Me.Controls.Add(Me.txtserver)
        Me.Controls.Add(Me.cmbAuthentication)
        Me.Controls.Add(Me.txtpassword)
        Me.Controls.Add(Me.txtuserid)
        Me.Controls.Add(Me.Labelpass)
        Me.Controls.Add(Me.Labeluser)
        Me.Controls.Add(Me.Buttoncancel)
        Me.Controls.Add(Me.Bsimpan)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormLogDB"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtdatabase As System.Windows.Forms.TextBox
    Friend WithEvents txtserver As System.Windows.Forms.TextBox
    Friend WithEvents cmbAuthentication As System.Windows.Forms.ComboBox
    Friend WithEvents txtpassword As System.Windows.Forms.TextBox
    Friend WithEvents txtuserid As System.Windows.Forms.TextBox
    Friend WithEvents Labelpass As System.Windows.Forms.Label
    Friend WithEvents Labeluser As System.Windows.Forms.Label
    Friend WithEvents Buttoncancel As System.Windows.Forms.Button
    Friend WithEvents Bsimpan As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
