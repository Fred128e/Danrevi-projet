using System;
using System.Collections.Generic;

namespace Danrevi.Models
{
    public partial class Users
    {
        public Users()
        {
            Articles = new HashSet<Articles>();
            Courses = new HashSet<Courses>();
            RoleUser = new HashSet<RoleUser>();
            UserCourse = new HashSet<UserCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTimeOffset? EmailVerifiedAt { get; set; }
        public string Password { get; set; }
        public string RememberToken { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public string ApiToken { get; set; }

        public ICollection<Articles> Articles { get; set; }
        public ICollection<Courses> Courses { get; set; }
        public ICollection<RoleUser> RoleUser { get; set; }
        public ICollection<UserCourse> UserCourse { get; set; }
    }
}
