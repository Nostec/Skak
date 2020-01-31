using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Skak {
    class Moves {
        ///Den enum under (Pieces) bruges med en offset 
        ///Der skal -9 på hver gang for Null bliver 0
        protected enum Pieces {
            BlackKing, BlackQueen, BlackBishop2, BlackBishop, BlackKnight2, BlackKnight, BlackTower2, BlackTower, BlackPawn,
            Null, //skal bruges som 0
            WhitePawn, WhiteTower, WhiteTower2, WhiteKnight, WhiteKnight2, WhiteBishop, WhiteBishop2, WhiteQueen, WhiteKing
        };

        protected List<Piece> pieces = new List<Piece>();

        ///Sorte brikker har - foran brikkens identitet, hvide har ingen
        ///Rook/Tårn = 2&3, Springer/Knight = 4&5 Bishop/Løber = 6&7
        ///Queen = 8, King = 9, Pawn = 1
        ///Ingen brik = 0
        protected static int[,] grid = new int[8, 8]{
            {-2,-4,-6,-8,-9,-7,-5,-3},
            {-1,-1,-1,-1,-1,-1,-1,-1},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0},
            { 1, 1, 1, 1, 1, 1, 1, 1},
            { 2, 4, 6, 8, 9, 7, 5, 3}
        };

        

        public void MovePieceLocation(string FromXY, string ToXY) {
            MoveRules mr = new MoveRules();
            mr.CreatePieces();
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
                case (int)Pieces.Null - 9:
                    Piece Null;
                    if (CheckPieceExists("Null", "Null") != true) {
                        Null = new Piece();
                        PieceCreateValues(Null, (int)Pieces.Null - 9, "Null", "Null");
                    }
                    //error message: Kan ikke rykke et tomt felt
                    break;

                case (int)Pieces.BlackKing - 9:
                    Piece BlackKing;
                    if (CheckPieceExists("King", "Black") != true) {
                        BlackKing = new Piece();
                        PieceCreateValues(BlackKing, (int)Pieces.BlackKing - 9, "King", "Black");
                    }
                    break;

                case (int)Pieces.BlackQueen - 9:
                    Piece BlackQueen;
                    if (CheckPieceExists("Queen", "Black") != true) {
                        BlackQueen = new Piece();
                        PieceCreateValues(BlackQueen, (int)Pieces.BlackQueen - 9, "Queen", "Black");
                    }
                    break;

                case (int)Pieces.BlackBishop - 9:
                    Piece BlackBishop;
                    if (CheckPieceExists("Bishop", "Black") != true) {
                        BlackBishop = new Piece();
                        PieceCreateValues(BlackBishop, (int)Pieces.BlackBishop - 9, "Bishop", "Black");
                    }
                    break;

                case (int)Pieces.BlackBishop2 - 9:
                    Piece BlackBishop2;
                    if (CheckPieceExists("Bishop2", "Black") != true) {
                        BlackBishop2 = new Piece();
                        PieceCreateValues(BlackBishop2, (int)Pieces.BlackBishop2 - 9, "Bishop2", "Black");
                    }
                    break;

                case (int)Pieces.BlackKnight - 9:
                    Piece BlackKnight;
                    if (CheckPieceExists("Knight", "Black") != true) {
                        BlackKnight = new Piece();
                        PieceCreateValues(BlackKnight, (int)Pieces.BlackKnight - 9, "Knight", "Black");
                    }
                    break;

                case (int)Pieces.BlackKnight2 - 9:
                    Piece BlackKnight2;
                    if (CheckPieceExists("Knight2", "Black") != true) {
                        BlackKnight2 = new Piece();
                        PieceCreateValues(BlackKnight2, (int)Pieces.BlackKnight2 - 9, "Knight2", "Black");
                    }
                    break;

                case (int)Pieces.BlackTower - 9:
                    Piece BlackTower;
                    if (CheckPieceExists("Tower", "Black") != true) {
                        BlackTower = new Piece();
                        PieceCreateValues(BlackTower, (int)Pieces.BlackTower - 9, "Tower", "Black");
                    }
                    break;

                case (int)Pieces.BlackTower2 - 9:
                    Piece BlackTower2;
                    if (CheckPieceExists("Tower2", "Black") != true) {
                        BlackTower2 = new Piece();
                        PieceCreateValues(BlackTower2, (int)Pieces.BlackTower2 - 9, "Tower2", "Black");
                    }
                    break;

                case (int)Pieces.BlackPawn - 9:
                    Piece BlackPawn;
                    if (CheckPieceExists("Pawn", "Black") != true) {
                        BlackPawn = new Piece();
                        PieceCreateValues(BlackPawn, (int)Pieces.BlackPawn - 9, "Pawn", "Black");
                    }
                    break;

                case (int)Pieces.WhiteKing - 9:
                    Piece WhiteKing;
                    if (CheckPieceExists("King", "White") != true) {
                        WhiteKing = new Piece();
                        PieceCreateValues(WhiteKing, (int)Pieces.WhiteKing - 9, "King", "White");
                    }
                    break;

                case (int)Pieces.WhiteQueen - 9:
                    Piece WhiteQueen;
                    if (CheckPieceExists("Queen", "White") != true) {
                        WhiteQueen = new Piece();
                        PieceCreateValues(WhiteQueen, (int)Pieces.WhiteQueen - 9, "Queen", "White");
                    }
                    break;

                case (int)Pieces.WhiteBishop - 9:
                    Piece WhiteBishop;
                    if (CheckPieceExists("Bishop", "White") != true) {
                        WhiteBishop = new Piece();
                        PieceCreateValues(WhiteBishop, (int)Pieces.WhiteBishop - 9, "Bishop", "White");
                    }
                    break;

                case (int)Pieces.WhiteBishop2 - 9:
                    Piece WhiteBishop2;
                    if (CheckPieceExists("Bishop2", "White") != true) {
                        WhiteBishop2 = new Piece();
                        PieceCreateValues(WhiteBishop2, (int)Pieces.WhiteBishop2 - 9, "Bishop2", "White");
                    }
                    break;

                case (int)Pieces.WhiteKnight - 9:
                    Piece WhiteKnight;
                    if (CheckPieceExists("Knight", "White") != true) {
                        WhiteKnight = new Piece();
                        PieceCreateValues(WhiteKnight, (int)Pieces.WhiteKnight - 9, "Knight", "White");
                    }
                    break;

                case (int)Pieces.WhiteKnight2 - 9:
                    Piece WhiteKnight2;
                    if (CheckPieceExists("Knight2", "White") != true) {
                        WhiteKnight2 = new Piece();
                        PieceCreateValues(WhiteKnight2, (int)Pieces.WhiteKnight2 - 9, "Knight2", "White");
                    }
                    break;

                case (int)Pieces.WhiteTower - 9:
                    Piece WhiteTower;
                    if (CheckPieceExists("Tower", "White") != true) {
                        WhiteTower = new Piece();
                        PieceCreateValues(WhiteTower, (int)Pieces.WhiteTower - 9, "Tower", "White");
                    }
                    break;

                case (int)Pieces.WhiteTower2 - 9:
                    Piece WhiteTower2;
                    if (CheckPieceExists("Tower2", "White") != true) {
                        WhiteTower2 = new Piece();
                        PieceCreateValues(WhiteTower2, (int)Pieces.WhiteTower2 - 9, "Tower2", "White");
                    }
                    break;

                case (int)Pieces.WhitePawn - 9:
                    Piece WhitePawn;
                    if (CheckPieceExists("Pawn", "White") != true) {
                        WhitePawn = new Piece();
                        PieceCreateValues(WhitePawn, (int)Pieces.WhitePawn - 9, "Pawn", "White");
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

        public void CreatePieces() {
            SetPiecePositions();
        }
          
        private void SetPiecePositions() {
            for (int x = -9; x <= 9; x++) {

                PieceIdentification(x);
            }
        }
    }
}
