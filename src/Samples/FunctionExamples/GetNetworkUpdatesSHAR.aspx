<%@ Page Language="C#" MasterPageFile="~/Default.master" ValidateRequest="false" AutoEventWireup="true" Inherits="GetNetworkUpdatesSHAR" Codebehind="GetNetworkUpdatesSHAR.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <asp:CheckBox ID="scopeCheckBox" runat="server" />Your own updates<br />
  <asp:Button ID="executeButton" runat="server" Text="Get" OnClick="executeButton_Click" />
  <br /><br />
  <asp:TextBox ID="console" runat="server" TextMode="MultiLine" Rows="60" Columns="80" />
</asp:Content>

