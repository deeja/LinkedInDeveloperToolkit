using System;

using LinkedIn;
using LinkedIn.Utility;

public partial class UpdateStatus : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    LinkedInService service = new LinkedInService(base.Authorization);
    
    try
    {
      service.UpdateStatus(string.Empty);
    }
    catch (LinkedInException lie)
    {
      console.Text += lie.Message;
    }
  }
}
