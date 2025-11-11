using System;
using TamagotchiLite_AMM_SBO_ESIG1.Utils;
using TamagotchiLite_AMM_SBO_ESIG1.Ecrans;
using static TamagotchiLite_AMM_SBO_ESIG1.Utils.Rng;

namespace TamagotchiLite_AMM_SBO_ESIG1.Ecrans
{
    internal class SBO_EcranAccueil
    {
        // Partie Main, écran d'accueil avec choix du joueur
        public static void Afficher()
        {
            // Pour que les accents s'affichent toujours bien, la console lit et code en UTF-8
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.Clear();

            // Ecran d'accueil ; cadre automatique autour du titre         
            AfficherTexteCadre("Tamagotchi Lite");
            Vide(2);

            Console.WriteLine("1. Commencer une partie.");
            Console.WriteLine("2. Règles du jeu.");
            Console.WriteLine("3. Quitter le jeu.");
            Vide(2);

            Console.WriteLine("Veuillez choisir l'action souhaitée (1,2 ou 3) :");

            // On récupère la valeur vérifiée
            int choix = VerificationSaisie(1, 3);

            switch (choix)
            {
                case 1:
                    // Nettoyer l'écran et passer à l'écran Naissance; Le jeu commencera
                    Console.Clear();
                    SBO_Naissance.EcranNaissance();
                    break;

                case 2:
                    // Nettoyer l'écran et passer à l'écran Règles du jeu
                    Console.Clear();
                    SBO_ReglesDuJeu.EcranAfficherReglesJeu();
                    break;

                case 3:
                    // Nettoyer l'écran et passer à l'écran Au revoir !; Le jeu se terminera
                    Console.Clear();
                    SBO_Quitter.EcranAuRevoir();
                    break;
            }
        }

        // Méthode de vérification de saisie, adaptée pour utiliser ton utilitaire Input
        private static int VerificationSaisie(int min, int max)
        {
            // Utilise la méthode centralisée qui valide les entrées numériques
            return Input.ReadInt("Votre choix : ", min, max);
        }
    }
}
