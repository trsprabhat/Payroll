using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Payroll.Contact
{
    public partial class District : System.Web.UI.Page
    {
        #region LocalVariables

        private static int intDistrictId = 0;    //when user clicks on edit the id of the selected row is copied to this variable

        private static bool SaveStatus = true;   /*This flag decides the buttons to be visible when we select a dropdown and page is posted back
        hidden field 'hvSavedStatus' should change according to the value of this flag. 
        if new button is clicked, then it should be true, else if edit, then false*/

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
                FillCountry();
            }
        }
        #endregion

        #region FillGrid

        /// <summary>
        /// This method fills the grid by getting the values from Payroll Manager class
        /// </summary>
        private void FillGrid()
        {
            Payroll_Manager.Contact contact = new Payroll_Manager.Contact();

            //Select all District            
            gvMain.DataSource = contact.GetDistrict();
            gvMain.DataBind();

            //If no data is selected shows appropriate message
            if (gvMain.Rows.Count == 0)
            {
                lblErrorMsg.Text = "No District Added yet.";
                lblErrorMsg.ForeColor = System.Drawing.Color.Blue;
            }
        }

        #endregion

        #region FillState
        /// <summary>
        /// Fills the state details in the dropdown
        /// </summary>
        private void FillState()
        {
            //getting countryId from dropdown
            int countryId = Convert.ToInt32(ddlCountryName.SelectedValue);
            
            //Creating an object of Contact Class
            Payroll_Manager.Contact contact = new Payroll_Manager.Contact();

            //Setting the data source with the list of states
            ddlStateName.DataSource = contact.GetStateByCountryId(countryId);

            //Setting the text of drop down items that can be viewed by user
            ddlStateName.DataTextField = "StateName";

            //Setting the value of drop down items
            ddlStateName.DataValueField = "StateId";

            //Binding the data source to the drop down
            ddlStateName.DataBind();

            //Making the '--Select--' as the first item of dropdown
            ddlStateName.Items.Insert(0, new ListItem("--Select--", "0"));

            //This may not be needed here. To be decided later.
            if (ddlStateName.Items.Count <= 1)
            {
                lblErrorMsg.Text = "Please add a State First";
                lblErrorMsg.ForeColor = System.Drawing.Color.Blue;
            }
        }

        #endregion

        #region FillCountry
        /// <summary>
        /// Fills the country details in the dropdown
        /// </summary>
        private void FillCountry()
        {
            //Creating an object of Contact Class
            Payroll_Manager.Contact contact = new Payroll_Manager.Contact();

            //Setting the data source with the list of country
            ddlCountryName.DataSource = contact.GetCountry();

            //Setting the text of drop down items that can be viewed by user
            ddlCountryName.DataTextField = "CountryName";

            //Setting the value of drop down items
            ddlCountryName.DataValueField = "CountryId";

            //Binding the data source to the drop down
            ddlCountryName.DataBind();

            //Making the '--Select--' as the first item of dropdown
            ddlCountryName.Items.Insert(0, new ListItem("--Select--", "0"));

            //This may not be needed here. To be decided later.
            if (ddlCountryName.Items.Count <= 1)
            {
                lblErrorMsg.Text = "Please add a Country First";
                lblErrorMsg.ForeColor = System.Drawing.Color.Blue;
            }
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

        #region ButtonSave_Click
        /// <summary>
        /// This method saves the district details and returns save status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonSave_Click(object sender, EventArgs e)
        {

            if (SaveDistrict() != -1)     //means it is saved            
            {
                lblErrorMsg.ForeColor = System.Drawing.Color.Green;
                lblErrorMsg.Text = "District Saved Successfully";
                hvSavedStatus.Text = "1"; //this means that data is saved. So the form can be hidden(jquery can hide form and show grid with new data. Also, the text boxes should be cleared.
                SaveStatus = true;
                FillCountry();
                ddlStateName.Items.Clear();
                FillGrid(); //This fills the Grid
            }
            else
            {
                hvSavedStatus.Text = "2";  //this means that data is not saved. So the form should be still shown with error. Text boxes should have their values as it is.
                SaveStatus = true;
            }


        }

        #endregion

        #region SaveDistrict

        /// <summary>
        /// This method saves the district details
        /// </summary>
        private int SaveDistrict()
        {
            try
            {
                PayrollModel.District district = new PayrollModel.District();

                //Fills the properties of state object with values in the inputs.
                AddValues(district);

                return new Payroll_Manager.Contact().AddDistrict(district);  //Successfully saved. so, 1 is returned
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

        #region AddValues
        /// <summary>
        /// Add Values to the Model
        /// </summary>
        /// <param name="district"></param>
        private void AddValues(PayrollModel.District district)
        {
            //Fills the properties of state object with values in the inputs.
            district.CountryId = Convert.ToInt32(ddlCountryName.SelectedValue);
            district.StateId = Convert.ToInt32(ddlStateName.SelectedValue);
            district.DistrictName = txtDistrictName.Text;
        }

        #endregion

        #region ButtonUpdate_Click
        /// <summary>
        /// This method modifies the District details and returns save status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateDistrict() != -1)     //means it is updated            
            {
                lblErrorMsg.ForeColor = System.Drawing.Color.Green;
                lblErrorMsg.Text = "District Updated Successfully";
                hvSavedStatus.Text = "1"; //this means that data is updated. So the form can be hidden(jquery can hide form and show grid with new data. Also, the text boxes should be cleared.
                SaveStatus = false;
                FillGrid();  //This fills the Grid
                SubmitStatus(true); //save is set for enter button
                FillCountry();
                ddlStateName.Items.Clear();
            }
            else
            {
                hvSavedStatus.Text = "0";  //this means that data is not updated. So the form should be still shown with error. Text boxes should have their values as it is.
                SubmitStatus(false); //update is set for enter button
            }
        }

        #endregion

        #region UpdateDistrict

        /// <summary>
        /// This method updates the district details
        /// </summary>
        private int UpdateDistrict()
        {
            try
            {
                //Creating an object of Contact Class
                Payroll_Manager.Contact contact = new Payroll_Manager.Contact();

                //Setting the data source with the list of district
                PayrollModel.District district = contact.GetDistrictById(intDistrictId);

                AddValues(district);

                return  contact.UpdateDistrict(district);   //Successfully updated. so, 1 is returned

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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            SaveStatus = true;
            SubmitStatus(false); //update is set for enter button
        }

        #endregion

        #region gvMain_SelectedIndexChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveStatus = false;  
            
            // This method sets the values of the input controls.
            AddValues();

            //setting the hidden variable text to 0. This is to ensure that the form with current values are shown, and grid is hidden etc(see jquery)
            hvSavedStatus.Text = "0";

            SubmitStatus(false); //update is set for enter button

            gvMain.SelectedIndex = -1; //remove the selection after click Edit
        }

        #endregion

        #region AddValuesToInputControls
        /// <summary>
        /// Add values to the input controls of the form
        /// </summary>
        private void AddValues()
        {
            //Get the id of the selected row and store it to local vairable
            intDistrictId = Convert.ToInt32(gvMain.Rows[gvMain.SelectedIndex].Cells[0].Text.Trim());

            //Creating an object of Contact Class
            Payroll_Manager.Contact contact = new Payroll_Manager.Contact();

            //Setting the data source with the list of state
            PayrollModel.District district = contact.GetDistrictById(intDistrictId);

            //fill the text boxes with the values in the object
            ddlCountryName.SelectedValue = district.CountryId.ToString();
            FillState();
            ddlStateName.SelectedValue = district.StateId.ToString();
            txtDistrictName.Text = district.DistrictName;

        }
        #endregion

        #region ddlCountryName_SelectedIndexChanged
        /// <summary>
        /// Loads the states with respect to the selected country
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlCountryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillState();

            if (!SaveStatus)
            {
                hvSavedStatus.Text = "0";
            }
            else
            {
                hvSavedStatus.Text = "2";
            }
        }
        #endregion
    }
}