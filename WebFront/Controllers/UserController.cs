using IService;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFront.Controllers
{
    public class UserController : Controller
    {
        IUserService userService = new UserService();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            string sql = "select * from t_users where Name=@Name and Password=@Password";
            var result=userService.GetEntity(sql,new{ Name = fc["Name"], Password = fc["Password"] });
            if (result == null)
            {
                return Content("404 not found");
            }
            else
            {
                return Redirect("/User/Index");
            } 
        }

        [HttpGet]
        public ActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserRegister(FormCollection fc)
        {
            string sql = "insert into t_user(Name,Password,CreateTime,IsDeleted) values(@Name,@Password,@CreateTime,@IsDeleted)";
            User user = new User() { Name = fc["Nam"], Password = fc["Password"],IsDeleted=false,CreateTime=DateTime.Now };
            var result = DapperHelper<User>.Execute(sql,user);
            if (result >= 1)
            {
                return Redirect("/User/Login");
            }
            else
            {
                return Content("fail");
            }
            
        }

        // GET: User
        public ActionResult Index()
        {
            string sql="select * from t_users";
            var list=userService.GetEntities(sql,null);
            return View(list);
        }

        [HttpGet]
        public ActionResult UserAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserAdd(FormCollection fc)
        {
            string sql = "insert into t_users(Name,Password,CreateTime,IsDeleted) values(@Name,@Password,@CreateTime,@IsDeleted)";
            User user = new User() {Name=fc["Name"],Password=fc["Password"],CreateTime=DateTime.Now,IsDeleted=false };
            int result=userService.Execute(sql,user);
            if (result >= 1)
            {
                return Redirect("/User/Index");
            }
            else
            {
                return Content("fail");
            }
        }

        [HttpGet]
        public ActionResult UserUpdate(long Id)
        {
            var sql = "select * from t_users where Id=@Id";
            var user = userService.GetEntity(sql,new {Id=Id });
            return View(user);
        }

        [HttpPost]
        public ActionResult UserUpdate(FormCollection fc)
        {
            string sql = "update t_users set Name=@Name,Password=@Password where Id=@Id";
            User user = new User() {Id=Convert.ToInt64(fc["Id"]),Name=fc["Name"],Password=fc["Password"]};
            int result=userService.Execute(sql,user);
            if (result >= 1)
            {
                return Redirect("/User/Index");
            }
            else
            {
                return Content("fail");
            }
        }

        [HttpGet]
        public ActionResult UserDelete(long Id)
        {
            string sql = "delete from t_users where Id=@Id";
            var user = new User() { Id = Id };
            int result = userService.Execute(sql,user);
            if (result >= 1)
            {
                return Redirect("/User/Index");
            }
            else
            {
                return Content("fail");
            }
        }
    }
}