using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_INDIVIDUAL_PROM_1
{
    internal class Soldier : Villager
    {

        internal Soldier()
        {
            life = 10;
            attack = 5;
        }

        internal override void Attack(Villager target)
        {
            target.TakeDamage(attack);
            Console.WriteLine($"Un Soldado atacó a una unidad por {attack} de daño.");
        }

        internal override void Attack(Base target)
        {
            target.TakeDamage(attack);
            Console.WriteLine($"Un Soldado atacó la base por {attack} de daño.");
        }

    }
}
