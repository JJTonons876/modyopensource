from moviepy.editor import VideoFileClip, concatenate_videoclips
from pydub import AudioSegment
import random

# Load the video file
video_clip = VideoFileClip("input_video.mp4")

# Load the audio file
audio_clip = AudioSegment.from_file("input_audio.mp3")

# Create a list of audio and visual effects
audio_effects = [
    lambda clip: clip.speedup(1.2),
    lambda clip: clip.speeddown(0.8),
    lambda clip: clip.reverse(),
]

visual_effects = [
    lambda clip: clip.resize(0.5),
    lambda clip: clip.rotate(45),
    lambda clip: clip.speed(1.5),
]

# Randomize the order of the effects
random.shuffle(audio_effects)
random.shuffle(visual_effects)

# Apply the effects to the audio and video
processed_audio = audio_clip
processed_clips = []
for audio_effect, visual_effect in zip(audio_effects, visual_effects):
    audio_clip = audio_effect(processed_audio)
    visual_clip = visual_effect(video_clip)
    processed_audio = audio_clip
    processed_clips.append(visual_clip)

# Concatenate the processed clips
final_clip = concatenate_videoclips(processed_clips)

# Combine the processed audio and video
final_clip = final_clip.set_audio(processed_audio)

# Add a fast-paced transition effect
final_clip = final_clip.fx(vfx.speedx, 1.5)

# Save the final MLG video
final_clip.write_videofile("output_video.mp4")