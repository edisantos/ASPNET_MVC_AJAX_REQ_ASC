using ProjeotJsonAjax.ApplicattionAjax.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjeotJsonAjax.ApplicattionAjax.Contexto
{
    public class ApplicationConnection:DbContext
    {
        public ApplicationConnection()
        :base("ConexaoStr")
        {
                
        }

        public DbSet<Cliente> Cliente { get; set; }
    }
}