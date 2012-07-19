using System;

using LinkedIn;
using LinkedIn.Utility;

public partial class InvalidateToken : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    LinkedInService service = new LinkedInService(base.Authorization);
    
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
