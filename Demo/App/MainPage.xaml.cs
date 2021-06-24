using Accessibility;
using System;
using Xamarin.Forms;

namespace App
{
    public partial class MainPage : ContentPage
    {
        private readonly IAccessibilityService _accessibilityService;

        public MainPage()
        {
            InitializeComponent();

            _accessibilityService = DependencyService.Get<IAccessibilityService>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _accessibilityService.SetControlType(TestFrame, ControlType.Button);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _accessibilityService.SetFocus(theLabel);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            _accessibilityService.Announcement(AnnounceEntry.Text);
        }
    }
}