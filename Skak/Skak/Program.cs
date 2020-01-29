using System;
using System.Linq;

namespace Skak {
    class Program {
        InputReceiver inputCall = new InputReceiver();
        public static bool Player1Turn = true;
        public static bool gameEnd = false;
        static void Main(string[] args) {
            Program Visual = new Program();
            Console.SetWindowSize(40, 5);
            Console.Title = "Trash Chess";
            Visual.GameMenu();
            Console.SetWindowSize(35, 20);
            Visual.RunGame();
        }

        void GameMenu() {
            Console.WriteLine("Welcome to a bad version of chess!");
            while (true) {
                Console.WriteLine("Type START, RULES or EXIT");
                if (inputCall.Input().Equals("Start", StringComparison.OrdinalIgnoreCase)) {
                    break;
                }
            }
        }

        void RunGame() {
            while (true) {
                ClearAndPrintBoard();
                inputCall.moveFromOrTo("From");
                ClearAndPrintBoard();
                inputCall.moveFromOrTo("To");
                if(gameEnd == true) {
                    break;
                }
            }
        }


        public void ClearAndPrintBoard() {
            Console.Clear();
            for (int x = 0; x < 9; x++) {
                for (int y = 0; y < 9; y++) {
                    Console.Write(string.Format(" {0} ", Visuals.Board[x, y]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }

        }

        static void ClearEverythingFromConsole(int line) {
            for (int i = 0; i < 1; i++) {
                Console.SetCursorPosition(0, line);
                Console.Write(new string(' ', Console.WindowWidth));

                line++;
            }
        } //Overskriver de forrige strings for ikke at skabe en "flashing" effeks som Console.Clear()

    }


    class InputReceiver { // Skal måske flyttes til Moves.cs?
        public string Input() {
            return Console.ReadLine();
        }

        static Program Visual = new Program();

        public string[] XYinput = new string[2]; // Indexes: 0 = fraXY, 1 = tilXY
        public void moveFromOrTo(string FromOrTo) {
            if (Program.Player1Turn == true) {
                Console.WriteLine("Player 1 turn");
            }
            else {
                Console.WriteLine("Player 2 turn");
            }
            if (FromOrTo == "From") {
                Console.Write("From pos XY: ");
            }
            else if (FromOrTo == "To") {
                Console.Write($"{XYinput[0]} -> ");
            }
            
            Move_XY_Input(FromOrTo);
        }

        public void Move_XY_Input(string FromOrTo) {
            while (true) {
                string positionInput = Input();

                if (positionInput.Equals("Cancel", StringComparison.OrdinalIgnoreCase)) {
                    Visual.ClearAndPrintBoard();
                    break;
                }

                else if (isPosInputValid(positionInput, FromOrTo) == true) {
                    if(FromOrTo == "To") {
                        Moves Moves = new Moves();
                        Moves.MovePieceLocation(XYinput[0], XYinput[1]);
                    }
                    break;
                }
                else {
                    Console.WriteLine("Pos input isn't valid...");
                    Console.ReadKey();
                    Visual.ClearAndPrintBoard();
                    if(FromOrTo == "From") {
                        moveFromOrTo("From");
                    }
                    break;
                }
            }
        }


        private bool isPosInputValid(string positionInput, string FromOrTo) {
            if (positionInput.Length == 2) { // Example: A1 (2 characters)
                if (XYinputIsWithinBoard(positionInput, FromOrTo) == true) {
                    return true;
                }
            }
            return false;
        }


        private bool XYinputIsWithinBoard(string positionInput, string FromOrTo) {
            if (XYinputContainsValidChars(positionInput) == true) {
                switch (FromOrTo) {
                    case "From":
                        XYinput[0] = positionInput;
                        break;
                    case "To":
                        XYinput[1] = positionInput;
                        break;
                }
                return true;
            }
            return false;
        }

        private char[] validPositionLetters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
        private char[] validPositionNums = { '1', '2', '3', '4', '5', '6', '7', '8' };

        private bool XYinputContainsValidChars(string positionInput) {
            return validPositionLetters.Contains(char.ToLower(positionInput[0])) && validPositionNums.Contains(positionInput[1]);
        }
    }
}
 