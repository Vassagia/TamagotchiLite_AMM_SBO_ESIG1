namespace TamagotchiLite_AMM_SBO_ESIG1.Compat
{
    public static class SBOExtensions
    {
        public static void Afficher(this TamagotchiLite_AMM_SBO_ESIG1.Ecrans.SBO_Naissance _)
            => TamagotchiLite_AMM_SBO_ESIG1.Ecrans.SBO_Naissance.EcranNaissance();

        public static void Afficher(this TamagotchiLite_AMM_SBO_ESIG1.Ecrans.SBO_Quitter _)
            => TamagotchiLite_AMM_SBO_ESIG1.Ecrans.SBO_Quitter.EcranAuRevoir();
    }
}
