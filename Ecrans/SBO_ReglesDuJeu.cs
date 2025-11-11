using System;
using TamagotchiLite_AMM_SBO_ESIG1.Utils;
using TamagotchiLite_AMM_SBO_ESIG1.Controllers;
using static TamagotchiLite_AMM_SBO_ESIG1.Utils.Rng;

namespace TamagotchiLite_AMM_SBO_ESIG1.Ecrans
{
    internal class SBO_ReglesDuJeu
    {
        // Ecran qui affiche les règles du jeu
        public static void EcranAfficherReglesJeu()
        {
            Console.Clear();

            // Affichage du titre dans un cadre
            AfficherTexteCadre("Règles du jeu");
            Vide(2);

            Console.WriteLine("Votre Tamagotchi est un petit animal virtuel dont vous devez prendre soin pour le garder en vie le plus longtemps possible.");
            Vide();
            Console.WriteLine("Ses besoins principaux sont :");
            Console.WriteLine("- la faim");
            Console.WriteLine("- le sommeil");
            Console.WriteLine("- le bonheur");
            Vide(2);
            Console.WriteLine("Chaque action que vous effectuerez (nourrir, dormir, jouer) influence ses besoins. Si vous négligez trop longtemps un besoin et qu'une jauge tombe à zéro, votre Tamagotchi finira par mourir.");
            Vide();
            Console.WriteLine("Prenez soin de lui et gardez-le en vie!");
            Vide(2);

            Console.WriteLine("1. Commencer une partie.");
            Console.WriteLine("2. Retour au menu principal.");
            Console.WriteLine("3. Quitter le jeu.");

            // Lecture du choix du joueur avec validation 
            int choix = Input.ReadInt("\nVotre choix : ", 1, 3);

            switch (choix)
            {
                case 1:
                    // Nettoyer l'écran et passer à l'écran Naissance; Le jeu commencera
                    Console.Clear();
                    SBO_Naissance.EcranNaissance();
                    new GameController().NouvellePartie();
                    break;

                case 2:
                    // Nettoyer l'écran et revenir à l'écran du menu principal Tamagotchi Lite
                    Console.Clear();
                    return; // Retourne à l'écran menu principal              

                case 3:
                    // Nettoyer l'écran et passer à l'écran Au revoir !; Le jeu se terminera
                    Console.Clear();
                    SBO_Quitter.EcranAuRevoir();
                    break;

                default:
                    // En théorie jamais atteint grâce à Input.ReadInt
                    Console.WriteLine("Entrée non valide");
                    break;
            }
        }
    }
}
