# A tkinter modulból szükséges sub-modulok importálása
from tkinter import messagebox, Tk, Button, Frame

# Ablakot középen megjelenítő függvény definiálása
def center(window):
    window.update_idletasks()

    # Megnézi mekkora a felhasználó kijelzője
    screen_width = window.winfo_screenwidth()
    screen_height = window.winfo_screenheight()

    size = tuple(int(_) for _ in window.geometry().split('+')[0].split('x'))

    x = screen_width/2 - size[0]/2
    y = screen_height/2 - size[1]/2

    window.geometry("%dx%d+%d+%d" % (size + (x, y)))

# Új grafikus ablak létrehozása "window" néven
window = Tk()
# Ablak ikonjának beállítása
window.iconbitmap("asset/gameIcon.ico")
# Ablak nevének beállítása
window.title("Amőba")

window.grid_rowconfigure(0, weight=1)
window.grid_columnconfigure(0, weight=1)

# Játkétáblát tartalmazó keret létrehozása
frame = Frame(window, relief="sunken")
frame.grid()
frame.grid_rowconfigure(0, weight=1)
frame.grid_columnconfigure(0, weight=1)

# 3x3-as játéktábla létrehozó függvény definiálása
def createBoard():
    for i in range(3):
        for j in range(3):
            button = Button(frame, text="", font=("Helvetica", 48), height=2, width=6, bg="#4c31e0", command=lambda row=i, col=j: handleClicks(row, col))
            button.grid(row=i, column=j)
            button.grid_rowconfigure(i, weight=1)
            button.grid_columnconfigure(j, weight=1)
# ...majd meghívása
createBoard()

# A győztest kihirdető füvvény definiálása
def declareWinner(winner):
    # Ha döntetlen akkor döntetlen ¯\_(ツ)_/¯
    if winner == "döntetlen":
        message = "A játék döntetlen."
    else:
        # Ha nem, akkor a függvény meghívásakor megadott winner paraméter értékéből meg lehet tudni a győztest
        message = f"Az {winner}. játékos nyert."
    
    # Megjeleníti azt a párbeszédablakot, ami megkérdezi játszanak-e egy új menetet a játékosok
    answer = messagebox.askyesno("Játék vége.",message=f"Véget ért a játék: {message} Szeretnél új játékot indítani?")

    # ...ha a válasz igen
    if answer:
        # Üríti a táblát
        global board
        board = [[0, 0, 0], [0, 0, 0], [0, 0, 0]]

        for i in range(3):
            for j in range(3):
                button = frame.grid_slaves(row=i, column=j)[0]
                button.config(text="")

        # És visszaállítja az aktív játékost 1(X)-re
        global activePlayer
        activePlayer = 1
    else:
        # Ha nem hát nem (kilép)
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
    
    # Átlósakat ellenőriz
    if board[0][0] == board[1][1] == board[2][2] and board[0][0] != 0:
        winner = board[0][0]
    elif board[0][2] == board[1][1] == board[2][0] and board[0][2] != 0:
        winner = board[0][2]
    
    # Ha minden sor tele van és nincs győztes, az állás döntetlen lesz
    if all([all(row) for row in board]) and winner is None:
        winner = "döntetlen"
    
    # Majd győzets hirdet a korábban definiált declareWinner() függvénnyel, a winner paramétert használva
    if winner:
        declareWinner(winner)

# Kattintásokat kezelő függvény definiálása (sor && oszlop paraméterekkel)
def handleClicks(row, col):
    global activePlayer

    # Megnézi a felhasználó melyik négyzetbe kattint
    if board[row][col] == 0:
        # Majd az aktív játékost, és a változó értékének megfelelően X-et vagy O-t tesz a négyzetbe
        if activePlayer == 1:
            board[row][col] = "X"
            activePlayer = 2
        else:
            board[row][col] = "O"
            activePlayer = 1
        
        button = frame.grid_slaves(row=row, column=col)[0]
        button.config(text=board[row][col])

        # Végül csekkolja győzött-e már valaki a korábban definiált függvény meghívásával
        checkForWinner()

# Aktív játékos és tábla értékeinek létrehozása változóba és listába
activePlayer = 1
board = [[0, 0, 0], [0, 0, 0], [0, 0, 0]]

# Ablak megjelnítése középen
center(window)
# Ablak megjelenítése, program grafikus futtatása
window.mainloop()