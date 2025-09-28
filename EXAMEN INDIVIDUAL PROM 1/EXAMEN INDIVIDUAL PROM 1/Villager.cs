using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_INDIVIDUAL_PROM_1
{
    internal abstract class Villager
    {

        protected int life;
        protected int attack;

        internal abstract void Attack(Villager target);
        internal abstract void Attack(Base target);

        internal bool IsAlive()
        {
            return life > 0;
        }

        internal void TakeDamage(int dmg)
        {
            life -= dmg;
            if (life < 0) life = 0;
        }

    }
}
