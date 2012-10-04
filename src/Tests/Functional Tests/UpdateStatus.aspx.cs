using System;
using FunctionalTests;
using LinkedIn;
using LinkedIn.ServiceEntities;
using LinkedIn.Utility;

public partial class UpdateStatus : LinkedInBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ILinkedInService service = _linkedInService;

        try
        {
            service.CreateShare(console.Text, VisibilityCode.Anyone);
        }
        catch (LinkedInException lie)
        {
            console.Text += lie.Message;
        }
    }
}
