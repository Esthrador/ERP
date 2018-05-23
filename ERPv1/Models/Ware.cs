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

        [Index("IX_ArtNr_Hersteller_Delete", 0, IsUnique = true)]
        [Required(ErrorMessage = "Das Feld {0} wird benötigt."), Display(Name = "Artikelnummer")]
        [StringLength(32, ErrorMessage = "Ungültige Länge der Artikelnummer")]
        public string ArtikelNummer { get; set; }

        [Required(ErrorMessage = "Das Feld {0} wird benötigt."), Display(Name = "Bezeichnung")]
        public string Bezeichnung { get; set; }

        [Display(Name = "Kurzbezeichnung")]
        public string KurzBezeichnung { get; set; }

        [Index("IX_ArtNr_Hersteller_Delete", 1, IsUnique = true)]
        [Required(ErrorMessage = "Das Feld {0} wird benötigt."), Display(Name = "Hersteller")]
        [StringLength(32, ErrorMessage = "Ungültige Länge des Herstellernamen")]
        public string HerstellerName { get; set; }

        [Index("IX_ArtNr_Hersteller_Delete", 2, IsUnique = true)]
        public override DateTime? DeletedOn { get; set; }
        
        [Required(ErrorMessage = "Das Feld {0} wird benötigt."), Display(Name = "Mindestmenge")]
        public int Anzahl { get; set; }

        [Required(ErrorMessage = "Das Feld {0} wird benötigt."), Display(Name = "Preis pro Einheit")]
        public double EinzelPreis { get; set; }

        [Display(Name = "Gewicht pro Einheit")]
        public double EinzelGewicht { get; set; }

        [Display(Name = "Anmerkung")]
        public string Notiz { get; set; }

        public virtual ICollection<AuftragWaren> AuftragWaren { get; set; }
        public virtual ICollection<LagerWaren> LagerWaren { get; set; }

    }
}