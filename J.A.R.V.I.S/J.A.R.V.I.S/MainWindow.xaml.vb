Imports System.Speech
Imports System.Threading
Imports System.Globalization
Imports System.IO
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports MySql.Web
Imports System.Data.OleDb



Public Class MainWindow
    'Old Voice Gen
    'Public Event SpeachRecignized As EventHandler(Of SpeechRecognizedEventArgs)

    'Dim a As New SpeechRecognizer
    'Dim b As Grammar
    'Dim c As String() = New String() {"en-Us"}
    Dim user_input As String
    Dim conn As New MySqlConnection
    Dim WithEvents reco As New Speech.Recognition.SpeechRecognitionEngine
    Dim convo_constring As OleDbCommand = New OleDbCommand
    Dim convo_datareader As OleDbDataReader
    Dim convo_connect As OleDbConnection = New OleDbConnection
    Dim voice_choices() As String
    Dim name As String




    Private Sub MainWindow_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        convo_connect.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=./Convo.mdb"
        Try




            'Connect("rootedrrouteless.net", "rootesxe_jarvis", "jarvis", "rootesxe_Jarvis_Convo")
            'Dim myCommand As New MySqlCommand
            'Dim myAdapter As New MySqlDataAdapter
            'Dim myData As MySqlDataReader
            'Dim SQL As String
            'Dim Noofrows As Integer

            'SQL = "Select Question FROM Ques/Resp"

            'myCommand.Connection = conn
            'myCommand.CommandText = SQL
            'myAdapter.SelectCommand = myCommand
            'Try
            '    myData = myCommand.ExecuteReader()
            '    myData.Read()
            '    Noofrows = myData.FieldCount


            '  Catch ex As Exception
            'Dim talk As Object
            'MsgBox("Sir, A fatal Error has occured limiting my functions And coversational skill. Please Check the log File For further details.")
            '' error_log(ex, "An Error has occured establishing connecting To the conversation data base , please check your internet And rety In sometime.")
            'talk = CreateObject("SAPI.spvoice")
            'talk.speak("Sir, A fatal Error has occured limiting my functions And coversational skill. Please Check the log File For further details.")
            '' End Try
            Try
                reco.SetInputToDefaultAudioDevice()

            Catch ex As Exception
                Dim talk As Object
                MsgBox("An Error has occured please the log file To check what it Is")
                error_log(ex, "Please See To it that your microphone Is connected")
                talk = CreateObject("SAPI.spvoice")
                talk.speak("An Error has occured please open the log file To check what it Is")
            End Try
            Dim noofvc As Integer = 14
            convo_connect.Open()
            convo_constring = New OleDbCommand("Select Question,Question_2 FROM QuesResp")
            convo_constring.Connection = convo_connect
            convo_datareader = convo_constring.ExecuteReader()
            Dim x = 14
            Do While convo_datareader.HasRows = True

                ReDim voice_choices(noofvc)
                voice_choices(x) = convo_datareader(1).ToString()
                noofvc += 1
                x += 1
                convo_datareader.NextResult()
            Loop



            ReDim voice_choices(noofvc)
            call_vc()
            While convo_datareader.Read()



                For n = 13 To noofvc
                    Dim x As Integer = convo_datareader.FieldCount - 1
                    Dim y As String


                    voice_choices(n) = convo_datareader(x).ToString
                    convo_datareader.NextResult()
                Next

            End While
            convo_datareader.Close()
            convo_connect.Close()



            '   Dim choices() As String = New String() {"jarvis you up"}

            Dim gram_builder As Recognition.GrammarBuilder = New Recognition.GrammarBuilder
            Dim list_choices As New Recognition.Choices
            For o = 0 To noofvc
                list_choices.Add(voice_choices(o))
                gram_builder.Append(voice_choices(o))
            Next






            Dim gram As Recognition.Grammar = New Recognition.Grammar(New Recognition.GrammarBuilder(list_choices))




            reco.LoadGrammar(gram)
            reco.RecognizeAsync()
            ' Code for open external file

            '    Dim p As System.Diagnostics.Process
            '    p.StartInfo.FileName = "sapisvr.exe"
            '    p.Start()



            Dim sapi As Object
            sapi = CreateObject("SAPI.spvoice")
            sapi.speak(Response_1.Text)
        Catch ex As Exception
            MsgBox("An Error has occured please open the log file To check what it Is")

            error_log(ex, "An Error had occured In intiallisation Of Project Jarvis, Please Check your internet And your Microphone")
            Dim sapi As Object
            sapi = CreateObject("SAPI.spvoice")
            sapi.speak("An Error has occured please open the log file To check what it Is")
        End Try
    End Sub
    Public Sub speechrecognised(ByVal sender As Object, e As System.Speech.Recognition.RecognitionEventArgs) Handles reco.SpeechRecognized
        Dim temp As String = Response_1.Text
        user_input = e.Result.Text
        Input1.Text = user_input
        Try
            convo_connect.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=./Convo.mdb"
            convo_connect.Open()
            Console.WriteLine("  ")
            Console.WriteLine(convo_connect.State.ToString)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        convo_constring = New OleDbCommand("Select Answer,Answer2,Answer3 FROM QuesResp WHERE Question='" & user_input & "' OR Question_2='" & user_input & "'")

        convo_constring.Connection = convo_connect

        check(user_input)

        If Response_1.Text <> temp Then
            Dim sapi As Object
            sapi = CreateObject("SAPI.spvoice")
            sapi.speak(Response_1.Text)

        End If
        convo_connect.Close()
    End Sub
    Public Sub recogcompleted(ByVal sender As Object, e As System.Speech.Recognition.RecognizeCompletedEventArgs) Handles reco.RecognizeCompleted
        reco.RecognizeAsync()
    End Sub

    Public Sub check(ByVal input As String)
        Dim temp As String = input
        input = LCase(temp)
        Dim calling_card As String
        calling_card = "jarvis you up"
        'And priotity 0
        'Caculate priotity 1
        Dim bodmas(5) As String
        bodmas(0) = "="
        bodmas(1) = "+"
        bodmas(2) = "*"
        bodmas(3) = "/"
        bodmas(4) = "%"
        bodmas(5) = "-"
        Dim strln As Integer
        strln = Len(input)
        For x = 0 To 5

            For y = 1 To strln
                If bodmas(x) = Mid(input, y, 1) Then
                    Dim sum As Integer = New_Calculator.Calc(input)
                    Console.WriteLine("The answer is " & sum)
                    Response_1.Text = "It is a number ...   ...But on a more serious note it is...." & sum & " .. Hopefully I didn't make any mistakes, Sir!"
                End If
            Next
        Next
        'time

        'Timer?/Stopwacth p2
        'timer
        If InStr(input, "timer") <> 0 Then
            If InStr(input, "Set") <> 0 Then
            End If
            Dim start_time, start_hour As Integer
            start_time = TimeOfDay.Minute
            start_hour = TimeOfDay.Hour
            Dim o, p, countdown As Integer
            If InStr(input, "For") <> 0 Then
                o = InStrRev(input, "For") + 3
            Else
                o = InStrRev(input, "timer") + 5
            End If
            If InStr(input, "minutes") <> 0 Then
                p = InStr(input, "minutes") - 1
            Else
                p = InStr(input, "min") - 1
            End If
            Dim l, n As String

            l = Mid(input, o, p - o)
            n = LTrim(l)
            l = RTrim(n)
            countdown = Val(l)
            While countdown <> 0
                timer_expander.Content = countdown
                For z = 0 To 1
                    If start_time + z = TimeOfDay.Minute Then
                        countdown -= z
                        timer_expander.Content = countdown

                    End If
                Next
            End While
        End If
        If InStr(input, "time") <> 0 And InStr(input, "timer") = 0 Then
            If InStr(input, "what is") <> 0 Then
                Response_1.Text = "The time Is " & TimeOfDay

            End If
        End If
        'Stopwatch

        'Alarm priotity 3
        'alarm writing
        If InStr(input, "alarm") <> 0 Then
            If InStr(input, "Set") <> 0 Then
                Dim output As New StreamWriter(".\alarm_time.txt")
                output.WriteLine("ThisisJarvis")
                output.Close()
                Response_1.Text = "Sir , your Alarm has been Set. I know you wil ignore it but still.."

                timer_expander.Header = "Alarm"
                timer_expander.Content = "Alarm has been Set For " ' & variable
            End If
        End If
        'Search priotity 4
        'Javis you up? priotity 5 like Hey siri or Okay Google Calling on the voice recog
        If InStr(input, calling_card) <> 0 Then


            Dim x, welcome As String
            x = "Sir" ' get from database

            welcome = "For you " & x & " Always"


            Response_1.Text = welcome
            Exit Sub


        End If
        'Hello Sir !                                                                                                       Misplace anything today?                                                                               Today isn't a blue moon is it? So What did you lose today?
        'Conversation skil lowest priotity

        If InStr(input, "close") <> 0 Then

            Response_1.Text = "Wait! Sir, What have I done wrong? Please tell Me.                              Don't Shut me down please!At least tell me why?"
            Dim sapi As Object
            sapi = CreateObject("SAPI.spvoice")
            sapi.speak("Wait! Sir, What have I done wrong? Please tell Me.                              Don't Shut me down please!At least tell me why?")
            Dim time As Integer
            time = TimeOfDay.Minute
            If Response_1.Text = "Wait! Sir, What have I done wrong? Please tell Me.                              Don't Shut me down please!At least tell me why?" Then
                While time + 1 <> TimeOfDay.Minute
                    Console.WriteLine("Sorry!")
                End While
                If time + 1 >= TimeOfDay.Minute Then
                    sapi = CreateObject("SAPI.spvoice")
                    sapi.speak("Sorry again Sir!")
                    MsgBox("Sorry Again Sir!")

                    Response_1.Text = "Sorry again Sir!"
                    End
                End If
            End If
        End If
        If InStr(input, "open log") <> 0 Then
            ' Code for open external file
            Input1.Text = "open log file"
            Response_1.Text = "Okay , Sir! I will do that or you."
            Dim p As New System.Diagnostics.Process
            p.StartInfo.FileName = "error_log.txt"
            p.Start()

        End If


        If convo_connect.State.ToString <> "Open" Then
            convo_connect.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source=.\Convo.mdb"
            convo_constring = New OleDbCommand("Select Answer,Answer2,Answer3 FROM QuesResp WHERE Question='" & input & "' OR Question_2='" & input & "'")

            convo_constring.Connection = convo_connect

            convo_connect.Open()
        End If
        convo_datareader = convo_constring.ExecuteReader()

        If convo_datareader.HasRows Then
            Dim intn, intx As Integer
            intn = convo_datareader.FieldCount
            Dim resp(intn) As String
            Console.WriteLine(intn)

            While convo_datareader.Read()
                For intx = 0 To (intn - 1)
                    resp(intx) = convo_datareader(intx).ToString
                    Console.WriteLine(resp(intx))

                Next
            End While

            Input1.Text = input
            Randomize()
            Select Case Rnd()
                Case 0 To 0.3
                    Response_1.Text = resp(1)
                Case 0.3 To 0.6
                    Response_1.Text = resp(0)
                Case 0.6 To 1
                    Response_1.Text = resp(2)
            End Select
        End If
        convo_connect.Close()
    End Sub

    Private Sub Edit_Click(sender As Object, e As RoutedEventArgs) Handles Edit.Click
        Dim x As String = InputBox("Text")
        Input1.Text = x
        check(x)
        Dim sapi As Object
        sapi = CreateObject("SAPI.spvoice")
        sapi.speak(Response_1.Text)
        Input1.IsEnabled = True
        Input1.ToolTip = "Sir , As i probably interpreted what you said incorrectly you can edit it. Sorry For the inconvinence ."
    End Sub
    Private Function Connect(ByVal server As String, ByRef user As String, ByRef password As String, ByRef database As String)
        ' Connection string with MySQL Info
        conn.ConnectionString = "Server=" + server + ";" _
            & "Database=rootesxe_Jarvis_Convo;" _
        & "Uid=" + user + ";" _
        & "Pwd=" + password + ";"


        ' Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword
        Console.Write(conn.ConnectionString.ToString)
        Try
            conn.Open()
            Return True
        Catch ex As MySqlException
            Return MsgBox(ex.Message)
        End Try
    End Function
    Public Sub call_vc()
        name = "jarvis"
        'voice_choices(0) = name
        'voice_choices(1) = "hey"
        'voice_choices(2) = "set"
        'voice_choices(3) = "sup"
        'voice_choices(4) = "time"
        'voice_choices(5) = "is"
        'voice_choices(6) = "you"
        'voice_choices(7) = "up"
        'voice_choices(8) = "what"
        'voice_choices(9) = "why"
        'voice_choices(10) = "when"
        'voice_choices(11) = "for"
        'voice_choices(12) = "timer"
        'voice_choices(13) = "alarm"
        'voice_choices(14) = "close"
        'voice_choices(15) = "good"
        'voice_choices(16) = "night"
        'voice_choices(17) = "open"
        'voice_choices(18) = "log"
        'voice_choices(19) = "bye"
        'voice_choices(20) = "the"
        'voice_choices(21) = "both"
        'voice_choices(22) = "sleep"
        'voice_choices(23) = "and"
        'voice_choices(24) = "or"
        'voice_choices(25) = "me"
        'voice_choices(26) = "to"
        'voice_choices(27) = "got"
        'voice_choices(28) = "go"

        voice_choices(0) = "jarvis you up"
        voice_choices(1) = "Set timer For"
        voice_choices(2) = "go To sleep j"
        voice_choices(3) = "hey"
        voice_choices(4) = "what is the time"
        voice_choices(5) = "close"
        voice_choices(6) = "good night"
        voice_choices(7) = "hello"
        voice_choices(8) = "Set alarm For"
        voice_choices(9) = "who is pranav"
        voice_choices(10) = "bye"
        voice_choices(11) = "open log"
        voice_choices(12) = "Sup"
    End Sub
End Class

