<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="InvitePersonByEmailAddress.aspx.cs" Inherits="InvitePersonByEmailAddress" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  E-mail address: <asp:TextBox ID="emailAddressTextBox" runat="server" /><br />
  First name: <asp:TextBox ID="firstNameTextBox" runat="server" /><br />
  Last name: <asp:TextBox ID="lastNameTextBox" runat="server" /><br />
  Subject: <asp:TextBox ID="subjectTextBox" runat="server" Text="The subject of the message" /><br />
  Body: <asp:TextBox ID="bodyTextBox" runat="server" Text="The body of the message" TextMode="MultiLine" Rows="5" Columns="50" /><br />
  <asp:Button ID="sendButton" runat="server" Text="Send" OnClick="sendButton_Click" />
  <br /><br />
  <asp:TextBox ID="console" runat="server" TextMode="MultiLine" Rows="80" Columns="80" />
</asp:Content>

