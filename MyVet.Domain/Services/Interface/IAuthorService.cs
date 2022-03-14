using MyVet.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
    public interface IAuthorService
    {
        Task<ResponseDto> GetAllAuthors(string token);
        Task<ResponseDto> InsertAuthors(AuthorDto data, string token);
        Task<ResponseDto> UpdateAuthors(AuthorDto data, string token);
        Task<ResponseDto> DeleteAuthors(int idAuthor, string token);
    }
}
