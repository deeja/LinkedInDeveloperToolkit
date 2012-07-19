//-----------------------------------------------------------------------
// <copyright file="Profile.cs" company="Beemway">
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

public partial class _Profile : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    LinkedInService service = new LinkedInService(base.Authorization);

    List<ProfileField> fields = new List<ProfileField>();
    fields.Add(ProfileField.PersonId);
    fields.Add(ProfileField.FirstName);
    fields.Add(ProfileField.LastName);
    fields.Add(ProfileField.Headline);
    fields.Add(ProfileField.CurrentStatus);
    fields.Add(ProfileField.PositionId);
    fields.Add(ProfileField.PositionTitle);
    fields.Add(ProfileField.PositionSummary);
    fields.Add(ProfileField.PositionStartDate);
    fields.Add(ProfileField.PositionEndDate);
    fields.Add(ProfileField.PositionIsCurrent);
    fields.Add(ProfileField.PositionCompanyName);
    fields.Add(ProfileField.PictureUrl);

    DisplayProfile(service.GetCurrentUser(ProfileType.Standard, fields));
  }

  private void DisplayProfile(Person person)
  {
    if (person != null)
    {
      nameLiteral.Text = person.Name;
      headlineLiteral.Text = person.Headline;
      statusLiteral.Text = person.CurrentStatus;
      profileImage.ImageUrl = person.PictureUrl;
      profileImage.AlternateText = person.Name;

      positionsDataList.DataSource = person.Positions;
      positionsDataList.DataBind();
    }
  }
}
