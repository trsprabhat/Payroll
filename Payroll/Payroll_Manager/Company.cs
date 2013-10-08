using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PayrollModel;

namespace Payroll_Manager
{
    public class Company
    {
        #region Declarations

        private ICompanyRepository companyRepository;

        #endregion

        #region Constructor

        public Company()
        {
            this.companyRepository = new CompanyRepository(new Payroll_Context());
        }

        #endregion

        #region CompanyType Methods

        #region GetCompanyType
        /// <summary>
        /// Get the Companytype details.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public IEnumerable<CompanyType> GetCompanyType()
        {

            //return all.
            return companyRepository.GetCompanyType();

        }

        #endregion

        #region GetCompanyTypeById
        /// <summary>
        /// Get the companytype details with respect to Id.
        /// </summary>
        /// <param name="companytypeId"></param>
        /// <returns></returns>
        public CompanyType GetCompanyTypeById(int companytypeId)
        {

            //return only rows that have the given id
            return companyRepository.GetCompanyTypeById(companytypeId);

        }

        #endregion

        #region AddCompanyType
        /// <summary>
        /// Add the companytype details
        /// </summary>
        /// <param name="companytype"></param>
        /// <returns>int</returns>
        public int AddCompanyType(CompanyType companytype)
        {
            try
            {
                //Add companytype object to context
                companyRepository.InsertCompanyType(companytype);

                //Save country
                companyRepository.Save();

                //returns 1 if successfull
                return 1;
            }
            catch
            {
                //Add details of error to a log file
                return -1;
            }
        }

        #endregion

        #region UpdateCompanyType
        /// <summary>
        /// Update the companytype details
        /// </summary>
        /// <param name="companytype"></param>
        /// <returns>int</returns>
        public int UpdateCompanyType(CompanyType companytype)
        {
            try
            {
                //Add companytype object to context
                companyRepository.UpdateCompanyType(companytype);

                //Save companytype
                companyRepository.Save();

                //returns 1 if successfull
                return 1;
            }
            catch
            {
                //Add details of error to a log file

                //returns -1 if error
                return -1;
            }
        }

        #endregion       

        #endregion

        #region Company Methods

        #region GetAllCompany
        /// <summary>
        /// Get all the Company details.
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public IEnumerable<PayrollModel.Company> GetAllCompany()
        {
            //return all.
            return companyRepository.GetCompanies();
        }

        #endregion

        #endregion

        #region CompanyBranch Methods

        #region GetAllCompanyBranch
        /// <summary>
        /// Get all the CompanyBranch details.
        /// </summary>
        /// <param name="companybranchId"></param>
        /// <returns></returns>
        public IEnumerable<PayrollModel.CompanyBranch> GetAllCompanyBranch()
        {
            //return all.
            return companyRepository.GetCompanyBranches();
        }

        #endregion

        #endregion

    }
}
