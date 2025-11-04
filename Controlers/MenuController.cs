using System;
using TamagotchiLite_AMM_SBO_ESIG1.Ecrans;
using TamagotchiLite_AMM_SBO_ESIG1.Controllers;
using TamagotchiLite_AMM_SBO_ESIG1.Utils;

namespace TamagotchiLite_AMM_SBO_ESIG1.Controllers
{
    public class MenuController
    {
        public void Run()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Rng.AfficherLigneHaut();
                Console.WriteLine("Tamagotchi Lite");
                Rng.AfficherLigneBas();
                Rng.Vide(2);

                Console.WriteLine("1. Commencer une partie");
                Console.WriteLine("2. Règles du jeu");
                Console.WriteLine("3. Quitter");
                int choix = Input.ReadInt("\nVotre choix: ", 1, 3);

                switch (choix)
                {
                    case 1:
                        // On laisse l’écran Naissance “cours” s’afficher
                        SBO_Naissance.EcranNaissance();
                        // Puis on démarre ta logique de jeu
                        new GameController().NouvellePartie();
                        break;

                    case 2:
                        // Appel direct de l’écran des règles (statique dans la classe SBO_ReglesDuJeu)
                        SBO_ReglesDuJeu.EcranAfficherReglesJeu();
                        break;

                    case 3:
                        // Appel direct de l’écran quitter
                        SBO_Quitter.EcranAuRevoir();
                        exit = true;
                        break;
                }
            }
        }
    }
}
