using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PayrollModel;

namespace Payroll_Manager
{
    public class Designation
    {
         #region Declarations

        private IDesignationRepository designationRepository;

        #endregion

        #region Constructor

        public Designation()
        {
            this.designationRepository = new DesignationRepository(new Payroll_Context());
        }

        #endregion

        #region DesignationType Methods

        #region GetAllDesignationTypes
        /// <summary>
        /// Get all the DesignationType details.
        /// </summary>
        /// <param name="designationtypeId"></param>
        /// <returns></returns>
        public IEnumerable<DesignationType> GetAllDesignationTypes()
        {
            //return all.
            return designationRepository.GetDesignationTypes();
        }

        #endregion

        #region GetDesignationTypeById
        /// <summary>
        /// Get the DesignationType details for the id passed
        /// </summary>
        /// <param name="designationtypeId"></param>
        /// <returns></returns>
        public DesignationType GetDesignationTypeById(int designationtypeId)
        {
            //return only rows that have the given id
            return designationRepository.GetDesignationTypeById(designationtypeId);
        }

        #endregion

        #region AddDesignationType
        /// <summary>
        /// Add the DesignationType details; Returns 1 if successful and -1 if not
        /// </summary>
        /// <param name="designationtype"></param>
        /// <returns>int</returns>
        public int AddDesignationType(DesignationType designationtype)
        {
            try
            {
                //Add designationtype object to context
                designationRepository.InsertDesignationType(designationtype);

                //Save designationtype
                designationRepository.Save();

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

        #region UpdateDesignationType
        /// <summary>
        /// Update the designationtype details; Returns 1 if successful and -1 if not
        /// </summary>
        /// <param name="designationtype"></param>
        /// <returns>int</returns>
        public int UpdateDesignationType(DesignationType designationtype)
        {
            try
            {
                //Add designationtype object to context
                designationRepository.UpdateDesignationType(designationtype);

                //Save designationtype
                designationRepository.Save();

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

        #region Designation Methods

        #region GetAllDesignation
        /// <summary>
        /// Get all the Designation details.
        /// </summary>
        /// <param name="designationId"></param>
        /// <returns></returns>
        public IEnumerable<PayrollModel.Designation> GetAllDesignation()
        {
            //return all.
            return designationRepository.GetDesignations();
        }

        #endregion

        #region GetDesignationById
        /// <summary>
        /// Get the Designation details for the id passed
        /// </summary>
        /// <param name="designationId"></param>
        /// <returns></returns>
        public PayrollModel.Designation GetDesignationById(int designationId)
        {
            //return only rows that have the given id
            return designationRepository.GetDesignationById(designationId);
        }

        #endregion

        #region AddDesignation
        /// <summary>
        /// Add the Designation details; Returns 1 if successful and -1 if not
        /// </summary>
        /// <param name="designation"></param>
        /// <returns>int</returns>
        public int AddDesignation(PayrollModel.Designation designation)
        {
            try
            {
                //Add Designation object to context
                designationRepository.InsertDesignation(designation);

                //Save Designation
                designationRepository.Save();

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

        #region UpdateDesignation
        /// <summary>
        /// Update the designation details; Returns 1 if successful and -1 if not
        /// </summary>
        /// <param name="designation"></param>
        /// <returns>int</returns>
        public int UpdateDesignation(PayrollModel.Designation designation)
        {
            try
            {
                //Add designation object to context
                designationRepository.UpdateDesignation(designation);

                //Save Designation
                designationRepository.Save();

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

       #region Grade Methods

        #region GetAllGradeTypes
        /// <summary>
        /// Get all the Grade details.
        /// </summary>
        /// <param name="gradeId"></param>
        /// <returns></returns>
        public IEnumerable<Grade> GetAllGrades()
        {
            //return all.
            return designationRepository.GetGrades();
        }

        #endregion

        #region GetGradeById
        /// <summary>
        /// Get the Grade details for the id passed
        /// </summary>
        /// <param name="gradeId"></param>
        /// <returns></returns>
        public Grade GetGradeById(int gradeId)
        {
            //return only rows that have the given id
            return designationRepository.GetGradeById(gradeId);
        }

        #endregion

        #region AddGrade
        /// <summary>
        /// Add the Grade details; Returns 1 if successful and -1 if not
        /// </summary>
        /// <param name="grade"></param>
        /// <returns>int</returns>
        public int AddGrade(Grade grade)
        {
            try
            {
                //Add grade object to context
                designationRepository.InsertGrade(grade);

                //Save designationtype
                designationRepository.Save();

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

        #region UpdateGrade
        /// <summary>
        /// Update the grade details; Returns 1 if successful and -1 if not
        /// </summary>
        /// <param name="grade"></param>
        /// <returns>int</returns>
        public int UpdateGrade(Grade grade)
        {
            try
            {
                //Add grade object to context
                designationRepository.UpdateGrade(grade);

                //Save grade
                designationRepository.Save();

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
