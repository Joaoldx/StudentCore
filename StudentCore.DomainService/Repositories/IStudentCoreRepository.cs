using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentCore.DomainModel.Entities;

namespace StudentCore.DomainService.Repositories
{
    public interface IStudentCoreRepository
    {
        // GENERIC
         void Add<T>(T entity) where T: class;

         void Delete<T>(T entity) where T: class;

         void Update<T>(T entity) where T: class;

        Task<bool> SaveChangesAsync();

        // STUDENTS
         Task<ICollection<Student>> GetAllStudentsAsync();

         Task<Student> GetStudentByIdAsync(Guid id);

         Task<ICollection<Student>> GetAllStudentsByNameAsync(string name);


        //TEACHER
        Task<ICollection<Teacher>> GetAllTeachersAsync();
        Task<Teacher> GetTeacherByIdAsync(Guid id);
        Task<ICollection<Teacher>> GetAllTeachersByNameAsync(string name);


    }
}