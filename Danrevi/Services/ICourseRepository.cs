using System.Collections.Generic;
using System.Threading.Tasks;
using Danrevi.Models;

namespace Danrevi.Services
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Courses>> GetCourses();
        Task<Courses> GetCourse(int id);
        void AddCourse (Courses courses);
        void DeleteCourse(Courses courses);
        void UpdateCourse(Courses courses);
        Task<bool> CourseExists(int id);
        Task<bool> CourseNameExists(string name);
        Task<bool> Save();
    }
}