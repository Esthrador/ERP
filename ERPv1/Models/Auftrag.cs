using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ERPv1.Models
{
    [Table("Auftrag")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Auftrag : BaseClass
    {
        [Key]
        public Guid ID { get; set; }
        public AuftragStatus Status { get; set; }
        public DateTime AuftragsDatum { get; set; }
        public virtual ApplicationUser Bearbeiter { get; set; }
        public DateTime? RechnungsDatum { get; set; }
        public virtual ICollection<AuftragWaren> AuftragWaren { get; set; }
        public string Notiz { get; set; }
        public string Lieferant { get; set; }
    }
}