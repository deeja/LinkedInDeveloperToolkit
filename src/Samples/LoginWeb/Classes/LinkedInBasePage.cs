//-----------------------------------------------------------------------
// <copyright file="LinkedInBasePage.cs" company="Beemway">
//     Copyright (c) Beemway. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Classes;
using LinkedIn;

public class LinkedInBasePage : System.Web.UI.Page
{

    protected static ILinkedInService _linkedInService = ServiceLookup.GetLinkedInService();

    protected override void OnLoad(EventArgs e)
    {
        
        //if (User.Identity.IsAuthenticated)

        //if (!IsPostBack)
        //{
        //    if (accessToken != null)
        //    {
        //        this.AccessToken = accessToken;

        //        Response.Redirect(Request.Path);
        //    }

        //    if (AccessToken == null)
        //    {
        //        Uri callback = new Uri(Page.ResolveUrl("http://localhost:1898/TestWeb/Default.aspx"));

        //        this.Authorization.BeginAuthorize(callback);
        //    }
        //}

        //base.OnLoad(e);
    }
}
