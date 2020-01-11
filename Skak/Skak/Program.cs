using System;
using System.Linq;

namespace Skak {
    class Program {

        static void Main(string[] args) {
            Program Visual = new Program();
            InputReceiver inputCall = new InputReceiver();
            Console.SetWindowSize(40, 5);
            Console.WriteLine("Welcome to a bad version of chess!");
            while (true) {
                Console.WriteLine("Type START, HELP or EXIT");
                if (inputCall.Input().Equals("Start", StringComparison.OrdinalIgnoreCase)) {
                    break;
                }
            }
            Console.Title = "Trash Chess";
            Console.SetWindowSize(35, 20);
            while (true) {
                Visual.ClearAndPrintBoard();
                inputCall.Move_XY_Input("From");
                Visual.ClearAndPrintBoard();
                inputCall.Move_XY_Input("To");
                Console.ReadLine();

                // If game is done, break
            }


        }

        string[,] Board = new string[9, 9]{
                {"   ", "a", "b", "c", "d", "e", "f", "g", "h" },
                {"[1]", "R", "K", "B", "Q", "K", "R", "K", "B"},
                {"[2]", "P", "P", "P", "P", "P", "P", "P", "P"},
                {"[3]", " ", " ", " ", " ", " ", " ", " ", " "},
                {"[4]", " ", " ", " ", " ", " ", " ", " ", " "},
                {"[5]", " ", " ", " ", " ", " ", " ", " ", " "},
                {"[6]", " ", " ", " ", " ", " ", " ", " ", " "},
                {"[7]", "P", "P", "P", "P", "P", "P", "P", "P"},
                {"[8]", "R", "K", "B", "Q", "K", "R", "K", "B"},
        };

        void ClearAndPrintBoard() {
            Console.Clear();
            for (int x = 0; x < 9; x++) {
                for (int y = 0; y < 9; y++) {
                    Console.Write(string.Format(" {0} ", Board[x, y]));
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


    class InputReceiver {
        public string Input() {
            return Console.ReadLine();
        }

        private char[] XYinput;

        public void Move_XY_Input(string FromOrTo) {
            while (true) {
                if (FromOrTo.Equals("From", StringComparison.OrdinalIgnoreCase)) {
                    Console.Write("From pos XY: ");
                }
                else if (FromOrTo.Equals("To", StringComparison.OrdinalIgnoreCase)) {
                    Console.Write($"{XYinput[0]}{XYinput[1]} -> ");

                }
                string positionInput = Input();
                if (isPosInputValid(positionInput) == true) {
                    break;
                }
                else {
                    Console.WriteLine("Pos input isn't valid");
                    // Try again
                }
            }
        }

        bool isPosInputValid(string positionInput) {
            if (positionInput.Length == 2) { // Example: A1 (2 characters)
                if (XYinputIsWithinBoard(positionInput) == true) {
                    return true;
                }
            }
            return false;
        }

        private char[] validPositionCharacters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };
        private char[] validPositionNumbers = { '1', '2', '3', '4', '5', '6', '7', '8' };

        bool XYinputIsWithinBoard(string positionInput) {
            XYinput = Split_XY_InputToCharacters(positionInput);
            if (validPositionCharacters.Contains(XYinput[0])) {
                if (validPositionNumbers.Contains(XYinput[1])) {
                    return true;
                }
            }
            return false;
        }

        char[] Split_XY_InputToCharacters(string positionInput) {
            return positionInput.ToCharArray();
        }
    }
}
