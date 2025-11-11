using System;
using TamagotchiLite_AMM_SBO_ESIG1.Models;
using TamagotchiLite_AMM_SBO_ESIG1.Utils;

namespace TamagotchiLite_AMM_SBO_ESIG1.Ecrans
{
    // Écran principal de jeu : affiche l'état du Tamagotchi et propose les actions
    internal class AMM_JoueAvecMoi
    {
        // Affiche l'état actuel du Tamagotchi et renvoie le choix de l'utilisateur
        public int AfficherEtatEtChoix(AnimalCompagnie pet)
        {
            Console.Clear();

            // Titre avec le nom du Tamagotchi, affiché dans un cadre
            Rng.AfficherTexteCadre($"Joue avec moi ! ({pet.NomAnimal})");
            Rng.Vide(2);

            // Affichage de l'état du Tamagotchi (faim, bonheur, énergie)
            Console.WriteLine($"Faim    : {pet.Stats.Faim}/100");
            Console.WriteLine($"Bonheur : {pet.Stats.Bonheur}/100");
            Console.WriteLine($"Énergie : {pet.Stats.Energie}/100");
            Rng.Vide();

            // Affichage des actions possibles
            Console.WriteLine("1. Nourrir");
            Console.WriteLine("2. Jouer");
            Console.WriteLine("3. Dormir");
            Console.WriteLine("4. Quitter la partie");

            // Lecture et retour du choix utilisateur (entre 1 et 4)
            return Input.ReadInt("\nVotre choix : ", 1, 4);
        }
    }
}
