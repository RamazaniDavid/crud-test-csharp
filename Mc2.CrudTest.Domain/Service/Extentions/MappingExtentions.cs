using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mc2.CrudTest.Core;
using Mc2.CrudTest.Core.Domian;
using Mapster;
using Mc2.CrudTest.Common.DTOs;

namespace Mc2.CrudTest.Service.Extentions
{
    public static class MappingExtentions
    {
        public static TDTO TODTO<TDTO>(this Entity entity) where TDTO : BaseDTO
        {
            if (entity == null)
                return null;

            var dto = entity.Adapt<TDTO>();

            if (entity is Customer && dto is CustomerListItemDTO)
            {
                var customer = entity as Customer;
                var customerDTO = dto as CustomerListItemDTO;
                customerDTO.BirthDate = customer.DateOfBirth.ToShortDateString();
                customerDTO.PhoneNumber =customer.CountryCode+"-"+ customer.PhoneNumber;
            }
            return dto;
        }


        public static TEntity ToEntity<TEntity>(this BaseDTO baseDTO) where TEntity : Entity
        {

            if (typeof(TEntity).GetInterface("IDateEntity") != null)
            {
                TypeAdapterConfig<BaseDTO, TEntity>.NewConfig().Ignore("CreateOn", "UpdateOn", "LocalCreateOn", "LocalUpdateOn");
            }
            var entity = baseDTO.Adapt<TEntity>();


          
            return entity;
        }

    }
}
