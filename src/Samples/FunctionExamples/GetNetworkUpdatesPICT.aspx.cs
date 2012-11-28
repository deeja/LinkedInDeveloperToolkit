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

public partial class GetNetworkUpdatesPICT : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    ILinkedInService service = _linkedInService;
    
    try
    {
      Updates updates = service.GetNetworkUpdates(NetworkUpdateTypes.ChangedAPicture, 20, 1, DateTime.MinValue, DateTime.MinValue, false);

      console.Text += Utilities.SerializeToXml<Updates>(updates);
    }
    catch (LinkedInException lie)
    {
      console.Text += lie.Message;
    }
  }
}
