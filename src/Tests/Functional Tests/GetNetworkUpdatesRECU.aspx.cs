using System;

using LinkedIn;
using LinkedIn.ServiceEntities;
using LinkedIn.Utility;

public partial class GetNetworkUpdatesRECU : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
  }

  protected void executeButton_Click(object sender, EventArgs e)
  {
    LinkedInService service = new LinkedInService(base.Authorization);
    
    try
    {
      Updates updates = null;
      if (scopeCheckBox.Checked)
      {
        updates = service.GetNetworkUpdates(NetworkUpdateTypes.Recommendations, 20, 0, new DateTime(2009,1,1), DateTime.MinValue, true, Scope.Self);
      }
      else
      {
        updates = service.GetNetworkUpdates(NetworkUpdateTypes.Recommendations, 20, 0, DateTime.MinValue, DateTime.MinValue, true);
      }

      console.Text += Utilities.SerializeToXml<Updates>(updates);
    }
    catch (LinkedInException lie)
    {
      console.Text += lie.Message;
    }
  }
}
