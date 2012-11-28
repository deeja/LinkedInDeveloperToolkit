using System;
using System.Collections.Generic;
using FunctionalTests;
using LinkedIn;
using LinkedIn.ServiceEntities;
using LinkedIn.Utility;

public partial class InvitePersonByEmailAddress : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    
  }

  protected void sendButton_Click(object sender, EventArgs e)
  {
    ILinkedInService service = _linkedInService;

    try
    {
      List<string> memberIds = new List<string>();
      memberIds.Add(Constants.TestMemberId);

      console.Text += service.InvitePerson(
        emailAddressTextBox.Text, 
        firstNameTextBox.Text, 
        lastNameTextBox.Text, 
        subjectTextBox.Text, 
        bodyTextBox.Text, 
        ConnectionType.Friend);
    }
    catch (LinkedInException lie)
    {
      console.Text += lie.Message;
    }
  }
}
