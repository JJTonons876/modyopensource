from pydub import AudioSegment
import random

# Load the audio file
audio_clip = AudioSegment.from_file("input_song.mp3")

# Create a list of audio effects
audio_effects = [
    lambda clip: clip.speedup(1.2),
    lambda clip: clip.speeddown(0.8),
    lambda clip: clip.change_pitch(12),
    lambda clip: clip.change_pitch(-12),
    lambda clip: clip.set_frame_rate(44100),
    lambda clip: clip.set_frame_rate(22050),
    lambda clip: clip.fade_in(500),
    lambda clip: clip.fade_out(500),
]

# Randomize the order of the effects
random.shuffle(audio_effects)

# Apply the effects to the audio
processed_audio = audio_clip
for audio_effect in audio_effects:
    processed_audio = audio_effect(processed_audio)

# Save the final LHS remix
processed_audio.export("output_song.mp3", format="mp3")