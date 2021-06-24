using Xamarin.Forms;

namespace Accessibility.iOS
{
    public static class Initialise
    {
        public static void Init()
        {
            DependencyService.Register<IAccessibilityService, AccessibilityService_iOS>();
        }
    }
}