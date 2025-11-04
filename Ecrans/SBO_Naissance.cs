using System;

namespace TamagotchiLite_AMM_SBO_ESIG1.Ecrans
{
    internal class SBO_Naissance
    {
        // Ecran naissance: choix de l'animal, de son nom.
        public static void EcranNaissance()
        {
            AfficherLigneHaut();
            Vide();
            Console.WriteLine("Naissance");
            Vide();
            AfficherLigneBas();
            Vide(2);

            Console.WriteLine("1. Raton laveur");
            Console.WriteLine("2. Fennec");
            Console.WriteLine("3. Écureuil");
            Vide(2);

            Console.WriteLine("Choisissez votre animal (1,2 ou 3) :");
            int choix = VerificationSaisie(1, 3); // On récupère la valeur vérifiée.
            Vide(2);

            Console.WriteLine("Votre oeuf éclot....");
            Console.WriteLine("Donnez-lui un nom :");
            string NomAnimal = Console.ReadLine();
            Vide(2);

            Console.WriteLine($"Bienvenue à {NomAnimal} ! Prenez bien soin de lui !");
            // EcranJoueAvecMoi();
        }
    }
}
