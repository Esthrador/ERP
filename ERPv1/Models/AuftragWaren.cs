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
        [Key, Column(Order = 0), ForeignKey("Auftrag")]
        public Guid AuftragID { get; set; }

        [Key, Column(Order = 1), ForeignKey("Ware")]
        public Guid WareID { get; set; }

        public string Notiz { get; set; }
        public int Menge { get; set; }

        public virtual Auftrag Auftrag { get; set; }
        public virtual Ware Ware { get; set; }


    }
}