using Microsoft.Extensions.DependencyInjection;
using CoursesApi.Core.Interface;
using CoursesApi.Core.Service;
using CoursesApi.Core.AutoMapper;

namespace CoursesApi.Core
{
    public static class ServiceExtensions
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<ICoursesService, CoursesService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAuthorService, AuthorService>();
        }
        public static void AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperCoursesProfile));
        }
    }
}
