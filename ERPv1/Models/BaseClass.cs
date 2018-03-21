using System;
using System.ComponentModel.DataAnnotations;

namespace ERPv1.Models
{
    [TrackChanges]
    public class BaseClass 
    {
        public virtual ApplicationUser ChangedBy { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual ApplicationUser DeletedBy { get; set; }
        public DateTime? ChangedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}