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

using LinkedIn;
using LinkedIn.ServiceEntities;
using LinkedIn.Utility;

public partial class GetNetworkUpdatesMultiple : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    LinkedInService service = new LinkedInService(base.Authorization);
    
    try
    {
      // Returns an error
      Updates updates = service.GetNetworkUpdates(NetworkUpdateTypes.ConnectionUpdate | NetworkUpdateTypes.ChangedAPicture, 20, 0, DateTime.Now.AddDays(-1), DateTime.Now);

      console.Text += Utilities.SerializeToXml<Updates>(updates);
    }
    catch (LinkedInException lie)
    {
      console.Text += lie.Message;
    }
  }
}
