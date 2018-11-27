using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTest.Entities.Customer
{
    [Table("CRM_CustomerBrand")]
    public class CustomerBrand: FullAuditedEntity<int>, IMayHaveTenant
    {
        [Key]
        [Column("CustomerBrandId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

        public virtual int CustomerId { get; set; }

        public virtual int BrandId { get; set; }

        public virtual int? TenantId { get; set; }
    }
}
