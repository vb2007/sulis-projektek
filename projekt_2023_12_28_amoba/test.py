class ttt:
    def __init__(self):
        self.currentWinner = None
        self.board = [" " for _ in range(9)]
    def printBoard(self):
        for row in [self.board[i*3:(i+1)*3] for i in range(3)]:
            print("| " + " | ".join(row) + " |")
    def availableMoves(self):
        return [i for i, spot in enumerate(self.board) if spot == " "]
    def emptySquares(self):
        return " " in self.board
    def makeMove(self, square, letter):
        if self.board[square] == " ":
            self.board[square] = letter
            if self.winner(square, letter):
                self.currentWinner = letter
            return True
        return False
    def winner(self, square, letter):
        rowIndex = square // 3
        row = self.board[rowIndex*3:(rowIndex+1)*3]
        if all([spot == letter for spot in row]):
            return True
        colIndex = square % 3
        column = [self.board[colIndex+i*3] for i in range(3)]
        if all([spot == letter for spot in column]):
            return True
        if square % 2 == 0:
            diagonal1 = [self.board[i] for i in [0, 4, 8]]
            if all([spot == letter for spot in diagonal1]):
                return True
            diagonal2 = [self.board[i] for i in [2, 4, 6]]
            if all([spot == letter for spot in diagonal2]):
                return True
        return False
class Player:
    def __init__(self, letter):
        self.letter = letter
    def getMove(self, game):
        validSquare = False
        value = None
        while not validSquare:
            square = int(input(f"{self.letter} játékos következik. Válassz mezőt (1-9): "))
            square -= 1
            try:
                if value not in game.availableMoves():
                    raise ValueError
                validSquare = True
            except ValueError:
                print('Ez a hely már foglalt, vagy érvénytelen.')
        return value
def play(game, playerX, playerO):
    game.printBoard()
    player = "X"
    while game.emptySquares():
        if player == "O":
            square = playerO.getMove(game)
        else:
            square = playerX.getMove(game)
        if game.makeMove(square, player):
            print(f"{player} befoglalja a {square}. mezőt.")
            game.printBoard()
            print("")
            if game.currentWinner:
                break
            if player == "X":
                player = "O"
            else:
                player ="X"
    if game.currentWinner:
        print(f"Az {player} játékos nyert.")
    else:
        print("Az eredmény döntetlen!")
if __name__ == "__main__":
    playerX = Player("X")
    playerO = Player("O")
    play(ttt(), playerX, playerO)