using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Library;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Common.Utils.Constant.Const;

namespace MyVet.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        #region Attributes
        private readonly IBookService _bookService;
        #endregion

        #region Builder
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        #endregion

        #region Controllers
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _bookService.GetAllBooks(token);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTypeBook()
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _bookService.GetAllTypeBook(token);
            return Ok(response);
        }        
        
        [HttpGet]
        public async Task<IActionResult> GetAllState()
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _bookService.GetAllState(token);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertBooks(InsertBookDto book)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _bookService.InsertBooks(book, token);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBooks(BookDto book)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _bookService.UpdateBooks(book, token);
            return Ok(response);
        }        
        
        [HttpDelete]
        public async Task<IActionResult> DeleteBooks(int idBook)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _bookService.DeleteBooks(idBook, token);
            return Ok(response);
        }
        #endregion
    }
}
