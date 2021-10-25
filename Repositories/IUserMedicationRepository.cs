using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserMedication.Models;
using static UserMedication.UtilityClass;

namespace UserMedication.Repositories
{
    public interface IUserMedicationRepository : IGenericRepository<UserMedicationData>
    {
     Task<IEnumerable<UserMedicationData>> Search(bool IsActive, Provinces Province, List<Medications> Medications);
    }
}
