import moviepy.editor as mpy

# Set up the image and audio files
images = ["./image1.png", "./image2.png", "./image3.png"]
audio_file = "./audio.mp3"

# Create a list of ImageClips
image_clips = [mpy.ImageClip(img).set_duration(1) for img in images]

# Create a concatenated clip from the image clips
video_clip = mpy.concatenate_videoclips(image_clips)

# Create an AudioClip from the audio file
audio_clip = mpy.AudioFileClip(audio_file)

# Combine the video and audio clips
final_clip = video_clip.set_audio(audio_clip)

# Save the final clip as a video file
final_clip.write_videofile("output.mp4", fps=24)