<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="MyFirstSiteWithMasterPage.Update" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-container">
    <div class="card">
        <div class="form-group">
            <label>Email</label>
           <%-- <asp:TextBox ID="txtEmail" runat="server" CssClass="input"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="*Required" CssClass="error"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                ErrorMessage="* Must be an email"
                ValidationExpression="\w+([-+.']\w+)@\w+([-.]\w+)\.\w+([-.]\w+)*"
                CssClass="error"></asp:RegularExpressionValidator>--%>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="input" ReadOnly="true"></asp:TextBox>
        </div>

    

        <div class="form-group">
            <label>Password</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                ControlToValidate="txtPassword" ErrorMessage="*Required" CssClass="error"></asp:RequiredFieldValidator>

        </div>

        <div class="form-group">
            <label>Confirm Password</label>
            <asp:TextBox ID="txtCpassword" runat="server" TextMode="Password" CssClass="input"></asp:TextBox>
            <asp:CompareValidator ID="cdPassword" runat="server"
                ControlToCompare="txtPassword" ControlToValidate="txtCpassword"
                ErrorMessage="*Value must match" CssClass="error"></asp:CompareValidator>
        </div>

        <div class="row">
    <div class="form-group half">
        <label>First Name</label>
        <asp:TextBox ID="txtFname" runat="server" CssClass="input"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvFname" runat="server"
            ControlToValidate="txtFname"
            ErrorMessage="*Required"
            CssClass="error">
        </asp:RequiredFieldValidator>
    </div>

    <div class="form-group half">
        <label>Last Name</label>
        <asp:TextBox ID="txtLname" runat="server" CssClass="input"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvLname" runat="server"
            ControlToValidate="txtLname"
            ErrorMessage="*Required"
            CssClass="error">
        </asp:RequiredFieldValidator>
    </div>
</div>

        <div class="form-group">
            <label>Year of Birth</label>
            <asp:TextBox ID="txtDob" runat="server" CssClass="input"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDOB" runat="server"
    ControlToValidate="txtDob"
    ErrorMessage="*Required"
    CssClass="error">
</asp:RequiredFieldValidator>
        </div>
    <asp:Button ID="btnRegister" runat="server"
    Text="Update"
    CssClass="btn"
    OnClick="btnRegister_Click"
    CausesValidation="false" />


    </div>

        <asp:Label ID="lblMessage" runat="server"></asp:Label>
 <asp:Label ID="lblPass" runat="server"></asp:Label>
</div>
</asp:Content>
