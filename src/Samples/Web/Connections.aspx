<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Connections.aspx.cs" Inherits="_Connections" %>

<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">

  <h2>Your connections</h2>
      
  <asp:DataList ID="connectionsDataList" runat="server">
    <ItemTemplate>
      <strong><%# Eval("Name") %></strong> - <em><%# Eval("Headline")%></em>
    </ItemTemplate>
  </asp:DataList>

</asp:Content>

