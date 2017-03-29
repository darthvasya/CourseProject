using System;
using System.ComponentModel.DataAnnotations;

namespace WebCourse.Models
{
    public class Comment {

        [Key]
        public int CommentID { get; set; }
        [Required]
        public string CommentText { get; set; }
        [Required]
        public string AuthorId { get; set; }
        [Required]
        public int NewsId { get; set; }
        public int CommentParentId { get; set; }
        [Required]
        public DateTime CommentDate { get; set; }
        public int Rating { get; set; }

    }
}
