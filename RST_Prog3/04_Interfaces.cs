using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3
{
    public interface IAirCondition
    {
        public double Temperature { get; }

        public void Cooling(double temp);

        public void Heating(double temp);
    }

    public interface IFanSystem
    {
        public int Level { get; set; }
        public bool Rotation { get; set; }
    }

    public interface IVentilation : IAirCondition, IFanSystem
    {
        public int CO2Level { get; set; }
        public void IncreaseAirQuality();
    }

    public class LectureRoom : IVentilation
    {
        public int Capacity {  get; set; }
        public string Location { get; set; }

        
        #region Sklop funkcij za vmesnik IAirCondition

        public double Temperature { get; private set; }
        
        
        // Dve eksplicitni implementaciji lastnosti vmesnika IFanSystem
        int IFanSystem.Level { get; set; }
        bool IFanSystem.Rotation { get; set; }
        int IVentilation.CO2Level { get; set; }

        public void Cooling(double temp)
        {
            Console.WriteLine($"Trenutna temperatura predavalnice je {this.Temperature}");
            if (temp < this.Temperature)
            {
                this.Temperature = temp;
                Console.WriteLine($"Trenutna temperatura predavalnice je {this.Temperature}");
            }
            else
            {
                Console.WriteLine($"Predavalnice s to funkcijo ne moremo greti!");
            }
        }

        public void Heating(double temp)
        {
            Console.WriteLine($"Trenutna temperatura predavalnice je {this.Temperature}");
            if (temp > this.Temperature)
            {
                this.Temperature = temp;
                Console.WriteLine($"Trenutna temperatura predavalnice je {this.Temperature}");
            }
            else
            {
                Console.WriteLine($"Predavalnice s to funkcijo ne moremo hladiti!");
            }
        }

        // Eksplicitna implementacija lastnosti vmesnika IVentilation
        void IVentilation.IncreaseAirQuality()
        {
            Console.WriteLine("Zagnali smo prezračevanje!");
            ((IVentilation)this).CO2Level = 600;
        }

        #endregion

        public void IncreaseAirQuality()
        {
            Console.WriteLine("Odprli smo okno!");
        }
    }

    public class Car : IAirCondition
    {
        public Car(int id) 
        {
            ID = id;
        }

        public int ID { get; }

        public int KW { get; private set; }

        public string Color { get; set; }

        
        #region Sklop funkcij za vmesnik IAirCondition

        public double Temperature 
        {
            get;
            set; // Lahko definiramo tudi set, vendar tega elementa preko interface-a ne bomo videli
        }

        public void Cooling(double temp)
        {
            Console.WriteLine($"Trenutna temperatura vozila je {this.Temperature}");
            if (temp < this.Temperature)
            {
                this.Temperature = temp;
                Console.WriteLine($"Trenutna temperatura vozila je {this.Temperature}");
            }
            else
            {
                Console.WriteLine($"Avtomobila s to funkcijo ne moremo greti!");
            }
        }

        public void Heating(double temp)
        {
            Console.WriteLine($"Trenutna temperatura vozila je {this.Temperature}");
            if (temp > this.Temperature)
            {
                this.Temperature = temp;
                Console.WriteLine($"Trenutna temperatura vozila je {this.Temperature}");
            }
            else
            {
                Console.WriteLine($"Avtomobila s to funkcijo ne moremo hladiti!");
            }
        }
                
        #endregion
    }

    public class Limo : Car
    {
        public Limo(int id) : base(id) { }

        public bool HasMinibar { get; set; }

        public bool HasMidGlass { get; set; }
    }
}
