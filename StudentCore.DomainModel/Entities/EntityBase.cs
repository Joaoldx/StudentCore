using System;

namespace StudentCore.DomainModel.Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string email { get; set; }

        public string Telephone { get; set; }

        public string PhotoURL { get; set; }
    }
}