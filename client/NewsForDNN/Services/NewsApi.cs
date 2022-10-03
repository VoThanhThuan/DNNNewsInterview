using NewsForDNN.Models;
using System.Net;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace NewsForDNN.Services;

public class NewsApi : INewsApi
{
    private readonly HttpClient _http;
    public NewsApi(HttpClient http)
    {
        _http = http;
    }
    public async Task<NewsModel?> Get(int id)
    {
        var response = await _http.GetAsync($"DNNNews/api/News/GetNews?itemId={id}");
        if (response.StatusCode is HttpStatusCode.OK)
        {
            return await response.Content.ReadFromJsonAsync<NewsModel>();
        }
        return null;
    }

    public async Task<List<NewsModel>> GetAll(int take = 20, int skip = 0, int category = -1)
    {
        var response = await _http.GetAsync($"DNNNews/api/News/GetAll?take={take}&skip={skip}&category={category}");
        if (response.StatusCode is HttpStatusCode.OK)
        {
            return await response.Content.ReadFromJsonAsync<List<NewsModel>>();
        }
        return new();
    }

    public async Task<List<NewsModel>> Search(string keywords, int take = 20, int skip = 0)
    {
        var response = await _http.GetAsync($"DNNNews/api/News/Search?keywords={keywords}&take={take}&skip={skip}");
        if (response.StatusCode is HttpStatusCode.OK)
        {
            return await response.Content.ReadFromJsonAsync<List<NewsModel>>();
        }
        return new();

    }

    public async Task<int> TotalNews(int category = -1, string keywords = "")
    {
        var response = await _http.GetAsync($"DNNNews/api/News/TotalNews?category={category}&keywords={keywords}");
        if (response.StatusCode is HttpStatusCode.OK)
        {
            return await response.Content.ReadFromJsonAsync<int>();
        }
        return 1;
    }
}
