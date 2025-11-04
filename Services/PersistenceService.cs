using TamagotchiLite_AMM_SBO_ESIG1.Models;
using System.IO;

namespace TamagotchiLite_AMM_SBO_ESIG1.Services
{
    internal class PersistenceService
    {
        public void Save(AnimalCompagnie pet, string path)
        {
            // TODO: sérialiser JSON si vous activez la sauvegarde
            File.WriteAllText(path, "TODO");
        }

        public AnimalCompagnie? Load(string path)
        {
            // TODO: lire JSON si vous activez la sauvegarde
            return null;
        }
    }
}
