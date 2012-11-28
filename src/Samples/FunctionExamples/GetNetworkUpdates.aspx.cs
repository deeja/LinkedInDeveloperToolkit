using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using FunctionalTests;
using LinkedIn;
using LinkedIn.ServiceEntities;
using LinkedIn.Utility;

public partial class GetNetworkUpdates : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
  }

  protected void executeButton_Click(object sender, EventArgs e)
  {
    ILinkedInService service = _linkedInService;
    
    try
    {
      Updates updates = null;
      if (scopeCheckBox.Checked)
      {
        updates = service.GetNetworkUpdates(NetworkUpdateTypes.All, Scope.Self);
      }
      else
      {
        updates = service.GetNetworkUpdates(NetworkUpdateTypes.All);
      }

      console.Text = Utilities.SerializeToXml<Updates>(updates);
    }
    catch (LinkedInException lie)
    {
      console.Text += lie.Message;
    }
  }
}
