using System;
namespace Skak {
    class MoveRules : Moves {
        int pieceId;
        int otherColorPiece;
        bool otherPiece;
        bool sameColorBlock;
        public int PieceId {
            set => this.pieceId = value;
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
                            return checkIfMoveIsPossible("Bishop", posX, posY, toPosX, toPosY);

                        case "Tower":
                        case "Tower2":
                            return checkIfMoveIsPossible("Tower", posX, posY, toPosX, toPosY);
                            
                        case "Queen":
                            break;

                        case "King":
                            return checkIfMoveIsPossible("King", posX, posY, toPosX, toPosY);
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
                            return checkIfMoveIsPossible("Bishop", posX, posY, toPosX, toPosY);

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
                    case "Bishop":
                        return BishopMoveIsPossible(posX, posY, toPosX, toPosY);
                    case "Tower":
                        return TowerMoveIsPossible(posX, posY, toPosX, toPosY);
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

        bool BishopMoveIsPossible(int posX, int posY, int toPosX, int toPosY) {
            otherColorPiece = 0;
            otherPiece = false;
            sameColorBlock = false;
            if (IsChoiceOfMove(posX + (toPosX - posX), posY + (toPosY - posY), toPosX, toPosY)) {
                for (int i = 0; i < toPosY - posY - 1; i++) {
                    if (IsDifferentColor(pieceId, grid[toPosY - 1 + i, toPosX - 1 + i]) == true) {
                        otherPiece = true;
                        otherColorPiece++;
                        if (IsSameColor(pieceId, grid[toPosY - 1 + i, toPosX - 1 + i]) == true) {
                            sameColorBlock = true;
                        }
                    }
                }
                if(otherPiece == false) {
                    return true;
                }
                if (sameColorBlock == false && otherColorPiece < 2 && IsDifferentColor(pieceId, grid[toPosY - 1, toPosX - 1]) == true) {
                    return true;
                }
                return false;

            }


            else if (IsChoiceOfMove(posX - (posX - toPosX), posY - (posY - toPosY), toPosX, toPosY)) {
                for (int i = 0; i < posY - toPosY - 1; i++) {
                    if (IsDifferentColor(pieceId, grid[toPosY - i, toPosX - i]) == true && IsSameColor(pieceId, grid[toPosY + i, toPosX - i]) == true) {
                        otherPiece = true;
                        otherColorPiece++;
                        if (IsSameColor(pieceId, grid[toPosY - i, toPosX - i]) == true) {
                            sameColorBlock = true;
                        }
                    }
                }
                if (otherPiece == false) {
                    return true;
                }
                else if (sameColorBlock == false && otherColorPiece < 2 && IsDifferentColor(pieceId, grid[toPosY - 1, toPosX - 1]) == true) {
                    return true;
                }
                else {
                    return false;
                }
            }

            else if (IsChoiceOfMove(posX - (posX - toPosX), posY + (toPosY - posY), toPosX, toPosY)) {
                for (int i = 0; i < posX - toPosX - 1; i++) {
                    if (IsDifferentColor(pieceId, grid[toPosY - 1, toPosX - 1 + i]) == true && IsSameColor(pieceId, grid[toPosY - 1 + i, toPosX - 1 - i]) == true) {
                        otherPiece = true;
                        otherColorPiece++;
                        if (IsSameColor(pieceId, grid[toPosY - 1, toPosX - 1 + i]) == true) {
                            sameColorBlock = true;
                        }
                    }
                }
                if (otherPiece == false) {
                    return true;
                }
                else if (sameColorBlock == false && otherColorPiece < 2 && IsDifferentColor(pieceId, grid[toPosY - 1, toPosX - 1]) == true) {
                    return true;
                }
                else {
                    return false;
                }
            }

            else if (IsChoiceOfMove(posX + (toPosX - posX), posY - (posY - toPosY), toPosX, toPosY) == true) {
                for (int i = 0; i < toPosX - posX - 1; i++) {
                    if (IsDifferentColor(pieceId, grid[toPosY - 1 + i, toPosX - 1 - i]) == true && IsSameColor(pieceId, grid[toPosY - 1 + i, toPosX - 1 - i]) == true) {
                        otherPiece = true;
                        otherColorPiece++;
                        if (IsSameColor(pieceId, grid[toPosY - 1 + i, toPosX - 1 - i]) == true) {
                            sameColorBlock = true;
                        }
                    }
                }
                if (otherPiece == false) {
                    return true;
                }
                else if (sameColorBlock == false && otherColorPiece < 2 && IsDifferentColor(pieceId, grid[toPosY - 1, toPosX - 1]) == true) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
        }

        bool TowerMoveIsPossible(int posX, int posY, int toPosX, int toPosY) {
            otherColorPiece = 0;
            otherPiece = false;
            sameColorBlock = false;
            if (IsChoiceOfMove(posX, posY + (toPosY - posY), toPosX, toPosY)) {
                for (int i = 0; i < posY - toPosY - 1; i++) {
                    if (CheckIfOtherPiece(pieceId, grid[toPosY - 1 + i, toPosX - 1]) == true) {
                        otherPiece = true;
                        otherColorPiece++;
                        if (IsSameColor(pieceId, grid[toPosY - 1 + i, toPosX - 1]) == true) {
                            sameColorBlock = true;
                        }
                    }
                }
                if (otherPiece == false) {
                    return true;
                }
                else if (sameColorBlock == false && otherColorPiece < 2 && IsDifferentColor(pieceId, grid[toPosY - 1, toPosX - 1]) == true) {
                    return true;
                }
                else {
                    return false;
                }
            }


            else if (IsChoiceOfMove(posX, posY - (posY - toPosY), toPosX, toPosY)) {
                for (int i = 0; i < posY - toPosY - 1; i++) {
                    if (CheckIfOtherPiece(pieceId, grid[toPosY - 1 - i, toPosX - 1]) == true) {
                        otherPiece = true;
                        otherColorPiece++;
                        if (IsSameColor(pieceId, grid[toPosY - 1 - i, toPosX - 1]) == true) {
                            sameColorBlock = true;
                        }
                    }
                }
                if (otherPiece == false) {
                    return true;
                }
                else if (sameColorBlock == false && otherColorPiece < 2 && IsDifferentColor(pieceId, grid[toPosY - 1, toPosX - 1]) == true) {
                    return true;
                }
                else {
                    return false;
                }
            }

            else if (IsChoiceOfMove(posX + (toPosX - posX), posY, toPosX, toPosY)) {
                for (int i = 0; i < posX - toPosX; i++) {
                    if (CheckIfOtherPiece(pieceId, grid[toPosY - 1, toPosX - 1 + i]) == true) {
                        otherPiece = true;
                        otherColorPiece++;
                        if (IsSameColor(pieceId, grid[toPosY - 1, toPosX - 1 + i]) == true) {
                            sameColorBlock = true;
                        }
                    }
                }
                if (otherPiece == false) {
                    return true;
                }
                else if (sameColorBlock == false && otherColorPiece < 2 && IsDifferentColor(pieceId, grid[toPosY - 1, toPosX - 1]) == true) {
                    return true;
                }
                else {
                    return false;
                }
            }

            else if (IsChoiceOfMove(posX - (posX - toPosY), posY, toPosX, toPosY) == true) {
                for (int i = 0; i < posX - toPosX; i++) {
                    if (CheckIfOtherPiece(pieceId, grid[toPosY - 1, toPosX - 1 - i]) == true) {
                        otherPiece = true;
                        otherColorPiece++;
                        if (IsSameColor(pieceId, grid[toPosY - 1, toPosX - 1 - i]) == true) {
                            sameColorBlock = true;
                        }
                    }
                }
                if (otherPiece == false) {
                    return true;
                }
                else if (sameColorBlock == false && otherColorPiece < 2 && IsDifferentColor(pieceId, grid[toPosY - 1, toPosX - 1]) == true) {
                    return true;
                }
                else {
                    return false;
                }
            }
            else {
                return false;
            }
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

        private bool IsSameColor(int pieceId, int otherPieceId) {
            //fjerner til id
            pieceId = pieceId + 9;
            otherPieceId = otherPieceId + 9;

            if (pieces[otherPieceId].Color == pieces[pieceId].Color) {
                return true;
            }
            else {
                return false;
            }
        }

        private bool CheckIfOtherPiece(int pieceId, int otherPieceId) {
            //fjerner til id
            pieceId = pieceId + 9;
            otherPieceId = otherPieceId + 9;

            if (pieces[otherPieceId].Color == "Null") {
                return false;
            }
            else if (pieces[otherPieceId].Color == pieces[pieceId].Color) {
                return true;
            }
            else if (pieces[otherPieceId].Color != pieces[pieceId].Color && pieces[otherPieceId].Color != "Null") {
                return true;
            }
            else { // Samme brik farve eller out of bounds
                return false;
            }
        }

        private bool IsDifferentColor(int pieceId, int otherPieceId) {
            //fjerner til id
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

