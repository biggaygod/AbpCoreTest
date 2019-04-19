using Abp.AutoMapper;
using CoreTest.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.App.BaseData.Dictionaries.Dto
{
    [AutoMapTo(typeof(Dictionary))]
    public class CreateDictionaryDto
    {
        public int? Id { get; set; }

        public string DicName{ get; set; }

        public string Description { get; set; }

        public string TenantId { get; set; }
    }
}
