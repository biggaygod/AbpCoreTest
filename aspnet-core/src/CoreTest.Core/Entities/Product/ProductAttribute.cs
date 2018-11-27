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
    [Table("PR_ProductAttribute")]
    public class ProductAttribute : FullAuditedEntity
    {
        [Key]
        [Column("Id", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

        public virtual int ProductId { get; set; }

        public virtual int AttributeId { get; set; }

        [MaxLength(20, ErrorMessage = "MaxLength 2000")]
        public virtual string AValue { get; set; }

    }
}
