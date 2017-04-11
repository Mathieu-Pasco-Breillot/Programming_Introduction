using System;
using System.Collections.Generic;
using System.Media;
using System.Security;

namespace DistributeurDeBillets
{
    internal class Program
    {
        private static bool conversionPassed = false;

        public static void Main(string[] args)
        {
            #region Initialization
            // Permet d'afficher des caractères spéciaux dans la console.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Random r = new Random();

            // Permet de créer un solde aléatoire à chaque démarrage du programme.
            double accountBalance = Math.Round(r.NextDouble() * 1000D, 2); 
            #endregion

            Console.WriteLine("\nBonjour, veuillez insérer votre carte.");

            WaitForEnterKey();

            Console.WriteLine("Merci de saisir votre code secret à 4 chiffres.\n");

            #region SecretCode

            string codeSecret = GetSecretCode();
            codeSecret = CheckLength(codeSecret, 4);

            while (!conversionPassed)
            {
                try
                {
                    short code = Convert.ToInt16(codeSecret);
                    conversionPassed = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Merci de saisir uniquement des chiffres.");
                    codeSecret = GetSecretCode();
                    codeSecret = CheckLength(codeSecret, 4);
                }
            }

            conversionPassed = false;

            #endregion

            Console.WriteLine("Quel opération souhaitez-vous effectuer ?\n 1. Retrait\n 2. Dépôt\n 3. Consulter mon solde\n 4. Quitter\n");

            #region OperationChoice
            string operation = Console.ReadLine();
            short choice = -1, previousChoice = -1;

            operation = CheckLength(operation, 1, false);

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
                    operation = CheckLength(operation, 1, false);
                }
            }

            conversionPassed = false; 
            #endregion

            do
            {
                switch (choice)
                {
                    case 1:
                        previousChoice = ProceedWithdrawal(ref accountBalance, ref operation, choice);
                        break;
                    case 2:
                        choice = ProceedDeposit(out operation, choice, out previousChoice);
                        break;
                    case 3:
                        choice = DisplayBalance(accountBalance, out operation, choice, out previousChoice);
                        break;
                    case 4:
                        ProceedExit();
                        break;
                    default:
                        choice = DisplayChoiceError(out operation, choice, out previousChoice);
                        break;
                }
            } while (choice != 1 || previousChoice != 1);

            WaitForEnterKey();
        }

        private static short DisplayChoiceError(out string operation, short choice, out short previousChoice)
        {
            Console.WriteLine("\nVotre choix doit être 1, 2, 3 ou 4.\n");
            previousChoice = choice;
            OperationChoice(out operation, out choice);
            return choice;
        }

        /// <summary>
        /// Permet de quitter l'application convenablement en affichant un message d'au revoir à l'utilisateur.
        /// </summary>
        private static void ProceedExit()
        {
            Console.WriteLine("\nMerci de votre visite, à bientôt !");
            System.Threading.Thread.Sleep(1000);
            Environment.Exit(0);
        }

        /// <summary>
        /// Affiche le solde du compte bancaire.
        /// </summary>
        /// <param name="accountBalance">La valeur du compte bancaire à afficher.</param>
        /// <param name="operation"></param>
        /// <param name="choice"></param>
        /// <param name="previousChoice"></param>
        /// <returns></returns>
        private static short DisplayBalance(double accountBalance, out string operation, short choice, out short previousChoice)
        {
            previousChoice = choice;
            Console.WriteLine($"\nLe solde de votre compte est : {accountBalance} €\n");
            OperationChoice(out operation, out choice);
            return choice;
        }

        /// <summary>
        /// Permet de procéder au dépôt d'argent sur le compte bancaire.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="choice"></param>
        /// <param name="previousChoice"></param>
        /// <returns></returns>
        private static short ProceedDeposit(out string operation, short choice, out short previousChoice)
        {
            Console.WriteLine("\nNous sommes désolé, le dépôt d'argent n'est pas encore disponible sur ce DAB.\n");
            previousChoice = choice;
            OperationChoice(out operation, out choice);
            return choice;
        }

        /// <summary>
        /// Permet de procéder au retrait d'argent sur le compte bancaire.
        /// </summary>
        /// <param name="accountBalance">Le solde du compte bancaire dont on va faire le retrait.</param>
        /// <param name="operation"></param>
        /// <param name="choice"></param>
        /// <returns></returns>
        private static short ProceedWithdrawal(ref double accountBalance, ref string operation, short choice)
        {
            short previousChoice = choice;
            Console.WriteLine("\nQuel montant désirez-vous retirer ?\n");
            while (!conversionPassed)
            {
                try
                {
                    string saisie = Console.ReadLine();
                    if (saisie.Contains("."))
                        saisie = saisie.Replace('.', ',');
                    float retrait = Convert.ToSingle(saisie);
                    conversionPassed = true;
                    Console.WriteLine("Interrogation du compte en cours...\n");
                    System.Threading.Thread.Sleep(2000);
                    if (retrait < accountBalance)
                    {
                        accountBalance -= retrait;
                        Console.WriteLine($"Le retrait de {saisie.Replace('.', ',')} € a été effectué avec succès.\n");
                        Console.WriteLine("Pour obtenir vos billets, merci de récupérer votre carte.");
                    }
                    else
                    {
                        Console.WriteLine($"Le retrait de {saisie.Replace('.', ',')} € n'a pas pu être effectué en raison d'un solde trop faible.\n");
                        Console.WriteLine("Merci de récupérer votre carte.");
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Merci de saisir uniquement des chiffres.\n");
                    operation = Console.ReadLine();
                    operation = CheckLength(operation, 1);
                }
            }
            conversionPassed = false;
            StartBip();
            return previousChoice;
        }

        /// <summary>
        /// Permet de diffuser le bip indiquant à l'utilisateur de retirer sa carte bancaire.
        /// </summary>
        private static void StartBip()
        {
            using (SoundPlayer player = new SoundPlayer())
            {
                player.SoundLocation = Environment.CurrentDirectory + "\\Bip.wav";
                player.Play();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="choice"></param>
        private static void OperationChoice(out string operation, out short choice)
        {
            Console.WriteLine("Quel opération souhaitez-vous effectuer ?\n 1. Retrait\n 2. Dépôt\n 3. Consulter mon solde\n 4. Quitter\n");

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
        private static string CheckLength(string value, int length, bool isForSecretCode = true)
        {
            while (value.Length != length)
            {
                Console.WriteLine($"Merci de saisir {length} chiffres.\n");
                if (!isForSecretCode)
                {
                    value = Console.ReadLine();
                }
                else
                {
                    value = GetSecretCode();
                }
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

        /// <summary>
        /// Permet d'obtenir le code secret de l'utilisateur tout en masquant la saisie de ce dernier.
        /// </summary>
        /// <returns>Le code secret saisit.</returns>
        private static string GetSecretCode()
        {
            string pwd = "";
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.Remove(pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    pwd += i.KeyChar;
                    Console.Write("*");
                }
            }
            Console.WriteLine("\n");
            return pwd;
        }
    }
}