using IService;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFront.Controllers
{
    public class NoteController : Controller
    {
        INoteService noteService = new NoteService();
        // GET: Note
        public ActionResult Index()
        {
            string sql = "select * from t_notes";
            var list = noteService.GetEntities(sql,null);
            return View(list);
        }


    }
}