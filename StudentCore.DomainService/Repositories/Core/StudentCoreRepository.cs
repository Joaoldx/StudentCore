using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentCore.DataAccess.Context;
using StudentCore.DomainModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace StudentCore.DomainService.Repositories.Core
{
    public class StudentCoreRepository : IStudentCoreRepository
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        // STUDENT
        public async Task<ICollection<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();

        }

        public Task<ICollection<Student>> GetAllStudentsByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Student>> GetAllStudentsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        // TEACHER
        public Task<ICollection<Teacher>> GetAllTeachersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Teacher>> GetAllTeachersByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Teacher>> GetAllTeachersByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}