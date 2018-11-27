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
    [Table("SCM_SalesOrder")]
    public class SalesOrder : FullAuditedEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("OrderId",Order = 1)]
        public override int Id { get; set; }

        [Key]
        [Column("CountryCode",Order = 2)]

        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

        [Column("ContractId")]
        public virtual int ContractId { get; set; }

        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string OrderTitle { get; set; }

        [Column("PbAmount", TypeName = "MONEY")]
        public virtual decimal? PbAmount { get; set; }

        [Column("OtAmount", TypeName = "MONEY")]
        public virtual decimal? OtAmount { get; set; }

        [Column("Amount", TypeName = "MONEY")]
        public virtual decimal? Amount { get; set; }

        public virtual decimal? DiscountRate { get; set; }

        public virtual decimal? SalesDiscount { get; set; }

        //public virtual SalesContract SalesContract { get; set; }
    }
}
