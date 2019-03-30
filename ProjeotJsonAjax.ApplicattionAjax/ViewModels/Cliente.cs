using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjeotJsonAjax.ApplicattionAjax.ViewModels
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Cidade { get; set; }
    }
}