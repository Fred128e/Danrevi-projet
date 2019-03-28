using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Danrevi.Dto
{
    public class CourseDto
    {
        //public CourseDto()
        //{
        //    UserCourse = new HashSet<UserCourse>();
        //}

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        //public Users User { get; set; }
        //public ICollection<UserCourse> UserCourse { get; set; }
    }
}
