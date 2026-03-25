using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3
{
    /// <summary>
    /// Pripravimo abstrakten razred - instance tega razreda ne moremo ustvariti
    /// </summary>
    public abstract class ChessPiece
    {
        public ChessPiece(Color color)
        {
            this.Color = color;
            this.IsAlive = true;
            Console.WriteLine("Ustvarili smo šahovsko figuro");
        }

        public Position Position { get; set; }
        public Color Color { get; }
        public bool IsAlive { get; set; }

        /// <summary>
        /// Abstraktna funkcija, ki nima implementirane logike.
        /// </summary>
        public abstract void Move(Position moveTo);
    }

    public class Knight : ChessPiece
    {
        public Knight(Color color) : base(color) { }

        public override void Move(Position moveTo)
        {
            if (
                (this.Position.Column == moveTo.Column + 1 || this.Position.Column == moveTo.Column - 1)
                    &&
                (this.Position.Row == moveTo.Row + 2 || this.Position.Row == moveTo.Row - 2)
                ||
                (this.Position.Column == moveTo.Column + 2 || this.Position.Column == moveTo.Column - 2)
                    &&
                (this.Position.Row == moveTo.Row + 1 || this.Position.Row == moveTo.Row - 1)
               )
                this.Position = moveTo;
            else
                throw new Exception($"Premik na polje { moveTo } ni dovoljen!");
        }
    }

    public class Rook : ChessPiece
    {
        public Rook(Color color) : base(color) { }

        public override void Move(Position moveTo)
        {
            // Preverimo, če ostanemo v stolpcu
            if (this.Position.Column == moveTo.Column || this.Position.Row == moveTo.Row)
                this.Position = moveTo;
            else
            {
                throw new Exception($"Premik na polje {moveTo} ni dovoljen!");
            }
        }
    }

    public enum Color
    {
        Black,
        White
    }

    public struct Position
    {
        private static List<string> lstAllowedColumns = new() { "A", "B", "C", "D", "E", "F", "G", "H" };

        public Position(int col, int lin)
        {
            this.Column = col;
            this.Row = lin;
        }

        private int column;
        public int Column
        {
            get
            {
                return column;
            }
            set
            {
                if (value <= 8 && value >= 1)
                    column = value;
                else
                    throw new ArgumentException("Dani stolpec ne obstaja!");
            }
        }

        private int line;
        public int Row
        {
            get { return line; }
            set
            {
                if (value <= 8 && value >= 1)
                    line = value;
                else
                    throw new ArgumentException("Dana vrstica ne obstaja!");
            }
        }

        public override string ToString()
        {
            return $"{lstAllowedColumns[this.Column - 1]}{this.Row}";
        }
    }
}
