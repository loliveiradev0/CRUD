using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using todo.Dao;
using todo.Models;

namespace todo.Controllers
{
    public class AtividadesController : Controller
    {
        private EFContext db = new EFContext();

       
        public ActionResult Index()
        {
            return View(db.Atividades.ToList());
        }

        [HttpGet]
        [Route("atividade-detalhe/{id:int}")]
        public ActionResult Details(int? id)
        {
            Atividades atividades = db.Atividades.Find(id);
            if (atividades == null)
            {
                return HttpNotFound();
            }
            return View(atividades);
        }

        [HttpGet]
        [Route("nova-atividade")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("nova-atividade")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AtividadeId,Nome,Data,Concluída,Realizando,Fazer")] Atividades atividades)
        {
            if (ModelState.IsValid)
            {
                db.Atividades.Add(atividades);
                db.SaveChanges();
                TempData["Mensagem"] = "Atividade cadastrada com sucesso";
                return RedirectToAction("Index");
              
            }

            return View(atividades);
        }

        [HttpGet]
        [Route("editar-Aatividade/{id:int}")]
        public ActionResult Edit(int? id)
        {
          
            Atividades atividades = db.Atividades.Find(id);
            if (atividades == null)
            {
                return HttpNotFound();
            }
            return View(atividades);
        }

 
        [HttpPost]
        [Route("editar-atividade/{id:int}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AtividadeId,Nome,Data,Concluída,Realizando,Fazer")] Atividades atividades)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atividades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(atividades);
        }

        [HttpGet]
        [Route("excluir-atividade/{id:int}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atividades atividades = db.Atividades.Find(id);
            if (atividades == null)
            {
                return HttpNotFound();
            }
            return View(atividades);
        }

        [HttpPost]
        [Route("excluir-atividade/{id:int}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atividades atividades = db.Atividades.Find(id);
            db.Atividades.Remove(atividades);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
