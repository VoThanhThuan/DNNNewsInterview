using NewsForDNN.Models;
using System.Net;

namespace NewsForDNN.Services;

public class CategoriesApi : ICategoriesApi
{
    private readonly HttpClient _http;
    public CategoriesApi(HttpClient http)
    {
        _http = http;
    }
    public async Task<CategoryModel?> Get(int id)
    {
        var response = await _http.GetAsync($"DNNNewsCategories/api/NewsCategories/GetCategory?itemId={id}");
        if (response.StatusCode is HttpStatusCode.OK)
        {
            return await response.Content.ReadFromJsonAsync<CategoryModel>();
        }
        return null;

    }

    public async Task<List<CategoryModel>> GetAll()
    {
        var response = await _http.GetAsync($"DNNNewsCategories/api/NewsCategories/GetCategories");
        if (response.StatusCode is HttpStatusCode.OK)
        {
            return await response.Content.ReadFromJsonAsync<List<CategoryModel>>();
        }
        return new();
    }

    public async Task<List<CategoryModel>> Search(string keywords)
    {
        var response = await _http.GetAsync($"DNNNewsCategories/api/NewsCategories/Search?keywords={keywords}");
        if (response.StatusCode is HttpStatusCode.OK)
        {
            return await response.Content.ReadFromJsonAsync<List<CategoryModel>>();
        }
        return new();
    }
}
