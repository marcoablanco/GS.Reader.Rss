namespace Krillin.App.ViewModels
{
    using Krillin.App.ViewModels.Base;
    using System.Windows.Input;
    using Xamarin.Forms;


    /// <seealso cref="Krillin.App.ViewModels.Base.BaseViewModel" />
    public class DetailViewModel : BaseViewModel
    {
        private ICommand backCommand;
        private string title;
        private string textPost;

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailViewModel"/> class.
        /// </summary>
        public DetailViewModel()
        {

        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title
        {
            get { return this.title; }
            set { this.title = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Gets or sets the text post.
        /// </summary>
        public string TextPost
        {
            get { return this.textPost; }
            set { this.textPost = value; OnPropertyChanged(); }
        }

        public ICommand BackCommand => this.backCommand;


        public override void CreateCommand()
        {
            base.CreateCommand();
            this.backCommand = new Command(() => Application.Current.MainPage.Navigation.PopModalAsync(true));
        }
    }
}