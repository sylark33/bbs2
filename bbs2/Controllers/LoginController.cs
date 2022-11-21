using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bbs2.Models;
using bbsBLL;

namespace bbs2.Controllers
{
    public class LoginController : Controller
    {
        //数据库上下文链接对象
        private CraftEntities db = new CraftEntities();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        //实现登录功能
        [HttpPost]
        public ActionResult Dologin(string uname, string upwd)
        {
            if (string.IsNullOrEmpty(uname) || string.IsNullOrEmpty(upwd))
            {
                ViewBag.notice = "用户名或密码不能为空";
                return View();
            }

            //去数据库查询是否存在该用户
            player_infos admin = db.player_infos.FirstOrDefault(p => p.uid == uname);
            if (admin == null)
            {
                ViewBag.notice = "用户不存在";
            }
            else if (admin.pwd != upwd)
            {
                ViewBag.notice = "密码错误";
            }
            else
            {
                //在这里需要记住登陆成功的用户信息 Cookie或者是Session =>会话管理（HTTP请求是不会带状态请求的，需要使用COOKIE或者SEIION来标识请求，区分是谁访问服务器）
                //Cookie和Session的区别 Cookie把用户的信息缓存到电脑本地 Session缓存到服务器的电脑，Session存储的安全性更高，安全数据，隐私数据推荐存储到Session
                //额外注意：记住用户自己的账号和密码则是用Cookie，因为用户本身知道这些数据，存储到Session和Cookie没区别
                Session["username"] = admin.uid;
                Session["nickname"] = admin.pwd;
                //登陆成功,跳转到后端的管理界面
                return View("Main");
            }
            return View();
        }

        public ActionResult logout()
        {
            Session["username"] = null;
            Session["nickname"] = null;
            return Redirect("/Login/Index");
        }

        //跳转到创建账号页面
        public ActionResult Register(string vuc)
        {
            return View("Register");
        }

        //实现账号注册
        public ActionResult DoCreate(string uname, string upwd)
        {
            if (string.IsNullOrEmpty(uname) || string.IsNullOrEmpty(upwd))
            {
                ViewBag.Msg = "用户名或密码不能为空";
                return View("Register");
            }

            if (string.Equals(uname, upwd))
            {
                ViewBag.Msg = "用户名和密码不能相同";
                return View("Register");
            }

            player_infos uname1 = db.player_infos.FirstOrDefault(p => p.uid == uname);
            if (uname1 != null)
            {
                ViewBag.Msg  = "用户名已存在";
            }

            return View("Index");
        }
    }
}