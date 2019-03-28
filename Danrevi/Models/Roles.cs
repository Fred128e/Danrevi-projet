using System;
using System.Collections.Generic;

namespace Danrevi.Models
{
    public partial class Roles
    {
        public Roles()
        {
            RoleUser = new HashSet<RoleUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public ICollection<RoleUser> RoleUser { get; set; }
    }
}
