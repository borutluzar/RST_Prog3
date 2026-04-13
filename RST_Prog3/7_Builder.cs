using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3
{
    public abstract class Computer
    {
        public abstract string Processor { get; set; }
        public abstract string RAM { get; set; }
        public abstract string GraphicsCard { get; set; }

        public List<string> Ports { get; }

        internal Computer()
        {
            this.Ports = new List<string>();
        }

        public void DisplaySpecs()
        {
            Console.WriteLine($"Specifications of computer: " +
                $"\n\tProcessor: {this.Processor}" +
                $"\n\tRAM: {this.RAM}" +
                $"\n\tGPU: {this.GraphicsCard}" +
                $"\n\tPorts: {string.Join(", ", this.Ports)}");
        }
    }

    public class Laptop : Computer
    {
        public override string Processor { get; set; }
        public override string RAM { get; set; }
        public override string GraphicsCard { get; set; }
        public int BatteryDuration { get; set; }

        internal Laptop() { }

        // Po "starem" bi za zagotovitev določanja obveznih lastnosti
        // uporabili kombinacije konstruktorjev z različnimi parametri
        internal Laptop(string proc, string ram, string gpu) : this(proc, ram, gpu, null) { }

        internal Laptop(string proc, string ram, string gpu, List<string>? ports) 
        {
            this.Processor = proc;
            this.RAM = ram;
            this.GraphicsCard = gpu;

            if(ports != null)
                this.Ports.AddRange(ports);
        }
    }

    public class PC : Computer
    {
        public override string Processor { get; set; }
        public override string RAM { get; set; }
        public override string GraphicsCard { get; set; }
        public List<string> Accessories { get; } = new List<string>();

        internal PC() { }
    }

    /// <summary>
    /// Vmesnik, ki poda načrt kreiranja instance razreda Computer
    /// </summary>
    public interface IComputerBuilder
    {
        void SetProcessor(string proc);
        void SetRAM(string ram);
        void SetGraphics(string gpu);
        void AddPort(string port);

        Computer Build();
    }

    /// <summary>
    /// Razred, ki nam po korakih zgradi instanco razreda Laptop
    /// </summary>
    public class LaptopBuilder : IComputerBuilder
    {
        private Laptop builderInstance = new Laptop();

        public void SetProcessor(string proc)
        {
            builderInstance.Processor = proc;
        }

        public void SetRAM(string ram)
        {
            builderInstance.RAM = ram;
        }

        public void SetGraphics(string gpu)
        {
            builderInstance.GraphicsCard = gpu;
        }

        public void AddPort(string port)
        {
            builderInstance.Ports.Add(port);
        }

        public Computer Build()
        {
            return builderInstance;
        }
    }

    public enum ComputerType
    {
        GamingLaptop = 1,
        OfficeLaptop = 2,
        GamingPC = 3
    }

    public class ComputerFactory
    {
        private IComputerBuilder builder;

        public Computer? Create(ComputerType type)
        {
            Computer? instance = null;

            switch (type)
            {
                case ComputerType.GamingLaptop:
                    builder = new LaptopBuilder();
                    instance = BuildGamingLaptop();
                    break;
                case ComputerType.OfficeLaptop:
                    builder = new LaptopBuilder();
                    instance = BuildOfficeLaptop();
                    break;
            }

            return instance;
        }

        private Computer BuildGamingLaptop()
        {
            builder.SetProcessor("intel i9");
            builder.SetRAM("32GB");
            builder.SetGraphics("NVIDIA RTX 4080");
            builder.AddPort("HDMI");
            builder.AddPort("USB-C");
            return builder.Build();
        }

        private Computer BuildOfficeLaptop()
        {
            builder.SetProcessor("intel i5");
            builder.SetRAM("16GB");
            builder.SetGraphics("Integrated");
            builder.AddPort("USB-A");
            return builder.Build();
        }
    }
}
