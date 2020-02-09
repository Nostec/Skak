using System;
using System.Linq;

namespace Skak {
    class Program {
        InputReceiver inputCall = new InputReceiver();
        public static bool Player1Turn = true;
        public static bool gameEnd = false;
        static void Main(string[] args) {
            Program Run = new Program();
            Console.SetWindowSize(42, 5);
            Console.Title = "C h e s s";
            Run.GameMenu();
            Console.SetWindowSize(29, 20);
            Run.Game();
        }

        void GameMenu() {
            Console.WriteLine("Welcome to a different version of chess...");
            while (true) {
                Console.WriteLine("Type START or EXIT");
                string menuInput = Console.ReadLine();
                if (menuInput.Equals("Start", StringComparison.OrdinalIgnoreCase)) {
                    break;
                }
                else if (menuInput.Equals("Exit", StringComparison.OrdinalIgnoreCase)) {
                    Console.Clear();
                    Console.WriteLine("Bye :)...");
                    System.Threading.Thread.Sleep(1000);
                    Environment.Exit(0);
                }
            }
        }

        void Game() { // Kører spillet i et loop og breaker først når gameEnd er true
            while (true) {
                Visuals.ClearAndPrintBoard();
                inputCall.MoveFromOrTo("From");
                Visuals.ClearAndPrintBoard();
                inputCall.MoveFromOrTo("To");
                if(gameEnd == true) {
                    break;
                }
            }
        }
    }

    class InputReceiver {
        public string[] XYinput = new string[2]; // Indexes: 0 = fraXY, 1 = tilXY
        public void MoveFromOrTo(string FromOrTo) {
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
                string positionInput = Console.ReadLine();

                if (positionInput.Equals("Cancel", StringComparison.OrdinalIgnoreCase)) {
                    Visuals.ClearAndPrintBoard();
                    break;
                }
                else if (PosInputIsValid(positionInput, FromOrTo) == true) {
                    if(FromOrTo == "To") {
                        Moves Moves = new Moves();
                        Moves.MovePieceLocation(XYinput[0], XYinput[1]);
                    }
                    break;
                }
                else {
                    Console.WriteLine("Pos input isn't valid...");
                    Console.ReadKey();
                    Visuals.ClearAndPrintBoard();
                    if(FromOrTo == "From") { // Undgår skiftet til "To" input
                        MoveFromOrTo("From");
                    }
                    break;
                }
            }
        }

        private bool PosInputIsValid(string positionInput, string FromOrTo) {
            if (positionInput.Length == 2) { // Eksempel: A1 (2 chars)
                return XYinputIsWithinBoard(positionInput, FromOrTo);
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
 