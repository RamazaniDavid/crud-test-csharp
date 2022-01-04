using System;

namespace Mc2.CrudTest.Core
{
    public interface IDateEntity
    {
         DateTime CreateOn { get; set; }
         DateTime UpdateOn { get; set; }
    }
}
