using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKak
{
    public class Moves
    {
        string[,] gridRequest;
        string[,] gridPosition;

        #region Check placering eller ramte brikker
        public void SetPiecePositions()
        {
            ///Sorte brikker har "s" foran brikkens identitet, hvide har "h"
            ///Rook/Tårn = r, Springer/Knight = h, Bishop/Løber = b
            ///Queen = q, King = k, Pawn = p
            ///
            gridRequest = new string[8, 8]
            {
                { "sr","sh","sb","sq","sk","sb","sh","sr"},
                { "sp","sp","sp","sp","sp","sp","sp","sp"},
                { "n","n","n","n","n","n","n","n"},
                { "n","n","n","n","n","n","n","n"},
                { "n","n","n","n","n","n","n","n"},
                { "n","n","n","n","n","n","n","n"},
                { "hp","hp","hp","hp","hp","hp","hp","hp"},
                { "hr","hh","hb","hq","hk","hb","hh","hr"}
            };

            gridPosition = new string[8, 8]
            {
                { "sr","sh","sb","sq","sk","sb","sh","sr"},
                { "sp","sp","sp","sp","sp","sp","sp","sp"},
                { "n","n","n","n","n","n","n","n"},
                { "n","n","n","n","n","n","n","n"},
                { "n","n","n","n","n","n","n","n"},
                { "n","n","n","n","n","n","n","n"},
                { "hp","hp","hp","hp","hp","hp","hp","hp"},
                { "hr","hh","hb","hq","hk","hb","hh","hr"}
            };
        }

        public void MovePiecePosition(ref bool change)
        {
            
            for (int x = 0; x < gridRequest.GetLength(0); x++)
            {
                for (int y = 0; y < gridRequest.GetLength(1); y++)
                {
                    if (BoardCheck(gridRequest[x,y], gridPosition[x,y], ref change) == true)
                    {
                        gridPosition[x, y] = gridRequest[x, y];
                    }
                    
                }
            }
        }

        private bool BoardCheck(string request, string position, ref bool change)
        {
            
            if(request != position)
            {
                change = true;
            }

            return change;
        }

        #endregion



    }
}
