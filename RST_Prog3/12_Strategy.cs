using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3.Strategy
{
    public abstract class Employee
    {
        public string FamilyName { get; set; }
        public string GivenName { get; set; }

        public Employee(string famName, string givenName, ISalaryStrategy salaryStrat)
        {
            this.FamilyName = famName;
            this.GivenName = givenName;
            this.SalaryStrategy = salaryStrat;
        }

        public ISalaryStrategy SalaryStrategy { get; set; }
        public void PaySalary(string bankAccount, int numberOfPromotions)
        {
            decimal amount = this.SalaryStrategy.ComputeSalary(numberOfPromotions);
            Console.WriteLine($"Vaša plača v znesku {amount} je bila nakazana na račun {bankAccount}.");
        }

        public IForeignLanguageSpeaker LanguageStrategy { get; protected set; }
        public void SpeakForeignLanguage(string lang)
        {
            //Console.WriteLine($"Govorim {lang}.");
            if(this.LanguageStrategy != null)
                this.LanguageStrategy.SpeakForeignLanguage(lang);
            else
                Console.WriteLine($"Strategija za to instanco ni implementirana.");
        }

        public void ReadForeignLanguage(string lang)
        {
            this.LanguageStrategy.ReadForeignLanguage(lang);
        }

        public virtual void WorkDuties()
        {
            Console.WriteLine($"Opravljam vse obveznosti, ki mi jih naložijo.");
        }
    }

    public class Researcher : Employee
    {
        public Researcher(string famName, string givenName) : base(famName, givenName, new ResearcherSalary()) 
        {
            this.LanguageStrategy = new SpeakForeignLanguageFluently();
        }

        public Researcher(string famName, string givenName, IForeignLanguageSpeaker langStrat) : base(famName, givenName, new ResearcherSalary())
        {
            this.LanguageStrategy = langStrat;
        }

        public override void WorkDuties()
        {
            base.WorkDuties();
            Console.WriteLine($"Vneto raziskujem.");
        }

        public void WriteProjectApplication()
        {
            Console.WriteLine($"Pišem raziskovalna vprašanja.");
        }
    }

    public class Lecturer : Employee
    {
        public Lecturer(string famName, string givenName) : base(famName, givenName, new ResearcherSalary()) 
        {
            this.LanguageStrategy = new SpeakForeignLanguageSoSo();
        }

        public override void WorkDuties()
        {
            base.WorkDuties();
            Console.WriteLine($"Vneto predavam.");
        }

        public void WriteProjectApplication()
        {
            Console.WriteLine($"Pišem raziskovalna vprašanja.");
        }
    }

    public class PRPerson : Employee
    {
        public PRPerson(string famName, string givenName) : base(famName, givenName, new ProfessionalSalary()) 
        {
            this.LanguageStrategy = new SpeakForeignLanguageFluently();
        }

        public override void WorkDuties()
        {
            base.WorkDuties();
            Console.WriteLine($"Pripravljam spletne kampanje.");
        }
    }

    public class Janitor : Employee
    {
        public Janitor(string famName, string givenName) : base(famName, givenName, new TechnicalSalary()) 
        {
            this.LanguageStrategy = new SpeakForeignLanguageNot();
        }

        public override void WorkDuties()
        {
            base.WorkDuties();
            Console.WriteLine($"Menjam baterije v uri.");
        }
    }


    // Vmesnik za strategy
    public interface IForeignLanguageSpeaker
    {
        void SpeakForeignLanguage(string lang);

        void ReadForeignLanguage(string lang);
    }

    // Razredi za posamezne strategije
    public class SpeakForeignLanguageFluently : IForeignLanguageSpeaker
    {
        public void ReadForeignLanguage(string lang)
        {
            Console.WriteLine($"V jeziku {lang} berem zelo dobro!");
        }

        public void SpeakForeignLanguage(string lang)
        {
            Console.WriteLine($"Jezik {lang} govorim zelo dobro!");
        }
    }

    public class SpeakForeignLanguageSoSo : IForeignLanguageSpeaker
    {
        public void ReadForeignLanguage(string lang)
        {
            Console.WriteLine($"V jeziku {lang} berem bolj tako tako!");
        }

        public void SpeakForeignLanguage(string lang)
        {
            Console.WriteLine($"Jezik {lang} govorim bolj tako tako!");
        }
    }

    public class SpeakForeignLanguageNot : IForeignLanguageSpeaker
    {
        public void ReadForeignLanguage(string lang)
        {
            Console.WriteLine($"V jeziku {lang} ne berem!");
        }

        public void SpeakForeignLanguage(string lang)
        {
            Console.WriteLine($"Jezik {lang} ne govorim!");
        }
    }


    public interface ISalaryStrategy
    {
        decimal ComputeSalary(int numberOfPromotitions);
    }

    public class ResearcherSalary : ISalaryStrategy
    {
        public decimal ComputeSalary(int numberOfPromotitions)
        {
            return 5000 + numberOfPromotitions * 500;
        }
    }

    public class ProfessionalSalary : ISalaryStrategy
    {
        public decimal ComputeSalary(int numberOfPromotitions)
        {
            return 4500 + numberOfPromotitions * 400;
        }
    }

    public class TechnicalSalary : ISalaryStrategy
    {
        public decimal ComputeSalary(int numberOfPromotitions)
        {
            return 6000 + numberOfPromotitions * 100;
        }
    }
}
