using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3
{
    public interface IStockObserver
    {
        void Update(double stockPrice);
    }

    public interface IStockSubject
    {
        void Subscribe(IStockObserver observer);
        void Unsubscribe(IStockObserver observer);

        void NotifyAll();
    }

    public class StockMarket : IStockSubject
    {
        private List<IStockObserver> lstObservers = new();
        private double stockPrice;

        public void GetStockPriceFromAPI(double newStockPrice)
        {
            this.stockPrice = newStockPrice;

            // Obvestimo vse opazovalce
            NotifyAll();
        }

        public void NotifyAll()
        {
            foreach(var observer in this.lstObservers)
            {
                observer.Update(this.stockPrice);
            }
        }

        public void Subscribe(IStockObserver observer)
        {
            this.lstObservers.Add(observer);
        }

        public void Unsubscribe(IStockObserver observer)
        {
            this.lstObservers.Remove(observer);
        }
    }

    public class EmailObserver : IStockObserver
    {
        private string email;
        private double notifyLowerBound;
        private double notifyUpperBound;

        public EmailObserver(string email, double lb, double ub)
        {
            this.email = email;
            this.notifyLowerBound = lb;
            this.notifyUpperBound = ub;
        }

        public void Update(double stockPrice)
        {
            if(stockPrice > this.notifyUpperBound)
            {
                Console.WriteLine($"[Observer] Cena delnice je zrasla na {stockPrice:C} - PRODAJ!");
            }
            else if(stockPrice < this.notifyLowerBound)
            {
                Console.WriteLine($"[Observer] Cena delnice je padla na {stockPrice:C} - KUPI!");
            }
        }
    }

    public class DisplayObserver : IStockObserver
    {
        private List<double> lstStockPriceHistory = new();

        public void Update(double stockPrice)
        {
            this.lstStockPriceHistory.Add(stockPrice);
            Console.WriteLine($"[Observer] Tečaj {stockPrice} je bil zabeležen v zgodovino!");
        }

        public void GetStatistics()
        {
            Console.WriteLine($"Skupno število meritev v zgodovini je {this.lstStockPriceHistory.Count}");
        }
    }
}
