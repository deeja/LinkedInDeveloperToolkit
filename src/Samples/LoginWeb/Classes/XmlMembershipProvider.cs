using System;
using System.Web;
using System.Web.Hosting;
using System.Web.Security;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Permissions;
using System.Configuration.Provider;
using System.Xml;

public class XmlMembershipProvider : MembershipProvider
{
  private Dictionary<string, MembershipUser> users;
  private string xmlFileName;

  // MembershipProvider Properties
  public override string ApplicationName
  {
    get { throw new NotImplementedException(Resources.Common.NotImplementedExceptionMessage); }
    set { throw new NotImplementedException(Resources.Common.NotImplementedExceptionMessage); }
  }

  public override bool EnablePasswordRetrieval
  {
    get { return false; }
  }

  public override bool EnablePasswordReset
  {
    get { return false; }
  }

  // MembershipProvider Methods
  public override void Initialize(string name, NameValueCollection config)
  {
    // Verify that config isn't null
    if (config == null)
    {
      throw new ArgumentNullException("config");
    }

    // Assign the provider a default name if it doesn't have one
    if (String.IsNullOrEmpty(name))
    {
      name = "XmlMembershipProvider";
    }

    // Add a default "description" attribute to config if the
    // attribute doesn’t exist or is empty
    if (string.IsNullOrEmpty(config["description"]))
    {
      config.Remove("description");
      config.Add("description", "XML membership provider");
    }

    // Call the base class's Initialize method
    base.Initialize(name, config);

    // Initialize xmlFileName and make sure the path is app-relative
    string path = config["xmlFileName"];

    if (String.IsNullOrEmpty(path))
    {
      path = "~/App_Data/Users.xml";
    }

    if (!VirtualPathUtility.IsAppRelative(path))
    {
      throw new ArgumentException(Resources.Common.XMLFileNameMustBeAppRelative);
    }

    string fullyQualifiedPath = VirtualPathUtility.Combine
        (VirtualPathUtility.AppendTrailingSlash(HttpRuntime.AppDomainAppVirtualPath), path);

    this.xmlFileName = HostingEnvironment.MapPath(fullyQualifiedPath);
    config.Remove("xmlFileName");

    // Make sure we have permission to read the XML data source and
    // throw an exception if we don't
    FileIOPermission permission = new FileIOPermission(FileIOPermissionAccess.Read, this.xmlFileName);
    permission.Demand();

    // Throw an exception if unrecognized attributes remain
    if (config.Count > 0)
    {
      string attr = config.GetKey(0);
      if (!String.IsNullOrEmpty(attr))
      {
        throw new ProviderException(Resources.Common.UnrecognizedAttribute + attr);
      }
    }
  }

  public override bool ValidateUser(string username, string password)
  {
    // Validate input parameters
    if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
    {
      return false;
    }

    try
    {
      // Make sure the data source has been loaded
      ReadMembershipDataStore();

      // Validate the user name and password
      MembershipUser user;
      if (this.users.TryGetValue(username, out user))
      {
        if (user.Comment == password) // Case-sensitive
        {
          // NOTE: A read/write membership provider
          // would update the user's LastLoginDate here.
          // A fully featured provider would also fire
          // an AuditMembershipAuthenticationSuccess
          // Web event
          return true;
        }
      }

      // NOTE: A fully featured membership provider would
      // fire an AuditMembershipAuthenticationFailure
      // Web event here
      return false;
    }
    catch (Exception)
    {
      return false;
    }
  }

  public override MembershipUser GetUser(string username, bool userIsOnline)
  {
    // Note: This implementation ignores userIsOnline

    // Validate input parameters
    if (String.IsNullOrEmpty(username))
    {
      return null;
    }

    // Make sure the data source has been loaded
    ReadMembershipDataStore();

    // Retrieve the user from the data source
    MembershipUser user;
    if (this.users.TryGetValue(username, out user))
    {
      return user;
    }

    return null;
  }

  public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
  {
    // Note: This implementation ignores pageIndex and pageSize,
    // and it doesn't sort the MembershipUser objects returned

    // Make sure the data source has been loaded
    ReadMembershipDataStore();

    MembershipUserCollection users = new MembershipUserCollection();

    foreach (KeyValuePair<string, MembershipUser> pair in users)
    {
      users.Add(pair.Value);
    }

    totalRecords = users.Count;
    return users;
  }

  public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
  {
    status = MembershipCreateStatus.Success;

    MembershipUser user = null;

    try
    {
      XmlDocument xd = new XmlDocument();
      xd.Load(this.xmlFileName);

      //Check to make sure the user doesn't already exist.

      XmlNode node = xd.SelectSingleNode(String.Format("//User/UserName[.  ='{0}']", username));

      if (node != null)
      {
        status = MembershipCreateStatus.DuplicateUserName;
      }
      else
      {
        XmlElement xmlUser = xd.CreateElement("User");
        xd.DocumentElement.AppendChild(xmlUser);

        XmlNode xmlUserName = xd.CreateElement("UserName");
        xmlUserName.InnerText = username;
        xmlUser.AppendChild(xmlUserName);

        XmlNode xmlPassword = xd.CreateElement("Password");
        xmlPassword.InnerText = password;
        xmlUser.AppendChild(xmlPassword);

        XmlNode xmlEmail = xd.CreateElement("email");
        xmlEmail.InnerText = email;
        xmlUser.AppendChild(xmlEmail);

        XmlNode xmlRoles = xd.CreateElement("Roles");
        xmlUser.AppendChild(xmlRoles);

        xd.Save(this.xmlFileName);

        user = GetUser(username, false);
      }
    }
    catch
    {
      status = MembershipCreateStatus.ProviderError;
    }

    return user;
  }

