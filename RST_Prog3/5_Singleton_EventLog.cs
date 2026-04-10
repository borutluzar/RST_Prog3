using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3
{
    public sealed class EventLog
    {
        private EventLog() 
        {
            fileName = $"events_{DateTime.Now:yyyy-MM-dd__HH-mm-ss}.evt";
        }

        private string fileName;

        public void WriteEvent(string message)
        {
            StreamWriter sw = new StreamWriter(fileName, true);
            sw.WriteLine($"Zgodil se je dogodek v času {DateTime.Now:HH:mm:ss}");
            sw.WriteLine(message + "\n");
            sw.Close();
        }

        private static EventLog? instance = null;

        public static EventLog GetInstance()
        { 
            if(instance == null)
            {
                instance = new EventLog();
            }
            return instance;
        }
    }


    public class SecureInformationSystem
    {
        public SecureInformationSystem()
        {
            //this.EventLog = EventLog.GetInstance();
        }

        //public EventLog EventLog { get; } // Takole bi bilo pravilno...

        public void SystemLogin(string user)
        {
            EventLog.GetInstance().WriteEvent($"Uporabnik {user} se je prijavil v sistem.");
        }

        public void SalaryDataLookup(string user)
        {
            EventLog.GetInstance().WriteEvent($"Uporabnik {user} je opravil vpogled plač.");
        }

        public void ViewVacationList(string user)
        {
            EventLog.GetInstance().WriteEvent($"Uporabnik {user} je opravil vpogled dopustov.");
        }

        public void SystemLogout(string user)
        {
            EventLog.GetInstance().WriteEvent($"Uporabnik {user} se je odjavil iz sistema.");
        }
    }
}
