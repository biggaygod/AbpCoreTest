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
    [Table("PR_Standard")]
    public class Standard : FullAuditedEntity
    {
        [Key]
        [Column("StdId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

        [MaxLength(60, ErrorMessage = "MaxLength 60")]
        public virtual string FreqName { get; set; }

        public virtual bool? IsDaylong { get; set; }

        public virtual int PbTime { get; set; }

        public virtual int PbFreq { get; set; }
    }
}
