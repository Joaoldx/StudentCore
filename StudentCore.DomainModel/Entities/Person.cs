using System;

namespace StudentCore.DomainModel.Entities
{
    public class Person : EntityBase
    {
        public DateTime Birthday { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public string PhotoURL { get; set; }
    }
} 