using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Stc.AppTemplate.Common.Events;
using Stc.AppTemplate.Core.UILogic.Navigation;
using Stc.AppTemplate.Core.UILogic.ViewModels;

namespace Stc.AppTemplate.Core.UILogic
{
    public abstract class CoreBootstrapper
    {
        static CoreBootstrapper()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //Common
            SimpleIoc.Default.Register<IEventsManager, EventsManager>();

            //UILogic
            SimpleIoc.Default.Register<IViewService, ViewService>();

            //ViewModels
            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
    }
}