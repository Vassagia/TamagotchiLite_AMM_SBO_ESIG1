using System;
using TamagotchiLite_AMM_SBO_ESIG1.Ecrans;
using TamagotchiLite_AMM_SBO_ESIG1.Models;
using TamagotchiLite_AMM_SBO_ESIG1.Services;
using TamagotchiLite_AMM_SBO_ESIG1.Utils;

namespace TamagotchiLite_AMM_SBO_ESIG1.Controllers
{
    public class GameController
    {
        private readonly AMM_JoueAvecMoi _jeu = new();
        private readonly AMM_Faim_JoueAvecMoi _faimMsg = new();
        private readonly AMM_Bonheur_JoueAvecMoi _bonheurMsg = new();
        private readonly AMM_Energie_JoueAvecMoi _energieMsg = new();
        private readonly AMM_FinDuJeu _fin = new();

        private readonly GameService _game = new();

        public void NouvellePartie()
        {
            string espece = AskChoice("Choisissez votre animal", new[] { "Raton laveur", "Fennec", "Écureuil" });
            string nom = Input.ReadNonEmpty("Nom du Tamagotchi: ");
            var pet = new AnimalCompagnie(espece, nom);

            bool quitter = false;
            while (!quitter)
            {
                int choix = _jeu.AfficherEtatEtChoix(pet);

                switch (choix)
                {
                    case 1: _game.AgirNourrir(pet); _faimMsg.AfficherMessage(); break;
                    case 2: _game.AgirJouer(pet); _bonheurMsg.AfficherMessage(); break;
                    case 3: _game.AgirDormir(pet); _energieMsg.AfficherMessage(); break;
                    case 4: quitter = true; continue;
                }

                _game.DeriveNaturelle(pet);

                if (_game.EstMort(pet))
                {
                    bool rejouer = _fin.AfficherEtRedemander(pet);
                    if (rejouer)
                    {
                        espece = AskChoice("Choisissez votre animal", new[] { "Raton laveur", "Fennec", "Écureuil" });
                        nom = Input.ReadNonEmpty("Nom du Tamagotchi: ");
                        pet = new AnimalCompagnie(espece, nom);
                        continue;
                    }
                    quitter = true;
                }
            }
        }

        private static string AskChoice(string label, string[] options)
        {
            Console.Clear();
            Console.WriteLine(label);
            for (int i = 0; i < options.Length; i++) Console.WriteLine($"{i + 1}. {options[i]}");
            return options[Input.ReadInt("Votre choix: ", 1, options.Length) - 1];
        }
    }
}
