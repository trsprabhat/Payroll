<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Designation.aspx.cs" Inherits="Payroll.Company.Designation" %>

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
    <h2>Designation Details</h2>
    <br />

    <input id="ButtonNew" type="button" value="Add New Designation" class="button" onclick="return ButtonNew_onclick()" /><br />
    
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
                    <td style="width:30%;">Designation Code</td>
                    <td><asp:TextBox ID="txtDesignationCode" runat="server" CssClass="longText" 
                            MaxLength="50"></asp:TextBox></td>
                    <asp:RequiredFieldValidator ID="RFVtxtDesignationCode" runat="server" 
                        ErrorMessage="Enter Designation Code" ControlToValidate="txtDesignationCode" Display="None"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </tr>

                <tr>
                    <td style="width:30%;">Designation Type</td>
                    <td><asp:DropDownList ID="ddlDesignationType" runat="server" CssClass="dropdown" 
                            MaxLength="50"></asp:DropDownList></td>
                    <asp:RequiredFieldValidator ID="RFVddlDesignationType" runat="server" 
                        ErrorMessage="Select Designation Type" ControlToValidate="ddlDesignationType" InitialValue="0" Display="None"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </tr>

                <tr>
                    <td style="width:30%;">Designation Name</td>
                    <td><asp:TextBox ID="txtDesignationName" runat="server" CssClass="longText" 
                            MaxLength="50"></asp:TextBox></td>
                    <asp:RequiredFieldValidator ID="RFV_txtDesignationName" runat="server" 
                        ErrorMessage="Enter Designation Name" ControlToValidate="txtDesignationName" Display="None"
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
                            OnClientClick="ShowGrid()"   />
                        
                                                                              
                    </td>
                </tr>
            </table>
        </div>

 <br />

        <div id="maingrid" align="center">

            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
                CellPadding="5" 
                CssClass="gridview" onselectedindexchanged="gvMain_SelectedIndexChanged"  >
                <Columns>
                    <asp:BoundField DataField="DesignationId" HeaderStyle-CssClass="hiddenItem" ItemStyle-CssClass="hiddenItem" />   
                    <asp:BoundField DataField="DesignationCode" HeaderText="Designation Code" />                 
                    <asp:TemplateField HeaderText="Designation Type" >
                        <ItemTemplate>
                            <asp:Label ID="LabelDesignationType" runat="server" Text='<%# Eval("DesignationType.DesignationTypeName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="DesignationName" HeaderText="Designation" />
                    <asp:CommandField ButtonType="Image" ShowSelectButton="True" SelectImageUrl="../Images/edit.png" />
                </Columns>
                <HeaderStyle BackColor="#35496A" ForeColor="#FFFCF2" />
            </asp:GridView>

        </div>
    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
