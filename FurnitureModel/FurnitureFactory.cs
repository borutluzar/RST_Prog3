using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureModel
{
    public static class FurnitureFactory
    {
        public static Furniture? Create(FurnitureType type, Dictionary<ParameterName, string>? dicParameters)
        {
            if (dicParameters == null)
                return null;

            Furniture? furniture;
            switch (type) // Implementirano samo za RockingChair, ostalo za vajo doma!
            {
                case FurnitureType.Sofa:
                    furniture = new Sofa(0, "", 4, "");
                    break;
                case FurnitureType.RockingChair:
                    var rcb = new RockingChairBuilder();
                    rcb.SetName(dicParameters[ParameterName.Name]);
                    rcb.SetPrice(decimal.Parse(dicParameters[ParameterName.Price]));
                    rcb.SetCapacity(int.Parse(dicParameters[ParameterName.Capacity]));
                    rcb.SetIsUpholstered(bool.Parse(dicParameters[ParameterName.IsUpholstered]));
                    rcb.SetRadius(double.Parse(dicParameters[ParameterName.Radius]));
                    rcb.SetHasArmRests(bool.Parse(dicParameters[ParameterName.HasArmRests]));
                    furniture = rcb.Build();
                    break;
                default:
                    furniture = null;
                    break;
            }
            return furniture;
        }
    }

    public interface IFurnitureBuilder
    {
        void SetName(string name);
        void SetPrice(decimal price);
        Furniture Build();
    }

    public interface ISeatingFurnitureBuilder : IFurnitureBuilder
    {
        void SetCapacity(int capacity);
        void SetIsUpholstered(bool isUpholstered);
    }

    public class RockingChairBuilder : ISeatingFurnitureBuilder
    {
        private RockingChair instance = new RockingChair(new Random().Next(0,100_000), "", 0, 0.0);

        public void SetCapacity(int capacity)
        {
            instance.Capacity = capacity;
        }

        public void SetIsUpholstered(bool isUpholstered)
        {
            instance.IsUpholstered = isUpholstered;
        }

        public void SetName(string name)
        {
            instance.Name = name;
        }

        public void SetPrice(decimal price)
        {
            instance.Price = price;
        }

        public void SetRadius(double radius)
        {
            instance.Radius = radius;
        }

        public void SetHasArmRests(bool hasArmRests)
        {
            instance.HasArmRests = hasArmRests;
        }

        public Furniture Build() 
        { 
            return instance;
        }
    }
}
