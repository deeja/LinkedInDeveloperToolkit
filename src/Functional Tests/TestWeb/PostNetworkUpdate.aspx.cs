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
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using LinkedIn;
using LinkedIn.Utility;
using LinkedIn.ServiceEntities;

public partial class PostNetworkUpdate : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    
  }

  protected void sendButton_Click(object sender, EventArgs e)
  {
    LinkedInService service = new LinkedInService(base.Authorization);

    try
    {
      Person currentUser = service.GetCurrentUser(ProfileType.Standard);

      string body = string.Format("{0} {1}", currentUser.Name, bodyTextBox.Text);

      console.Text += service.PostNetworkUpdate("nl-nl", body);
    }
    catch (LinkedInException lie)
    {
      console.Text += lie.Message;
    }
  }
}
