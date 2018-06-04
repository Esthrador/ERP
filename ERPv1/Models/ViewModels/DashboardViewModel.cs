using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPv1.Models.ViewModels
{
    public class DashboardViewModel
    {
        public List<Auftrag> AuftragListe { get; set; }

        public List<Kunde> KundenListe { get; set; }

        public List<Ware> WarenListe { get; set; }

        public List<Lager> LagerListe { get; set; }
    }
}