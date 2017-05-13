using $safeprojectname$.ViewControllers;

namespace $safeprojectname$
{
    public class App
    {
        public static BaseViewController ActiveView { get; set; }

        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator => _locator ?? (_locator = new ViewModelLocator());
        
        public static void Init()
        {
            if (_locator == null)
            {
                _locator = new ViewModelLocator();
            }
        }
    }
}