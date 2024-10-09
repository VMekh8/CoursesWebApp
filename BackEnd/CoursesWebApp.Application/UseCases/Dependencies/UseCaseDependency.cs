using CoursesWebApp.Application.UseCases.CoursesUseCases;
using CoursesWebApp.Application.UseCases.NewsUseCases;
using CoursesWebApp.Application.UseCases.StudentsUseCases;
using Microsoft.Extensions.DependencyInjection;

namespace CoursesWebApp.Application.UseCases.Dependencies;

public static class UseCaseDependency
{

    public static IServiceCollection AddUseCasesDependency(this IServiceCollection service)
    {

        ///Courses Dependencies
        service.AddTransient<CreateCourseUseCase>();
        service.AddTransient<CourseUpdateUseCase>();
        service.AddTransient<RemoveCourseUseCase>();
        service.AddTransient<GetCoursesUseCase>();
        service.AddTransient<GetCourseByIdUseCase>();

        ///News Dependencies
        service.AddTransient<CreateNewsUseCase>();
        service.AddTransient<UpdateNewsUseCase>();
        service.AddTransient<RemoveNewsUseCase>();
        service.AddTransient<GetNewsUseCase>();
        service.AddTransient<GetNewsByIdUseCase>();

        ///Student Dependencies
        service.AddTransient<StudentCreateUseCase>();
        service.AddTransient<StudentUpdateUseCase>();
        service.AddTransient<StudentRemoveUseCase>();
        service.AddTransient<GetStudentsUseCase>();
        service.AddTransient<GetStudentByIdUseCase>();




        return service;

    }
}