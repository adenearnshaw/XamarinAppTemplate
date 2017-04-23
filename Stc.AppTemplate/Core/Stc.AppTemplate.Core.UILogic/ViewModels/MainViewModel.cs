using Stc.AppTemplate.Core.UILogic.Navigation;

namespace Stc.AppTemplate.Core.UILogic.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IViewService _viewService;

        public MainViewModel(IViewService viewService)
        {
            _viewService = viewService;
        }
    }
}