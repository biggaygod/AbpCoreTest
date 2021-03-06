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
    [Table("C_Country")]
    public class Country: FullAuditedEntity<int>, IMayHaveTenant, IPassivable
    {
        [Key]
        [Column("CountryId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Key]
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string CountryName { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string CountryShort { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string ChineseName { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string EnglishName { get; set; }

        public virtual int? TenantId { get; set; }

        public virtual bool IsActive { get; set; }
    }
}
