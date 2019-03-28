using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Danrevi.Models;
using Microsoft.EntityFrameworkCore;

namespace Danrevi.Services
{
    public class CourseRepository : ICourseRepository
    {
        private readonly danrevi_webContext _context;

        public CourseRepository(danrevi_webContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Courses>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Courses> GetCourse(int id)
        {
            return await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
        }

        public void AddCourse (Courses courses)
        {
            _context.Add(courses);
        }

        public void DeleteCourse(Courses courses)
        {
            _context.Remove(courses);
        }

        public void UpdateCourse(Courses courses)
        {
            _context.Update(courses);
        }

        public async Task<bool> CourseExists(int id)
        {
            return await _context.Courses.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> CourseNameExists(string name)
        {
            return await _context.Courses.AnyAsync(c => c.Name == name);
        }

        public async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
