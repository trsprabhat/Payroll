using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayrollModel
{
    public interface IDesignationRepository : IDisposable
    {
        #region DesignationType

        IEnumerable<DesignationType> GetDesignationTypes();

        DesignationType GetDesignationTypeById(int designationtypeId);

        void InsertDesignationType(DesignationType designationtype);

        void UpdateDesignationType(DesignationType designationtype);

        void DeleteDesignationType(int designationtypeId);

        #endregion

        #region Designation

        IEnumerable<Designation> GetDesignations();

        Designation GetDesignationById(int designationId);

        void InsertDesignation(Designation designation);

        void UpdateDesignation(Designation designation);

        void DeleteDesignation(int designationId);

        #endregion

        #region Grade

        IEnumerable<Grade> GetGrades();

        Grade GetGradeById(int gradeId);

        void InsertGrade(Grade grade);

        void UpdateGrade(Grade grade);

        void DeleteGrade(int gradeId);

        #endregion

        void Save();
    }
}
