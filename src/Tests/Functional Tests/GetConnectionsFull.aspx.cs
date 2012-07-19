using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Xml.Serialization;

using LinkedIn;
using LinkedIn.Utility;
using LinkedIn.ServiceEntities;

public partial class GetConnectionsFull : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    LinkedInService service = new LinkedInService(base.Authorization);
    
    try
    {
      List<ProfileField> fields = new List<ProfileField> 
      {
        ProfileField.ApiStandardProfileRequestHeaders,
        ProfileField.ApiStandardProfileRequestUrl,
        ProfileField.CurrentStatus,
        ProfileField.CurrentStatusTimestamp,
        ProfileField.DateOfBirth,
        ProfileField.Distance,
        ProfileField.EducationActivities,
        ProfileField.EducationDegree,
        ProfileField.EducationEndDate,
        ProfileField.EducationFieldOfStudy,
        ProfileField.EducationId,
        ProfileField.EducationSchoolName,
        ProfileField.EducationStartDate,
        ProfileField.FirstName,
        ProfileField.Headline,
        ProfileField.IMAccounts,
        ProfileField.Industry,
        ProfileField.LastName,
        ProfileField.LocationCountryCode,
        ProfileField.LocationName,
        ProfileField.MainAddress,
        ProfileField.MemberUrlName,
        ProfileField.MemberUrlUrl,
        ProfileField.NumberOfConnections,
        ProfileField.NumberOfConnectionsCapped,
        ProfileField.PersonId,
        ProfileField.PhoneNumbers,
        ProfileField.PictureUrl,
        ProfileField.PositionCompanyName,
        ProfileField.PositionEndDate,
        ProfileField.PositionId,
        ProfileField.PositionIsCurrent,
        ProfileField.PositionStartDate,
        ProfileField.PositionSummary,
        ProfileField.PositionTitle,
        ProfileField.PublicProfileUrl,
        ProfileField.RecommendationId,
        ProfileField.RecommendationRecommendationType,
        ProfileField.RecommendationRecommender,
        ProfileField.SiteStandardProfileRequestUrl,
        ProfileField.ThreeCurrentPositions,
        ProfileField.ThreePastPositions,
        ProfileField.TwitterAccounts
      };

      Connections connections = service.GetConnectionsForCurrentUser(fields, 1, 2, Modified.New, 12);

      console.Text += Utilities.SerializeToXml<Connections>(connections);
    }
    catch (LinkedInException lie)
    {
      console.Text += lie.Message;
    }
  }
}
