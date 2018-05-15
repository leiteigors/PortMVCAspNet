using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PortMVCAspNet.Models
{ 
    public class contexto: DbContext 
    {
        public DbSet<PessoaViewModels> PessoaViewModels { get; set; }
    }
}