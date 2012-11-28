<%@ Page Language="C#" MasterPageFile="~/Default.master" ValidateRequest="false" AutoEventWireup="true" Inherits="LikeNetworkUpdate" Codebehind="LikeNetworkUpdate.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  Update key (see: <a href="GetNetworkUpdates.aspx">Network Updates</a>): <asp:TextBox ID="updateKeyTextBox" runat="server" Columns="50" /><br />
  <asp:Button ID="sendButton" runat="server" Text="Send" OnClick="sendButton_Click" />
  <br /><br />
  <asp:TextBox ID="console" runat="server" TextMode="MultiLine" Rows="80" Columns="80" />
</asp:Content>

