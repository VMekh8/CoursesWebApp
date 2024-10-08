﻿using CSharpFunctionalExtensions;

namespace CoursesWebApp.Domain.Entities
{
    public class EnrollmentEntity : Entity
    {
        public StudentEntity Student { get; set; }

        public CourseEntity Course { get; set; }

        private EnrollmentEntity() {}

        public EnrollmentEntity(StudentEntity student, CourseEntity course)
        {
            Student = student;
            Course = course;
        }

    }
}