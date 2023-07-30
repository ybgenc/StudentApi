using StudentApı.DataModels;
using System.Reflection;

namespace StudentApı.Repositories
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly StudentAdminContext context;
        public SqlStudentRepository(StudentAdminContext context)
        {
            this.context = context;
        }
        public List<Student> GetStudents()
        {
            var students = context.Student
                                   .Select(s => new Student
                                   {
                                       // Burada Student sınıfının tüm özelliklerini doldurarak veritabanından sadece gerekli alanları çekebilirsiniz.
                                       // Örnek olarak:
                                       FirstName = s.FirstName,
                                       lastName = s.lastName,
                                       Email = s.Email,
                                       Mobile = s.Mobile,
                                       ProfileImageUrl = s.ProfileImageUrl ?? "DefaultImage.png",
                                       Gender = s.Gender ?? new Gender { Id = Guid.Empty, Description = "Unknown" },
                                       Address = s.Address ?? new Address { Id = Guid.Empty, PhysicalAddress = "Unknown", PostalAddress = "Unknown" },
                                       // Diğer özellikleri de benzer şekilde kontrol edebilirsiniz.
                                   })
                                   .ToList();

            return students;
        }

    }
}
