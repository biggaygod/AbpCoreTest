using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.BaseDto
{
    public class PageResultRequestSearch: PagedAndSortedResultRequestDto
    {
        public virtual string where { get; set; }
    }
}
