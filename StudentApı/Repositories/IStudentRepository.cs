using StudentApı.DataModels;

namespace StudentApı.Repositories
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();
    }
}
