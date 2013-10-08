using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Institution
{
    public partial class InstitutionType : System.Web.UI.Page
    {

        #region LocalVariables

        private static int intInstitutionTypeId = 0;    //when user clicks on edit the id of the selected row is copied to this variable

        #endregion

        #region Page_Load
        /// <summary>
        /// load the page with the things in this event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            //This variable is used in jquery code. More details in common-1.js file
            hvSavedStatus.Text = "1";

            //This label(actually a textbox) shows the errors
            lblErrorMsg.Text = "";
            lblErrorMsg.Enabled = false;

            if (!IsPostBack)
            {
                FillGrid();
                SubmitStatus(true);
            }
        }

        #endregion

        #region FillGrid

        /// <summary>
        /// This method fills the grid by getting the values from Payroll Manager class
        /// </summary>
        private void FillGrid()
        {
            Payroll_Manager.Institution institution = new Payroll_Manager.Institution();

            //Select all Institution Type            
            gvMain.DataSource = institution.GetAllInstitutionTypes();
            gvMain.DataBind();

            //If no data is selected shows appropriate message
            if (gvMain.Rows.Count == 0)
            {
                lblErrorMsg.Text = "No Institution Type Added yet.";
                lblErrorMsg.ForeColor = System.Drawing.Color.Blue;
            }
        }

        #endregion

        #region ButtonSave_Click
        /// <summary>
        /// This method saves the Institution Type details and returns save status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (SaveInstitutionType() != -1)     //means it is saved            
            {
                lblErrorMsg.ForeColor = System.Drawing.Color.Green;
                lblErrorMsg.Text = "Institution Type Saved Successfully";
                hvSavedStatus.Text = "1"; //this means that data is saved. So the form can be hidden(jquery can hide form and show grid with new data. Also, the text boxes should be cleared.
                FillGrid(); //This fills the Grid
            }
            else
            {
                hvSavedStatus.Text = "2";  //this means that data is not saved. So the form should be still shown with error. Text boxes should have their values as it is.
            }
        }

        #endregion

        #region SaveInstitutionType

        /// <summary>
        /// This method saves the InstitutionType details
        /// </summary>
        private int SaveInstitutionType()
        {
            try
            {
                PayrollModel.InstitutionType institutiontype = new PayrollModel.InstitutionType();

                //Fills the properties of institutiontype object with values in the inputs.
                AddValues(institutiontype);

                return new Payroll_Manager.Institution().AddInstitutionType(institutiontype);  //Successfully saved. so, 1 is returned
            }
            catch (Exception ex)
            {
                //if an exception occurs, the error is displayed in the label in red color.
                lblErrorMsg.ForeColor = System.Drawing.Color.Red;
                if (ex.InnerException == null)
                {
                    lblErrorMsg.Text = "Error - " + ex.Message;
                }
                else
                {
                    lblErrorMsg.Text = "Error - " + ex.InnerException;
                }

                return -1;  //Error, so 2 is returned
            }
        }

        #endregion

        #region AddValuesToModel
        /// <summary>
        /// Add Values to the Model
        /// </summary>
        /// <param name="religion"></param>
        private void AddValues(PayrollModel.InstitutionType institutiontype)
        {
            //Fills the properties of institutiontype object with values in the inputs.
            institutiontype.InstitutionTypeName = txtInstitutionTypeName.Text;
        }

        #endregion

        #region gvMain_SelectedIndexChanged
        /// <summary>
        /// When user clicks on edit button to edit a row, this event is called which copies the id of row and fills the text boxes with respective values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // This method sets the values of the input controls.
            AddValues();

            //setting the hidden variable text to 0. This is to ensure that the form with current values are shown, and grid is hidden etc(see jquery)
            hvSavedStatus.Text = "0";

            SubmitStatus(false); //update is set for enter button
        }

        #endregion

        #region AddValuesToInputControls
        /// <summary>
        /// Add values to the input controls of the form
        /// </summary>
        private void AddValues()
        {
            //Get the id of the selected row and store it to local vairable
            intInstitutionTypeId = Convert.ToInt32(gvMain.Rows[gvMain.SelectedIndex].Cells[0].Text.Trim());

            //Creating an object of Institution Class
            Payroll_Manager.Institution institution = new Payroll_Manager.Institution();

            //Setting the data source with the list of institutiontype
            PayrollModel.InstitutionType institutiontype = institution.GetInstitutionTypeById(intInstitutionTypeId);

            //fill the text boxes with the values in the object
            txtInstitutionTypeName.Text = institutiontype.InstitutionTypeName;

        }
        #endregion

        #region SubmitStatus
        /// <summary>
        /// for change the Enterkey function of each button
        /// </summary>
        /// <param name="Status"></param>
        private void SubmitStatus(bool Status)
        {
            if (Status)
            {
                //for save enable
                ButtonSave.UseSubmitBehavior = true;
                ButtonUpdate.UseSubmitBehavior = false;
            }
            else
            {
                //for update enable
                ButtonSave.UseSubmitBehavior = false;
                ButtonUpdate.UseSubmitBehavior = true;
            }
        }
        #endregion

        #region ButtonCancel_Click
        /// <summary>
        /// When user click Cancel button It change the Submit behavior of savebutton and updatebutton 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            SubmitStatus(false); //update is set for enter button
        }

        #endregion

        #region ButtonUpdate_Click
        /// <summary>
        /// This method modifies the InstitutionType details and returns save status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {


            if (UpdateInstitutionType() != -1)     //means it is updated            
            {
                lblErrorMsg.ForeColor = System.Drawing.Color.Green;
                lblErrorMsg.Text = "InstitutionType Updated Successfully";
                hvSavedStatus.Text = "1"; //this means that data is updated. So the form can be hidden(jquery can hide form and show grid with new data. Also, the text boxes should be cleared.
                FillGrid();  //This fills the Grid
                SubmitStatus(true); //save is set for enter button
            }
            else
            {
                hvSavedStatus.Text = "0";  //this means that data is not updated. So the form should be still shown with error. Text boxes should have their values as it is.
                SubmitStatus(false); //update is set for enter button
            }


        }

        #endregion

        #region UpdateInstitutionType

        /// <summary>
        /// This method updates the InstitutionType details
        /// </summary>
        private int UpdateInstitutionType()
        {
            try
            {

                //Creating an object of Institution Class
                Payroll_Manager.Institution institution = new Payroll_Manager.Institution();

                //Setting the data source with the list of institutiontype
                PayrollModel.InstitutionType institutiontype = institution.GetInstitutionTypeById(intInstitutionTypeId);


                institutiontype.InstitutionTypeName = txtInstitutionTypeName.Text;

                
                return institution.UpdateInstitutionType(institutiontype);

            }
            catch (Exception ex)
            {
                //if an exception occurs, the error is displayed in the label in red color.
                lblErrorMsg.ForeColor = System.Drawing.Color.Red;
                if (ex.InnerException == null)
                {
                    lblErrorMsg.Text = "Error - " + ex.Message;
                }
                else
                {
                    lblErrorMsg.Text = "Error - " + ex.InnerException;
                }

                return 2;  //Error, so 2 is returned
            }
        }

        #endregion


    }
}