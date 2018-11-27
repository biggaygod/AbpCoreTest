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
    [Table("SCM_SalesAchieve")]
    public class SalesAchieve : FullAuditedEntity
    {
        [Key]
        [Column("SAId",Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        public virtual int OrderId { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

        public virtual int? SalesId { get; set; }

        [Column(TypeName = "MONEY")]
        public virtual decimal? AAmount { get; set; }

        public virtual decimal? APercent { get; set; }

        /// <summary>
        /// 同步Id
        /// </summary>
        public virtual int? SyncId { get; set; }

        //[ForeignKey("CountryCode")]
        //public virtual Country Country { get; set; }

        //[ForeignKey("OrderId")]
        //public virtual SalesOrder SalesOrder { get; set; }
    }
}
