using System.Collections.Generic;
using Android.Support.V4.App;
using Android.Views;
using GalaSoft.MvvmLight.Helpers;

namespace $safeprojectname$.Fragments
{
    public abstract class BaseFragment : Fragment
    {
        private View _fragmentView;

        protected List<Binding> Bindings = new List<Binding>();
        protected View FragmentView { get { return _fragmentView; } }
        protected LayoutInflater FragmentInflater;

        public override void OnViewCreated(View view, Android.OS.Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            SetupBindings();
        }

        public override void OnDestroy()
        {
            ClearBindings();
            base.OnDestroy();
        }

        protected void SetFragmentView(View view)
        {
            _fragmentView = view;
        }

        protected virtual void SetupBindings()
        { }

        protected virtual void ClearBindings()
        {
            foreach (var binding in Bindings)
            {
                binding.Detach();
            }
            Bindings.Clear();
        }
    }
}