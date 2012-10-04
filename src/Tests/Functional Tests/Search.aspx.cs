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

public partial class Search : LinkedInBasePage
{
  protected void Page_Load(object sender, EventArgs e)
  {
    ILinkedInService service = _linkedInService;
    
    try
    {
      Collection<ProfileField> fields = new Collection<ProfileField>();
      fields.Add(ProfileField.FirstName);
      fields.Add(ProfileField.LastName);
      fields.Add(ProfileField.Industry);
      fields.Add(ProfileField.MainAddress);
      fields.Add(ProfileField.PositionId);
      fields.Add(ProfileField.PositionTitle);
      fields.Add(ProfileField.PositionCompanyName);
      fields.Add(ProfileField.LocationName);
      fields.Add(ProfileField.LocationCountryCode);
      fields.Add(ProfileField.SiteStandardProfileRequestUrl);
      fields.Add(ProfileField.ApiStandardProfileRequestUrl);
      fields.Add(ProfileField.ApiStandardProfileRequestHeaders);
      fields.Add(ProfileField.ThreeCurrentPositions);

      Collection<FacetField> facetFields = new Collection<FacetField>();
      facetFields.Add(FacetField.Name);
      facetFields.Add(FacetField.Code);
      facetFields.Add(FacetField.BucketName);
      facetFields.Add(FacetField.BucketCode);
      facetFields.Add(FacetField.BucketCount);
      facetFields.Add(FacetField.BucketSelected);

      Dictionary<FacetCode, Collection<string>> facets = new Dictionary<FacetCode, Collection<string>>();
      //facets.Add(FacetCode.CurrentCompany, new Collection<string> { "1970", "1173" });
      //facets.Add(FacetCode.Location, "nl:5665");
      facets.Add(FacetCode.Industry, null);
      facets.Add(FacetCode.Language, null);
      facets.Add(FacetCode.Network, null);
      facets.Add(FacetCode.PastCompany, null);
      facets.Add(FacetCode.School, null);

      PeopleSearch people = service.Search("linkedin",
        Constants.TestMemberName2, 
        string.Empty,
        string.Empty,
        false,
        string.Empty,
        false,
        string.Empty,
        false,
        string.Empty,
        string.Empty,
        -1,
        SortCriteria.Connections,
        1,
        10,
        fields,
        facetFields,
        facets);

      console.Text += Utilities.SerializeToXml<PeopleSearch>(people);
    }
    catch (LinkedInException lie)
    {
      console.Text += lie.Message;
    }
  }
}
