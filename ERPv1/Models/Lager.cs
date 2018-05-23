using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ERPv1.Models
{
    [Table("Lager")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Lager : BaseClass
    {
        [Key]
        public Guid ID { get;set; }

        [Display(Name = "Bezeichnung")]
        public string Bezeichnung { get; set; }

        [Display(Name = "Standort")]
        [Required(ErrorMessage = "Das Feld {0} wird benötigt.")]
        public string Standort { get; set; }

        [Display(Name = "Adresse")]
        [Required(ErrorMessage = "Das Feld {0} wird benötigt.")]
        public string Adresse { get; set; }

        [Display(Name = "PLZ")]
        [Required(ErrorMessage = "Das Feld {0} wird benötigt.")]
        public string PLZ { get; set; }

        [Required(ErrorMessage = "Das Feld {0} wird benötigt.")]
        [Display(Name = "Ort")]
        public string Ort { get; set; }

        public virtual ICollection<LagerWaren> LagerWaren { get; set; }

    }
}