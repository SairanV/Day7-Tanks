using System;

namespace MyClassLib.WordOfTanks
{
    public class Tank
    {
        public int Ammunition { get; set; }
        public int Armor { get; set; }
        public int Agility { get; set; }
        public decimal Bet { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }

        public Tank(string name, string currency, decimal bet)
        {
            Random random = new Random();
            Name = name;
            Ammunition = random.Next(0, 101);
            Armor = random.Next(0, 101);
            Agility = random.Next(0, 101);
            Currency = currency;
            Bet = bet;
        }

        public string GetTankParameters()
        {
            return $"Tank Name: {Name}, Ammunition: {Ammunition}%, Armor: {Armor}%, Agility: {Agility}%";
        }

        public static bool operator ^(Tank tank1, Tank tank2)
        {
            int winCriteriaCount = 0;

            if (tank1.Ammunition > tank2.Ammunition)
                winCriteriaCount++;
            if (tank1.Armor > tank2.Armor)
                winCriteriaCount++;
            if (tank1.Agility > tank2.Agility)
                winCriteriaCount++;

            return winCriteriaCount >= 2;
        }
    }
}
