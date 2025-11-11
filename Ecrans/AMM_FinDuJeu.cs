using System;
using TamagotchiLite_AMM_SBO_ESIG1.Models;
using TamagotchiLite_AMM_SBO_ESIG1.Utils;

namespace TamagotchiLite_AMM_SBO_ESIG1.Ecrans
{
    // Écran de fin de partie
    internal class AMM_FinDuJeu
    {
        // Affiche l'écran de fin et demande au joueur s'il veut recommencer
        public bool AfficherEtRedemander(AnimalCompagnie pet)
        {
            Console.Clear();

            // Affiche un cadre autour du titre “Fin du jeu”
            Rng.AfficherTexteCadre("FIN DU JEU");
            Rng.Vide(2); // Ajoute de l’espace avant le message

            // Message personnalisé selon le nom du Tamagotchi
            Console.WriteLine($"Votre Tamagotchi {pet.NomAnimal} n'a pas survécu.");
            Console.WriteLine("Merci d'avoir joué !");
            Rng.Vide();

            // Question de redémarrage
            Console.Write("Recommencer une partie ? (O/N) : ");

            // Lecture et validation de la réponse utilisateur
            while (true)
            {
                string s = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();

                if (s == "O")
                {
                    return true;  // Rejouer
                }
                if (s == "N")
                {
                    return false; // Quitter
                }

                // Si la saisie est incorrecte, on redemande
                Console.WriteLine("Réponse invalide. Tapez O pour oui ou N pour non.");
                Console.Write("Votre choix : ");
            }
        }
    }
}
