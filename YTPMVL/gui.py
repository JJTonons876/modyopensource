import tkinter as tk
from tkinter import filedialog

def select_video():
    video_path = filedialog.askopenfilename()
    print(f"Video file selected: {video_path}")

def select_audio():
    audio_path = filedialog.askopenfilename()
    print(f"Audio file selected: {audio_path}")

def create_ytpmv():
    video_path = entry_video.get()
    audio_path = entry_audio.get()
    pitch_shift_amount = int(entry_pitch.get())
    output_path = 'ytpmv.mp4'

    create_ytpmv(video_path, audio_path, output_path, pitch_shift_amount)

root = tk.Tk()
root.title("YTPMV Creator")

tk.Label(root, text="Video file:").pack()
entry_video = tk.Entry(root)
entry_video.pack()

tk.Label(root, text="Audio file:").pack()
entry_audio = tk.Entry(root)
entry_audio.pack()

tk.Label(root, text="Pitch shift amount:").pack()
entry_pitch = tk.Entry(root)
entry_pitch.pack()

tk.Button(root, text="Create YTPMV", command=create_ytpmv).pack()

root.mainloop()