using System;

namespace TamagotchiLite_AMM_SBO_ESIG1.Ecrans
{
    // Écran de feedback après l’action “Dormir”
    internal class AMM_Energie_JoueAvecMoi
    {
        // Méthode qui affiche un message après que le Tamagotchi ait dormi
        public void AfficherMessage()
        {
            // Ligne vide pour aérer l’affichage
            Console.WriteLine();

            // Message de feedback positif
            Console.WriteLine("Je me sens très reposé, merci pour la sieste !");

            // Attente d'une touche pour que le joueur lise avant de continuer
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey(true); // true = n’affiche pas la touche appuyée
        }
    }
}
