using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Danrevi.Models;
using Danrevi.Services;
using Microsoft.EntityFrameworkCore.Update;
using AutoMapper;
using Danrevi.Dto;
using Microsoft.AspNetCore.Cors;

namespace Danrevi.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        // GET: api/Courses
        [EnableCors("AllowAllOrigins")]
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseRepository.GetCourses();
            var results = Mapper.Map<IEnumerable<CourseDto>>(courses);
            return Ok(results);
        }

        // GET: api/Courses/5
        [EnableCors("AllowAllOrigins")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var course = await _courseRepository.GetCourse(id);

            if(course == null)
            {
                return NotFound();
            }

            var results = Mapper.Map<CourseDto>(course);

            return Ok(results);
            ;
        }

        // PUT: api/Courses/5
        [EnableCors("AllowAllOrigins")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourses([FromRoute] int id, [FromBody] Courses course)
        {
            if(course == null)
            {
                return BadRequest();
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseExists = await _courseRepository.CourseExists(id);
            if(!courseExists)
            {
                return NotFound();
            }

            var courseToUpdate = await _courseRepository.GetCourse(id);


            Mapper.Map(course,courseToUpdate);
            var saved = await _courseRepository.Save();

            if(!saved)
            {
                return StatusCode(500,"Issue updating course. Please try again.");
            }

            return NoContent();
        }

        // POST: api/Courses
        [EnableCors("AllowAllOrigins")]
        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] Courses courses)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(await _courseRepository.CourseNameExists(courses.Name))
            {
                ModelState.AddModelError("Title","Course with that name already exists.");
            }

            var newCourse = Mapper.Map<Courses>(courses);
            _courseRepository.AddCourse(newCourse);
            var saved = await _courseRepository.Save();

            if(!saved)
            {
                return StatusCode(500,"Error when adding course. Please try again.");
            }

            var returnCourse = Mapper.Map<CourseDto>(newCourse);

            return CreatedAtAction("GetCourse",new { id = returnCourse.Id },returnCourse);
        }

        // DELETE: api/Courses/5
        [EnableCors("AllowAllOrigins")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourses([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var courseToRemove = await _courseRepository.GetCourse(id);
            if(courseToRemove == null)
            {
                return NotFound();
            }

            _courseRepository.DeleteCourse(courseToRemove);
            await _courseRepository.Save();

            return Ok(courseToRemove);
        }

        private async Task<bool> CoursesExists(int id)
        {
            return await _courseRepository.CourseExists(id);
        }
    }
}