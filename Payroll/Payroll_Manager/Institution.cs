using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PayrollModel;

namespace Payroll_Manager
{
    public class Institution
    {
        #region Declarations

        private IInstitutionRepository institutionRepository;

        #endregion

        #region Constructor

        public Institution()
        {
            this.institutionRepository = new InstitutionRepository(new Payroll_Context());
        }

        #endregion

        #region InstitutionType Methods

        #region GetAllInstitutionTypes
        /// <summary>
        /// Get all the InstitutionType details.
        /// </summary>
        /// <param name="institutiontypeId"></param>
        /// <returns></returns>
        public IEnumerable<InstitutionType> GetAllInstitutionTypes()
        {
            //return all.
            return institutionRepository.GetInstitutionTypes();
        }

        #endregion

        #region GetInstitutionTypeById
        /// <summary>
        /// Get the InstitutionType details for the id passed
        /// </summary>
        /// <param name="institutiontypeId"></param>
        /// <returns></returns>
        public InstitutionType GetInstitutionTypeById(int institutiontypeId)
        {
            //return only rows that have the given id
            return institutionRepository.GetInstitutionTypeById(institutiontypeId);
        }

        #endregion

        #region AddInstitutionType
        /// <summary>
        /// Add the InstitutionType details; Returns 1 if successful and -1 if not
        /// </summary>
        /// <param name="institutiontype"></param>
        /// <returns>int</returns>
        public int AddInstitutionType(InstitutionType institutiontype)
        {
            try
            {
                //Add institutiontype object to context
                institutionRepository.InsertInstitutionType(institutiontype);

                //Save institutiontype
                institutionRepository.Save();
                
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

        #region UpdateInstitutionType
        /// <summary>
        /// Update the institutiontype details; Returns 1 if successful and -1 if not
        /// </summary>
        /// <param name="institutiontype"></param>
        /// <returns>int</returns>
        public int UpdateInstitutionType(InstitutionType institutiontype)
        {
            try
            {
                //Add institutiontype object to context
                institutionRepository.UpdateInstitutionType(institutiontype);

                //Save institutiontype
                institutionRepository.Save();

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

        #region Institution Methods

        #region GetAllInstitution
        /// <summary>
        /// Get all the Institution details.
        /// </summary>
        /// <param name="institutionId"></param>
        /// <returns></returns>
        public IEnumerable<PayrollModel.Institution> GetAllInstitution()
        {
            //return all.
            return institutionRepository.GetInstitutions();
        }

        #endregion

        #region GetInstitutionById
        /// <summary>
        /// Get the Institution details for the id passed
        /// </summary>
        /// <param name="institutionId"></param>
        /// <returns></returns>
        public PayrollModel.Institution GetInstitutionById(int institutionId)
        {
            //return only rows that have the given id
            return institutionRepository.GetInstitutionById(institutionId);
        }

        #endregion

        #region AddInstitution
        /// <summary>
        /// Add the Institution details; Returns 1 if successful and -1 if not
        /// </summary>
        /// <param name="institution"></param>
        /// <returns>int</returns>
        public int AddInstitution(PayrollModel.Institution institution)
        {
            try
            {
                //Add Institution object to context
                institutionRepository.InsertInstitution(institution);

                //Save Institution
                institutionRepository.Save();

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

        #region UpdateInstitution
        /// <summary>
        /// Update the institution details; Returns 1 if successful and -1 if not
        /// </summary>
        /// <param name="institution"></param>
        /// <returns>int</returns>
        public int UpdateInstitution(PayrollModel.Institution institution)
        {
            try
            {
                //Add institution object to context
                institutionRepository.UpdateInstitution(institution);

                //Save institution
                institutionRepository.Save();

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

    }
}
