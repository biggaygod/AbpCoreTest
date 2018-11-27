using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace FocusMedia.FSOi.Entities.Contract
{
    [Table("SCM_PublishAmount_Future")]
    public class PublishAmount_Future: FullAuditedEntity
    {
        [Key]
        [Column("GPId", Order = 1)]
        public override int Id { get; set; }

        [Key]
        [Column("CountryCode", Order = 2)]
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

        public virtual int ContractId { get; set; }

        public virtual int PublishId { get; set; }

        public virtual int FYear { get; set; }

        public virtual int FPeriod { get; set; }

        public virtual int SalesId { get; set; }

        public virtual int DeptId { get; set; }

        public virtual decimal Amount { get; set; }

        public virtual int State { get; set; }

        public virtual string Remark { get; set; }

        public virtual decimal TAmount { get; set; }

        /// <summary>
        /// 同步Id
        /// </summary>
        public virtual int? SyncId { get; set; }
    }
}
