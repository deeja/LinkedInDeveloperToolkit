

using LinkedIn;

namespace MvcSample
{
    public static class ShouldReallyBeAnIocContainerAndDontUseServiceLocators
    {
        public static ILinkedInService LinkedInService { get; set; }
    }
}