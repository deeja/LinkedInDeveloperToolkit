//-----------------------------------------------------------------------
// <copyright file="EntitiesConstants.cs" company="Beemway">
//     Copyright (c) Beemway. All rights reserved.
// </copyright>
// <license>
//     Microsoft Public License (Ms-PL http://opensource.org/licenses/ms-pl.html).
//     Contributors may add their own copyright notice above.
// </license>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security;

using LinkedIn.ServiceEntities;

namespace LinkedIn.Tests
{
  /// <summary>
  /// A constants class with entities.
  /// </summary>
  internal static class EntitiesConstants
  {
    public static ApiRequest ApiRequest_One
    {
      get
      {
        Collection<HttpHeader> httpHeaders = new Collection<HttpHeader>();
        httpHeaders.Add(new HttpHeader
        {
          Name = Constants.HttpHeader_Name,
          Value = Constants.HttpHeader_Value
        });

        return new ApiRequest
        {
          Url = Constants.ApiRequest_One_Url,
          Headers = httpHeaders
        };
      }
    }

    public static ApiRequest ApiRequest_Two
    {
      get
      {
        Collection<HttpHeader> httpHeaders = new Collection<HttpHeader>();
        httpHeaders.Add(new HttpHeader
        {
          Name = Constants.HttpHeader_Name,
          Value = Constants.HttpHeader_Value
        });

        return new ApiRequest
        {
          Url = Constants.ApiRequest_Two_Url,
          Headers = httpHeaders
        };
      }
    }

    public static ApiRequest ApiRequest_Three
    {
      get
      {
        Collection<HttpHeader> httpHeaders = new Collection<HttpHeader>();
        httpHeaders.Add(new HttpHeader
        {
          Name = Constants.HttpHeader_Name,
          Value = Constants.HttpHeader_Value
        });

        return new ApiRequest
        {
          Url = Constants.ApiRequest_Three_Url,
          Headers = httpHeaders
        };
      }
    }

    public static Person Person_Simple_One
    {
      get
      {
        Country country = new Country
        {
          Code = Constants.Country_One_Code
        };

        Location location = new Location
        {
          Name = Constants.Location_One_Name,
          Country = country
        };

        Person person = new Person
        {
          Id = Constants.Person_One_Id,
          FirstName = Constants.Person_One_FirstName,
          LastName = Constants.Person_One_LastName,
          Headline = Constants.Person_One_Headline,
          Location = location,
          Industry = Constants.Person_One_Industry,
          ApiStandardProfileRequest = ApiRequest_One,
          SiteStandardProfileUrl = SiteRequest_One,
          PictureUrl = Constants.Person_One_PictureUrl
        };

        return person;
      }
    }

    public static Person Person_Simple_Two
    {
      get
      {
        Country country = new Country
        {
          Code = Constants.Country_Two_Code
        };

        Location location = new Location
        {
          Name = Constants.Location_Two_Name,
          Country = country
        };

        Person person = new Person
        {
          Id = Constants.Person_Two_Id,
          FirstName = Constants.Person_Two_FirstName,
          LastName = Constants.Person_Two_LastName,
          Headline = Constants.Person_Two_Headline,
          Location = location,
          Industry = Constants.Person_Two_Industry,
          ApiStandardProfileRequest = ApiRequest_Two,
          SiteStandardProfileUrl = SiteRequest_Two,
          PictureUrl = Constants.Person_Two_PictureUrl
        };

        return person;
      }
    }

    public static Person Person_Minimal_One
    {
      get
      {
        Person person = new Person
        {
          Id = Constants.Person_One_Id,
          FirstName = Constants.Person_One_FirstName,
          LastName = Constants.Person_One_LastName,
          Headline = Constants.Person_One_Headline,
          ApiStandardProfileRequest = ApiRequest_One,
          SiteStandardProfileUrl = SiteRequest_One
        };

        return person;
      }
    }

