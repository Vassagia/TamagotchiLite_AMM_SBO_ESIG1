using System;

namespace TamagotchiLite_AMM_SBO_ESIG1.Ecrans
{
    internal class SBO_Quitter
    {
        // Ecran quitter qui affiche un Au revoir ! à la sortie du jeu.
        public static void EcranAuRevoir()
        {
            AfficherLigneHaut();
            Vide();
            Console.WriteLine("Au revoir !");
            Vide();
            AfficherLigneBas();
            Vide(2);
            Console.WriteLine("Merci d'avoir joué à Tamagotchi Lite. À bientôt !");

            // Attendre 5 secondes avant de fermer.
            System.Threading.Thread.Sleep(5000);

            // Fermeture de la console sans intervention de l'utilisateur.
            Environment.Exit(0);
        }
    }
}
