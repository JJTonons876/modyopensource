using System.Diagnostics;
using FFmpeg.AutoGen;

public class YTPGenerator
{
    public void ExtractStreams(string inputFile, string outputFolder)
    {
        string ffmpegPath = "ffmpeg.exe";
        string arguments = $"-i \"{inputFile}\" -c copy -map 0:v \"{outputFolder}\\video.mp4\" -c copy -map 0:a \"{outputFolder}\\audio.mp3\"";

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

using Sony.Vegas;
using Sony.Vegas.MediaDataObjects;

public class YTPGenerator
{
    public void ApplyCrossfade(string projectFile)
    {
        Vegas vegas = new Vegas();
        vegas.OpenProject(projectFile, OpenProjectOptions.Silent);

        VideoEvent videoEvent1 = vegas.VideoGroup.GetVideoEventAt(0);
        VideoEvent videoEvent2 = vegas.VideoGroup.GetVideoEventAt(1);

        VideoTransition transition = vegas.VideoGroup.AddVideoTransitionAt(videoEvent1.EventID, videoEvent2.EventID, VideoTransitionType.Crossfade);
        transition.Duration = 1;

        vegas.SaveProject(projectFile, SaveProjectOptions.Silent);
        vegas.CloseProject();
    }
}

using Sony.Vegas;

public class YTPGenerator
{
    public void ExportVideo(string projectFile, string outputFile)
    {
        Vegas vegas = new Vegas();
        vegas.OpenProject(projectFile, OpenProjectOptions.Silent);

        vegas.VideoGroup.RenderFile(outputFile, RenderingResolution.HD1080, RenderingQuality.High, RenderingOptions.Silent);

        vegas.CloseProject();
    }
}

