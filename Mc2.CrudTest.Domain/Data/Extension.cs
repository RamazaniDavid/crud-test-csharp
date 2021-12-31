using Mc2.CrudTest.Core;
using Mc2.CrudTest.Core.Extenstions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mc2.CrudTest.Data
{
    public static class Extension
    {

        public static void SetCreateOn(this ModelBuilder modelBuilder)
        {

            var ListIDateEntityClasses = typeof(IDateEntity).GetAllClassNames();


         

            var ListEntityMaps = modelBuilder.Model.GetEntityTypes()
                .Where(p=>ListIDateEntityClasses.Contains(p.ClrType.FullName));


            foreach (var EntityMap in ListEntityMaps)
            {

                var props = EntityMap.GetProperties().Where(p => p.ClrType == typeof(string));

                foreach (var item in props)
                {

                    item.SetColumnType("varchar");
                }

                var property = EntityMap.FindProperty("CreateOn");
                if (property != null)
                {
                    property.ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAdd;
                    property.SetDefaultValueSql("GetDate()");
                }
            }
        }

        public static void SetVarchar(this ModelBuilder modelBuilder)
        {

            var ListIDateEntityClasses = typeof(IDateEntity).GetAllClassNames();




            var ListEntityMaps = modelBuilder.Model.GetEntityTypes()
                .Where(p => ListIDateEntityClasses.Contains(p.ClrType.FullName));


            foreach (var EntityMap in ListEntityMaps)
            {

                var props = EntityMap.GetProperties().Where(p => p.ClrType == typeof(string));

                foreach (var item in props)
                {

                    item.SetColumnType("varchar");
                }

            }
        }


    }
}
