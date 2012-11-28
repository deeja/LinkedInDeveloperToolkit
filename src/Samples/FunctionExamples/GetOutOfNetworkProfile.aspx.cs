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
using FunctionalTests;
using LinkedIn;
using LinkedIn.Utility;
using LinkedIn.ServiceEntities;

public partial class GetOutOfNetworkProfile : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    ILinkedInService service = _linkedInService;
    
    try
    {
      Uri requestUri = new Uri(Constants.TestApiStandardProfileRequest_Uri);
      HttpHeader httpHeader = new HttpHeader
      {
        Name = Constants.TestApiStandardProfileRequest_HttpHeader_Name,
        Value = Constants.TestApiStandardProfileRequest_HttpHeader_Value
      };

      Person person = service.GetOutOfNetworkProfile(requestUri, new List<HttpHeader> { httpHeader });

      console.Text += Utilities.SerializeToXml<Person>(person);
    }
    catch (LinkedInException lie)
    {
      console.Text += lie.Message;
    }
  }
}
