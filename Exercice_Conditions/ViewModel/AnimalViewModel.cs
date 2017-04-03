using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programming_Introduction.Model;
using Programming_Introduction.Transverse.Utils;

namespace Exercice_Conditions.ViewModel
{
    public class AnimalViewModel
    {
        /// <summary>
        /// Champ privé de la propriété MonAnimal de type <c>Animal</c>.
        /// </summary>
        private Animal monAnimal;

        /// <summary>
        /// Propriété public permettant d'interagir sur l'objet MonAnimal de type <c>Animal</c>.
        /// </summary>
        public Animal MonAnimal { get => monAnimal; set => monAnimal = value; }

        /// <summary>
        /// Collection contenant tous les types d'animaux.
        /// </summary>
        private List<AnimalType> animalTypes = new List<AnimalType> { AnimalType.Chat, AnimalType.Chien, AnimalType.Hamster, AnimalType.Lapin, AnimalType.Rat, AnimalType.Souris };

        /// <summary>
        /// Collection contenant seulement les types d'animaux autorisés.
        /// </summary>
        private List<AnimalType> allowedAnimalTypes = new List<AnimalType> { AnimalType.Chat, AnimalType.Hamster, AnimalType.Lapin, AnimalType.Souris };
    }
}
