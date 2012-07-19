<%@ Page Language="C#" MasterPageFile="~/Default.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="PostNetworkUpdate.aspx.cs" Inherits="PostNetworkUpdate" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:TextBox ID="bodyTextBox" runat="server" Text="created a Network Update using the <a href='http://linkedintoolkit.codeplex.com/'>LinkedIn Developer Toolkit</a>" TextMode="MultiLine" Rows="5" Columns="50" /><br />
  <asp:Button ID="sendButton" runat="server" Text="Send" OnClick="sendButton_Click" />
  <br /><br />
  <asp:TextBox ID="console" runat="server" TextMode="MultiLine" Rows="20" Columns="80" />
</asp:Content>

