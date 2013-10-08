<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Caste.aspx.cs" Inherits="Payroll.Employee.Caste" %>

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
    <h2>Caste Details</h2>
    <br />

    <input id="ButtonNew" type="button" value="Add New Caste" class="button"  /><br />
    
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
                    <td style="width:30%;">Religion Name</td>
                    <td><asp:DropDownList ID="ddlReligionName" runat="server"  CssClass="dropdown"></asp:DropDownList></td>
               </tr>
                <tr>
                    <td style="width:30%;">Caste Name</td>
                    <td><asp:TextBox ID="txtCasteName" runat="server" CssClass="longText" 
                            MaxLength="50"></asp:TextBox></td>
                    <asp:RequiredFieldValidator ID="RFV_txtCasteName" runat="server" 
                        ErrorMessage="Enter Caste Name" ControlToValidate="txtCasteName" Display="None"
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
                            OnClientClick="ShowGrid()" onclick="ButtonCancel_Click"  />
                        
                                    
                                             
                    </td>
                </tr>
            </table>
        </div>

 <br />

        <div id="maingrid" align="center">

            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
                CellPadding="5" 
                CssClass="gridview" onselectedindexchanged="gvMain_SelectedIndexChanged" >
                <Columns>
                    <asp:BoundField DataField="CasteId" HeaderStyle-CssClass="hiddenItem" ItemStyle-CssClass="hiddenItem" /> 
                    <asp:TemplateField HeaderText="Religion" >
                        <ItemTemplate>
                            <asp:Label ID="LabelReligion" runat="server" Text='<%# Eval("Religion.ReligionName") %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>                   
                    <asp:BoundField DataField="CasteName" HeaderText="Caste" />
                    <asp:CommandField ButtonType="Image" ShowSelectButton="True" SelectImageUrl="~/images/edit.png" />
                </Columns>
                <HeaderStyle BackColor="#35496A" ForeColor="#FFFCF2" />
            </asp:GridView>

        </div>
    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
