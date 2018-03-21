using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;

namespace ERPv1.Models
{
    [Table("Kunden")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Kunde : BaseClass
    {
        [Key]
        public Guid ID { get;set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public bool IsFirma { get; set; }
        public string Email { get; set; }
        public string PLZ { get; set; }
        public string Ort { get; set; }
        public string Addresse { get; set; }
        public string Tel { get; set; }
        public string KurzBezeichnung { get; set; }
    }
}