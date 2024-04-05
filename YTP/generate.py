from moviepy.editor import VideoFileClip, AudioFileClip, concatenate_videoclips, CompositeVideoClip
from moviepy.audio.fx.all import ear_rape, stutter, time_stretch, pitch_shift

def create_ytp(video_path, audio_path, music_path, photo_path, gif_path, output_path, ear_rape_amount=1, stutter_amount=1, pitch_shift_amount=1, time_stretch_amount=1):
    # Load the video, audio, music, photo, and gif files
    video = VideoFileClip(video_path)
    audio = AudioFileClip(audio_path)
    music = AudioFileClip(music_path)
    photo = ImageClip(photo_path)
    gif = ImageClip(gif_path)

    # Apply the ear rape effect to the audio
    audio_with_ear_rape = ear_rape(audio, ear_rape_amount)

    # Apply the stutter effect to the audio
    audio_with_stutter = stutter(audio_with_ear_rape, stutter_amount)

    # Apply the pitch shift effect to the audio
    audio_with_pitch_shift = pitch_shift(audio_with_stutter, pitch_shift_amount)

    # Apply the time stretch effect to the audio
    audio_with_time_stretch = time_stretch(audio_with_pitch_shift, time_stretch_amount)

    # Mix the audio with the video
    mixed_clip = video.set_audio(audio_with_time_stretch)

    # Add the music to the video
    mixed_clip = concatenate_videoclips([mixed_clip, music.set_duration(mixed_clip.duration)])

    # Add the photo to the video
    photo_clip = photo.set_duration(mixed_clip.duration)
    mixed_clip = CompositeVideoClip([mixed_clip, photo_clip])

    # Add the gif to the video
    gif_clip = gif.set_duration(mixed_clip.duration)
    mixed_clip = CompositeVideoClip([mixed_clip, gif_clip])

    # Add some effects to the video (optional)
    # e.g. add a text clip, rotate the video, etc.

    # Write the final video to a file
    mixed_clip.write_videofile(output_path)

# Usage
create_ytp('video.mp4', 'audio.mp3', 'music.mp3', 'photo.png', 'gif.gif', 'ytp.mp4', ear_rape_amount=1, stutter_amount=1, pitch_shift_amount=1, time_stretch_amount=1)