using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Security;

public partial class Register : System.Web.UI.Page
{
  protected void UserNameValidator_ServerValidate(object source, ServerValidateEventArgs args)
  {
    MembershipProvider provider = Membership.Provider;
    if (provider.GetUser(args.Value, true) != null)
    {
      args.IsValid = false;
    }
    else
    {
      args.IsValid = true;
    }
  }
}
