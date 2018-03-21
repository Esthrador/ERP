using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;

namespace ERPv1.Models
{
    [Table("Auftragsstatus")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class AuftragStatus
    {
        [Key]
        public Guid ID { get; set; }
        public string Bezeichnung { get; set; }
        public string KurzBezeichnung { get; set; }
        public bool IsVisibleForAll { get; set; }
    }
}