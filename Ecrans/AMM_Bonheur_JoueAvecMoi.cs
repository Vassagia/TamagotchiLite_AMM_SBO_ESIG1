using System;

namespace TamagotchiLite_AMM_SBO_ESIG1.Ecrans
{
    // Écran de feedback après l’action “Jouer”
    internal class AMM_Bonheur_JoueAvecMoi
    {
        // Méthode qui affiche un message positif après avoir joué avec le Tamagotchi
        public void AfficherMessage()
        {
            // Ligne vide pour aérer l’affichage
            Console.WriteLine();

            // Message de feedback
            Console.WriteLine("Actuellement je me sens très joyeux !");

            // Attente d'une touche pour que le joueur puisse lire avant de continuer
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey(true); // true = n’affiche pas la touche pressée
        }
    }
}
