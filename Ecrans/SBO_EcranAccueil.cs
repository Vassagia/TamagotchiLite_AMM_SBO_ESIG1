using System;

namespace TamagotchiLite_AMM_SBO_ESIG1.Ecrans
{
    internal class SBO_EcranAccueil
    {
        // Partie Main, écran d'accueil avec choix du joueur.
        static void Main(string[] args)
        {
            // Pour que les accents s'affichent toujours bien, la console lit et code en UTF-8.
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // Ecran d'accueil.            
            AfficherLigneHaut();
            Vide();
            Console.WriteLine("Tamagotchi Lite");
            Vide();
            AfficherLigneBas(); 
            Vide(2);

            Console.WriteLine("1. Commencer une partie.");
            Console.WriteLine("2. Règles du jeu.");
            Console.WriteLine("3. Quitter le jeu.");
            Vide(2);

            Console.WriteLine("Veuillez choisir l'action souhaitée (1,2 ou 3) :");
            int choix = VerificationSaisie(1, 3); // On récupère la valeur vérifiée.
            switch (choix)
            {
                case 1:
                    // Nettoyer l'écran et passer à l'écran Naissance. Le jeu commencera.
                    Console.Clear();
                   new SBO_Naissance();
                    break;

                case 2:
                    // Nettoyer l'écran et passer à l'écran Règles du jeu.
                    Console.Clear();
                    new SBO_ReglesDuJeu();
                    break;
                case 3:
                    // Nettoyer l'écran et passer à l'écran Au revoir !. Le jeu se terminera.
                    Console.Clear();
                    new SBO_Quitter();
                    break;
            }
        }
    }
}
