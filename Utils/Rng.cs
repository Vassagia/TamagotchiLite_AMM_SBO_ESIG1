using System;

namespace TamagotchiLite_AMM_SBO_ESIG1.Utils
{
    // Classe utilitaire pour les tirages aléatoires et les affichages décoratifs en console
    internal static class Rng
    {
        // Générateur aléatoire unique pour toute la classe
        private static readonly Random _r = new Random();

        // Retourne un entier aléatoire entre min et max (inclus)
        public static int Next(int min, int maxInclusive)
        {
            return _r.Next(min, maxInclusive + 1);
        }

        // Retourne true avec une probabilité "percent" (de 0 à 100)
        public static bool Chance(int percent)
        {
            return _r.Next(0, 100) < percent;
        }

        // Affiche un certain nombre de lignes vides pour aérer l’affichage
        public static void Vide(int nbLignes = 1)
        {
            for (int i = 0; i < nbLignes; i++)
            {
                Console.WriteLine();
            }
        }

        // Affiche un cadre complet et symétrique autour du texte fourni
        public static void AfficherTexteCadre(string texte)
        {
            // Étape 1 : définir une marge visuelle autour du texte
            int marge = 4; // deux espaces avant et après le texte

            // Étape 2 : calculer la longueur totale intérieure du cadre
            // Si le texte est trop long ou contient des caractères spéciaux, on protège la valeur
            int longueurInterieure = Math.Max(texte.Length + marge, 6);

            // Étape 3 : afficher la ligne du haut du cadre
            Console.WriteLine("╔" + new string('═', longueurInterieure) + "╗");

            // Étape 4 : calculer combien d'espaces mettre avant et après le texte pour le centrer
            int totalEspace = longueurInterieure - texte.Length;
            int espacesAvant = totalEspace / 2;
            int espacesApres = totalEspace - espacesAvant;

            // Étape 5 : afficher la ligne centrale avec les bords verticaux et le texte centré
            Console.WriteLine(
                "║"
                + new string(' ', espacesAvant)
                + texte
                + new string(' ', espacesApres)
                + "║"
            );

            // Étape 6 : afficher la ligne du bas du cadre
            Console.WriteLine("╚" + new string('═', longueurInterieure) + "╝");
        }
    }
}