  public override bool DeleteUser(string username, bool deleteAllRelatedData)
  {
    // Note: This implementation ignores deleteAllRelatedData

    bool result = true;

    try
    {
      XmlDocument xd = new XmlDocument();
      xd.Load(this.xmlFileName);

      //Check to make sure the user exists.
      XmlNode node = xd.SelectSingleNode(String.Format("//User/UserName[.  ='{0}']", username));

      if (node != null)
      {
        node.ParentNode.RemoveChild(node);
        xd.Save(this.xmlFileName);
      }
    }
    catch
    {
      result = false;
    }

    return result;
  }

  public override bool RequiresQuestionAndAnswer
  {
    get { return false; }
  }

  #region Not implemented methods
  public override int MaxInvalidPasswordAttempts
  {
    get { throw new NotImplementedException(Resources.Common.NotImplementedExceptionMessage); }
  }

  public override int MinRequiredNonAlphanumericCharacters
  {
    get { throw new NotImplementedException(Resources.Common.NotImplementedExceptionMessage); }
  }

  public override int MinRequiredPasswordLength
  {
    get { throw new NotImplementedException(Resources.Common.NotImplementedExceptionMessage); }
  }

  public override int PasswordAttemptWindow
  {
    get { throw new NotImplementedException(Resources.Common.NotImplementedExceptionMessage); }
  }

  public override MembershipPasswordFormat PasswordFormat
  {
    get { throw new NotImplementedException(Resources.Common.NotImplementedExceptionMessage); }
  }

  public override string PasswordStrengthRegularExpression
  {
    get { throw new NotImplementedException(Resources.Common.NotImplementedExceptionMessage); }
  }

  public override bool RequiresUniqueEmail
  {
    get { throw new NotImplementedException(Resources.Common.NotImplementedExceptionMessage); }
  }

  public override int GetNumberOfUsersOnline()
  {
    throw new NotImplementedException(Resources.Common.NotImplementedExceptionMessage);
  }

  public override bool ChangePassword(string username, string oldPassword, string newPassword)
  {
    throw new NotImplementedException(Resources.Common.NotImplementedExceptionMessage);
  }

  public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
  {
    throw new NotImplementedException(Resources.Common.NotImplementedExceptionMessage);
  }

  public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
  {
    throw new NotImplementedException(Resources.Common.NotImplementedExceptionMessage);
  }

  public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
  {
    throw new NotImplementedException(Resources.Common.NotImplementedExceptionMessage);
  }

  public override string GetPassword(string username, string answer)
  {
    throw new NotImplementedException(Resources.Common.NotImplementedExceptionMessage);
  }

  public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
  {
    throw new NotImplementedException(Resources.Common.NotImplementedExceptionMessage);
  }

  public override string GetUserNameByEmail(string email)
  {
    throw new NotImplementedException(Resources.Common.NotImplementedExceptionMessage);
  }

  public override string ResetPassword(string username, string answer)
  {
    throw new NotImplementedException(Resources.Common.NotImplementedExceptionMessage);
  }

  public override bool UnlockUser(string userName)
  {
    throw new NotImplementedException(Resources.Common.NotImplementedExceptionMessage);
  }

  public override void UpdateUser(MembershipUser user)
  {
    throw new NotImplementedException(Resources.Common.NotImplementedExceptionMessage);
  }
  #endregion

  #region Helpers
  private void ReadMembershipDataStore()
  {
    lock (this)
    {
      this.users = new Dictionary<string, MembershipUser>(16, StringComparer.InvariantCultureIgnoreCase);
      XmlDocument doc = new XmlDocument();
      doc.Load(this.xmlFileName);
      XmlNodeList nodes = doc.GetElementsByTagName("User");

      foreach (XmlNode node in nodes)
      {
        MembershipUser user = new MembershipUser(
            Name,                       // Provider name
            node["UserName"].InnerText, // Username
            null,                       // providerUserKey
            node["email"].InnerText,    // Email
            String.Empty,               // passwordQuestion
            node["Password"].InnerText, // Comment
            true,                       // isApproved
            false,                      // isLockedOut
            DateTime.Now,               // creationDate
            DateTime.Now,               // lastLoginDate
            DateTime.Now,               // lastActivityDate
            DateTime.Now,               // lastPasswordChangedDate
            new DateTime(1980, 1, 1)    // lastLockoutDate
        );

        this.users.Add(user.UserName, user);
      }
    }
  }
  #endregion
}
