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
        

        private bool MoveAllowedCheck() {
            switch (pieces[pieceId].Color) {
                case "White":
                    switch (pieces[pieceId].Name) {
                        case "Pawn":
                            if (CompareColors(pieceId, grid[posY - 1, posX - 1]) == true) {
                                return true;
                            }
                            else if (CompareColors(pieceId, grid[posY - 1, posX + 1]) == true) {
                                return true;
                            }
                            else if (CompareColors(pieceId, grid[posY - 1, posX]) == true) {
                                return false;
                            }
                            else if (CompareColors(pieceId, grid[posY - 1, posX]) == false) {
                                return true;
                            }
                            else {//error message: move cannot be made
                                return false;
                            }

                        case "Knight":
                        case "Knight2":
                            if(CompareColors(pieceId, grid[posY + 2, posX - 1]) == true) {
                                return true;
                            }
                            else if(CompareColors(pieceId, grid[posY + 2, posX + 1]) == true) {
                                return true;
                            }
                            else if(CompareColors(pieceId, grid[posY + 1, posX - 1]) == true) {
                                return true;
                            }
                            else if (CompareColors(pieceId, grid[posY + 1, posX + 1]) == true) {
                                return true;
                            }
                            
                            else if (CompareColors(pieceId, grid[posY - 2, posX - 1]) == true) {
                                return true;
                            }
                            else if (CompareColors(pieceId, grid[posY - 2, posX + 1]) == true) {
                                return true;
                            }
                            else if (CompareColors(pieceId, grid[posY - 1, posX - 1]) == true) {
                                return true;
                            }
                            else if (CompareColors(pieceId, grid[posY - 1, posX + 1]) == true) {
                                return true;
                            }

                            else {
                                return false;
                            }

                            break;

                        case "Bishop":
                        case "Bishop2":
                            break;

                        case "Tower":
                        case "Tower2"
                        :
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

        private bool CompareColors(int pieceId, int otherPieceId) {
            if (pieces[otherPieceId].Color != pieces[pieceId].Color && pieces[otherPieceId].Color != "Null") {
                return true;
            }
            else {
                return false;
            }
        }

    }
}
