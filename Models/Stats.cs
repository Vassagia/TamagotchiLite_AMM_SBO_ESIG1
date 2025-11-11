using System;

namespace TamagotchiLite_AMM_SBO_ESIG1.Models
{
    // Représente les statistiques principales du Tamagotchi :
    // la faim, l'énergie et le bonheur, chacune entre 0 et 100
    internal class Stats
    {
        // Valeurs initiales des jauges (70 pour un équilibre de départ)
        public int Faim { get; set; } = 70;
        public int Energie { get; set; } = 70;
        public int Bonheur { get; set; } = 70;

        // Méthode Clamp() : empêche les valeurs de dépasser les bornes (0–100)
        public void Clamp()
        {
            Faim = Math.Clamp(Faim, 0, 100);
            Energie = Math.Clamp(Energie, 0, 100);
            Bonheur = Math.Clamp(Bonheur, 0, 100);
        }
    }
}
