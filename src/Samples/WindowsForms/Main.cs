using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LinkedIn;
using System.Configuration;
using DotNetOpenAuth.OAuth.ChannelElements;

namespace LinkedIn.Samples.WindowsForms
{
  public partial class Main : Form
  {
    private IConsumerTokenManager tokenManager;
    private DesktopOAuthAuthorization authorization;

    private IConsumerTokenManager TokenManager
    {
      get
      {
        if (this.tokenManager == null)
        {
          string consumerKey = ConfigurationManager.AppSettings["LinkedInConsumerKey"];
          string consumerSecret = ConfigurationManager.AppSettings["LinkedInConsumerSecret"];
          this.tokenManager = new WindowsCredentialStoreTokenManager(consumerKey, consumerSecret);
        }

        return this.tokenManager;
      }
    }

    private DesktopOAuthAuthorization Authorization
    {
      get
      {
        if (this.authorization == null)
        {
          string accessToken = string.Empty; // this can be retrieve from your own storage solution

          this.authorization = new DesktopOAuthAuthorization(TokenManager, accessToken);
          this.authorization.GetVerifier = GetVerifier;
          accessToken = this.authorization.Authorize();

          // Store accessToken for further use
        }

        return this.authorization;
      }
    }

    public Main()
    {
      InitializeComponent();
    }

    private void getConnectionsButton_Click(object sender, EventArgs e)
    {
      try
      {
        LinkedInService service = new LinkedInService(this.Authorization);
        ServiceEntities.Connections connections = service.GetConnectionsForCurrentUser();
        networkUpdatesGridView.DataSource = connections.Items;
      }
      catch (Exception ex)
      {
        MessageBox.Show(string.Format("An error occured ({0}).", ex.Message));
      }    
    }

    private void getNetworkUpdatesButton_Click(object sender, EventArgs e)
    {
      try
      {
        LinkedInService service = new LinkedInService(this.Authorization);
        ServiceEntities.Updates updates = service.GetNetworkUpdates(ServiceEntities.NetworkUpdateTypes.All);
        networkUpdatesGridView.DataSource = updates.Items;
      }
      catch (Exception ex)
      {
        MessageBox.Show(string.Format("An error occured ({0}).", ex.Message));
      }
    }

    private string GetVerifier()
    {
      PinDialog pinDialog = new PinDialog();

      if (pinDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        return pinDialog.Pin;
      }

      return string.Empty;
    }
  }
}
