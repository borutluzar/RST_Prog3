using System.Linq.Expressions;

namespace RST_Prog3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Table miza1 = new Table(1)
            {
                dimensions = new Dimensions() { Depth = 0.5, Width = 1.0, Height = 0.8 }
            };
            // id je private, zato ga ne moremo določiti.
            //miza1.id = 2;

            // Lastnosti ID lahko nastavimo vrednost samo, če ima definiran 
            // element set, ki nima določila private
            //miza1.ID = 2;

            miza1.Weight = 2.4;
            miza1.Price = 399.99;

            Console.WriteLine($"Imamo mizo z id-jem {miza1.ID}");

            // Kreiramo še nov indeks:
            Index index = new Index(20, StudyProgram.RST);
            index.Year = 2;

            Subject prog3 = new Subject(1) 
            { 
                Name = "Programiranje 3", 
                Grade = 10, 
                ECTS = 6, 
                DateCompleted = new DateOnly(2026, 6, 4) 
            };
            Subject baze = new Subject(2)
            {
                Name = "Baze in modeliranje podatkov",
                Grade = 10,
                ECTS = 6,
                DateCompleted = new DateOnly(2026, 6, 10)
            };

            index.Subjects.Add(prog3);
            index.Subjects.Add(baze);

            Console.WriteLine($"{index}");
            Console.Read();
        }
    }

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
        public Table()
        {
            this.id = 1;
        }

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
                if(value > 100 || value < 0)
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
