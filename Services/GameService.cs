using System;
using TamagotchiLite_AMM_SBO_ESIG1.Models;
using TamagotchiLite_AMM_SBO_ESIG1.Utils;

namespace TamagotchiLite_AMM_SBO_ESIG1.Services
{
    internal class GameService
    {
        private const int ACTION_BOOST = 20;

        private const int DECAY_FAIM_MIN = 6;
        private const int DECAY_FAIM_MAX = 12;
        private const int DECAY_BONHEUR_MIN = 4;
        private const int DECAY_BONHEUR_MAX = 10;
        private const int DECAY_ENERGIE_MIN = 6;
        private const int DECAY_ENERGIE_MAX = 12;

        public void AgirNourrir(AnimalCompagnie pet) => pet.Stats.Faim = Clamp100(pet.Stats.Faim + ACTION_BOOST);
        public void AgirJouer(AnimalCompagnie pet) => pet.Stats.Bonheur = Clamp100(pet.Stats.Bonheur + ACTION_BOOST);
        public void AgirDormir(AnimalCompagnie pet) => pet.Stats.Energie = Clamp100(pet.Stats.Energie + ACTION_BOOST);

        public void DeriveNaturelle(AnimalCompagnie pet)
        {
            int df = Rng.Next(DECAY_FAIM_MIN, DECAY_FAIM_MAX);
            int db = Rng.Next(DECAY_BONHEUR_MIN, DECAY_BONHEUR_MAX);
            int de = Rng.Next(DECAY_ENERGIE_MIN, DECAY_ENERGIE_MAX);

            pet.Stats.Faim = Clamp100(pet.Stats.Faim - df);
            pet.Stats.Bonheur = Clamp100(pet.Stats.Bonheur - db);
            pet.Stats.Energie = Clamp100(pet.Stats.Energie - de);
        }

        public bool EstMort(AnimalCompagnie pet)
            => pet.Stats.Faim <= 0 || pet.Stats.Bonheur <= 0 || pet.Stats.Energie <= 0;

        private static int Clamp100(int v) => Math.Min(100, Math.Max(0, v));
    }
}
