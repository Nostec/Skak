using System;
namespace Skak {
    class MoveRules : Moves {
        int pieceId;
        int posX, posY;

        public int PieceId {
            set => this.pieceId = value;
        }
        public int PosX {
            set => this.posX = value;
        }
        public int PosY {
            set => this.posY = value;
        }
        

        public bool MoveAllowedCheck(int posX, int posY, int toPosX, int toPosY) {
            switch (pieces[pieceId+9].Color) {
                case "White":
                    switch (pieces[pieceId+9].Name) {
                        case "Pawn":
                            return (checkIfMoveIsPossible("Pawn", posX, posY, toPosX, toPosY));

                        case "Knight":
                        case "Knight2":
                            return checkIfMoveIsPossible("Knight", posX, posY, toPosX, toPosY);

                        case "Bishop":
                        case "Bishop2":

                            break;

                        case "Tower":
                        case "Tower2":
                            int maxMovesAllowed = 7;
                            for (int i = 0; i < maxMovesAllowed; i++) { 
                                if (IsDifferentColor(pieceId, grid[posY - i, posX]) == true) { 
                                    return true;
                                }
                                else if(IsDifferentColor(pieceId, grid[posY + i, posX]) == true) {
                                    return true;
                                }
                                else if(IsDifferentColor(pieceId, grid[posY, posX - i]) == true) {
                                    return true;
                                }
                                else if(IsDifferentColor(pieceId, grid[posY, posX + 1])) {
                                    return true;
                                }
                                else {
                                    return false;
                                }
                            }
                            break;
                            
                        case "Queen":
                            break;

                        case "King":
                            return KingMoveIsPossible(posX, posY, toPosX, toPosY);
                    }

                    break;

                case "Black":
                    switch (pieces[pieceId].Name) {
                        case "Pawn":
                            if (IsDifferentColor(pieceId, grid[posY + 1, posX - 1]) == true) {
                                return true;
                            }
                            else if (IsDifferentColor(pieceId, grid[posY + 1, posX + 1]) == true) {
                                return true;
                            }
                            else if (IsDifferentColor(pieceId, grid[posY + 1, posX]) == true) {
                                return true;
                            }
                            else {//error message: move cannot be made
                                return false;
                            }

                        case "Knight":
                        case "Knight2":
                            break;

                        case "Bishop":
                        case "Bishop2":
                            break;

                        case "Tower":
                        case "Tower2":
                            break;

                        case "Queen":
                            break;

                        case "King":
                            break;
                    }
                    break;

                case "Null":
                    //error message: no piece in the spot
                    break;

            }
            return false;
        }

        bool checkIfMoveIsPossible(string Piece, int posX, int posY, int toPosX, int toPosY) {
            if (toPosIsntOnOwnPiece(toPosX, toPosY) == true) {
                switch (Piece) {
                    case "Pawn":
                        return PawnMoveIsPossible(posX, posY, toPosX, toPosY);
                    case "Knight":
                        return SpringerMoveIsPossible(posX, posY, toPosX, toPosY);
                    case "King":
                        return KingMoveIsPossible(posX, posY, toPosX, toPosY);
                }
            }
            return false;
        }

        bool toPosIsntOnOwnPiece(int toPosX, int toPosY) {
            if(IsDifferentColor(pieceId, grid[toPosY - 1, toPosX - 1]) == true) {
                return true;
            }
            return false;
        }

        bool PawnMoveIsPossible(int posX, int posY, int toPosX, int toPosY) {
            if (IsChoiceOfMove(posX - 1, posY - 1, toPosX, toPosY) == true) {
                return true;
            }
            else if (IsChoiceOfMove(posX + 1, posY - 1, toPosX, toPosY) == true) {
                return true;
            }
            else if (IsChoiceOfMove(posX, posY - 1, toPosX, toPosY) == true) {
                int otherPieceId = grid[toPosY - 1, toPosX - 1];
                otherPieceId += 9;
                if(otherPieceId != 9) {
                    return false;
                }
                return true;
            }
            return false;
        }

        bool SpringerMoveIsPossible(int posX, int posY, int toPosX, int toPosY) {
            if (IsChoiceOfMove(posX - 1, posY + 2, toPosX, toPosY) == true) {
                return true;
            }
            else if (IsChoiceOfMove(posX + 1, posY + 2, toPosX, toPosY) == true) {
                return true;
            }
            else if (IsChoiceOfMove(posX - 2, posY + 1, toPosX, toPosY) == true) {
                return true;
            }
            else if (IsChoiceOfMove(posX + 2, posY + 1, toPosX, toPosY) == true) {
                return true;
            }
            else if (IsChoiceOfMove(posX - 1, posY - 2, toPosX, toPosY) == true) {
                return true;
            }
            else if (IsChoiceOfMove(posX + 1, posY - 2, toPosX, toPosY) == true) {
                return true;
            }
            else if (IsChoiceOfMove(posX - 2, posY - 1, toPosX, toPosY) == true) {
                return true;
            }
            else if (IsChoiceOfMove(posX + 2, posY - 1, toPosX, toPosY) == true) {
                return true;
            }
            return false;
        }

        bool KingMoveIsPossible(int posX, int posY, int toPosX, int toPosY) {
            if (IsChoiceOfMove(posX - 1, posY - 1, toPosX, toPosY) == true) {
                return true;
            }
            else if (IsChoiceOfMove(posX, posY - 1, toPosX, toPosY) == true) {
                return true;
            }
            else if (IsChoiceOfMove(posX + 1, posY - 1, toPosX, toPosY) == true) {
                return true;
            }
            else if (IsChoiceOfMove(posX - 1, posY, toPosX, toPosY) == true) {
                return true;
            }
            else if (IsChoiceOfMove(posX + 1, posY, toPosX, toPosY) == true) {
                return true;
            }
            else if (IsChoiceOfMove(posX - 1, posY + 1, toPosX, toPosY) == true) {
                return true;
            }
            else if (IsChoiceOfMove(posX, posY + 1, toPosX, toPosY) == true) {
                return true;
            }
            else if (IsChoiceOfMove(posX + 1, posY + 1, toPosX, toPosY) == true) {
                return true;
            }
            return false;
        }



        private bool IsChoiceOfMove(int posX, int posY, int toPosX, int toPosY) {
            if(posX == toPosX && posY == toPosY) {
                return true;
            }
            else {
                return false;
            }
        }

        private bool IsDifferentColor(int pieceId, int otherPieceId) {
            //fjerner til id
            pieceId += 9;
            otherPieceId += 9;
            if(pieces[otherPieceId].Color == "Null") {
                return true;
            }
            else if (pieces[otherPieceId].Color != pieces[pieceId].Color && pieces[otherPieceId].Color != "Null") {
                return true;
            }
            else { // Samme brik farve eller out of bounds
                return false;
            }
        }

    }
}

