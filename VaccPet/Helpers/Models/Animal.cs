namespace VaccPet.Helpers.Models
{
    public class Animal
    {
        public int Key { get; set; }
        public string Value { get; set; }

        public List<Animal> GetAllAnimals()
        {
            return new List<Animal>()
            {
                new Animal{Key = 1, Value = "Cachorro"},
                new Animal{Key = 2, Value = "Gato"},
                new Animal{Key = 3, Value = "Peixe"},
                new Animal{Key = 4, Value = "Pássaro"},
                new Animal{Key = 5, Value = "Coelho"},
                new Animal{Key = 6, Value = "Hamster"},
                new Animal{Key = 7, Value = "Tartaruga"},
                new Animal{Key = 8, Value = "Porquinho-da-índia"},
                new Animal{Key = 9, Value = "Furão"},
                new Animal{Key = 10, Value = "Chinchila"},
                new Animal{Key = 11, Value = "Rato"},
                new Animal{Key = 12, Value = "Gerbil"},
                new Animal{Key = 13, Value = "Cobra"},
                new Animal{Key = 14, Value = "Lagarto"},
                new Animal{Key = 15, Value = "Cavalo"},
                new Animal{Key = 16, Value = "Porco"},
            };
        }
    }
}
