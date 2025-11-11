using System;
using TamagotchiLite_AMM_SBO_ESIG1.Ecrans;
using TamagotchiLite_AMM_SBO_ESIG1.Models;
using TamagotchiLite_AMM_SBO_ESIG1.Services;

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

        // Point d'entrée pour lancer une nouvelle partie
        public void NouvellePartie()
        {
            // L'écran SBO_Naissance gère le choix de l'animal et du nom
            AnimalCompagnie pet = SBO_Naissance.EcranNaissance();

            bool quitter = false;

            // Boucle principale de la partie
            while (!quitter)
            {
                int choix = _jeu.AfficherEtatEtChoix(pet);

                switch (choix)
                {
                    case 1:
                        _game.AgirNourrir(pet);
                        _faimMsg.AfficherMessage();
                        break;

                    case 2:
                        _game.AgirJouer(pet);
                        _bonheurMsg.AfficherMessage();
                        break;

                    case 3:
                        _game.AgirDormir(pet);
                        _energieMsg.AfficherMessage();
                        break;

                    case 4:
                        // Le joueur choisit de quitter la partie
                        quitter = true;
                        continue;
                }

                // Dérive naturelle des stats
                _game.DeriveNaturelle(pet);

                // Vérification de la mort
                if (_game.EstMort(pet))
                {
                    bool rejouer = _fin.AfficherEtRedemander(pet);

                    if (rejouer)
                    {
                        // Pour rejouer, on repasse par l'écran SBO_Naissance
                        pet = SBO_Naissance.EcranNaissance();
                        continue;
                    }

                    quitter = true;
                }
            }
        }
    }
}

