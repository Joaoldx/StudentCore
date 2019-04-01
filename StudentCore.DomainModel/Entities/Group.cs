using System;
using System.Collections.Generic;

namespace StudentCore.DomainModel.Entities
{
    public class Group
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Student> StudentList { get; set; }

        public IEnumerable<Teacher> TeacherList { get; set; }
    }
}