using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Accessibility.Droid
{
    public static class Extensions
    {
        public static global::Android.Views.View GetViewForAccessibility(this VisualElement visualElement)
        {
            var renderer = Platform.GetRenderer(visualElement);

            if (visualElement is Layout)
                return renderer?.View;
            else if (renderer is ViewGroup vg && vg.ChildCount > 0)
                return vg.GetChildAt(0);
            else if (renderer != null)
                return renderer.View;

            return null;
        }

        public static global::Android.Views.View GetViewForAccessibility(this VisualElement visualElement, global::Android.Views.View renderer)
        {
            if (renderer == null)
                return visualElement.GetViewForAccessibility();

            if (visualElement is Layout)
                return renderer;
            else if (renderer is ViewGroup vg && vg.ChildCount > 0)
                return vg.GetChildAt(0);

            return renderer;
        }
    }
}