using GalaSoft.MvvmLight.Ioc;
using Stc.AppTemplate.App.UWP.Navigation;
using Stc.AppTemplate.Core.UILogic;

namespace Stc.AppTemplate.App.UWP
{
    public class ViewModelLocator : CoreBootstrapper
    {
        static ViewModelLocator()
        {
            var navSvc = NavigationServiceFactory.Get();
            SimpleIoc.Default.Register(() => navSvc);
        }
    }
}
