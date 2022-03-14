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
    public class EditorialController : Controller
    {
        #region Atributte
        private readonly IEditorialService _editorialService;
        #endregion

        #region Builder
        public EditorialController(IEditorialService editorialService)
        {
            _editorialService = editorialService;
        }
        #endregion

        #region Controllers
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEditorial()
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _editorialService.GetAllEditorial(token);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> InsertEditorial(EditorialDto book)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _editorialService.InsertEditorial(book, token);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEditorial(EditorialDto book)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _editorialService.UpdateEditorial(book, token);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEditorial(int idEdit)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _editorialService.DeleteEditorial(idEdit, token);
            return Ok(response);
        }

        #endregion
    }
}
