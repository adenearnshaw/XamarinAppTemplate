using GalaSoft.MvvmLight.Ioc;
using $safeprojectname$.Navigation;
using Stc.AppTemplate.Core.UILogic;

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