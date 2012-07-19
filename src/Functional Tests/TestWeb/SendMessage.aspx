<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="SendMessage.aspx.cs" Inherits="SendMessage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:TextBox ID="subjectTextBox" runat="server" Text="The subject of the message" /><br />
  <asp:TextBox ID="bodyTextBox" runat="server" Text="The body of the message" TextMode="MultiLine" Rows="5" Columns="50" /><br />
  <asp:CheckBox ID="includeCurrentUser" runat="server" />
  <asp:Button ID="sendButton" runat="server" Text="Send" OnClick="sendButton_Click" />
  <br /><br />
  <asp:TextBox ID="console" runat="server" TextMode="MultiLine" Rows="80" Columns="80" />
</asp:Content>

