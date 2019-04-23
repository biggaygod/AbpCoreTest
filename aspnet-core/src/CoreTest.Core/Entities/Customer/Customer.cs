using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace CoreTest.Entities.Customer
{
    [Table("CRM_Customer")]
    public class Customer: FullAuditedEntity<int>, IMayHaveTenant, IPassivable
    {
        [Key]
        [Column("CustomerId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        public virtual string CustomerCode { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string CustomerName { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string EngName { get; set; }

        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string Spell { get; set; }

        [MaxLength(2000, ErrorMessage = "MaxLength 2000")]
        public virtual string Address { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string Phone { get; set; }

        /// <summary>
        /// 同步Id
        /// </summary>
        public virtual int? SyncId { get; set; }

        public virtual int? TenantId { get; set; }

        public virtual bool IsActive { get; set; }
    }
}
