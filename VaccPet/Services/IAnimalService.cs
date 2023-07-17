using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccPet.Helpers.Models;

namespace VaccPet.Services
{
    public interface IAnimalService
    {
        List<Animal> GetBreedsByAnimal(string animalSelected);
    }
}
