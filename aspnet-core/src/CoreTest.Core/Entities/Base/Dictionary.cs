﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace FocusMedia.FSOi.Entities.Base
{
    [Table("Dic_Dictionary")]
    public class Dictionary: FullAuditedEntity
    {
        [Key]
        [Column("DicId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public virtual string DicName { get; set; }

        [MaxLength(2000, ErrorMessage = "MaxLength 2000")]
        public virtual string Description { get; set; }
    }
}
