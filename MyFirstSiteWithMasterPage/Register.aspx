<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MyFirstSiteWithMasterPage.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-container">
    <div class="card">
        <div id="successCard" runat="server" visible="false" class="success-card">
    <h2>Account Deleted ✅</h2>
    <p>Your account has been successfully removed.</p>
</div>
        </div>
        </div>

     <div class="form-container">
 <div class="card">
 <table align="center" style="width: 73%">
     <tr>
         <td style="text-align: right; width: 456px">Email</td>
         <td>
             <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="* Must be an email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
         </td>
         <td>&nbsp;</td>
     </tr>
     <tr>
         <td style="text-align: right; width: 456px">Confirm Email </td>
         <td>
             <asp:TextBox ID="TxtCemail" runat="server"></asp:TextBox>
             <asp:CompareValidator ID="cdEmail" runat="server" ControlToCompare="txtEmail" ControlToValidate="TxtCemail" ErrorMessage="*Value must match" ForeColor="Red"></asp:CompareValidator>
         </td>
         <td>&nbsp;</td>
     </tr>
     <tr>
         <td style="text-align: right; width: 456px">Password</td>
         <td>
             <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>
         </td>
         <td>&nbsp;</td>
     </tr>
     <tr>
         <td style="text-align: right; width: 456px">Confirm Password</td>
         <td>
             <asp:TextBox ID="txtCpassword" runat="server"></asp:TextBox>
             <asp:CompareValidator ID="cdPassword" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtCpassword" ErrorMessage="*Value must match" ForeColor="Red"></asp:CompareValidator>
         </td>
         <td>&nbsp;</td>
     </tr>
     <tr>
         <td style="text-align: right; width: 456px">First Name</td>
         <td>
             <asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvFname" runat="server" ControlToValidate="txtFname" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>
         </td>
         <td>&nbsp;</td>
     </tr>
     <tr>
         <td style="text-align: right; width: 456px">Last Name</td>
         <td>
             <asp:TextBox ID="txtLname" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvLname" runat="server" ControlToValidate="txtLname" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>
         </td>
         <td>&nbsp;</td>
     </tr>
     <tr>
         <td style="text-align: right; width: 456px">Year of birth</td>
         <td>
             <asp:TextBox ID="txtDob" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="txtDob" ErrorMessage="*Required" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="rev2" runat="server" ControlToValidate="txtDob" ErrorMessage="* Must be a year" ValidationExpression="\d{4}" ForeColor="Red"></asp:RegularExpressionValidator>
         </td>
         <td>&nbsp;</td>
     </tr>
     <tr>
         <td style="text-align: right; width: 456px">&nbsp;</td>
         <td>&nbsp;</td>
         <td>&nbsp;</td>
     </tr>
     <tr>
         <td style="text-align: right; width: 456px">&nbsp;</td>
         <td>
             <asp:Button ID="btnRegister" runat="server" Text="Register" Width="251px" OnClick="btnRegister_Click" />
             <asp:Label ID="lblMessage" runat="server"></asp:Label>
         </td>
         <td>&nbsp;</td>
     </tr>
     <tr>
         <td style="text-align: right; width: 456px">&nbsp;</td>
         <td>&nbsp;</td>
         <td>&nbsp;</td>
     </tr>
 </table>
     </div>
     </div>
</asp:Content>

