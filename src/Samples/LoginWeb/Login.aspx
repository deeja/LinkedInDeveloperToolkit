<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" 
  Inherits="Login" Codebehind="Login.aspx.cs" %>

<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
  
  <h2>Login</h2>
  <p>Please login so we can retrieve your LinkedIn permission from your account.</p>
  
  <asp:Login ID="login" runat="server" TitleText="" PasswordLabelText="Password" UserNameLabelText="User Name" 
    TextAlignment="Left" DestinationPageUrl="~/Secure/Profile.aspx" CreateUserText="Create an account" 
    CreateUserUrl="~/Register.aspx"></asp:Login>

</asp:Content>

