Imports System.Xml.Serialization
Imports System.IO
Module ModuleTempData
    Dim Ds As DataSet
    Public Sub LoadXMl()
        LoadFromXMLfile("c:\report_config.xml")
    End Sub

    'memuat file XML
    Private Sub LoadFromXMLfile(ByVal filename As String)
        If System.IO.File.Exists(filename) Then
            Dim xmlSerializer As XmlSerializer = New XmlSerializer(ds.GetType)
            Dim readStream As FileStream = New FileStream(filename, FileMode.Open)
            ds = CType(xmlSerializer.Deserialize(readStream), DataSet)
            readStream.Close()
            'DataGridView1.DataSource = ds.Tables("Person")
        Else
            MsgBox("File tidak ditemukan, silahkan entri data terlebih dahulu", MsgBoxStyle.Exclamation, "")
        End If
    End Sub

    'simpan data kedalam file XML
    Private Sub SaveToXMLFile(ByVal filename As String, ByVal Dset As DataSet)
        Dim ser As XmlSerializer = New XmlSerializer(GetType(DataSet))
        Dim writer As TextWriter = New StreamWriter(filename)
        ser.Serialize(writer, Dset)
        writer.Close()
    End Sub

    'mendapatkan data XML dari dataset ke dalam textbox
    Private Function PrintRows(ByVal dataSet As DataSet) As String
        Dim s As String = ""
        Dim thisTable As DataTable
        For Each thisTable In dataSet.Tables
            Dim row As DataRow
            For Each row In thisTable.Rows
                Dim column As DataColumn
                For Each column In thisTable.Columns
                    s &= row(column) & " "
                Next column
                s &= vbCrLf
            Next row
        Next thisTable
        Return s
    End Function
End Module
