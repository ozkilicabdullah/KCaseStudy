using KaizenCaseStudy.Model.ResonseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KaizenCaseStudy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
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
            responseModel.Data = Utils.CheckValidCode(code);
            if (responseModel.Data)
            {
                responseModel.IsSuccess = true;
                responseModel.ErrorMessages = null;
                return Ok(responseModel);
            }

            return BadRequest(responseModel);
        }
    }
}
