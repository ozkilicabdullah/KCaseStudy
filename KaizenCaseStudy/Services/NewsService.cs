using Dapper;
using KaizenCaseStudy.Model;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace KaizenCaseStudy.Services
{
    public class NewsService : INewsService
    {
        private readonly IConfiguration _configuration;

        public NewsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 'appsettings.json' dosyasında aktif database adını getirir
        /// </summary>
        /// <returns></returns>
        private string GetDbName()
        {
            return _configuration.GetValue<string>("DatabaseName");
        }
       
        /// <summary>
        /// Get News Bay Name
        /// </summary>
        /// <param name="Name">News name</param>
        /// <param name="lang"> lang -> 1: Turkish , 2: English</param>
        /// <returns></returns>
        public async Task<GeneralResponseModel<NewsResponseModel>> GetAsyncByName(string Name, int lang = 1)
        {
            var responseModel = new GeneralResponseModel<NewsResponseModel>();
            try
            {
                string query = " EXEC [dbo].[GetNewsByName] @Name,@lang";
                var parameters = new DynamicParameters();
                parameters.Add("@Name", dbType: System.Data.DbType.String, value: Name, direction: ParameterDirection.Input);
                parameters.Add("@lang", dbType: System.Data.DbType.Int32, value: lang, direction: ParameterDirection.Input);
                using (var connection = new SqlConnection(_configuration.GetConnectionString(GetDbName())))
                {
                    var response = await connection.QueryAsync<NewsResponseModel>(query, parameters);
                    if (response.Count() > 0)
                    {
                        responseModel.Data = response.FirstOrDefault();
                        responseModel.IsSuccess = true;
                        responseModel.ErrorMessages = null;
                    }
                }
            }
            catch (System.Exception ex)
            {

                throw;
            }
            return responseModel;
        }
       
        /// <summary>
        /// Get All News By Lang
        /// </summary>
        /// <param name="lang"> lang -> 1: Turkish , 2: English</param>
        /// <returns></returns>
        public async Task<GeneralResponseModel<List<NewsResponseModel>>> GetAllAsyncByLang(int lang = 1)
        {
            var responseModel = new GeneralResponseModel<List<NewsResponseModel>>();
            try
            {
                string query = " EXEC [dbo].[GetNewsByLang] @lang";
                var parameters = new DynamicParameters();
                parameters.Add("@lang", dbType: System.Data.DbType.Int32, value: lang, direction: ParameterDirection.Input);
                using (var connection = new SqlConnection(_configuration.GetConnectionString(GetDbName())))
                {
                    var response = await connection.QueryAsync<NewsResponseModel>(query, parameters);
                    if (response.Count() > 0)
                    {
                        responseModel.Data = response.ToList();
                        responseModel.IsSuccess = true;
                        responseModel.ErrorMessages = null;
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
            return responseModel;
        }
    }
}
