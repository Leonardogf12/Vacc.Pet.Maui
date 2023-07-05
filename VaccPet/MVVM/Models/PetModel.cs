using SQLite;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Observation { get; set; }
        public byte[] ImageData { get; set; }

    }
}
