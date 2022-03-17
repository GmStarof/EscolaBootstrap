using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Appai.API.Models
{
    public class AlunoListadeMateriaViewModel
    {
        public IEnumerable<SelectListItem> Materias { get; set; }
        public int MateriasId { get; set; }
        public int NomeAlunoId { get; set; }
        public double Nota { get; set; }
    }
}