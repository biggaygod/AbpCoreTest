using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using CoreTest.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreTest.App.BaseData.Dictionaries.Dto
{
    [AutoMapTo(typeof(Dictionary))]
    public class DictionaryDto:EntityDto<int>
    {
        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public string DicName { get; set; }


        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public string Description { get; set; }

        /// <summary>
        /// 启用停用状态
        /// </summary>
        public bool IsActive { get; set; }

        public DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public bool IsDeleted { get; set; }

        public int? TenantId { get; set; }
    }
}
