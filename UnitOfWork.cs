using Microsoft.Extensions.Configuration;
using UserMedication.DAL;
using UserMedication.Models;
using UserMedication.Repositories;

namespace UserMedication
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly UserMedicationDAL _userMedicationDAL;
        public UnitOfWork(IConfiguration config)
        {
            _userMedicationDAL = new UserMedicationDAL(config);
        }
        public ISeedDataRepository seedDataRepository => new SeedDataRepository(_userMedicationDAL);
        public IUserMedicationRepository UserMedicationRepository => new UserMedicationRepository(_userMedicationDAL);
    }
}
