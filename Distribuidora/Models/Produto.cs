using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Distribuidora.Models
{
    public class Produto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "É necessário preencher o nome do Produto")]
        [Display(Name = "Nome do Produto")]
        public string NomeProduto { get; set; }
        [Required(ErrorMessage = "É necessário preencher a Quantidade")]
        public string Quantidade { get; set; }
        [Display(Name = "Característica")]
        public string Caracteristica { get; set; }
        [Required(ErrorMessage = "É necessário preencher o Distribuidor")]
        [Display(Name = "Distribuidor")]
        public int DistribuidorId { get; set; }
        public Distribuidor Distribuidor { get; set; }
    }
}
