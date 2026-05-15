using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3
{
    // Razred naredimo kot statičen, saj vsebuje le statično funkcijo,
    // nikoli pa ga ne bomo instancirali.
    public static class CardFactory
    {
        public static CreditCard? CreateCreditCard(CreditCardType type, string holderName, string cardNumber, string securityCode)
        {
            CreditCard? mojaKreditna;
            switch (type)
            {
                case CreditCardType.Silver:
                    mojaKreditna = new SilverCard(holderName, cardNumber, securityCode);
                    break;
                case CreditCardType.Gold:
                    mojaKreditna = new GoldCard(holderName, cardNumber, securityCode);
                    break;
                case CreditCardType.Platinum:
                    mojaKreditna = new PlatinumCard(holderName, cardNumber, securityCode);
                    break;
                case CreditCardType.Student:
                    mojaKreditna = new StudentCard(holderName, cardNumber, securityCode);
                    break;
                case CreditCardType.Diamond:
                    mojaKreditna = new DiamondCard(holderName, cardNumber, securityCode);
                    break;
                default:
                    Console.WriteLine("Ta tip kartice ne obstaja!");
                    mojaKreditna = null;
                    break;
            }
            return mojaKreditna;
        }
    }


    public enum CreditCardType
    {
        Silver = 1,
        Gold = 2,
        Platinum = 3,
        Student = 4,
        Diamond = 5
    }

    public interface ICreditCard
    {
        decimal Limit { get; }
        double AnnualCharge { get; }
        CreditCardType CreditCardType { get; }
    }

    public abstract class CreditCard : ICreditCard
    {
        public string CardHolderName { get; }
        public string CardNumber { get; }
        public DateOnly ExpirationDate { get; }
        public string SecurityCode { get; }


        // Lastnosti kreditne kartice definiramo kot abstraktne,
        // in s tem podrazrede prisilimo v razmislek o specifični
        // implementaciji getterja
        public abstract decimal Limit { get; }
        public abstract double AnnualCharge { get; }
        public abstract CreditCardType CreditCardType { get; }

        internal CreditCard(string holderName, string cardNumber, string securityCode)
        {
            this.CardHolderName = holderName;
            this.CardNumber = cardNumber;
            this.SecurityCode = securityCode;
        }
    }

    public class SilverCard : CreditCard
    {
        internal SilverCard(string holderName, string cardNumber, string securityCode)
            : base(holderName, cardNumber, securityCode) { }

        public override decimal Limit => 800; // enako kot: public decimal Limit { get { return 800; } }
        public override double AnnualCharge => 20;
        public override CreditCardType CreditCardType => CreditCardType.Silver;
    }

    public class GoldCard : CreditCard
    {
        internal GoldCard(string holderName, string cardNumber, string securityCode)
            : base(holderName, cardNumber, securityCode) { }

        public override decimal Limit => 2000;
        public override double AnnualCharge => 50;
        public override CreditCardType CreditCardType => CreditCardType.Gold;
    }

    public class PlatinumCard : CreditCard
    {
        internal PlatinumCard(string holderName, string cardNumber, string securityCode)
            : base(holderName, cardNumber, securityCode) { }

        public override decimal Limit => 5000;
        public override double AnnualCharge => 100;
        public override CreditCardType CreditCardType => CreditCardType.Platinum;
    }

    public class StudentCard : CreditCard
    {
        internal StudentCard(string holderName, string cardNumber, string securityCode)
            : base(holderName, cardNumber, securityCode) { }

        public override decimal Limit => 500;
        public override double AnnualCharge => 10;
        public override CreditCardType CreditCardType => CreditCardType.Student;
    }

    public class DiamondCard : CreditCard
    {
        internal DiamondCard(string holderName, string cardNumber, string securityCode)
            : base(holderName, cardNumber, securityCode) { }

        public override decimal Limit => 50_000;
        public override double AnnualCharge => 1000;
        public override CreditCardType CreditCardType => CreditCardType.Diamond;
    }
}
