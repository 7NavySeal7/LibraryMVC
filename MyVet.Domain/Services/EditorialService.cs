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
    public class EditorialService : IEditorialService
    {
        #region Attributes
        private readonly IRestService _restService;
        private readonly IConfiguration _config;
        #endregion

        #region Builder
        public EditorialService(IRestService restService, IConfiguration config)
        {
            _restService = restService;
            _config = config;
        }
        #endregion

        #region Methods
        public async Task<ResponseDto> GetAllEditorial(string token)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControllerEditorial").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodGetAllEditorial").Value;


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.GetRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.IsSuccess)
                response.Result = JsonConvert.DeserializeObject<List<EditorialDto>>(response.Result.ToString());

            return response;
        }

        public async Task<ResponseDto> InsertEditorial(EditorialDto data, string token)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControllerEditorial").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodInsertEditorial").Value;

            EditorialDto parameters = new EditorialDto()
            {
                Editorial = data.Editorial,
                Sede = data.Sede
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);
            ResponseDto resultToken = await _restService.PostRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            return resultToken;
        }

        public async Task<ResponseDto> UpdateEditorial(EditorialDto data, string token)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControllerEditorial").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodUpdateEditorial").Value;

            EditorialDto parameters = new EditorialDto()
            {
                IdEditorial = data.IdEditorial,
                Editorial = data.Editorial,
                Sede = data.Sede
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);
            ResponseDto resultToken = await _restService.PutRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            return resultToken;
        }

        public async Task<ResponseDto> DeleteEditorial(int idEdit, string token)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControllerEditorial").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodDeleteEditorial").Value;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("idEdit", idEdit.ToString());
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);
            ResponseDto resultToken = await _restService.DeleteRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            //resultToken.IsSuccess = true;
            //if (resultToken.IsSuccess)
            //    resultToken.Message = "Se eliminó correctamente la editorial";
            //else
            //    resultToken.Message = "Hubo un error al eliminar el autor, por favor vuelva a intentalo";
            return resultToken;
        }
        #endregion
    }
}
