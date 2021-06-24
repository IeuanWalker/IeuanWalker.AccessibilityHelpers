using Xamarin.Forms;

namespace Accessibility
{
    public interface IAccessibilityService
    {
        /// <summary>
        /// Force accessibility focus to specified element
        /// </summary>
        /// <param name="element"></param>
        void SetFocus(VisualElement element);


        /// <summary>
        /// Tell an element to parade around as a different element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="controlType"></param>
        void SetControlType(VisualElement element, ControlType controlType);

        /// <summary>
        /// Announces the accessibility text passed based on the VoiceOver/ TalkBack is enabled.
        /// </summary>
        /// <param name="text"></param>
        void Announcement(string text);

    }

    public enum ControlType
    {
        Default,
        Button
    }
}
