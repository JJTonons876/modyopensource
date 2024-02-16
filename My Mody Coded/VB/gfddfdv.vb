Imports System.Diagnostics
Imports FFmpeg.AutoGen

Public Class YTPMVGenerator

    Public Sub ExtractStreams(inputFile As String, outputFolder As String)
        Dim ffmpegPath As String = "ffmpeg.exe"
        Dim arguments As String = $"-i ""{inputFile}"" -c copy -map 0:v ""{outputFolder}\video.mp4"" -c copy -map 0:a ""{outputFolder}\audio.mp3"""

        Dim startInfo As New ProcessStartInfo
        With startInfo
            .FileName = ffmpegPath
            .Arguments = arguments
            .UseShellExecute = False
            .RedirectStandardOutput = True
            .CreateNoWindow = True
        End With

        Using process As New Process With {.StartInfo = startInfo}
            process.Start()
            process.WaitForExit()
        End Using
    End Sub

End Class

Imports Sony.Vegas
Imports Sony.Vegas.MediaDataObjects

Public Class YTPMVGenerator

    Public Sub CreateTimeline(videoFile As String, audioFile As String)
        Dim vegas As New Vegas()
        vegas.OpenProject("", OpenProjectOptions.Silent)

        Dim videoTrack As VideoTrack = vegas.VideoGroup.AddVideoTrackAt(0, True)
        Dim audioTrack As AudioTrack = vegas.AudioGroup.AddAudioTrackAt(0, True)

        videoTrack.InsertMedia(videoFile, 0, 0, 0, 0, True)
        audioTrack.InsertMedia(audioFile, 0, 0, 0, 0, True)

        vegas.SaveProject("", SaveProjectOptions.Silent)
        vegas.CloseProject()
    End Sub

End Class

Imports Sony.Vegas
Imports Sony.Vegas.MediaDataObjects

Public Class YTPMVGenerator

    Public Sub ApplyCrossfade(projectFile As String)
        Dim vegas As New Vegas()
        vegas.OpenProject(projectFile, OpenProjectOptions.Silent)

        Dim videoEvent1 As VideoEvent = vegas.VideoGroup.GetVideoEventAt(0)
        Dim videoEvent2 As VideoEvent = vegas.VideoGroup.GetVideoEventAt(1)

        Dim transition As VideoTransition = vegas.VideoGroup.AddVideoTransitionAt(videoEvent1.EventID, videoEvent2.EventID, VideoTransitionType.Crossfade)
        transition.Duration = 1

        vegas.SaveProject(projectFile, SaveProjectOptions.Silent)
        vegas.CloseProject()
    End Sub

End Class

Imports Sony.Vegas
Imports Sony.Vegas.MediaDataObjects

Public Class YTPMVGenerator

    Public Sub Add3DCubeEffect(projectFile As String, effectName As String)
        Dim vegas As New Vegas()
        vegas.OpenProject(projectFile, OpenProjectOptions.Silent)

        Dim videoEvent As VideoEvent = vegas.VideoGroup.GetVideoEventAt(0)

        Dim effect As VideoEventMediaItem = videoEvent.MediaItem.AddVideoEventMediaItem()
        effect.VideoStream = New FileVideoStream(effectName)

        vegas.CloseProject()
    End Sub

End Class

Imports Sony.Vegas

Public Class YTPMVGenerator

    Public Sub ExportVideo(projectFile As String, outputFile As String)
        Dim vegas As New Vegas()
        vegas.OpenProject(projectFile, OpenProjectOptions.Silent)

        vegas.VideoGroup.RenderFile(outputFile, RenderingResolution.HD1080, RenderingQuality.High, RenderingOptions.Silent)

        vegas.CloseProject()
    End Sub

End Class

