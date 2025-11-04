using System;

namespace TamagotchiLite_AMM_SBO_ESIG1.Utils
{
    internal static class Input
    {
        public static int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = Console.ReadLine();
                if (int.TryParse(s, out int n) && n >= min && n <= max) return n;
                Console.WriteLine($"Veuillez entrer un nombre entre {min} et {max}.");
            }
        }

        public static string ReadNonEmpty(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                var s = (Console.ReadLine() ?? "").Trim();
                if (!string.IsNullOrWhiteSpace(s)) return s;
                Console.WriteLine("Texte invalide. Réessayez.");
            }
        }

        // Compat pour les fichiers du cours (SBO_*)
        public static int VerificationSaisie(int min, int max)
        {
            int choix = int.Parse(Console.ReadLine() ?? "0");
            while (choix < min || choix > max)
            {
                Console.WriteLine($"Veuillez choisir entre {min} et {max}.");
                choix = int.Parse(Console.ReadLine() ?? "0");
            }
            return choix;
        }
    }
}
