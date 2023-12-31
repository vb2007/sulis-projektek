# Ha csalni akarunk:

# import subprocess
# subprocess.run(["pip", "install", "tictactoe-py"]) # A játékhoz szükséges library-t telepítjük
# from tictactoe import play_console_game
# play_console_game() # Elindítjuk a játékot

# ---------

class ttt:
    # Üres tábla létrehozása
    def __init__(self):
        self.currentWinner = None
        self.board = [" " for _ in range(9)]

    # Már meglévő tábla vertikális elválasztása vonalakkal 
    def printBoard(self):
        print("╔═══╦═══╦═══╗")
        i = 0
        for row in [self.board[i*3:(i+1)*3] for i in range(3)]:
            print("║ " + " ║ ".join(row) + " ║")
            i-=-1
            if 3>i:
                print("╠═══╬═══╬═══╣")
            else:
                print("╚═══╩═══╩═══╝")

    # Elérhető lépések csekkolása
    def availableMoves(self):
        # Szabad-e a négyzet és (1-9) közt van-e az értéke
        return [i for i, spot in enumerate(self.board) if spot == " "]

    # Üres négyzetek csekkolása
    def emptySquares(self):
        return " " in self.board

    # Lépés
    def makeMove(self, square, letter):
        # Ha üres a négyzet...
        if self.board[square] == " ":
            # Beteszi az aktív játékos betűjét (letter paraméter) a választott négyzetbe (square paraméter)
            self.board[square] = letter

            # Majd megmondja melyik játékos győzött
            if self.winner(square, letter):
                self.currentWinner = letter
            return True

        return False

    # Győzteskihirdetés
    def winner(self, square, letter):
        # Győzet sorokat csekkol
        rowIndex = square // 3
        row = self.board[rowIndex*3:(rowIndex+1)*3]

        if all([spot == letter for spot in row]):
            return True

        # Győztes oszlopokat csekkol
        colIndex = square % 3
        column = [self.board[colIndex+i*3] for i in range(3)]

        if all([spot == letter for spot in column]):
            return True

        # Győztes átlósakat (vagy mi a diagonal magyarul) csekkol
        if square % 2 == 0:
            # Első oszlop helyeinek megadása
            diagonal1 = [self.board[i] for i in [0, 4, 8]]
            # Első oszlop helyeiben 3 azonos X vagy O csekkolása
            if all([spot == letter for spot in diagonal1]):
                return True
            # Második oszlop helyeinek megadása
            diagonal2 = [self.board[i] for i in [2, 4, 6]]
            # Második oszlop helyeiben 3 azonos X vagy O csekkolása
            if all([spot == letter for spot in diagonal2]):
                return True

        # Ha nincs győztes hát nincs győztes :(
        return False

class Player:
    # Alap betű beállítása
    def __init__(self, letter):
        self.letter = letter

    # Olvassa a játékosok lépéseit
    def getMove(self, game):
        validSquare = False
        # Amíg nem érvényes a lépés...
        while not validSquare:
            # Bekéri az értéket
            square = int(input(f"{self.letter} játékos következik. Válassz mezőt (1-9): "))
            # Majd kivon belőle egyet, mert a szutyok python 0-tól indexel
            square -= 1
            # Megpróbálja betenni a megadott helyre az aktív játékos jelét
            try:
                # Ha nem elérhető a négyzet...
                if square not in game.availableMoves():
                    # ValueError-t hoz fel
                    raise ValueError
                validSquare = True
            # Ha nem megy (out of range vagy foglalt), akkor visszadob egy "hibaüzenetet" és újra próbálkoztat
            except ValueError:
                print('Ez a hely már foglalt, vagy érvénytelen.')
        # Ha érvényes, visszaadja a lépés értékét 
        if validSquare:
            return square

# Játék fukció definiálása
def play(game, playerX, playerO):
    # Tábla konzolra írása
    game.printBoard()
    # Kezdő játékos beállítása
    player = "X"
    # Amíg van üres mező, addig játék futtatása

    while game.emptySquares():
        if player == "O":
            square = playerO.getMove(game)
        else:
            square = playerX.getMove(game)

        # Ha lép egy játékos...
        if game.makeMove(square, player):
            # Kiírja hova lépett (a módosított táblával együtt)
            print(f"{player} befoglalja a(z) {square+1}. mezőt.")
            game.printBoard()
            print("")

            # Ha vége a játéknak kilép a while-ból és a lenti if alapján győztest hirdet
            if game.currentWinner:
                break

            # Kezeli a játékosváltást
            if player == "X":
                player = "O"
            else:
                player ="X"

    # Ha a nyertes player X vagy O...
    if game.currentWinner:
        # ...akkor kiírja melyik nyert
        print(f"Az {player} játékos nyert.")
    # Ha meg nem...
    else:
        # ...akkor a játék döntetlen
        print("Az eredmény döntetlen!")

# Majd a fő funkcióban futtatja az appot a megadott paraméterekkel

if __name__ == "__main__":
    playerX = Player("X")
    playerO = Player("O")
    play(ttt(), playerX, playerO)
