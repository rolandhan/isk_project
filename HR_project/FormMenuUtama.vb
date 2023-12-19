Imports System.Globalization

Public Class FormMenuUtama
    Dim isRed As Boolean = True
    Dim blinking As Boolean = False


    ' Override the ProcessCmdKey function to handle custom keyboard shortcuts
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = (Keys.Control Or Keys.D) Then
            ' Ctrl + D is pressed, handle your command here
            DisplayMessage("Ctrl + D is pressed!")
            Return True ' We handled the command
        End If

        ' If it's not our custom command, let the base class handle it
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    ' Custom method to display a message
    Private Sub DisplayMessage(ByVal message As String)
        MessageBox.Show(message, "Custom Command", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ... Rest of your form code ...
    Private Sub FormMenuUtama_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SamplePotonganToolStripMenuItem.Visible = False
        disable_menu()
        Application.CurrentCulture = New CultureInfo("id-ID")
        FormLogIn.Show()
        FormLogIn.StartPosition = FormStartPosition.CenterScreen
        FormLogIn.MdiParent = Me
    End Sub


    Private Sub IjinDinasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub IjinCutiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub IjinMeninggalkanKerjaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TelatKerjaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub RekapAbsensiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PemanggilanKaryawanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub RekapTahunanKhususToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        With FormRekapTahunan
            .Show()
            .MdiParent = Me
            .WindowState = FormWindowState.Maximized
        End With
    End Sub

    Private Sub IjinCutiToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormIjinCuti.Show()
        FormIjinCuti.MdiParent = Me
        FormIjinCuti.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub IjinMeninggalkanPekerjaanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormIjinKerja.Show()
        FormIjinKerja.MdiParent = Me
        FormIjinKerja.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub TelatKerjaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormTelatMasukKerja.Show()
        FormTelatMasukKerja.MdiParent = Me
        FormTelatMasukKerja.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub IjinDinasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormDinas.Show()
        FormDinas.MdiParent = Me
        FormDinas.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub PemanggilanKaryawanToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormCatatanKhusus.Show()
        FormCatatanKhusus.MdiParent = Me
        FormCatatanKhusus.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub RekapAbsensiToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormRekapAbsen.Show()
        FormRekapAbsen.MdiParent = Me
        FormRekapAbsen.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub MesinToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormConnectFinger.Show()
        FormConnectFinger.MdiParent = Me
        FormConnectFinger.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub FormAbsensiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormAbsensi.Show()
        FormAbsensi.MdiParent = Me
        FormAbsensi.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ImportDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormImportFile.Show()
        FormImportFile.MdiParent = Me
        FormImportFile.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub FormLaporanAbsensiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormDetailPresensi.Show()
        FormDetailPresensi.MdiParent = Me
        FormDetailPresensi.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub LogInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogInToolStripMenuItem.Click
        FormLogIn.Show()

    End Sub

    Private Sub DetailPeresensiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormDetRiwayat.Show()
        FormDetRiwayat.MdiParent = Me
        FormDetRiwayat.WindowState = FormWindowState.Maximized

    End Sub

    Private Sub KeluarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeluarToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub CekMesinFingerspotToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormSettingFingerSpot.Show()
        FormSettingFingerSpot.MdiParent = Me
        FormSettingFingerSpot.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub HistorisJabatanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormDetail_Pegawai.Show()
        FormDetail_Pegawai.MdiParent = Me
        FormDetail_Pegawai.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub RiwayatKerjaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormDetRiwayat.Show()
        FormDetRiwayat.MdiParent = Me
        FormDetRiwayat.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub MesinToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MesinToolStripMenuItem.Click
        FormSettingFingerSpot.Show()
        FormSettingFingerSpot.MdiParent = Me
        FormSettingFingerSpot.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ImportDataToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportDataToolStripMenuItem.Click
        FormImportData.Show()
        FormImportData.MdiParent = Me
        FormImportData.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutToolStripMenuItem.Click
        disable_menu()
    End Sub

    Private Sub PengolahanAbsensiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormAbsensi.Show()
        FormAbsensi.MdiParent = Me
        FormAbsensi.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub DataAbsensiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormDetailPresensi.Show()
        FormDetailPresensi.MdiParent = Me
        FormDetailPresensi.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ImportDataAbsensiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DownloadDataAbsensiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub LaporanRekapiltulasiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormRekapAbsen.Show()
        FormRekapAbsen.MdiParent = Me
        FormRekapAbsen.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub LaporanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MesinToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MesinToolStripMenuItem1.Click
        FormConnectDevices.Show()
        FormConnectDevices.MdiParent = Me
        FormConnectDevices.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub DownloadDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownloadDataToolStripMenuItem.Click

    End Sub

    Private Sub EditDataKaryawanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormEditDtPeg.Show()
        FormEditDtPeg.MdiParent = Me
        FormEditDtPeg.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub LaporanUmumToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormLapUmum.Show()
        FormLapUmum.MdiParent = Me
        FormLapUmum.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub SampleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormAbsensiKhusus.Show()
        FormAbsensiKhusus.MdiParent = Me
        FormAbsensiKhusus.WindowState = FormWindowState.Maximized
    End Sub


    Private Sub Sample2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SampleCutiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub InputDataKaryawanToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputDataKaryawanToolStripMenuItem1.Click
        nik_global = String.Empty
        FormDTPersonal.Show()
        FormDTPersonal.MdiParent = Me
        FormDTPersonal.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub InputDataJabatanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InputDataJabatanToolStripMenuItem.Click
        FormDTJabatan.Show()
        FormDTJabatan.MdiParent = Me
        FormDTJabatan.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub DataKekaryawanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataKekaryawanToolStripMenuItem.Click
        FormDataKekaryawanan.Show()
        FormDataKekaryawanan.MdiParent = Me
        FormDataKekaryawanan.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub DaftarCutiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DaftarCutiToolStripMenuItem.Click
        FormDaftarCuti.Show()
        FormDaftarCuti.MdiParent = Me
        FormDaftarCuti.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub IjinTidakMasukToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IjinTidakMasukToolStripMenuItem.Click
        FormIjinCuti.Show()
        FormIjinCuti.MdiParent = Me
        FormIjinCuti.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub IjinMeninggalkanPekerjaanToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IjinMeninggalkanPekerjaanToolStripMenuItem1.Click
        FormIjinKerja.Show()
        FormIjinKerja.MdiParent = Me
        FormIjinKerja.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub KeterlambatanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeterlambatanToolStripMenuItem.Click
        FormTelatMasukKerja.Show()
        FormTelatMasukKerja.MdiParent = Me
        FormTelatMasukKerja.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub DinasLuarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DinasLuarToolStripMenuItem.Click
        FormDinas.Show()
        FormDinas.MdiParent = Me
        FormDinas.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub RekapitulasiAbsensiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RekapitulasiAbsensiToolStripMenuItem.Click
        FormRekapAbsen.Show()
        FormRekapAbsen.MdiParent = Me
        FormRekapAbsen.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub FormAbsenMasaTrainingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormAbsenMasaTrainingToolStripMenuItem.Click
        FormAbsensiKhusus.Show()
        FormAbsensiKhusus.MdiParent = Me
        FormAbsensiKhusus.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub FormAbsenLampiranKecelakanKerjaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormAbsenLampiranKecelakanKerjaToolStripMenuItem.Click
        FormAbsensiKhusus.Show()
        FormAbsensiKhusus.MdiParent = Me
        FormAbsensiKhusus.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub AbsensiHarianToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbsensiHarianToolStripMenuItem.Click
        FormDaftarAbsensi.Show()
        FormDaftarAbsensi.MdiParent = Me
        FormDaftarAbsensi.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub RiwayatPerijinanKaryawanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RiwayatPerijinanKaryawanToolStripMenuItem.Click
        FormDaftarRiwayatIjin.Show()
        FormDaftarRiwayatIjin.MdiParent = Me
        FormDaftarRiwayatIjin.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub PenarikanAbsensiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PenarikanAbsensiToolStripMenuItem.Click

    End Sub

    Private Sub DataSPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataSPToolStripMenuItem.Click
        FormCatatanKhusus.Show()
        FormCatatanKhusus.MdiParent = Me
        FormCatatanKhusus.WindowState = FormWindowState.Maximized
    End Sub


    Private Sub PotonganToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DownloadDataToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownloadDataToolStripMenuItem1.Click
        FormDownloadData.Show()
        FormDownloadData.MdiParent = Me
        FormDownloadData.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub PengolahanAbsensiToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PengolahanAbsensiToolStripMenuItem.Click
        FormAbsensi.Show()
        FormAbsensi.MdiParent = Me
        FormAbsensi.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub DaftarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DaftarToolStripMenuItem.Click
        FormDaftarPotongan.Show()
        FormDaftarPotongan.MdiParent = Me
        FormDaftarPotongan.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub GantiNIKKaryawanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GantiNIKKaryawanToolStripMenuItem.Click
        FormGantiNIK.Show()
        FormGantiNIK.MdiParent = Me
        FormGantiNIK.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub DaftarDataPerijinanDanKeterlambatanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DaftarDataPerijinanDanKeterlambatanToolStripMenuItem.Click
        FormEditIjin.Show()
        FormEditIjin.MdiParent = Me
        FormEditIjin.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub SampleToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SampleToolStripMenuItem.Click
        FormEditPeringatan.Show()
        FormEditPeringatan.MdiParent = Me
        FormEditPeringatan.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub SampleabsenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SampleabsenToolStripMenuItem.Click
        FormDaftarAbsensiFull.Show()
        FormDaftarAbsensiFull.MdiParent = Me
        FormDaftarAbsensiFull.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub DaftarAbsensiHarianToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DaftarAbsensiHarianToolStripMenuItem.Click
        FormDaftarAbsensiFull.Show()
        FormDaftarAbsensiFull.MdiParent = Me
        FormDaftarAbsensiFull.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub RiwayatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RiwayatToolStripMenuItem.Click
        FormDaftarRiwayatIjin.Show()
        FormDaftarRiwayatIjin.MdiParent = Me
        FormDaftarRiwayatIjin.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub DaftarDataSPCovidDanPeringatanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DaftarDataSPCovidDanPeringatanToolStripMenuItem.Click
        FormEditPeringatan.Show()
        FormEditPeringatan.MdiParent = Me
        FormEditPeringatan.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub PengaturanLaporanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PengaturanLaporanToolStripMenuItem.Click
        FormPengaturanLaporan.Show()
        FormPengaturanLaporan.MdiParent = Me
        FormPengaturanLaporan.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub MutasiKaryawanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MutasiKaryawanToolStripMenuItem.Click
        FormMutasi.Show()
        FormMutasi.MdiParent = Me
        FormMutasi.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub FormMenuUtama_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Sub StartBlink()
        Timer1.Interval = 500 ' Interval waktu dalam milidetik (500 ms)
        Timer1.Start()
        blinking = Not blinking
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If blinking Then
            If isRed Then
                LinkLabel1.LinkColor = Color.Blue
            Else
                LinkLabel1.LinkColor = Color.Red
            End If
            isRed = Not isRed
        Else
            LinkLabel1.LinkColor = Color.Blue
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        'blinking = Not blinking
        Timer1.Stop()
        FormKontrak.Show()
        FormKontrak.MdiParent = Me
        FormKontrak.WindowState = FormWindowState.Maximized
        LinkLabel1.Visible = False
    End Sub

    Private Sub RiwayatMutasiDanHarianToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RiwayatMutasiDanHarianToolStripMenuItem.Click
        FormRiwayatMutasi.Show()
        FormRiwayatMutasi.MdiParent = Me
        FormRiwayatMutasi.WindowState = FormWindowState.Maximized
    End Sub
End Class