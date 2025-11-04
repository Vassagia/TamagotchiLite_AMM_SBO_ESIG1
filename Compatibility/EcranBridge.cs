using System;
using TamagotchiLite_AMM_SBO_ESIG1.Ecrans;

namespace TamagotchiLite_AMM_SBO_ESIG1.Compat
{
    /// <summary>
    /// Sert à relier le code des écrans de Sophie avec le reste du projet,
    /// sans modifier son code dans ses fichiers.
    /// </summary>
    internal static class EcranBridge
    {
        // Écran des règles (dans le namespace racine)
        public static void ShowRules()
        {
            object value = TamagotchiLite_AMM_SBO_ESIG1.EcranReglesJeu();
        }

        // Écran de naissance (dans Ecrans)
        public static void ShowBirth()
        {
            EcranNaissance();
        }

        // Écran "Au revoir"
        public static void ShowFarewell()
        {
            EcranAuRevoir();
        }

        // Ces méthodes appellent les fonctions statiques existantes
        private static void EcranNaissance() => SBO_Naissance.EcranNaissance();
        private static void EcranAuRevoir() => SBO_Quitter.EcranAuRevoir();
    }
}
