using NAudio.Wave;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Load the audio file
        var reader = new AudioFileReader("input_sound.wav");

        // Create a list of audio effects
        var audioEffects = new[]
        {
            (AudioEffect)CreateSpeedUpEffect(1.2),
            (AudioEffect)CreateSpeedDownEffect(0.8),
            (AudioEffect)CreateChangePitchEffect(12),
            (AudioEffect)CreateChangePitchEffect(-12),
            (AudioEffect)CreateChangeVolumeEffect(0.5),
            (AudioEffect)CreateChangeVolumeEffect(2),
        };

        // Randomize the order of the effects
        var random = new Random();
        var randomizedEffects = audioEffects.OrderBy(x => random.Next()).ToList();

        // Apply the effects to the audio
        var processedAudio = ApplyEffects(reader, randomizedEffects);

        // Save the final Windows remix sound
        WaveFileWriter.CreateWaveFile("output_sound.wav", processedAudio);
    }

    static IWaveProvider CreateSpeedUpEffect(double factor)
    {
        return new MediaFoundationResampler(new MediaFoundationReader("input_sound.wav"), new WaveFormat(44100, 16, 2), ResamplerQuality.High);
    }

    static IWaveProvider CreateSpeedDownEffect(double factor)
    {
        return new MediaFoundationResampler(new MediaFoundationReader("input_sound.wav"), new WaveFormat(22050, 16, 2), ResamplerQuality.High);
    }

    static IWaveProvider CreateChangePitchEffect(int semitones)
    {
        return new MediaFoundationMixer(new MediaFoundationReader("input_sound.wav"), new MediaFoundationReader("input_sound.wav"), new MediaFoundationTransform(MediaFoundationTransformFlags.PitchShift, semitones));
    }

    static IWaveProvider CreateChangeVolumeEffect(double volume)
    {
        return new MediaFoundationVolumeMeter(new MediaFoundationReader("input_sound.wav"), volume);
    }

    static IWaveProvider ApplyEffects(IWaveProvider input, IEnumerable<AudioEffect> effects)
    {
        var output = input;
        foreach (var effect in effects)
        {
            output = effect.ApplyEffect(output);
        }
        return output;
    }

    delegate IWaveProvider AudioEffect(IWaveProvider input);
}