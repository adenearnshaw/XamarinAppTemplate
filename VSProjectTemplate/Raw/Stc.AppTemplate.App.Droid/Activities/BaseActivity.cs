using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using $safeprojectname$.Navigation;
using $safeprojectgroupname$.Core.UILogic.Navigation;

namespace $safeprojectname$.Activities
{
    public abstract class BaseActivity : AppCompatActivity
    {
        private INavigationAware _navigationAwareVm;

        public static BaseActivity CurrentActivity { get; private set; }
        internal string ActivityKey { get; private set; }
        internal static string NextPageKey { get; set; }
        private AppCompatNavigationService Nav =>
            (AppCompatNavigationService)ServiceLocator.Current.GetInstance<INavigationService>();

        protected override void OnStart()
        {
            base.OnStart();

            var navigationParam = Nav.GetAndRemoveParameter(Intent);
            _navigationAwareVm?.OnNavigatedTo(navigationParam);
        }

        protected override void OnResume()
        {
            CurrentActivity = this;

            if (string.IsNullOrEmpty(ActivityKey))
            {
                ActivityKey = NextPageKey;
                NextPageKey = null;
            }

            base.OnResume();
        }

        protected override void OnPause()
        {
            base.OnPause();

            _navigationAwareVm?.OnNavigatedFrom();
        }

        public void SetNavigationContext(INavigationAware navigationAwareVm)
        {
            _navigationAwareVm = navigationAwareVm;
        }

        public static void GoBack()
        {
            CurrentActivity?.OnBackPressed();
        }

        public override bool OnSupportNavigateUp()
        {
            return base.OnSupportNavigateUp();
        }


        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
                this.OnBackPressed();

            return base.OnOptionsItemSelected(item);
        }

        protected void ConfigureSupportToolbar(Toolbar toolbar, int titleHeaderResourceId, bool isBackEnabled)
        {
            SetSupportActionBar(toolbar);
            toolbar.SetTitle(titleHeaderResourceId);

            if (isBackEnabled)
            {
                SupportActionBar.SetDisplayHomeAsUpEnabled(isBackEnabled);
                SupportActionBar.SetHomeButtonEnabled(isBackEnabled);
            }
        }
    }
}