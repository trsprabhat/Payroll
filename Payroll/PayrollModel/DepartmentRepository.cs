using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayrollModel
{
    public class DepartmentRepository : IDepartmentRepository, IDisposable
    {
         //Create an object of Payroll_Context
        private Payroll_Context payroll;

        #region Constructor

        public DepartmentRepository(Payroll_Context payroll)
        {
            //Pass the Payroll_Context object 
            this.payroll = payroll;
        }

        #endregion

        #region DepartmentType

        #region GetDepartmentTypes
        /// <summary>
        /// Get all the DepartmentTypes
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<DepartmentType> GetDepartmentTypes()
        {
            //Gets the DepartmentTypes
            return payroll.DepartmentTypes.ToList();
        }

        #endregion

        #region GetDepartmentTypeById
        /// <summary>
        /// Get the details of selected DepartmentType
        /// </summary>
        /// <param name="DepartmentTypeId"></param>
        /// <returns>DepartmentType</returns>
        public DepartmentType GetDepartmentTypeById(int departmenttypeId)
        {
            //Gets the departmenttype based on the Id passed
            return payroll.DepartmentTypes.Where(x => x.DepartmentTypeId == departmenttypeId).First();
        }
        #endregion

        #region InsertDepartmentType
        /// <summary>
        /// Insert a new departmenttype
        /// </summary>
        /// <param name="departmenttype"></param>
        public void InsertDepartmentType(DepartmentType departmenttype)
        {
            //Adds the departmenttype object to the context
            payroll.DepartmentTypes.AddObject(departmenttype);
        }
        #endregion

        #region UpdateDepartmentType
        /// <summary>
        /// Update an existing departmenttype
        /// </summary>
        /// <param name="departmenttype"></param>
        public void UpdateDepartmentType(DepartmentType departmenttype)
        {
            //Apply the departmenttype object changed values to the context
            payroll.DepartmentTypes.ApplyCurrentValues(departmenttype);
        }
        #endregion

        #region DeleteDepartmentType
        /// <summary>
        /// Delete a DepartmentType
        /// </summary>
        /// <param name="departmenttypeId"></param>
        public void DeleteDepartmentType(int departmenttypeId)
        {
            //To do later
        }
        #endregion

        #endregion

        #region Department

        #region GetDepartments
        /// <summary>
        /// Get all the Department
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<Department> GetDepartments()
        {
            //Gets the Department
            return payroll.Departments.ToList();
        }

        #endregion

        #region GetDepartmentById
        /// <summary>
        /// Get the details of selected Department
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns>Department</returns>
        public Department GetDepartmentById(int departmentId)
        {
            //Gets the department based on the Id passed
            return payroll.Departments.Where(x => x.DepartmentId == departmentId).First();
        }
        #endregion

        #region InsertDepartment
        /// <summary>
        /// Insert a new department
        /// </summary>
        /// <param name="department"></param>
        public void InsertDepartment(Department department)
        {
            //Adds the department object to the context
            payroll.Departments.AddObject(department);
        }
        #endregion

        #region UpdateDepartment
        /// <summary>
        /// Update an existing Department
        /// </summary>
        /// <param name="department"></param>
        public void UpdateDepartment(Department department)
        {
            //Apply the Department object changed values to the context
            payroll.Departments.ApplyCurrentValues(department);
        }
        #endregion

        #region DeleteDepartment
        /// <summary>
        /// Delete a Department
        /// </summary>
        /// <param name="departmentId"></param>
        public void DeleteDepartment(int departmentId)
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
