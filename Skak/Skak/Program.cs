using System;

namespace Skak {
    class Program : Moves {       

        static void Main(string[] args) {
            //Print();
            Moves brik = new Moves();
            brik.CreatePieces();
            //brik.PieceIdentification(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine();
            Console.ReadKey();
        }

        private void ClearCurrentConsoleLine() {
            int currentLineCursor = 0;
            for (int i = 0; i < 15; i++) {
                Console.SetCursorPosition(0, currentLineCursor);
                Console.Write(new string(' ', Console.WindowWidth));

                currentLineCursor++;
            }
        } //Overskriver de forrige strings for ikke at skabe en "flashing" effeks som Console.Clear()

    }
}
