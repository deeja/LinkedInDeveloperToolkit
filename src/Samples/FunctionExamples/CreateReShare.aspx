<%@ Page Language="C#" MasterPageFile="~/Default.master" ValidateRequest="false" AutoEventWireup="true" Inherits="CreateReShare" Codebehind="CreateReShare.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:TextBox ID="commentTextBox" runat="server" Text="Testing shares using the LinkedIn Developer Toolkit" Columns="50" /><br />
  Share Id (see <a href="GetNetworkUpdatesSHAR.aspx">GetNetworkUpdates</a>): <asp:TextBox ID="shareIdTextBox" runat="server" Columns="50" /><br />
  <asp:Button ID="sendButton" runat="server" Text="Send" OnClick="sendButton_Click" />
  <br /><br />
  <asp:TextBox ID="console" runat="server" TextMode="MultiLine" Rows="80" Columns="80" />
</asp:Content>

