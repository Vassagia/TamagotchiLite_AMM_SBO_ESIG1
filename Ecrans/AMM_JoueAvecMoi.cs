using System;
using TamagotchiLite_AMM_SBO_ESIG1.Models;
using TamagotchiLite_AMM_SBO_ESIG1.Utils;

namespace TamagotchiLite_AMM_SBO_ESIG1.Ecrans
{
    internal class AMM_JoueAvecMoi
    {
        public int AfficherEtatEtChoix(AnimalCompagnie pet)
        {
            Console.Clear();
            Console.WriteLine($"=== Joue avec moi !  ({pet.Nom}) ===");
            Console.WriteLine($"Faim: {pet.Stats.Faim}/100   Bonheur: {pet.Stats.Bonheur}/100   Énergie: {pet.Stats.Energie}/100\n");
            Console.WriteLine("1. Nourrir");
            Console.WriteLine("2. Jouer");
            Console.WriteLine("3. Dormir");
            Console.WriteLine("4. Quitter la partie");
            return Input.ReadInt("Votre choix: ", 1, 4);
        }
    }
}
