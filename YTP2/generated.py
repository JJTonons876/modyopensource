import tkinter as tk
from tkinter import filedialog
from moviepy.editor import *

class YTPGenerator:
    def __init__(self, master):
        self.master = master
        master.title("YTP Style 2012 Generator")

        self.video_source = ""
        self.audio_source = ""
        self.music_source = ""
        self.photo_source = ""
        self.gif_source = ""
        self.mlg_source = ""

        self.ear_rape = False
        self.stutter_loop = False
        self.sentence_mixing = False
        self.spadinner = False
        self.special_effect = False
        self.ytp_helper = False

        self.create_widgets()

    def create_widgets(self):
        # Video source
        self.video_label = tk.Label(self.master, text="Video Source:")
        self.video_label.grid(row=0, column=0)
        self.video_button = tk.Button(self.master, text="Browse", command=self.browse_video)
        self.video_button.grid(row=0, column=1)

        # Audio source
        self.audio_label = tk.Label(self.master, text="Audio Source:")
        self.audio_label.grid(row=1, column=0)
        self.audio_button = tk.Button(self.master, text="Browse", command=self.browse_audio)
        self.audio_button.grid(row=1, column=1)

        # Music source
        self.music_label = tk.Label(self.master, text="Music Source:")
        self.music_label.grid(row=2, column=0)
        self.music_button = tk.Button(self.master, text="Browse", command=self.browse_music)
        self.music_button.grid(row=2, column=1)

        # Photo source
        self.photo_label = tk.Label(self.master, text="Photo Source:")
        self.photo_label.grid(row=3, column=0)
        self.photo_button = tk.Button(self.master, text="Browse", command=self.browse_photo)
        self.photo_button.grid(row=3, column=1)

        # GIF source
        self.gif_label = tk.Label(self.master, text="GIF Source:")
        self.gif_label.grid(row=4, column=0)
        self.gif_button = tk.Button(self.master, text="Browse", command=self.browse_gif)
        self.gif_button.grid(row=4, column=1)

        # MLG source
        self.mlg_label = tk.Label(self.master, text="MLG Source:")
        self.mlg_label.grid(row=5, column=0)
        self.mlg_button = tk.Button(self.master, text="Browse", command=self.browse_mlg)
        self.mlg_button.grid(row=5, column=1)

        # Ear Rape
        self.ear_rape_var = tk.BooleanVar()
        self.ear_rape_check = tk.Checkbutton(self.master, text="Ear Rape", variable=self.ear_rape_var, onvalue=True, offvalue=False)
        self.ear_rape_check.grid(row=6, column=0)

        # Stutter Loop
        self.stutter_loop_var = tk.BooleanVar()
        self.stutter_loop_check = tk.Checkbutton(self.master, text="Stutter Loop", variable=self.stutter_loop_var, onvalue=True, offvalue=False)
        self.stutter_loop_check.grid(row=7, column=0)
# Sentence Mixing
        self.sentence_mixing_var = tk.BooleanVar()
        self.sentence_mixing_check = tk.Checkbutton(self.master, text="Sentence Mixing", variable=self.sentence_mixing_var, onvalue=True, offvalue=False)
        self.sentence_mixing_check.grid(row=8, column=0)

        # Spadinner
        self.spadinner_var = tk.BooleanVar()
        self.spadinner_check = tk.Checkbutton(self.master, text="Spadinner", variable=self.spadinner_var, onvalue=True, offvalue=False)
        self.spadinner_check.grid(row=9, column=0)

        # Special Effect
        self.special_effect_var = tk.BooleanVar()
        self.special_effect_check = tk.Checkbutton(self.master, text="Special Effect", variable=self.special_effect_var, onvalue=True, offvalue=False)
        self.special_effect_check.grid(row=10, column=0)

        # YTP Helper
        self.ytp_helper_var = tk.BooleanVar()
        self.ytp_helper_check = tk.Checkbutton(self.master, text="YTP Helper", variable=self.ytp_helper_var, onvalue=True, offvalue=False)
        self.ytp_helper_check.grid(row=11, column=0)

        # Generate button
        self.generate_button = tk.Button(self.master, text="Generate", command=self.generate)
        self.generate_button.grid(row=12, column=0)

    def browse_video(self):
        self.video_source = filedialog.askopenfilename()

    def browse_audio(self):
        self.audio_source = filedialog.askopenfilename()

    def browse_music(self):
        self.music_source = filedialog.askopenfilename()

    def browse_photo(self):
        self.photo_source = filedialog.askopenfilename()

    def browse_gif(self):
        self.gif_source = filedialog.askopenfilename()

    def browse_mlg(self):
        self.mlg_source = filedialog.askopenfilename()

    def generate(self):
        generate_ytp(self.video_source, self.audio_source, self.music_source, self.photo_source, self.gif_source, self.mlg_source,
                     ear_rape=self.ear_rape_var.get(), stutter_loop=self.stutter_loop_var.get(), sentence_mixing=self.sentence_mixing_var.get(),
                     spadinner=self.spadinner_var.get(), special_effect=self.special_effect_var.get(), ytp_helper=self.ytp_helper_var.get())

root = tk.Tk()
ytp = YTPGenerator(root)
root.mainloop()