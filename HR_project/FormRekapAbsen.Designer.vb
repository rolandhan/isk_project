<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRekapAbsen
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
        Me.Combo_dept = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Group_periode = New System.Windows.Forms.GroupBox()
        Me.Radio_tahunan = New System.Windows.Forms.RadioButton()
        Me.Radio_triwulan = New System.Windows.Forms.RadioButton()
        Me.Button_go = New System.Windows.Forms.Button()
        Me.Check_harian = New System.Windows.Forms.CheckBox()
        Me.Radio_bulanan = New System.Windows.Forms.RadioButton()
        Me.DT_tglke = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DT_tgldari = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Combo_khusus = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grid_karyawan = New System.Windows.Forms.DataGridView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.LabelPeriode = New System.Windows.Forms.Label()
        Me.Worker1 = New System.ComponentModel.BackgroundWorker()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.worker2 = New System.ComponentModel.BackgroundWorker()
        Me.worker3 = New System.ComponentModel.BackgroundWorker()
        Me.Button_baru = New System.Windows.Forms.Button()
        Me.WorkerDtHarian = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LabelProcess = New System.Windows.Forms.Label()
        Me.WorkerTimer = New System.ComponentModel.BackgroundWorker()
        Me.WorkerLaporan = New System.ComponentModel.BackgroundWorker()
        Me.LabelMemuat = New System.Windows.Forms.Label()
        Me.WorkerTahunan = New System.ComponentModel.BackgroundWorker()
        Me.WorkerTriwulan = New System.ComponentModel.BackgroundWorker()
        Me.WorkerBulanan = New System.ComponentModel.BackgroundWorker()
        Me.Group_periode.SuspendLayout()
        CType(Me.grid_karyawan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Combo_dept
        '
        Me.Combo_dept.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_dept.FormattingEnabled = True
        Me.Combo_dept.Location = New System.Drawing.Point(951, 111)
        Me.Combo_dept.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_dept.Name = "Combo_dept"
        Me.Combo_dept.Size = New System.Drawing.Size(348, 28)
        Me.Combo_dept.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(807, 114)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Departmen"
        '
        'Group_periode
        '
        Me.Group_periode.Controls.Add(Me.Radio_tahunan)
        Me.Group_periode.Controls.Add(Me.Radio_triwulan)
        Me.Group_periode.Controls.Add(Me.Button_go)
        Me.Group_periode.Controls.Add(Me.Check_harian)
        Me.Group_periode.Controls.Add(Me.Radio_bulanan)
        Me.Group_periode.Controls.Add(Me.DT_tglke)
        Me.Group_periode.Controls.Add(Me.Label2)
        Me.Group_periode.Controls.Add(Me.DT_tgldari)
        Me.Group_periode.Controls.Add(Me.Label13)
        Me.Group_periode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Group_periode.Location = New System.Drawing.Point(31, 102)
        Me.Group_periode.Margin = New System.Windows.Forms.Padding(4)
        Me.Group_periode.Name = "Group_periode"
        Me.Group_periode.Padding = New System.Windows.Forms.Padding(4)
        Me.Group_periode.Size = New System.Drawing.Size(768, 167)
        Me.Group_periode.TabIndex = 203
        Me.Group_periode.TabStop = False
        Me.Group_periode.Text = "Periode"
        '
        'Radio_tahunan
        '
        Me.Radio_tahunan.AutoSize = True
        Me.Radio_tahunan.Location = New System.Drawing.Point(24, 76)
        Me.Radio_tahunan.Margin = New System.Windows.Forms.Padding(4)
        Me.Radio_tahunan.Name = "Radio_tahunan"
        Me.Radio_tahunan.Size = New System.Drawing.Size(146, 24)
        Me.Radio_tahunan.TabIndex = 211
        Me.Radio_tahunan.TabStop = True
        Me.Radio_tahunan.Text = "Rekap Tahunan"
        Me.Radio_tahunan.UseVisualStyleBackColor = True
        '
        'Radio_triwulan
        '
        Me.Radio_triwulan.AutoSize = True
        Me.Radio_triwulan.Location = New System.Drawing.Point(25, 50)
        Me.Radio_triwulan.Margin = New System.Windows.Forms.Padding(4)
        Me.Radio_triwulan.Name = "Radio_triwulan"
        Me.Radio_triwulan.Size = New System.Drawing.Size(145, 24)
        Me.Radio_triwulan.TabIndex = 210
        Me.Radio_triwulan.TabStop = True
        Me.Radio_triwulan.Text = "Rekap Triwulan"
        Me.Radio_triwulan.UseVisualStyleBackColor = True
        '
        'Button_go
        '
        Me.Button_go.Location = New System.Drawing.Point(644, 117)
        Me.Button_go.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_go.Name = "Button_go"
        Me.Button_go.Size = New System.Drawing.Size(52, 32)
        Me.Button_go.TabIndex = 202
        Me.Button_go.Text = "Go !"
        Me.Button_go.UseVisualStyleBackColor = True
        '
        'Check_harian
        '
        Me.Check_harian.AutoSize = True
        Me.Check_harian.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_harian.Location = New System.Drawing.Point(396, 125)
        Me.Check_harian.Margin = New System.Windows.Forms.Padding(4)
        Me.Check_harian.Name = "Check_harian"
        Me.Check_harian.Size = New System.Drawing.Size(81, 24)
        Me.Check_harian.TabIndex = 329
        Me.Check_harian.Text = "Harian"
        Me.Check_harian.UseVisualStyleBackColor = True
        '
        'Radio_bulanan
        '
        Me.Radio_bulanan.AutoSize = True
        Me.Radio_bulanan.Location = New System.Drawing.Point(25, 25)
        Me.Radio_bulanan.Margin = New System.Windows.Forms.Padding(4)
        Me.Radio_bulanan.Name = "Radio_bulanan"
        Me.Radio_bulanan.Size = New System.Drawing.Size(143, 24)
        Me.Radio_bulanan.TabIndex = 209
        Me.Radio_bulanan.TabStop = True
        Me.Radio_bulanan.Text = "Rekap Bulanan"
        Me.Radio_bulanan.UseVisualStyleBackColor = True
        '
        'DT_tglke
        '
        Me.DT_tglke.Location = New System.Drawing.Point(459, 71)
        Me.DT_tglke.Margin = New System.Windows.Forms.Padding(4)
        Me.DT_tglke.Name = "DT_tglke"
        Me.DT_tglke.Size = New System.Drawing.Size(237, 26)
        Me.DT_tglke.TabIndex = 201
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(393, 73)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 18)
        Me.Label2.TabIndex = 200
        Me.Label2.Text = "Ke"
        '
        'DT_tgldari
        '
        Me.DT_tgldari.Location = New System.Drawing.Point(459, 30)
        Me.DT_tgldari.Margin = New System.Windows.Forms.Padding(4)
        Me.DT_tgldari.Name = "DT_tgldari"
        Me.DT_tgldari.Size = New System.Drawing.Size(237, 26)
        Me.DT_tgldari.TabIndex = 199
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(393, 28)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 18)
        Me.Label13.TabIndex = 198
        Me.Label13.Text = "Dari"
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
        Me.Label4.Size = New System.Drawing.Size(639, 52)
        Me.Label4.TabIndex = 324
        Me.Label4.Text = "FORM REKAPITULASI ABSENSI"
        '
        'Combo_khusus
        '
        Me.Combo_khusus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo_khusus.FormattingEnabled = True
        Me.Combo_khusus.Location = New System.Drawing.Point(951, 150)
        Me.Combo_khusus.Margin = New System.Windows.Forms.Padding(4)
        Me.Combo_khusus.Name = "Combo_khusus"
        Me.Combo_khusus.Size = New System.Drawing.Size(348, 28)
        Me.Combo_khusus.TabIndex = 326
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(807, 160)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 20)
        Me.Label3.TabIndex = 327
        Me.Label3.Text = "Bagian Khusus"
        '
        'grid_karyawan
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grid_karyawan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grid_karyawan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid_karyawan.DefaultCellStyle = DataGridViewCellStyle2
        Me.grid_karyawan.Location = New System.Drawing.Point(31, 277)
        Me.grid_karyawan.Margin = New System.Windows.Forms.Padding(4)
        Me.grid_karyawan.Name = "grid_karyawan"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grid_karyawan.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grid_karyawan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid_karyawan.Size = New System.Drawing.Size(1735, 417)
        Me.grid_karyawan.TabIndex = 328
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
        'Button1
        '
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = Global.HR_project.My.Resources.Resources.cetak
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(35, 724)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(91, 70)
        Me.Button1.TabIndex = 207
        Me.Button1.Text = "Cetak"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
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
        'LabelPeriode
        '
        Me.LabelPeriode.AutoSize = True
        Me.LabelPeriode.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPeriode.Location = New System.Drawing.Point(1207, 709)
        Me.LabelPeriode.Name = "LabelPeriode"
        Me.LabelPeriode.Size = New System.Drawing.Size(550, 20)
        Me.LabelPeriode.TabIndex = 331
        Me.LabelPeriode.Text = "untuk periode triwulan dimulai dari tanggal 26 sampai dengan tanggal 25 "
        '
        'Worker1
        '
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(702, 709)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(286, 27)
        Me.ProgressBar1.TabIndex = 333
        Me.ProgressBar1.Visible = False
        '
        'worker2
        '
        '
        'worker3
        '
        '
        'Button_baru
        '
        Me.Button_baru.FlatAppearance.BorderSize = 0
        Me.Button_baru.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button_baru.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button_baru.Image = Global.HR_project.My.Resources.Resources._new
        Me.Button_baru.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button_baru.Location = New System.Drawing.Point(134, 724)
        Me.Button_baru.Margin = New System.Windows.Forms.Padding(4)
        Me.Button_baru.Name = "Button_baru"
        Me.Button_baru.Size = New System.Drawing.Size(91, 70)
        Me.Button_baru.TabIndex = 334
        Me.Button_baru.Text = "baru"
        Me.Button_baru.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button_baru.UseVisualStyleBackColor = True
        '
        'WorkerDtHarian
        '
        '
        'Timer1
        '
        '
        'LabelProcess
        '
        Me.LabelProcess.AutoSize = True
        Me.LabelProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProcess.Location = New System.Drawing.Point(1012, 710)
        Me.LabelProcess.Name = "LabelProcess"
        Me.LabelProcess.Size = New System.Drawing.Size(59, 20)
        Me.LabelProcess.TabIndex = 335
        Me.LabelProcess.Text = "Label5"
        Me.LabelProcess.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LabelProcess.Visible = False
        '
        'WorkerTimer
        '
        '
        'WorkerLaporan
        '
        '
        'LabelMemuat
        '
        Me.LabelMemuat.AutoSize = True
        Me.LabelMemuat.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMemuat.Location = New System.Drawing.Point(822, 710)
        Me.LabelMemuat.Name = "LabelMemuat"
        Me.LabelMemuat.Size = New System.Drawing.Size(140, 20)
        Me.LabelMemuat.TabIndex = 336
        Me.LabelMemuat.Text = "sedang memuat..."
        Me.LabelMemuat.Visible = False
        '
        'WorkerTahunan
        '
        '
        'WorkerTriwulan
        '
        Me.WorkerTriwulan.WorkerReportsProgress = True
        Me.WorkerTriwulan.WorkerSupportsCancellation = True
        '
        'WorkerBulanan
        '
        Me.WorkerBulanan.WorkerReportsProgress = True
        Me.WorkerBulanan.WorkerSupportsCancellation = True
        '
        'FormRekapAbsen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1827, 923)
        Me.Controls.Add(Me.LabelMemuat)
        Me.Controls.Add(Me.LabelProcess)
        Me.Controls.Add(Me.Button_baru)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.LabelPeriode)
        Me.Controls.Add(Me.grid_karyawan)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Combo_khusus)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Group_periode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Combo_dept)
        Me.Controls.Add(Me.PictureBox2)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "FormRekapAbsen"
        Me.Text = "FormRekapAbsen"
        Me.Group_periode.ResumeLayout(False)
        Me.Group_periode.PerformLayout()
        CType(Me.grid_karyawan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Combo_dept As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Group_periode As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DT_tglke As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DT_tgldari As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button_go As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Radio_triwulan As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_bulanan As System.Windows.Forms.RadioButton
    Friend WithEvents Radio_tahunan As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Combo_khusus As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grid_karyawan As System.Windows.Forms.DataGridView
    Friend WithEvents Check_harian As System.Windows.Forms.CheckBox
    Friend WithEvents LabelPeriode As System.Windows.Forms.Label
    Friend WithEvents Worker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents worker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents worker3 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button_baru As System.Windows.Forms.Button
    Friend WithEvents WorkerDtHarian As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents LabelProcess As System.Windows.Forms.Label
    Friend WithEvents WorkerTimer As System.ComponentModel.BackgroundWorker
    Friend WithEvents WorkerLaporan As System.ComponentModel.BackgroundWorker
    Friend WithEvents LabelMemuat As System.Windows.Forms.Label
    Friend WithEvents WorkerTahunan As System.ComponentModel.BackgroundWorker
    Friend WithEvents WorkerTriwulan As System.ComponentModel.BackgroundWorker
    Friend WithEvents WorkerBulanan As System.ComponentModel.BackgroundWorker
End Class
