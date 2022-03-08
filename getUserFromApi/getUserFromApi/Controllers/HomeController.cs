using getUserFromApi.Application.IServices;
using getUserFromApi.Models;
using getUserFromApi.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace getUserFromApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConnectUserApi _ConnectUserApi;
        public HomeController(ILogger<HomeController> logger, IConnectUserApi ConnectUserApi)
        {
            _logger = logger;
            _ConnectUserApi = ConnectUserApi;
        }

        public IActionResult Index()
        {
            return View();
        }



        //獲得清單

        public async Task<IActionResult> Userlist()
        {
            GetAllUsersResponse getAllUsersResponse = await _ConnectUserApi.GetAllUser();
            TempData["result"] = getAllUsersResponse.desc;
            return View(getAllUsersResponse.data);
        }

        //新增
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            UpdateUserResponse updateUserResponse = await _ConnectUserApi.Create(user);
            if (updateUserResponse.code == 200) { 
                return RedirectToAction("Userlist"); }
            ViewBag.result = updateUserResponse.desc;
            return View();
        }

        //修改使用者資料

        public async Task<IActionResult> Edituser(string UserID)
        {
            GetUserByIdResponse getUserByIdResponse = await _ConnectUserApi.GetUserById(UserID);
            TempData["result"] = getUserByIdResponse.desc;
            return View(getUserByIdResponse.data);
        }

        [HttpPost]
        public async Task<IActionResult> Edituser(User user)
        {
            UpdateUserResponse updateUserResponse =await _ConnectUserApi.UpdateUserData(user);
            if (updateUserResponse.code == 200) { return RedirectToAction("Userlist"); }
            ViewBag.result = updateUserResponse.desc;
            return View();
        }


      //刪除使用者
      
       
        public async Task<IActionResult> Deleteuser(string UserID)
        {
            UpdateUserResponse updateUserResponse = await _ConnectUserApi.Delete(UserID);
            
            if (updateUserResponse.code == 200)
            {
                return RedirectToAction("Userlist");
            }
            ViewBag.result = updateUserResponse.desc;
            return View();
        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
