using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PayrollModel;

namespace Payroll_Manager
{
    public class Department
    {
        #region Declarations

        private IDepartmentRepository departmentRepository;

        #endregion

        #region Constructor

        public Department()
        {
            this.departmentRepository = new DepartmentRepository(new Payroll_Context());
        }

        #endregion

        #region DepartmentType Methods

        #region GetAllDepartmentTypes
        /// <summary>
        /// Get all the DepartmentType details.
        /// </summary>
        /// <param name="departmenttypeId"></param>
        /// <returns></returns>
        public IEnumerable<DepartmentType> GetAllDepartmentTypes()
        {
            //return all.
            return departmentRepository.GetDepartmentTypes();
        }

        #endregion

        #region GetDepartmentTypeById
        /// <summary>
        /// Get the DepartmentType details for the id passed
        /// </summary>
        /// <param name="departmenttypeId"></param>
        /// <returns></returns>
        public DepartmentType GetDepartmentTypeById(int departmenttypeId)
        {
            //return only rows that have the given id
            return departmentRepository.GetDepartmentTypeById(departmenttypeId);
        }

        #endregion

        #region AddDepartmentType
        /// <summary>
        /// Add the DepartmentType details; Returns 1 if successful and -1 if not
        /// </summary>
        /// <param name="departmenttype"></param>
        /// <returns>int</returns>
        public int AddDepartmentType(DepartmentType departmenttype)
        {
            try
            {
                //Add Departmenttype object to context
                departmentRepository.InsertDepartmentType(departmenttype);

                //Save departmenttype
                departmentRepository.Save();

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

        #region UpdateDepartmentType
        /// <summary>
        /// Update the departmenttype details; Returns 1 if successful and -1 if not
        /// </summary>
        /// <param name="departmenttype"></param>
        /// <returns>int</returns>
        public int UpdateDepartmentType(DepartmentType departmenttype)
        {
            try
            {
                //Add departmenttype object to context
                departmentRepository.UpdateDepartmentType(departmenttype);

                //Save departmenttype
                departmentRepository.Save();

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

        #region Department Methods

        #region GetAllDepartment
        /// <summary>
        /// Get all the Department details.
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public IEnumerable<PayrollModel.Department> GetAllDepartment()
        {
            //return all.
            return departmentRepository.GetDepartments();
        }

        #endregion

        #region GetDepartmentById
        /// <summary>
        /// Get the Department details for the id passed
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public PayrollModel.Department GetDepartmentById(int departmentId)
        {
            //return only rows that have the given id
            return departmentRepository.GetDepartmentById(departmentId);
        }

        #endregion

        #region AddDepartment
        /// <summary>
        /// Add the Department details; Returns 1 if successful and -1 if not
        /// </summary>
        /// <param name="department"></param>
        /// <returns>int</returns>
        public int AddDepartment(PayrollModel.Department department)
        {
            try
            {
                //Add department object to context
                departmentRepository.InsertDepartment(department);

                //Save Department
                departmentRepository.Save();

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

        #region UpdateDepartment
        /// <summary>
        /// Update the department details; Returns 1 if successful and -1 if not
        /// </summary>
        /// <param name="department"></param>
        /// <returns>int</returns>
        public int UpdateDepartment(PayrollModel.Department department)
        {
            try
            {
                //Add department object to context
                departmentRepository.UpdateDepartment(department);

                //Save Department
                departmentRepository.Save();

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
