using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Distribuidora.Models
{
    public class Distribuidor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "É necessário preencher o Distribuidor")]
        [Display(Name = "Nome do Distribuidor")]
        public string NomeDistribuidor { get; set; }
        [Required(ErrorMessage = "É necessário preencher o CNPJ")]
        public string CNPJ { get; set; }
        [Required(ErrorMessage = "É necessário preencher o CEP")]
        public string CEP { get; set; }
        [Required(ErrorMessage = "É necessário preencher o Endereço")]
        [Display(Name ="Endereço")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "É necessário preencher o número")]
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public List<Produto> Produtos { get; set; }


    }
}
