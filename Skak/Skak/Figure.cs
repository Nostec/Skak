using System;
using System.Collections.Generic;
using System.Text;

namespace Skak {
    class Figure {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
    }
    
    class FigureDeclaration {
        Figure Tower = new Figure();
        Figure Horse = new Figure();
        Figure Bishop = new Figure();
        Figure Queen = new Figure();
        Figure King = new Figure();

        void DefineValues() {

        }
    }

    
}
