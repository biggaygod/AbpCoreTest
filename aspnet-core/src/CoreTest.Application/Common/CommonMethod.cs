using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTest.Common
{
    public class CommonMethod
    {
        public virtual string BuildSqlWhere(string where,string TableName)
        {
            var sql= $"select * from {TableName}  where 1=1";
            if (!string.IsNullOrEmpty(where))
                sql += " and ";
            sql += where;
            return sql;
        }
    }
}
