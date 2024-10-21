using System.Collections.Immutable;
using System.Runtime.InteropServices;
using System.Text;
using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Application.UseCases.CoursesUseCases;
using CoursesWebApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CoursesWebApp.Application.UseCases.TeacherUseCases;

public class CreateTeacherUseCase : TeacherUseCase
{

    private readonly IRepository<TeacherEntity> _repository;
    private readonly GetCourseByIdUseCase _getCourse;

    public CreateTeacherUseCase(IRepository<TeacherEntity> repository, GetCourseByIdUseCase getCourseByIdUseCase)
    {
        _repository = repository;
        _getCourse = getCourseByIdUseCase;
    }

    public override async Task Create(TeacherEntity entity, IEnumerable<long> coursesId)
    {
        if (!coursesId.Any())
            throw new ArgumentException("Collection with Courses Id`s is empty");

        var findCourseTask = coursesId.Select(async courseId => 
            await _getCourse.GetById(courseId)
        ).ToList();

        var courses = await Task.WhenAll(findCourseTask);

        entity.Courses.AddRange(courses.Where(course =>
            course is not null
        ).Cast<CourseEntity>());

        await _repository.CreateAsync(entity);
    }


}