using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayrollModel
{
    public interface IEmployeeRepository : IDisposable
    {
       
        #region Religion
        IEnumerable<Religion> GetReligions();

        Religion GetReligionByID(int religionId);

        void InsertReligion(Religion religion);

        void UpdateReligion(Religion religion);

        void DeleteReligion(int religionId);

        #endregion

        #region Caste

        IEnumerable<Caste> GetCastes();

        Caste GetCasteByID(int casteId);

        Caste GetCasteByReligionID(int religionId);

        void InsertCaste(Caste caste);

        void UpdateCaste(Caste caste);

        void DeleteCaste(int casteId);

        #endregion

        #region EmployeeType

        IEnumerable<EmployeeType> GetEmployeeTypes();

        EmployeeType GetEmployeeTypeById(int employeetypeId);

        void InsertEmployeeType(EmployeeType employeetype);

        void UpdateEmployeeType(EmployeeType employeetype);

        void DeleteEmployeeType(int employeetypeId);

        #endregion

        void Save();
    }
}
