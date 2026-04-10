using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureModel
{
    public interface IAssemblyRequired
    {
        public string AssemblyInstructions();
        public List<string> AssemblyTools();
    }

    public interface IOutdoorDurable
    {
        public int WeatherResistanceLevel { get; }
        public int MinTemperature { get; }
    }
}
