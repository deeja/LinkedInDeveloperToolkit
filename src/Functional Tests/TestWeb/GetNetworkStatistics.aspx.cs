using System;

using LinkedIn;
using LinkedIn.ServiceEntities;
using LinkedIn.Utility;


public partial class GetNetworkStatistics : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    LinkedInService service = new LinkedInService(base.Authorization);
    
    try
    {
      NetworkStats networkStats = service.GetNetworkStatistics();

      console.Text += Utilities.SerializeToXml<NetworkStats>(networkStats);
    }
    catch (LinkedInException lie)
    {
      console.Text += lie.Message;
    }
  }
}
