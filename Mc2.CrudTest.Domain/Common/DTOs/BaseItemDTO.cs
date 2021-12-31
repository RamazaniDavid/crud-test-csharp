using System;

namespace Mc2.CrudTest.Common.DTOs
{
    public class BaseItemDTO : BaseEntityDTO, IDateDTO
    {
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }
        public string LocalCreateOn { get; set; }
        public string LocalUpdateOn { get; set; }
    }
}
