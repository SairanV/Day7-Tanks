using System;
using MyClassLib.WordOfTanks;

namespace Day7_Tanks
{
    class Program
    {
        static void Main(string[] args)
        {
            Tank[] tanksT34 = new Tank[5];
            Tank[] tanksPantera = new Tank[5];

            for (int i = 0; i < 1; i++)
            {
                tanksT34[i] = new Tank("Т-34");
                tanksPantera[i] = new Tank("Pantera");
            }

            for (int i = 0; i < 1; i++)
            {
                bool t34Wins = tanksT34[i] ^ tanksPantera[i];
                string winner = t34Wins ? "Т-34" : "Pantera";

                Console.WriteLine($"Бой {i + 1}: {tanksT34[i].GetTankParameters()} vs {tanksPantera[i].GetTankParameters()}");
                Console.WriteLine($"Победитель: {winner}");
                Console.WriteLine();
            }
        }
    }
}
