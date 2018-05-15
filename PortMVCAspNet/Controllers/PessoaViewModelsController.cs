using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PortMVCAspNet.Models;

namespace PortMVCAspNet.Controllers
{
    public class PessoaViewModelsController : Controller
    {
        private contexto db = new contexto();

        // GET: PessoaViewModels
        public ActionResult Index()
        {
            return View(db.PessoaViewModels.ToList());
        }

        // GET: PessoaViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaViewModels pessoaViewModels = db.PessoaViewModels.Find(id);
            if (pessoaViewModels == null)
            {
                return HttpNotFound();
            }
            return View(pessoaViewModels);
        }

        // GET: PessoaViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PessoaViewModels/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,nome,email")] PessoaViewModels pessoaViewModels)
        {
            if (ModelState.IsValid)
            {
                db.PessoaViewModels.Add(pessoaViewModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pessoaViewModels);
        }

        // GET: PessoaViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaViewModels pessoaViewModels = db.PessoaViewModels.Find(id);
            if (pessoaViewModels == null)
            {
                return HttpNotFound();
            }
            return View(pessoaViewModels);
        }

        // POST: PessoaViewModels/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nome,email")] PessoaViewModels pessoaViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoaViewModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoaViewModels);
        }

        // GET: PessoaViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PessoaViewModels pessoaViewModels = db.PessoaViewModels.Find(id);
            if (pessoaViewModels == null)
            {
                return HttpNotFound();
            }
            return View(pessoaViewModels);
        }

        // POST: PessoaViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PessoaViewModels pessoaViewModels = db.PessoaViewModels.Find(id);
            db.PessoaViewModels.Remove(pessoaViewModels);
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
