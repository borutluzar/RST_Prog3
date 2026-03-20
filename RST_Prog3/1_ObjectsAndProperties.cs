using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3
{
    public class Table
    {
        private int id; // Če je spremenljivka privatna, izven razreda ne moremo brati niti njene vrednosti
        public string material;
        public string color;
        public Dimensions dimensions;

        /// <summary>
        /// Konstruktor, ki nastavi dani id.
        /// </summary>
        /// <param name="id">Zunaj pridobljeni id.</param>
        public Table(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// Prazen konstruktor s privzeto vrednostjo id-ja.
        /// </summary>
        /*
        public Table()
        {
            this.id = 1;
        }*/

        /// <summary>
        /// Lastnost (property), ki nam omogoči pridobivanje
        /// vrednosti privatne spremenljivke id.
        /// </summary>
        public int ID
        {
            get
            {
                return this.id;
            }
            private set
            {
                this.id = value;
            }
        }

        private double weight;
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value > 100 || value < 0)
                {
                    throw new ArgumentException("Teža ni v intervalu dovoljenih tež!");
                }
                this.weight = value;
            }
        }

        /// <summary>
        /// Samodejno implementirana lastnost (auto-implemented property)
        /// </summary>
        public double Price { get; set; }

        public override string ToString()
        {
            return $"Miza {this.ID}:\n" +
                $"\tDimenzije: {this.dimensions.Width} x {this.dimensions.Depth} x {this.dimensions.Height}\n" +
                $"\tCena: {this.Price}€";
        }

        // Definiramo funkcijo, ki je ne moremo prepisati v podrazredu
        public double GetVolume()
        {
            return dimensions.Width * dimensions.Height * dimensions.Depth;
        }

        // Funkcija je označena kot virtual,
        // zato jo v podrazredu lahko prepišemo
        public virtual double GetArea()
        {
            return dimensions.Width * dimensions.Depth;
        }
    }

    /// <summary>
    /// Vse tri dimenzije objekta.
    /// </summary>
    public struct Dimensions
    {
        /// <summary>
        /// Višina mize
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Širinia mize
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Globina mize
        /// </summary>
        public double Depth { get; set; }
    }
}
