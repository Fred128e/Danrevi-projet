using System;
using System.Collections.Generic;

namespace Danrevi.Models
{
    public partial class Articles
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }

        public Users User { get; set; }
    }
}
