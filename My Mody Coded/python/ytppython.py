import moviepy.editor as mpy

# Set up the video and image and audio files
video = ["./testsources.mp4", "./testsources2.mp4"]  # List of videos to concatenate
gif = './testsources.gif'                     # Image file for overlaying on top
images = ["./image1.png", "./image2.png", "./image3.png"]
audio_file = "./audio.mp3"

# Create a list of ImageClips
image_clips = [mpy.ImageClip(img).set_duration(1) for img in images]

# Create a concatenated clip from the image clips
video_clip = mpy.concatenate_videoclips(image_clips)

# Create a concatenated clip from the video clips
video_clip = mpy.concatenate_videoclips(video_clip)

# Create An TextClip with a tille text
text_clip = mpy.TextClip("Hello, world!", fontsize=50, color='white')
text_clip = text_clip.set_duration(5)
final_clip = mpy.concatenate_videoclips([video_clip, text_clip])

# Create an AudioClip from the audio file
audio_clip = mpy.AudioFileClip(audio_file)

# Combine the video and audio clips
final_clip = video_clip.set_audio(audio_clip)

# Save the final clip as a video file
final_clip.write_videofile("output.mp4", fps=24)