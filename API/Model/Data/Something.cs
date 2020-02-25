using System;

namespace API.Model.Data
{
    public class Something : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDateUTC { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string StringField { get; set; }
        public int IntField { get; set; }
        public double DoubleField { get; set; }
        public Gender Gender { get; set; }
    }
}
