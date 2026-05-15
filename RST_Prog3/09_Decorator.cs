using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3
{
    public abstract class Pizza
    {
        public abstract string Description { get; }

        public abstract double GetPrice();
    }

    public class Margherita : Pizza
    {
        public override string Description => "Margherita";

        public override double GetPrice()
        {
            return 8.0;
        }
    }

    public class Pepperoni : Pizza
    {
        public override string Description => "Pepperoni";

        public override double GetPrice()
        {
            return 9.5;
        }
    }

    // Razredi decoratorja

    public abstract class ToppingDecorator : Pizza
    {
        protected Pizza pizza;

        protected ToppingDecorator(Pizza pizza)
        {
            this.pizza = pizza;
        }
    }

    // Konkreten decoratorski razred
    public class EggOnPizza : ToppingDecorator
    {
        public EggOnPizza(Pizza pizza) : base(pizza) { }

        public override string Description => this.pizza.Description + " z jajcem";

        public override double GetPrice()
        {
            return this.pizza.GetPrice() + 1.50;
        }
    }

    public class OlivesOnPizza : ToppingDecorator
    {
        public OlivesOnPizza(Pizza pizza) : base(pizza) { }

        public override string Description => this.pizza.Description + " z olivami";

        public override double GetPrice()
        {
            return this.pizza.GetPrice() + 0.75;
        }
    }



    public interface IEventLog
    {
        string WriteEvent();
    }

    public class EventLogger : IEventLog 
    { 
        public string WriteEvent()
        {
            return "Dogodek se je zgodil";
        }
    }

    public abstract class EventDecorator : IEventLog
    {
        protected IEventLog eventLog;

        protected EventDecorator(IEventLog evnt)
        {
            this.eventLog = evnt;
        }

        public abstract string WriteEvent();
    }

    public class UserEventLogger : EventDecorator
    {
        private string user;

        public UserEventLogger(IEventLog evnt, string user) : base(evnt) 
        {
            this.user = user;
        }

        public override string WriteEvent()
        {
            return $"[{this.user}]\t{this.eventLog.WriteEvent()}";
        }
    }
}
