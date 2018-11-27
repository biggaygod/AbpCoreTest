using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using FocusMedia.FSOi.Entities.Base;

namespace FocusMedia.FSOi.Entities.Contract
{
    [Table("SCM_SalesPublish")]
    public class SalesPublish : FullAuditedEntity
    {
        [Key]
        [Column("PbId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

        public virtual int OrderId { get; set; }

        public virtual int ProductId { get; set; }

        public virtual int? PRId { get; set; }

        public virtual DateTime? RateCardDate { get; set; }

        [Column(TypeName = "MONEY")]
        public virtual decimal? RateCard { get; set; }

        public virtual decimal? RealPlay { get; set; }

        public virtual decimal? RealFreq { get; set; }

        public virtual decimal? Quantity { get; set; }

        public virtual int? Attribute { get; set; }

        public virtual DateTime BeginDate { get; set; }

        public virtual DateTime EndDate { get; set; }

        public virtual decimal? Period { get; set; }

        [Column(TypeName = "MONEY")]
        public virtual decimal? TotalAmount { get; set; }

        public virtual decimal? Discount { get; set; }

        [Column(TypeName = "MONEY")]
        public virtual decimal? PbAmount { get; set; }

        [Column(TypeName = "MONEY")]
        public virtual decimal? OtAmount { get; set; }

        [MaxLength(2000, ErrorMessage = "MaxLength 2000")]
        public virtual string PbContent { get; set; }

        /// <summary>
        /// 同步Id
        /// </summary>
        public virtual int? SyncId { get; set; }

        //public virtual SalesOrder SalesOrder { get; set; }

    }
}
