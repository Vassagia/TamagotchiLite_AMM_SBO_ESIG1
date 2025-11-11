using System;
using TamagotchiLite_AMM_SBO_ESIG1.Models;
using TamagotchiLite_AMM_SBO_ESIG1.Utils;
using static TamagotchiLite_AMM_SBO_ESIG1.Utils.Rng;

namespace TamagotchiLite_AMM_SBO_ESIG1.Ecrans
{
    internal class SBO_Naissance
    {
        // Ecran naissance: choix de l'animal, de son nom.
        // Cette méthode retourne un AnimalCompagnie prêt à être utilisé.
        public static AnimalCompagnie EcranNaissance()
        {
            Console.Clear();

            AfficherTexteCadre("Naissance");
            Vide(2);

            Console.WriteLine("1. Raton laveur");
            Console.WriteLine("2. Fennec");
            Console.WriteLine("3. Écureuil");
            Vide(2);

            Console.WriteLine("Choisissez votre animal (1,2 ou 3) :");
            int choix = Input.VerificationSaisie(1, 3); // On récupère la valeur vérifiée.
            Vide(2);

            // On déduit l'espèce à partir du choix du joueur
            string espece;

            switch (choix)
            {
                case 1:
                    espece = "Raton laveur";
                    break;

                case 2:
                    espece = "Fennec";
                    break;

                case 3:
                    espece = "Écureuil";
                    break;

                default:
                    // Sécurité : ce cas ne devrait jamais se produire
                    espece = "Raton laveur";
                    break;
            }

            Console.WriteLine("Votre oeuf éclot....");
            string nomAnimal = Input.ReadNonEmpty("Donnez-lui un nom : ");
            Vide(2);

            Console.WriteLine($"Bienvenue à {nomAnimal} ! Prenez bien soin de lui !");
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey(true);

            // On crée et on retourne l'animal au contrôleur de jeu
            return new AnimalCompagnie(espece, nomAnimal);
        }
    }
}
