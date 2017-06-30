using $safeprojectname$.Navigation;

namespace $safeprojectname$.ViewModels
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