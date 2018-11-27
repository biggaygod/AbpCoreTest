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
    [Table("Base_SignBody")]
    public class SignBody: FullAuditedEntity<int>, IMayHaveTenant, IPassivable
    {
        [Key]
        [Column("BodyId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string BodyCode { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string BodyName { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string EngName { get; set; }

        public bool IsActive { get; set; }

        public virtual int? TenantId { get; set; }
    }
}
