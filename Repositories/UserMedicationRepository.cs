using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMedication.DAL;
using UserMedication.Models;
using static UserMedication.UtilityClass;

namespace UserMedication.Repositories
{
    public class UserMedicationRepository : IUserMedicationRepository
    {

        private readonly UserMedicationDAL _userMedicationDAL;
        public UserMedicationRepository(UserMedicationDAL userMedicationDAL)
        {
            _userMedicationDAL = userMedicationDAL;
        }
        public async Task<bool> Add(UserMedicationData entity)
        {
            return await  _userMedicationDAL.AddUser(entity);
        }



        public async Task<bool> DeactivateUser(int Id)
        {
            return await _userMedicationDAL.DeactivateUser(Id);
        }

        public async Task<UserMedicationData> Get(int id)
        {

            var table = await _userMedicationDAL.GellAllUserMedication();
            var list = GetListFromTable(table);
            return list.Where(x => x.UserId == id).FirstOrDefault();
        }

        public async Task<IEnumerable<UserMedicationData>> GetAll()
        {
            var table = await _userMedicationDAL.GellAllUserMedication();
            return GetListFromTable(table);

        }


        private List<UserMedicationData> GetListFromTable(DataTable dt)
        {
            var dict = new Dictionary<int, UserMedicationData>();

            foreach (DataRow row in dt.Rows)
            {
                if (!dict.ContainsKey((int)row["Userid"]))
                {
                    var userMedicationData = new UserMedicationData();
                    userMedicationData.UserId = (int)row["Userid"];
                    userMedicationData.Email = row["Email"].ToString();
                    userMedicationData.Name = row["name"].ToString();
                    userMedicationData.Province = int.Parse(row["ProvinceID"].ToString());
                    userMedicationData.Medication = new List<int>();
                    userMedicationData.Medication.Add(int.Parse(row["MedicationID"].ToString()));
                    userMedicationData.IsActive = (bool)row["IsActive"];
                    dict.Add((int)row["Userid"], userMedicationData);
                }
                else
                {
                    var obj = dict[(int)row["Userid"]];
                    obj.Medication.Add(int.Parse(row["MedicationID"].ToString()));
                }
            }
            return dict.Values.ToList();
        }


        public async Task<bool> Update(UserMedicationData entity)
        {
            return await _userMedicationDAL.UpdateUser(entity);
        }

        public async Task<IEnumerable<UserMedicationData>> Search(bool IsActive, Provinces Province, List<Medications> Medications)
        {
            var table = await _userMedicationDAL.GellAllUserMedication();
            var list = GetListFromTable(table);
            return list.Where(x => x.IsActive == IsActive && x.Province == (int)Province && x.Medication.Any(p1 => Medications.Any(p2 => (int)p2 == p1))).ToList();
        }
    }
}
