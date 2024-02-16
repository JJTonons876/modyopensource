Imports System.IO
Imports NAudio.Wave

Module Module1
    Sub Main()
        Dim inputFile1 As String = "C:\path\to\your\soundfile1.wav"
        Dim inputFile2 As String = "C:\path\to\your\soundfile2.wav"
        Dim outputFile As String = "C:\path\to\your\outputfile.wav"

        Using reader1 As New AudioFileReader(inputFile1)
            Using reader2 As New AudioFileReader(inputFile2)
                Using writer As New WaveFileWriter(outputFile, reader1.WaveFormat)
                    Dim buffer1(4095) As Single
                    Dim buffer2(4095) As Single
                    Dim samplesRead1 As Integer
                    Dim samplesRead2 As Integer

                    While True
                        samplesRead1 = reader1.Read(buffer1, 0, buffer1.Length)
                        samplesRead2 = reader2.Read(buffer2, 0, buffer2.Length)

                        If samplesRead1 = 0 Then
                            Exit While
                        End If

                        For i As Integer = 0 To samplesRead1 - 1
                            writer.WriteSample(buffer1(i))
                        Next

                        For i As Integer = 0 To samplesRead2 - 1
                            writer.WriteSample(buffer2(i))
                        Next
                    End While
                End Using
            End Using
        End Using
    End Sub
End Module