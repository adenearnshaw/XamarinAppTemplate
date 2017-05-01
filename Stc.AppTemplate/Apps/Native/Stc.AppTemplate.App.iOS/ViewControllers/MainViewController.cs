
using System;
using Stc.AppTemplate.Core.UILogic.ViewModels;

namespace Stc.AppTemplate.App.iOS.ViewControllers
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