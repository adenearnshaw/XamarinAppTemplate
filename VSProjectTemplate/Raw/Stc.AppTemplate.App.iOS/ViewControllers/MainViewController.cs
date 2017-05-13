
using System;
using $safeprojectname$.Core.UILogic.ViewModels;

namespace $safeprojectname$.ViewControllers
{
    public partial class MainViewController : BaseViewController
    {
        private MainViewModel Vm => App.Locator.Main;

        public MainViewController(IntPtr handle) : base(handle)
        {
            SetNavigationContext(Vm);
        }
    }
}