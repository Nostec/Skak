using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Skak {
    class Moves {
        ///Den enum under (Pieces) bruges med en offset 
        ///Der skal -6 på hver gang for Null bliver 0
        protected enum Pieces {
            BlackKing, BlackQueen, BlackBishop, BlackKnight, BlackTower, BlackPawn,
            Null, //skal bruges som 0
            WhitePawn, WhiteTower, WhiteKnight, WhiteBishop, WhiteQueen, WhiteKing
        };
        protected const int offset = 6;

        protected List<Piece> pieces = new List<Piece>();

        ///Sorte brikker har - foran brikkens identitet, hvide har ingen
        ///Rook/Tårn = 2, Springer/Knight = 3, Bishop/Løber = 4
        ///Queen = 5, King = 6, Pawn = 1
        ///Ingen brik = 0
        protected static int[,] grid = new int[8, 8]{
            {-2,-3,-4,-5,-6,-4,-3,-2},
            {-1,-1,-1,-1,-1,-1,-1,-1},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 1, 1, 1, 1, 1, 1, 1, 1},
            { 2, 3, 4, 5, 6, 4, 3, 2}
        };

        

        public void MovePieceLocation(string FromXY, string ToXY) {
            MoveRules mr = new MoveRules();
            mr.SetPiecePositions();
            int[] FromXYconverted = ConvertXYtoNums(FromXY);
          
            if(PieceIsPlayers(FromXYconverted, Program.Player1Turn) == true) {
                int[] ToXYconverted = ConvertXYtoNums(ToXY);
                mr.PieceId = grid[FromXYconverted[1] - 1, FromXYconverted[0] - 1];
                if (mr.MoveAllowedCheck(FromXYconverted[0], FromXYconverted[1], ToXYconverted[0], ToXYconverted[1]) == true) {
                    Program.Player1Turn = !Program.Player1Turn; // Skifter bool-værdien til den modsatte værdi 
                    Visuals.Board[ToXYconverted[1], ToXYconverted[0]] = Visuals.Board[FromXYconverted[1], FromXYconverted[0]]; // Brikken fra from-pos bliver sat på to-pos
                    Visuals.Board[FromXYconverted[1], FromXYconverted[0]] = " "; // Brikkens from-pos bliver til ingenting
                    //Offset på backend grid grundet den er 8x8 istedet for 9x9 (Frontend grid er 9x9, da der er tilføjet A-H, 1-8 i siderne til koordination af position)
                    grid[ToXYconverted[1] - 1, ToXYconverted[0] - 1] = grid[FromXYconverted[1] - 1, FromXYconverted[0] - 1];
                    grid[FromXYconverted[1] - 1, FromXYconverted[0] - 1] = 0;
                    Visuals.ClearAndPrintBoard();
                }
            }
            else {
                Console.WriteLine("You can't move that piece...");
                Console.ReadKey();
                Visuals.ClearAndPrintBoard();
            }    
        }

        string possibleLetterPositions = "abcdefgh";
        private int[] ConvertXYtoNums(string XY) {
            int[] XYconverted = new int[2];
            XYconverted[0] = possibleLetterPositions.IndexOf(char.ToLower(XY[0])) + 1;
            XYconverted[1] = Convert.ToInt32(XY[1].ToString());
            return XYconverted;
        }

        private bool PieceIsPlayers(int[] FromXYconverted, bool Player1Turn) {
            if(Visuals.Board[FromXYconverted[1], FromXYconverted[0]] != " ") {
                if (Visuals.Board[FromXYconverted[1], FromXYconverted[0]].Any(char.IsUpper)) {
                    if (Player1Turn == true) {
                        return true;
                    }
                }
                else {
                    if (Player1Turn == false) {
                        return true;
                    }
                }
            }
            return false;
        }

        private void PieceIdentification(int piece) {
            switch (piece) {
                case (int)Pieces.Null - offset:
                    Piece Null;
                    if (CheckPieceExists("Null", "Null") != true) {
                        Null = new Piece();
                        PieceCreateValues(Null, (int)Pieces.Null - offset, "Null", "Null");
                    }
                    break;

                case (int)Pieces.BlackKing - offset:
                    Piece BlackKing;
                    if (CheckPieceExists("King", "Black") != true) {
                        BlackKing = new Piece();
                        PieceCreateValues(BlackKing, (int)Pieces.BlackKing - offset, "King", "Black");
                    }
                    break;

                case (int)Pieces.BlackQueen - offset:
                    Piece BlackQueen;
                    if (CheckPieceExists("Queen", "Black") != true) {
                        BlackQueen = new Piece();
                        PieceCreateValues(BlackQueen, (int)Pieces.BlackQueen - offset, "Queen", "Black");
                    }
                    break;

                case (int)Pieces.BlackBishop - offset:
                    Piece BlackBishop;
                    if (CheckPieceExists("Bishop", "Black") != true) {
                        BlackBishop = new Piece();
                        PieceCreateValues(BlackBishop, (int)Pieces.BlackBishop - offset, "Bishop", "Black");
                    }
                    break;

                case (int)Pieces.BlackKnight - offset:
                    Piece BlackKnight;
                    if (CheckPieceExists("Knight", "Black") != true) {
                        BlackKnight = new Piece();
                        PieceCreateValues(BlackKnight, (int)Pieces.BlackKnight - offset, "Knight", "Black");
                    }
                    break;

                case (int)Pieces.BlackTower - offset:
                    Piece BlackTower;
                    if (CheckPieceExists("Tower", "Black") != true) {
                        BlackTower = new Piece();
                        PieceCreateValues(BlackTower, (int)Pieces.BlackTower - offset, "Tower", "Black");
                    }
                    break;

                case (int)Pieces.BlackPawn - offset:
                    Piece BlackPawn;
                    if (CheckPieceExists("Pawn", "Black") != true) {
                        BlackPawn = new Piece();
                        PieceCreateValues(BlackPawn, (int)Pieces.BlackPawn - offset, "Pawn", "Black");
                    }
                    break;

                case (int)Pieces.WhiteKing - offset:
                    Piece WhiteKing;
                    if (CheckPieceExists("King", "White") != true) {
                        WhiteKing = new Piece();
                        PieceCreateValues(WhiteKing, (int)Pieces.WhiteKing - offset, "King", "White");
                    }
                    break;

                case (int)Pieces.WhiteQueen - offset:
                    Piece WhiteQueen;
                    if (CheckPieceExists("Queen", "White") != true) {
                        WhiteQueen = new Piece();
                        PieceCreateValues(WhiteQueen, (int)Pieces.WhiteQueen - offset, "Queen", "White");
                    }
                    break;

                case (int)Pieces.WhiteBishop - offset:
                    Piece WhiteBishop;
                    if (CheckPieceExists("Bishop", "White") != true) {
                        WhiteBishop = new Piece();
                        PieceCreateValues(WhiteBishop, (int)Pieces.WhiteBishop - offset, "Bishop", "White");
                    }
                    break;

                case (int)Pieces.WhiteKnight - offset:
                    Piece WhiteKnight;
                    if (CheckPieceExists("Knight", "White") != true) {
                        WhiteKnight = new Piece();
                        PieceCreateValues(WhiteKnight, (int)Pieces.WhiteKnight - offset, "Knight", "White");
                    }
                    break;

                case (int)Pieces.WhiteTower - offset:
                    Piece WhiteTower;
                    if (CheckPieceExists("Tower", "White") != true) {
                        WhiteTower = new Piece();
                        PieceCreateValues(WhiteTower, (int)Pieces.WhiteTower - offset, "Tower", "White");
                    }
                    break;

                case (int)Pieces.WhitePawn - offset:
                    Piece WhitePawn;
                    if (CheckPieceExists("Pawn", "White") != true) {
                        WhitePawn = new Piece();
                        PieceCreateValues(WhitePawn, (int)Pieces.WhitePawn - offset, "Pawn", "White");
                    }
                    break;
            }
        }
        
        private void PieceCreateValues(Piece piece, int pieceId, string pieceName, string pieceColor) {
            piece.Id = pieceId;
            piece.Name = pieceName;
            piece.Color = pieceColor;
            pieces.Add(piece);
        }
        private bool CheckPieceExists(string name, string color) {
            return pieces.Exists(x => x.Name == name && x.Color == color);
        }

        private void SetPiecePositions() {
            for (int x = -9; x <= 9; x++) {
                PieceIdentification(x);
            }
        }
    }
}
