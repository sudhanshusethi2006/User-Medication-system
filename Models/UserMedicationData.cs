
using System;
using System.Collections.Generic;
using System.Text;
using static UserMedication.UtilityClass;

namespace UserMedication.Models
{
   public class UserMedicationData
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public int? Province { get; set; }

 
        public List<int> Medication { get; set; }

        public bool? IsActive { get; set; }

    }
}
