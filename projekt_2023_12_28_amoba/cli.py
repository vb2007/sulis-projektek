import subprocess
subprocess.run(["pip", "install", "tictactoe-py"]) # A játékhoz szükséges library-t telepítjük
from tictactoe import play_console_game
play_console_game() # Elindítjuk a játékot
