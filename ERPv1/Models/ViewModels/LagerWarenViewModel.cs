using System.Collections.Generic;

namespace ERPv1.Models.ViewModels
{
    public class LagerWarenViewModel
    {
        public Lager Lager { get; set; }
        public List<LagerWaren> LagerWaren { get; set; }
        public List<Ware> Waren { get; set; }
    }
}