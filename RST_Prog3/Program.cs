using System.Linq.Expressions;

namespace RST_Prog3
{
    public enum Lecture
    {
        Lecture_01 = 1,  // 16. 3. 2026
        Lecture_02 = 2,  // 20. 3. 2026
        Lecture_03 = 3,  // 25. 3. 2026
        Lecture_04 = 4,  //  7. 4. 2026
        Lecture_05 = 5,  //  9. 4. 2026
        Lecture_06 = 6,  // 10. 4. 2026
        Lecture_07 = 7,  // 13. 4. 2026
        Lecture_08 = 8,  // 23. 4. 2026
        Lecture_09 = 9,  //  6. 5. 2026
        Lecture_10 = 10, // 13. 5. 2026
        Lecture_11 = 11, // 15. 5. 2026
        Lecture_12 = 12, // 20. 5. 2026
        Lecture_13 = 13, // 21. 5. 2026
        Lecture_14 = 14, // 26. 5. 2026
        Lecture_15 = 15, // 28. 5. 2026
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            switch (AuxiliaryFunctions.ChooseOption<Lecture>())
            {
                case Lecture.Lecture_01:
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
                    }
                    break;

                case Lecture.Lecture_02:
                    {
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
                    }
                    break;

                case Lecture.Lecture_03:
                    {
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
                    }
                    break;

                case Lecture.Lecture_04:
                    {
                        // Primeri za vmesnike
                        Car avto = new Car(101) { Temperature = 24 };
                        avto.Cooling(20);

                        IAirCondition avto2 = new Car(102) { Temperature = 20 };
                        avto2.Cooling(24);
                        // Če hočemo dostopati do funkcionalnosti, ki jih ima na voljo Avto,
                        // uporabimo "casting"
                        if (avto2 is Car)
                        {
                            ((Car)avto2).Temperature = 24;
                        }

                        IAirCondition theta = new LectureRoom();
                        theta.Heating(22);
                        //((LectureRoom)theta).Temperature = 35; // Set je private v razredu LectureRoom

                        IVentilation eta = new LectureRoom();
                        eta.IncreaseAirQuality(); // Funkcija definirana eksplicitno za IVentilation
                        ((LectureRoom)eta).IncreaseAirQuality(); // Funkcija iz LectureRoom
                    }
                    break;

                case Lecture.Lecture_05:
                    {
                        // Singleton
                        Singleton singi1 = Singleton.GetInstance();
                        Console.WriteLine(singi1);

                        Singleton singi2 = Singleton.GetInstance();
                        Console.WriteLine(singi2);

                        if (singi1 == singi2) // Obe spremenljivki kažeta na isto instanco
                        {
                            Console.WriteLine("Objekta sta enaka!");
                        }
                        else
                        {
                            Console.WriteLine("Objekta nista enaka!");
                        }

                        SecureInformationSystem sis = new();
                        sis.SystemLogin("Borut");
                        sis.ViewVacationList("Borut");
                        sis.SalaryDataLookup("Borut");
                        sis.ViewVacationList("Borut");
                        sis.SystemLogout("Borut");                        
                    }
                    break;

                case Lecture.Lecture_06:
                    {
                        // Factory

                        // Na banki želimo pridobiti kreditno kartico                        
                        // Najprej izberemo tip kartice
                        Console.WriteLine("Izberite tip kreditne kartice:\n");

                        CreditCardType type = AuxiliaryFunctions.ChooseOption<CreditCardType>();

                        Console.Write("Vnesite ime nosilca kartice: ");
                        string holderName = Console.ReadLine() ?? string.Empty;

                        ICreditCard? mojaKreditna = CardFactory.CreateCreditCard(type, holderName, "4106", "546");

                        if(mojaKreditna != null)
                            Console.WriteLine($"Limit na moji kartici je {mojaKreditna.Limit}");                        
                    }
                    break;

                case Lecture.Lecture_07:
                    {
                        // Builder 
                        ComputerFactory factory = new ComputerFactory();
                        Laptop laptop = (Laptop)factory.Create(ComputerType.GamingLaptop);
                        laptop?.DisplaySpecs();
                    }
                    break;

                case Lecture.Lecture_08:
                    {
                        // Delali smo nalogo WildlifeReserve!
                    }
                    break;
            }
            Console.Read();
        }
    }

}
