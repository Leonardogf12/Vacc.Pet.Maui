using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccPet.Helpers.Models;

namespace VaccPet.Services
{
    public class AnimalService : IAnimalService
    {
        public Animal _animal { get; }

        public List<Animal> GetBreedsByAnimal(string animalSelected)
        {
            if (animalSelected == "Cachorro")
            {
               return _animal.GetBreedDogs();
            }
            else if (animalSelected == "Gato")
            {
                return _animal.GetBreedCats();
            }
            else if (animalSelected == "Ave")
            {
                return _animal.GetBreedBirds();
            }
            else
            {
                return new List<Animal> { new Animal { Key = 1000, Value = "Não Definida" } };
            }
        }
    }
}
