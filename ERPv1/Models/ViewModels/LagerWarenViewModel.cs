using System.Collections.Generic;

namespace ERPv1.Models.ViewModels
{
    public class LagerWarenViewModel
    {
        public Lager Lager { get; set; }
        public IEnumerable<Ware> Waren { get; set; }
    }
}