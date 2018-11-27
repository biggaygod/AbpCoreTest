using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace CoreTest.Entities.Contract
{
    [Table("SCM_VoucherAI")]
    public class VoucherAI : FullAuditedEntity
    {
        [Key]
        [Column("AId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

        public virtual int? ContractId { get; set; }

        public virtual int? PbId { get; set; }

        public virtual int? FYear { get; set; }

        public virtual int? FMonth { get; set; }


        public virtual int? SalesId { get; set; }


        public virtual int? DeptId { get; set; }

        [Column("Amount", TypeName = "MONEY")]
        public virtual decimal? Amount { get; set; }

        public virtual int? State { get; set; }

        [MaxLength(255, ErrorMessage = "MaxLength 255")]
        public virtual string Remark { get; set; }

        //[ForeignKey("CountryCode")]
        //public virtual Country Country { get; set; }
    }
}
