using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_INDIVIDUAL_PROM_1
{
    internal class Base
    {

        private int hp;

        internal Base()
        {
            hp = 10;
        }

        internal int CurrentHP => hp;

        internal void TakeDamage(int dmg)
        {
            hp -= dmg;
            if (hp < 0) hp = 0;
            Console.WriteLine($"La base recibió {dmg} de daño. HP restante: {hp}");
        }

        internal bool IsAlive()
        {
            return hp > 0;
        }

    }
}
