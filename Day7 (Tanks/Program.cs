using System;
using System.Collections.Generic;
using MyClassLib.WordOfTanks;

namespace Day7_Tanks
{
    public class Program
    {
        public static Tank DetermineWinner(Tank tank1, Tank tank2)
        {
            int criteriaMet = 0;

            if (tank1.Ammunition > tank2.Ammunition)
            {
                criteriaMet++;
            }

            if (tank1.Armor > tank2.Armor)
            {
                criteriaMet++;
            }

            if (tank1.Agility > tank2.Agility)
            {
                criteriaMet++;
            }

            if (criteriaMet >= 2)
            {
                return tank1;
            }
            else
            {
                return tank2;
            }
        }

        static void Main(string[] args)
        {
            // Создаем 5 танков "Т-34" и 5 танков "Pantera"
            Tank[] tanksT34 = new Tank[5];
            Tank[] tanksPantera = new Tank[5];

            string[] t34Names = { "T-34-1", "T-34-2", "T-34-3", "T-34-4", "T-34-5" };
            string[] panteraNames = { "Pantera-1", "Pantera-2", "Pantera-3", "Pantera-4", "Pantera-5" };

            // Создаем словарь для хранения курсов конвертации валют
            Dictionary<string, decimal> exchangeRates = new Dictionary<string, decimal>
            {
                { "USD", 425.1M },
                { "EUR", 491.5M },
                { "KZT", 1M },
                { "RUB", 5.09M }
            };

            // Ввод ставки игроками
            for (int i = 0; i < tanksT34.Length; i++)
            {
                Console.WriteLine($"Игрок {i + 1}, введите валюту для Т-34 (валюта):");
                Console.WriteLine("| USD | EUR | KZT | RUB |");
                string currency = Console.ReadLine();

                Console.WriteLine($"Игрок {i + 1}, введите ставку для Т-34:");
                if (decimal.TryParse(Console.ReadLine(), out decimal bet))
                {
                    tanksT34[i] = new Tank(t34Names[i], currency, bet);
                }
                else
                {
                    Console.WriteLine("Неправильный формат ставки. Ставка будет установлена на 0.");
                    tanksT34[i] = new Tank(t34Names[i], currency, 0);
                }
            }

            for (int i = 0; i < tanksPantera.Length; i++)
            {
                Console.WriteLine($"Игрок {i + 1}, введите валюту для Pantera (валюта):");
                Console.WriteLine("| USD | EUR | KZT | RUB |");
                string currency = Console.ReadLine();

                Console.WriteLine($"Игрок {i + 1}, введите ставку для Pantera:");
                if (decimal.TryParse(Console.ReadLine(), out decimal bet))
                {
                    tanksPantera[i] = new Tank(panteraNames[i], currency, bet);
                }
                else
                {
                    Console.WriteLine("Неправильный формат ставки. Ставка будет установлена на 0.");
                    tanksPantera[i] = new Tank(panteraNames[i], currency, 0);
                }
            }

            // Моделируем бои и определяем победителей
            for (int i = 0; i < 5; i++)
            {
                bool t34Wins = tanksT34[i] ^ tanksPantera[i];
                Tank winner = DetermineWinner(tanksT34[i], tanksPantera[i]);

                Console.WriteLine();
                Console.WriteLine($"Бой {i + 1}: {tanksT34[i].GetTankParameters()} vs {tanksPantera[i].GetTankParameters()}");
                Console.WriteLine($"Победитель: {winner.Name}");
                Console.WriteLine();

                // Конвертацию ставок в одну валюту
                decimal t34BetInTenge = MoneyConverter.ConvertToTenge(tanksT34[i].Bet, tanksT34[i].Currency, exchangeRates);
                decimal panteraBetInTenge = MoneyConverter.ConvertToTenge(tanksPantera[i].Bet, tanksPantera[i].Currency, exchangeRates);

                // Определите победителя и выигрыши
                if (t34BetInTenge > panteraBetInTenge)
                {
                    Console.WriteLine($"Игрок сделавший ставку {tanksT34[i].Bet} на Т-34 выиграл {t34BetInTenge * 2} тенге.");
                }
                else if (panteraBetInTenge > t34BetInTenge)
                {
                    Console.WriteLine($"Игрок сделавший ставку {tanksPantera[i].Bet} на Pantera выиграл {panteraBetInTenge * 2} тенге.");
                }
                else
                {
                    Console.WriteLine("Ничья.");
                }

                Console.WriteLine();
            }
        }
    }
}
