using System;

namespace Mc2.CrudTest.Core
{
    public abstract  class BaseEntity:Entity,IDateEntity
    {
        public int Id { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }
    }
}
