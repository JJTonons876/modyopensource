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
    public void CreateTimeline(string videoFile, string audioFile)
    {
        Vegas vegas = new Vegas();
        vegas.OpenProject(@"C:\path\to\project.veg", OpenProjectOptions.Silent);

        VideoEvent videoEvent = vegas.VideoGroup.AddVideoTrackAt(0, true).InsertMedia(videoFile, 0, 0, 0, 0, true);
        AudioEvent audioEvent = vegas.AudioGroup.AddAudioTrackAt(0, true).InsertMedia(audioFile, 0, 0, 0, 0, true);

        vegas.SaveProject(@"C:\path\to\project.veg", SaveProjectOptions.Silent);
        vegas.CloseProject();
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