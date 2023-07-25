using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccPet.Helpers.Models
{
    public class VaccineHelper
    {
        public int Key { get; set; }
        public string Value { get; set; }

        public List<VaccineHelper> GetVaccines(string specie)
        {
            if (specie == "Cachorro")
            {
                return new List<VaccineHelper>()
                {
                    new VaccineHelper{Key = 1, Value =  "V10"},
                    new VaccineHelper{Key = 2, Value =  "V8"},
                    new VaccineHelper{Key = 3, Value =  "V4"},
                    new VaccineHelper{Key = 4, Value =  "V5"},
                    new VaccineHelper{Key = 5, Value =  "Antirrábica"},
                    new VaccineHelper{Key = 6, Value =  "Traqueobronquite"},
                    new VaccineHelper{Key = 7, Value =  "Leptospirose"},
                    new VaccineHelper{Key = 8, Value =  "Giárdia"},
                    new VaccineHelper{Key = 9, Value =  "Leishmaniose"},
                    new VaccineHelper{Key = 10, Value = "Outra"},
                };
            }

            return new List<VaccineHelper> { new VaccineHelper { Key = 10, Value = "Outra" } };

        }
    }
}
