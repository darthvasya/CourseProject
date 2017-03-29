using System;
using System.Collections.Generic;

namespace WebCourse.Models.Repositories
{
    public class EFCommentRepository : ICommentRepository {

        private ApplicationDbContext context;

        public EFCommentRepository(ApplicationDbContext ctx) {
            context = ctx;
        }

        public IEnumerable<Comment> Comments { get; set; }

        public Comment DeleteComment(int commentId) {
            throw new NotImplementedException();
        }

        public void SaveComment(Comment c) {
            throw new NotImplementedException();
        }
    }
}
