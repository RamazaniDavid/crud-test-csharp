using System;

namespace Mc2.CrudTest.Common.DTOs
{
    public interface IDateDTO
    {
          DateTime CreateOn { get; set; }
  
         DateTime UpdateOn { get; set; }
         string LocalCreateOn { get; set; }

         string LocalUpdateOn { get; set; }      
    }
}
