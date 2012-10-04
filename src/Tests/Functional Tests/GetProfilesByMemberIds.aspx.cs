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
using LinkedIn.Utility;
using LinkedIn.ServiceEntities;

public partial class GetProfilesByMemberIds : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    ILinkedInService service = _linkedInService;
    
    try
    {
      List<string> memberIds = new List<string>();
      memberIds.Add(Constants.TestMemberId);
      memberIds.Add(Constants.TestMemberId2);

      People people = service.GetProfilesByMemberIds(memberIds);

      console.Text += Utilities.SerializeToXml<People>(people); ;
    }
    catch (LinkedInException lie)
    {
      console.Text += lie.Message;
    }
  }
}
