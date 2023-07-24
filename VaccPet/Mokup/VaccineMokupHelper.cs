using System.Collections.ObjectModel;

namespace VaccPet.Mokup
{
    public class VaccineMokupHelper
    {       
        public class VaccineMokup
        {           
            public DateTime VaccinationDate { get; set; }
            public DateTime RevaccinateDate { get; set; }           
            public string VaccineName { get; set; }
            public double Weight { get; set; } 

            public VaccineMokup()
            {              
            }
            
        }

        public class VaccineMokupData
        {
            public ObservableCollection<VaccineMokup> VaccineMokupCollection { get; private set; }

            void GenerateVaccineMokup()
            {
                ObservableCollection<VaccineMokup> result = new ObservableCollection<VaccineMokup>();
                
                result.Add(
                    new VaccineMokup()
                    {
                        VaccinationDate = new DateTime(2023, 1, 1),
                        RevaccinateDate = new DateTime(2005, 1, 6),                     
                        VaccineName = "Raiva",
                        Weight = 5,
                      
                    }
                );
                result.Add(
                   new VaccineMokup()
                   {
                       VaccinationDate = new DateTime(2023, 1, 1),
                       RevaccinateDate = new DateTime(2005, 1, 6),
                       VaccineName = "Raiva",
                       Weight = 5,

                   }
               );
                result.Add(
                   new VaccineMokup()
                   {
                       VaccinationDate = new DateTime(2023, 1, 1),
                       RevaccinateDate = new DateTime(2005, 1, 6),
                       VaccineName = "Raiva",
                       Weight = 5,

                   }
               );

                VaccineMokupCollection = result;
            }
            
            public VaccineMokupData()
            {
                GenerateVaccineMokup();
            }
        }
    }
}
