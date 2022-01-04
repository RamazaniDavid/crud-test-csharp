using Mapster;
using Mc2.CrudTest.Common.DTOs;
using Mc2.CrudTest.Core;
using Mc2.CrudTest.Core.Domain;

namespace Mc2.CrudTest.Service.Extentions
{
    public static class MappingExtentions
    {
        public static TDto ToDto<TDto>(this Entity entity) where TDto : BaseDto
        {
            if (entity == null)
                return null;

            TDto dto = entity.Adapt<TDto>();

            if (entity is Customer customer && dto is CustomerListItemDto)
            {
                var customerDto = dto as CustomerListItemDto;
                customerDto.BirthDate = customer.DateOfBirth.ToShortDateString();
                customerDto.PhoneNumber =customer.CountryCode+"-"+ customer.PhoneNumber;
            }
            return dto;
        }


        public static TEntity ToEntity<TEntity>(this BaseDto baseDto) where TEntity : Entity
        {

            if (typeof(TEntity).GetInterface("IDateEntity") != null)
            {
                TypeAdapterConfig<BaseDto, TEntity>.NewConfig().Ignore("CreateOn", "UpdateOn", "LocalCreateOn", "LocalUpdateOn");
            }
            var entity = baseDto.Adapt<TEntity>();


          
            return entity;
        }

    }
}
