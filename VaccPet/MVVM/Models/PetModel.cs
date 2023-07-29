using SQLite;
using System.ComponentModel.DataAnnotations.Schema;
using VaccPet.MVVM.ViewModels;

namespace VaccPet.MVVM.Models
{
    [SQLite.Table("Pet")]
    public class PetModel : BaseViewModel
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

    }
}
