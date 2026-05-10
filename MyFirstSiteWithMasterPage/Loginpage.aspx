<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Loginpage.aspx.cs" Inherits="MyFirstSiteWithMasterPage.Loginpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="login-container">
    <h2>Login</h2>

    <asp:Label ID="lblUsername" runat="server" Text="Email"></asp:Label><br />
    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>

    <!-- Required Field Validator -->
    <asp:RequiredFieldValidator 
        ID="rfvUser" 
        runat="server" 
        ControlToValidate="txtUsername"
        ErrorMessage="Email is required" 
        ForeColor="Red" />

    <!-- Email Format Validator -->
    <asp:RegularExpressionValidator 
        ID="revEmail" 
        runat="server" 
        ControlToValidate="txtUsername"
        ValidationExpression="\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}"
        ErrorMessage="Invalid email format"
        ForeColor="Red" />

    <br /><br />

    <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label><br />
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>

    <!-- Password Required -->
    <asp:RequiredFieldValidator 
        ID="rfvPass" 
        runat="server" 
        ControlToValidate="txtPassword"
        ErrorMessage="Password is required"
        ForeColor="Red" />

    <br /><br />

   <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="login-btn" OnClick="btnLogin_Click" />

    <br /><br />

    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
</div>
   
</asp:Content>