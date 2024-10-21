using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Application.UseCases.Abstract;
using CoursesWebApp.Application.UseCases.CoursesUseCases;
using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.Application.UseCases.TeacherUseCases;

public class UpdateTeacherUseCase : TeacherUseCase
{
    private readonly IRepository<TeacherEntity> _repository;
    private readonly GetCourseByIdUseCase _getCourse;

    public UpdateTeacherUseCase(IRepository<TeacherEntity> repository, GetCourseByIdUseCase getCourse)
    {
        _repository = repository;
        _getCourse = getCourse;
    }

    public override async Task Update(TeacherEntity entity, IEnumerable<long> coursesId)
    {
        if (!coursesId.Any())
            throw new ArgumentException("Collection with courses ids is empty");

        var findCoursesTask = coursesId.Select(async courseId => 
            await _getCourse.GetById(courseId)).ToList();

        var courses = await Task.WhenAll(findCoursesTask);

        entity.Courses.AddRange(
            courses.Where(course =>
                course is not null
            ).Cast<CourseEntity>());

        await _repository.UpdateAsync(entity);
    }
}