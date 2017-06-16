namespace Krillin.App.ViewModels
{
    using Krillin.App.Models;
    using Krillin.App.Services;
    using Krillin.App.ViewModels.Base;
    using Krillin.App.Views;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class MainViewModel:BaseViewModel
    {
        private readonly IRssService rssService;
        private readonly string url;
        private ICommand selectedItemCommand;
        private Rss rss;


        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel() : this(null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="rss">The RSS.</param>
        public MainViewModel(IRssService rss)
        {
            this.rssService = rss ?? DependencyService.Get<IRssService>();

            this.url = "http://www.devsdna.com/DesktopModules/DNNGo_xBlog/Resource_Ajax.aspx?ModuleId=586&ajaxType=2&TabId=108&PortalId=0&language=en-US&";
            //this.url = "https://blog.xamarin.com/category/developers/feed/";
        }

        /// <summary>
        /// Gets or sets the RSS.
        /// </summary>
        public Rss Rss
        {
            get { return this.rss; }
            set { this.rss = value; OnPropertyChanged(); }
        }

        public ICommand SelectedItemCommand => this.selectedItemCommand;

        /// <summary>
        /// Called when [appearing].
        /// </summary>
        public override async void OnAppearing()
        {
            base.OnAppearing();
            Rss = await this.rssService.GetRssModel(this.url);
        }

        /// <summary>
        /// Creates the command.
        /// </summary>
        public override void CreateCommand()
        {
            base.CreateCommand();
            
            this.selectedItemCommand = new Command<Item>((item) => 
            {
                DetailView view = new DetailView();
                view.ViewModel.TextPost = item.Description;
                view.ViewModel.Title= item.Title;
                Application.Current.MainPage.Navigation.PushModalAsync(view);
            });
        }
    }
}
