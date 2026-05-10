<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AcctSuccessfull.aspx.cs" Inherits="MyFirstSiteWithMasterPage.AcctSuccessfull" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <div class="card-container">
     <div class="card">

         <div class="success-icon">✔</div>

         <asp:Label ID="lblMessage" runat="server" CssClass="message">
            Registered successfully!
         </asp:Label>

         <asp:HyperLink ID="lnkLogin" runat="server" 
             NavigateUrl="LoginPage.aspx" 
             CssClass="link-btn" Visible="false">
             Click here to login
         </asp:HyperLink>

     </div>
 </div>
</asp:Content>
