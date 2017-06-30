using GalaSoft.MvvmLight.Ioc;
using $safeprojectname$.Navigation;
using $safeprojectgroupname$.Core.UILogic;

namespace $safeprojectname$
{
    public class ViewModelLocator : CoreBootstrapper
    {
        static ViewModelLocator()
        {
            SimpleIoc.Default.Register(() => NavigationServiceFactory.Get());
        }
    }
}