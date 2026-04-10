using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3
{
    public sealed class Singleton
    {
        /// <summary>
        /// Konstruktor je viden samo znotraj razreda
        /// </summary>
        private Singleton() 
        {
            Console.WriteLine("Konstruktor je bil poklican!");

            Random rnd = new Random();
            ID = rnd.Next(1, 101);
        }

        public int ID { get; }

        public override string ToString()
        {
            return $"ID: {this.ID}";
        }

        /// <summary>
        /// Uporabimo statično funkcijo, ker za objektno ne moremo narediti instance!
        /// </summary>
        /// <returns></returns>
        public static Singleton GetInstance()
        {
            if(instance == null)
            {
                instance = new Singleton();
            }
            
            return instance;
        }

        // Spremenljivka, ki bo hranila edino instanco razreda
        private static Singleton? instance = null;
    }
    
}
