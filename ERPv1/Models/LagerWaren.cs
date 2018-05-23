using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ERPv1.Models
{
    [Table("LagerWaren")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class LagerWaren : BaseClass
    {
        [Key, Column(Order = 0), ForeignKey("Lager")]
        public Guid LagerID { get; set; }

        [Key, Column(Order = 1), ForeignKey("Ware")]
        public Guid WareID { get; set; }

        [Display(Name = "Menge")]
        [Required(ErrorMessage = "Das Feld {0} wird benötigt.")]
        public int Menge { get; set; }

        public virtual Lager Lager { get; set; }
        public virtual Ware Ware { get; set; }

    }
}