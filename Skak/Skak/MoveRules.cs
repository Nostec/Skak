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
                            
                            if (IsChoiceOfMove(posX - 1, posY - 1, toPosX, toPosY) == true && CompareColors(pieceId, grid[toPosY-1, toPosX-1]) == true) {
                                return true;
                            }
                            else if (IsChoiceOfMove(posX + 1, posY - 1, toPosX, toPosY) == true && CompareColors(pieceId, grid[toPosY-1, toPosX+1]) == true) {
                                return true;
                            }
                            else if (IsChoiceOfMove(posX, posY - 1, toPosX, toPosY) == true && CompareColors(pieceId, grid[toPosY-1, toPosX]) == true) {
                                return false;
                            }
                            else if (IsChoiceOfMove(posX, posY - 1, toPosX, toPosY) == true && CompareColors(pieceId, grid[toPosY-1, toPosX]) == false) {
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

                case "Black":
                    switch (pieces[pieceId].Name) {
                        case "Pawn":
                            if (CompareColors(pieceId, grid[posY + 1, posX - 1]) == true) {
                                return true;
                            }
                            else if (CompareColors(pieceId, grid[posY + 1, posX + 1]) == true) {
                                return true;
                            }
                            else if (CompareColors(pieceId, grid[posY + 1, posX]) == true) {
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

        private bool CompareColors(int pieceId, int otherPieceId) {
            //fjerner til id
            pieceId = pieceId + 9;
            otherPieceId = otherPieceId + 9;
            if (pieces[otherPieceId].Color == "Null") {
                return false;
            }
            else if (pieces[otherPieceId].Color != pieces[pieceId].Color || pieces[otherPieceId].Color != "Null") {
                return true;
            }
            else {
                return false;
            }
        }

    }
}
