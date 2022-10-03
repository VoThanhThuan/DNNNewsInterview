using NewsForDNN.Models;

namespace NewsForDNN.Services;
public interface ICategoriesApi
{
    Task<CategoryModel?> Get(int id);
    Task<List<CategoryModel>> GetAll();
    Task<List<CategoryModel>> Search(string keywords);
}

