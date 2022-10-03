using NewsForDNN.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace NewsForDNN.Services;

public interface INewsApi
{
    Task<NewsModel?> Get(int id);
    Task<List<NewsModel>> GetAll(int take = 20, int skip = 0, int category = -1);
    Task<int> TotalNews(int category = -1, string keywords = "");
    Task<List<NewsModel>> Search(string keywords, int take = 20, int skip = 0);
}
