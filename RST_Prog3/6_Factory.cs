using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3
{
    public class Factory
    {
    }


    public enum CreditCardType
    {
        Silver = 1,
        Gold = 2,
        Platinum = 3,
        Student = 4
    }

    public interface ICreditCard
    {
        decimal Limit { get; }
        double AnnualCharge { get; }
        CreditCardType CreditCardType { get; }
    }

    internal abstract class CreditCard : ICreditCard
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

        public CreditCard(string holderName, string cardNumber, string securityCode)
        {
            this.CardHolderName = holderName;
            this.CardNumber = cardNumber;
            this.SecurityCode = securityCode;                       
        }
    }

    internal class SilverCard : CreditCard
    {
        public SilverCard(string holderName, string cardNumber, string securityCode) 
            : base(holderName, cardNumber, securityCode) { }

        public override decimal Limit => 800; // enako kot: public decimal Limit { get { return 800; } }
        public override double AnnualCharge => 20;
        public override CreditCardType CreditCardType => CreditCardType.Silver;
    }
    
    internal class GoldCard : CreditCard
    {
        public GoldCard(string holderName, string cardNumber, string securityCode)
            : base(holderName, cardNumber, securityCode) { }

        public override decimal Limit => 2000;
        public override double AnnualCharge => 50;
        public override CreditCardType CreditCardType => CreditCardType.Gold;
    }

    internal class PlatinumCard : CreditCard
    {
        public PlatinumCard(string holderName, string cardNumber, string securityCode)
            : base(holderName, cardNumber, securityCode) { }

        public override decimal Limit => 5000;
        public override double AnnualCharge => 100;
        public override CreditCardType CreditCardType => CreditCardType.Platinum;
    }

    internal class StudentCard : CreditCard
    {
        public StudentCard(string holderName, string cardNumber, string securityCode)
            : base(holderName, cardNumber, securityCode) { }

        public override decimal Limit => 500;
        public override double AnnualCharge => 10;
        public override CreditCardType CreditCardType => CreditCardType.Student;
    }
}
