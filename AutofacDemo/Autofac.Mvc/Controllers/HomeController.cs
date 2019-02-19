using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac.Mvc.ITest;

namespace Autofac.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepositories _userRepositories;
        public HomeController(IUserRepositories userRepositories)//使用构造函数注入
        {
            _userRepositories = userRepositories;
        }

        public ActionResult Index()
        {
            var list = _userRepositories.GetList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}