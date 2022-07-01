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

        /// <summary>
        /// Kampanya kodu oluştur.
        /// </summary>
        /// <param name="count">Kod adedi</param>
        /// <param name="codeLength">Kod uzunluğu</param>
        /// <returns></returns>
        [HttpGet("GenerateCampaignCode")]
        public IActionResult GenerateCampaignCode(int count = 10, int codeLength = 8)
        {
            GeneralResponseModel<GenerateCampaignCodeResponseModel> responseModel = new()
            {
                Data = new()
            };
            responseModel.Data.Codes = Utils.GenerateCampaignCode(count, codeLength);
            if (responseModel.Data.Codes != null && responseModel.Data.Codes.Count > 0)
            {
                responseModel.IsSuccess = true;
                responseModel.ErrorMessages = null;
                return Ok(responseModel);
            }

            return BadRequest(responseModel);
        }

        /// <summary>
        /// Kod kontrolü 
        /// </summary>
        /// <param name="code">Kod</param>
        /// <returns></returns>
        [HttpGet("CheckCode")]
        public IActionResult CheckCode(string code)
        {
            GeneralResponseModel<string> responseModel = new()
            {
                ErrorMessages = new List<string>() { "The Code is not valid!" }
            };
            if (code.Length > 0)
            {
                responseModel.IsSuccess = Utils.CheckValidCode(code.ToUpper());
                if (responseModel.IsSuccess)
                {
                    responseModel.ErrorMessages = null;
                    responseModel.Data = "The Code is valid.";
                    return Ok(responseModel);
                }
            }

            return BadRequest(responseModel);
        }

        /// <summary>
        /// Dil'e göre haberleri getirir
        /// </summary>
        /// <remarks>
        /// 'Lang' parameter value => 1 : Türkçe , 2: İngilizce
        /// </remarks>
        /// <param name="Lang">Lang (1-> Türkçe , 2-> İngilizce)</param>
        /// <returns></returns>
        [HttpGet("GetNewsByLang")]
        public async Task<IActionResult> GetNewsByLang(int Lang = 1)
        {
            GeneralResponseModel<List<NewsResponseModel>> responseModel = await _newsService.GetAllAsyncByLang(Lang);
            if (responseModel.IsSuccess)
                return Ok(responseModel);

            return BadRequest(responseModel);
        }

        /// <summary>
        /// Haber adına göre detay getir 
        /// </summary>
        /// <remarks>
        /// 'Lang' parameter value => 1 : Türkçe , 2: İngilizce
        /// </remarks>
        /// <param name="Name">Haber Adı</param>
        /// <param name="Lang">Lang (1-> Türkçe , 2-> İngilizce)</param>
        /// <returns></returns>
        [HttpGet("GetNewsByName")]
        public async Task<IActionResult> GetNewsByName(string Name, int Lang = 1)
        {
            GeneralResponseModel<NewsResponseModel> responseModel = new();
            if (string.IsNullOrEmpty(Name))
                responseModel.ErrorMessages = new List<string>() { "Name is required!" };
            else
            {
                responseModel = await _newsService.GetAsyncByName(Name, Lang);
                if (responseModel.IsSuccess)
                    return Ok(responseModel);
            }

            return BadRequest(responseModel);
        }

    }
}
