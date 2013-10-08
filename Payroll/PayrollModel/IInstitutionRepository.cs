using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayrollModel
{
    public interface IInstitutionRepository:IDisposable
    {
        #region InstitutionType

        IEnumerable<InstitutionType> GetInstitutionTypes();

        InstitutionType GetInstitutionTypeById(int institutiontypeId);

        void InsertInstitutionType(InstitutionType institutiontype);

        void UpdateInstitutionType(InstitutionType institutiontype);

        void DeleteInstitutionType(int institutiontypeId);

        #endregion

        #region Institution

        IEnumerable<Institution> GetInstitutions();

        Institution GetInstitutionById(int institutionId);

        void InsertInstitution(Institution institution);

        void UpdateInstitution(Institution institution);

        void DeleteInstitution(int institutionId);

        #endregion

        void Save();
    }
}
