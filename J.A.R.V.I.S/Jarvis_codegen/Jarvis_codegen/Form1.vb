Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim x As Integer = NumericUpDown1.Value
        For i = 0 To x
            Console.Write("voice_choices(" & i & "),")
        Next

    End Sub
End Class
