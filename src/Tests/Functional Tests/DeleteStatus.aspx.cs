using System;
using FunctionalTests;
using LinkedIn;
using LinkedIn.ServiceEntities;
using LinkedIn.Utility;

public partial class DeleteStatus : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    ILinkedInService service = _linkedInService;
    
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
