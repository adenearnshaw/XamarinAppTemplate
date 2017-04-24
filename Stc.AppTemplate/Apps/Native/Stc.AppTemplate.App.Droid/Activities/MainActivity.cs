using Android.App;
using Android.OS;
using Stc.AppTemplate.Core.UILogic.ViewModels;

namespace Stc.AppTemplate.App.Droid.Activities
{
    [Activity(Label = "Stc.AppTemplate.App.Droid",
              MainLauncher = true,
              Icon = "@drawable/icon",
              Theme = "@style/AppTheme")]
    public class MainActivity : BaseActivity
    {
        private MainViewModel Vm => App.Locator.Main;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.Main);
            SetNavigationContext(Vm);
        }
    }
}

