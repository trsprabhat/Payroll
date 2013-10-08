﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Company
{
    public partial class Designation : System.Web.UI.Page
    {
        #region LocalVariables

        private static int intDesignationId = 0;    //when user clicks on edit the id of the selected row is copied to this variable

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
                SubmitStatus(true); //save is set for enter button
                FillGrid();
                FillDesignationType();
            }
        }

        #endregion

        #region FillGrid

        /// <summary>
        /// This method fills the grid by getting the values from Payroll Manager class
        /// </summary>
        private void FillGrid()
        {
            Payroll_Manager.Designation designation = new Payroll_Manager.Designation();

            //Select all Castes            
            gvMain.DataSource = designation.GetAllDesignation();
            gvMain.DataBind();

            //If no data is selected shows appropriate message
            if (gvMain.Rows.Count == 0)
            {
                lblErrorMsg.Text = "No Designation Added yet.";
                lblErrorMsg.ForeColor = System.Drawing.Color.Blue;
            }
        }

        #endregion

        #region FillDesignationType
        /// <summary>
        /// Fills the DesignationType details in the dropdown
        /// </summary>
        private void FillDesignationType()
        {
            //Creating an object of Designation Class
            Payroll_Manager.Designation designation = new Payroll_Manager.Designation();

            //Setting the data source with the list of DesignationType
            ddlDesignationType.DataSource = designation.GetAllDesignationTypes();

            //Setting the text of drop down items that can be viewed by user
            ddlDesignationType.DataTextField = "DesignationTypeName";

            //Setting the value of drop down items
            ddlDesignationType.DataValueField = "DesignationTypeId";

            //Binding the data source to the drop down
            ddlDesignationType.DataBind();

            //Making the '--Select--' as the first item of dropdown
            ddlDesignationType.Items.Insert(0, new ListItem("--Select--", "0"));

            //This may not be needed here. To be decided later.
            if (ddlDesignationType.Items.Count <= 1)
            {
                lblErrorMsg.Text = "Please add a DesignationType First";
                lblErrorMsg.ForeColor = System.Drawing.Color.Blue;
            }
        }

        #endregion

        #region ButtonSave_Click
        /// <summary>
        /// This method saves the Designation details and returns save status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSave_Click(object sender, EventArgs e)
        {

            if (SaveDesignation() != -1)     //means it is saved            
            {
                lblErrorMsg.ForeColor = System.Drawing.Color.Green;
                lblErrorMsg.Text = "Designation Saved Successfully";
                hvSavedStatus.Text = "1"; //this means that data is saved. So the form can be hidden(jquery can hide form and show grid with new data. Also, the text boxes should be cleared.
                FillGrid(); //This fills the Grid
            }
            else
            {
                hvSavedStatus.Text = "2";  //this means that data is not saved. So the form should be still shown with error. Text boxes should have their values as it is.
            }


        }

        #endregion

        #region SaveDesignation

        /// <summary>
        /// This method saves the Designation details
        /// </summary>
        private int SaveDesignation()
        {
            try
            {
                PayrollModel.Designation designation = new PayrollModel.Designation();

                //Fills the properties of designation object with values in the inputs.
                AddValues(designation);

                return new Payroll_Manager.Designation().AddDesignation(designation);  //Successfully saved. so, 1 is returned
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
        /// <param name="institution"></param>
        private void AddValues(PayrollModel.Designation designation)
        {
            //Fills the properties of designation object with values in the inputs.
            designation.DesignationTypeId = Convert.ToInt32(ddlDesignationType.SelectedValue);
            designation.DesignationCode = txtDesignationCode.Text;
            designation.DesignationName = txtDesignationName.Text;
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
            intDesignationId = Convert.ToInt32(gvMain.Rows[gvMain.SelectedIndex].Cells[0].Text.Trim());

            //Creating an object of Designation Class
            Payroll_Manager.Designation designation = new Payroll_Manager.Designation();

            //Setting the data source with the list of designation
            PayrollModel.Designation DesignationModel = designation.GetDesignationById(intDesignationId);

            //fill the text boxes with the values in the object
            ddlDesignationType.SelectedValue = DesignationModel.DesignationTypeId.ToString();
            txtDesignationCode.Text = DesignationModel.DesignationCode;
            txtDesignationName.Text = DesignationModel.DesignationName;

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

        #region ButtonUpdate_Click
        /// <summary>
        /// This method modifies the Designation details and returns save status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {


            if (UpdateDesignation() != -1)     //means it is updated            
            {
                lblErrorMsg.ForeColor = System.Drawing.Color.Green;
                lblErrorMsg.Text = "Designation Updated Successfully";
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

        #region UpdateDesignation

        /// <summary>
        /// This method updates the Designation details
        /// </summary>
        private int UpdateDesignation()
        {
            try
            {

                //Creating an object of Designation Class
                Payroll_Manager.Designation designation = new Payroll_Manager.Designation();

                //Setting the data source with the list of Designation
                PayrollModel.Designation designationmodel = designation.GetDesignationById(intDesignationId);

               
                AddValues(designationmodel);

                return designation.UpdateDesignation(designationmodel);

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



    }
}