using CSharpFunctionalExtensions;

namespace CoursesWebApp.Domain.Entities
{
    public class EnrollmentEntity : Entity
    {
        public StudentEntity Student { get; private set; }

        public CourseEntity Course { get; private set; }

        public EnrollmentEntity(StudentEntity student, CourseEntity course)
        {
            Student = student;
            Course = course;
        }

    }
}