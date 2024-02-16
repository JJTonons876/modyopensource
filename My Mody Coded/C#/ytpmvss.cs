using System.Diagnostics;
using FFmpeg.AutoGen;

public class YTPMVGenerator
{
    public void ImportVideo(string filePath)
    {
        string ffmpegPath = "ffmpeg.exe";
        string arguments = $"-i \"{filePath}\" -c copy -an -f null -";

        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = ffmpegPath,
            Arguments = arguments,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true
        };

        using (Process process = new Process { StartInfo = startInfo })
        {
            process.Start();
            process.WaitForExit();
        }
    }
}