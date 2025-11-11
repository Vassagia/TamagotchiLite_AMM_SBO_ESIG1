using System;

namespace TamagotchiLite_AMM_SBO_ESIG1.Utils
{
    internal static class Input
    {
        // Lit un entier entre min et max, avec message d'erreur en cas de mauvaise saisie
        public static int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                string? s = Console.ReadLine();

                if (int.TryParse(s, out int n) && n >= min && n <= max)
                {
                    return n;
                }

                Console.WriteLine($"Veuillez entrer un nombre entre {min} et {max}.");
            }
        }

        // Lit une chaîne non vide, en supprimant les espaces autour
        public static string ReadNonEmpty(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = (Console.ReadLine() ?? string.Empty).Trim();

                if (!string.IsNullOrWhiteSpace(s))
                {
                    return s;
                }

                Console.WriteLine("Texte invalide. Réessayez.");
            }
        }

        // Compat pour les fichiers SBO; Utilisation de ReadInt pour éviter les plantages
        public static int VerificationSaisie(int min, int max)
        {
            // Centralisation de la logique au lieu de dupliquer du int.Parse 
            return ReadInt("Votre choix : ", min, max);
        }
    }
}
