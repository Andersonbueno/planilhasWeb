using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using andersontui.Models;

namespace andersontui.Controllers
{

    public class Planilha1Controller : Controller
    {

        private diluicao_normal_connection db = new diluicao_normal_connection();
        // GET: Planilha1
        public ActionResult Index()
        {
            diluicao_normal _d = new diluicao_normal();
            _d = db.diluicao_normais.Where(w => w.prazo != 0).FirstOrDefault();
            if (_d != null)
            {
                _d.bem_taxa_no_plano = ((_d.tx_adm_total + _d.fdo_reserva) / 100) + 1;
                _d.vlr_bem_mais_tax = (_d.vlr_bem * _d.bem_taxa_no_plano);
                _d.taxa_real = ((_d.fdo_reserva + 7) / 100) + 1;
                _d.valor_real = _d.vlr_bem * _d.taxa_real;
                _d.vlr_parce_sem_seguro = _d.valor_real / _d.prazo;
                _d.vlr_seguro = ((_d.vlr_bem * _d.bem_taxa_no_plano) * _d.seguro_percent) / 100;
                _d.parc_sem_ad_dilu = _d.vlr_parce_sem_seguro + _d.vlr_seguro;
                _d.parc_inicial = (((_d.vlr_parce_sem_seguro) / _d.bem_taxa_no_plano) / _d.vlr_bem);
                _d.parcelas_restantes = ((_d.vlr_parce_sem_seguro / _d.bem_taxa_no_plano) / _d.vlr_bem);
                _d.totalizando = (31 * _d.parcelas_restantes) + (_d.parc_inicial * 5);
                _d.vlr_parc_mensal_parc_restantes = _d.vlr_parce_sem_seguro + _d.vlr_seguro;
                _d.vlr_parc_mensal_iniciais = _d.vlr_parc_mensal_parc_restantes;
                _d.vlr_parcela_inicial_mais_adesao = _d.vlr_parc_mensal_iniciais;
                _d.valor_adm = (_d.vlr_bem * _d.tx_adm_total) / 100;
                _d.f_res = (_d.vlr_bem * _d.fdo_reserva) / 100;
                _d.resumo_seguro = _d.vlr_seguro * _d.prazo;
                                _d.resumo_total = _d.vlr_bem + _d.valor_adm + _d.f_res + _d.resumo_seguro;

                _d.ad_a_vista  = _d.ad_a_vista  ;

                _d.parc_inicial = _d.vlr_parc_mensal_iniciais ;
                //_d.parcelas_restantes = _d.vlr_parce_sem_seguro + _d.vlr_seguro;



                _d.ad_a_vista_valor2 =_d.ad_a_vista_valor1  *_d.ad_a_vista ;
                _d.parc_ini_valor2 =_d.parc_ini_valor1 * _d.parc_inicial     ;
                _d.parcelas_restantes_valor2 =_d.vlr_parc_mensal_parc_restantes * _d.parcelas_restantes_valor1;
                _d.total_quadro = _d.ad_a_vista_valor2 + _d.parc_ini_valor2 + _d.parcelas_restantes_valor2;

                _d.lance_valor = _d.vlr_bem * _d.lance/100;

                _d.saldo_devedor = _d.total_quadro - _d.parcela_1 - _d.lance_valor;

                _d._qte_meses = _d.prazo - 1;

                _d._j38 = (_d.saldo_devedor - _d.vlr_parc_mensal_parc_restantes) / _d.vlr_parc_mensal_parc_restantes;
                _d._l39 = (_d.total_quadro - _d.lance_valor) / _d.prazo;


                return View(_d);
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(diluicao_normal _d)
        {
          

            _d.alteracao = DateTime.Now;

            //if (TryUpdateModel(_d))
            //{
            //  try
            //{
            //    db.SaveChanges();
            //}
            //catch (Exception ex)
            //{

            //}  
            //}

            db.Entry(_d).State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit()
        {


            return View();
        }
    }
}