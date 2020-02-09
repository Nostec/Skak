namespace Skak {
    class Piece {
        private int id; //den specifikke id på brikken
        private string name; //brikkens navn f.eks. konge, dronning etc.
        private string color; //brikkens farve e.g. sort og hvid

        public int Id {
            get => id;
            set => id = value;
        }

        public string Name {
            get => name;
            set => name = value;
        }

        public string Color {
            get => color;
            set => color = value;
        }
    }



}
