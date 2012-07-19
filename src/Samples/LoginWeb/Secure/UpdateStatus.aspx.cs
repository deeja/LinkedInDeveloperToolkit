//-----------------------------------------------------------------------
// <copyright file="UpdateStatus.cs" company="Beemway">
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
using LinkedIn.Utility;
using LinkedIn.ServiceEntities;

public partial class _UpdateStatus : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    if (!IsPostBack)
    {
      ShowCurrentStatus();
    }
  }

  protected void updateButton_Click(object sender, EventArgs e)
  {
    try
    {
      LinkedInService service = new LinkedInService(base.Authorization);

      service.CreateShare(statusTextBox.Text, VisibilityCode.ConnectionsOnly);

      ShowCurrentStatus();

      currentStatusLabel.Text = "Your updated status:";
      messageLabel.Text = "You successfully updated your status.";
    }
    catch (LinkedInException li)
    {
      messageLabel.Text = string.Format("An error occured: {0}", li.Message);
    }

    messageLabel.Visible = true;
  }

  private void ShowCurrentStatus()
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

    Person currentUser = service.GetCurrentUser(ProfileType.Standard, fields);

    currentStatusLiteral.Text = currentUser.CurrentStatus;
  }
}
