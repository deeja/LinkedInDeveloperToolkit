using System;
using System.Collections;
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
using FunctionalTests;
using LinkedIn;
using LinkedIn.Utility;
using LinkedIn.ServiceEntities;

public partial class Default : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    try
    {
      Person currentUser= _linkedInService.GetCurrentUser(ProfileType.Standard);

      console.Text += currentUser.Name;
    }
    catch (LinkedInException lie)
    {
      console.Text += lie.Message;
    }
  }
}
