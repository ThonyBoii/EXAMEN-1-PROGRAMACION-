using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_INDIVIDUAL_PROM_1
{
    internal class Enemy : Player
    {

        internal Enemy(string name) : base(name) { }

        internal void SpawnByFibonacci(int turn)
        {
            int count = Fibonacci(turn);
            for (int i = 0; i < count; i++)
            {
                Villager.Add(new Soldier());
            }
            if (count > 0)
                Console.WriteLine($"{Name} creó {count} Soldado.");
        }

        private int Fibonacci(int n)
        {
            if (n <= 1) return n;
            int a = 0, b = 1, temp;
            for (int i = 2; i <= n; i++)
            {
                temp = a + b;
                a = b;
                b = temp;
            }
            return b;
        }

    }
}
