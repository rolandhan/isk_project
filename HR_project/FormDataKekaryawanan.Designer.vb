<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDataKekaryawanan
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Combo_kary = New System.Windows.Forms.ComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabDTKaryawan = New System.Windows.Forms.TabPage()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Text_cari = New System.Windows.Forms.TextBox()
        Me.Group_periode = New System.Windows.Forms.GroupBox()
        Me.DT_akhir = New System.Windows.Forms.DateTimePicker()
        Me.DTawal = New System.Windows.Forms.DateTimePicker()
        Me.B_go = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grid_karyawan = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboFilter = New System.Windows.Forms.ComboBox()
        Me.ComboKategori = New System.Windows.Forms.ComboBox()
        Me.Label_filter = New System.Windows.Forms.Label()
        Me.TabDataPersonal = New System.Windows.Forms.TabPage()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Text_cariktp = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Combo_opsiKTP = New System.Windows.Forms.ComboBox()
        Me.combo_filterKTP = New System.Windows.Forms.ComboBox()
        Me.Label_filterKTP = New System.Windows.Forms.Label()
        Me.grid_dtKTP = New System.Windows.Forms.DataGridView()
        Me.TabDataDomisili = New System.Windows.Forms.TabPage()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Text_caridom = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Combo_opsiDom = New System.Windows.Forms.ComboBox()
        Me.Combo_filterDom = New System.Windows.Forms.ComboBox()
        Me.Label_filterdom = New System.Windows.Forms.Label()
        Me.grid_DataDom = New System.Windows.Forms.DataGridView()
        Me.TabIndentitasKel = New System.Windows.Forms.TabPage()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Text_carikel = New System.Windows.Forms.TextBox()
        Me.Combo_filterKel = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Combo_opsiK = New System.Windows.Forms.ComboBox()
        Me.Label_IK = New System.Windows.Forms.Label()
        Me.grid_keluarga = New System.Windows.Forms.DataGridView()
        Me.TabFaskes = New System.Windows.Forms.TabPage()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.Text_carifas = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Combo_opsiFK = New System.Windows.Forms.ComboBox()
        Me.Combo_filerFK = New System.Windows.Forms.ComboBox()
        Me.Label_faskes = New System.Windows.Forms.Label()
        Me.grid_faskes = New System.Windows.Forms.DataGridView()
        Me.Radio_fulljab = New System.Windows.Forms.RadioButton()
        Me.Radio_singlejab = New System.Windows.Forms.RadioButton()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditDataPersonalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripRiwayatKerja = New System.Windows.Forms.ToolStripMenuItem()
        Me.HapusDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.worker1 = New System.ComponentModel.BackgroundWorker()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label_progress = New System.Windows.Forms.Label()
        Me.ButtonExport = New System.Windows.Forms.Button()
        Me.WorkerDtKaryawan = New System.ComponentModel.BackgroundWorker()
        Me.WorkerDtKeluarga = New System.ComponentModel.BackgroundWorker()
        Me.WorkerDtFaskes = New System.ComponentModel.BackgroundWorker()
        Me.WorkerDataKTP = New System.ComponentModel.BackgroundWorker()
        Me.WorkerDtDomisili = New System.ComponentModel.BackgroundWorker()
        Me.TabControl1.SuspendLayout()
        Me.TabDTKaryawan.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Group_periode.SuspendLayout()
        CType(Me.grid_karyawan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabDataPersonal.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid_dtKTP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabDataDomisili.SuspendLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid_DataDom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabIndentitasKel.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid_keluarga, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabFaskes.SuspendLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grid_faskes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1252, 85)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Karyawan"
        '
        'Combo_kary
        '
        Me.Combo_kary.FormattingEnabled = True
        Me.Combo_kary.Location = New System.Drawing.Point(1367, 82)
        Me.Combo_kary.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_kary.Name = "Combo_kary"
        Me.Combo_kary.Size = New System.Drawing.Size(420, 24)
        Me.Combo_kary.TabIndex = 343
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabDTKaryawan)
        Me.TabControl1.Controls.Add(Me.TabDataPersonal)
        Me.TabControl1.Controls.Add(Me.TabDataDomisili)
        Me.TabControl1.Controls.Add(Me.TabIndentitasKel)
        Me.TabControl1.Controls.Add(Me.TabFaskes)
        Me.TabControl1.Location = New System.Drawing.Point(11, 108)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1777, 630)
        Me.TabControl1.TabIndex = 347
        '
        'TabDTKaryawan
        '
        Me.TabDTKaryawan.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TabDTKaryawan.Controls.Add(Me.PictureBox5)
        Me.TabDTKaryawan.Controls.Add(Me.Text_cari)
        Me.TabDTKaryawan.Controls.Add(Me.Group_periode)
        Me.TabDTKaryawan.Controls.Add(Me.grid_karyawan)
        Me.TabDTKaryawan.Controls.Add(Me.Label5)
        Me.TabDTKaryawan.Controls.Add(Me.ComboFilter)
        Me.TabDTKaryawan.Controls.Add(Me.ComboKategori)
        Me.TabDTKaryawan.Controls.Add(Me.Label_filter)
        Me.TabDTKaryawan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabDTKaryawan.Location = New System.Drawing.Point(4, 25)
        Me.TabDTKaryawan.Margin = New System.Windows.Forms.Padding(4)
        Me.TabDTKaryawan.Name = "TabDTKaryawan"
        Me.TabDTKaryawan.Padding = New System.Windows.Forms.Padding(4)
        Me.TabDTKaryawan.Size = New System.Drawing.Size(1769, 601)
        Me.TabDTKaryawan.TabIndex = 0
        Me.TabDTKaryawan.Text = "Data Karyawan"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.HR_project.My.Resources.Resources.find_21
        Me.PictureBox5.Location = New System.Drawing.Point(960, 75)
        Me.PictureBox5.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(27, 25)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 365
        Me.PictureBox5.TabStop = False
        '
        'Text_cari
        '
        Me.Text_cari.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_cari.Location = New System.Drawing.Point(12, 74)
        Me.Text_cari.Margin = New System.Windows.Forms.Padding(4)
        Me.Text_cari.Name = "Text_cari"
        Me.Text_cari.Size = New System.Drawing.Size(976, 26)
        Me.Text_cari.TabIndex = 364
        '
        'Group_periode
        '
        Me.Group_periode.Controls.Add(Me.DT_akhir)
        Me.Group_periode.Controls.Add(Me.DTawal)
        Me.Group_periode.Controls.Add(Me.B_go)
        Me.Group_periode.Controls.Add(Me.Label4)
        Me.Group_periode.Controls.Add(Me.Label3)
        Me.Group_periode.Location = New System.Drawing.Point(16, 6)
        Me.Group_periode.Margin = New System.Windows.Forms.Padding(4)
        Me.Group_periode.Name = "Group_periode"
        Me.Group_periode.Padding = New System.Windows.Forms.Padding(4)
        Me.Group_periode.Size = New System.Drawing.Size(585, 54)
        Me.Group_periode.TabIndex = 347
        Me.Group_periode.TabStop = False
        '
        'DT_akhir
        '
        Me.DT_akhir.Enabled = False
        Me.DT_akhir.Location = New System.Drawing.Point(303, 18)
        Me.DT_akhir.Margin = New System.Windows.Forms.Padding(4)
        Me.DT_akhir.Name = "DT_akhir"
        Me.DT_akhir.Size = New System.Drawing.Size(176, 24)
        Me.DT_akhir.TabIndex = 350
        '
        'DTawal
        '
        Me.DTawal.Enabled = False
        Me.DTawal.Location = New System.Drawing.Point(77, 21)
        Me.DTawal.Margin = New System.Windows.Forms.Padding(4)
        Me.DTawal.Name = "DTawal"
        Me.DTawal.Size = New System.Drawing.Size(176, 24)
        Me.DTawal.TabIndex = 349
        '
        'B_go
        '
        Me.B_go.Enabled = False
        Me.B_go.Location = New System.Drawing.Point(504, 18)
        Me.B_go.Margin = New System.Windows.Forms.Padding(4)
        Me.B_go.Name = "B_go"
        Me.B_go.Size = New System.Drawing.Size(52, 27)
        Me.B_go.TabIndex = 348
        Me.B_go.Text = "Go"
        Me.B_go.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(263, 23)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 20)
        Me.Label4.TabIndex = 347
        Me.Label4.Text = "Ke"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 23)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 20)
        Me.Label3.TabIndex = 345
        Me.Label3.Text = "Dari"
        '
        'grid_karyawan
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid_karyawan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grid_karyawan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_karyawan.Location = New System.Drawing.Point(11, 110)
        Me.grid_karyawan.Margin = New System.Windows.Forms.Padding(4)
        Me.grid_karyawan.Name = "grid_karyawan"
        Me.grid_karyawan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_karyawan.Size = New System.Drawing.Size(1735, 462)
        Me.grid_karyawan.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(627, 31)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 20)
        Me.Label5.TabIndex = 352
        Me.Label5.Text = "Filter"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboFilter
        '
        Me.ComboFilter.FormattingEnabled = True
        Me.ComboFilter.Location = New System.Drawing.Point(1139, 31)
        Me.ComboFilter.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboFilter.Name = "ComboFilter"
        Me.ComboFilter.Size = New System.Drawing.Size(376, 26)
        Me.ComboFilter.TabIndex = 3
        '
        'ComboKategori
        '
        Me.ComboKategori.FormattingEnabled = True
        Me.ComboKategori.Location = New System.Drawing.Point(712, 31)
        Me.ComboKategori.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboKategori.Name = "ComboKategori"
        Me.ComboKategori.Size = New System.Drawing.Size(259, 26)
        Me.ComboKategori.TabIndex = 353
        '
        'Label_filter
        '
        Me.Label_filter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_filter.Location = New System.Drawing.Point(1004, 32)
        Me.Label_filter.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_filter.Name = "Label_filter"
        Me.Label_filter.Size = New System.Drawing.Size(127, 31)
        Me.Label_filter.TabIndex = 362
        Me.Label_filter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabDataPersonal
        '
        Me.TabDataPersonal.Controls.Add(Me.PictureBox4)
        Me.TabDataPersonal.Controls.Add(Me.Text_cariktp)
        Me.TabDataPersonal.Controls.Add(Me.Label12)
        Me.TabDataPersonal.Controls.Add(Me.Combo_opsiKTP)
        Me.TabDataPersonal.Controls.Add(Me.combo_filterKTP)
        Me.TabDataPersonal.Controls.Add(Me.Label_filterKTP)
        Me.TabDataPersonal.Controls.Add(Me.grid_dtKTP)
        Me.TabDataPersonal.Location = New System.Drawing.Point(4, 25)
        Me.TabDataPersonal.Margin = New System.Windows.Forms.Padding(4)
        Me.TabDataPersonal.Name = "TabDataPersonal"
        Me.TabDataPersonal.Padding = New System.Windows.Forms.Padding(4)
        Me.TabDataPersonal.Size = New System.Drawing.Size(1769, 601)
        Me.TabDataPersonal.TabIndex = 1
        Me.TabDataPersonal.Text = "Data Personal (Alamat KTP)"
        Me.TabDataPersonal.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.HR_project.My.Resources.Resources.find_21
        Me.PictureBox4.Location = New System.Drawing.Point(963, 68)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(27, 25)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 377
        Me.PictureBox4.TabStop = False
        '
        'Text_cariktp
        '
        Me.Text_cariktp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_cariktp.Location = New System.Drawing.Point(15, 66)
        Me.Text_cariktp.Margin = New System.Windows.Forms.Padding(4)
        Me.Text_cariktp.Name = "Text_cariktp"
        Me.Text_cariktp.Size = New System.Drawing.Size(976, 26)
        Me.Text_cariktp.TabIndex = 376
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 23)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 20)
        Me.Label12.TabIndex = 374
        Me.Label12.Text = "Filter"
        '
        'Combo_opsiKTP
        '
        Me.Combo_opsiKTP.FormattingEnabled = True
        Me.Combo_opsiKTP.Location = New System.Drawing.Point(131, 18)
        Me.Combo_opsiKTP.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_opsiKTP.Name = "Combo_opsiKTP"
        Me.Combo_opsiKTP.Size = New System.Drawing.Size(348, 24)
        Me.Combo_opsiKTP.TabIndex = 375
        '
        'combo_filterKTP
        '
        Me.combo_filterKTP.FormattingEnabled = True
        Me.combo_filterKTP.Location = New System.Drawing.Point(709, 18)
        Me.combo_filterKTP.Margin = New System.Windows.Forms.Padding(4)
        Me.combo_filterKTP.Name = "combo_filterKTP"
        Me.combo_filterKTP.Size = New System.Drawing.Size(256, 24)
        Me.combo_filterKTP.TabIndex = 371
        '
        'Label_filterKTP
        '
        Me.Label_filterKTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_filterKTP.Location = New System.Drawing.Point(488, 21)
        Me.Label_filterKTP.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_filterKTP.Name = "Label_filterKTP"
        Me.Label_filterKTP.Size = New System.Drawing.Size(213, 23)
        Me.Label_filterKTP.TabIndex = 370
        Me.Label_filterKTP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grid_dtKTP
        '
        Me.grid_dtKTP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_dtKTP.Location = New System.Drawing.Point(11, 110)
        Me.grid_dtKTP.Margin = New System.Windows.Forms.Padding(4)
        Me.grid_dtKTP.Name = "grid_dtKTP"
        Me.grid_dtKTP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_dtKTP.Size = New System.Drawing.Size(1735, 475)
        Me.grid_dtKTP.TabIndex = 1
        '
        'TabDataDomisili
        '
        Me.TabDataDomisili.Controls.Add(Me.PictureBox6)
        Me.TabDataDomisili.Controls.Add(Me.Text_caridom)
        Me.TabDataDomisili.Controls.Add(Me.Label6)
        Me.TabDataDomisili.Controls.Add(Me.Combo_opsiDom)
        Me.TabDataDomisili.Controls.Add(Me.Combo_filterDom)
        Me.TabDataDomisili.Controls.Add(Me.Label_filterdom)
        Me.TabDataDomisili.Controls.Add(Me.grid_DataDom)
        Me.TabDataDomisili.Location = New System.Drawing.Point(4, 25)
        Me.TabDataDomisili.Margin = New System.Windows.Forms.Padding(4)
        Me.TabDataDomisili.Name = "TabDataDomisili"
        Me.TabDataDomisili.Size = New System.Drawing.Size(1769, 601)
        Me.TabDataDomisili.TabIndex = 2
        Me.TabDataDomisili.Text = "Data Personal (Alamat Domisili)"
        Me.TabDataDomisili.UseVisualStyleBackColor = True
        '
        'PictureBox6
        '
        Me.PictureBox6.Image = Global.HR_project.My.Resources.Resources.find_21
        Me.PictureBox6.Location = New System.Drawing.Point(961, 69)
        Me.PictureBox6.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(27, 25)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 381
        Me.PictureBox6.TabStop = False
        '
        'Text_caridom
        '
        Me.Text_caridom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_caridom.Location = New System.Drawing.Point(13, 68)
        Me.Text_caridom.Margin = New System.Windows.Forms.Padding(4)
        Me.Text_caridom.Name = "Text_caridom"
        Me.Text_caridom.Size = New System.Drawing.Size(976, 26)
        Me.Text_caridom.TabIndex = 380
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 27)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 20)
        Me.Label6.TabIndex = 378
        Me.Label6.Text = "Filter"
        '
        'Combo_opsiDom
        '
        Me.Combo_opsiDom.FormattingEnabled = True
        Me.Combo_opsiDom.Location = New System.Drawing.Point(135, 22)
        Me.Combo_opsiDom.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_opsiDom.Name = "Combo_opsiDom"
        Me.Combo_opsiDom.Size = New System.Drawing.Size(348, 24)
        Me.Combo_opsiDom.TabIndex = 379
        '
        'Combo_filterDom
        '
        Me.Combo_filterDom.FormattingEnabled = True
        Me.Combo_filterDom.Location = New System.Drawing.Point(713, 22)
        Me.Combo_filterDom.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_filterDom.Name = "Combo_filterDom"
        Me.Combo_filterDom.Size = New System.Drawing.Size(256, 24)
        Me.Combo_filterDom.TabIndex = 377
        '
        'Label_filterdom
        '
        Me.Label_filterdom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_filterdom.Location = New System.Drawing.Point(492, 25)
        Me.Label_filterdom.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_filterdom.Name = "Label_filterdom"
        Me.Label_filterdom.Size = New System.Drawing.Size(213, 23)
        Me.Label_filterdom.TabIndex = 376
        Me.Label_filterdom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grid_DataDom
        '
        Me.grid_DataDom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_DataDom.Location = New System.Drawing.Point(11, 110)
        Me.grid_DataDom.Margin = New System.Windows.Forms.Padding(4)
        Me.grid_DataDom.Name = "grid_DataDom"
        Me.grid_DataDom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_DataDom.Size = New System.Drawing.Size(1735, 489)
        Me.grid_DataDom.TabIndex = 2
        '
        'TabIndentitasKel
        '
        Me.TabIndentitasKel.Controls.Add(Me.PictureBox7)
        Me.TabIndentitasKel.Controls.Add(Me.Text_carikel)
        Me.TabIndentitasKel.Controls.Add(Me.Combo_filterKel)
        Me.TabIndentitasKel.Controls.Add(Me.Label8)
        Me.TabIndentitasKel.Controls.Add(Me.Combo_opsiK)
        Me.TabIndentitasKel.Controls.Add(Me.Label_IK)
        Me.TabIndentitasKel.Controls.Add(Me.grid_keluarga)
        Me.TabIndentitasKel.Location = New System.Drawing.Point(4, 25)
        Me.TabIndentitasKel.Margin = New System.Windows.Forms.Padding(4)
        Me.TabIndentitasKel.Name = "TabIndentitasKel"
        Me.TabIndentitasKel.Size = New System.Drawing.Size(1769, 601)
        Me.TabIndentitasKel.TabIndex = 3
        Me.TabIndentitasKel.Text = "Identitas Keluarga"
        Me.TabIndentitasKel.UseVisualStyleBackColor = True
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = Global.HR_project.My.Resources.Resources.find_21
        Me.PictureBox7.Location = New System.Drawing.Point(960, 68)
        Me.PictureBox7.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(27, 25)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox7.TabIndex = 386
        Me.PictureBox7.TabStop = False
        '
        'Text_carikel
        '
        Me.Text_carikel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_carikel.Location = New System.Drawing.Point(12, 66)
        Me.Text_carikel.Margin = New System.Windows.Forms.Padding(4)
        Me.Text_carikel.Name = "Text_carikel"
        Me.Text_carikel.Size = New System.Drawing.Size(976, 26)
        Me.Text_carikel.TabIndex = 385
        '
        'Combo_filterKel
        '
        Me.Combo_filterKel.FormattingEnabled = True
        Me.Combo_filterKel.Location = New System.Drawing.Point(740, 18)
        Me.Combo_filterKel.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_filterKel.Name = "Combo_filterKel"
        Me.Combo_filterKel.Size = New System.Drawing.Size(280, 24)
        Me.Combo_filterKel.TabIndex = 384
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 25)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 20)
        Me.Label8.TabIndex = 382
        Me.Label8.Text = "Filter"
        '
        'Combo_opsiK
        '
        Me.Combo_opsiK.FormattingEnabled = True
        Me.Combo_opsiK.Location = New System.Drawing.Point(139, 20)
        Me.Combo_opsiK.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_opsiK.Name = "Combo_opsiK"
        Me.Combo_opsiK.Size = New System.Drawing.Size(348, 24)
        Me.Combo_opsiK.TabIndex = 383
        '
        'Label_IK
        '
        Me.Label_IK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_IK.Location = New System.Drawing.Point(496, 22)
        Me.Label_IK.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_IK.Name = "Label_IK"
        Me.Label_IK.Size = New System.Drawing.Size(213, 23)
        Me.Label_IK.TabIndex = 380
        Me.Label_IK.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grid_keluarga
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid_keluarga.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grid_keluarga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_keluarga.Location = New System.Drawing.Point(11, 110)
        Me.grid_keluarga.Margin = New System.Windows.Forms.Padding(4)
        Me.grid_keluarga.Name = "grid_keluarga"
        Me.grid_keluarga.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_keluarga.Size = New System.Drawing.Size(1735, 473)
        Me.grid_keluarga.TabIndex = 2
        '
        'TabFaskes
        '
        Me.TabFaskes.Controls.Add(Me.PictureBox8)
        Me.TabFaskes.Controls.Add(Me.Text_carifas)
        Me.TabFaskes.Controls.Add(Me.Label10)
        Me.TabFaskes.Controls.Add(Me.Combo_opsiFK)
        Me.TabFaskes.Controls.Add(Me.Combo_filerFK)
        Me.TabFaskes.Controls.Add(Me.Label_faskes)
        Me.TabFaskes.Controls.Add(Me.grid_faskes)
        Me.TabFaskes.Location = New System.Drawing.Point(4, 25)
        Me.TabFaskes.Margin = New System.Windows.Forms.Padding(4)
        Me.TabFaskes.Name = "TabFaskes"
        Me.TabFaskes.Size = New System.Drawing.Size(1769, 601)
        Me.TabFaskes.TabIndex = 4
        Me.TabFaskes.Text = "Fasilitas Kesehatan"
        Me.TabFaskes.UseVisualStyleBackColor = True
        '
        'PictureBox8
        '
        Me.PictureBox8.Image = Global.HR_project.My.Resources.Resources.find_21
        Me.PictureBox8.Location = New System.Drawing.Point(959, 64)
        Me.PictureBox8.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(27, 25)
        Me.PictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox8.TabIndex = 385
        Me.PictureBox8.TabStop = False
        '
        'Text_carifas
        '
        Me.Text_carifas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_carifas.Location = New System.Drawing.Point(11, 63)
        Me.Text_carifas.Margin = New System.Windows.Forms.Padding(4)
        Me.Text_carifas.Name = "Text_carifas"
        Me.Text_carifas.Size = New System.Drawing.Size(976, 26)
        Me.Text_carifas.TabIndex = 384
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 23)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 20)
        Me.Label10.TabIndex = 382
        Me.Label10.Text = "Filter"
        '
        'Combo_opsiFK
        '
        Me.Combo_opsiFK.FormattingEnabled = True
        Me.Combo_opsiFK.Location = New System.Drawing.Point(135, 18)
        Me.Combo_opsiFK.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_opsiFK.Name = "Combo_opsiFK"
        Me.Combo_opsiFK.Size = New System.Drawing.Size(348, 24)
        Me.Combo_opsiFK.TabIndex = 383
        '
        'Combo_filerFK
        '
        Me.Combo_filerFK.FormattingEnabled = True
        Me.Combo_filerFK.Location = New System.Drawing.Point(713, 18)
        Me.Combo_filerFK.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_filerFK.Name = "Combo_filerFK"
        Me.Combo_filerFK.Size = New System.Drawing.Size(256, 24)
        Me.Combo_filerFK.TabIndex = 381
        '
        'Label_faskes
        '
        Me.Label_faskes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_faskes.Location = New System.Drawing.Point(492, 21)
        Me.Label_faskes.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label_faskes.Name = "Label_faskes"
        Me.Label_faskes.Size = New System.Drawing.Size(213, 23)
        Me.Label_faskes.TabIndex = 380
        Me.Label_faskes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grid_faskes
        '
        Me.grid_faskes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid_faskes.Location = New System.Drawing.Point(11, 110)
        Me.grid_faskes.Margin = New System.Windows.Forms.Padding(4)
        Me.grid_faskes.Name = "grid_faskes"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid_faskes.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grid_faskes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_faskes.Size = New System.Drawing.Size(1735, 475)
        Me.grid_faskes.TabIndex = 3
        '
        'Radio_fulljab
        '
        Me.Radio_fulljab.AutoSize = True
        Me.Radio_fulljab.Checked = True
        Me.Radio_fulljab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_fulljab.Location = New System.Drawing.Point(1259, 122)
        Me.Radio_fulljab.Margin = New System.Windows.Forms.Padding(4)
        Me.Radio_fulljab.Name = "Radio_fulljab"
        Me.Radio_fulljab.Size = New System.Drawing.Size(80, 22)
        Me.Radio_fulljab.TabIndex = 353
        Me.Radio_fulljab.TabStop = True
        Me.Radio_fulljab.Text = "Periode"
        Me.Radio_fulljab.UseVisualStyleBackColor = True
        '
        'Radio_singlejab
        '
        Me.Radio_singlejab.AutoSize = True
        Me.Radio_singlejab.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Radio_singlejab.Location = New System.Drawing.Point(1368, 122)
        Me.Radio_singlejab.Margin = New System.Windows.Forms.Padding(4)
        Me.Radio_singlejab.Name = "Radio_singlejab"
        Me.Radio_singlejab.Size = New System.Drawing.Size(125, 22)
        Me.Radio_singlejab.TabIndex = 2
        Me.Radio_singlejab.Text = "Tanpa Periode"
        Me.Radio_singlejab.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.EditDataPersonalToolStripMenuItem, Me.ToolStripMenuItem2, Me.ToolStripRiwayatKerja, Me.HapusDataToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(215, 88)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(211, 6)
        '
        'EditDataPersonalToolStripMenuItem
        '
        Me.EditDataPersonalToolStripMenuItem.Name = "EditDataPersonalToolStripMenuItem"
        Me.EditDataPersonalToolStripMenuItem.Size = New System.Drawing.Size(214, 24)
        Me.EditDataPersonalToolStripMenuItem.Text = "Edit Data Personal"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(211, 6)
        '
        'ToolStripRiwayatKerja
        '
        Me.ToolStripRiwayatKerja.Name = "ToolStripRiwayatKerja"
        Me.ToolStripRiwayatKerja.Size = New System.Drawing.Size(214, 24)
        Me.ToolStripRiwayatKerja.Text = "Daftar Riwayat Kerja"
        Me.ToolStripRiwayatKerja.Visible = False
        '
        'HapusDataToolStripMenuItem
        '
        Me.HapusDataToolStripMenuItem.Name = "HapusDataToolStripMenuItem"
        Me.HapusDataToolStripMenuItem.Size = New System.Drawing.Size(214, 24)
        Me.HapusDataToolStripMenuItem.Text = "Hapus Data"
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label14.Location = New System.Drawing.Point(19, 10)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(13, 50)
        Me.Label14.TabIndex = 356
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Britannic Bold", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.SteelBlue
        Me.Label2.Location = New System.Drawing.Point(32, 11)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(606, 52)
        Me.Label2.TabIndex = 355
        Me.Label2.Text = "FORM DATA KEKARYAWANAN"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox3.Location = New System.Drawing.Point(0, -1)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(1823, 80)
        Me.PictureBox3.TabIndex = 340
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox2.Location = New System.Drawing.Point(3, 750)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(1823, 166)
        Me.PictureBox2.TabIndex = 339
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.HR_project.My.Resources.Resources.input_data
        Me.PictureBox1.Location = New System.Drawing.Point(0, 742)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1823, 166)
        Me.PictureBox1.TabIndex = 341
        Me.PictureBox1.TabStop = False
        '
        'worker1
        '
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(28, 788)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(522, 23)
        Me.ProgressBar1.TabIndex = 357
        Me.ProgressBar1.Visible = False
        '
        'Label_progress
        '
        Me.Label_progress.AutoSize = True
        Me.Label_progress.BackColor = System.Drawing.Color.Transparent
        Me.Label_progress.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_progress.Location = New System.Drawing.Point(556, 791)
        Me.Label_progress.Name = "Label_progress"
        Me.Label_progress.Size = New System.Drawing.Size(38, 20)
        Me.Label_progress.TabIndex = 358
        Me.Label_progress.Text = "0 %"
        Me.Label_progress.Visible = False
        '
        'ButtonExport
        '
        Me.ButtonExport.Location = New System.Drawing.Point(26, 750)
        Me.ButtonExport.Margin = New System.Windows.Forms.Padding(4)
        Me.ButtonExport.Name = "ButtonExport"
        Me.ButtonExport.Size = New System.Drawing.Size(121, 31)
        Me.ButtonExport.TabIndex = 367
        Me.ButtonExport.Text = "Export File"
        Me.ButtonExport.UseVisualStyleBackColor = True
        '
        'FormDataKekaryawanan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1827, 922)
        Me.Controls.Add(Me.ButtonExport)
        Me.Controls.Add(Me.Label_progress)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Radio_singlejab)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Radio_fulljab)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Combo_kary)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormDataKekaryawanan"
        Me.Text = "FormDataKekaryawanan"
        Me.TabControl1.ResumeLayout(False)
        Me.TabDTKaryawan.ResumeLayout(False)
        Me.TabDTKaryawan.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Group_periode.ResumeLayout(False)
        Me.Group_periode.PerformLayout()
        CType(Me.grid_karyawan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabDataPersonal.ResumeLayout(False)
        Me.TabDataPersonal.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid_dtKTP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabDataDomisili.ResumeLayout(False)
        Me.TabDataDomisili.PerformLayout()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid_DataDom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabIndentitasKel.ResumeLayout(False)
        Me.TabIndentitasKel.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid_keluarga, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabFaskes.ResumeLayout(False)
        Me.TabFaskes.PerformLayout()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grid_faskes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Combo_kary As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabDTKaryawan As System.Windows.Forms.TabPage
    Friend WithEvents grid_karyawan As System.Windows.Forms.DataGridView
    Friend WithEvents TabDataPersonal As System.Windows.Forms.TabPage
    Friend WithEvents grid_dtKTP As System.Windows.Forms.DataGridView
    Friend WithEvents TabDataDomisili As System.Windows.Forms.TabPage
    Friend WithEvents grid_DataDom As System.Windows.Forms.DataGridView
    Friend WithEvents TabIndentitasKel As System.Windows.Forms.TabPage
    Friend WithEvents grid_keluarga As System.Windows.Forms.DataGridView
    Friend WithEvents Group_periode As System.Windows.Forms.GroupBox
    Friend WithEvents B_go As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboFilter As System.Windows.Forms.ComboBox
    Friend WithEvents ComboKategori As System.Windows.Forms.ComboBox
    Friend WithEvents Label_filter As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Combo_opsiKTP As System.Windows.Forms.ComboBox
    Friend WithEvents combo_filterKTP As System.Windows.Forms.ComboBox
    Friend WithEvents Label_filterKTP As System.Windows.Forms.Label
    Friend WithEvents TabFaskes As System.Windows.Forms.TabPage
    Friend WithEvents grid_faskes As System.Windows.Forms.DataGridView
    Friend WithEvents DT_akhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Combo_opsiDom As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_filterDom As System.Windows.Forms.ComboBox
    Friend WithEvents Label_filterdom As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Combo_opsiK As System.Windows.Forms.ComboBox
    Friend WithEvents Label_IK As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Combo_opsiFK As System.Windows.Forms.ComboBox
    Friend WithEvents Combo_filerFK As System.Windows.Forms.ComboBox
    Friend WithEvents Label_faskes As System.Windows.Forms.Label
    Friend WithEvents Radio_fulljab As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_singlejab As System.Windows.Forms.RadioButton
    Friend WithEvents Combo_filterKel As System.Windows.Forms.ComboBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EditDataPersonalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HapusDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Text_cariktp As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Text_cari As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents Text_caridom As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents Text_carikel As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents Text_carifas As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripRiwayatKerja As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents worker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label_progress As System.Windows.Forms.Label
    Friend WithEvents ButtonExport As System.Windows.Forms.Button
    Friend WithEvents WorkerDtKaryawan As System.ComponentModel.BackgroundWorker
    Friend WithEvents WorkerDtKeluarga As System.ComponentModel.BackgroundWorker
    Friend WithEvents WorkerDtFaskes As System.ComponentModel.BackgroundWorker
    Friend WithEvents WorkerDataKTP As System.ComponentModel.BackgroundWorker
    Friend WithEvents WorkerDtDomisili As System.ComponentModel.BackgroundWorker
End Class
