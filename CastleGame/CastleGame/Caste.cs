using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleGame
{
    public class Castle
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public int Income { get; set; }
        public int Expenses { get; set; }

        public Castle(string name, int money, int income, int expenses)
        {
            Name = name;
            Money = money;
            Income = income;
            Expenses = expenses;
        }

        public void SwitchDay()
        {
            Money += Income - Expenses;
        }

        public int RobCastle()
        {
            Random random = new Random();
            int stolenMoney = random.Next(0, Money / 2);
            Money -= stolenMoney;
            return stolenMoney;
        }

        public void AddMoney(int amount)
        {
            Money += amount;
        }
    }
}
