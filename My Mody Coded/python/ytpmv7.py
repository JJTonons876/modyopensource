from pydub import AudioSegment
from pydub.playback import play

# Load audio file
audio = AudioSegment.from_file("audio.mp3")

# Time-stretch audio
audio = audio._spawn(audio.raw_data, overrides={'frame_rate': int(audio.frame_rate * 1.5)})

# Pitch-shift audio
audio = audio.pitch_shift(n_semitones=5)

# Repeat audio 3 times
audio = audio * 3

# Play processed audio
play(audio)