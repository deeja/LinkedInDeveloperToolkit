using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.Messaging;
using LinkedIn;
using LinkedIn.ServiceEntities;
using WebMatrix.WebData;

namespace MvcSample.Controllers
{
    public class HomeController : Controller
    {
        public ILinkedInService LinkedInService { get; set; }

        [Obsolete("This is a poor example of accessing the ILinkedInService")]
        public HomeController()
        {
            // You should really set up the IoC for Constructor injection (as per below)
            LinkedInService = ShouldReallyBeAnIocContainerAndDontUseServiceLocators.LinkedInService;
        }

        public HomeController(ILinkedInService linkedInService)
        {
            LinkedInService = linkedInService;
        }

        public ActionResult Index()
        {
            var authenticated = User.Identity.IsAuthenticated;
            ViewBag.Message = authenticated ?  "You are authenticated" : "Please Login";
            ViewBag.Authenticated = authenticated;

            if (authenticated)
            {
                // Example errors are handled below. This "catching" should be moved so it can be used 
                // application wide.
                try
                {
                    var person = LinkedInService.GetCurrentUser(ProfileType.Standard,
                                                                      new List<ProfileField>
                                                                {
                                                                    ProfileField.PersonId,
                                                                    ProfileField.FirstName,
                                                                    ProfileField.LastName,
                                                                    ProfileField.PictureUrl
                                                                });

                    ViewBag.Id = person.Id;
                    ViewBag.Image = person.PictureUrl;
                    ViewBag.Name = person.Name;
                }
                catch (AccessTokenNotFoundException accessTokenNotFound)
                {
                    /* When the IAccessTokenStorage can't find the key */ 
                    FormsAuthentication.SignOut();
                    return RedirectToAction("Index");
                }
                catch (ProtocolException protocolException) 
                {
                    /* When the IOAuthTokenManager can't find the key */ 
                    FormsAuthentication.SignOut();
                    return RedirectToAction("Index");
                }
            }

            return View();
        }
    }
}
