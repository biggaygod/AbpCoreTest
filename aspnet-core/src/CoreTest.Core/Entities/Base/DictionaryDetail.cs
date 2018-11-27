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
    [Table("Dic_DictionaryDetail")]
    public class DictionaryDetail : FullAuditedEntity<int>, IMayHaveTenant
    {
        [Key]
        [Column("DId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        public virtual int DicId { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string NameLCode { get; set; }

        [MaxLength(2000, ErrorMessage = "MaxLength 2000")]
        public virtual string Description { get; set; }

        [ForeignKey("DicId")]
        public Dictionary Dictionary { get; set; }

        public virtual int? TenantId { get; set; }
    }
}
