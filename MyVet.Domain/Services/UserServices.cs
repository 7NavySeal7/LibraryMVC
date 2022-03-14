using MyVet.Domain.Dto;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Utils.Helpers;
using static Common.Utils.Enums.Enums;
using Common.Utils.RestServices.Interface;
using Microsoft.Extensions.Configuration;
using MyVet.Domain.Dto.RestServices;

namespace MyVet.Domain.Services
{
    public class UserServices : IUserServices
    {
        #region Attribute
        //atributo--Interfaz de solo lectura
        private readonly IRestService _restService;
        private readonly IConfiguration _config;
        #endregion

        #region Builder
        //El constructor recibe la instacia de RestService por medio de la interfaz
        public UserServices(IRestService restService, IConfiguration config)
        {
            _restService = restService; //Le pasamos el valor de esa instancia a atributo global.
            _config = config;
        }
        #endregion

        #region Authentication
        public async Task<ResponseDto> Login(UserDto user)
        {
            string urlBase = _config.GetSection("ApiMyLibrary").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyLibrary").GetSection("ControllerAuthentication").Value;
            string method = _config.GetSection("ApiMyLibrary").GetSection("MethodLogin").Value;

            LoginDto parameters = new LoginDto()
            {
                Password = user.Password,
                UserName = user.UserName,
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            ResponseDto resultToken = await _restService.PostRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);

            return resultToken;
        }
        #endregion

        #region Methods Crud
        //public List<UserEntity> GetAll()
        //{
        //    return _unitOfWork.UserRepository.GetAll().ToList();
        //}

        ////Esta función sirve para traerme un usuario especifico
        //public UserEntity GetUser(int idUser)
        //{
        //    return _unitOfWork.UserRepository.FirstOrDefault(x => x.IdUser == idUser);
        //}

        //public async Task<bool> UpdateUser(UserEntity user)
        //{
        //    //Esto sirve para consultar el usuario
        //    UserEntity _user = GetUser(user.IdUser);

        //    _user.Name = user.Name;
        //    _user.LastName = user.LastName;
        //    _unitOfWork.UserRepository.Update(_user);

        //    return await _unitOfWork.Save() > 0;
        //    //return _unitOfWork.UserRepository.FirstOrDefault(x=>x.IdUser == idUser);
        //}

        //public async Task<bool> DeleteUser(int idUser)
        //{
        //    //Con el patron repositorio tenemos un delete
        //    _unitOfWork.UserRepository.Delete(idUser);
        //    //El metodo save proviene de la unidad de trabajo
        //    return await _unitOfWork.Save() > 0;
        //}

        //public async Task<ResponseDto> CreateUser(UserEntity data)
        //{
        //    ResponseDto result = new ResponseDto();

        //    //Esta condicional me devuelve un booleano, según la validación que se realize en utils.
        //    if (Utils.ValidateEmail(data.Email))
        //    {
        //        //Si es igual a nulo significa que no hay nigún otro email.
        //        if (_unitOfWork.UserRepository.FirstOrDefault(x => x.Email == data.Email) == null)
        //        {
        //            int idRol = data.IdUser;
        //            data.Password = "1234";
        //            data.IdUser = 0;
        //            RolUserEntity rolUser = new RolUserEntity()
        //            {
        //                IdRol = idRol,
        //                UserEntity = data
        //            };
        //            _unitOfWork.RolUserRepository.Insert(rolUser);
        //            result.IsSuccess = await _unitOfWork.Save() > 0;
        //        }
        //        else
        //        {
        //            result.Message = "Email ya se encuentra registrado, utilizar otro!";
        //        }
        //    }
        //    else
        //    {
        //        result.Message = "Usuario con Email inválido";
        //    }
        //    // _unitOfWork.UserRepository.Update(_user);
        //    return result;
        //    //return _unitOfWork.UserRepository.FirstOrDefault(x=>x.IdUser == idUser);
        //}

        //public async Task<ResponseDto> Register(UserDto data)
        //{
        //    ResponseDto result = new ResponseDto();

        //    //Esta condicional me devuelve un booleano, según la validación que se realize en utils.
        //    if (Utils.ValidateEmail(data.UserName))
        //    {
        //        //Si es igual a nulo significa que no hay nigún otro email.
        //        if (_unitOfWork.UserRepository.FirstOrDefault(x => x.Email == data.UserName) == null)
        //        {

        //            RolUserEntity rolUser = new RolUserEntity()
        //            {
        //                IdRol = Rol.Estandar.GetHashCode(),
        //                UserEntity = new UserEntity()
        //                {
        //                    Email = data.UserName,
        //                    LastName = data.LastName,
        //                    Name = data.Name,
        //                    Password = data.Password
        //                }
        //            };

        //            _unitOfWork.RolUserRepository.Insert(rolUser);
        //            result.IsSuccess = await _unitOfWork.Save() > 0;
        //        }
        //        else
        //            result.Message = "Email ya se encuestra registrado, utilizar otro!";
        //    }
        //    else
        //    {
        //        result.Message = "Usuarioc con Email Inválido";
        //    }
        //    return result;
        //}
        #endregion
    }
}