    public static Update Update_One
    {
      get
      {
        return new Update
        {
          Timestamp = Constants.Update_One_Timestamp,
          UpdateType = Constants.Update_One_UpdateType,
          UpdateContent = UpdateContent_One,
          IsCommentable = Constants.Update_One_IsCommentable
        };
      }
    }

    public static Update Update_Two
    {
      get
      {
        return new Update
        {
          Timestamp = Constants.Update_Two_Timestamp,
          UpdateType = Constants.Update_Two_UpdateType,
          UpdateContent = UpdateContent_Two,
          IsCommentable = Constants.Update_Two_IsCommentable
        };
      }
    }

    public static Update Update_Three
    {
      get
      {
        return new Update
        {
          Timestamp = Constants.Update_Three_Timestamp,
          UpdateType = Constants.Update_Three_UpdateType,
          UpdateContent = UpdateContent_Three,
          IsCommentable = Constants.Update_Three_IsCommentable
        };
      }
    }

    public static UpdateContent UpdateContent_One
    {
      get
      {
        Connections connections = new Connections();
        connections.Items = new Collection<Person>();
        connections.Items.Add(Person_Minimal_One);

        return new UpdateContent
        {
          Person = new Person
          {
            Id = Constants.Person_One_Id,
            FirstName = Constants.Person_One_FirstName,
            LastName = Constants.Person_One_LastName,
            Headline = Constants.Person_One_Headline,
            Connections = connections,
            ApiStandardProfileRequest = ApiRequest_One,
            SiteStandardProfileUrl = SiteRequest_One,            
          }          
        };
      }
    }

    public static UpdateContent UpdateContent_Two
    {
      get
      {
        return new UpdateContent
        {
          Person = new Person
          {
            Id = Constants.Person_Two_Id,
            FirstName = Constants.Person_Two_FirstName,
            LastName = Constants.Person_Two_LastName,
            Headline = Constants.Person_Two_Headline,
            CurrentStatus = Constants.Person_Two_CurrentStatus,
            ApiStandardProfileRequest = ApiRequest_Two,
            SiteStandardProfileUrl = SiteRequest_Two,
          }
        };
      }
    }

    public static UpdateContent UpdateContent_Three
    {
      get
      {
        Collection<MemberGroup> memberGroups = new Collection<MemberGroup>();
        memberGroups.Add(new MemberGroup
        {
          Id = Constants.MemberGroup_One_Id,
          Name = Constants.MemberGroup_One_Name,
          SiteGroupRequest = SiteGroupRequest_One
        });

        return new UpdateContent
        {
          Person = new Person
          {
            Id = Constants.Person_Three_Id,
            FirstName = Constants.Person_Three_FirstName,
            LastName = Constants.Person_Three_LastName,
            Headline = Constants.Person_Three_Headline,            
            ApiStandardProfileRequest = ApiRequest_Three,
            SiteStandardProfileUrl = SiteRequest_Three,
            MemberGroups = memberGroups
          }
        };
      }
    }

    public static MemberGroup MemberGroup_One
    {
      get
      {
        return new MemberGroup
        {
          Id = Constants.MemberGroup_One_Id,
          Name = Constants.MemberGroup_One_Name,
          SiteGroupRequest = SiteGroupRequest_One
        };
      }
    }

    public static SiteRequest SiteRequest_One
    {
      get
      {
        return new SiteRequest
        {
          Url = Constants.SiteRequest_One_Url
        };
      }
    }

    public static SiteRequest SiteRequest_Two
    {
      get
      {
        return new SiteRequest
        {
          Url = Constants.SiteRequest_Three_Url
        };
      }
    }

    public static SiteRequest SiteRequest_Three
    {
      get
      {
        return new SiteRequest
        {
          Url = Constants.SiteRequest_Three_Url
        };
      }
    }

    public static SiteRequest SiteGroupRequest_One
    {
      get
      {
        return new SiteRequest
        {
          Url = Constants.SiteGroupRequest_One_Url
        };
      }
    }
  }
}
