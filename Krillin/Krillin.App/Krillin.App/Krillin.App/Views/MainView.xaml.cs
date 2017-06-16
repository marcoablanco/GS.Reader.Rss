namespace Krillin.App.Views
{
    using Xamarin.Forms;

    /// <seealso cref="Krillin.App.Views.Base.BaseView{Krillin.App.ViewModels.MainViewModel}" />
    public partial class MainView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainView"/> class.
        /// </summary>
        public MainView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.ListPost.ItemSelected += ListPost_ItemSelected;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this.ListPost.ItemSelected -= ListPost_ItemSelected;
        }

        private void ListPost_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            ((ListView)sender).SelectedItem = null;
            ViewModel.SelectedItemCommand?.Execute(e.SelectedItem);
        }
    }
}