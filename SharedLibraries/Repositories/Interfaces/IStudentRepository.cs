using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibraries.Models;
namespace SharedLibraries.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentByIdAsync(int id);
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task AddStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
        Task UpdateStudentAsync(Student student);
    }
}
