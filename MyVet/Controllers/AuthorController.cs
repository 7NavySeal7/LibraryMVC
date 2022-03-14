using Microsoft.AspNetCore.Mvc;
using MyVet.Domain.Dto;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Common.Utils.Constant.Const;

namespace MyVet.Controllers
{
    public class AuthorController : Controller
    {
        #region Attribute
        private readonly IAuthorService _authorService;
        #endregion

        #region Builder
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        #endregion


        #region Controllers
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _authorService.GetAllAuthors(token);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAuthors(AuthorDto author)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _authorService.InsertAuthors(author, token);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthors(AuthorDto author)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _authorService.UpdateAuthors(author, token);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAuthors(int idAuthor)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _authorService.DeleteAuthors(idAuthor, token);
            return Ok(response);
        }

        #endregion
    }
}
