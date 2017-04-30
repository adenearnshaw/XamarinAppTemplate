using Stc.AppTemplate.App.iOS.ViewControllers;

namespace Stc.AppTemplate.App.iOS
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