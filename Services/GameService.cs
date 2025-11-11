using System;
using TamagotchiLite_AMM_SBO_ESIG1.Models;
using TamagotchiLite_AMM_SBO_ESIG1.Utils;

namespace TamagotchiLite_AMM_SBO_ESIG1.Services
{
    // Service qui gère les actions du joueur et la dérive naturelle des statistiques du Tamagotchi
    internal class GameService
    {
        // Valeur de boost appliquée quand le joueur agit (nourrir, jouer, dormir)
        private const int ACTION_BOOST = 20;

        // Valeurs minimales et maximales de la dérive naturelle (baisse automatique des jauges)
        private const int DECAY_FAIM_MIN = 6;
        private const int DECAY_FAIM_MAX = 12;

        private const int DECAY_BONHEUR_MIN = 4;
        private const int DECAY_BONHEUR_MAX = 10;

        private const int DECAY_ENERGIE_MIN = 6;
        private const int DECAY_ENERGIE_MAX = 12;

        // Actions du joueur
        public void AgirNourrir(AnimalCompagnie pet)
        {
            pet.Stats.Faim = Clamp100(pet.Stats.Faim + ACTION_BOOST);
        }

        public void AgirJouer(AnimalCompagnie pet)
        {
            pet.Stats.Bonheur = Clamp100(pet.Stats.Bonheur + ACTION_BOOST);
        }

        public void AgirDormir(AnimalCompagnie pet)
        {
            pet.Stats.Energie = Clamp100(pet.Stats.Energie + ACTION_BOOST);
        }

        // Dérive naturelle des jauges 
        // À chaque tour, les besoins diminuent d'une valeur aléatoire comprise dans les bornes définies ci-dessus
        public void DeriveNaturelle(AnimalCompagnie pet)
        {
            int df = Rng.Next(DECAY_FAIM_MIN, DECAY_FAIM_MAX);
            int db = Rng.Next(DECAY_BONHEUR_MIN, DECAY_BONHEUR_MAX);
            int de = Rng.Next(DECAY_ENERGIE_MIN, DECAY_ENERGIE_MAX);

            pet.Stats.Faim = Clamp100(pet.Stats.Faim - df);
            pet.Stats.Bonheur = Clamp100(pet.Stats.Bonheur - db);
            pet.Stats.Energie = Clamp100(pet.Stats.Energie - de);
        }

        // Vérifie si le Tamagotchi est vivant
        public bool EstMort(AnimalCompagnie pet)
        {
            return pet.Stats.Faim <= 0 || pet.Stats.Bonheur <= 0 || pet.Stats.Energie <= 0;
        }

        // Fonction utilitaire : maintient une valeur entre 0 et 100 
        private static int Clamp100(int v)
        {
            return Math.Min(100, Math.Max(0, v));
        }
    }
}
