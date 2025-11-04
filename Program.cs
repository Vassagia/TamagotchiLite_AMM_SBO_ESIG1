using System;
using TamagotchiLite_AMM_SBO_ESIG1.Controllers;

namespace TamagotchiLite_AMM_SBO_ESIG1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Tamagotchi Lite — ESIG1";
            new MenuController().Run();
        }
    }
}
