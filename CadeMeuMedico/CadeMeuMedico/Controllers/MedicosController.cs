using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CadeMeuMedico.Models;
using System.Data;
using System.Data.Entity;

namespace CadeMeuMedico.Controllers
{
    public class MedicosController : Controller
    {
        private EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD();

        // GET: Medicos
        public ActionResult Index()
        {
            var medicos = db.Medico.Include(m => m.Cidade).Include(m => m.Especialidade).ToList();
            return View(medicos);
        }

        //GET: Medicos/Adicionar
        public ActionResult Adicionar()
        {
            ViewBag.IDCidade = new SelectList(db.Cidade, "IDCidade", "Nome");
            ViewBag.IDEspecialidade = new SelectList(db.Especialidade, "IDEspecialidade","Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar([Bind(Include = "CRM,Nome,Endereco,Bairro,Email,AtendePorConvenio,TemClinica,WebsiteBlog,IDCidade,IDEspecialidade")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Medico.Add(medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCidade = new SelectList(db.Cidade, "IDCidade","Nome",medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidade,"IDEspecialidade","Nome",medico.IDEspecialidade);
            return View(medico);
        }

        //GET: Medicos/Editar
        public ActionResult Editar(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = db.Medico.Find(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCidade = new SelectList(db.Cidade, "IDCidade", "Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidade,"IDEspecialidade","Nome", medico.IDEspecialidade);
            return View(medico);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "IDMedico,CRM,Nome,Endereco,Bairro,Email,AtendePorConvenio,TemClinica,WebsiteBlog,IDCidade,IDEspecialidade")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.IDCidade = new SelectList(db.Cidade, "IDCidade","Nome", medico.IDCidade);
            ViewBag.IDEspecialidade = new SelectList(db.Especialidade, "IDEspecialidade", "Nome", medico.IDEspecialidade);
            return View(medico);
        }


        //GET: Medicos/Excluir
        public ActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medicos = db.Medico.Find(id);
            if (medicos == null)
            {
                return HttpNotFound();
            }
            return View(medicos);
        }

        
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medico medicos = db.Medico.Find(id);
            db.Medico.Remove(medicos);
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