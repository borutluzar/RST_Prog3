using FurnitureModel;
using RST_Prog3;

namespace FurnitureInventory
{
    internal class Program
    {
        // Za trenutne potrebe bomo osnovne parametre kar fiksno določili
        private const string INVENTORY_NAME = "FIS-STORAGE";
        private const string INVENTORY_ADDRESS = "Bršljin";
        private const int INVENTORY_CAPACITY = 200;

        static void Main(string[] args)
        {
            Console.WriteLine("Pozdravljen uporabnik skladišča!");

            Inventory inventory = Inventory.GetInstance(INVENTORY_NAME, INVENTORY_ADDRESS, INVENTORY_CAPACITY);

            while (true)
            {
                Console.WriteLine($"***  Menu ***");
                Console.WriteLine($"1. Dodajanje artiklov");
                Console.WriteLine($"2. Izpis artiklov v skladišču");
                Console.WriteLine($"3. Izhod iz sistema ");

                Console.Write($"Izberite opcijo: ");
                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write($"Izberite artikel za vnos:");
                        FurnitureType type = AuxiliaryFunctions.ChooseOption<FurnitureType>();

                        Dictionary<ParameterName, string>? dicParameters;
                        switch (type)
                        {
                            case FurnitureType.RockingChair:
                                dicParameters = GetParameterValues(RockingChair.ListOfParameters());
                                break;
                            case FurnitureType.BookShelf:
                                dicParameters = GetParameterValues(BookShelf.ListOfParameters());
                                break;
                            default:
                                dicParameters = null;
                                break;
                        }
                        Furniture? furniture = FurnitureFactory.Create(type, dicParameters);

                        if (furniture != null)
                            inventory.AddItem(furniture);
                        break;
                    case "2":
                        foreach (var fur in inventory.Items)
                        {
                            fur.Display();
                        }
                        break;
                    case "3":
                        Console.Write($"Hvala in nasvidenje!");
                        return;
                }
            }
        }

        private static Dictionary<ParameterName, string> GetParameterValues(List<ParameterName> lstParameterNames)
        {
            Dictionary<ParameterName, string> dicParameters = new();
            foreach (var parName in lstParameterNames)
            {
                Console.Write($"Podajte vrednost za parameter {parName}: ");
                string parVal = Console.ReadLine();

                dicParameters.Add(parName, parVal);
            }
            return dicParameters;
        }
    }
}
