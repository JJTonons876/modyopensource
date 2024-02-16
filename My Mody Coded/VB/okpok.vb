Dim ffmpegPath As String = "ffmpeg.exe"
Dim inputFile As String = "input.mp4"
Dim outputFolder As String = "output"
Dim arguments As String = $"-i ""{inputFile}"" -c copy -map 0:v ""{outputFolder}\video.mp4"" -c copy -map 0:a ""{outputFolder}\audio.mp3"""
Dim startInfo As New ProcessStartInfo With {
    .FileName = ffmpegPath,
    .Arguments = arguments,
    .UseShellExecute = False,
    .RedirectStandardOutput = True,
    .CreateNoWindow = True
}
Dim process As New Process With {
    .StartInfo = startInfo
}
process.Start()
process.WaitForExit()
Dim vegas As New Vegas()
vegas.OpenProject("", OpenProjectOptions.Silent)

Dim videoTrack As VideoTrack = vegas.VideoGroup.AddVideoTrackAt(0, True)
Dim audioTrack As AudioTrack = vegas.AudioGroup.AddAudioTrackAt(0, True)

videoTrack.InsertMedia("output\video.mp4", 0, 0, 0, 0, True)
audioTrack.InsertMedia("output\audio.mp3", 0, 0, 0, 0, True)

vegas.SaveProject("", SaveProjectOptions.Silent)
vegas.CloseProject()
vegas.OpenProject("", OpenProjectOptions.Silent)

Dim videoEvent1 As VideoEvent = vegas.VideoGroup.GetVideoEventAt(0)
Dim videoEvent2 As VideoEvent = vegas.VideoGroup.GetVideoEventAt(1)

Dim transition As VideoTransition = vegas.VideoGroup.AddVideoTransitionAt(videoEvent1.EventID, videoEvent2.EventID, VideoTransitionType.Crossfade)
transition.Duration = 1

vegas.SaveProject("", SaveProjectOptions.Silent)
vegas.CloseProject()
vegas.OpenProject("", OpenProjectOptions.Silent)

vegas.VideoGroup.RenderFile("output\final.mp4", RenderingResolution.HD1080, RenderingQuality.High, RenderingOptions.Silent)

vegas.CloseProject()