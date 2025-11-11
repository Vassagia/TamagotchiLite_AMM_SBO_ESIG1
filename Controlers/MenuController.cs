using System;
using TamagotchiLite_AMM_SBO_ESIG1.Ecrans;
using TamagotchiLite_AMM_SBO_ESIG1.Utils;

namespace TamagotchiLite_AMM_SBO_ESIG1.Controllers
{
    public class MenuController
    {
        // Méthode principale du menu : affichage et gestion des choix utilisateur
        public void Run()
        {
            bool exit = false;  // condition pour sortir du menu

            // Boucle principale du menu
            while (!exit)
            {
                Console.Clear();

                // 1) Affichage de l'en-tête de l'application; On utilise un cadre automatique autour du titre
                Rng.AfficherTexteCadre("Tamagotchi Lite");
                Rng.Vide(2);  // deux lignes vides pour aérer

                // 2) Affichage du menu principal
                Console.WriteLine("1. Commencer une partie");
                Console.WriteLine("2. Règles du jeu");
                Console.WriteLine("3. Quitter");

                // 3) Lecture d'un choix utilisateur entre 1 et 3
                int choix = Input.ReadInt("\nVotre choix : ", 1, 3);

                // 4) Traitement du choix
                switch (choix)
                {
                    case 1:
                        // Lancer une nouvelle partie
                        Console.Clear();

                        // Le GameController appelle déjà l'écran SBO_Naissance; on ne l'appelle plus ici pour éviter le doublon
                        new GameController().NouvellePartie();
                        break;

                    case 2:
                        // Afficher les règles du jeu
                        Console.Clear();
                        SBO_ReglesDuJeu.EcranAfficherReglesJeu();
                        break;

                    case 3:
                        // Afficher l'écran de fin / au revoir puis sortir du menu
                        Console.Clear();
                        SBO_Quitter.EcranAuRevoir();
                        exit = true;
                        break;
                }
            }
        }
    }
}
