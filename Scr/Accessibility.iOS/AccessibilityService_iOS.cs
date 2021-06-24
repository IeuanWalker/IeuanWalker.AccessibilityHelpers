using Accessibility.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Dependency(typeof(AccessibilityService_iOS))]
namespace Accessibility.iOS
{
    public class AccessibilityService_iOS : IAccessibilityService
    {
        public void SetFocus(VisualElement element)
        {
            var nativeView = Platform.GetRenderer(element).NativeView;
            UIAccessibility.PostNotification(UIAccessibilityPostNotification.LayoutChanged, nativeView);
        }

        public void SetControlType(VisualElement element, ControlType controlType)
        {
            var nativeView = Platform.GetRenderer(element).NativeView;

            switch (controlType)
            {
                case ControlType.Button:
                    nativeView.AccessibilityTraits = UIAccessibilityTrait.Button;
                    break;

                case ControlType.Default:
                    nativeView.AccessibilityTraits = UIAccessibilityTrait.None;
                    break;
            }
        }

        public void Announcement(string text)
        {
            if (string.IsNullOrEmpty(text)) return;

            if (!UIAccessibility.IsVoiceOverRunning)
                return;

            UIAccessibility.PostNotification(UIAccessibilityPostNotification.Announcement, new NSString(text));
        }
    }
}