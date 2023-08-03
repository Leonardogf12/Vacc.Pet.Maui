using SQLite;
using SQLiteNetExtensions.Attributes;
using System.ComponentModel.DataAnnotations.Schema;
using VaccPet.MVVM.ViewModels;
using ForeignKeyAttribute = SQLiteNetExtensions.Attributes.ForeignKeyAttribute;

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

        [ForeignKey(typeof(PetModel))]
        public int PetlId { get; set; }
                
        [ManyToOne]
        [NotMapped]
        public PetModel PetModel { get; set; }
        
    }
}
