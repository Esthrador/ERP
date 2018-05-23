﻿using System;
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

        [Display(Name = "Bezeichnung")]
        public string Bezeichnung { get; set; }

        [Display(Name = "Auftrags-Status")]
        public AuftragStatus Status { get; set; }

        [Display(Name="Ausführungsdatum")]
        public DateTime AuftragsDatum { get; set; }

        [Display(Name="Bearbeiter")]
        public virtual ApplicationUser Bearbeiter { get; set; }

        [Display(Name="Rechnungsdatum")]
        public DateTime? RechnungsDatum { get; set; }

        [Display(Name="Anmerkungen")]
        public string Notiz { get; set; }

        [Display(Name = "Lieferant")]
        public string Lieferant { get; set; }

        [Display(Name = "Zugeordnete Waren")]
        public virtual ICollection<AuftragWaren> AuftragWaren { get; set; }

        [NotMapped]
        public List<SelectListItem> WarenAuswahl { get; set; }

    }
}