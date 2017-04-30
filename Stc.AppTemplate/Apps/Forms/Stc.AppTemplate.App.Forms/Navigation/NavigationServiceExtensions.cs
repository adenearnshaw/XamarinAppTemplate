using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Stc.AppTemplate.App.Forms.Navigation
{
    public static class NavigationServiceExtensions
    {
        private static ConditionalWeakTable<Page, object> arguments
                = new ConditionalWeakTable<Page, object>();

        public static object GetNavigationArgs(this Page page)
        {
            object argument = null;
            arguments.TryGetValue(page, out argument);

            return argument;
        }

        public static void SetNavigationArgs(this Page page, object args)
            => arguments.Add(page, args);
    }
}