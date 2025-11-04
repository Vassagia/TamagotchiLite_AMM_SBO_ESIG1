using System;

namespace TamagotchiLite_AMM_SBO_ESIG1.Ecrans
{
    /// <summary>
    /// Écran de feedback après l'action "Nourrir"
    /// </summary>
    internal class AMM_Faim_JoueAvecMoi
    {
        public void AfficherMessage()
        {
            Console.WriteLine("\nActuellement je me sens mieux, j'avais faim !");
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey(true);
        }
    }
}
