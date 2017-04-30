using GalaSoft.MvvmLight.Ioc;
using Stc.AppTemplate.App.iOS.Navigation;
using Stc.AppTemplate.Core.UILogic;

namespace Stc.AppTemplate.App.iOS
{
    public class ViewModelLocator : CoreBootstrapper
    {
        static ViewModelLocator()
        {
            SimpleIoc.Default.Register(() => NavigationServiceFactory.Get());
        }
    }
}