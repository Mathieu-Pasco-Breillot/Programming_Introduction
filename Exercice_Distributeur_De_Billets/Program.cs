﻿using System;
using System.Collections.Generic;

namespace DistributeurDeBillets
{
    internal class Program
    {
        private static Random r = new Random();

        private static bool conversionPassed = false;

        public static void Main(string[] args)
        {
            int accountBalande = r.Next(-1000, 1000);

            Console.WriteLine("Bonjour, veuillez insérer votre carte.");

            WaitForEnterKey();

            Console.WriteLine("Merci de saisir votre code secret à 4 chiffres.");

            string codeSecret = Console.ReadLine();
            codeSecret = CheckLength(codeSecret, 4);

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
                    codeSecret = CheckLength(codeSecret, 4);
                }
            }

            conversionPassed = false;

            Console.WriteLine("Quel opération souhaitez-vous effectuer ?\n 1. Retrait\n 2. Dépôt");

            string operation = Console.ReadLine();
            operation = CheckLength(operation, 1);
            short choice = -1;

            while (!conversionPassed)
            {
                try
                {
                    choice = Convert.ToInt16(operation);
                    conversionPassed = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Merci de saisir uniquement des chiffres.");
                    operation = Console.ReadLine();
                    operation = CheckLength(operation, 1);
                }
            }

            conversionPassed = false;
            short previousChoice = -1;
            do
            {
                switch (choice)
                {
                    case 1:
                        previousChoice = choice;
                        Console.WriteLine("Quel montant désirez-vous retirer ?");
                        Console.ReadLine();
                        Console.WriteLine("Interrogation du compte en cours...");
                        System.Threading.Thread.Sleep(5000);
                        Console.WriteLine("Pour obtenir vos billets, merci de récupérer votre carte.");
                        break;
                    case 2:
                        Console.WriteLine("Nous sommes désolé, le dépôt d'argent n'est pas encore disponible sur ce DAB.\n");
                        previousChoice = choice;
                        OperationChoice(out operation, out choice);                        
                        break;
                    default:
                        Console.WriteLine("Votre choix doit être 1 ou 2 uniquement.\n");
                        previousChoice = choice;
                        OperationChoice(out operation, out choice);
                        break;
                }
            } while (choice != 1 || previousChoice != 1);

            WaitForEnterKey();
        }

        private static void OperationChoice(out string operation, out short choice)
        {
            Console.WriteLine("Quel opération souhaitez-vous effectuer ?\n 1. Retrait\n 2. Dépôt\n");

            operation = Console.ReadLine();
            operation = CheckLength(operation, 1);
            choice = -1;

            while (!conversionPassed)
            {
                try
                {
                    choice = Convert.ToInt16(operation);
                    conversionPassed = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Merci de saisir uniquement des chiffres.");
                    operation = Console.ReadLine();
                    operation = CheckLength(operation, 1);
                }
            }

            conversionPassed = false;
        }

        /// <summary>
        /// Permet de vérifier que l'entrée utilisateur est de la longueur attendue.
        /// </summary>
        /// <param name="value">La saisie de l'utilisateur.</param>
        /// <param name="length">La longueur attendue de la saisie de l'utilisateur.</param>
        /// <returns></returns>
        private static string CheckLength(string value, int length)
        {
            while (value.Length != length)
            {
                Console.WriteLine("Merci de saisir 4 chiffres.");
                value = Console.ReadLine();
            }

            return value;
        }

        /// <summary>
        /// Permet d'attendre que l'utilisateur appuie sur la touche entrée.
        /// </summary>
        private static void WaitForEnterKey()
        {
            Console.WriteLine("\nAppuyer sur Entré pour continuer.\n");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {

            }
        }
    }
}