Imports System.Speech
Imports System.Threading
Imports System.Globalization
Imports System.IO
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports MySql.Web
Imports System.Data.OleDb
public Class 'window name
Dim WithEvents reco As New Speech.Recognition.SpeechRecognitionEngine
Public Sub 'form name load thingy
reco.SetInputToDefaultAudioDevice()

Dim gram_builder As Recognition.GrammarBuilder = New Recognition.GrammarBuilder
Dim list_choices As New Recognition.Choices

    list_choices.Add("hello") 'choices can be added in a loop


Dim gram As Recognition.Grammar = New Recognition.Grammar(New Recognition.GrammarBuilder(list_choices))
reco.LoadGrammar(gram)
reco.RecognizeAsync()

Public Sub recogcompleted(ByVal sender As Object, e As System.Speech.Recognition.RecognizeCompletedEventArgs) Handles reco.RecognizeCompleted
    reco.RecognizeAsync()
End Sub

Public Sub speechrecognised(ByVal sender As Object, e As System.Speech.Recognition.RecognitionEventArgs) Handles reco.SpeechRecognized
    Dim temp As String = Response_1.Text
    user_input = e.Result.Text
    Input1.Text = user_input

End Sub
