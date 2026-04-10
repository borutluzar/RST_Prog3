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

            Inventory skladisce = Inventory.GetInstance(INVENTORY_NAME, INVENTORY_ADDRESS, INVENTORY_CAPACITY);
                        
            Console.WriteLine($"***  Menu ***");
            Console.WriteLine($"1. Dodajanje artiklov ");
            Console.WriteLine($"2. Izhod iz sistema ");

            Console.Write($"Izberite opcijo: ");
            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write($"Izberite artikel za vnos:");
                    FurnitureType type = AuxiliaryFunctions.ChooseOption<FurnitureType>();

                    //FurnitureFactory.
                    break;
                case "2":
                    Console.Write($"Hvala in nasvidenje!");
                    break;
            }
        }
    }
}
