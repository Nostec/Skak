using System;
using System.Collections.Generic;
using System.Text;

namespace Skak {
    class Visuals {
        public static string[,] Board = new string[9, 9]{
                {"   ", "A", "B", "C", "D", "E", "F", "G", "H" },
                {"[1]", "r", "s", "b", "q", "k", "b", "s", "r"},
                {"[2]", "p", "p", "p", "p", "p", "p", "p", "p"},
                {"[3]", " ", " ", " ", " ", " ", " ", " ", " "},
                {"[4]", " ", " ", " ", " ", " ", " ", " ", " "},
                {"[5]", " ", " ", " ", " ", " ", " ", " ", " "},
                {"[6]", " ", " ", " ", " ", " ", " ", " ", " "},
                {"[7]", "P", "P", "P", "P", "P", "P", "P", "P"},
                {"[8]", "R", "S", "B", "Q", "K", "B", "S", "R"},
        };

        public static void ClearAndPrintBoard() {
            Console.Clear();
            for (int x = 0; x < 9; x++) {
                for (int y = 0; y < 9; y++) {
                    Console.Write(string.Format(" {0} ", Visuals.Board[x, y]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }
    }
}
