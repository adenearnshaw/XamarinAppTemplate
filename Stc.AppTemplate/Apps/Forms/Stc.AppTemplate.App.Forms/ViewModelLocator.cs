using GalaSoft.MvvmLight.Ioc;
using Stc.AppTemplate.App.Forms.Navigation;
using Stc.AppTemplate.Core.UILogic;

namespace Stc.AppTemplate.App.Forms
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
