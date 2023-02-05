using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeParkTycoonGame
{
    class Personal
    {
        public string name;
        public int salary;
        public int power;
        public int baseCost;

        public List<string> nameList = new List<string>();
        public List<int> salaryList = new List<int>();
        public List<int> powerList = new List<int>();
        public List<int> baseCostList = new List<int>();
        Random random = new Random();

        public void Hire(int power)
        {
            this.name = NameGenerator.NextName(); ;
            if (power == 1)
            {
                this.salary = 85;
                this.power = random.Next(1, 5);
                this.baseCost = random.Next(100, 250);
            }
            if (power == 2)
            {
                this.salary = 120;
                this.power = random.Next(6, 12);
                this.baseCost = random.Next(150, 400);
            }
            if (power == 3)
            {
                this.salary = 225;
                this.power = random.Next(15, 25);
                this.baseCost = 400;
            }
            nameList.Add(this.name);
            salaryList.Add(this.salary);
            powerList.Add(this.power);
            baseCostList.Add(this.baseCost);
        }
        public string GetName(int index)
        {
            return nameList[index];
        }

        public int GetSalary(int index)
        {
            return salaryList[index];
        }

        public int GetPower(int index)
        {
            return powerList[index];
        }

        public int GetCost(int index)
        {
            return baseCostList[index];
        }

    }
}
