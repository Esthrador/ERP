using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ERPv1.Models
{
    [Table("Kunden")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Kunde : BaseClass
    {
        [Key]
        public Guid ID { get;set; }

        [Required(ErrorMessage = "Das Feld {0} wird benötigt."), Display(Name = "Vorname")]
        public string Vorname { get; set; }

        [Required(ErrorMessage = "Das Feld {0} wird benötigt."), Display(Name = "Nachname")]
        public string Nachname { get; set; }

        [Display(Name = "Ist ein Unternehmen")]
        public bool IsFirma { get; set; }

        [Required(ErrorMessage = "Das Feld {0} wird benötigt."), Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Das Feld {0} wird benötigt."), Display(Name = "PLZ")]
        public string PLZ { get; set; }

        [Required(ErrorMessage = "Das Feld {0} wird benötigt."), Display(Name = "Ort")]
        public string Ort { get; set; }

        [Required(ErrorMessage = "Das Feld {0} wird benötigt."), Display(Name = "Adresse")]
        public string Addresse { get; set; }

        [Display(Name = "Telefon")]
        public string Tel { get; set; }

        [Display(Name = "Bezeichnung")]
        public string KurzBezeichnung { get; set; }
    }
}