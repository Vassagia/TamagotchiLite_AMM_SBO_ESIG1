namespace TamagotchiLite_AMM_SBO_ESIG1.Models
{
    internal class AnimalCompagnie
    {
        // Espèce du Tamagotchi (ex. Raton laveur, Fennec, Écureuil)
        public string Espece { get; }

        // Nom donné par le joueur
        public string NomAnimal { get; }

        // Statistiques du Tamagotchi (faim, bonheur, énergie)
        public Stats Stats { get; } = new Stats();

        // Constructeur : création du Tamagotchi avec une espèce et un nom obligatoires
        public AnimalCompagnie(string espece, string nomAnimal)
        {
            // Vérifie que l'espèce est non vide, sinon redemande
            while (string.IsNullOrWhiteSpace(espece))
            {
                Console.Write("Veuillez entrer une espèce valide : ");
                espece = Console.ReadLine();
            }

            // Vérifie que le nom est non vide, sinon redemande
            while (string.IsNullOrWhiteSpace(nomAnimal))
            {
                Console.Write("Veuillez donner un nom à votre Tamagotchi : ");
                nomAnimal = Console.ReadLine();
            }

            // Supprime les espaces inutiles avant/après
            Espece = espece.Trim();
            NomAnimal = nomAnimal.Trim();
        }
    }
}
