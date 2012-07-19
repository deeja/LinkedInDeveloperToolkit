using System;

using LinkedIn;
using LinkedIn.ServiceEntities;
using LinkedIn.Utility;

public partial class CreateReShare : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
  }

  protected void sendButton_Click(object sender, EventArgs e)
  {
    LinkedInService service = new LinkedInService(base.Authorization);
    
    try
    {      
      console.Text += service.CreateReShare(commentTextBox.Text, shareIdTextBox.Text, VisibilityCode.ConnectionsOnly);
    }
    catch (LinkedInException lie)
    {
      console.Text += lie.Message;
    }
  }
}
