<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Grade.aspx.cs" Inherits="Payroll.Company.Grade" %>

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
    <h2>Grade Details</h2>
    <br />

    <input id="ButtonNew" type="button" value="Add New Grade" class="button" onclick="return ButtonNew_onclick()" /><br />
    
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
                    <td style="width:30%;">Grade Code</td>
                    <td><asp:TextBox ID="txtGradeCode" runat="server" CssClass="longText" 
                            MaxLength="50"></asp:TextBox></td>
                    <asp:RequiredFieldValidator ID="RFVtxtGradeCode" runat="server" 
                        ErrorMessage="Enter Grade Code" ControlToValidate="txtGradeCode" Display="None"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </tr>

                <tr>
                    <td style="width:30%;">Grade Name</td>
                    <td><asp:TextBox ID="txtGradeName" runat="server" CssClass="longText" 
                            MaxLength="50"></asp:TextBox></td>
                    <asp:RequiredFieldValidator ID="RFVGradeName" runat="server" 
                        ErrorMessage="Enter Grade Name" ControlToValidate="txtGradeName" Display="None"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </tr>

                <tr>
                    <td style="width:30%;">Grade Pay</td>
                    <td><asp:TextBox ID="txtGradePay" runat="server" CssClass="longText" 
                            MaxLength="50"></asp:TextBox></td>
                    <asp:RequiredFieldValidator ID="RFVtxtGradePay" runat="server" 
                        ErrorMessage="Enter Grade Pay" ControlToValidate="txtGradePay" Display="None"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </tr>

                <tr>
                    <td style="width:30%;">Description</td>
                    <td><asp:TextBox ID="txtDescription" runat="server" CssClass="longText" TextMode="MultiLine" 
                            MaxLength="50"></asp:TextBox></td>
                    
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
                            OnClientClick="ShowGrid()" onclick="ButtonCancel_Click"    />
                        
                                    
                                             
                    </td>
                </tr>
            </table>
        </div>

 <br />

        <div id="maingrid" align="center">

            <asp:GridView ID="gvMain" runat="server" AutoGenerateColumns="False" 
                CellPadding="5" 
                CssClass="gridview" onselectedindexchanged="gvMain_SelectedIndexChanged" 
                  >
                <Columns>
                    <asp:BoundField DataField="GradeId" HeaderStyle-CssClass="hiddenItem" ItemStyle-CssClass="hiddenItem" />   
                    <asp:BoundField DataField="GradeCode" HeaderText="Grade Code" />
                    <asp:BoundField DataField="GradeName" HeaderText="Grade Name" />
                    <asp:BoundField DataField="GradePay" HeaderText="Grade Pay" DataFormatString="{0:C2}" />
                     <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:CommandField ButtonType="Image" ShowSelectButton="True" SelectImageUrl="../Images/edit.png" />
                </Columns>
                <HeaderStyle BackColor="#35496A" ForeColor="#FFFCF2" />
            </asp:GridView>

        </div>
    </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
