using CarRentalSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.DataAccess.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetCommentsByCarIdAsync(int carId);
        Task<IEnumerable<Comment>> GetCommentsByCustomerIdAsync(int customerId);
        Task<IEnumerable<Comment>> GetCommentsByCompanyIdAsync(int companyId);
        Task AddReply(Comment comment, int parentId);
        Task<IEnumerable<Comment>> GetRepliesByCustomerIdAsync(int customerId, int parentCommentId);
        Task<IEnumerable<Comment>> GetReplies(int parentCommentId);
        Task<IEnumerable<Comment>> GetWithReplies(int parentCommentId);


    }
}
