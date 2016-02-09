Imports System.Speech
Imports System.Threading
Imports System.Globalization
Imports System.IO
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports MySql.Web
Module external_output

    Public Sub error_log(ByVal ex As Exception, ByVal text As String)
        Dim output As New StreamWriter(".\error_log.txt")
        Dim date_curr As String = Date.Now.ToString
        output.WriteLine(date_curr & text & ex.ToString)
        output.Close()
    End Sub
End Module
