using SQLite;

namespace VaccPet.MVVM.Models
{
    public class VaccineModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime VaccinationDate { get; set; }
        public string  VaccineName { get; set; }
        public DateTime RevaccinateDate { get; set; }
        public double Weight { get; set; }
    }
}
