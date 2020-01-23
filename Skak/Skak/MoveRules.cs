namespace Skak {
    class MoveRules : Moves {
        int pieceId;

        public int PieceId {
            set => this.pieceId = value;
        }

        public bool MoveAllowedCheck(int posX, int posY, int toPosX, int toPosY) {
            int otherColorPiece = 0;
            bool otherPiece = false;
            bool sameColorBlock = false;

            switch (pieces[pieceId+9].Color) {
                case "White":
                    switch (pieces[pieceId + 9].Name) {
                        case "Pawn":
                            if (IsChoiceOfMove(posX - 1, posY - 1, toPosX, toPosY) == true && IsDifferentColor(pieceId, grid[toPosY - 1, toPosX - 1]) == true) {
                                return true;
                            }
                            else if (IsChoiceOfMove(posX + 1, posY - 1, toPosX, toPosY) == true && IsDifferentColor(pieceId, grid[toPosY - 1, toPosX - 1]) == true) {
                                return true;
                            }
                            else if (IsChoiceOfMove(posX, posY - 1, toPosX, toPosY) == true && IsDifferentColor(pieceId, grid[toPosY - 1, toPosX - 1]) == true) {
                                return false;
                            }
                            else if (IsChoiceOfMove(posX, posY - 1, toPosX, toPosY) == true && IsDifferentColor(pieceId, grid[toPosY - 1, toPosX - 1]) == false) {
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
                            otherColorPiece = 0;
                            otherPiece = false;
                            sameColorBlock = false;
                            if (IsChoiceOfMove(posX - (posX-toPosX), posY - (posY - toPosY), toPosX, toPosY)) {
                                for (int i = 0; i < posY - toPosY; i++) {
                                    if (CheckIfOtherPiece(pieceId, grid[toPosY - 1 + i, toPosX - 1 + i]) == true) {
                                        otherPiece = true;
                                        otherColorPiece++;
                                        if (IsSameColor(pieceId, grid[toPosY - 1 + i, toPosX - 1 + i]) == true) {
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


                            else if (IsChoiceOfMove(posX - (posX - toPosX), posY - (posY - toPosY), toPosX, toPosY)) {
                                for (int i = 0; i < posY - toPosY; i++) {
                                    if (CheckIfOtherPiece(pieceId, grid[toPosY - 1 - i, toPosX - 1 - i]) == true) {
                                        otherPiece = true;
                                        otherColorPiece++;
                                        if (IsSameColor(pieceId, grid[toPosY - 1 - i, toPosX - 1 - i]) == true) {
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

                            else if (IsChoiceOfMove(posX - (posX - toPosX), posY, toPosX, toPosY)) {
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
                                    if (CheckIfOtherPiece(pieceId, grid[toPosY - 1 + i, toPosX - 1 - i]) == true) {
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

                        case "Tower":
                        case "Tower2":
                            otherColorPiece = 0;
                            otherPiece = false;
                            sameColorBlock = false;
                            if (IsChoiceOfMove(posX, posY - (posY - toPosY), toPosX, toPosY)) {
                                for (int i = 0; i < posY - toPosY; i++) {
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
                                for (int i = 0; i < posY - toPosY; i++) {
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

                            else if (IsChoiceOfMove(posX - (posX - toPosX), posY, toPosX, toPosY)) {
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

                        case "Queen":
                            break;

                        case "King":
                            break;
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

            if(pieces[otherPieceId].Color == "Null") {
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
            pieceId = pieceId + 9;
            otherPieceId = otherPieceId + 9;

            if (pieces[otherPieceId].Color == "Null") {
                return false;
            }
            else if (pieces[otherPieceId].Color != pieces[pieceId].Color || pieces[otherPieceId].Color != "Null") {
                return true;
            }
            else { // Samme brik farve eller out of bounds
                return false;
            }
        }

    }
}

