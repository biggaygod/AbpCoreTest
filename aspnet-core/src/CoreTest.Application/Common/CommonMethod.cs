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

        public IList<T> SqlQuery<T>(DbContext db, string sql, params object[] parameters) where T : new()
        {
            var conn = db.Database.GetDbConnection();
            try
            {
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = sql;
                    command.Parameters.AddRange(parameters);
                    var propts = typeof(T).GetProperties();
                    var rtnList = new List<T>();
                    T model;
                    object val;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model = new T();
                            foreach (var i in propts)
                            {
                                val = reader[i.Name];
                                if (val == DBNull.Value)
                                {
                                    i.SetValue(model, null);
                                }
                                else
                                {
                                    i.SetValue(model, val);
                                }
                            }
                            rtnList.Add(model);
                        }
                    }
                    return rtnList;
                }
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
