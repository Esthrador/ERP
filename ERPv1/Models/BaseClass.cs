﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ERPv1.Models
{
    [TrackChanges]
    public class BaseClass 
    {
        public string ChangedBy { get; set; }
        public string CreatedBy { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? ChangedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}