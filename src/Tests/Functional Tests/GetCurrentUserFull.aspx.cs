using System;
using System.Collections.Generic;
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

using LinkedIn;
using LinkedIn.Utility;
using LinkedIn.ServiceEntities;

public partial class GetCurrentUserFull : LinkedInBasePage
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
        ProfileField.Associations,
        ProfileField.Connections,
        ProfileField.CurrentShare,
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
        ProfileField.Honors,
        ProfileField.IMAccounts,
        ProfileField.Industry,
        ProfileField.LastName,
        ProfileField.LocationCountryCode,
        ProfileField.LocationName,
        ProfileField.MainAddress,
        ProfileField.NumberOfConnections,
        ProfileField.NumberOfConnectionsCapped,
        ProfileField.NumberOfRecommenders,
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
        ProfileField.ProposalComments,
        ProfileField.PublicProfileUrl,
        ProfileField.RecommendationId,
        ProfileField.RecommendationRecommendationType,
        ProfileField.RecommendationRecommender,
        ProfileField.RelationToViewerDistance,
        ProfileField.RelationToViewerNumberOfRelatedConnections,
        ProfileField.RelationToViewerRelatedConnections,
        ProfileField.SiteStandardProfileRequestUrl,
        ProfileField.Specialties,
        ProfileField.Summary,
        ProfileField.ThreeCurrentPositions,
        ProfileField.ThreePastPositions,
        ProfileField.TwitterAccounts
      };

      Person person = service.GetCurrentUser(ProfileType.Standard, fields);

      console.Text += Utilities.SerializeToXml<Person>(person); ;
    }
    catch (LinkedInException lie)
    {
      console.Text += lie.Message;
    }
  }
}
