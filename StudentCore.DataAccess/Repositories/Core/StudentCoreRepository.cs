using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentCore.DataAccess.Context;
using StudentCore.DomainModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace StudentCore.DataAccess.Repositories.Core
{
    public class StudentCoreRepository : IStudentCoreRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentCoreRepository(ApplicationDbContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
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

        public async Task<Student> GetStudentByIdAsync(Guid Id)
        {
            return await _context.Students.FirstAsync(student => student.Id == Id);
        }

        public async Task<ICollection<Student>> GetAllStudentsByNameAsync(string name)
        {
            return await _context.Students            
            .Where(student =>
                student.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        // TEACHER
        public async Task<ICollection<Teacher>> GetAllTeachersAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task<Teacher> GetTeacherByIdAsync(Guid id)
        {
            return await _context.Teachers.FirstAsync(teacher => teacher.Id == id);
        }

        public async Task<ICollection<Teacher>> GetAllTeachersByNameAsync(string name)
        {
            return await _context.Teachers
               .Where(teacher =>
                   teacher.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}