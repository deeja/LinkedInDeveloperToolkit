<%@ Page Language="C#" MasterPageFile="~/Secure/Secure.master" AutoEventWireup="true" Inherits="_UpdateStatus" Codebehind="UpdateStatus.aspx.cs" %>

<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">

  <h2>Update your status</h2>
  
  <asp:Label ID="messageLabel" runat="server" Visible="false" ForeColor="Red" />
  <br />
  
  <asp:Label ID="currentStatusLabel" runat="server" CssClass="italic">Your current status:</asp:Label>
  <asp:Literal ID="currentStatusLiteral" runat="server" />
  <br /><br />
  <asp:TextBox ID="statusTextBox" runat="server" TextMode="MultiLine" Rows="2" Columns="50" /><br />
  <asp:Button ID="updateButton" runat="server" Text="Update" OnClick="updateButton_Click" />

</asp:Content>

