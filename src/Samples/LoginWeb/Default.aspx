<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">

  <h2>Overview</h2>

  <p>The LinkedIn Developer Toolkit is a open source library build in C# for using the <a href="http://developer.linkedin.com/">LinkedIn&reg; API</a> in your .Net web applications.<br />
    These samples will help you get started.</p>
  
  <p>The LinkedIn Developer Toolkit is a project created by <a href="http://www.beemway.com/">Beemway</a>. For support options, please email <a href="mailto:info@beemway.com">info@beemway.com</a>.</p>
  
  <asp:LoginView runat="server">
    <AnonymousTemplate>
      <p></p>
      <p><strong>Before you can use these samples, you need to <a href="Login.aspx">login</a>.</strong></p>
      <p></p>
    </AnonymousTemplate>
    <LoggedInTemplate>
      <ul>
        <li><a href="Secure/Profile.aspx">Retrieve your profile information</a></li>
        <li><a href="Secure/Connections.aspx">Retrieve all your connections</a></li>
        <li><a href="Secure/UpdateStatus.aspx">Update your status</a></li>
      </ul>
    </LoggedInTemplate>
  </asp:LoginView>
  
  <p>Download the latest version (including these samples) at <a href="http://linkedintoolkit.codeplex.com/">Codeplex.com</a></p>

</asp:Content>

