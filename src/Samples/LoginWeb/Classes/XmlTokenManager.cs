//-----------------------------------------------------------------------
// <copyright file="XmlTokenManager.cs" company="Beemway">
//     Copyright (c) Beemway. All rights reserved.
// </copyright>
// <license>
//     Microsoft Public License (Ms-PL http://opensource.org/licenses/ms-pl.html).
//     Contributors may add their own copyright notice above.
// </license>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Permissions;
using System.Web;
using System.Web.Hosting;
using System.Xml;

using DotNetOpenAuth.OAuth.ChannelElements;
using DotNetOpenAuth.OAuth.Messages;

public class XmlTokenManager : IConsumerTokenManager
{
  private string xmlFileName = "~/App_Data/TokensAndSecrets.xml";
  private List<TokenxxxSecret> tokensAndSecrets;

  public XmlTokenManager(string consumerKey, string consumerSecret)
  {
    if (String.IsNullOrEmpty(consumerKey))
    {
      throw new ArgumentNullException("consumerKey");
    }

    this.ConsumerKey = consumerKey;
    this.ConsumerSecret = consumerSecret;

    this.Initialize();
  }

  public string ConsumerKey { get; private set; }

  public string ConsumerSecret { get; private set; }

  #region ITokenManager Members
  public string GetTokenSecret(string token)
  {
    TokenxxxSecret tokenAndSecret = this.tokensAndSecrets.Find(delegate(TokenxxxSecret ts)
    {
      return ts.Token.Equals(token, StringComparison.InvariantCultureIgnoreCase);
    });

    return tokenAndSecret != null ? tokenAndSecret.TokenSecret : null;
  }

  public void StoreNewRequestToken(UnauthorizedTokenRequest request, ITokenSecretContainingMessage response)
  {
    this.CreateToken(response.Token, response.TokenSecret, string.Empty);
  }

  public void ExpireRequestTokenAndStoreNewAccessToken(string consumerKey, string requestToken, string accessToken, string accessTokenSecret)
  {
    this.DeleteToken(requestToken);
    this.CreateToken(accessToken, accessTokenSecret, HttpContext.Current.User.Identity.Name);
  }

  /// <summary>
  /// Classifies a token as a request token or an access token.
  /// </summary>
  /// <param name="token">The token to classify.</param>
  /// <returns>Request or Access token, or invalid if the token is not recognized.</returns>
  public TokenType GetTokenType(string token)
  {
    throw new NotImplementedException();
  }
  #endregion

  public string GetTokenByUserName(string userName)
  {
    TokenxxxSecret tokenAndSecret = this.tokensAndSecrets.Find(delegate(TokenxxxSecret ts)
    {
      return ts.UserName.Equals(userName, StringComparison.InvariantCultureIgnoreCase);
    });

    return tokenAndSecret != null ? tokenAndSecret.Token : null;
  }

  private void Initialize()
  {
    string fullyQualifiedPath = VirtualPathUtility.Combine
        (VirtualPathUtility.AppendTrailingSlash
        (HttpRuntime.AppDomainAppVirtualPath), this.xmlFileName);

    this.xmlFileName = HostingEnvironment.MapPath(fullyQualifiedPath);

    // Make sure we have permission to read the XML data source and throw an exception if we don't
    FileIOPermission permission = new FileIOPermission(FileIOPermissionAccess.Write, this.xmlFileName);
    permission.Demand();

    ReadDataStore();
  }

  private void ReadDataStore()
  {
    lock (this)
    {
      if (this.tokensAndSecrets == null)
      {
        this.tokensAndSecrets = new List<TokenxxxSecret>();
        XmlDocument doc = new XmlDocument();
        doc.Load(this.xmlFileName);
        XmlNodeList nodes = doc.GetElementsByTagName("TokenAndSecret");

        foreach (XmlNode node in nodes)
        {
          this.tokensAndSecrets.Add(new TokenxxxSecret
          {
            Token = node["Token"].InnerText,
            TokenSecret = node["TokenSecret"].InnerText,
            UserName = node["UserName"].InnerText
          });
        }
      }
    }
  }

  private void CreateToken(string token, string tokenSecret, string userName)
  {
    XmlDocument doc = new XmlDocument();
    doc.Load(this.xmlFileName);

    XmlNode xmlTokenAndSecretRoot = doc.CreateElement("TokenAndSecret");
    XmlNode xmlToken = doc.CreateElement("Token");
    XmlNode xmlTokenSecret = doc.CreateElement("TokenSecret");
    XmlNode xmlUserName = doc.CreateElement("UserName");
    XmlNode xmlTimestamp = doc.CreateElement("Timestamp");

    xmlToken.InnerText = token;
    xmlTokenSecret.InnerText = tokenSecret;
    xmlUserName.InnerText = userName;
    xmlTimestamp.InnerText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

    xmlTokenAndSecretRoot.AppendChild(xmlToken);
    xmlTokenAndSecretRoot.AppendChild(xmlTokenSecret);
    xmlTokenAndSecretRoot.AppendChild(xmlUserName);
    xmlTokenAndSecretRoot.AppendChild(xmlTimestamp);

    doc.SelectSingleNode("TokensAndSecrets").AppendChild(xmlTokenAndSecretRoot);
    doc.Save(this.xmlFileName);

    this.tokensAndSecrets.Add(new TokenxxxSecret
    {
      Token = token,
      TokenSecret = tokenSecret,
      UserName = userName
    });
  }

  private bool DeleteToken(string token)
  {
    XmlDocument doc = new XmlDocument();
    doc.Load(this.xmlFileName);

    foreach (XmlNode node in doc.GetElementsByTagName("TokenAndSecret"))
    {
      if (node.ChildNodes[0].InnerText.Equals(token, StringComparison.OrdinalIgnoreCase))
      {
        doc.SelectSingleNode("TokensAndSecrets").RemoveChild(node);
        doc.Save(this.xmlFileName);

        this.tokensAndSecrets.Remove(this.tokensAndSecrets.Find(delegate(TokenxxxSecret t)
        {
          return t.Token.Equals(token, StringComparison.InvariantCultureIgnoreCase);
        }));

        return true;
      }
    }

    return false;
  }
}
