using System;
using System.Collections.Generic;
using System.Text;
using UserMedication.Models;
using UserMedication.Repositories;

namespace UserMedication
{
    public interface IUnitOfWork
    {
        IUserMedicationRepository UserMedicationRepository { get; }
        ISeedDataRepository seedDataRepository {get;}

    }
}
