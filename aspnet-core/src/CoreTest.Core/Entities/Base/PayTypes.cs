using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusMedia.FSOi.Entities.Base
{
    public class PayTypes : FullAuditedEntity<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        public int TenantId { get; set; }

        /// <summary>
        /// 国家代码
        /// </summary>
        [Required]
        [MaxLength(20)]
        public virtual string CountryCode { get; set; }

        /// <summary>
        /// 支付方式代码
        /// </summary>
        public virtual int PayCode { get; set; }

        /// <summary>
        /// 支付方式名称
        /// </summary>
        [MaxLength(120)]
        public virtual string PayName { get; set; }

        /// <summary>
        /// 英文名称
        /// </summary>
        [MaxLength(120)]
        public virtual string EngName { get; set; }


        /// <summary>
        /// 对应总部的支付方式
        /// </summary>
        public virtual int CN_Code { get; set; }


        public virtual bool IsActive { get; set; }


    }
}
