<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MyFirstSiteWithMasterPage.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h2>Contact Me</h2>
<asp:Label runat="server" Text="Name:" style="text-align: center"></asp:Label>
<asp:TextBox runat="server" ID="txtName" CssClass="form-
control" Width="296px"></asp:TextBox>
    <br />
<asp:Label runat="server" Text="Email:"></asp:Label>
<asp:TextBox runat="server" ID="txtEmail" CssClass="form-
control" Width="299px"></asp:TextBox>
    <br />
<asp:Label runat="server" Text="Message:"></asp:Label>
<asp:TextBox runat="server" ID="txtMessage"
CssClass="form-control" Height="16px" Width="243px"></asp:TextBox>
    <br />
<asp:Button runat="server" ID="btnSubmit" Text="Send Message"
CssClass="btn-submit" OnClick="btnSubmit_Click" /><br />
<asp:Label runat="server" ID="lblResult" ForeColor="Green"></asp:Label>
</asp:Content>
