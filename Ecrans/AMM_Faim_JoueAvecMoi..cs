using System;

namespace TamagotchiLite_AMM_SBO_ESIG1.Ecrans
{
    // Écran de feedback après l’action “Nourrir”
    internal class AMM_Faim_JoueAvecMoi
    {
        // Méthode qui affiche un message après que le Tamagotchi a été nourri
        public void AfficherMessage()
        {
            // Ligne vide pour aérer l’affichage
            Console.WriteLine();

            // Message de feedback positif
            Console.WriteLine("Actuellement je me sens mieux, j'avais faim !");

            // Attente d'une touche pour que le joueur puisse lire avant de continuer
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey(true); // true = n’affiche pas la touche appuyée
        }
    }
}
