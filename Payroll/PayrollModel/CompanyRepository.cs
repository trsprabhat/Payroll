using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayrollModel
{
    /// <summary>
    /// This class provides the methods for operations on Company and related objects
    /// </summary>
    public class CompanyRepository :ICompanyRepository,IDisposable
    {
        #region Declarations

        //Create an object of Payroll_Context
        private Payroll_Context payroll;

        private bool disposed = false;

        #endregion

        #region Constructor

        public CompanyRepository(Payroll_Context payroll)
        {
            //Pass the Payroll_Context object 
            this.payroll = payroll;
        }

        #endregion

     #region CompanyType

        #region GetCompanyType

        public IEnumerable<CompanyType> GetCompanyType()
        {
            //Gets the company types
            return payroll.CompanyTypes.ToList();
        }

        #endregion

        #region GetCompanyTypeById

        public CompanyType GetCompanyTypeById(int companytypeId)
        {
            //return only rows that have the given id
            return payroll.CompanyTypes.Where(x => x.CompanyTypeId == companytypeId).First();
        }

        #endregion

        #region InsertCompanyType

        public void InsertCompanyType(CompanyType companytype)
        {
            //Adds the companytype object to the context
            payroll.CompanyTypes.AddObject(companytype);
        }

        #endregion

        #region UpdateCompanyType

        public void UpdateCompanyType(CompanyType companytype)
        {
            //Apply the country object changed values to the context
            payroll.CompanyTypes.ApplyCurrentValues(companytype);
        }

        #endregion

        #region DeleteCompanyType

        public void DeleteCompanyType(int companytypeId)
        {
            throw new NotImplementedException();
        }
        #endregion

     #endregion

     #region Company

        #region GetCompanies
        /// <summary>
        /// Get all the Company
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<Company> GetCompanies()
        {
            //Gets the Company
            return payroll.Companies.ToList();
        }

        #endregion

     #endregion

     #region CompanyBranches

        #region GetCompanies
        /// <summary>
        /// Get all the CompanyBranch
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<CompanyBranch> GetCompanyBranches()
        {
            //Gets the CompanyBranch
            return payroll.CompanyBranches.ToList();
        }

        #endregion

     #endregion

        #region Save
        /// <summary>
        /// Save the object
        /// </summary>
        public void Save()
        {
            payroll.SaveChanges();
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Disposes the Payroll context(if not already done by GC)
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    payroll.Dispose();
                }
            }
            this.disposed = true;
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Dispose the context
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
