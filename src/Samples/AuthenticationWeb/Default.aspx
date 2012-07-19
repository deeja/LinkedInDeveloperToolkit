<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" Inherits="Authentication.Web._Default" Codebehind="Default.aspx.cs" %>

<asp:Content ID="bodyContent" ContentPlaceHolderID="bodyContentPlaceHolder" runat="Server">

  <h2>Overview</h2>

  <asp:MultiView ID="loginStatusMultiView" runat="server" ActiveViewIndex="0">
    <asp:View runat="server">
      <p>Please log in using LinkedIn.</p>
  
      <asp:ImageButton ID="logInUsingLinkedInButtom" runat="server" ImageUrl="~/assets/img/log-in-linkedin-large.png" OnClick="logInUsingLinkedInButtom_Click" />
      
      <p></p>
      <p>
        For more information visit: <a 
          href="http://developer.linkedin.com/community/apis/blog/2010/04/29/oauth--now-for-authentication">http://developer.linkedin.com/community/apis/blog/2010/04/29/oauth--now-for-authentication</a><br />
        For other buttons see: <a href="http://developer.linkedin.com/docs/DOC-1182">http://developer.linkedin.com/docs/DOC-1182</a>
      </p>
    </asp:View>
    <asp:View runat="server">
      <p>Authentication of <asp:HyperLink ID="currentUserHyperLink" runat="server" /> successful.</p>
      
      <asp:LinkButton ID="logOutButton" runat="server" OnClick="logOutButton_Click"></asp:LinkButton>
    </asp:View>
  </asp:MultiView>

</asp:Content>

