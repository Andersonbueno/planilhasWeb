using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Planilhas.Models;
using System.Net;
using System.Data.Entity;

namespace Planilhas.Controllers
{
    [Authorize]
    public class PlanilhaController : Controller
    {

        private OurDbContext db = new OurDbContext();
        // GET: Planilha1
        public ActionResult Index()
        {
            diluicao_normal _d = new diluicao_normal();
            _d = db.diluicao_normal.Where(w => w.ID != 0).FirstOrDefault();
            if (_d != null)
            {

                if (_d.prazo == 0)
                {
                    _d.prazo = 1;
                }
                _d.bem_taxa_no_plano = ((_d.tx_adm_total + _d.fdo_reserva) / 100) + 1;
                _d.vlr_bem_mais_tax = (_d.vlr_bem * _d.bem_taxa_no_plano);
                _d.taxa_real = ((_d.fdo_reserva + 7) / 100) + 1;
                _d.valor_real = _d.vlr_bem * _d.taxa_real;
                _d.vlr_parce_sem_seguro = _d.valor_real / _d.prazo;
                _d.vlr_seguro = ((_d.vlr_bem * _d.bem_taxa_no_plano) * _d.seguro_percent) / 100;
                _d.parc_sem_ad_dilu = _d.vlr_parce_sem_seguro + _d.vlr_seguro;
                _d.parc_inicial = (((_d.vlr_parce_sem_seguro) / _d.bem_taxa_no_plano) / _d.vlr_bem);
                _d.parcelas_restantes = ((_d.vlr_parce_sem_seguro / _d.bem_taxa_no_plano) / _d.vlr_bem);

                if ((31 * _d.parcelas_restantes) + (_d.parc_inicial * 5) > 0)
                {
                    _d.totalizando = (31 * _d.parcelas_restantes) + (_d.parc_inicial * 5);
                }
                else
                {
                    _d.totalizando = 0;
                }

                _d.vlr_parc_mensal_parc_restantes = _d.vlr_parce_sem_seguro + _d.vlr_seguro;
                _d.vlr_parc_mensal_iniciais = _d.vlr_parc_mensal_parc_restantes;
                _d.vlr_parcela_inicial_mais_adesao = _d.vlr_parc_mensal_iniciais;
                _d.valor_adm = (_d.vlr_bem * _d.tx_adm_total) / 100;
                _d.f_res = (_d.vlr_bem * _d.fdo_reserva) / 100;
                _d.resumo_seguro = _d.vlr_seguro * _d.prazo;
                _d.resumo_total = _d.vlr_bem + _d.valor_adm + _d.f_res + _d.resumo_seguro;
                

                _d.ad_a_vista = _d.ad_a_vista;

                _d.parc_inicial = _d.vlr_parc_mensal_iniciais;
                _d.parcelas_restantes = _d.vlr_parce_sem_seguro + _d.vlr_seguro;



                _d.ad_a_vista_valor2 = _d.ad_a_vista_valor1 * _d.ad_a_vista;
                _d.parc_ini_valor2 = _d.parc_ini_valor1 * _d.parc_inicial;
                _d.parcelas_restantes_valor2 = _d.vlr_parc_mensal_parc_restantes * _d.parcelas_restantes_valor1;
                _d.total_quadro = _d.ad_a_vista_valor2 + _d.parc_ini_valor2 + _d.parcelas_restantes_valor2;

                _d.lance_valor = _d.vlr_bem * _d.lance / 100;

                _d.saldo_devedor = _d.total_quadro - _d.parcela_1 - _d.lance_valor;

                _d._qte_meses = _d.prazo - 1;

                if (_d.vlr_parc_mensal_parc_restantes > 0)
                {
                    _d._j38 = (_d.saldo_devedor - _d.vlr_parc_mensal_parc_restantes) / _d.vlr_parc_mensal_parc_restantes;


                }
                else
                {
                    _d._j38 = 0;
                }



                _d._l39 = (_d.total_quadro - _d.lance_valor) / _d.prazo;

                _d.alteracao = DateTime.Now;

                db.Entry(_d).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return View(_d);
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(diluicao_normal _d)
        {

            _d.alteracao = DateTime.Now;

            _d.bem = _d.vlr_bem;

            db.Entry(_d).State = System.Data.Entity.EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {

            }

            return RedirectToAction("Index");
        }


        //GET CRUD Detalhes
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            diluicao_normal _d = db.diluicao_normal.Find(id);
            if (_d == null)
            {
                return HttpNotFound();
            }
            return View(_d);
        }

        // GET: /CRUD/Criar  

        public ActionResult Create()
        {
            return View();
        }

        // POST: /CRUD/Criar  

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(diluicao_normal _d)
        {
            if (ModelState.IsValid)
            {
                db.diluicao_normal.Add(_d);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(_d);
        }

        //GET: /CRUD/ EDITAR

        public ActionResult Edit(string id = null)
        {
            diluicao_normal _d = db.diluicao_normal.Find(id);
            if (_d == null)
            {
                return HttpNotFound();
            }
            return View(_d);
        }

        //POST: /CRUD/ EDITAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(diluicao_normal _d)
        {
            if (ModelState.IsValid)
            {
                db.Entry(_d).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_d);
        }

        //GET: /CRUD/ DELETAR
        public ActionResult Delete(string id = null)
        {
            diluicao_normal _d = db.diluicao_normal.Find(id);
            if (_d == null)
            {
                return HttpNotFound();
            }
            return PartialView("~/Views/Planilha/Delete.cshtml");
        }

        //POST: /CRUD/ DELETAR
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            diluicao_normal _d = db.diluicao_normal.Find(id);
            db.diluicao_normal.Remove(_d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}