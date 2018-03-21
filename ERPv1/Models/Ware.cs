using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ERPv1.Models
{
    [Table("Waren")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Ware
    {
        [Key]
        public Guid ID { get; set; }
        public string Bezeichnung { get; set; }
        public string KurzBezeichnung { get; set; }
        public int Anzahl { get; set; }
        public DateTime? ChangedOn { get;set; }
        public virtual ApplicationUser ChangedBy { get; set; }
        public virtual ApplicationUser CreatedBy { get;set; }
        public DateTime CreatedOn { get;set; }
        public decimal Preis { get; set; }
        public int SteuerKlasse { get; set; }
        public double EinzelGewicht { get; set; }
    }
}