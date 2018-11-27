using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreTest.Entities.Customer
{
    [Table("CRM_Brand")]
    public class Brand : FullAuditedEntity<int>,IMayHaveTenant,IPassivable
    {
        [Key]
        [Column("BrandId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get ; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string BrandName { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string EngName { get; set; }

        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string Spell { get; set; }

        public virtual int? TenantId { get; set; }

        public virtual bool IsActive { get; set; }

    }
}
