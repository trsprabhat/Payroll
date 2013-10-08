using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using PayrollModel;

namespace Payroll_Manager
{
    public class Employee
    {

        #region Declarations

            private IEmployeeRepository employeeRepository;

        #endregion
        
        #region Constructor

        public Employee()
        {
            this.employeeRepository = new EmployeeRepository(new Payroll_Context());
        }

        #endregion

        #region Religion Methods

        #region GetAllReligions
        /// <summary>
        /// Get all the religion details.
        /// </summary>
        /// <param name="religionId"></param>
        /// <returns></returns>
        public IEnumerable<Religion> GetAllReligions()
        {            
            //return all.
            return employeeRepository.GetReligions();           
        }

        #endregion

        #region GetReligion
        /// <summary>
        /// Get the religion details for the id passed
        /// </summary>
        /// <param name="religionId"></param>
        /// <returns></returns>
        public Religion GetReligion(int religionId)
        {
            //return only rows that have the given id
            return employeeRepository.GetReligionByID(religionId);          
        }

        #endregion

        #region AddReligion
        /// <summary>
        /// Add the religion details; Returns 1 if successful and -1 if not
        /// </summary>
        /// <param name="religion"></param>
        /// <returns>int</returns>
        public int AddReligion(Religion religion)
        {
            try
            {
                //Add religion object to context
                employeeRepository.InsertReligion(religion);

                //Save religion
                employeeRepository.Save();

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

        #region UpdateReligion
        /// <summary>
        /// Update the religion details; Returns 1 if successful and -1 if not
        /// </summary>
        /// <param name="religion"></param>
        /// <returns>int</returns>
        public int UpdateReligion(Religion religion)
        {
            try
            {
                //Add religion object to context
                employeeRepository.UpdateReligion(religion);

                //Save religion
                employeeRepository.Save();

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

        #region Caste Methods

        #region GetAllCastes
        /// <summary>
        /// Get all the Caste details.
        /// </summary>
        /// <param name="CasteId"></param>
        /// <returns></returns>
        public IEnumerable<Caste> GetAllCastes()
        {
            //return all.
            return employeeRepository.GetCastes();
        }

        #endregion

        #region GetCaste
        /// <summary>
        /// Get the Caste details for the id passed
        /// </summary>
        /// <param name="CasteId"></param>
        /// <returns></returns>
        public Caste GetCaste(int casteId)
        {
            //return only rows that have the given id
            return employeeRepository.GetCasteByID(casteId);
        }

        #endregion

        #region AddCaste
        /// <summary>
        /// Add the caste details; Returns 1 if successful and -1 if not
        /// </summary>
        /// <param name="caste"></param>
        /// <returns>int</returns>
        public int AddCaste(Caste caste)
        {
            try
            {
                //Add caste object to context
                employeeRepository.InsertCaste(caste);

                //Save caste
                employeeRepository.Save();

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

        #region UpdateCaste
        /// <summary>
        /// Update the caste details; Returns 1 if successful and -1 if not
        /// </summary>
        /// <param name="caste"></param>
        /// <returns>int</returns>
        public int UpdateCaste(Caste caste)
        {
            try
            {
                //Add caste object to context
                employeeRepository.UpdateCaste(caste);

                //Save caste
                employeeRepository.Save();

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

    #region EmployeeType Methods

        #region GetAllEmployeeTypes
        /// <summary>
        /// Get all the EmployeeType details.
        /// </summary>
        /// <param name="employeetypeId"></param>
        /// <returns></returns>
        public IEnumerable<EmployeeType> GetAllEmployeeTypes()
        {
            //return all.
            return employeeRepository.GetEmployeeTypes();
        }

        #endregion

        #region GetEmployeeTypeById
        /// <summary>
        /// Get the EmployeeType details for the id passed
        /// </summary>
        /// <param name="employeetypeId"></param>
        /// <returns></returns>
        public EmployeeType GetEmployeeTypeById(int employeetypeId)
        {
            //return only rows that have the given id
            return employeeRepository.GetEmployeeTypeById(employeetypeId);
        }

        #endregion

        #region AddEmployeeType
        /// <summary>
        /// Add the EmployeeType details; Returns 1 if successful and -1 if not
        /// </summary>
        /// <param name="employeetype"></param>
        /// <returns>int</returns>
        public int AddEmployeeType(EmployeeType employeetype)
        {
            try
            {
                //Add employeetype object to context
                employeeRepository.InsertEmployeeType(employeetype);

                //Save employeetype
                employeeRepository.Save();

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

        #region UpdateEmployeeType
        /// <summary>
        /// Update the employeetype details; Returns 1 if successful and -1 if not
        /// </summary>
        /// <param name="employeetype"></param>
        /// <returns>int</returns>
        public int UpdateEmployeeType(EmployeeType employeetype)
        {
            try
            {
                //Add employeetype object to context
                employeeRepository.UpdateEmployeeType(employeetype);

                //Save employeetype
                employeeRepository.Save();

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
