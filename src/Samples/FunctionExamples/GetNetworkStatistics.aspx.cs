using System;
using FunctionalTests;
using LinkedIn;
using LinkedIn.ServiceEntities;
using LinkedIn.Utility;


public partial class GetNetworkStatistics : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    ILinkedInService service = _linkedInService;
    
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
