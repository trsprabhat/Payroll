using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PayrollModel
{
    /// <summary>
    /// This class provides the methods for operations on Employee and related objects
    /// </summary>
    public class EmployeeRepository:IEmployeeRepository,IDisposable
    {
        //Create an object of Payroll_Context
        private Payroll_Context payroll;

        #region Constructor

        public EmployeeRepository(Payroll_Context payroll)
        {
            //Pass the Payroll_Context object 
            this.payroll = payroll;
        }

        #endregion

        #region Religion

        #region GetReligions
        /// <summary>
        /// Get all the Religions
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<Religion> GetReligions()
        {
            //Gets the religions
            return payroll.Religions.ToList().OrderBy(x=>x.ReligionName);
        }

        #endregion

        #region GetReligionByID
        /// <summary>
        /// Get the details of selected religion
        /// </summary>
        /// <param name="religionId"></param>
        /// <returns>Religion</returns>
        public Religion GetReligionByID(int religionId)
        {
            //Gets the religion based on the Id passed
            return payroll.Religions.Where(x => x.ReligionId == religionId).First();
        }
        #endregion

        #region InsertReligion
        /// <summary>
        /// Insert a new religion
        /// </summary>
        /// <param name="religion"></param>
        public void InsertReligion(Religion religion)
        {            
            //Adds the religion object to the context
            payroll.Religions.AddObject(religion);
        }
        #endregion

        #region UpdateReligion
        /// <summary>
        /// Update an existing relgion
        /// </summary>
        /// <param name="religion"></param>
        public void UpdateReligion(Religion religion)
        {
            //Apply the religion object changed values to the context
            payroll.Religions.ApplyCurrentValues(religion);
        }
        #endregion

        #region DeleteReligion
        /// <summary>
        /// Delete a religion
        /// </summary>
        /// <param name="religionId"></param>
        public void DeleteReligion(int religionId)
        {
            //To do later
        }
        #endregion

     #endregion

        #region Caste

        #region GetCastes
        /// <summary>
        /// Get all the Castes
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<Caste> GetCastes()
        {
            //Gets the religions
            return payroll.Castes.ToList().OrderBy(x=>x.ReligionId).ThenBy(x=>x.CasteName);
        }

        #endregion

        #region GetCasteByID
        /// <summary>
        /// Get the details of selected Caste
        /// </summary>
        /// <param name="religionId"></param>
        /// <returns>Caste</returns>
        public Caste GetCasteByID(int casteId)
        {
            //Gets the Caste based on the Id passed
            return payroll.Castes.Where(x => x.CasteId == casteId).First();
        }
        #endregion

        #region GetCasteByReligionID
        /// <summary>
        /// Get the details of selected Caste
        /// </summary>
        /// <param name="religionId"></param>
        /// <returns>Caste</returns>
        public Caste GetCasteByReligionID(int religionId)
        {
            //Gets the Caste based on the Id passed
            return payroll.Castes.Where(x => x.ReligionId == religionId).First();
        }
        #endregion

        #region InsertCaste
        /// <summary>
        /// Insert a new caste
        /// </summary>
        /// <param name="religion"></param>
        public void InsertCaste(Caste caste)
        {
            //Adds the caste object to the context
            payroll.Castes.AddObject(caste);
        }
        #endregion

        #region UpdateCaste
        /// <summary>
        /// Update an existing caste
        /// </summary>
        /// <param name="religion"></param>
        public void UpdateCaste(Caste caste)
        {
            //Apply the caste object changed values to the context
            payroll.Castes.ApplyCurrentValues(caste);
        }
        #endregion

        #region DeleteCaste
        /// <summary>
        /// Delete a caste
        /// </summary>
        /// <param name="CasteId"></param>
        public void DeleteCaste(int casteId)
        {
            //To do later
        }
        #endregion

      #endregion

        #region EmployeeType

        #region GetEmployeeTypes
        /// <summary>
        /// Get all the EmployeeTypes
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<EmployeeType> GetEmployeeTypes()
        {
            //Gets the EmployeeTypes
            return payroll.EmployeeTypes.ToList();
        }

        #endregion

        #region GetEmployeeTypeById
        /// <summary>
        /// Get the details of selected EmployeeType
        /// </summary>
        /// <param name="EmployeeTypeId"></param>
        /// <returns>EmployeeType</returns>
        public EmployeeType GetEmployeeTypeById(int employeetypeId)
        {
            //Gets the employeetype based on the Id passed
            return payroll.EmployeeTypes.Where(x => x.EmployeeTypeId == employeetypeId).First();
        }
        #endregion

        #region InsertEmployeeType
        /// <summary>
        /// Insert a new employeetype
        /// </summary>
        /// <param name="employeetype"></param>
        public void InsertEmployeeType(EmployeeType employeetype)
        {
            //Adds the employeetype object to the context
            payroll.EmployeeTypes.AddObject(employeetype);
        }
        #endregion

        #region UpdateEmployeeType
        /// <summary>
        /// Update an existing employeetype
        /// </summary>
        /// <param name="employeetype"></param>
        public void UpdateEmployeeType(EmployeeType employeetype)
        {
            //Apply the employeetype object changed values to the context
            payroll.EmployeeTypes.ApplyCurrentValues(employeetype);
        }
        #endregion

        #region DeleteEmployeeType
        /// <summary>
        /// Delete a EmployeeType
        /// </summary>
        /// <param name="employeetypeId"></param>
        public void DeleteEmployeeType(int employeetypeId)
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
