using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Planilhas.Models
{
    public class diluicao_normal

    {
        public int ID { get; set; }

        public int prazo { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public double tx_adm_total { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}%", ApplyFormatInEditMode = true)]
        public double fdo_reserva { get; set; }

        public double seguro_percent { get; set; }

        public double bem_taxa_no_plano { get; set; }

        public double a_vista { get; set; }

        public double vlr_adesao_divido { get; set; }

        public double vlr_adesao_diluido { get; set; }

        public double vlr_bem { get; set; }

        public double vlr_bem_mais_tax { get; set; }

        public double vlr_parce_sem_seguro { get; set; }

        public double vlr_seguro { get; set; }

        public double parc_sem_ad_dilu { get; set; }

        public double per_sobre_5_parcelas_iniciais { get; set; }

        public double per_sobre_31_parcelas_iniciais { get; set; }

        public double totalizando { get; set; }

        public double vlr_parcela_inicial_mais_adesao { get; set; }

        public double vlr_parc_mensal_iniciais { get; set; }

        public double vlr_parc_mensal_parc_restantes { get; set; }

        public double bem { get; set; }
        public double adm { get; set; }

        public double f_res { get; set; }

        public double seguro { get; set; }

        public double ad_a_vista { get; set; }

        public double parc_inicial { get; set; }

        public double parcelas_restantes { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:P2}")]
        public double txt_adm_desc_ad { get; set; }

        public double taxa_real { get; set; }

        public double valor_real { get; set; }

        public double valor_adm { get; set; }

        public double f_residencial { get; set; }

        public double resumo_ad_a_vista { get; set; }
        public double resumo_parc_inicial { get; set; }
        public double resumo_parc_restante { get; set; }

        public double resumo_seguro { get; set; }

        public double resumo_total { get; set; }

        public DateTime alteracao { get; set; }

        public double ad_a_vista_valor1 { get; set; }
        public double ad_a_vista_valor2 { get; set; }
        public double parc_ini_valor1 { get; set; }
        public double parc_ini_valor2 { get; set; }
        public double parcelas_restantes_valor1 { get; set; }
        public double parcelas_restantes_valor2 { get; set; }

        public double total_quadro { get; set; }

        public double parcela_1 { get; set; }
        public double lance { get; set; }

        public double lance_valor { get; set; }

        public double saldo_devedor {get;set;}

        public int _qte_meses { get; set;  }

        public double _j38 { get; set; }

        public double _l39 { get; set;  }



    }

}