﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace FocusMedia.FSOi.Entities.Base
{
    [Table("ED_Employee")]
    public class Employee: FullAuditedEntity
    {
        [Key]
        [Column("EId",Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string ECode { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string EName { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string EngName { get; set; }

        public virtual int? DeptId { get; set; }

        //[ForeignKey("CountryCode")]
        //public virtual Country Country { get; set; }
    }
}
