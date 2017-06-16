namespace Krillin.App.ViewModels.Base
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool isLoading;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        protected BaseViewModel()
        {
            CreateCommand();
        }


        public bool IsLoading
        {
            get { return this.isLoading; }
            set { this.isLoading = value; OnPropertyChanged(); }
        }


        /// <summary>
        /// Called when [appearing].
        /// </summary>
        public virtual void OnAppearing() { }
        /// <summary>
        /// Called when [disappearing].
        /// </summary>
        public virtual void OnDisappearing() { }
        /// <summary>
        /// Called when [back button pressed].
        /// </summary>
        public virtual void OnBackButtonPressed() { }

        /// <summary>
        /// Creates the command.
        /// </summary>
        public virtual void CreateCommand() { }


        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void ClearBindingContext()
        {
            
        }
    }
}