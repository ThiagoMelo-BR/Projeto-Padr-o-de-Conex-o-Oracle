using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PRJ_MVC_CORE_ORACLE.Models
{
    public class Secao
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }

    }
}
