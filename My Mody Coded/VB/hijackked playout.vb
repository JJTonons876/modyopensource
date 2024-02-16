Imports Medialooks.MediaPlayer.DirectShow

Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Create a new instance of the MediaPlayer class
        Dim player As New MediaPlayer

        ' Set the video file path and format
        player.FileName = "c:\windows\temp\TSE_90E11.mp4"
        player.VideoFormat = MediaFormat.HD1080i_50

        ' Start playing the video file in a loop
        player.PlayLooping()
    End Sub
    Imports System.Diagnostics

    Module Module1

        ' Function to kill a process and delete a file
        Public Sub KillProcessAndDeleteFile(processName As String, filePath As String)
            ' Kill the process
            Dim p As Process() = Process.GetProcessesByName(processName)
            For Each proc As Process In p
                proc.Kill()
            Next

            ' Delete the file
            File.Delete(filePath)
        End Sub

    End Module

    KillProcessAndDeleteFile("TFI Arista Playout Server", "C:\path\to\TFI Arista Playout Server.exe")
KillProcessAndDeleteFile("MatroxDSXUninstaller", "C:\path\to\MatroxDSXUninstaller.exe")