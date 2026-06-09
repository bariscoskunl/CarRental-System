using CarRentalSystem.DataAccess.Contexts;
using CarRentalSystem.DataAccess.Interfaces;
using CarRentalSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Concrete
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly CarRentalDbContext _context;
        private readonly Repository<Comment> _repo;

        public CommentRepository(CarRentalDbContext context, Repository<Comment> repo) : base(context)
        {
            _context = context;
            _repo = repo;
        }

        public async Task AddReply(Comment comment, int parentId)
        {

            var parentComment = await _repo.GetByIdAsync(parentId);
            if (parentComment == null)
            {
                throw new Exception("Parent comment not found");
            }
            comment.ParentCommentId = parentComment.Id;

            await _repo.AddAsync(comment);


        }

        public async Task<IEnumerable<Comment>> GetCommentsByCarIdAsync(int carId)
        {
            var comments = await _repo.FindAsync(c => c.CarId == carId && c.ParentCommentId == null);
            return comments;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByCompanyIdAsync(int companyId)
        {
            var comments = await _repo.FindAsync(c => c.CompanyId == companyId && c.ParentCommentId == null);
            return comments;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByCustomerIdAsync(int customerId)
        {
            var comments = await _repo.FindAsync(c => c.CustomerId == customerId && c.ParentCommentId == null);
            return comments;
        }

        public async Task<IEnumerable<Comment>> GetReplies(int parentCommentId)
        {
            var replies = await _repo.FindAsync(c => c.ParentCommentId == parentCommentId);
            return replies;
        }

        public Task<IEnumerable<Comment>> GetRepliesByCustomerIdAsync(int customerId, int parentCommentId)
        {
            var replies = _repo.FindAsync(c => c.ParentCommentId == parentCommentId && c.CustomerId == customerId);
            return replies;
        }

        public Task<IEnumerable<Comment>> GetWithReplies(int parentCommentId)
        {
            var comments = _repo.FindAsync(c => c.Id == parentCommentId || c.ParentCommentId == parentCommentId);
            return comments;
        }
    }
}
