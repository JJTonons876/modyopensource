import tkinter as tk
from tkinter import filedialog

def select_video():
    video_path = filedialog.askopenfilename()
    print(f"Video file selected: {video_path}")

def select_audio():
    audio_path = filedialog.askopenfilename()
    print(f"Audio file selected: {audio_path}")

def select_music():
    music_path = filedialog.askopenfilename()
    print(f"Music file selected: {music_path}")

def select_photo():
    photo_path = filedialog.askopenfilename()
    print(f"Photo file selected: {photo_path}")

def select_gif():
    gif_path = filedialog.askopenfilename()
    print(f"GIF file selected: {gif_path}")

def create_ytp():
    video_path = entry_video.get()
    audio_path = entry_audio.get()
    music_path = entry_music.get()
    photo_path = entry_photo.get()
    gif_path = entry_gif.get()
    output_path = 'ytp.mp4'

    ear_rape_amount = int(entry_ear_rape.get())
    stutter_amount = int(entry_stutter.get())
    pitch_shift_amount = int(entry_pitch_shift.get())
    time_stretch_amount = int(entry_time_stretch.get())

    create_ytp(video_path, audio_path, music_path, photo_path, gif_path, output_path, ear_rape_amount, stutter_amount, pitch_shift_amount, time_stretch_amount)

root = tk.Tk()
root.title("YTP Creator")

tk.Label(root, text="Video file:").pack()
entry_video = tk.Entry(root)
entry_video.pack()

tk.Label(root, text="Audio file:").pack()
entry_audio = tk.Entry(root)
entry_audio.pack()

tk.Label(root, text="Music file:").pack()
entry_music = tk.Entry(root)
entry_music.pack()

tk.Label(root, text="Photo file:").pack()
entry_photo = tk.Entry(root)
entry_photo.pack()

tk.Label(root, text="GIF file:").pack()
entry_gif = tk.Entry(root)
entry_gif.pack()

tk.Label(root, text="Ear rape amount:").pack()
entry_ear_rape = tk.Entry(root)
entry_ear_rape.pack()

tk.Label(root, text="Stutter amount:").pack()
entry_stutter = tk.Entry(root)
entry_stutter.pack()

tk.Label(root, text="Pitch shift amount:").pack()
entry_pitch_shift = tk.Entry(root)
entry_pitch_shift.pack()

tk.Label(root, text="Time stretch amount:").pack()
entry_time_stretch = tk.Entry(root)
entry_time_stretch.pack()

tk.Button(root, text="Create YTP", command=create_ytp).pack()

root.mainloop()