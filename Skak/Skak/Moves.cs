using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skak
{
    public class Moves
    {
        ///Den enum under (Pieces) bruges med en offset 
        ///Der skal -6 på hver gang for Null bliver 0
        enum Pieces {
            BlackKing,
            BlackQueen,
            BlackBishop,
            BlackKnight,
            BlackTower,
            BlackPawn,
            Null, //skal bruges som 0
            WhitePawn,
            WhiteTower,
            WhiteKnight,
            WhiteBishop,
            WhiteQueen,
            WhiteKing
        };

        int[,] grid;
        

        #region Check placering eller ramte brikker
        public void SetPiecePositions(){
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
        }
        /*
        public void MovePiecePosition(ref bool change){
            
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    if (BoardCheck(gridRequest[x,y], gridPosition[x,y], ref change) == true)
                    {
                        gridPosition[x, y] = gridRequest[x, y];
                    }
                    
                }
            }
        }

        private bool BoardCheck(string request, string position, ref bool change){
            
            if(request != position)
            {
                change = true;
            }

            return change;
        }
        */
        #endregion

        

    }
}
