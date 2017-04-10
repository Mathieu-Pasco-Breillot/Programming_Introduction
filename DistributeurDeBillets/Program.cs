using System;
using System.Collections.Generic;

namespace DistributeurDeBillets
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Bonjour, veuillez insérer votre carte");

            // Attendre que l'utilisateur appuye sur la touche entrée
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {

            }

            Console.WriteLine("Merci de saisir votre code secret.");

            Console.ReadLine();

            Console.WriteLine("Quel opération souhaitez-vous effectuer ?");

            Console.ReadLine();

            Console.WriteLine("Quel montant désirez-vous retirer ?");

            Console.ReadLine();

            Console.WriteLine("Interrogation du compte en cours...");

            System.Threading.Thread.Sleep(5000);

            Console.WriteLine("Pour obtenir vos billets, merci de récupérer votre carte.");
        }
    }
}