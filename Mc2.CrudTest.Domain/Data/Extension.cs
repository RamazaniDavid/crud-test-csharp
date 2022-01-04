using Mc2.CrudTest.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Mc2.CrudTest.Core.Extensions;

namespace Mc2.CrudTest.Data
{
    public static class Extension
    {

        public static void SetCreateOn(this ModelBuilder modelBuilder)
        {

            var listIDateEntityClasses = typeof(IDateEntity).GetAllClassNames();


         

            var listEntityMaps = modelBuilder.Model.GetEntityTypes()
                .Where(p=>listIDateEntityClasses.Contains(p.ClrType.FullName));


            foreach (var entityMap in listEntityMaps)
            {

                var props = entityMap.GetProperties().Where(p => p.ClrType == typeof(string));

                foreach (var item in props)
                {

                    item.SetColumnType("varchar");
                }

                var property = entityMap.FindProperty("CreateOn");
                if (property != null)
                {
                    property.ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.OnAdd;
                    property.SetDefaultValueSql("GetDate()");
                }
            }
        }

        public static void SetVarchar(this ModelBuilder modelBuilder)
        {

            var listIDateEntityClasses = typeof(IDateEntity).GetAllClassNames();




            var listEntityMaps = modelBuilder.Model.GetEntityTypes()
                .Where(p => listIDateEntityClasses.Contains(p.ClrType.FullName));


            foreach (var entityMap in listEntityMaps)
            {

                var props = entityMap.GetProperties().Where(p => p.ClrType == typeof(string));

                foreach (var item in props)
                {

                    item.SetColumnType("varchar");
                }

            }
        }


    }
}
