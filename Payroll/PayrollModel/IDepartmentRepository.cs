using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayrollModel
{
    public interface IDepartmentRepository:IDisposable
    {
        #region DepartmentType

        IEnumerable<DepartmentType> GetDepartmentTypes();

        DepartmentType GetDepartmentTypeById(int departmenttypeId);

        void InsertDepartmentType(DepartmentType departmenttype);

        void UpdateDepartmentType(DepartmentType departmenttype);

        void DeleteDepartmentType(int departmenttypeId);

        #endregion

        #region Department

        IEnumerable<Department> GetDepartments();

        Department GetDepartmentById(int departmentId);

        void InsertDepartment(Department department);

        void UpdateDepartment(Department department);

        void DeleteDepartment(int departmentId);

        #endregion

        void Save();
    }
}
