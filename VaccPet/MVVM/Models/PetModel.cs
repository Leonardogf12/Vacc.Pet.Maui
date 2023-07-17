using SQLite;

namespace VaccPet.MVVM.Models
{
    public class PetModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public DateTime BirthDate { get; set; }        
        public string Animal { get; set; }
        public double Weight { get; set; }
        public string Sex { get; set; }
        public bool Catrated { get; set; }
        public string Observation { get; set; }
        public byte[] ImageData { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; }

        
    }
}
