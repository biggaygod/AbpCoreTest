using Abp.AutoMapper;
using CoreTest.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoreTest.Brands.Dto
{
    [AutoMapTo(typeof(Brand))]
    public class BrandDto
    {
        public int? Id { get; set; }

        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public string CountryCode { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public string BrandName { get; set; }

        [MaxLength(120, ErrorMessage = "MaxLength 120")]
        public string EngName { get; set; }

        [MaxLength(20, ErrorMessage = "MaxLength 20")]
        public string Spell { get; set; }

        /// <summary>
        /// 启用停用状态
        /// </summary>
        public bool IsActive { get; set; }
    }
}
