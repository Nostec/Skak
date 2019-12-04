using System;

namespace Skak {
    class Program {       

        static void Main(string[] args) {
            Console.SetWindowSize(40, 5);
            Console.WriteLine("Welcome to a bad version of chess!");
            Console.Write("Press a button to start...");
            Console.ReadKey();
            Console.Clear();
            Console.SetWindowSize(30, 20);
            Console.Title = "Trash Chess";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Print();

            Console.ReadLine();
            ClearCurrentConsoleLine(18);
            
        }

        static string input() { // get set?
            return Console.ReadLine();
        }

        static void Print() {
            string[,] board = new string[9, 9]{
                {"   ", "1", "2", "3", "4", "5", "6", "7", "8" },
                {"[1]", "R", "K", "B", "Q", "K", "R", "K", "B"},
                {"[2]", "P", "P", "P", "P", "P", "P", "P", "P"},
                {"[3]", " ", " ", " ", " ", " ", " ", " ", " "},
                {"[4]", " ", " ", " ", " ", " ", " ", " ", " "},
                {"[5]", " ", " ", " ", " ", " ", " ", " ", " "},
                {"[6]", " ", " ", " ", " ", " ", " ", " ", " "},
                {"[7]", "P", "P", "P", "P", "P", "P", "P", "P"},
                {"[8]", "R", "K", "B", "Q", "K", "R", "K", "B"},
            };
            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    Console.Write(string.Format(" {0} ", board[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }

            Console.Write("From pos[X,Y] = ");
            Console.WriteLine(input());
        }

        static void ClearCurrentConsoleLine(int line) {
            for (int i = 0; i < 1; i++) {
                Console.SetCursorPosition(0, line);
                Console.Write(new string(' ', Console.WindowWidth));

                line++;
            }
        } //Overskriver de forrige strings for ikke at skabe en "flashing" effeks som Console.Clear()

    }
}
