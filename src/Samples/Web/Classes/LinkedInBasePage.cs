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
using Classes;
using LinkedIn;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class LinkedInBasePage : System.Web.UI.Page
{

    protected static ILinkedInService _linkedInService = ServiceLookup.GetLinkedInService();


    protected override void OnLoad(EventArgs e)
    {
    }
}
