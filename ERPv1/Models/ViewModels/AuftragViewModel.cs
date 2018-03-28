using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPv1.Models.ViewModels
{
    public class AuftragViewModel
    {
        public Auftrag Auftrag { get; set; }
        public IEnumerable<Ware> Waren { get; set; }
    }


    public class ExtendedWare : Ware
    {
        public int SelectedAnzahl { get;set; }
    }
}