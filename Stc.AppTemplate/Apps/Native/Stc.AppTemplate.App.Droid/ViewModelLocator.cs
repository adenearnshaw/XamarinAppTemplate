using GalaSoft.MvvmLight.Ioc;
using Stc.AppTemplate.App.Droid.Navigation;
using Stc.AppTemplate.Core.UILogic;

namespace Stc.AppTemplate.App.Droid
{
    public class ViewModelLocator : CoreBootstrapper
    {
        static ViewModelLocator()
        {
            SimpleIoc.Default.Register(() => NavigationServiceFactory.Get());
        }
    }
}