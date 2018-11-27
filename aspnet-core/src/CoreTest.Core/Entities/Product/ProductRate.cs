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
    [Table("PR_ProductRate")]
    public class ProductRate : FullAuditedEntity
    {
        [Key]
        [Column("PRId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

        public virtual int ProductId { get; set; }

        public virtual int PbPeriodId { get; set; }

        public virtual DateTime BeginDate { get; set; }

        public virtual DateTime EndDate { get; set; }

        [Column("Rate", TypeName = "MONEY")]
        public virtual decimal Rate { get; set; }

        [MaxLength(20, ErrorMessage = "MaxLength 2000")]
        public virtual string Description { get; set; }

        //[ForeignKey("ProductId")]
        //public virtual Product Product { get; set; }

    }
}
