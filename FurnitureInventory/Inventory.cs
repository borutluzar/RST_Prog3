using FurnitureModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureInventory
{
    // Singleton za hranjenje podatkov
    public sealed class Inventory
    {
        private Inventory(string name, string address, int capacity) 
        {
            this.Items = new();
            this.Data = new BasicData(name) { Address = address, Capacity = capacity };                        
        }

        private static Inventory? instance = null;

        public static Inventory GetInstance(string name, string address, int capacity)
        {
            if (instance == null)
            {
                instance = new Inventory(name, address, capacity);
            }
            return instance;
        }

        public List<Furniture> Items { get; }

        public void AddItem(Furniture item)
        {
            this.Items.Add(item);
        }

        public BasicData Data { get; }
    }

    public record BasicData
    {
        public BasicData(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public string? Address { get; init; } // init je poseben, omejen set, ki omogoča nastavljanje vrednosti samo ob kreiranju objekta
        public int Capacity { get; init; }
    }
}
