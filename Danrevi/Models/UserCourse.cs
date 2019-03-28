using System;
using System.Collections.Generic;

namespace Danrevi.Models
{
    public partial class UserCourse
    {
        public int CourseId { get; set; }
        public int UserId { get; set; }

        public Courses Course { get; set; }
        public Users User { get; set; }
    }
}
