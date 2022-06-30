using KaizenCaseStudy.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaizenCaseStudy.Services
{
    public interface INewsService
    {
        Task<GeneralResponseModel<List<NewsResponseModel>>> GetAllAsyncByLang(int lang);
        Task<GeneralResponseModel<NewsResponseModel>> GetAsyncByName(string Name, int lang);
    }
}
