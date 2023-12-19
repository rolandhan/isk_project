<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDTJabatan
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DT_tglawal = New System.Windows.Forms.DateTimePicker()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Groupnik = New System.Windows.Forms.GroupBox()
        Me.Combo_atasan = New System.Windows.Forms.ComboBox()
        Me.Combo_departemen = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Combo_status = New System.Windows.Forms.ComboBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Text_nama = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Text_nik = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Groupjabatan = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DT_tglakhir = New System.Windows.Forms.DateTimePicker()
        Me.combo_jbt = New System.Windows.Forms.ComboBox()
        Me.grid_karyawan = New System.Windows.Forms.DataGridView()
        Me.Button_simpan = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LihatDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Combo_depart = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button_baru = New System.Windows.Forms.Button()
        Me.Text_pencarian = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DT_masukrec = New System.Windows.Forms.DateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Groupmasuk = New System.Windows.Forms.GroupBox()
        Me.DT_kontrak = New System.Windows.Forms.DateTimePicker()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.DT_tetap = New System.Windows.Forms.DateTimePicker()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.DT_Keluar = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Groupnik.SuspendLayout()
        Me.Groupjabatan.SuspendLayout()
        CType(Me.grid_karyawan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Groupmasuk.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DT_tglawal
        '
        Me.DT_tglawal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_tglawal.Location = New System.Drawing.Point(153, 80)
        Me.DT_tglawal.Margin = New System.Windows.Forms.Padding(4)
        Me.DT_tglawal.Name = "DT_tglawal"
        Me.DT_tglawal.Size = New System.Drawing.Size(232, 24)
        Me.DT_tglawal.TabIndex = 7
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(15, 16)
        Me.Label38.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(60, 18)
        Me.Label38.TabIndex = 189
        Me.Label38.Text = "Jabatan"
        '
        'Groupnik
        '
        Me.Groupnik.BackColor = System.Drawing.Color.White
        Me.Groupnik.Controls.Add(Me.Combo_atasan)
        Me.Groupnik.Controls.Add(Me.Combo_departemen)
        Me.Groupnik.Controls.Add(Me.Label2)
        Me.Groupnik.Controls.Add(Me.Label37)
        Me.Groupnik.Controls.Add(Me.Combo_status)
        Me.Groupnik.Controls.Add(Me.Label39)
        Me.Groupnik.Controls.Add(Me.Text_nama)
        Me.Groupnik.Controls.Add(Me.Label10)
        Me.Groupnik.Controls.Add(Me.Text_nik)
        Me.Groupnik.Controls.Add(Me.Label9)
        Me.Groupnik.Location = New System.Drawing.Point(37, 94)
        Me.Groupnik.Margin = New System.Windows.Forms.Padding(4)
        Me.Groupnik.Name = "Groupnik"
        Me.Groupnik.Padding = New System.Windows.Forms.Padding(4)
        Me.Groupnik.Size = New System.Drawing.Size(801, 213)
        Me.Groupnik.TabIndex = 214
        Me.Groupnik.TabStop = False
        '
        'Combo_atasan
        '
        Me.Combo_atasan.FormattingEnabled = True
        Me.Combo_atasan.Location = New System.Drawing.Point(159, 112)
        Me.Combo_atasan.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_atasan.Name = "Combo_atasan"
        Me.Combo_atasan.Size = New System.Drawing.Size(571, 24)
        Me.Combo_atasan.TabIndex = 4
        '
        'Combo_departemen
        '
        Me.Combo_departemen.FormattingEnabled = True
        Me.Combo_departemen.Location = New System.Drawing.Point(157, 81)
        Me.Combo_departemen.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_departemen.Name = "Combo_departemen"
        Me.Combo_departemen.Size = New System.Drawing.Size(277, 24)
        Me.Combo_departemen.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 116)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 18)
        Me.Label2.TabIndex = 209
        Me.Label2.Text = "Atasan"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(13, 87)
        Me.Label37.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(89, 18)
        Me.Label37.TabIndex = 200
        Me.Label37.Text = "Departemen"
        '
        'Combo_status
        '
        Me.Combo_status.FormattingEnabled = True
        Me.Combo_status.Location = New System.Drawing.Point(157, 143)
        Me.Combo_status.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_status.Name = "Combo_status"
        Me.Combo_status.Size = New System.Drawing.Size(276, 24)
        Me.Combo_status.TabIndex = 5
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(13, 148)
        Me.Label39.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(119, 18)
        Me.Label39.TabIndex = 201
        Me.Label39.Text = "Status Karyawan"
        '
        'Text_nama
        '
        Me.Text_nama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_nama.Location = New System.Drawing.Point(157, 49)
        Me.Text_nama.Margin = New System.Windows.Forms.Padding(4)
        Me.Text_nama.Name = "Text_nama"
        Me.Text_nama.Size = New System.Drawing.Size(571, 26)
        Me.Text_nama.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(13, 54)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 18)
        Me.Label10.TabIndex = 206
        Me.Label10.Text = "Nama"
        '
        'Text_nik
        '
        Me.Text_nik.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_nik.Location = New System.Drawing.Point(157, 17)
        Me.Text_nik.Margin = New System.Windows.Forms.Padding(4)
        Me.Text_nik.Name = "Text_nik"
        Me.Text_nik.Size = New System.Drawing.Size(340, 26)
        Me.Text_nik.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(13, 21)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 18)
        Me.Label9.TabIndex = 204
        Me.Label9.Text = "NIK"
        '
        'Groupjabatan
        '
        Me.Groupjabatan.Controls.Add(Me.Label11)
        Me.Groupjabatan.Controls.Add(Me.Label8)
        Me.Groupjabatan.Controls.Add(Me.DT_tglakhir)
        Me.Groupjabatan.Controls.Add(Me.DT_tglawal)
        Me.Groupjabatan.Controls.Add(Me.combo_jbt)
        Me.Groupjabatan.Controls.Add(Me.Label38)
        Me.Groupjabatan.Location = New System.Drawing.Point(436, 356)
        Me.Groupjabatan.Margin = New System.Windows.Forms.Padding(4)
        Me.Groupjabatan.Name = "Groupjabatan"
        Me.Groupjabatan.Padding = New System.Windows.Forms.Padding(4)
        Me.Groupjabatan.Size = New System.Drawing.Size(395, 157)
        Me.Groupjabatan.TabIndex = 218
        Me.Groupjabatan.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(16, 119)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 18)
        Me.Label11.TabIndex = 218
        Me.Label11.Text = "Periode Akhir"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 85)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(94, 18)
        Me.Label8.TabIndex = 217
        Me.Label8.Text = "Periode Awal"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DT_tglakhir
        '
        Me.DT_tglakhir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_tglakhir.Location = New System.Drawing.Point(153, 118)
        Me.DT_tglakhir.Margin = New System.Windows.Forms.Padding(4)
        Me.DT_tglakhir.Name = "DT_tglakhir"
        Me.DT_tglakhir.Size = New System.Drawing.Size(232, 24)
        Me.DT_tglakhir.TabIndex = 8
        '
        'combo_jbt
        '
        Me.combo_jbt.FormattingEnabled = True
        Me.combo_jbt.Location = New System.Drawing.Point(20, 42)
        Me.combo_jbt.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_jbt.Name = "combo_jbt"
        Me.combo_jbt.Size = New System.Drawing.Size(365, 24)
        Me.combo_jbt.TabIndex = 6
        '
        'grid_karyawan
        '
        Me.grid_karyawan.BackgroundColor = System.Drawing.SystemColors.Control
        Me.grid_karyawan.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid_karyawan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grid_karyawan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_karyawan.Location = New System.Drawing.Point(863, 175)
        Me.grid_karyawan.Margin = New System.Windows.Forms.Padding(4)
        Me.grid_karyawan.Name = "grid_karyawan"
        Me.grid_karyawan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_karyawan.Size = New System.Drawing.Size(900, 555)
        Me.grid_karyawan.TabIndex = 219
        '
        'Button_simpan
        '
        Me.Button_simpan.FlatAppearance.BorderSize = 0
        Me.Button_simpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_simpan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_simpan.Image = Global.HR_project.My.Resources.Resources.save
        Me.Button_simpan.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_simpan.Location = New System.Drawing.Point(137, 738)
        Me.Button_simpan.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_simpan.Name = "Button_simpan"
        Me.Button_simpan.Size = New System.Drawing.Size(91, 70)
        Me.Button_simpan.TabIndex = 222
        Me.Button_simpan.Text = "simpan"
        Me.Button_simpan.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_simpan.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LihatDetailToolStripMenuItem, Me.UpdateDataToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(160, 52)
        '
        'LihatDetailToolStripMenuItem
        '
        Me.LihatDetailToolStripMenuItem.Name = "LihatDetailToolStripMenuItem"
        Me.LihatDetailToolStripMenuItem.Size = New System.Drawing.Size(159, 24)
        Me.LihatDetailToolStripMenuItem.Text = "lihat detail"
        '
        'UpdateDataToolStripMenuItem
        '
        Me.UpdateDataToolStripMenuItem.Name = "UpdateDataToolStripMenuItem"
        Me.UpdateDataToolStripMenuItem.Size = New System.Drawing.Size(159, 24)
        Me.UpdateDataToolStripMenuItem.Text = "update data"
        '
        'Combo_depart
        '
        Me.Combo_depart.FormattingEnabled = True
        Me.Combo_depart.Location = New System.Drawing.Point(968, 105)
        Me.Combo_depart.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_depart.Name = "Combo_depart"
        Me.Combo_depart.Size = New System.Drawing.Size(303, 24)
        Me.Combo_depart.TabIndex = 223
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(859, 108)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 18)
        Me.Label3.TabIndex = 224
        Me.Label3.Text = "Departemen"
        '
        'Button_baru
        '
        Me.Button_baru.FlatAppearance.BorderSize = 0
        Me.Button_baru.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_baru.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_baru.Image = Global.HR_project.My.Resources.Resources._new
        Me.Button_baru.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_baru.Location = New System.Drawing.Point(37, 738)
        Me.Button_baru.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_baru.Name = "Button_baru"
        Me.Button_baru.Size = New System.Drawing.Size(91, 70)
        Me.Button_baru.TabIndex = 225
        Me.Button_baru.Text = "baru"
        Me.Button_baru.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_baru.UseVisualStyleBackColor = True
        '
        'Text_pencarian
        '
        Me.Text_pencarian.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_pencarian.Location = New System.Drawing.Point(863, 139)
        Me.Text_pencarian.Margin = New System.Windows.Forms.Padding(4)
        Me.Text_pencarian.Name = "Text_pencarian"
        Me.Text_pencarian.Size = New System.Drawing.Size(899, 26)
        Me.Text_pencarian.TabIndex = 220
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label14.Location = New System.Drawing.Point(12, 20)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(13, 50)
        Me.Label14.TabIndex = 332
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label4.Location = New System.Drawing.Point(25, 20)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(451, 52)
        Me.Label4.TabIndex = 331
        Me.Label4.Text = "FORM DATA JABATAN"
        '
        'DT_masukrec
        '
        Me.DT_masukrec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_masukrec.Location = New System.Drawing.Point(160, 33)
        Me.DT_masukrec.Margin = New System.Windows.Forms.Padding(4)
        Me.DT_masukrec.Name = "DT_masukrec"
        Me.DT_masukrec.Size = New System.Drawing.Size(201, 24)
        Me.DT_masukrec.TabIndex = 9
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(20, 37)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 18)
        Me.Label15.TabIndex = 204
        Me.Label15.Text = "Recruitmen"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Groupmasuk
        '
        Me.Groupmasuk.Controls.Add(Me.DT_kontrak)
        Me.Groupmasuk.Controls.Add(Me.Label25)
        Me.Groupmasuk.Controls.Add(Me.DT_tetap)
        Me.Groupmasuk.Controls.Add(Me.Label26)
        Me.Groupmasuk.Controls.Add(Me.Label36)
        Me.Groupmasuk.Controls.Add(Me.DT_Keluar)
        Me.Groupmasuk.Controls.Add(Me.Label15)
        Me.Groupmasuk.Controls.Add(Me.DT_masukrec)
        Me.Groupmasuk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Groupmasuk.Location = New System.Drawing.Point(35, 354)
        Me.Groupmasuk.Margin = New System.Windows.Forms.Padding(4)
        Me.Groupmasuk.Name = "Groupmasuk"
        Me.Groupmasuk.Padding = New System.Windows.Forms.Padding(4)
        Me.Groupmasuk.Size = New System.Drawing.Size(393, 186)
        Me.Groupmasuk.TabIndex = 216
        Me.Groupmasuk.TabStop = False
        Me.Groupmasuk.Text = "Tanggal Masuk"
        '
        'DT_kontrak
        '
        Me.DT_kontrak.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_kontrak.Location = New System.Drawing.Point(160, 68)
        Me.DT_kontrak.Margin = New System.Windows.Forms.Padding(4)
        Me.DT_kontrak.Name = "DT_kontrak"
        Me.DT_kontrak.Size = New System.Drawing.Size(201, 24)
        Me.DT_kontrak.TabIndex = 10
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(20, 71)
        Me.Label25.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(116, 18)
        Me.Label25.TabIndex = 216
        Me.Label25.Text = "Tanggal Kontrak"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DT_tetap
        '
        Me.DT_tetap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_tetap.Location = New System.Drawing.Point(160, 103)
        Me.DT_tetap.Margin = New System.Windows.Forms.Padding(4)
        Me.DT_tetap.Name = "DT_tetap"
        Me.DT_tetap.Size = New System.Drawing.Size(201, 24)
        Me.DT_tetap.TabIndex = 11
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(20, 103)
        Me.Label26.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(101, 18)
        Me.Label26.TabIndex = 217
        Me.Label26.Text = "Tanggal Tetap"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(20, 140)
        Me.Label36.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(106, 18)
        Me.Label36.TabIndex = 220
        Me.Label36.Text = "Tanggal Keluar"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DT_Keluar
        '
        Me.DT_Keluar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DT_Keluar.Location = New System.Drawing.Point(160, 136)
        Me.DT_Keluar.Margin = New System.Windows.Forms.Padding(4)
        Me.DT_Keluar.Name = "DT_Keluar"
        Me.DT_Keluar.Size = New System.Drawing.Size(201, 24)
        Me.DT_Keluar.TabIndex = 12
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(35, 315)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(803, 32)
        Me.GroupBox1.TabIndex = 335
        Me.GroupBox1.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Image = Global.HR_project.My.Resources.Resources.find_2
        Me.PictureBox1.Location = New System.Drawing.Point(1733, 139)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(27, 25)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 221
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox2.Location = New System.Drawing.Point(3, 750)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1823, 166)
        Me.PictureBox2.TabIndex = 333
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox3.Location = New System.Drawing.Point(3, 7)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(1823, 80)
        Me.PictureBox3.TabIndex = 330
        Me.PictureBox3.TabStop = False
        '
        'FormDTJabatan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1827, 923)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button_baru)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Combo_depart)
        Me.Controls.Add(Me.Button_simpan)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Text_pencarian)
        Me.Controls.Add(Me.grid_karyawan)
        Me.Controls.Add(Me.Groupnik)
        Me.Controls.Add(Me.Groupjabatan)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Groupmasuk)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormDTJabatan"
        Me.Text = "FORM DATA JABATAN"
        Me.Groupnik.ResumeLayout(False)
        Me.Groupnik.PerformLayout()
        Me.Groupjabatan.ResumeLayout(False)
        Me.Groupjabatan.PerformLayout()
        CType(Me.grid_karyawan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Groupmasuk.ResumeLayout(False)
        Me.Groupmasuk.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Groupnik As System.Windows.Forms.GroupBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Combo_status As System.Windows.Forms.ComboBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Text_nama As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Text_nik As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Groupjabatan As System.Windows.Forms.GroupBox
    Friend WithEvents grid_karyawan As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button_simpan As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LihatDetailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DT_tglawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Combo_depart As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button_baru As System.Windows.Forms.Button
    Friend WithEvents combo_jbt As System.Windows.Forms.ComboBox
    Friend WithEvents Text_pencarian As System.Windows.Forms.TextBox
    Friend WithEvents Combo_departemen As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents DT_masukrec As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Groupmasuk As System.Windows.Forms.GroupBox
    Friend WithEvents DT_kontrak As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents DT_tetap As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents DT_Keluar As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DT_tglakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Combo_atasan As System.Windows.Forms.ComboBox
End Class
