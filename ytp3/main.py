from moviepy.editor import VideoFileClip, AudioFileClip, ImageSequenceClip, concatenate_videoclips
import random
import os

# Function to generate ear rape effect
def ear_rape(audio):
    audio = audio.set_freq_and_gain(2000, 10)
    return audio

# Function to generate stutter loop effect
def stutter_loop(video, audio, duration):
    stutter_clips = []
    for i in range(0, int(duration), int(duration/10)):
        stutter_clips.append(video.subclip(i, i+duration/10))
        stutter_clips.append(audio.subclip(i, i+duration/10))
    return concatenate_videoclips(stutter_clips)

# Function to generate sentence mixing effect
def sentence_mixing(audio1, audio2):
    audio1 = audio1.set_start(0)
    audio2 = audio2.set_start(audio1.duration)
    return concatenate_audioclips([audio1, audio2])

# Function to generate spadinner effect
def spadinner(video, audio, duration):
    spadinner_clips = []
    for i in range(0, int(duration), int(duration/10)):
        spadinner_clips.append(video.subclip(i, i+duration/10).fx(vfx.accel_decel, 0.5))
        spadinner_clips.append(audio.subclip(i, i+duration/10).fx(afx.audio_fadein, 0.5))
    return concatenate_videoclips(spadinner_clips)

# Function to generate special effect
def special_effect(video):
    return video.fx(vfx.colorx, 2)

# Function to generate YTP helper
def ytp_helper(video, audio, duration):
    ytp_helper_clips = []
    for i in range(0, int(duration), int(duration/10)):
        ytp_helper_clips.append(video.subclip(i, i+duration/10).resize(0.5))
        ytp_helper_clips.append(audio.subclip(i, i+duration/10).set_volume(0.5))
    return concatenate_videoclips(ytp_helper_clips)

# Browse video source
video_source = VideoFileClip("video_source.mp4")

# Browse audio source
audio_source = AudioFileClip("audio_source.mp3")

# Browse music source
music_source = AudioFileClip("music_source.mp3")

# Browse photo source
photo_source = ImageSequenceClip("photo_source/*.png", fps=24)

# Browse GIF source
gif_source = VideoFileClip("gif_source.gif")

# Browse MLG source
mlg_source = VideoFileClip("mlg_source.mp4")

# Generate ear rape effect
ear_rape_audio = ear_rape(audio_source)

# Generate stutter loop effect
stutter_loop_video = stutter_loop(video_source, audio_source, 10)

# Generate sentence mixing effect
sentence_mixing_audio = sentence_mixing(audio_source, music_source)

# Generate spadinner effect
spadinner_video = spadinner(video_source, audio_source, 10)

# Generate special effect
special_effect_video = special_effect(video_source)

# Generate YTP helper
ytp_helper_video = ytp_helper(video_source, audio_source, 10)

# Combine all clips
final_clip = concatenate_videoclips([ear_rape_audio, stutter_loop_video, sentence_mixing_audio, spadinner_video, special_effect_video, ytp_helper_video])

# Write final clip to file
final_clip.write_videofile("final_output.mp4")