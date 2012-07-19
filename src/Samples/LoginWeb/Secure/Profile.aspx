<%@ Page Language="C#" MasterPageFile="~/Secure/Secure.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Secure_Profile" %>

<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">

  <h2>Your profile information</h2>
    
  <table cellpadding="0" cellspacing="0" border="0" style="float: left; width: 400px">
    <tr>
      <td class="label">Name:</td>
      <td class="data"><asp:Literal ID="nameLiteral" runat="server" /></td>
    </tr>
    <tr>
      <td class="label">Headline:</td>
      <td class="data"><asp:Literal ID="headlineLiteral" runat="server" /></td>
    </tr>
    <tr>
      <td class="label">Status:</td>
      <td class="data"><asp:Literal ID="statusLiteral" runat="server" /></td>
    </tr>
    <tr>
      <td class="label">Positions:</td>
      <td>
        <asp:DataList ID="positionsDataList" runat="server">
          <ItemTemplate>
            <strong><%# Eval("Title") %></strong> at <strong><%# Eval("Company.Name")%></strong>
          </ItemTemplate>
        </asp:DataList>
      </td>
    </tr>
  </table>
  
  <div style="float: left; width: 200px">
    <asp:Image ID="profileImage" runat="server" />
  </div>
  

</asp:Content>

