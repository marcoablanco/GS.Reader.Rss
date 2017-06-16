namespace Krillin.App.Services
{
    using Krillin.App.Models;
    using System.Threading.Tasks;

    public interface IRssService
    {
        /// <summary>
        /// Gets the RSS model.
        /// </summary>
        /// <param name="urlRss">The URL RSS.</param>
        Task<Rss> GetRssModel(string urlRss);
    }
}
