using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using FunctionalTests;
using LinkedIn;
using LinkedIn.Utility;
using LinkedIn.ServiceEntities;

public partial class CommentOnNetworkUpdate : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
  }

  protected void sendButton_Click(object sender, EventArgs e)
  {
    ILinkedInService service = _linkedInService;
    
    try
    {
      console.Text += service.CommentOnNetworkUpdate(updateKeyTextBox.Text, commentTextBox.Text);
    }
    catch (LinkedInException lie)
    {
      console.Text += lie.Message;
    }
  }
}
