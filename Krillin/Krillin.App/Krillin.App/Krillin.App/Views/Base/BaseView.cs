namespace Krillin.App.Views.Base
{
    using System;
    using Krillin.App.ViewModels.Base;
    using Xamarin.Forms;

    public class BaseView<T> : ContentPage where T : BaseViewModel, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseView{T}"/> class.
        /// </summary>
        public BaseView()
        {
            ViewModel = ViewModel?? Activator.CreateInstance<T>();
        }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        public T ViewModel
        {
            get { return BindingContext as T; }
            set { BindingContext = value; }
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel?.OnAppearing();
        }

        /// <summary>
        /// When overridden, allows the application developer to customize behavior as the <see cref="T:Xamarin.Forms.Page" /> disappears.
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ViewModel?.OnDisappearing();
        }

        /// <summary>
        /// Application developers can override this method to provide behavior when the back button is pressed.
        /// </summary>
        protected override bool OnBackButtonPressed()
        {
            ViewModel?.OnBackButtonPressed();
            return base.OnBackButtonPressed();
        }
    }
}