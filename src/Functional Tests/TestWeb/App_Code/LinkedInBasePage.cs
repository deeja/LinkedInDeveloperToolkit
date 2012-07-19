//-----------------------------------------------------------------------
// <copyright file="LinkedInBasePage.cs" company="Beemway">
//     Copyright (c) Beemway. All rights reserved.
// </copyright>
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

public class LinkedInBasePage : System.Web.UI.Page
{
  private string consumerKey;

  private string AccessToken
  {
    get { return (string)Session["AccessToken"]; }
    set { Session["AccessToken"] = value; }
  }

  public string ConsumerKey
  {
    get
    {
      if (string.IsNullOrEmpty(this.consumerKey))
      {
        this.consumerKey = ConfigurationManager.AppSettings["LinkedInConsumerKey"];
      }

      return this.consumerKey;
    }
    set { this.consumerKey = value; }
  }

  private InMemoryTokenManager TokenManager
  {
    get
    {
      var tokenManager = (InMemoryTokenManager)Application["TokenManager"];
      if (tokenManager == null)
      {
        string consumerSecret = ConfigurationManager.AppSettings["LinkedInConsumerSecret"];
        if (string.IsNullOrEmpty(this.ConsumerKey) == false)
        {
          tokenManager = new InMemoryTokenManager(this.ConsumerKey, consumerSecret);
          Application["TokenManager"] = tokenManager;
        }
      }

      return tokenManager;
    }
  }

  protected WebOAuthAuthorization Authorization
  {
    get;
    private set;
  }

  protected override void OnLoad(EventArgs e)
  {
    this.Authorization = new WebOAuthAuthorization(this.TokenManager, this.AccessToken);

    if (!IsPostBack)
    {
      string accessToken = this.Authorization.CompleteAuthorize();
      if (accessToken != null)
      {
        this.AccessToken = accessToken;

        Response.Redirect(Request.Path);
      }

      if (AccessToken == null)
      {
        Uri callback = new Uri(Page.ResolveUrl("http://localhost:1898/TestWeb/Default.aspx"));

        this.Authorization.BeginAuthorize(callback);
      }
    }

    base.OnLoad(e);
  }
}
