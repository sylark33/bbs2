using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bbsBLL;

namespace bbs2.Controllers
{
    public class UserController : Controller
    {
        UserService userService = new UserService();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        //处理登陆请求 
        public ActionResult DoLogin(string uname, string upwd)
        {
            //调用service层的处理登陆请求的方法
            if (userService.DoLogin(uname,upwd))
            {
                //把用户名传到主页
                //ViewBag.Uname = uname;
                Session.Remove("Uname");
                Session["Uname"]= uname;
                return View("Main");
            }
            else
            {
                ViewBag.Msg = "用户名或密码错误";
                return View("Index");
            }
        }
    }
}