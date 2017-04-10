using System;
using System.Collections.Generic;

namespace DistributeurDeBillets
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Bonjour, veuillez insérer votre carte");

            WaitForEnterKey();

            Console.WriteLine("Merci de saisir votre code secret à 4 chiffres.");

            var codeSecret = Console.ReadLine();
            codeSecret = CheckLength(codeSecret);

            bool conversionPassed = false;

            while (!conversionPassed)
            {
                try
                {
                    var code = Convert.ToInt16(codeSecret);
                    conversionPassed = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Merci de saisir uniquement des chiffres.");
                    codeSecret = Console.ReadLine();
                    codeSecret = CheckLength(codeSecret);
                }
            }

            Console.WriteLine("Quel opération souhaitez-vous effectuer ?");

            Console.ReadLine();

            Console.WriteLine("Quel montant désirez-vous retirer ?");

            Console.ReadLine();

            Console.WriteLine("Interrogation du compte en cours...");

            System.Threading.Thread.Sleep(5000);

            Console.WriteLine("Pour obtenir vos billets, merci de récupérer votre carte.");

            WaitForEnterKey();
        }

        private static string CheckLength(string codeSecret)
        {
            while (codeSecret.Length != 4)
            {
                Console.WriteLine("Merci de saisir 4 chiffres.");
                codeSecret = Console.ReadLine();
            }

            return codeSecret;
        }

        /// <summary>
        /// Permet d'attendre que l'utilisateur appuie sur la touche entrée.
        /// </summary>
        private static void WaitForEnterKey()
        {
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {

            }
        }
    }
}