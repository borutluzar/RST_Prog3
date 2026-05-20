using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3
{
    public interface ITemperatureSensor
    {
        event Action<double> OnTemperatureChanged;
    }

    // Subjekt
    public class TemperatureSensor : ITemperatureSensor
    {
        public event Action<double>? OnTemperatureChanged;        

        // Funkcija za obveščanje
        public void GetTemperature(double newTemp)
        {
            Console.WriteLine($"[Subjekt] Pridobili smo novo temperaturo: {newTemp}");

            OnTemperatureChanged?.Invoke(newTemp);
        }
    }

    // Opazovalca
    public class ConsoleDisplay
    {
        public void UpdateDisplay(double temp)
        {
            Console.WriteLine($"[Observer] Prikazujem trenutno temperaturo: {temp}");
        }
    }

    public class AlarmSystem
    {
        private const double Threshold = 100.0;

        public void CheckTemperature(double temp)
        {
            if(temp >= Threshold)
            {
                Console.WriteLine($"[Observer] Pozor - temperatura je {temp}!");
            }
        }
    }
}
