using System;

namespace TamagotchiLite_AMM_SBO_ESIG1.Models
{
    internal class Stats
    {
        public int Faim { get; set; } = 70;
        public int Energie { get; set; } = 70;
        public int Bonheur { get; set; } = 70;

        public void Clamp()
        {
            Faim = Math.Clamp(Faim, 0, 100);
            Energie = Math.Clamp(Energie, 0, 100);
            Bonheur = Math.Clamp(Bonheur, 0, 100);
        }
    }
}
