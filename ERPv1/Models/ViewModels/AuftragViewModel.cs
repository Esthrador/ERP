using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPv1.Models.ViewModels
{
    public class AuftragViewModel
    {
        public Auftrag AuftragToDo { get; set; }
        public List<WareViewModel> Waren { get; set; }
        public List<WareViewModel> SelectedWaren { get;set; }
    }

    public class WareViewModel
    {
        public Ware Ware { get; set; }
        public int Menge { get; set; }
        public Guid LWID {get; set; }
        public string Lager { get; set; }
        public WareViewModel () { }

        public WareViewModel(Ware ware, int menge)
        {
            Ware = ware;
            Menge = menge;
        }
    }
}