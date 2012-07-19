using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace LinkedIn.Tests.Mocks
{
  public class LinkedInAuthorizationMock : ILinkedInAuthorization
  {
    #region ILinkedInAuthorization Members

    public TimeSpan ReadWriteTimeout
    {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    public TimeSpan Timeout
    {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    public string UserAgent
    {
      get
      {
        throw new NotImplementedException();
      }
      set
      {
        throw new NotImplementedException();
      }
    }

    public HttpWebRequest InitializeGetRequest(Uri requestUrl)
    {
      HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
      webRequest.Method = "GET";
      return webRequest;
    }

    public HttpWebRequest InitializePostRequest(Uri requestUrl)
    {
      HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
      webRequest.Method = "POST";
      return webRequest;
    }

    public HttpWebRequest InitializePutRequest(Uri requestUrl)
    {
      HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
      webRequest.Method = "PUT";
      return webRequest;
    }

    public HttpWebRequest InitializeDeleteRequest(Uri requestUrl)
    {
      HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(requestUrl);
      webRequest.Method = "DELETE";
      return webRequest;
    }

    #endregion
  }
}
