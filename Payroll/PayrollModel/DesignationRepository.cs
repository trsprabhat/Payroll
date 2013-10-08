using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayrollModel
{
    public class DesignationRepository:IDesignationRepository,IDisposable
    {
        //Create an object of Payroll_Context
        private Payroll_Context payroll;

        #region Constructor

        public DesignationRepository(Payroll_Context payroll)
        {
            //Pass the Payroll_Context object 
            this.payroll = payroll;
        }

        #endregion

        #region DesignationType

        #region GetDesignationTypes
        /// <summary>
        /// Get all the DesignationTypes
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<DesignationType> GetDesignationTypes()
        {
            //Gets the DesignationTypes
            return payroll.DesignationTypes.ToList();
        }

        #endregion

        #region GetDesignationTypeById
        /// <summary>
        /// Get the details of selected DesignationType
        /// </summary>
        /// <param name="DesignationTypeId"></param>
        /// <returns>DesignationType</returns>
        public DesignationType GetDesignationTypeById(int designationtypeId)
        {
            //Gets the designationtype based on the Id passed
            return payroll.DesignationTypes.Where(x => x.DesignationTypeId == designationtypeId).First();
        }
        #endregion

        #region InsertDesignationType
        /// <summary>
        /// Insert a new designationtype
        /// </summary>
        /// <param name="designationtype"></param>
        public void InsertDesignationType(DesignationType designationtype)
        {
            //Adds the designationtype object to the context
            payroll.DesignationTypes.AddObject(designationtype);
        }
        #endregion

        #region UpdateDesignationType
        /// <summary>
        /// Update an existing designationtype
        /// </summary>
        /// <param name="designationtype"></param>
        public void UpdateDesignationType(DesignationType designationtype)
        {
            //Apply the designationtype object changed values to the context
            payroll.DesignationTypes.ApplyCurrentValues(designationtype);
        }
        #endregion

        #region DeleteDesignationType
        /// <summary>
        /// Delete a DesignationType
        /// </summary>
        /// <param name="designationtypeId"></param>
        public void DeleteDesignationType(int designationtypeId)
        {
            //To do later
        }
        #endregion

        #endregion

        #region Designation

        #region GetDesignations
        /// <summary>
        /// Get all the Designation
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<Designation> GetDesignations()
        {
            //Gets the Designation
            return payroll.Designations.ToList();
        }

        #endregion

        #region GetDesignationById
        /// <summary>
        /// Get the details of selected designation
        /// </summary>
        /// <param name="designationId"></param>
        /// <returns>Designation</returns>
        public Designation GetDesignationById(int designationId)
        {
            //Gets the designation based on the Id passed
            return payroll.Designations.Where(x => x.DesignationId == designationId).First();
        }
        #endregion

        #region InsertDesignation
        /// <summary>
        /// Insert a new designation
        /// </summary>
        /// <param name="designation"></param>
        public void InsertDesignation(Designation designation)
        {
            //Adds the designation object to the context
            payroll.Designations.AddObject(designation);
        }
        #endregion

        #region UpdateDesignation
        /// <summary>
        /// Update an existing Designation
        /// </summary>
        /// <param name="designation"></param>
        public void UpdateDesignation(Designation designation)
        {
            //Apply the designation object changed values to the context
            payroll.Designations.ApplyCurrentValues(designation);
        }
        #endregion

        #region DeleteDesignation
        /// <summary>
        /// Delete a Designation
        /// </summary>
        /// <param name="designationId"></param>
        public void DeleteDesignation(int designationId)
        {
            //To do later
        }
        #endregion

        #endregion

        #region Grade

        #region GetGrades
        /// <summary>
        /// Get all the Grades
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<Grade> GetGrades()
        {
            //Gets the Grades
            return payroll.Grades.ToList();
        }

        #endregion

        #region GetGradeById
        /// <summary>
        /// Get the details of selected Grade
        /// </summary>
        /// <param name="GradeId"></param>
        /// <returns>Grade</returns>
        public Grade GetGradeById(int gradeId)
        {
            //Gets the grade based on the Id passed
            return payroll.Grades.Where(x => x.GradeId == gradeId).First();
        }
        #endregion

        #region InsertGrade
        /// <summary>
        /// Insert a new Grade
        /// </summary>
        /// <param name="grade"></param>
        public void InsertGrade(Grade grade)
        {
            //Adds the grade object to the context
            payroll.Grades.AddObject(grade);
        }
        #endregion

        #region UpdateGrade
        /// <summary>
        /// Update an existing Grade
        /// </summary>
        /// <param name="grade"></param>
        public void UpdateGrade(Grade grade)
        {
            //Apply the grade object changed values to the context
            payroll.Grades.ApplyCurrentValues(grade);
        }
        #endregion

        #region DeleteGrade
        /// <summary>
        /// Delete a Grade
        /// </summary>
        /// <param name="gradeId"></param>
        public void DeleteGrade(int gradeId)
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
