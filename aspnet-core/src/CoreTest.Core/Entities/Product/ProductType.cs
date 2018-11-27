using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace FocusMedia.FSOi.Entities.Product
{
    [Table("PR_ProductType")]
    public class ProductType : FullAuditedEntity
    {
        [Key]
        [Column("PTId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string PTCode { get; set; }

        [MaxLength(20, ErrorMessage = "MaxLength 120")]
        public virtual string PTName { get; set; }

        public virtual int ParentId { get; set; }
    }
}
