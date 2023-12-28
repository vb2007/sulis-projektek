# A tkinter modul importálása "tk"-ként, a grafikus megjelenítéshez
import tkinter as tk
from tkinter import messagebox

# Új grafikus ablak létrehozása "window" néven
window = tk.Tk()
# Ablak nevének beállítása
window.title("Amőba")

# 3x3-as játéktábla létrehozó függvény definiálása
def createBoard():
    for i in range(3):
        for j in range(3):
            button = tk.Button(window, text="", font=("Arial", 50), height=2, width=6, bg="lightblue", command=lambda row=i, col=j: handleClicks(row, col))
            button.grid(row=i, column=j, sticky="nsew")
# ...majd meghívása
createBoard()

# A győztest kihirdető füvvény definiálása
def decleareWinner(winner):
    if winner == "döntetlen":
        message = "A játék döntetlen."
    else:
        message = f"Az {winner} játékos nyert."
    
    answer = messagebox.askyesno(f"Véget ért a játék: {message} Szeretnél új játékot indítani?")

    if answer:
        global board
        board = [[0, 0, 0], [0, 0, 0], [0, 0, 0]]

        for i in range(3):
            for j in range(3):
                button = window.grid_slaves(row=i, column=j)[0]
                button.config(text="")

        global activePlayer
        activePlayer = 1
    else:
        window.quit()

# A győztest csekkoló füvvény definiálása
# (minden egyes kattintáskor ellenőrzi, hogy van-e már győztes, vagy döntetlen-e a játék)
def checkForWinner():
    winner = None

    # Sorokat ellenőriz
    for row in board:
        if row.count(row[0]) == len(row) and row[0] != 0:
            winner = row[0]
            break

    # Oszlopokat ellenőriz
    for col in range(len(board)):
        if board[0][col] == board[1][col] == board[2][col] and board[0][col] != 0:
            winner = board[0][col]
            break
    
    # Átlós meccseket ellenőriz
    if board[0][0] == board[1][1] == board[2][2] and board[0][0] != 0:
        winner = board[0][0]
    elif board[0][2] == board[1][1] == board[2][0] and board[0][2] != 0:
        winner = board[0][2]
    
    if all([all(row) for row in board]) and winner is None:
        winner = "döntetlen"
    
    if winner:
        decleareWinner(winner)

# Kattintásokat kezelő függvény definiálása (sor && oszlop paraméterekkel)
def handleClicks(row, col):
    global activePlayer

    if board[row][col] == 0:
        if activePlayer == 1:
            board[row][col] = "X"
            activePlayer = 2
        else:
            board[row][col] = "O"
            activePlayer = 1
        
        button = window.grid_slaves(row=row, column=col)[0]
        button.config(text=board[row][col])

        checkForWinner()

# Aktív játékos és tábla értékeinek létrehozása változóba és listába
activePlayer = 1
board = [[0, 0, 0], [0, 0, 0], [0, 0, 0]]

# Ablak megjelenítése, program grafikus futtatása
window.mainloop()