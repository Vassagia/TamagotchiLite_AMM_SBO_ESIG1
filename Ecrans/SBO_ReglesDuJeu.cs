using System;
using TamagotchiLite_AMM_SBO_ESIG1.Ecrans;

namespace TamagotchiLite_AMM_SBO_ESIG1
{
    internal class SBO_ReglesDuJeu
    {
        // Ecran qui affiche les règles du jeu.
        public static void EcranAfficherReglesJeu()
        {
            AfficherLigneHaut();
            Vide();
            Console.WriteLine("Règles du jeu");
            Vide();
            AfficherLigneBas();
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
            AfficherLigneHaut();
            Console.WriteLine("1. Commencer une partie.");
            Console.WriteLine("2. Retour au menu principal.");
            Console.WriteLine("3. Quitter le jeu.");
            AfficherLigneBas();

            int choix = int.Parse(Console.ReadLine()); // Lecture du choix du joueur.
            switch (choix)
            {
                case 1:
                    // Nettoyer l'écran et passer à l'écran Naissance. Le jeu commencera.
                    Console.Clear();
                    new SBO_Naissance();
                    break;

                case 2:
                    // Nettoyer l'écran et revenir à l'écran du menu principal Tamagotchi Lite.
                    Console.Clear();
                    return; // Retourne à l'écran menu principal.               
                case 3:
                    // Nettoyer l'écran et passer à l'écran Au revoir !. Le jeu se terminera.
                    Console.Clear();
                    new SBO_Quitter();
                    break;
                default:
                    Console.WriteLine("Entrée non valide");
                    break;
            }
        }

    }
}
