<%@ Page Language="C#" MasterPageFile="~/Default.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="CreateShare.aspx.cs" Inherits="CreateShare" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:TextBox ID="commentTextBox" runat="server" Text="Testing shares using the LinkedIn Developer Toolkit" TextMode="MultiLine" Rows="5" Columns="50" /><br />
  <asp:Button ID="sendButton" runat="server" Text="Send" OnClick="sendButton_Click" />
  <br /><br />
  <hr />
  <asp:TextBox ID="titleTextBox" runat="server" Text="Testing shares using the LinkedIn Developer Toolkit" Columns="50" /><br />
  <asp:TextBox ID="submittedUrlTextBox" runat="server" Text="http://linkedintoolkit.codeplex.com/" Columns="50" /><br />
  <asp:CheckBox ID="postOnTwitterCheckBox" runat="server" />Post also on Twitter<br />
  <asp:Button ID="sendButton2" runat="server" Text="Send" OnClick="sendButton2_Click" />
  <br /><br />
  <asp:TextBox ID="console" runat="server" TextMode="MultiLine" Rows="80" Columns="80" />
</asp:Content>

