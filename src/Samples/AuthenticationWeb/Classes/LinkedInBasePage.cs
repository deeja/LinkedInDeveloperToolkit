//-----------------------------------------------------------------------
// <copyright file="LinkedInBasePage.cs" company="Beemway">
//     Copyright (c) Beemway. All rights reserved.
// </copyright>
// <license>
//     Microsoft Public License (Ms-PL http://opensource.org/licenses/ms-pl.html).
//     Contributors may add their own copyright notice above.
// </license>
//-----------------------------------------------------------------------

using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;

using LinkedIn;
using DotNetOpenAuth.Messaging;
using System.Globalization;

namespace Authentication.Web
{
  public class LinkedInBasePage : System.Web.UI.Page
  {
    protected string AccessToken
    {
      get { return (string)Session["AccessToken"]; }
      set { Session["AccessToken"] = value; }
    }

    protected InMemoryTokenManager TokenManager
    {
      get
      {
        var tokenManager = (InMemoryTokenManager)Application["TokenManager"];
        if (tokenManager == null)
        {
          string consumerKey = ConfigurationManager.AppSettings["LinkedInConsumerKey"];
          string consumerSecret = ConfigurationManager.AppSettings["LinkedInConsumerSecret"];
          if (string.IsNullOrEmpty(consumerKey) == false)
          {
            tokenManager = new InMemoryTokenManager(consumerKey, consumerSecret);
            Application["TokenManager"] = tokenManager;
          }
        }

        return tokenManager;
      }
    }

    protected WebOAuthAuthorization Authorization
    {
      get;
      set;
    }
  }
}