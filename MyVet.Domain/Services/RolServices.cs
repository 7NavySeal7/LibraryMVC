using Common.Utils.RestServices.Interface;
using Microsoft.Extensions.Configuration;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyVet.Domain.Services
{
    public class RolServices: IRolServices
    {
        //atributo--Interfaz de solo lectura
        private readonly IRestService _restService;
        private readonly IConfiguration _config;

        //El constructor recibe la instacia de unitOfWork por medio de la interfaz
        public RolServices(IRestService restService, IConfiguration config)
        {
            _restService = restService; //Le pasamos el valor de esa instancia a atributo global.
            _config = config;
        }

        //public async List<RolEntity> GetAll()
        //{
        //    string urlBase = _config.GetSection("ApiMyVet").GetSection("UrlBase").Value;
        //    string controller = _config.GetSection("ApiMyVet").GetSection("ControlerPet").Value;
        //    string method = _config.GetSection("ApiMyVet").GetSection("MethodGetAllMyPets").Value;


        //    Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    Dictionary<string, string> headers = new Dictionary<string, string>();
        //    headers.Add("Token", token);

        //    ResponseDto response = await _restService.GetRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
        //    if (response.IsSuccess)
        //        response.Result = JsonConvert.DeserializeObject<List<PetDto>>(response.Result.ToString());

        //    return response;
        //}
    }
}
