from moviepy.editor import VideoFileClip, concatenate_videoclips
from gtts import gTTS
import random

# Load the video file
video_clip = VideoFileClip("input_video.mp4")

# Create a list of audio and visual effects
audio_effects = [
    gTTS("This is a YouTube Poop!"),
    gTTS("I love Python!"),
    gTTS("Made with Python!"),
]

visual_effects = [
    lambda clip: clip.resize(0.5),
    lambda clip: clip.rotate(45),
    lambda clip: clip.speed(1.5),
]

# Randomize the order of the effects
random.shuffle(audio_effects)
random.shuffle(visual_effects)

# Apply the effects to the video
processed_clips = []
for audio_effect, visual_effect in zip(audio_effects, visual_effects):
    audio_clip = audio_effect.save("temp_audio.mp3")
    visual_clip = visual_effect(video_clip)
    processed_clips.append(visual_clip.set_audio(audio_clip))

# Concatenate the processed clips
final_clip = concatenate_videoclips(processed_clips)

# Save the final YTP
final_clip.write_videofile("output_video.mp4")