using ProjeotJsonAjax.ApplicattionAjax.Contexto;
using ProjeotJsonAjax.ApplicattionAjax.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProjeotJsonAjax.ApplicattionAjax.Controllers
{
    public class ConsultaJsonController : Controller
    {
        // GET: ConsultaJson
        protected ApplicationConnection db = new ApplicationConnection();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ListaClienteJson()
        { 

            var result = db.Cliente.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCliente(Cliente cliente)
        {
            return Json(cliente.Nome, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Regiter()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Regiter(Cliente model,string Nome)
        {
            if (!Request.IsAjaxRequest())
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return Content("Desculpe-me este metodo não pode chamar o Ajax.");
            }
            try
            {
                var verificaUsuarioExistente = db.Cliente.Where(p => p.Nome == Nome).FirstOrDefault();
                if (ModelState.IsValid)
                {
                    
                    if (verificaUsuarioExistente != null)
                    {
                        db.Cliente.Add(model);
                        db.SaveChanges();
                        return Content("Registro feito com sucess !");
                    }
                    else
                    {
                        TempData["MsgError"] = "Usuário já existe";
                    }
                }
                else
                {
                    StringBuilder strB = new StringBuilder(500);
                    foreach (ModelState modelState in ModelState.Values)
                    {
                        foreach (ModelError error in modelState.Errors)
                        {
                            strB.Append(error.ErrorMessage + ".");
                        }
                    }
                    Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                    return Content(strB.ToString());
                }
            }
            catch (Exception ex)
            {

                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return Content("Desculpe ocorreu um erro." + ex.Message);
            }
            return View();
        }
    }
}