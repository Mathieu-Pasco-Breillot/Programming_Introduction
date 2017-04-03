using Programming_Introduction.Transverse.Utils;

namespace Programming_Introduction.Model
{
    public class Animal
    {
        public string Nom { get; set; }
        public short Age { get; set; }
        public short NombreDePattes { get; set; }
        public short NombreDeYeux { get; set; }
        public float Taille { get; set; }
        public AnimalType Type { get; set; }
        public bool HasTail { get; set; }
        public bool HasMustache { get; set; }
    }
}
