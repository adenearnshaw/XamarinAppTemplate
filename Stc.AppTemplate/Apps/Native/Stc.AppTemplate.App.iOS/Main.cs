using UIKit;

namespace Stc.AppTemplate.App.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            App.Init();
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}