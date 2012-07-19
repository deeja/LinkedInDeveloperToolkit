using System;

using LinkedIn;
using LinkedIn.ServiceEntities;
using LinkedIn.Utility;

public partial class GetNetworkUpdatesSHAR : LinkedInBasePage
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
        updates= service.GetNetworkUpdates(NetworkUpdateTypes.SharedItem, 20, 0, DateTime.MinValue, DateTime.MinValue, false, Scope.Self);
      }
      else
      {
        updates = service.GetNetworkUpdates(NetworkUpdateTypes.SharedItem, 20, 0, DateTime.MinValue, DateTime.MinValue, false);
      }

      console.Text = Utilities.SerializeToXml<Updates>(updates);
    }
    catch (LinkedInException lie)
    {
      console.Text += lie.Message;
    }
  }
}
