using System;

namespace Skak {
    class Program {
        static void Main(string[] args) {
            Print();
            Console.ReadKey();
        }

        static void Print() {
            Console.WriteLine("     [a][b][c][d][e][f][g][h]");
            string[,] board = new string[8, 9]{
                {"[1]", "R", "K", "B", "Q", "K", "R", "K", "B"},
                {"[2]", "P", "P", "P", "P", "P", "P", "P", "P"},
                {"[3]", " ", " ", " ", " ", " ", " ", " ", " "},
                {"[4]", " ", " ", " ", " ", " ", " ", " ", " "},
                {"[5]", " ", " ", " ", " ", " ", " ", " ", " "},
                {"[6]", " ", " ", " ", " ", " ", " ", " ", " "},
                {"[7]", "P", "P", "P", "P", "P", "P", "P", "P"},
                {"[8]", "R", "K", "B", "Q", "K", "R", "K", "B"},
            };
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 9; j++) {
                    Console.Write(string.Format(" {0} ", board[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

    }
}
