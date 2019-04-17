using StudentCore.DomainModel.Entities;

namespace StudentCore.WebApp.Dtos
{
    public class PersonDto : EntityBase
    {
        public string PhotoURL { get; set; }
    }
}