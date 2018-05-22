using System;
using System.ComponentModel.DataAnnotations;

namespace ERPv1.Models
{
    [TrackChanges]
    public abstract class BaseClass 
    {
        [Display(Name = "Geändert von")]
        public string ChangedBy { get; set; }
        [Display(Name = "Erstellt von")]
        public string CreatedBy { get; set; }
        [Display(Name = "Gelöscht von")]
        public string DeletedBy { get; set; }
        [Display(Name = "Geändert am")]
        public DateTime? ChangedOn { get; set; }
        [Display(Name = "Gelöscht am")]
        public virtual DateTime? DeletedOn { get; set; }
        [Display(Name = "Erstellt am")]
        public DateTime CreatedOn { get; set; }
    }
}