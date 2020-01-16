using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skak {
    class Moves : Exceptions {
        ///Den enum under (Pieces) bruges med en offset 
        ///Der skal -6 på hver gang for Null bliver 0
        public enum Pieces {
            BlackKing, BlackQueen, BlackBishop, BlackKnight, BlackTower, BlackPawn,
            Null, //skal bruges som 0
            WhitePawn, WhiteTower, WhiteKnight, WhiteBishop, WhiteQueen, WhiteKing
        };

        int[,] grid;

        public void MovePieceLocation(string FromXY, string ToXY) {
            Program Visual = new Program();
            int[] FromXYconverted = convertXYtoNums(FromXY);
            int[] ToXYconverted = convertXYtoNums(ToXY);


            // Hvis rykket er muligt gøres dette:
            Visuals.Board[ToXYconverted[1], ToXYconverted[0]] = Visuals.Board[FromXYconverted[1], FromXYconverted[0]];
            Visuals.Board[FromXYconverted[1], FromXYconverted[0]] = " ";
            Visual.ClearAndPrintBoard();
        }

        string possibleLetterPositions = "abcdefgh";
        int[] convertXYtoNums(string XY) {
            int[] XYconverted = new int[2];
            XYconverted[0] = possibleLetterPositions.IndexOf(XY[0]) + 1;
            XYconverted[1] = Convert.ToInt32(XY[1].ToString());
            return XYconverted;
        }
        // 13.01.20 er nået hertil, prøvede at lave konvertering fra char til num

        //Sender videre til de metoder der gøres brug af for at omlokaliserer en brik
        public void PieceRelocation(int x, int y, int reloX, int reloY) {

            MovePiecePosition(x, y, reloX, reloY);
        }

        //
        private void MovePiecePosition(int x, int y, int reloX, int reloY) {
            //code to move the specific piece to another specific spot
            //add exceptions for: if other piece is there(friendly & enemy), where it can move
            int piece = grid[x, y];
            int availableMovePosCheck;
            switch (piece) {
                case (int)Pieces.Null:
                    //error message: Kan ikke rykke med et tomt felt
                    break;
                case (int)Pieces.BlackKing:
                    //do stuff
                    break;
                case (int)Pieces.BlackQueen:
                    //do stuff
                    break;
                case (int)Pieces.BlackBishop:
                    //do stuff
                    break;
                case (int)Pieces.BlackKnight:
                    //do stuff
                    break;
                case (int)Pieces.BlackTower:
                    //do stuff
                    break;
                case (int)Pieces.BlackPawn:
                    availableMovePosCheck = grid[x + 1, y];

                    break;
                case (int)Pieces.WhiteKing:
                    //do stuff
                    break;
                case (int)Pieces.WhiteQueen:
                    //do stuff
                    break;
                case (int)Pieces.WhiteBishop:
                    //do stuff
                    break;
                case (int)Pieces.WhiteKnight:
                    //do stuff
                    break;
                case (int)Pieces.WhiteTower:
                    //do stuff
                    break;
                case (int)Pieces.WhitePawn:
                    //do stuff
                    break;
            }
        }

        public void PerformMove() {
            // SetCursorPosition
            // Input indtil videre, skal ændres
            int inputX = 0;
            int inputY = 0;
            int pieceOnInput;

            pieceOnInput = grid[inputX, inputY];

        }

        public void SetPiecePositions() {
            ///Sorte brikker har - foran brikkens identitet, hvide har ingen
            ///Rook/Tårn = 2, Springer/Knight = 3, Bishop/Løber = 4
            ///Queen = 5, King = 6, Pawn = 1
            ///Ingen brik = 0

            grid = new int[8, 8]
            {
                {-2,-3,-4,-5,-6,-4,-3,-2},
                {-1,-1,-1,-1,-1,-1,-1,-1},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0},
                { 1, 1, 1, 1, 1, 1, 1, 1},
                { 2, 3, 4, 5, 6, 4, 3, 2}
            };

            /*for (int x = 0; x < grid.GetLength(0); x++) {
                for (int y = 0; y < grid.GetLength(1); y++) {

                }
            }*/
        }

        private bool BoardCheck(int request, int position, ref bool change) {

            if (request != position) {
                change = true;
            }

            return change;
        }

    }
}
