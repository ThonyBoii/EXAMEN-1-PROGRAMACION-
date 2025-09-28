using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_INDIVIDUAL_PROM_1
{
    internal class Gatherer : Villager
    {

        internal Gatherer()
        {
            life = 5;
            attack = 1;
        }

        internal override void Attack(Villager target)
        {
            target.TakeDamage(attack);
            Console.WriteLine($"Un Recolector atacó a una unidad por {attack} de daño.");
        }

        internal override void Attack(Base target)
        {
            target.TakeDamage(attack);
            Console.WriteLine($"Un Recolector atacó la base por {attack} de daño.");
        }

    }
}
