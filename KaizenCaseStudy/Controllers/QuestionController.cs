using KaizenCaseStudy.Model;
using KaizenCaseStudy.Model.ResonseModel;
using KaizenCaseStudy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KaizenCaseStudy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly INewsService _newsService;

        public QuestionController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet("GenerateCampaignCode")]
        public IActionResult GenerateCampaignCode()
        {
            GeneralResponseModel<GenerateCampaignCodeResponseModel> responseModel = new()
            {
                Data = new()
            };
            responseModel.Data.Codes = Utils.GenerateCampaignCode();

            if (responseModel.Data.Codes != null && responseModel.Data.Codes.Count > 0)
            {
                responseModel.IsSuccess = true;
                responseModel.ErrorMessages = null;
                return Ok(responseModel);
            }

            return BadRequest(responseModel);
        }

        [HttpGet("CheckCode")]
        public IActionResult CheckCode(string code)
        {
            GeneralResponseModel<bool> responseModel = new()
            {
                Data = false,
                ErrorMessages = new List<string>() { "Code is not valid!" }
            };
            responseModel.Data = Utils.CheckValidCode(code.ToUpper());
            if (responseModel.Data)
            {
                responseModel.IsSuccess = true;
                responseModel.ErrorMessages = null;
                return Ok(responseModel);
            }

            return BadRequest(responseModel);
        }

        [HttpGet("GetNewsByLang")]
        /// <summary>
        /// İstenilen dildeki haberleri döner
        /// </summary>
        /// <remarks>
        /// 'Lang' parametresi => 1 : Türkçe , 2: İngilizce
        /// </remarks>
        /// <param name="Lang">İstenilen dil (1-> Türkçe , 2-> İngilizce)</param>
        /// <returns></returns>
        public async Task<IActionResult> GetNewsByLang(int Lang)
        {
            GeneralResponseModel<List<NewsResponseModel>> responseModel = new();
            responseModel = await _newsService.GetAllAsyncByLang(Lang);
            if (responseModel.IsSuccess)
                return Ok(responseModel);

            return BadRequest(responseModel);
        }

        [HttpGet("GetNewsByName")]
        /// <summary>
        /// Haber detayını getir
        /// </summary>
        /// <remarks>
        /// 'Lang' parametresi => 1 : Türkçe , 2: İngilizce
        /// </remarks>
        /// <param name="Name">Haberin adı</param>
        /// <param name="Lang">İstenilen dil(1-> Türkçe , 2-> İngilizce)</param>
        /// <returns></returns>
        public async Task<IActionResult> GetNewsByName(string Name, int Lang)
        {
            GeneralResponseModel<NewsResponseModel> responseModel = new();
            responseModel = await _newsService.GetAsyncByName(Name, Lang);
            if (responseModel.IsSuccess)
                return Ok(responseModel);

            return BadRequest(responseModel);
        }

    }
}
