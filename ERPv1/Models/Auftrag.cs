using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;
using ERPv1.Models.IdentityModels;

namespace ERPv1.Models
{
    [Table("Auftrag")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Auftrag : BaseClass
    {
        [Key]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Das Feld {0} wird benötigt."), Display(Name = "Auftragsnummer")]
        public int Auftragsnummer { get; set; }

        [Required(ErrorMessage = "Das Feld {0} wird benötigt."), Display(Name = "Bezeichnung")]
        public string Bezeichnung { get; set; }

        [ForeignKey("Status")]
        public Guid? StatusId { get; set; }

        [Display(Name = "Auftrags-Status")]
        public AuftragStatus Status { get; set; }

        [Required(ErrorMessage = "Das Feld {0} wird benötigt."), Display(Name="Ausführungsdatum")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime AuftragsDatum { get; set; }

        [Required(ErrorMessage = "Das Feld {0} wird benötigt."), Display(Name="Rechnungsdatum")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? RechnungsDatum { get; set; }

        [Display(Name="Anmerkungen")]
        public string Notiz { get; set; }

        [Required(ErrorMessage = "Das Feld {0} wird benötigt."), Display(Name = "Lieferant")]
        public string Lieferant { get; set; }

        [Display(Name = "Zugeordnete Waren")]
        public virtual ICollection<AuftragWaren> AuftragWaren { get; set; }

        [NotMapped]
        public List<SelectListItem> WarenAuswahl { get; set; }

        [Required(ErrorMessage = "Das Feld {0} wird benötigt."), ForeignKey("Kunde")]
        public Guid KundeId { get; set; }

        public virtual Kunde Kunde { get; set; }

        [NotMapped]
        public List<SelectListItem> KundenAuswahl { get; set; }
    }
}