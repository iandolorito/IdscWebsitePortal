using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibraries.Models;
namespace SharedLibraries.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> GetStudentByIdAsync(int id);
        Task<IEnumerable<Payment>> GetAllStudentsAsync();   
        Task AddStudentAsync(Payment payment);
        Task DeleteStudentAsync(int id);
        Task UpdateStudentAsync(Payment payment);
    }
}
