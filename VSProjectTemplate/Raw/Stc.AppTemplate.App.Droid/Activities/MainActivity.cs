using Android.App;
using Android.OS;
using $safeprojectname$.Core.UILogic.ViewModels;

namespace $safeprojectname$.Activities
{
    [Activity(Label = "$safeprojectname$",
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

