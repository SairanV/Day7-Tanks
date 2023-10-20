using System;

namespace MyClassLib.WordOfTanks
{
    public class Tank
    {
        private string tankName;
        private int ammunitionLevel;
        private int armorLevel;
        private int agilityLevel;

        public Tank(string name)
        {
            Random random = new Random();
            tankName = name;
            ammunitionLevel = random.Next(0, 101);
            armorLevel = random.Next(0, 101);
            agilityLevel = random.Next(0, 101);
        }

        public string GetTankParameters()
        {
            return $"Tank Name: {tankName}, Ammunition: {ammunitionLevel}%, Armor: {armorLevel}%, Agility: {agilityLevel}%";
        }

        public static bool operator ^(Tank tank1, Tank tank2)
        {
            int winCriteriaCount = 0;

            if (tank1.ammunitionLevel > tank2.ammunitionLevel)
                winCriteriaCount++;
            if (tank1.armorLevel > tank2.armorLevel)
                winCriteriaCount++;
            if (tank1.agilityLevel > tank2.agilityLevel)
                winCriteriaCount++;

            return winCriteriaCount >= 2;
        }
    }
}
