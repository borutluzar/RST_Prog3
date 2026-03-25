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

            ClubTable klubska = new ClubTable(2);
            DiningTable jedilna = new DiningTable(3, 6);
            GameTable igralna = new GameTable(4, GameType.Poker);
            OfficeTable pisalna = new OfficeTable(5);

            // Vse instance dodamo na seznam, ki kot elemente dobi instance
            // razreda Table, saj so vsi podrazredi Table tudi instance le-te
            List<Table> lstTables = new List<Table>()
            {
                klubska,
                jedilna,
                igralna,
                pisalna
            };

            foreach (var tab in lstTables)
            {
                // Za vsako instanco se pokliče funkcija ToString,
                // ki je definirana v hierarhiji dedovanja najbližje k dejanskemu razredu instance
                Console.WriteLine($"Miza tipa {tab.GetType()} \n" +
                    $"{tab.ToString()}");

                if (tab is OfficeTable)
                {
                    // Pokličemo ToString, ki smo ga definirali kot new (nismo ga prepisali)
                    Console.WriteLine(((OfficeTable)tab).ToString());
                }
            }

            // Instance ne moremo kreirati
            //ChessPiece figura = new ChessPiece();

            Knight konj = new Knight(Color.White)
            {
                Position = new Position(2, 1),
            };
            Console.WriteLine($"Figura je na poziciji {konj.Position}");
            konj.Move(new Position(3, 3));
            Console.WriteLine($"Premikamo...");
            Console.WriteLine($"Figura je na poziciji {konj.Position}");

            Rook top = new Rook(Color.Black)
            {
                Position = new Position(1, 8),
            };
            Console.WriteLine($"Figura je na poziciji {top.Position}");
            top.Move(new Position(1, 3));
            Console.WriteLine($"Premikamo...");
            Console.WriteLine($"Figura je na poziciji {top.Position}");

            Console.Read();
        }
    }

}
