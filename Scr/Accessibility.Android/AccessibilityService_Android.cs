using Accessibility.Droid;
using Android.Content;
using Android.Views.Accessibility;
using Xamarin.Forms;

[assembly: Dependency(typeof(AccessibilityService_Android))]
namespace Accessibility.Droid
{
    public class AccessibilityService_Android : IAccessibilityService
    {
        public void SetFocus(VisualElement element)
        {
            var view = element.GetViewForAccessibility();
            view?.SendAccessibilityEvent((EventTypes)(int)WindowsChange.AccessibilityFocused);
        }

        public void SetControlType(VisualElement element, ControlType controlType)
        {
            var view = element.GetViewForAccessibility();

            if (view == null)
                return;

            if (controlType == ControlType.Default)
                view.SetAccessibilityDelegate(null);
            else
                view.SetAccessibilityDelegate(new MyAccessibilityDelegate(controlType));
        }

        private class MyAccessibilityDelegate : Android.Views.View.AccessibilityDelegate
        {
            private readonly ControlType controlType;

            public MyAccessibilityDelegate(ControlType controlType)
            {
                this.controlType = controlType;
            }

            public override void OnInitializeAccessibilityNodeInfo(Android.Views.View host, AccessibilityNodeInfo info)
            {
                base.OnInitializeAccessibilityNodeInfo(host, info);
                switch (controlType)
                {
                    case ControlType.Button:
                        info.ClassName = "android.widget.Button";
                        info.Clickable = true;
                        break;
                }
            }
        }

        public void Announcement(string text)
        {
            AccessabilityAnnouncement(text);
        }
        public void ForcedAnnouncement(string text)
        {
            AccessabilityAnnouncement(text);
        }

        private void AccessabilityAnnouncement(string text)
        {
            if (string.IsNullOrEmpty(text)) return;

            AccessibilityManager manager = Xamarin.Essentials.Platform.AppContext?.GetSystemService(Context.AccessibilityService) as AccessibilityManager;

            if (!(manager.IsEnabled || manager.IsTouchExplorationEnabled))
                return;

            // Sends the accessibility event to announce.
            AccessibilityEvent e = AccessibilityEvent.Obtain();
            e.EventType = EventTypes.Announcement;
            e.Text.Add(new Java.Lang.String(text));
            manager.SendAccessibilityEvent(e);
        }
    }
}