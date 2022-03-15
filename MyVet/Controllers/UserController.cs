using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyVet.Domain.Dto;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Common.Utils.Constant.Const;

namespace MyVet.Controllers
{
    //Obliga a que el usuario este logueada para acceder a estas rutas
    [Authorize]
    public class UserController : Controller
    {
        #region Attributes
        private readonly IUserServices _userServices;
        #endregion

        #region Builder
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        #endregion

        #region Controllers
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;

            ResponseDto response = await _userServices.GetAllUsers(token);
            return Ok(response);
        } 
        #endregion

        //[HttpGet]
        //public IActionResult Edit(int? id)
        //{
        //    IActionResult response;

        //    if (id == null)
        //        response = NotFound();

        //    UserEntity user = _userServices.GetUser((int)id);
        //    if (user == null)
        //        response = NotFound();
        //    else
        //        response = View(user);

        //    return response;
        //}
        //

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    //Listado de usuarios
        //    List<UserEntity> users = _userServices.GetAll();
        //    return View(users);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(UserEntity user)
        //{
        //    IActionResult response;

        //    bool result = await _userServices.UpdateUser(user);

        //    if (result)
        //    {
        //        response = RedirectToAction(nameof(Index));
        //    }
        //    else
        //    {
        //        ModelState.AddModelError(string.Empty, "No se pudo Actualizar el Usuario");
        //        response = RedirectToAction(nameof(Index));
        //    }
        //    return response;
        //}

        //[HttpGet]
        //public IActionResult Delete(int? id)
        //{
        //    IActionResult response;

        //    if (id == null)
        //        response = NotFound();

        //    UserEntity user = _userServices.GetUser((int)id);
        //    if (user == null)
        //        response = NotFound();
        //    else
        //        response = View(user);

        //    return response;
        //}

        //[HttpPost]
        //public async Task<IActionResult> ConfirmDelete(int idUser)
        //{
        //    IActionResult response;
        //    if (idUser == 0)
        //    {
        //        response = NotFound();
        //    }
        //    else
        //    {
        //        bool result = await _userServices.DeleteUser(idUser);
        //        if (result)
        //        {
        //            response = RedirectToAction(nameof(Index));
        //        }
        //        else
        //        {
        //            ModelState.AddModelError(string.Empty, "No se pudo eliminar el Usuario");
        //            response = RedirectToAction(nameof(Index));
        //        }
        //    }
        //    return response;
        //}

        //[HttpGet]
        //public IActionResult Create()
        //{
        //    //'Son las sesiones' => El select List me trae los datos en forma de lista
        //    ViewData["Roles"] = new SelectList(_rolServices.GetAll(), "IdRol", "Rol");
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(UserEntity user)
        //{
        //    IActionResult response;

        //    var result = await _userServices.CreateUser(user);

        //    if (result.IsSuccess)
        //    {
        //        response = RedirectToAction(nameof(Index));
        //    }
        //    else
        //    {
        //        ViewData["Roles"] = new SelectList(_rolServices.GetAll(), "IdRol", "Rol");
        //        ModelState.AddModelError(string.Empty, result.Message);
        //        response = View(user);
        //    }
        //    return response;
        //}

    }
}
