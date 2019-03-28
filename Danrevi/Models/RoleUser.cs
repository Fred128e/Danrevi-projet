using System;
using System.Collections.Generic;

namespace Danrevi.Models
{
    public partial class RoleUser
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }

        public Roles Role { get; set; }
        public Users User { get; set; }
    }
}
