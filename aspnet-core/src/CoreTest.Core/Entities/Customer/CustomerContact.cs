using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusMedia.FSOi.Entities.Customer
{
    [Table("CRM_CustomerContact")]
    public class CustomerContact : FullAuditedEntity
    {
        [Key]
        [Column("CustomerContactId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

        public virtual int CustomerId { get; set; }

        /// <summary>
        /// 联系人名称
        /// </summary>
        [MaxLength(30, ErrorMessage = "MaxLength 30")]
        public virtual string ContactName { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [MaxLength(2000, ErrorMessage = "MaxLength 2000")]
        public virtual string Address { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string Position { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        [MaxLength(60, ErrorMessage = "MaxLength 60")]
        public virtual string TelePhone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string Email { get; set; }
    }
}
