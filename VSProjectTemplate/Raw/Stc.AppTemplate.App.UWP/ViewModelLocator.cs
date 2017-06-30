using GalaSoft.MvvmLight.Ioc;
using $safeprojectname$.Navigation;
using $safeprojectgroupname$.Core.UILogic;

namespace $safeprojectname$
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
