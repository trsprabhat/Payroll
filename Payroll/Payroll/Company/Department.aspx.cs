using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Company
{
    public partial class Department : System.Web.UI.Page
    {
        #region LocalVariables

        private static int intDepartmentId = 0;    //when user clicks on edit the id of the selected row is copied to this variable

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
                FillCompany();
                FillCompanyBranch();
                FillDepartmentType();
            }
        }

        #endregion

        #region FillGrid

        /// <summary>
        /// This method fills the grid by getting the values from Payroll Manager class
        /// </summary>
        private void FillGrid()
        {
            Payroll_Manager.Department department = new Payroll_Manager.Department();

            //Select all Castes            
            gvMain.DataSource = department.GetAllDepartment();
            gvMain.DataBind();

            //If no data is selected shows appropriate message
            if (gvMain.Rows.Count == 0)
            {
                lblErrorMsg.Text = "No Department Added yet.";
                lblErrorMsg.ForeColor = System.Drawing.Color.Blue;
            }
        }

        #endregion

        #region FillDepartmentType
        /// <summary>
        /// Fills the DepartmentType details in the dropdown
        /// </summary>
        private void FillDepartmentType()
        {
            //Creating an object of Department Class
            Payroll_Manager.Department department = new Payroll_Manager.Department();

            //Setting the data source with the list of DepartmentType
            ddlDepartmentType.DataSource = department.GetAllDepartmentTypes();

            //Setting the text of drop down items that can be viewed by user
            ddlDepartmentType.DataTextField = "DepartmentTypeName";

            //Setting the value of drop down items
            ddlDepartmentType.DataValueField = "DepartmentTypeId";

            //Binding the data source to the drop down
            ddlDepartmentType.DataBind();

            //Making the '--Select--' as the first item of dropdown
            ddlDepartmentType.Items.Insert(0, new ListItem("--Select--", "0"));

            //This may not be needed here. To be decided later.
            if (ddlDepartmentType.Items.Count <= 1)
            {
                lblErrorMsg.Text = "Please add a DepartmentType First";
                lblErrorMsg.ForeColor = System.Drawing.Color.Blue;
            }
        }

        #endregion

        #region FillCompany
        /// <summary>
        /// Fills the Company details in the dropdown
        /// </summary>
        private void FillCompany()
        {
            //Creating an object of Company Class
            Payroll_Manager.Company company = new Payroll_Manager.Company();

            //Setting the data source with the list of Company
            ddlCompanyName.DataSource = company.GetAllCompany();

            //Setting the text of drop down items that can be viewed by user
            ddlCompanyName.DataTextField = "CompanyName";

            //Setting the value of drop down items
            ddlCompanyName.DataValueField = "CompanyId";

            //Binding the data source to the drop down
            ddlCompanyName.DataBind();

            //Making the '--Select--' as the first item of dropdown
            ddlCompanyName.Items.Insert(0, new ListItem("--Select--", "0"));

            //This may not be needed here. To be decided later.
            if (ddlCompanyName.Items.Count <= 1)
            {
                lblErrorMsg.Text = "Please add a Company First";
                lblErrorMsg.ForeColor = System.Drawing.Color.Blue;
            }
        }

        #endregion

        #region FillCompanyBranch
        /// <summary>
        /// Fills the CompanyBranch details in the dropdown
        /// </summary>
        private void FillCompanyBranch()
        {
            //Creating an object of CompanyBranch Class
            Payroll_Manager.Company company = new Payroll_Manager.Company();

            //Setting the data source with the list of CompanyBranch
            ddlCompanyBranch.DataSource = company.GetAllCompanyBranch();

            //Setting the text of drop down items that can be viewed by user
            ddlCompanyBranch.DataTextField = "CompanyBranchName";

            //Setting the value of drop down items
            ddlCompanyBranch.DataValueField = "CompanyBranchId";

            //Binding the data source to the drop down
            ddlCompanyBranch.DataBind();

            //Making the '--Select--' as the first item of dropdown
            ddlCompanyBranch.Items.Insert(0, new ListItem("--Select--", "0"));

            //This may not be needed here. To be decided later.
            if (ddlCompanyBranch.Items.Count <= 1)
            {
                lblErrorMsg.Text = "Please add a CompanyBranch First";
                lblErrorMsg.ForeColor = System.Drawing.Color.Blue;
            }
        }

        #endregion

        #region ButtonSave_Click
        /// <summary>
        /// This method saves the Department details and returns save status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSave_Click(object sender, EventArgs e)
        {

            if (SaveDepartment() != -1)     //means it is saved            
            {
                lblErrorMsg.ForeColor = System.Drawing.Color.Green;
                lblErrorMsg.Text = "Department Saved Successfully";
                hvSavedStatus.Text = "1"; //this means that data is saved. So the form can be hidden(jquery can hide form and show grid with new data. Also, the text boxes should be cleared.
                FillGrid(); //This fills the Grid
            }
            else
            {
                hvSavedStatus.Text = "2";  //this means that data is not saved. So the form should be still shown with error. Text boxes should have their values as it is.
            }


        }

        #endregion

        #region SaveDepartment

        /// <summary>
        /// This method saves the Department details
        /// </summary>
        private int SaveDepartment()
        {
            try
            {
                PayrollModel.Department department = new PayrollModel.Department();

                //Fills the properties of department object with values in the inputs.
                AddValues(department);

                return new Payroll_Manager.Department().AddDepartment(department);  //Successfully saved. so, 1 is returned
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
        /// <param name="department"></param>
        private void AddValues(PayrollModel.Department department)
        {
            //Fills the properties of department object with values in the inputs.
            department.CompanyId = Convert.ToInt32(ddlCompanyName.SelectedValue);
            department.CompanyBranchId = Convert.ToInt32(ddlCompanyBranch.SelectedValue);
            department.DepartmentName = txtDepartmentName.Text;
            department.DepartmentTypeId = Convert.ToInt32(ddlDepartmentType.SelectedValue);
            department.PhoneNo = txtPhoneNo.Text;
            
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
            intDepartmentId = Convert.ToInt32(gvMain.Rows[gvMain.SelectedIndex].Cells[0].Text.Trim());

            //Creating an object of Department Class
            Payroll_Manager.Department department = new Payroll_Manager.Department();

            //Setting the data source with the list of department
            PayrollModel.Department DepartmentModel = department.GetDepartmentById(intDepartmentId);

            //fill the text boxes with the values in the object
            ddlCompanyName.SelectedValue = DepartmentModel.CompanyId.ToString();
            ddlCompanyBranch.SelectedValue = DepartmentModel.CompanyBranchId.ToString();
            txtDepartmentName.Text = DepartmentModel.DepartmentName;
            ddlDepartmentType.SelectedValue = DepartmentModel.DepartmentTypeId.ToString();
            txtPhoneNo.Text = DepartmentModel.PhoneNo;
            

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
        /// This method modifies the Department details and returns save status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {


            if (UpdateDepartment() != -1)     //means it is updated            
            {
                lblErrorMsg.ForeColor = System.Drawing.Color.Green;
                lblErrorMsg.Text = "Department Updated Successfully";
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

        #region UpdateDepartment

        /// <summary>
        /// This method updates the Department details
        /// </summary>
        private int UpdateDepartment()
        {
            try
            {

                //Creating an object of Department Class
                Payroll_Manager.Department department = new Payroll_Manager.Department();

                //Setting the data source with the list of Department
                PayrollModel.Department departmentmodel = department.GetDepartmentById(intDepartmentId);

                AddValues(departmentmodel);
                
                return department.UpdateDepartment(departmentmodel);

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
            FillGrid();
        }

        #endregion

    }
}