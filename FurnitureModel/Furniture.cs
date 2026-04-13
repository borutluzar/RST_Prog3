namespace FurnitureModel
{
    public enum FurnitureType
    {
        Sofa = 1,
        RockingChair = 2,
        GardenChair = 3,
        BedroomCloset = 4,
        BookShelf = 5
    }

    public enum ParameterName
    {
        Name = 1,
        Price = 2,
        Capacity = 3,
        IsUpholstered = 4,
        Radius = 5,
        HasArmRests = 6,
    }

    public abstract class Furniture : IParameterPassing, IViewable
    {
        public int ID { get; }

        public decimal Price { get; set; }

        public string Name { get; internal set; }

        internal Furniture(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public static List<ParameterName> ListOfParameters()
        {
            return new List<ParameterName>() { ParameterName.Name, ParameterName.Price };
        }

        public virtual void Display()
        {
            Console.WriteLine($"{Name} - {Price} eur");
        }
    }

    public abstract class SeatingFurniture : Furniture
    {
        public int Capacity { get; internal set; }
        public bool IsUpholstered { get; set; }

        internal SeatingFurniture(int id, string name, int cap) : base(id, name)
        {
            this.Capacity = cap;
        }

        public static new List<ParameterName> ListOfParameters()
        {
            var lst = Furniture.ListOfParameters();
            lst.Add(ParameterName.Capacity);
            lst.Add(ParameterName.IsUpholstered);

            return lst;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"\nKapaciteta: {Capacity}, Oblazinjen: {(IsUpholstered ? "Da" : "Ne")}");
        }
    }

    public abstract class StorageFurniture : Furniture
    {
        public int MaxWeightCapacity { get; }
        public Material Material { get; }

        internal StorageFurniture(int id, string name, int maxCap, Material mat) : base(id, name)
        {
            this.MaxWeightCapacity = maxCap;
            this.Material = mat;
        }
    }

    public enum Material
    {
        Wood,
        Glass,
        Stone,
        Plastic
    }

    public class RockingChair : SeatingFurniture
    {
        public double Radius { get; internal set; } 
        public bool HasArmRests { get; set; }

        internal RockingChair(int id, string name, int cap, double rad) : base(id, name, cap)
        {
            this.Radius = rad;
        }

        public static new List<ParameterName> ListOfParameters()
        {
            var lst = SeatingFurniture.ListOfParameters();
            lst.Add(ParameterName.Radius);
            lst.Add(ParameterName.HasArmRests);

            return lst;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"\nRadij loka: {Radius}, Naslonjala: {(HasArmRests ? "Da" : "Ne")}");
        }
    }

    public class GardenChair : SeatingFurniture, IOutdoorDurable, IAssemblyRequired
    {
        public int LegCount { get; }

        public int WeatherResistanceLevel => 5;

        public int MinTemperature => -10;

        internal GardenChair(int id, string name, int cap, int legs) : base(id, name, cap)
        {
            this.LegCount = legs;
        }

        public string AssemblyInstructions()
        {
            return "Sestavi po teh navodilih!";
        }

        public List<string> AssemblyTools()
        {
            return new List<string>() { "kladivo", "izvijač" };
        }
    }

    public class Sofa : SeatingFurniture
    {
        public string FabricType { get; set; }

        internal Sofa(int id, string name, int cap, string fabType) : base(id, name, cap)
        {
            this.IsUpholstered = true;
            this.FabricType = fabType;
        }
    }

    public class BedroomCloset : StorageFurniture
    {
        public int DoorCount { get; set; }

        internal BedroomCloset(int id, string name, int maxCap, Material mat) : base(id, name, maxCap, mat) { }
    }

    public class BookShelf : StorageFurniture, IAssemblyRequired
    {
        public int ShelfCount { get; set; }

        public bool IsWallMounted { get; set; }

        internal BookShelf(int id, string name, int maxCap, Material mat) : base(id, name, maxCap, mat) { }

        public string AssemblyInstructions()
        {
            return "Polico po polico";
        }

        public List<string> AssemblyTools()
        {
            return new List<string>() { "izvijač" };
        }
    }
}
