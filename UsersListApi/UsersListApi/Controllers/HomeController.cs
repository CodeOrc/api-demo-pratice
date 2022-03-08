using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersListApi.Application;
using UsersListApi.Models;

namespace UsersListApi.Controllers
{
    [ApiController]
    [Route("[action]")] 
    public class HomeController : Controller
    {
        
        private readonly IReadtxt _Readtxt;
        public HomeController(IReadtxt Readtxt)
        {
            _Readtxt = Readtxt;
        }


        [HttpGet]
        public GetAllUsersFromTxtResponse GetAllUsersFromTxt()
        {
            return _Readtxt.GetAllUsers();
        }
        [HttpGet]
        public GetUserByIdFromTxtResponse GetUserByIdFromTxt(string UserID)
        {
            return _Readtxt.GetUserById(UserID);
        }
        [HttpPost]
        public UpdateUserInTxtResponse UpdateUserInTxt(User user)
        {
            return _Readtxt.UpdateUserData(user);
        }
        [HttpPost]
        public UpdateUserInTxtResponse CreateUserInTxt(User user)
        {
           return _Readtxt.Create(user);
        }
        [HttpPost]
        public UpdateUserInTxtResponse DeleteUserInTxt(string UserID)
        {
            return _Readtxt.Delete(UserID);
        }

    }
}
