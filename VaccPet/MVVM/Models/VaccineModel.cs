using SQLite;
using SQLiteNetExtensions.Attributes;
using VaccPet.MVVM.ViewModels;

namespace VaccPet.MVVM.Models
{
    [SQLite.Table("Vaccine")]
    public class VaccineModel : BaseViewModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime VaccinationDate { get; set; }
        public string VaccineName { get; set; }
        public DateTime RevaccinateDate { get; set; }
        public double Weight { get; set; }
      
        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(PetModel))]
        public int PetlId { get; set; }


        [ManyToOne]
        public PetModel PetModel { get; set; }

    }
}
