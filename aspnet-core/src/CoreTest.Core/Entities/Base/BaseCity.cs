using System;
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
    [Table("Base_City")]
    public class BaseCity : FullAuditedEntity<int>, IMayHaveTenant, IPassivable
    {
        [Key]
        [Column("CityId",Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

        [MaxLength(10, ErrorMessage = "MaxLength 10")]
        public virtual string CityCode { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string CityName { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string EngName { get; set; }

        public virtual int? ParentId { get; set; }

        public virtual int? CityType { get; set; }

        public virtual int? CityLevel { get; set; }

        [MaxLength(20)]
        public virtual string Spell { get; set; }

        [MaxLength(2000, ErrorMessage = "MaxLength 2000")]
        public virtual string Description { get; set; }

        public virtual bool IsSales { get; set; }

        public virtual bool IsFinance { get; set; }

        public virtual bool IsPublish { get; set; }

        public virtual int? TenantId { get; set; }

        public virtual bool IsActive { get; set; }
    }
}
