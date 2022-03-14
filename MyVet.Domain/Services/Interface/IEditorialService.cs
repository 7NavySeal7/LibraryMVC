using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
    public interface IEditorialService
    {
        Task<ResponseDto> GetAllEditorial(string token);
        Task<ResponseDto> InsertEditorial(EditorialDto data, string token);
        Task<ResponseDto> UpdateEditorial(EditorialDto data, string token);
        Task<ResponseDto> DeleteEditorial(int idEdit, string token);
    }
}
