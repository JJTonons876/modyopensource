Imports Vegas
Imports Filmora

Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    ' Create a new instance of the YTP class
    Dim ytp As New YTP("c:\windows\temp\input.mp4", "c:\windows\temp\output.mp4")

    ' Perform the YTP and MLG
    ytp.PerformYTPAndMLG()
End Sub

Imports Vegas
Imports Filmora

Public Class YTP

    Private ReadOnly _inputFilePath As String
    Private ReadOnly _outputFilePath As String

    Public Sub New(inputFilePath As String, outputFilePath As String)
        _inputFilePath = inputFilePath
        _outputFilePath = outputFilePath
    End Sub

    Public Sub PerformYTPAndMLG()
        ' Create a new instance of the VideoRemixer class
        Dim remixer As New VideoRemixer(_inputFilePath)

        ' Perform the YTP
        remixer.PerformYTP()

        ' Perform the MLG
        remixer.PerformMLG()

        ' Save the output video file
        remixer.Save(_outputFilePath)
    End Sub

End Class

Public Sub PerformYTP()
    ' Load the input video file
    LoadVideo(_inputFilePath)

    ' Add some crazy effects
    AddEffect(EffectType.FlipHorizontal)
    AddEffect(EffectType.FlipVertical)
    AddEffect(EffectType.ColorInvert)
    AddEffect(EffectType.Colorize, Color.Red)
    AddEffect(EffectType.SpeedUp, 2.0)
    AddEffect(EffectType.SpeedDown, 0.5)
End Sub

Public Sub PerformMLG()
    ' Create a new instance of the FilmoraLegacy class
    Dim filmora As New FilmoraLegacy(_inputFilePath)

    ' Add some MLG effects
    filmora.AddEffect(EffectType.GreenScreen, Color.Green)
    filmora.AddEffect(EffectType.SlowMotion, 0.5)
    filmora.AddEffect(EffectType.FastMotion, 2.0)
    filmora.AddEffect(EffectType.ColorCorrection, Color.Yellow)
End Sub

