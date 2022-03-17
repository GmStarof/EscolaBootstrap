using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppaiEstudeMVC.ViewsModels
{
    public class ProfessorMateriaViewModel
    {
        public IEnumerable<SelectListItem> Materias { get; set; }
        public int MateriasId { get; set; }
        public string NomeProfessor { get; set; }
    }
}