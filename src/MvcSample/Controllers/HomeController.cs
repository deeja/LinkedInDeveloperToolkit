using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinkedIn;
using LinkedIn.ServiceEntities;

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
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            if (User.Identity.IsAuthenticated)
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

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
