using System;

using LinkedIn;
using LinkedIn.ServiceEntities;
using LinkedIn.Utility;

public partial class DeleteStatus : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    LinkedInService service = new LinkedInService(base.Authorization);
    
    try
    {
      service.CreateShare("",VisibilityCode.Anyone);
    }
    catch (LinkedInException lie)
    {
      console.Text += lie.Message;
    }
  }
}
