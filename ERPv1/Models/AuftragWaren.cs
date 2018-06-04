using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;

namespace ERPv1.Models
{
    [Table("AuftragWaren")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class AuftragWaren : BaseClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AuftragWarenID { get; set; }

        [ForeignKey("Auftrag")]
        public Guid AuftragID { get; set; }

        [ForeignKey("LagerWare")]
        public Guid LagerWareID { get; set; }

        [Display(Name = "Notiz")]
        public string Notiz { get; set; }

        [Display(Name = "Menge")]
        [Required(ErrorMessage = "Das Feld {0} wird benötigt.")]
        public int Menge { get; set; }

        public virtual Auftrag Auftrag { get; set; }
        public virtual LagerWaren LagerWare { get; set; }


    }
}