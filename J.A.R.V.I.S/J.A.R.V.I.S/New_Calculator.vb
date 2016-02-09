Module New_Calculator
    Public Function Calc(ByVal input As String)
        Dim bodmas(5) As String
        bodmas(0) = "="
        bodmas(1) = "+"
        bodmas(2) = "*"
        bodmas(3) = "/"
        bodmas(4) = "%"
        bodmas(5) = "-"
        Dim copy_input As String = input
        For inti = 0 To 5
            If InStr(input, bodmas(inti)) <> 0 Then
                Dim sign_loc As Integer = InStr(input, bodmas(inti))
                Dim inty As Integer = sign_loc - 1
                Dim intz As Integer = sign_loc + 1
                Dim number1(), number2() As Integer
                Dim inlen As Integer = Len(input)
                ReDim number1(inlen)
                ReDim number2(inlen)
                Dim intx(1) As Integer
                intx(0) = 0
                intx(1) = 1
                While inty > 0

                    If IsNumeric(Mid(input, inty, 1)) = True Then
                        number1(intx(0)) = Mid(input, inty, 1)

                        inty -= 1
                        intx(0) += 1


                    End If
                End While
                While inlen >= intz
                    If intz <> sign_loc Then
                        If IsNumeric(Mid(input, intz, 1)) Then
                            number2(intx(1)) = Mid(input, intz, 1)

                            intz -= 1
                            intx(1) += 1

                        End If
                    Else
                        Exit While
                    End If

                End While
                Dim final_number1, final_number2 As String
                For Each number As String In number1

                    final_number1 = number + final_number1
                Next
                For Each number As String In number2
                    final_number2 = number + final_number2
                Next
                Dim operat As String = Mid(input, sign_loc, 1)
                Dim sum As Integer
                Select Case operat
                    Case "+"
                        sum = Val(final_number1) + Val(final_number2)
                    Case "-"
                        sum = Val(final_number1) - Val(final_number2)
                    Case "*"
                        sum = Val(final_number1) * Val(final_number2)
                    Case "/"
                        sum = (1 / Val(final_number1)) * (1 / Val(final_number2))

                End Select
                Console.WriteLine(sum)
                Return sum
            End If

        Next
    End Function
End Module
