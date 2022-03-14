using Common.Utils.RestServices.Interface;
using Microsoft.Extensions.Configuration;
using MyVet.Domain.Dto;
using MyVet.Domain.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services
{
    public class AuthorService : IAuthorService
    {
        #region Attribute
        private readonly IRestService _restService;
        private readonly IConfiguration _config;
        #endregion

        #region Builder
        public AuthorService(IRestService restService, IConfiguration config)
        {
            _restService = restService;
            _config = config;
        }
        #endregion

        #region Methods
        public async Task<ResponseDto> GetAllAuthors(string token)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControllerAuthor").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodGetAllAuthors").Value;

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.GetRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.IsSuccess)
                response.Result = JsonConvert.DeserializeObject<List<AuthorDto>>(response.Result.ToString());

            return response;
        }
        public async Task<ResponseDto> InsertAuthors(AuthorDto data, string token)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControllerAuthor").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodInsertAuthors").Value;

            AuthorDto parameters = new AuthorDto()
            {
                NameAuthor = data.NameAuthor,
                LastNameAuthor = data.LastNameAuthor
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);
            ResponseDto resultToken = await _restService.PostRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            return resultToken;
        }
        public async Task<ResponseDto> UpdateAuthors(AuthorDto data, string token)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControllerAuthor").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodUpdateAuthors").Value;

            AuthorDto parameters = new AuthorDto()
            {
                IdAuthor = data.IdAuthor,
                NameAuthor= data.NameAuthor,
                LastNameAuthor = data.LastNameAuthor
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);
            ResponseDto resultToken = await _restService.PutRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            return resultToken;
        }
        public async Task<ResponseDto> DeleteAuthors(int idAuthor, string token)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControllerAuthor").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodDeleteAuthors").Value;
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Add("authors", idAuthor);
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);
            ResponseDto resultToken = await _restService.DeleteRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            resultToken.IsSuccess = true;
            if (resultToken.IsSuccess)
                resultToken.Message = "Se eliminó correctamente la editorial";
            else
                resultToken.Message = "Hubo un error al eliminar el autor, por favor vuelva a intentalo";
            return resultToken;
        }

        #endregion
    }
}
