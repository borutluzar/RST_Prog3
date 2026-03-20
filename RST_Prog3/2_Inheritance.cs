using System;
using System.Collections.Generic;
using System.Text;

namespace RST_Prog3
{
    /// <summary>
    /// Podrazred razreda Table
    /// </summary>
    public class ClubTable : Table
    {
        public ClubTable(int id) : base(id) { }

        public bool HasPaperShelf { get; set; }
    }

    /// <summary>
    /// Jedilna miza, za katero ne dopuščamo podrazredov - uporabimo določilo sealed
    /// </summary>
    public sealed class DiningTable : Table
    {
        public DiningTable(int id, int capacity) : base(id)
        {
            this.Capacity = capacity;
        }

        public int Capacity { get; set; }

        public bool IsExtendable { get; set; }
    }

    // Ker je nadrazred sealed, ne moremo razvijati novih podrazredov zanj
    /*
    public class MiniDiningTable : DiningTable
    {

    }
    */


    public class GameTable : Table
    {
        public GameTable(int id, GameType gameType) : base(id)
        {
            this.GameType = gameType;
        }

        public GameType GameType { get; }
    }

    public enum GameType
    {
        Snooker = 1,
        Poker = 2
    }

    public class OfficeTable : Table
    {
        public OfficeTable(int id) : base(id) { }

        public bool IsStanding { get; set; }

        public bool HasDrawers { get; set; }

        public bool CableChannel { get; set; }

        /*
        public override string ToString()
        {
            return base.ToString() + "kuku";
        }
        */

        public new string ToString()
        {
            return "Nekaj čisto novega";
        }

        // Funkcije ne moremo prepisati,
        // ker ni označena z virtual, abstract ali override
        /*
        public override double GetVolume()
        {

        }
        */

        public override double GetArea()
        {
            return base.GetArea() / 2;
        }
    }
}
