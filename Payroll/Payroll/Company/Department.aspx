<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Department.aspx.cs" Inherits="Payroll.Company.Department" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/common-1.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<asp:ScriptManager ID="sm1" runat="server"></asp:ScriptManager>
 <script type="text/javascript">
     Sys.WebForms.PageRequestManager.getInstance().add_endRequest(InIEvent);   //Code used to avoid javascript clash with C#
 </script>

<asp:UpdatePanel ID="up1" runat="server">
<ContentTemplate>
    <h2>Department Details</h2>
    <br />

    <input id="ButtonNew" type="button" value="Add New Department" class="button" onclick="return ButtonNew_onclick()" /><br />
    
    <asp:TextBox ID="hvSavedStatus" runat="server" CssClass="donotshow"></asp:TextBox>

        <div id="lblDiv" align="center">
            <asp:TextBox ID="lblErrorMsg" runat="server" CssClass="ErrorLabel" 
                Enabled="False"></asp:TextBox>
        </div>
        
        <div id="formdiv" align="center">
            <div id="valdiv" align="left">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="valSummary" DisplayMode="List" ShowMessageBox="true" ShowSummary="false"/>
            </div>

            <table id="formtable" cellpadding="5" >
                <tr>
                    <td style="width:30%;">Company</td>
                    <td><asp:DropDownList ID="ddlCompanyName" runat="server" CssClass="dropdown" 
                            MaxLength="50"></asp:DropDownList></td>
                    <asp:RequiredFieldValidator ID="RFVddlCompanyName" runat="server" 
                        ErrorMessage="Select a Company " ControlToValidate="ddlCompanyName" InitialValue="0" Display="None"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </tr>

                 <tr>
                    <td style="width:30%;">Company Branch</td>
                    <td><asp:DropDownList ID="ddlCompanyBranch" runat="server" CssClass="dropdown" 
                            MaxLength="50"></asp:DropDownList></td>
                    <asp:RequiredFieldValidator ID="RFVddlCompanyBranch" runat="server" 
                        ErrorMessage="Select a Company Branch" ControlToValidate="ddlCompanyBranch" InitialValue="0" Display="None"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </tr>

                <tr>
                    <td style="width:30%;">Department Name</td>
                    <td><asp:TextBox ID="txtDepartmentName" runat="server" CssClass="longText" 
                            MaxLength="50"></asp:TextBox></td>
                    <asp:RequiredFieldValidator ID="RFV_txtDepartmentName" runat="server" 
                        ErrorMessage="Enter Department Name" ControlToValidate="txtDepartmentName" Display="None"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </tr>

                <tr>
                    <td style="width:30%;">Department Type</td>
                    <td><asp:DropDownList ID="ddlDepartmentType" runat="server" CssClass="dropdown" 
                            MaxLength="50"></asp:DropDownList></td>
                    <asp:RequiredFieldValidator ID="RFVddlDepartmentType" runat="server" 
                        ErrorMessage="Select Department Type" ControlToValidate="ddlDepartmentType" InitialValue="0" Display="None"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </tr>

                 <tr>
                    <td style="width:30%;">Phone No</td>
                    <td><asp:TextBox ID="txtPhoneNo" runat="server" CssClass="longText" 
                            MaxLength="50"></asp:TextBox></td>
                    <asp:RequiredFieldValidator ID="RFVtxtPhoneNo" runat="server" 
                        ErrorMessage="Enter Phone Number" ControlToValidate="txtPhoneNo" Display="None"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </tr>

                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="ButtonSave" runat="server" ClientIDMode="Static" 
                            CssClass="buttonAsp" Text="Save" onclick="ButtonSave_Click"  
                             />
                        <asp:Button ID="ButtonUpdate" runat="server" ClientIDMode="Static" 
                            CssClass="buttonAsp" Text="Update" onclick="ButtonUpdate_Click"  
                           />
                        
                        <asp:Button ID="ButtonCancel" runat="server" ClientIDMode="Static" 
                            CssClass="buttonAsp" Text="Cancel" 
                            CausesValidation="False" UseSubmitBehavior="false" 
                            OnClientClick="ShowGrid()" onclick="ButtonCancel_Click"   />
                        
                                    
                                             
                    </td>
                </tr>
            </table>
        </div>

 <br />

        <div id="maingrid" align="center">

            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
                CellPadding="5" 
                CssClass="gridview" 
                onselectedindexchanged="gvMain_SelectedIndexChanged"   >
                <Columns>
                    <asp:BoundField DataField="DepartmentId" HeaderStyle-CssClass="hiddenItem" ItemStyle-CssClass="hiddenItem" />
                    <asp:TemplateField HeaderText="Company" >
                        <ItemTemplate>
                            <asp:Label ID="LabelCompany" runat="server" Text='<%# Eval("Company.CompanyName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>  
                    <asp:TemplateField HeaderText="CompanyBranch" >
                        <ItemTemplate>
                            <asp:Label ID="LabelCompanyBranch" runat="server" Text='<%# Eval("CompanyBranch.CompanyBranchName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:BoundField DataField="DepartmentCode" HeaderText="Department Code" /> 
                    <asp:TemplateField HeaderText="DepartmentType" >
                        <ItemTemplate>
                            <asp:Label ID="LabelDepartmentType" runat="server" Text='<%# Eval("DepartmentType.DepartmentTypeName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                
                    <asp:BoundField DataField="DepartmentName" HeaderText="Department" />
                    <asp:CommandField ButtonType="Image" ShowSelectButton="True" SelectImageUrl="../Images/edit.png" />
                </Columns>
                <HeaderStyle BackColor="#35496A" ForeColor="#FFFCF2" />
            </asp:GridView>

        </div>
    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

