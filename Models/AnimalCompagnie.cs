namespace TamagotchiLite_AMM_SBO_ESIG1.Models
{
    internal class AnimalCompagnie
    {
        public string Espece { get; }
        public string Nom { get; }
        public Stats Stats { get; } = new Stats();

        public AnimalCompagnie(string espece, string nom)
        {
            Espece = string.IsNullOrWhiteSpace(espece) ? "Axolotl" : espece.Trim();
            Nom = string.IsNullOrWhiteSpace(nom) ? "Tama" : nom.Trim();
        }
    }
}
