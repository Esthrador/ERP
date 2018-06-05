using ERPv1.Models.IdentityModels;

namespace ERPv1.Models.ViewModels
{
    public class RechnungViewModel
    {
        public Auftrag Auftrag { get; set; }

        public ApplicationUser Bearbeiter { get; set; }
    }
}