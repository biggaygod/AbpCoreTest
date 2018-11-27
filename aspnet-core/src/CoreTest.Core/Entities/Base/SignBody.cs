using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace FocusMedia.FSOi.Entities.Base
{
    [Table("Base_SignBody")]
    public class SignBody: FullAuditedEntity
    {
        [Key]
        [Column("BodyId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string BodyCode { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string BodyName { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string EngName { get; set; }

        //[ForeignKey("CountryCode")]
        //public virtual Country Country { get; set; }

        /// <summary>
        /// 是否活跃
        /// </summary>
        public bool IsActive { get; set; }
    }
}
