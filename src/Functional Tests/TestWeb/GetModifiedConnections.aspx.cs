using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml.Serialization;

using LinkedIn;
using LinkedIn.Utility;
using LinkedIn.ServiceEntities;

public partial class GetModifiedConnections : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    LinkedInService service = new LinkedInService(base.Authorization);
    
    try
    {
      List<ProfileField> fields = new List<ProfileField> 
      {
        ProfileField.CurrentShare,
        ProfileField.DateOfBirth,
        ProfileField.FirstName,
        ProfileField.Headline,
        ProfileField.Industry,
        ProfileField.LastName,
        ProfileField.LocationCountryCode,
        ProfileField.LocationName,
        ProfileField.NumberOfConnections,
        ProfileField.NumberOfConnectionsCapped,
        ProfileField.PersonId,
        ProfileField.PictureUrl,
        ProfileField.PublicProfileUrl
      };

      Connections connections = service.GetConnectionsForCurrentUser(fields, Modified.Updated, 1);

      console.Text += Utilities.SerializeToXml<Connections>(connections);
    }
    catch (LinkedInException lie)
    {
      console.Text += lie.Message;
    }
  }
}
