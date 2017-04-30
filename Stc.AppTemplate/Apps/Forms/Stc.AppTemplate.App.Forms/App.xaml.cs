using Stc.AppTemplate.App.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Stc.AppTemplate.App.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
