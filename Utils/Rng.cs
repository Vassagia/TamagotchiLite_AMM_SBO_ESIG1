using System;

namespace TamagotchiLite_AMM_SBO_ESIG1.Utils
{
    internal static class Rng
    {
        private static readonly Random _r = new Random();
        public static int Next(int min, int maxInclusive) => _r.Next(min, maxInclusive + 1);
        public static bool Chance(int percent) => _r.Next(0, 100) < percent;

        // Compat affichage "cours"
        public static void AfficherLigneHaut(int longueur = 50)
            => Console.WriteLine("╔" + new string('═', longueur) + "╗");

        public static void AfficherLigneBas(int longueur = 50)
            => Console.WriteLine("╚" + new string('═', longueur) + "╝");

        public static void Vide(int nbLignes = 1)
        {
            for (int i = 0; i < nbLignes; i++) Console.WriteLine();
        }
    }
}
