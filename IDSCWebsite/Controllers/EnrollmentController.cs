using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SharedLibraries.Models;
using SharedLibraries.Repositories.Interfaces;

namespace IDSCWebsite.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
       
        private const decimal MIN_DOWN_PAYMENT = 1000m;

        public EnrollmentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Student student)
        {
            if (ModelState.IsValid)
            {
               
                TempData["StudentData"] = JsonConvert.SerializeObject(student);
              
                return RedirectToAction("Payment");
            }

            return View(student);
        }
        public IActionResult Payment()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Payment(Payment payment)
        {
            if (!ModelState.IsValid || TempData["StudentData"] == null)
            {
                return View(payment);
            }

            
            if (payment.Payment_Ammount < MIN_DOWN_PAYMENT)
            {
                ModelState.AddModelError("DownPayment", $"A minimum down payment of {MIN_DOWN_PAYMENT:C} is required.");
                return View(payment);
            }

        
            var studentJson = TempData["StudentData"].ToString();
            var student = JsonConvert.DeserializeObject<Student>(studentJson);

            // Generate and assign the Student Number
            student.StudentNo = await GenerateStudentNoAsync();

            // Assign the down payment to the student's payments
            // Ensure that your Student model has a Payments collection to capture this detail.
            student.Payments = new List<Payment> { payment };

            // Save the student (along with payment) to the database
            await _studentRepository.AddStudentAsync(student);

            return RedirectToAction("Success");
        }

        
        public IActionResult Success()
        {
            return View();
        }

        
        private async Task<string> GenerateStudentNoAsync()
        {
            var yearShort = DateTime.Now.ToString("yy");
            var allStudents = await _studentRepository.GetAllStudentsAsync();
            int countThisYear = allStudents.Count(s => s.StudentNo != null && s.StudentNo.StartsWith($"{yearShort}-"));
            return $"{yearShort}-{(countThisYear + 1).ToString("D3")}";
        }
    }
}
