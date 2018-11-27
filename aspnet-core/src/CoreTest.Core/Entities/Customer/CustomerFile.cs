﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusMedia.FSOi.Entities.Customer
{
    [Table("CRM_File")]
    public class CustomerFile: FullAuditedEntity
    {
        [Key]
        [Column("CustomerBrandId", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public virtual string CountryCode { get; set; }

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
    }
}