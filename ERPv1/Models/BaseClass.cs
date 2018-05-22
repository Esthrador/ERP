using System;
using System.ComponentModel.DataAnnotations;

namespace ERPv1.Models
{
    [TrackChanges]
    public abstract class BaseClass 
    {
        public string ChangedBy { get; set; }
        public string CreatedBy { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? ChangedOn { get; set; }
        public virtual DateTime? DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}