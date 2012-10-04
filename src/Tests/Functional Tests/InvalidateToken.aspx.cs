using System;
using FunctionalTests;
using LinkedIn;
using LinkedIn.Utility;

public partial class InvalidateToken : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    ILinkedInService service = _linkedInService;
    
    try
    {
      console.Text += service.InvalidateToken();

      Session.RemoveAll();
    }
    catch (LinkedInException lie)
    {
      console.Text += lie.Message;
    }
  }
}
