//-----------------------------------------------------------------------
// <copyright file="Connections.cs" company="Beemway">
//     Copyright (c) Beemway. All rights reserved.
// </copyright>
// <license>
//     Microsoft Public License (Ms-PL http://opensource.org/licenses/ms-pl.html).
//     Contributors may add their own copyright notice above.
// </license>
//-----------------------------------------------------------------------

using System;
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

public partial class _Connections : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    ILinkedInService service = _linkedInService;

    connectionsDataList.DataSource = service.GetConnectionsForCurrentUser().Items;
    connectionsDataList.DataBind();
  }
}