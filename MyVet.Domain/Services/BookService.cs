using Common.Utils.RestServices.Interface;
using Microsoft.Extensions.Configuration;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Library;
using MyVet.Domain.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services
{
    public class BookService : IBookService
    {
        #region Atributtes
        private readonly IRestService _restService;
        private readonly IConfiguration _config;
        #endregion

        #region Builder
        public BookService(IRestService restService,IConfiguration config)
        {
            _restService = restService;
            _config = config;
        }
        #endregion

        #region Methods
        public async Task<ResponseDto> GetAllBooks(string token)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControllerAuthentication").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodGetAllBooks").Value;

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.GetRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.IsSuccess)
                response.Result = JsonConvert.DeserializeObject<List<ConsultBookDto>>(response.Result.ToString());

            return response;
        }
        public async Task<ResponseDto> GetAllTypeBook(string token)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControllerBook").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodGetAllTypeBooks").Value;

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.GetRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.IsSuccess)
                response.Result = JsonConvert.DeserializeObject<List<TypeBookDto>>(response.Result.ToString());

            return response;
        }
        public async Task<ResponseDto> GetAllState(string token)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControllerBook").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodGetAllState").Value;

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.GetRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.IsSuccess)
                response.Result = JsonConvert.DeserializeObject<List<StateDto>>(response.Result.ToString());

            return response;
        }
        public async Task<ResponseDto> InsertBooks(InsertBookDto data, string token)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControllerBook").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodInsertBooks").Value;

            InsertBookDto parameters = new InsertBookDto()
            {
                Name = data.Name,
                DateRelease = data.DateRelease,
                Description = data.Description,
                IdEditorial = data.IdEditorial,
                IdAuthor = data.IdAuthor,
                IdTypeBook = data.IdTypeBook,
                IdState = data.IdState
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);
            ResponseDto resultToken = await _restService.PostRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            return resultToken;
        }
        public async Task<ResponseDto> UpdateBooks(BookDto data, string token)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControllerBook").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodUpdateBooks").Value;

            BookDto parameters = new BookDto()
            {
                Name = data.Name,
                DateRelease = data.DateRelease,
                Description = data.Description,
                IdEditorial = data.IdEditorial,
                IdAuthor = data.IdAuthor,
                IdTypeBook = data.IdTypeBook,
                IdState = data.IdState,
                IdBook = data.IdBook,
                IdAuthorBook = data.IdAuthorBook
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);
            ResponseDto resultToken = await _restService.PutRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            return resultToken;
        }
        public async Task<ResponseDto> DeleteBooks(int idBook, string token)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControllerBook").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodDeleteBooks").Value;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("idBook",idBook.ToString());
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);
            ResponseDto resultToken = await _restService.DeleteRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            return resultToken;
        }
        #endregion
    }
}
