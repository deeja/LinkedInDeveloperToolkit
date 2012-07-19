<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" Inherits="_Connections" Codebehind="Connections.aspx.cs" %>

<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">

  <h2>Your connections</h2>
      
  <asp:DataList ID="connectionsDataList" runat="server">
    <ItemTemplate>
      <strong><%# Eval("Name") %></strong> - <em><%# Eval("Headline")%></em>
    </ItemTemplate>
  </asp:DataList>

</asp:Content>

