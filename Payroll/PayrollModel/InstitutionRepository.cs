using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayrollModel
{
    public class InstitutionRepository:IInstitutionRepository,IDisposable
    {
        //Create an object of Payroll_Context
        private Payroll_Context payroll;

        #region Constructor

        public InstitutionRepository(Payroll_Context payroll)
        {
            //Pass the Payroll_Context object 
            this.payroll = payroll;
        }

        #endregion

        #region InstitutionType

        #region GetInstitutionTypes
        /// <summary>
        /// Get all the InstitutionTypes
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<InstitutionType> GetInstitutionTypes()
        {
            //Gets the InstitutionTypes
            return payroll.InstitutionTypes.ToList();
        }

        #endregion

        #region GetInstitutionTypeById
        /// <summary>
        /// Get the details of selected InstitutionType
        /// </summary>
        /// <param name="InstitutionTypeId"></param>
        /// <returns>InstitutionType</returns>
        public InstitutionType GetInstitutionTypeById(int institutiontypeId)
        {
            //Gets the institutiontype based on the Id passed
            return payroll.InstitutionTypes.Where(x => x.InstitutionTypeId == institutiontypeId).First();
        }
        #endregion

        #region InsertInstitutionType
        /// <summary>
        /// Insert a new institutiontype
        /// </summary>
        /// <param name="institutiontype"></param>
        public void InsertInstitutionType(InstitutionType institutiontype)
        {
            //Adds the institutiontype object to the context
            payroll.InstitutionTypes.AddObject(institutiontype);
        }
        #endregion

        #region UpdateInstitutionType
        /// <summary>
        /// Update an existing institutiontype
        /// </summary>
        /// <param name="institutiontype"></param>
        public void UpdateInstitutionType(InstitutionType institutiontype)
        {
            //Apply the institutiontype object changed values to the context
            payroll.InstitutionTypes.ApplyCurrentValues(institutiontype);
        }
        #endregion

        #region DeleteInstitutionType
        /// <summary>
        /// Delete a InstitutionType
        /// </summary>
        /// <param name="institutiontypeId"></param>
        public void DeleteInstitutionType(int institutiontypeId)
        {
            //To do later
        }
        #endregion

        #endregion

        #region Institution

        #region GetInstitutions
        /// <summary>
        /// Get all the Institution
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<Institution> GetInstitutions()
        {
            //Gets the Institutions
            return payroll.Institutions.ToList();
        }

        #endregion

        #region GetInstitutionById
        /// <summary>
        /// Get the details of selected institution
        /// </summary>
        /// <param name="InstitutionId"></param>
        /// <returns>Institution</returns>
        public Institution GetInstitutionById(int institutionId)
        {
            //Gets the institution based on the Id passed
            return payroll.Institutions.Where(x => x.InstitutionId == institutionId).First();
        }
        #endregion

        #region InsertInstitution
        /// <summary>
        /// Insert a new institution
        /// </summary>
        /// <param name="institution"></param>
        public void InsertInstitution(Institution institution)
        {
            //Adds the institution object to the context
            payroll.Institutions.AddObject(institution);
        }
        #endregion

        #region UpdateInstitution
        /// <summary>
        /// Update an existing institution
        /// </summary>
        /// <param name="institution"></param>
        public void UpdateInstitution(Institution institution)
        {
            //Apply the institution object changed values to the context
            payroll.Institutions.ApplyCurrentValues(institution);
        }
        #endregion

        #region DeleteInstitution
        /// <summary>
        /// Delete a Institution
        /// </summary>
        /// <param name="institutionId"></param>
        public void DeleteInstitution(int institutionId)
        {
            //To do later
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

        #region dispose

        private bool disposed = false;

        /// <summary>
        /// Disposes the Payroll context(if not already done by GC
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
