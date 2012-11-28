using System;
using FunctionalTests;
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
    ILinkedInService service = _linkedInService;
    
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
