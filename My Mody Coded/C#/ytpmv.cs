using System;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Load the video file
        var video = "input_video.mp4";

        // Load the audio file
        var audio = "input_audio.mp3";

        // Create a list of audio effects
        var audioEffects = new[]
        {
            "atempo=1.2",
            "atempo=0.8",
            "asetrate=44100*0.8",
            "asetrate=44100*1.25",
            "volume=0.5",
            "volume=2",
        };

        // Create a list of visual effects
        var visualEffects = new[]
        {
            "scale=w=iw/2:h=ih/2",
            "rotate=45",
            "setpts=PTS-STARTPTS",
            "setpts=PTS/1.5",
        };

        // Randomize the order of the effects
        var random = new Random();
        var randomizedAudioEffects = audioEffects.OrderBy(x => random.Next()).ToList();
        var randomizedVisualEffects = visualEffects.OrderBy(x => random.Next()).ToList();

        // Apply the effects to the audio and video
        var processedAudio = ApplyAudioEffects(audio, randomizedAudioEffects);
        var processedVideo = ApplyVisualEffects(video, randomizedVisualEffects);

        // Combine the processed audio and video
        CombineAudioAndVideo(processedAudio, processedVideo, "output_video.mp4");
    }

    static string ApplyAudioEffects(string input, IEnumerable<string> effects)
    {
        var command = $"ffmpeg -i {input} -filter_complex \"";
        foreach (var effect in effects)
        {
            command += $"{effect},";
        }
        command = command.TrimEnd(',') + "\" output.mp3";
        Process.Start(command).WaitForExit();
        return "output.mp3";
    }

    static string ApplyVisualEffects(string input, IEnumerable<string> effects)
    {
        var command = $"ffmpeg -i {input} -filter_complex \"";
        foreach (var effect in effects)
        {
            command += $"{effect},";
        }
        command = command.TrimEnd(',') + "\" output.mp4";
        Process.Start(command).WaitForExit();
        return "output.mp4";
    }

    static void CombineAudioAndVideo(string audio, string video, string output)
    {
        var command = $"ffmpeg -i {video} -i {audio} -c:v copy -c:a aac -strict experimental {output}";
        Process.Start(command).WaitForExit();
    }
}