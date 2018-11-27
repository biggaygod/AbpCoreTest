using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace CoreTest.Entities.Product
{

    [Table("PR_Product")]
    public class Product: FullAuditedEntity
    {
        [Key]
        [Column("ProductId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string ProductName { get; set; }

        public virtual int PTId { get; set; }

        public virtual int StdId { get; set; }

        public virtual int? Shape { get; set; }

        public virtual int? CityCount { get; set; }

        public virtual bool? IsFixedRate { get; set; }

        public virtual bool? IsFixedPeriod { get; set; }

        public virtual bool? InRate { get; set; }

        public virtual int? SaleUnit { get; set; }

        /// <summary>
        /// 同步Id
        /// </summary>
        public virtual int? SyncId { get; set; }

        /// <summary>
        /// 是否活跃
        /// </summary>
        public virtual bool IsActive { get; set; }

        //[ForeignKey("CountryCode")]
        //public virtual Country Country { get; set; }


    }
}
