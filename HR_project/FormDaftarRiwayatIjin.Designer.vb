<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDaftarRiwayatIjin
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
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabijin = New System.Windows.Forms.TabPage()
        Me.Button_cetakijin = New System.Windows.Forms.Button()
        Me.grid_ijin = New System.Windows.Forms.DataGridView()
        Me.tabimp = New System.Windows.Forms.TabPage()
        Me.Button_cetakimp = New System.Windows.Forms.Button()
        Me.grid_imp = New System.Windows.Forms.DataGridView()
        Me.Tabtelat = New System.Windows.Forms.TabPage()
        Me.Button_cetaktlt = New System.Windows.Forms.Button()
        Me.grid_telat = New System.Windows.Forms.DataGridView()
        Me.Text_dept = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Text_jabatan = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Text_nama = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Text_nik = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button_go = New System.Windows.Forms.Button()
        Me.DT_akhir = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DT_awal = New System.Windows.Forms.DateTimePicker()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.grid_cari = New System.Windows.Forms.DataGridView()
        Me.Buttonkeluar = New System.Windows.Forms.Button()
        Me.Button_baru = New System.Windows.Forms.Button()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tabijin.SuspendLayout()
        CType(Me.grid_ijin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabimp.SuspendLayout()
        CType(Me.grid_imp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tabtelat.SuspendLayout()
        CType(Me.grid_telat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid_cari, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label14.Location = New System.Drawing.Point(12, 21)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(13, 50)
        Me.Label14.TabIndex = 325
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(25, 21)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(745, 52)
        Me.Label4.TabIndex = 324
        Me.Label4.Text = "FORM DAFTAR RIWAYAT KARYAWAN"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox2.Location = New System.Drawing.Point(3, 748)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1823, 166)
        Me.PictureBox2.TabIndex = 323
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox1.Location = New System.Drawing.Point(3, 9)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1823, 80)
        Me.PictureBox1.TabIndex = 322
        Me.PictureBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabijin)
        Me.TabControl1.Controls.Add(Me.tabimp)
        Me.TabControl1.Controls.Add(Me.Tabtelat)
        Me.TabControl1.Location = New System.Drawing.Point(35, 258)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1525, 482)
        Me.TabControl1.TabIndex = 326
        '
        'tabijin
        '
        Me.tabijin.Controls.Add(Me.Button_cetakijin)
        Me.tabijin.Controls.Add(Me.grid_ijin)
        Me.tabijin.Location = New System.Drawing.Point(4, 25)
        Me.tabijin.Margin = New System.Windows.Forms.Padding(4)
        Me.tabijin.Name = "tabijin"
        Me.tabijin.Padding = New System.Windows.Forms.Padding(4)
        Me.tabijin.Size = New System.Drawing.Size(1517, 453)
        Me.tabijin.TabIndex = 0
        Me.tabijin.Text = "DATA IJIN TIDAK MASUK KERJA"
        Me.tabijin.UseVisualStyleBackColor = True
        '
        'Button_cetakijin
        '
        Me.Button_cetakijin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_cetakijin.FlatAppearance.BorderSize = 0
        Me.Button_cetakijin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_cetakijin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_cetakijin.Image = Global.HR_project.My.Resources.Resources.cetak
        Me.Button_cetakijin.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_cetakijin.Location = New System.Drawing.Point(1393, 354)
        Me.Button_cetakijin.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_cetakijin.Name = "Button_cetakijin"
        Me.Button_cetakijin.Size = New System.Drawing.Size(91, 70)
        Me.Button_cetakijin.TabIndex = 357
        Me.Button_cetakijin.Text = "cetak"
        Me.Button_cetakijin.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_cetakijin.UseVisualStyleBackColor = True
        '
        'grid_ijin
        '
        Me.grid_ijin.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grid_ijin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grid_ijin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_ijin.Location = New System.Drawing.Point(8, 44)
        Me.grid_ijin.Margin = New System.Windows.Forms.Padding(4)
        Me.grid_ijin.Name = "grid_ijin"
        Me.grid_ijin.Size = New System.Drawing.Size(1353, 374)
        Me.grid_ijin.TabIndex = 0
        '
        'tabimp
        '
        Me.tabimp.Controls.Add(Me.Button_cetakimp)
        Me.tabimp.Controls.Add(Me.grid_imp)
        Me.tabimp.Location = New System.Drawing.Point(4, 25)
        Me.tabimp.Margin = New System.Windows.Forms.Padding(4)
        Me.tabimp.Name = "tabimp"
        Me.tabimp.Padding = New System.Windows.Forms.Padding(4)
        Me.tabimp.Size = New System.Drawing.Size(1517, 453)
        Me.tabimp.TabIndex = 1
        Me.tabimp.Text = "DATA IJIN MENINGGALKAN PEKERJAAN"
        Me.tabimp.UseVisualStyleBackColor = True
        '
        'Button_cetakimp
        '
        Me.Button_cetakimp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_cetakimp.FlatAppearance.BorderSize = 0
        Me.Button_cetakimp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_cetakimp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_cetakimp.Image = Global.HR_project.My.Resources.Resources.cetak
        Me.Button_cetakimp.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_cetakimp.Location = New System.Drawing.Point(1396, 354)
        Me.Button_cetakimp.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_cetakimp.Name = "Button_cetakimp"
        Me.Button_cetakimp.Size = New System.Drawing.Size(91, 70)
        Me.Button_cetakimp.TabIndex = 357
        Me.Button_cetakimp.Text = "cetak"
        Me.Button_cetakimp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_cetakimp.UseVisualStyleBackColor = True
        '
        'grid_imp
        '
        Me.grid_imp.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grid_imp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grid_imp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_imp.Location = New System.Drawing.Point(8, 50)
        Me.grid_imp.Margin = New System.Windows.Forms.Padding(4)
        Me.grid_imp.Name = "grid_imp"
        Me.grid_imp.Size = New System.Drawing.Size(1353, 374)
        Me.grid_imp.TabIndex = 1
        '
        'Tabtelat
        '
        Me.Tabtelat.Controls.Add(Me.Button_cetaktlt)
        Me.Tabtelat.Controls.Add(Me.grid_telat)
        Me.Tabtelat.Location = New System.Drawing.Point(4, 25)
        Me.Tabtelat.Margin = New System.Windows.Forms.Padding(4)
        Me.Tabtelat.Name = "Tabtelat"
        Me.Tabtelat.Size = New System.Drawing.Size(1517, 453)
        Me.Tabtelat.TabIndex = 2
        Me.Tabtelat.Text = "DATA KETERLAMBATAN"
        Me.Tabtelat.UseVisualStyleBackColor = True
        '
        'Button_cetaktlt
        '
        Me.Button_cetaktlt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button_cetaktlt.FlatAppearance.BorderSize = 0
        Me.Button_cetaktlt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_cetaktlt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_cetaktlt.Image = Global.HR_project.My.Resources.Resources.cetak
        Me.Button_cetaktlt.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_cetaktlt.Location = New System.Drawing.Point(1396, 354)
        Me.Button_cetaktlt.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_cetaktlt.Name = "Button_cetaktlt"
        Me.Button_cetaktlt.Size = New System.Drawing.Size(91, 70)
        Me.Button_cetaktlt.TabIndex = 356
        Me.Button_cetaktlt.Text = "cetak"
        Me.Button_cetaktlt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_cetaktlt.UseVisualStyleBackColor = True
        '
        'grid_telat
        '
        Me.grid_telat.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grid_telat.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grid_telat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_telat.Location = New System.Drawing.Point(8, 50)
        Me.grid_telat.Margin = New System.Windows.Forms.Padding(4)
        Me.grid_telat.Name = "grid_telat"
        Me.grid_telat.Size = New System.Drawing.Size(1353, 374)
        Me.grid_telat.TabIndex = 2
        '
        'Text_dept
        '
        Me.Text_dept.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_dept.Location = New System.Drawing.Point(161, 206)
        Me.Text_dept.Margin = New System.Windows.Forms.Padding(4)
        Me.Text_dept.Name = "Text_dept"
        Me.Text_dept.Size = New System.Drawing.Size(452, 26)
        Me.Text_dept.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(36, 217)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 18)
        Me.Label3.TabIndex = 333
        Me.Label3.Text = "Departemen"
        '
        'Text_jabatan
        '
        Me.Text_jabatan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_jabatan.Location = New System.Drawing.Point(161, 172)
        Me.Text_jabatan.Margin = New System.Windows.Forms.Padding(4)
        Me.Text_jabatan.Name = "Text_jabatan"
        Me.Text_jabatan.Size = New System.Drawing.Size(452, 26)
        Me.Text_jabatan.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(36, 178)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 18)
        Me.Label2.TabIndex = 331
        Me.Label2.Text = "Jabatan"
        '
        'Text_nama
        '
        Me.Text_nama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_nama.Location = New System.Drawing.Point(161, 139)
        Me.Text_nama.Margin = New System.Windows.Forms.Padding(4)
        Me.Text_nama.Name = "Text_nama"
        Me.Text_nama.Size = New System.Drawing.Size(340, 26)
        Me.Text_nama.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 144)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 18)
        Me.Label1.TabIndex = 329
        Me.Label1.Text = "Nama"
        '
        'Text_nik
        '
        Me.Text_nik.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_nik.Location = New System.Drawing.Point(161, 108)
        Me.Text_nik.Margin = New System.Windows.Forms.Padding(4)
        Me.Text_nik.Name = "Text_nik"
        Me.Text_nik.Size = New System.Drawing.Size(340, 26)
        Me.Text_nik.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(36, 112)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 18)
        Me.Label9.TabIndex = 327
        Me.Label9.Text = "NIK"
        '
        'Button_go
        '
        Me.Button_go.Location = New System.Drawing.Point(1011, 208)
        Me.Button_go.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_go.Name = "Button_go"
        Me.Button_go.Size = New System.Drawing.Size(48, 27)
        Me.Button_go.TabIndex = 6
        Me.Button_go.Text = "Go !"
        Me.Button_go.UseVisualStyleBackColor = True
        '
        'DT_akhir
        '
        Me.DT_akhir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_akhir.Location = New System.Drawing.Point(785, 208)
        Me.DT_akhir.Margin = New System.Windows.Forms.Padding(4)
        Me.DT_akhir.Name = "DT_akhir"
        Me.DT_akhir.Size = New System.Drawing.Size(201, 24)
        Me.DT_akhir.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(731, 212)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(26, 18)
        Me.Label16.TabIndex = 337
        Me.Label16.Text = "Ke"
        '
        'DT_awal
        '
        Me.DT_awal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_awal.Location = New System.Drawing.Point(785, 172)
        Me.DT_awal.Margin = New System.Windows.Forms.Padding(4)
        Me.DT_awal.Name = "DT_awal"
        Me.DT_awal.Size = New System.Drawing.Size(201, 24)
        Me.DT_awal.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(731, 180)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(35, 18)
        Me.Label17.TabIndex = 335
        Me.Label17.Text = "Dari"
        '
        'grid_cari
        '
        Me.grid_cari.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grid_cari.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grid_cari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_cari.Location = New System.Drawing.Point(161, 137)
        Me.grid_cari.Margin = New System.Windows.Forms.Padding(4)
        Me.grid_cari.Name = "grid_cari"
        Me.grid_cari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_cari.Size = New System.Drawing.Size(933, 114)
        Me.grid_cari.TabIndex = 340
        Me.grid_cari.Visible = False
        '
        'Buttonkeluar
        '
        Me.Buttonkeluar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Buttonkeluar.FlatAppearance.BorderSize = 0
        Me.Buttonkeluar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buttonkeluar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Buttonkeluar.Image = Global.HR_project.My.Resources.Resources.logout
        Me.Buttonkeluar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Buttonkeluar.Location = New System.Drawing.Point(1660, 640)
        Me.Buttonkeluar.Margin = New System.Windows.Forms.Padding(4)
        Me.Buttonkeluar.Name = "Buttonkeluar"
        Me.Buttonkeluar.Size = New System.Drawing.Size(91, 70)
        Me.Buttonkeluar.TabIndex = 353
        Me.Buttonkeluar.Text = "keluar"
        Me.Buttonkeluar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Buttonkeluar.UseVisualStyleBackColor = True
        '
        'Button_baru
        '
        Me.Button_baru.FlatAppearance.BorderSize = 0
        Me.Button_baru.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_baru.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_baru.Image = Global.HR_project.My.Resources.Resources._new
        Me.Button_baru.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_baru.Location = New System.Drawing.Point(1568, 640)
        Me.Button_baru.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_baru.Name = "Button_baru"
        Me.Button_baru.Size = New System.Drawing.Size(91, 70)
        Me.Button_baru.TabIndex = 354
        Me.Button_baru.Text = "baru"
        Me.Button_baru.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_baru.UseVisualStyleBackColor = True
        '
        'FormDaftarRiwayatIjin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1827, 923)
        Me.Controls.Add(Me.Button_baru)
        Me.Controls.Add(Me.Button_go)
        Me.Controls.Add(Me.Buttonkeluar)
        Me.Controls.Add(Me.DT_akhir)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.DT_awal)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Text_dept)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Text_jabatan)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Text_nama)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Text_nik)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.grid_cari)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormDaftarRiwayatIjin"
        Me.Text = "FormDaftarRiwayatIjin"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tabijin.ResumeLayout(False)
        CType(Me.grid_ijin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabimp.ResumeLayout(False)
        CType(Me.grid_imp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tabtelat.ResumeLayout(False)
        CType(Me.grid_telat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid_cari, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabijin As System.Windows.Forms.TabPage
    Friend WithEvents tabimp As System.Windows.Forms.TabPage
    Friend WithEvents Text_dept As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Text_jabatan As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Text_nama As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Text_nik As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button_go As System.Windows.Forms.Button
    Friend WithEvents DT_akhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DT_awal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents grid_ijin As System.Windows.Forms.DataGridView
    Friend WithEvents Tabtelat As System.Windows.Forms.TabPage
    Friend WithEvents grid_imp As System.Windows.Forms.DataGridView
    Friend WithEvents grid_telat As System.Windows.Forms.DataGridView
    Friend WithEvents grid_cari As System.Windows.Forms.DataGridView
    Friend WithEvents Buttonkeluar As System.Windows.Forms.Button
    Friend WithEvents Button_cetaktlt As System.Windows.Forms.Button
    Friend WithEvents Button_cetakijin As System.Windows.Forms.Button
    Friend WithEvents Button_cetakimp As System.Windows.Forms.Button
    Friend WithEvents Button_baru As System.Windows.Forms.Button
End Class
