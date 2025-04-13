using Microsoft.EntityFrameworkCore;
using SharedLibraries.Data;
using SharedLibraries.Models;
using SharedLibraries.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibraries.Repositories.Implementations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IdscWebsiteDbContext _context;

        public StudentRepository(IdscWebsiteDbContext context)
        {
            _context = context;
        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            return await _context.students
                                 .FirstOrDefaultAsync(s => s.Id ==  id);

        }
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.students.ToListAsync();
        }
        public async Task AddStudentAsync (Student student)
        {
            await _context.students.AddAsync(student);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateStudentAsync(Student student)
        {
            _context.students.Update(student);
            await _context.SaveChangesAsync();

        }
        public async Task DeleteStudentAsync(int id)
        {
            var student = await GetStudentByIdAsync(id);
            if (student != null)
            {
                _context.students.Remove(student);
                await _context.SaveChangesAsync();      
            }
        }
    }
}
