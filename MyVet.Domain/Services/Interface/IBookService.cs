using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
    public interface IBookService
    {
        Task<ResponseDto> GetAllBooks(string token);
        Task<ResponseDto> GetAllTypeBook(string token);
        Task<ResponseDto> GetAllState(string token);
        Task<ResponseDto> InsertBooks(InsertBookDto data, string token);
        Task<ResponseDto> UpdateBooks(BookDto data, string token);
        Task<ResponseDto> DeleteBooks(int idBooks, string token);
    }
}
