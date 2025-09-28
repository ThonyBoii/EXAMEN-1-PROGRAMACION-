using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_INDIVIDUAL_PROM_1
{
    internal class Player
    {

        private List<Villager> villager;
        private Base territory;
        private string Heroe;
        private int gold;
        internal Player(string name)
        {
            Heroe = name;
            gold = 20;
            territory = new Base();
            villager = new List<Villager>();
        }

        internal string Name => Heroe;
        internal int Resources => gold;
        internal Base Base => territory;
        internal List<Villager> Villager => villager;

        internal void GainResourcesPerTurn()
        {
            int gatherers = villager.FindAll(u => u is Gatherer).Count;
            gold += 5 + (gatherers * 3);
            Console.WriteLine($"{Heroe} ganó oro. Total: {gold}");
        }

        internal void BuildSoldier()
        {
            int cost = 10;
            if (gold < cost)
            {
                Console.WriteLine("No tienes suficiente oro para un Soldado.");
                return;
            }

            gold -= cost;
            villager.Add(new Soldier());
            Console.WriteLine($"{Heroe} construyó un Soldado.");
        }

        internal void BuildGatherer()
        {
            int cost = 5;
            if (gold < cost)
            {
                Console.WriteLine("No tienes suficiente oro para un Recolector.");
                return;
            }

            gold -= cost;
            villager.Add(new Gatherer());
            Console.WriteLine($"{Heroe} construyó un Recolector.");
        }

    }
}
