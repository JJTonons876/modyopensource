from moviepy.editor import VideoFileClip, AudioFileClip, concatenate_videoclips, CompositeVideoClip
from moviepy.audio.fx.all import pitch_shift

def create_ytpmv(video_path, audio_path, output_path, pitch_shift_amount=4):
    # Load the video and audio files
    video = VideoFileClip(video_path)
    audio = AudioFileClip(audio_path)

    # Apply the pitch effect to the audio
    audio_with_pitch = pitch_shift(audio, pitch_shift_amount)

    # Mix the audio with the video
    mixed_clip = video.set_audio(audio_with_pitch)

    # Add some effects to the video (optional)
    # e.g. add a text clip, rotate the video, etc.

    # Write the final video to a file
    mixed_clip.write_videofile(output_path)

# Usage
create_ytpmv('video.mp4', 'audio.mp3', 'ytpmv.mp4', pitch_shift_amount=4)