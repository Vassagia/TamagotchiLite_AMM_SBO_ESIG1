using System;

namespace TamagotchiLite_AMM_SBO_ESIG1.Ecrans
{
    /// <summary>
    /// Écran de feedback après l'action "Jouer"
    /// </summary>
    internal class AMM_Bonheur_JoueAvecMoi
    {
        public void AfficherMessage()
        {
            Console.WriteLine("\nActuellement je me sens très joyeux !");
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey(true);
        }
    }
}
