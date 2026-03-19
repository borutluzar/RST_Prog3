using System.Linq.Expressions;
using static RST_Prog3.ObjectsAndProperties;

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

            Console.Read();
        }
    }

}
