using System.Collections.Generic;

namespace WebCourse.Models.Repositories
{
    public interface ICommentRepository {
        IEnumerable<Comment> Comments { get; set; }

        void SaveComment(Comment c);

        Comment DeleteComment(int commentId);
    }
}
