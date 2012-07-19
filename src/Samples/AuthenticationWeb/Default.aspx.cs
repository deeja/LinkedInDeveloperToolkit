//-----------------------------------------------------------------------
// <copyright file="Default.aspx.cs" company="Beemway">
//     Copyright (c) Beemway. All rights reserved.
// </copyright>
// <license>
//     Microsoft Public License (Ms-PL http://opensource.org/licenses/ms-pl.html).
//     Contributors may add their own copyright notice above.
// </license>
//-----------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;

using LinkedIn;
using LinkedIn.ServiceEntities;

namespace Authentication.Web
{
  public partial class Default : LinkedInBasePage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      base.Authorization = new WebOAuthAuthentication(base.TokenManager, base.AccessToken);

      if (!IsPostBack)
      {
        string accessToken = this.Authorization.CompleteAuthorize();
        if (accessToken != null)
        {
          this.AccessToken = accessToken;

          Response.Redirect(Request.Path);
        }
      }

      if (string.IsNullOrEmpty(base.AccessToken))
      {
        loginStatusMultiView.ActiveViewIndex = 0;
      }
      else
      {
        loginStatusMultiView.ActiveViewIndex = 1;
        ShowCurrentUserInfo();
      }
    }

    protected void logInUsingLinkedInButtom_Click(object sender, EventArgs e)
    {
      if (base.AccessToken == null)
      {
        this.Authorization.BeginAuthorize();
      }
    }

    protected void logOutButton_Click(object sender, EventArgs e)
    {
      LinkedInService service = new LinkedInService(base.Authorization);
      service.InvalidateToken();
      this.AccessToken = null;

      loginStatusMultiView.ActiveViewIndex = 0;
    }

    private void ShowCurrentUserInfo()
    {
      LinkedInService service = new LinkedInService(base.Authorization);

      List<ProfileField> fields = new List<ProfileField>();
      fields.Add(ProfileField.PersonId);
      fields.Add(ProfileField.FirstName);
      fields.Add(ProfileField.LastName);
      fields.Add(ProfileField.PublicProfileUrl);

      Person currentUser = service.GetCurrentUser(ProfileType.Standard, fields);
      if (currentUser != null)
      {
        currentUserHyperLink.NavigateUrl = currentUser.PublicProfileUrl;
        currentUserHyperLink.Text = currentUser.Name;
      }
    }
  }
}