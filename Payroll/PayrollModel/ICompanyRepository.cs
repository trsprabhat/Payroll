using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayrollModel
{
    public interface ICompanyRepository
    {
        #region CompanyType
        IEnumerable<CompanyType> GetCompanyType();

        CompanyType GetCompanyTypeById(int companytypeId);

        void InsertCompanyType(CompanyType companytype);

        void UpdateCompanyType(CompanyType companytype);

        void DeleteCompanyType(int companytypeId);
        #endregion

        #region Company

        IEnumerable<Company> GetCompanies();

        #endregion

        #region CompanyBranch

        IEnumerable<CompanyBranch> GetCompanyBranches();

        #endregion

        #region Save

        void Save();

        #endregion
    }
}
