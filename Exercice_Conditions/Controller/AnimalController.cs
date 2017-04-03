using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programming_Introduction.Transverse.Utils;

namespace Exercice_Conditions.Controller
{
    internal class AnimalController
    {
        /// <summary>
        /// méthode permettant de vérifier que le nom de l'animal ne contient que les caractères a-Z et que le nom de l'animal ne dépasse pas 10 caractères.
        /// </summary>
        /// <param name="nom">Le nom de l'animal à vérifier.</param>
        /// <returns>Retourne <c>True</c> si le nom de l'animal est correct; <c>False</c> sinon.</returns>
        private bool CheckNom(string nom)
        {
            bool result = false;

            return result;
        }

        /// <summary>
        /// Méthode permettant de vérifier que l'âge est compris strictement entre 0 et 99 inclus.
        /// </summary>
        /// <param name="age">L'âge de l'animal</param>
        /// <returns>Retourne <c>True</c> si l'âge  est dans la plage indiquée; <c>False</c> sinon.</returns>
        private bool CheckAge(short age)
        {
            bool result = false;

            return result;
        }

        /// <summary>
        /// Méthode permettant de vérifier que le nombre de pattes est compris strictement entre 0 et 4 inclus.
        /// </summary>
        /// <param name="nbPattes">Le nombre de pattes que possède l'animal.</param>
        /// <returns>Retourne <c>True</c> si le nombre de pattes est dans la plage indiquée; <c>False</c> sinon.</returns>
        private bool CheckNbPattes(short nbPattes)
        {
            bool result = false;

            return result;
        }

        /// <summary>
        /// Méthode permettant de vérifier que le nombre d'yeux est compris strictement entre 0 et 2 inclus.
        /// </summary>
        /// <param name="nbYeux">Le nombre d'yeux que possède l'animal.</param>
        /// <returns>Retourne <c>True</c> si le nombre d'yeux est dans la plage indiquée; <c>False</c> sinon.</returns>
        private bool CheckNbYeux(short nbYeux)
        {
            bool result = false;

            return result;
        }

        /// <summary>
        /// Méthode permettant de vérifier que la taille de l'animal est comprise strictement entre 10 centimètres et 1.5 mètres inclus.
        /// </summary>
        /// <param name="taille">La taille de l'animal.</param>
        /// <returns>Retourne <c>True</c> si la taille est dans la plage indiquée; <c>False</c> sinon.</returns>
        private bool CheckTaille(float taille)
        {
            bool result = false;

            return result;
        }

        /// <summary>
        /// Méthode permettant de vérifier que le type de l'animal est bien l'un de ceux autorisé.
        /// </summary>
        /// <param name="type">Le type de l'animal</param>
        /// <returns>Retourne <c>True</c> si le type de l'animal est dans la liste des types autorisés; <c>False</c> sinon.</returns>
        private bool CheckAnimalType(AnimalType type)
        {
            bool result = false;

            return result;
        }
    }
}
