<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="State.aspx.cs" Inherits="Payroll.Address.State" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="../../Scripts/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/common-1.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<asp:ScriptManager ID="sm1" runat="server"></asp:ScriptManager>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(InIEvent);
    </script>

<asp:UpdatePanel ID="up1" runat="server">
<ContentTemplate>
    <h2>State Details</h2>
    <br />

    <input id="ButtonNew" type="button" value="Add New State" class="button"  /><br />
    
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
                    <td style="width:30%;">Country Name</td>
                    <td><asp:DropDownList ID="ddlCountryName" runat="server"  CssClass="dropdown"></asp:DropDownList></td>
               </tr>
                <tr>
                    <td style="width:30%;">State Name</td>
                    <td><asp:TextBox ID="txtStateName" runat="server" CssClass="longText" 
                            MaxLength="50"></asp:TextBox></td>
                    <asp:RequiredFieldValidator ID="RFV_txtStateName" runat="server" 
                        ErrorMessage="Enter State Name" ControlToValidate="txtStateName" Display="None"
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
                CssClass="gridview" onselectedindexchanged="gvMain_SelectedIndexChanged"  >
                <Columns>
                    <asp:BoundField DataField="StateId" HeaderStyle-CssClass="hiddenItem" ItemStyle-CssClass="hiddenItem" />                    
                    <asp:TemplateField HeaderText="Country" >
                        <ItemTemplate>
                            <asp:Label ID="LabelCountry" runat="server" Text='<%# Eval("Country.CountryName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="StateName" HeaderText="State" />
                    <asp:CommandField ButtonType="Image" ShowSelectButton="True" SelectImageUrl="~/images/edit.png" />
                </Columns>
                <HeaderStyle BackColor="#35496A" ForeColor="#FFFCF2" />
            </asp:GridView>

        </div>
    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
