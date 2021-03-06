﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace CoreTest.Entities.Base
{
    [Table("ED_Department")]
    public class Department : FullAuditedEntity<int>, IMayHaveTenant, IPassivable
    {
        [Key]
        [Column("DeptId" ,Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string DeptCode { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string DeptName { get; set; }

        public virtual int? ParentDeptId { get; set; }

        public virtual int? TenantId { get; set; }

        public virtual bool IsActive { get; set; }
    }
}
