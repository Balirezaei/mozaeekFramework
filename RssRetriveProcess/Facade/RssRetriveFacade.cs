using System.Linq;
using RssRetriveProcess.Service;

namespace RssRetriveProcess.Facade
{
    public interface IRssRetriveFacade
    {
        void ReadAndFetchData();
    }
    public class RssRetriveFacade : IRssRetriveFacade
    {
        private readonly IRSSManager _rssManager;

        public RssRetriveFacade(IRSSManager rssManager)
        {
            _rssManager = rssManager;
        }

        public void ReadAndFetchData()
        {
            var rssReadyToRead = _rssManager.GetALLRssReadyToRead();
            foreach (var rss in rssReadyToRead)
            {
                var newsReadToSave = new ReadRssFeed().GetNews(rss.Url);

                var processedNews = _rssManager.ReCheckRssResult(newsReadToSave);

                processedNews = processedNews.Select(m =>
                 {
                     m.Source = rss.Source;
                     m.RSSId = rss.Id;
                     return m;
                 }).ToList();

                _rssManager.SaveRssNewsCollection(processedNews);
                _rssManager.UpdateRetriveHistory(rss.Id, processedNews.Count);
                _rssManager.SaveChange();
            }
        }

    }
}