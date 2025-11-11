using System;
using TamagotchiLite_AMM_SBO_ESIG1.Controllers;

namespace TamagotchiLite_AMM_SBO_ESIG1
{
    internal class Program
    {
        // Point d'entrée de l'application
        static void Main(string[] args)
        {
            // Encodage pour gérer les accents et les cadres
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // Titre de la fenêtre de console
            Console.Title = "Tamagotchi Lite — ESIG1";

            // Lancer le contrôleur de menu principal
            var menuController = new MenuController();
            menuController.Run();
        }
    }
}
