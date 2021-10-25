using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UserMedication.DAL;
using UserMedication.Models;
using static UserMedication.UtilityClass;

namespace UserMedication.Repositories
{
    class SeedDataRepository : ISeedDataRepository
    {
        private readonly UserMedicationDAL _userMedicationDal;
        public SeedDataRepository(UserMedicationDAL userMedicationDal)
        {
            _userMedicationDal = userMedicationDal;
        }

        public UserMedicationDAL UserMedicationDal { get; }

        public void CreateSeedData()
        {
            var userMedicationsList = new List<UserMedicationData>()
            {

                new UserMedicationData(){ Name="bob",Email="bob@gmail.com",Province=(int)Provinces.Alberta,IsActive=true },
                new UserMedicationData(){ Name="matt",Email="matt@gmail.com",Province=(int)Provinces.BritishColumbia,IsActive=true},
                new UserMedicationData(){ Name="robert",Email="robert@gmail.com",Province=(int)Provinces.Manitoba,IsActive=true},
                new UserMedicationData(){ Name="calvin",Email="cslvin@gmail.com",Province=(int)Provinces.NewBrunswick,IsActive=true},
                new UserMedicationData(){ Name="bob2",Email="bob2@gmail.com",Province=(int)Provinces.Alberta,IsActive=true },
                new UserMedicationData(){ Name="matt2",Email="matt2@gmail.com",Province=(int)Provinces.BritishColumbia,IsActive=true},
                new UserMedicationData(){ Name="robert2",Email="robert2@gmail.com",Province=(int)Provinces.Manitoba,IsActive=true},
                new UserMedicationData(){ Name="calvin2",Email="calvin2@gmail.com",Province=(int)Provinces.NewBrunswick,IsActive=true},
                new UserMedicationData(){ Name="bob3",Email="bob3@gmail.com",Province=(int)Provinces.Alberta,IsActive=true },
                new UserMedicationData(){ Name="matt3",Email="matt3@gmail.com",Province=(int)Provinces.BritishColumbia,IsActive=true},
                new UserMedicationData(){ Name="robert3",Email="robert3@gmail.com",Province=(int)Provinces.Manitoba,IsActive=true},
                new UserMedicationData(){ Name="calvin3",Email="cslvin3@gmail.com",Province=(int)Provinces.NewBrunswick,IsActive=true},
                new UserMedicationData(){ Name="bob4",Email="bob4@gmail.com",Province=(int)Provinces.Saskatchewan,IsActive=true },
                new UserMedicationData(){ Name="matt4",Email="matt4@gmail.com",Province=(int)Provinces.BritishColumbia,IsActive=true},
                new UserMedicationData(){ Name="robert4",Email="robert4@gmail.com",Province=(int)Provinces.Manitoba,IsActive=true},
                new UserMedicationData(){ Name="calvin4",Email="cslvin4@gmail.com",Province=(int)Provinces.Saskatchewan,IsActive=true},
                new UserMedicationData(){ Name="bob5",Email="bob5@gmail.com",Province=(int)Provinces.Ontario,IsActive=true },
                new UserMedicationData(){ Name="matt5",Email="matt5@gmail.com",Province=(int)Provinces.BritishColumbia,IsActive=true},
                new UserMedicationData(){ Name="robert5",Email="robert5@gmail.com",Province=(int)Provinces.NorthwestTerritories,IsActive=true},
                new UserMedicationData(){ Name="calvin5",Email="cslvin5@hotmail.com",Province=(int)Provinces.NewfoundlandAndLabrador,IsActive=true}

            };
            DataTable UsersDT = new DataTable();
            UsersDT.Columns.Add("Name");
            UsersDT.Columns.Add("Email");
            UsersDT.Columns.Add("ProvinceID");
            UsersDT.Columns.Add("IsActive");
            userMedicationsList.ForEach(x => UsersDT.Rows.Add(x.Name, x.Email, x.Province, x.IsActive));


            DataTable UserMedicationDT = new DataTable();
            UserMedicationDT.Columns.Add("UserID");
            UserMedicationDT.Columns.Add("MedicationID");

            UserMedicationDT.Rows.Add(1, (int)Medications.depression);
            UserMedicationDT.Rows.Add(1, (int)Medications.obesity);
            UserMedicationDT.Rows.Add(2, (int)Medications.diabetesT2);
            UserMedicationDT.Rows.Add(2, (int)Medications.migraine);
            UserMedicationDT.Rows.Add(2, (int)Medications.obesity);
            UserMedicationDT.Rows.Add(3, (int)Medications.obesity);
            UserMedicationDT.Rows.Add(3, (int)Medications.depression);
            UserMedicationDT.Rows.Add(3, (int)Medications.diabetesT1);
            UserMedicationDT.Rows.Add(3, (int)Medications.diabetesT2);
            UserMedicationDT.Rows.Add(3, (int)Medications.migraine);
            UserMedicationDT.Rows.Add(4, (int)Medications.obesity);
            UserMedicationDT.Rows.Add(5, (int)Medications.diabetesT1);
            var res = _userMedicationDal.SeedData(UsersDT, UserMedicationDT);

        }
    }
}
