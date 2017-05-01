using System;
using System.Reflection;
using Windows.UI.Xaml;

namespace Stc.AppTemplate.App.UWP.Behaviors
{
    /// <summary>
    /// Base logic for Behavior. Implicitly implement's blend IBehavior interface
    /// </summary>
    /// <typeparam name="T">Type of the object to attach the behavior</typeparam>
    public abstract class BaseBehavior<T> : DependencyObject where T : DependencyObject
    {
        #region AssociatedObject

        protected T AssociatedObjectTyped { get; private set; }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public DependencyObject AssociatedObject => this.AssociatedObjectTyped;

        #endregion

        protected abstract void OnAttached();
        protected abstract void OnDetached();

        /// <summary>
        /// Attaches to the specified object.
        /// </summary>
        /// <param name="dependencyObject">
        /// The object to attach to.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// The Behavior is already hosted on a different element.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// dependencyObject does not satisfy the Behavior type constraint.
        /// </exception>
        public void Attach(DependencyObject dependencyObject)
        {
            if (this.AssociatedObject != null)
            {
                throw new InvalidOperationException("The Behavior is already hosted on a different element.");
            }
            AssociatedObjectTyped = dependencyObject as T;
            if (dependencyObject != null)
            {
                if (!typeof(T).GetTypeInfo().IsAssignableFrom(dependencyObject.GetType().GetTypeInfo()))
                {
                    throw new InvalidOperationException("dependencyObject does not satisfy the Behavior type constraint.");
                }

                OnAttached();
            }
        }

        public void Detach()
        {
            this.OnDetached();
            this.AssociatedObjectTyped = null;
        }
    }
}