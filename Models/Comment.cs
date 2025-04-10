using System;
using System.ComponentModel.DataAnnotations;

namespace Demo03.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        public string UserId { get; set; }
        public string UserName { get; set; }

        public int DocumentID { get; set; }
        public Document Document { get; set; }
    }
} 