using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN_INDIVIDUAL_PROM_1
{
    internal class Game
    {
        private Player player;
        private Enemy enemy;
        private int turnNumber;

        internal Game()
        {
            player = new Player("Jugador");
            enemy = new Enemy("Enemigo");
            turnNumber = 1;
        }

        internal void Start()
        {
            Console.WriteLine("=== X Turnos ===");
            Console.WriteLine("Gana el que destruya la base del otro.\n");

            while (true)
            {
                PlayerTurn();
                if (CheckVictory()) break;

                EnemyTurn();
                if (CheckVictory()) break;

                turnNumber++;
            }
        }

        private void PlayerTurn()
        {
            Console.WriteLine($"\n--- Turno{turnNumber} del Jugador  ---");
            player.GainResourcesPerTurn();

            bool endTurn = false;
            while (!endTurn)
            {
                Console.WriteLine("\nAcciones disponibles:");
                Console.WriteLine("1) Construir Soldado (10 recursos)");
                Console.WriteLine("2) Construir Recolector (5 recursos)");
                Console.WriteLine("3) Ver Estado");
                Console.WriteLine("4) Terminar Turno");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        player.BuildSoldier();
                        break;
                    case "2":
                        player.BuildGatherer();
                        break;
                    case "3":
                        ShowStatus();
                        break;
                    case "4":
                        endTurn = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intenta de nuevo.");
                        break;
                }
            }

            ResolveUnitsActions(player, enemy);
        }

        private void EnemyTurn()
        {
            Console.WriteLine($"\n--- Turno{turnNumber} del Enemigo  ---");
            enemy.GainResourcesPerTurn();
            enemy.SpawnByFibonacci(turnNumber);
            ResolveUnitsActions(enemy, player);
        }

        private void ResolveUnitsActions(Player attacker, Player defender)
        {
            var unitsCopy = new List<Villager>(attacker.Villager);

            foreach (var unit in unitsCopy)
            {
                if (defender.Villager.Count > 0)
                {
                    Villager target = defender.Villager[0];
                    unit.Attack(target);

                    if (!target.IsAlive())
                    {
                        defender.Villager.Remove(target);
                        Console.WriteLine($"{defender.Name} perdió una unidad.");
                    }
                }
                else
                {
                    unit.Attack(defender.Base);
                    if (!defender.Base.IsAlive())
                    {
                        Console.WriteLine($"{defender.Name} perdió su base.");
                        return;
                    }
                }
            }
        }

        private bool CheckVictory()
        {
            if (!player.Base.IsAlive())
            {
                Console.WriteLine("El enemigo ganó. Fin del juego.");
                return true;
            }
            else if (!enemy.Base.IsAlive())
            {
                Console.WriteLine("¡Ganaste! Fin del juego.");
                return true;
            }
            return false;
        }

        private void ShowStatus()
        {
            Console.WriteLine($"\nEstado del Jugador:");
            Console.WriteLine($"Recursos: {player.Resources} oro");
            Console.WriteLine($"Base HP: {player.Base.CurrentHP} vida");
            Console.WriteLine($"Unidades: {player.Villager.Count} aldeanos");

            Console.WriteLine($"\nEstado del Enemigo:");
            Console.WriteLine($"Recursos: {enemy.Resources} oro");
            Console.WriteLine($"Base HP: {enemy.Base.CurrentHP} vida");
            Console.WriteLine($"Unidades: {enemy.Villager.Count} aldeanos");
        }

    }
}
