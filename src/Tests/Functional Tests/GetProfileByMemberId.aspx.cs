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
using System.Xml.Linq;

using LinkedIn;
using LinkedIn.Utility;
using LinkedIn.ServiceEntities;

public partial class GetProfileByMemberId : LinkedInBasePage
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
        ProfileField.Connections,
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
        ProfileField.Industry,
        ProfileField.LastName,
        ProfileField.LocationCountryCode,
        ProfileField.LocationName,
        ProfileField.NumberOfRecommenders,
        ProfileField.PersonId,
        ProfileField.PictureUrl,
        ProfileField.PositionCompanyName,
        ProfileField.PositionEndDate,
        ProfileField.PositionId,
        ProfileField.PositionIsCurrent,
        ProfileField.PositionStartDate,
        ProfileField.PositionSummary,
        ProfileField.PositionTitle,
        ProfileField.PublicProfileUrl,
        ProfileField.SiteStandardProfileRequestUrl,
        ProfileField.Specialties,
        ProfileField.Summary,
        ProfileField.SitePublicProfileRequestUrl,
        ProfileField.ApiPublicProfileRequestUrl
      };

      Person person = service.GetProfileByMemberId(Constants.TestMemberId, fields);

      console.Text += Utilities.SerializeToXml<Person>(person); ;
    }
    catch (LinkedInException lie)
    {
      console.Text += lie.Message;
    }
  }
}
