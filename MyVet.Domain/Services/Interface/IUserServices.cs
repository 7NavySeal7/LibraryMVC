using MyVet.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
    public interface IUserServices
    {
        #region Methods Crud
        Task<ResponseDto> GetAllUsers(string token);

        //UserEntity GetUser(int idUser);

        //Task<bool> UpdateUser(UserEntity user);

        //Task<bool> DeleteUser(int idUser);

        //Task<ResponseDto> CreateUser(UserEntity user);
        #endregion

        #region Authentication
        Task<ResponseDto> Login(UserDto user);
        //Task<ResponseDto> Register(UserDto data);
        #endregion
    }
}