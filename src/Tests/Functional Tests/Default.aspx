<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" Inherits="Default" Codebehind="Default.aspx.cs" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <asp:HyperLink runat="server" NavigateUrl="~/GetCurrentUserFull.aspx">GetCurrentUserFull</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/GetProfileByMemberId.aspx">GetProfileByMemberId</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/GetProfilesByMemberIds.aspx">GetProfilesByMemberIds</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/Search.aspx">Search</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/GetConnections.aspx">GetConnections</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/GetConnectionsFull.aspx">GetConnectionsFull</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/GetModifiedConnections.aspx">GetModifiedConnections</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/GetOutOfNetworkProfile.aspx">GetOutOfNetworkProfile</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/GetNetworkUpdates.aspx">GetNetworkUpdates</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/GetNetworkUpdatesANSW.aspx">GetNetworkUpdatesANSW</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/GetNetworkUpdatesAPPS.aspx">GetNetworkUpdatesAPPS</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/GetNetworkUpdatesCONN.aspx">GetNetworkUpdatesCONN</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/GetNetworkUpdatesJOBS.aspx">GetNetworkUpdatesJOBS</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/GetNetworkUpdatesJGRP.aspx">GetNetworkUpdatesJGRP</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/GetNetworkUpdatesRECU.aspx">GetNetworkUpdatesRECU</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/GetNetworkUpdatesPICT.aspx">GetNetworkUpdatesPICT</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/GetNetworkUpdatesQSTN.aspx">GetNetworkUpdatesQSTN</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/GetNetworkUpdatesSHAR.aspx">GetNetworkUpdatesSHAR</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/GetNetworkStatistics.aspx">GetNetworkStatistics</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/CommentOnNetworkUpdate.aspx">CommentOnNetworkUpdate</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/LikeNetworkUpdate.aspx">LikeNetworkUpdate</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/UnlikeNetworkUpdate.aspx">UnlikeNetworkUpdate</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/CreateShare.aspx">CreateShare</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/CreateReShare.aspx">CreateReShare</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/InvitePersonByEmailAddress.aspx">InvitePersonByEmailAddress</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/SendMessage.aspx">SendMessage</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/PostNetworkUpdate.aspx">PostNetworkUpdate</asp:HyperLink><br />
  <asp:HyperLink runat="server" NavigateUrl="~/InvalidateToken.aspx">InvalidateToken</asp:HyperLink><br />
  
  <br />
  <asp:TextBox ID="console" runat="server" TextMode="MultiLine" Rows="40" Columns="80" />
</asp:Content>

