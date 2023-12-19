Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FormKhusus

    Private Sub FormKhusus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub load_cmbCovid(ByVal combo As ComboBox)
        combo.Items.Add("Positif")
        combo.Items.Add("Negatif")
    End Sub

    Private Sub load_gridKK()
        Try
            clear_command()
            openDB()
            sql = ""
        Catch ex As Exception

        End Try
    End Sub

    Private Sub load_gridCov()

    End Sub

End Class