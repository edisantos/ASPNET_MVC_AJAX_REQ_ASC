using ProjeotJsonAjax.ApplicattionAjax.Contexto;
using ProjeotJsonAjax.ApplicattionAjax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjeotJsonAjax.ApplicattionAjax.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        protected ApplicationConnection db = new ApplicationConnection();
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ListarDados(string Pesquisa ="")
        {

            var result = db.Cliente.AsQueryable();
            if (!string.IsNullOrEmpty(Pesquisa))
                result = result.Where(c => c.Nome.Contains(Pesquisa));
                result = result.OrderBy(c => c.Nome);

            if (Request.IsAjaxRequest())
                return PartialView("_ListarDados", result.ToList());

                return View(result.ToList());
            
           
        }
        public ActionResult GetCurso()
        {
            return View();
        }
        public JsonResult GetCliente()
        {
            var result = db.Cliente.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}