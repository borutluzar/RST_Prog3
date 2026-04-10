using System;
using System.Collections.Generic;
using System.Text;

namespace FurnitureModel
{
    public static class FurnitureFactory
    {
        public static Furniture? Create(FurnitureType type)
        {
            Furniture? furniture;
            switch (type)
            {
                case FurnitureType.Sofa:
                    furniture = new Sofa(0,"",4,"");
                    break;
                case FurnitureType.RockingChair:
                    furniture = new RockingChair(0, "", 4, 0.0);
                    break;
                default:
                    furniture = null;
                    break;
            }
            return furniture;
        }
    }
}
