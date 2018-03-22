using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ERPv1.Models
{
    [Table("Waren")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Ware : BaseClass
    {
        [Key]
        public Guid ID { get; set; }
        public string Bezeichnung { get; set; }
        public string KurzBezeichnung { get; set; }
        public string Notiz { get; set; }
        public int Anzahl { get; set; }
        public decimal Preis { get; set; }
        public int SteuerKlasse { get; set; }
        public double EinzelGewicht { get; set; }
        public virtual ICollection<AuftragWaren> AuftragWaren { get;set; }
    }
}