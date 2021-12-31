using Mc2.CrudTest.Core;
using Mc2.CrudTest.Data.Mapping;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Mc2.CrudTest.Data
{
    public class SqlServerApplicationContext:DbContext, IApplcationDbContext
    {
       
        public SqlServerApplicationContext(DbContextOptions option)
            : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerApplicationContext).Assembly);
           
            
            base.OnModelCreating(modelBuilder);
        }

        public override EntityEntry Update([NotNullAttribute] object entity)
        {
            return base.Update(entity);
        }

        public List<T> RunSp<T>(string StoreName, List<DbParamter> ListParamert) where T : new()
        {
            this.Database.OpenConnection();
            DbCommand cmd = this.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = StoreName;
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (var item in ListParamert)
            {
                cmd.Parameters.Add(new SqlParameter { ParameterName = item.ParametrName, Value = item.Value });
            }


            List<T> list = new List<T>();
            using (var reader = cmd.ExecuteReader())
            {
                if (reader != null && reader.HasRows)
                {
                    var entity = typeof(T);
                    var propDict = new Dictionary<string, PropertyInfo>();
                    var props = entity.GetProperties
           (BindingFlags.Instance | BindingFlags.Public);
                    propDict = props.ToDictionary(p => p.Name.ToUpper(), p => p);
                    while (reader.Read())
                    {
                        T newobject = new T();

                        for (int index = 0; index < reader.FieldCount; index++)
                        {
                            if (propDict.ContainsKey(reader.GetName(index).ToUpper()))
                            {
                                var info = propDict[reader.GetName(index).ToUpper()];
                                if ((info != null) && info.CanWrite)
                                {
                                    var val = reader.GetValue(index);
                                    info.SetValue(newobject, (val == DBNull.Value) ? null : val, null);
                                }
                            }
                        }
                        list.Add(newobject);
                    }
                }
                this.Database.CloseConnection();
                return list;
            }
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (Exception ex)
            {
                CleanContext();
                throw ex;
            }
        }

        private void CleanContext()
        {
            if (this.ChangeTracker.HasChanges())
            {
                var _list = this.ChangeTracker.Entries().Where(p => p.State == EntityState.Modified || p.State == EntityState.Added || p.State == EntityState.Deleted).ToList();
                foreach (var item in _list)
                {
                    item.State = EntityState.Unchanged;
                }
            }
        }



    }
}
