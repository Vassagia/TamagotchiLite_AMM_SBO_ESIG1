using System;
using TamagotchiLite_AMM_SBO_ESIG1.Models;

namespace TamagotchiLite_AMM_SBO_ESIG1.Ecrans
{
    internal class AMM_FinDuJeu
    {
        public bool AfficherEtRedemander(AnimalCompagnie pet)
        {
            Console.Clear();
            Console.WriteLine("=== FIN DU JEU ===");
            Console.WriteLine($"Votre Tamagotchi {pet.Nom} n'a pas survécu. Merci d'avoir joué !\n");
            Console.Write("Recommencer une partie ? (O/N): ");
            while (true)
            {
                var s = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();
                if (s == "O") return true;
                if (s == "N") return false;
                Console.WriteLine("Réponse invalide. Tapez O ou N.");
            }
        }
    }
}
