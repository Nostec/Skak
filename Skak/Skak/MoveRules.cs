using System;
namespace Skak {
    class MoveRules : Moves {
        int pieceId;
        int otherColorPiece;
        bool otherPiece;
        bool sameColorBlock;
        bool onFinalPos;
        public int PieceId {
            set => this.pieceId = value;
        }

        public bool MoveAllowedCheck(int posX, int posY, int toPosX, int toPosY) {
            switch (pieces[pieceId+9].Color) {
                case "White":
                    switch (pieces[pieceId+9].Name) {
                        case "Pawn":
                            return (checkIfMoveIsPossible("WhitePawn", posX, posY, toPosX, toPosY));

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
                            return checkIfMoveIsPossible("Queen", posX, posY, toPosX, toPosY);

                        case "King":
                            pieceId -= 9;
                            return checkIfMoveIsPossible("King", posX, posY, toPosX, toPosY);
                    }

                    break;

                case "Black":
                    switch (pieces[pieceId+9].Name) {
                        case "Pawn":
                            return checkIfMoveIsPossible("BlackPawn", posX, posY, toPosX, toPosY);

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
                            return checkIfMoveIsPossible("Queen", posX, posY, toPosX, toPosY);

                        case "King":
                            pieceId += 9;
                            return checkIfMoveIsPossible("King", posX, posY, toPosX, toPosY);
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
                    case "WhitePawn":
                        if(posY == 7 && posY - toPosY == 2) { // If pawn is on start pos (first move), let it move 2 ahead
                            return WhitePawnMoveIsPossible(posX, posY - 1, toPosX, toPosY);
                        }
                        return WhitePawnMoveIsPossible(posX, posY, toPosX, toPosY);
                    case "BlackPawn":
                        if(posY == 2 && toPosY - posY == 2) {
                            return BlackPawnMoveIsPossible(posX, posY + 1, toPosX, toPosY);
                        }
                        return BlackPawnMoveIsPossible(posX, posY, toPosX, toPosY);
                    case "Knight":
                        return SpringerMoveIsPossible(posX, posY, toPosX, toPosY);
                    case "Bishop":
                        return BishopMoveIsPossible(posX, posY, toPosX, toPosY);
                    case "Tower":
                        return TowerMoveIsPossible(posX, posY, toPosX, toPosY);
                    case "King":
                        return KingMoveIsPossible(posX, posY, toPosX, toPosY);
                    case "Queen":
                        return QueenMoveIsPossible(posX, posY, toPosX, toPosY);
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

        private bool IsDifferentColor(int pieceId, int otherPieceId) {
            //fjerner til id
            pieceId += 9;
            otherPieceId += 9;
            if (pieces[otherPieceId].Color == "Null") {
                return true;
            }
            else if (pieces[otherPieceId].Color != pieces[pieceId].Color && pieces[otherPieceId].Color != "Null") {
                checkIfGameEnd(pieceId, otherPieceId);
                return true;
            }
            else { // Samme brik farve eller out of bounds
                return false;
            }
        }

        void checkIfGameEnd(int pieceId, int otherPieceId) {
            if (pieces[otherPieceId].Name == "King") {
                if (Program.Player1Turn == true) {
                    Console.WriteLine("Player1 Won!");
                }
                else {
                    Console.WriteLine("Player2 Won!");
                }
                Console.WriteLine("Press any key to end the game...");
                Console.ReadKey();
                Program.gameEnd = true;
            }
        }

        bool WhitePawnMoveIsPossible(int posX, int posY, int toPosX, int toPosY) {
            if (IsChoiceOfMove(posX - 1, posY - 1, toPosX, toPosY) == true) {
                PawnPromotionCheck(toPosY, posX, posY);
                return true;
            }
            else if (IsChoiceOfMove(posX + 1, posY - 1, toPosX, toPosY) == true) {
                PawnPromotionCheck(toPosY, posX, posY);
                return true;
            }
            else if (IsChoiceOfMove(posX, posY - 1, toPosX, toPosY) == true) {
                int otherPieceId = Moves.grid[toPosY - 1, toPosX - 1];
                otherPieceId += 9;
                if(otherPieceId != 9) {
                    return false;
                }
                PawnPromotionCheck(toPosY, posX, posY);
                return true;
            }
            return false;
        }

        bool BlackPawnMoveIsPossible(int posX, int posY, int toPosX, int toPosY) {
            if (IsChoiceOfMove(posX + 1, posY + 1, toPosX, toPosY) == true) {
                PawnPromotionCheck(toPosY, posX, posY);
                return true;
            }
            else if (IsChoiceOfMove(posX - 1, posY + 1, toPosX, toPosY) == true) {
                PawnPromotionCheck(toPosY, posX, posY);
                return true;
            }
            else if (IsChoiceOfMove(posX, posY + 1, toPosX, toPosY) == true) {
                PawnPromotionCheck(toPosY, posX, posY);
                int otherPieceId = grid[toPosY - 1, toPosX - 1];
                otherPieceId += 9;
                if (otherPieceId != 9) {
                    return false;
                }
                return true;
            }
            return false;
        }

        void PawnPromotionCheck(int toPosY, int posX, int posY) {
            if(toPosY == 1) { // If pawn location is on the furthest Y on the board
                PawnPromotion("White", posX, posY);
            }
            else if (toPosY == 8) { 
                PawnPromotion("Black", posX, posY);
            }
        }

        void PawnPromotion(string Color, int posX, int posY) {
            while (true) {
                Console.Write("Promote pawn to: "); string promotionInput = Console.ReadLine();
                if (promotionInput.Equals("Queen", StringComparison.OrdinalIgnoreCase)) {
                    if (Color == "White") {
                        Visuals.Board[posY, posX] = "Q";
                        Moves.grid[posY - 1, posX - 1] = 8;
                    }
                    else {
                        Visuals.Board[posY, posX] = "q";
                        Moves.grid[posY - 1, posX - 1] = -8;
                    }
                    break;
                }
                else if (promotionInput.Equals("Tower", StringComparison.OrdinalIgnoreCase)) {
                    if (Color == "White") {
                        Visuals.Board[posY, posX] = "R";
                        Moves.grid[posY - 1, posX - 1] = 2;
                    }
                    else {
                        Visuals.Board[posY, posX] = "r";
                        Moves.grid[posY - 1, posX - 1] = -2;
                    }
                    break;
                }
                else if (promotionInput.Equals("Bishop", StringComparison.OrdinalIgnoreCase)) {
                    if (Color == "White") {
                        Visuals.Board[posY, posX] = "B";
                        Moves.grid[posY - 1, posX - 1] = 6;
                    }
                    else {
                        Visuals.Board[posY, posX] = "b";
                        Moves.grid[posY - 1, posX - 1] = -6;
                    }
                    break;
                }
                else {

                }
            }
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
            onFinalPos = false;
            if (posX - toPosX < 0 && posY - toPosY < 0) {
                for (int i = 1; i <= toPosY - posY; i++) {
                    if (CheckIfOtherPiece(pieceId, Moves.grid[posY - 1 + i, posX - 1 + i]) == true) {
                        otherPiece = true;
                        otherColorPiece++;
                        if (IsSameColor(pieceId, Moves.grid[posY - 1 + i, posX - 1 + i]) == true) {
                            sameColorBlock = true;
                        }
                    }
                    if (IsChoiceOfMove(posX + i, posY + i, toPosX, toPosY) == true) {
                        onFinalPos = true;
                    }
                }
                return BishopAndTowerMoveCheck(toPosX, toPosY);
            }
            else if (posX - toPosX > 0 && posY - toPosY > 0) {
                for (int i = 1; i <= posY - toPosY; i++) {
                    if (CheckIfOtherPiece(pieceId, Moves.grid[posY - 1 - i, posX - 1 - i]) == true) {
                        otherPiece = true;
                        otherColorPiece++;
                        if (IsSameColor(pieceId, Moves.grid[posY - 1 - i, posX - 1 - i]) == true) {
                            sameColorBlock = true;
                        }
                    }
                    if (IsChoiceOfMove(posX - i, posY - i, toPosX, toPosY) == true) {
                        onFinalPos = true;
                    }
                }
                return BishopAndTowerMoveCheck(toPosX, toPosY);
            }
            else if ( posX - toPosX < 0 && posY - toPosY > 0) {
                for (int i = 1; i <= toPosX - posX; i++) {
                    if (CheckIfOtherPiece(pieceId, Moves.grid[posY - 1 - i, posX - 1 + i]) == true) {
                        otherPiece = true;
                        otherColorPiece++;
                        if (IsSameColor(pieceId, Moves.grid[posY - 1 - i, posX - 1 + i]) == true) {
                            sameColorBlock = true;
                        }
                    }
                    if (IsChoiceOfMove(posX + i, posY - i, toPosX, toPosY) == true) {
                        onFinalPos = true;
                    }
                }
                return BishopAndTowerMoveCheck(toPosX, toPosY);
            }
            else if (posX - toPosX > 0 && posY - toPosY < 0) {
                for (int i = 1; i <= posX - toPosX; i++) {
                    if (CheckIfOtherPiece(pieceId, Moves.grid[posY - 1 + i, posX - 1 - i]) == true) {
                        otherPiece = true;
                        otherColorPiece++;
                        if (IsSameColor(pieceId, Moves.grid[posY - 1 + i, posX - 1 - i]) == true) {
                            sameColorBlock = true;
                        }
                    }
                    if (IsChoiceOfMove(posX - i, posY + i, toPosX, toPosY) == true) {
                        onFinalPos = true;
                    }
                }
                return BishopAndTowerMoveCheck(toPosX, toPosY);
            }
            else {
                return false;
            }
        }

        bool TowerMoveIsPossible(int posX, int posY, int toPosX, int toPosY) {
            otherColorPiece = 0;
            otherPiece = false;
            sameColorBlock = false;
            if (posY - toPosY > 0) {
                for (int i = 1; i <= posY - toPosY; i++) {
                    if (CheckIfOtherPiece(pieceId, Moves.grid[posY - 1 - i, posX - 1]) == true) {
                        otherPiece = true;
                        otherColorPiece++;
                        if (IsSameColor(pieceId, Moves.grid[posY - 1 - i, posX - 1]) == true) {
                            sameColorBlock = true;
                        }
                    }
                    if (IsChoiceOfMove(posX, posY - i, toPosX, toPosY) == true) {
                        onFinalPos = true;
                    }
                }
                return BishopAndTowerMoveCheck(toPosX, toPosY);
            }
            else if (posY - toPosY < 0) {
                for (int i = 1; i <= toPosY - posY; i++) {
                    if (CheckIfOtherPiece(pieceId, Moves.grid[posY - 1 + i, posX - 1]) == true) {
                        otherPiece = true;
                        otherColorPiece++;
                        if (IsSameColor(pieceId, Moves.grid[posY - 1 + i, posX - 1]) == true) {
                            sameColorBlock = true;
                        }
                    }
                    if (IsChoiceOfMove(posX, posY + i, toPosX, toPosY) == true) {
                        onFinalPos = true;
                    }
                }
                return BishopAndTowerMoveCheck(toPosX, toPosY);

            }
            else if (posX - toPosX > 0) {
                for (int i = 1; i <= posX - toPosX; i++) {
                    if (CheckIfOtherPiece(pieceId, Moves.grid[posY - 1, posX - 1 - i]) == true) {
                        otherPiece = true;
                        otherColorPiece++;
                        if (IsSameColor(pieceId, Moves.grid[posY - 1, posX - 1 - i]) == true) {
                            sameColorBlock = true;
                        }
                    }
                    if (IsChoiceOfMove(posX - i, posY, toPosX, toPosY) == true) {
                        onFinalPos = true;
                    }
                }
                return BishopAndTowerMoveCheck(toPosX, toPosY);
            }
            else if (posX - toPosX < 0) {
                for (int i = 1; i <= toPosX - posX; i++) {
                    if (CheckIfOtherPiece(pieceId, Moves.grid[posY - 1, posX - 1 + i]) == true) {
                        otherPiece = true;
                        otherColorPiece++;
                        if (IsSameColor(pieceId, Moves.grid[posY - 1, posX - 1 + i]) == true) {
                            sameColorBlock = true;
                        }
                    }
                    if (IsChoiceOfMove(posX + i, posY, toPosX, toPosY) == true) {
                        onFinalPos = true;
                    }
                }
                return BishopAndTowerMoveCheck(toPosX, toPosY);
            }
            else {
                return false;
            }
        }

        bool QueenMoveIsPossible(int posX, int posY, int toPosX, int toPosY) {
            if (posX - toPosX < 0 && posY - toPosY < 0) {
                return BishopMoveIsPossible(posX, posY, toPosX, toPosY);
            }
            else if (posX - toPosX > 0 && posY - toPosY < 0) {
                return BishopMoveIsPossible(posX, posY, toPosX, toPosY);
            }
            else if (posX - toPosX < 0 && posY - toPosY > 0) {
                return BishopMoveIsPossible(posX, posY, toPosX, toPosY);
            }
            else if (posX - toPosX > 0 && posY - toPosY > 0) {
                return BishopMoveIsPossible(posX, posY, toPosX, toPosY);
            }
            else if (posY - toPosY > 0) {
                return TowerMoveIsPossible(posX, posY, toPosX, toPosY);
            }
            else if (posY - toPosY < 0) {
                return TowerMoveIsPossible(posX, posY, toPosX, toPosY);
            }
            else if (posX - toPosX > 0) {
                return TowerMoveIsPossible(posX, posY, toPosX, toPosY);
            }
            else if (posX - toPosX < 0) {
                return TowerMoveIsPossible(posX, posY, toPosX, toPosY);
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

        bool BishopAndTowerMoveCheck(int toPosX, int toPosY) {
            if (onFinalPos == true && otherPiece == false && IsDifferentColor(pieceId, Moves.grid[toPosY - 1, toPosX - 1]) == true) {
                return true;
            }
            else if (onFinalPos == true && sameColorBlock == false && otherColorPiece < 2 && IsDifferentColor(pieceId, Moves.grid[toPosY - 1, toPosX - 1]) == true) {
                return true;
            }
            else {
                return false;
            }
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
            else if (pieces[otherPieceId].Color != pieces[pieceId].Color && pieces[otherPieceId].Color != "Null") {
                return false;
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
    }
}

