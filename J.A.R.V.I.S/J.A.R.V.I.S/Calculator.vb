Module Calculator
    Public Function Calculate(ByVal input As String)
        Dim sum, x, z As Integer
        Dim temp As String
        Dim bodmas(5) As String
        bodmas(0) = "="
        bodmas(1) = "+"
        bodmas(2) = "*"
        bodmas(3) = "/"
        bodmas(4) = "%"
        bodmas(5) = "-"
        'Division
        Dim strlen As Integer = Len(input)
        For y = 1 To strlen
            If "/" = Mid(input, 1, 1) Then
                Console.WriteLine("Sir, I am sorry but you can have a sign without a number before it")
            ElseIf "/" = Mid(input, y, 1) Then
                temp = Mid(input, y, 1)
                If Mid(input, y + 1, 1) = 0 Then


                    'smart answer
                Else
                    Dim a, b As Integer
                    For q = 1 To strlen

                        If Mid(input, q, 1) = "/" And Mid(input, q, 1) <> temp Then
                            a = Mid(input, q, y - q)
                            For p = 1 To strlen
                                If Mid(input, p, 1) = "/" And Mid(input, p, 1) <> temp And Mid(input, p, 1) <> Mid(input, q, 1) Then
                                    b = Mid(input, p, y - p)
                                End If
                            Next

                        End If
                        For n = 1 To strlen
                            If Mid(input, n, 1) = Mid(input, y, 1) Then
                                Dim v As Integer = n - 1
                                Dim m As Integer = strlen - n
                                a = Val(Mid(input, y - v, v))
                                b = Val((Mid(input, y + 1, m)))
                                Mid(input, y - v, v) = " "
                                Mid(input, y + 1, m) = " "
                            End If

                        Next

                    Next

                    Mid(input, y, 1) = divide(a, b).ToString
                End If
            End If


        Next
        For y = 1 To strlen
            'Multiply
            If "*" = Mid(input, 1, 1) Then
                Console.WriteLine("Sir, I am sorry but you can have a sign without a number before it")
            ElseIf Mid(input, y, 1) = "*" Then
                Dim a, b As Integer
                For q = 1 To strlen

                    If Mid(input, q, 1) = "*" And Mid(input, q, 1) <> Mid(input, y, 1) Then
                        a = Mid(input, q, y - q)
                        For p = 1 To strlen
                            If Mid(input, p, 1) = "*" And Mid(input, p, 1) <> Mid(input, y, 1) And Mid(input, p, 1) <> Mid(input, q, 1) Then
                                b = Mid(input, p, y - p)
                            End If
                        Next

                    End If
                    For n = 1 To strlen
                        If Mid(input, n, 1) = Mid(input, y, 1) Then
                            Dim v As Integer = n - 1
                            Dim m As Integer = strlen - n
                            a = Val(Mid(input, y - v, v))
                            b = Val((Mid(input, y + 1, m)))
                            Mid(input, y - v, v) = " "
                            Mid(input, y + 1, m) = " "
                        End If

                    Next

                Next

                Mid(input, y, 1) = multiply(a, b).ToString
            End If
        Next
        'addition
         Dim c As Integer
        If InStr(input, "+") <> 0 Then
            Dim n(2) As Integer
            n(0) = InStr(input, "+")

            For o = 0 To 5
                If InStr(input, bodmas(o)) <> 0 Then

                    c = InStr(input, bodmas(o))

                End If

                If c <> n(0) Then
                    If c > n(0) Then
                        n(1) = Val(Mid(input, n(0), (((c - n(0))))))
                    Else
                        n(2) = Val(Mid(input, n(0), (((n(0) - c) + 1))))
                    End If


                    Console.WriteLine(add(n(1), n(2)))
                End If

            Next




        End If
        'Subtract
        For y = 1 To strlen
            If "-" = Mid(input, 1, 1) Then
                Console.WriteLine("Sir, I am sorry but you can have a sign without a number before it")
            ElseIf Mid(input, y, 1) = "-" Then
                Dim a, b As Integer
                For q = 1 To strlen

                    If Mid(input, q, 1) = "-" And Mid(input, q, 1) <> Mid(input, y, 1) Then
                        a = Mid(input, q, y - q)
                        For p = 1 To strlen
                            If Mid(input, p, 1) = "-" And Mid(input, p, 1) <> Mid(input, y, 1) And Mid(input, p, 1) <> Mid(input, q, 1) Then
                                b = Mid(input, p, y - p)
                            End If
                        Next

                    End If
                    For n = 1 To strlen
                        If Mid(input, n, 1) = Mid(input, y, 1) Then
                            Dim v As Integer = n - 1
                            Dim m As Integer = strlen - n
                            a = Val(Mid(input, y - v, v))
                            b = Val((Mid(input, y + 1, m)))
                            Mid(input, y - v, v) = " "
                            Mid(input, y + 1, m) = " "
                            Mid(input, y, v) = subtract(a, b).ToString
                        End If

                    Next


                Next


            End If
        Next

        Return input
    End Function
    Public Function divide(ByVal x As Integer, ByVal y As Integer)
        Dim sum As Integer
        If y <> 0 Then
            sum = x / y
        Else
            Console.WriteLine("y is 0")
        End If

        Return sum
    End Function
    Public Function multiply(ByVal x As Integer, ByVal y As Integer)
        Dim sum As Integer
        sum = x * y

        Return sum
    End Function
    Public Function add(ByVal x As Integer, ByVal o As Integer)
        Dim sum As Integer = x + o
        Return sum
    End Function
    Public Function subtract(ByVal x As Integer, ByVal y As Integer)
        Dim sum As Integer = x - y
        Return sum
    End Function
End Module
