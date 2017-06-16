[assembly: Xamarin.Forms.Dependency(typeof(Krillin.App.Services.Implementations.RssService))]
namespace Krillin.App.Services.Implementations
{
    using Krillin.App.Models;
    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Serialization;

    public class RssService : IRssService
    {
        /// <summary>
        /// Gets the RSS model.
        /// </summary>
        public async Task<Rss> GetRssModel(string urlRss)
        {
            Rss rss;
            Uri uri = new Uri(urlRss, UriKind.Absolute);
            
            using (HttpClient client = new HttpClient())
            {
                using (Stream stream = await client.GetStreamAsync(urlRss))
                {
                    using (XmlReader reader = XmlReader.Create(stream))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Rss));
                        rss = (Rss)serializer.Deserialize(reader);
                    }
                }
            }
            
            return rss;
        }
    }
}
