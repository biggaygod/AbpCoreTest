using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreTest.Entities.Customer
{
    [Table("CRM_CustomerFile")]
    public class CustomerFile: FullAuditedEntity<int>, IMayHaveTenant
    {
        [Key]
        [Column("CustomerBrandId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        public virtual int CustomerId { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public virtual string  FilePath { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        [MaxLength(1000, ErrorMessage = "MaxLength 1000")]
        public virtual string FileName { get; set; }


        public virtual int? TenantId { get; set; }
    }
}
