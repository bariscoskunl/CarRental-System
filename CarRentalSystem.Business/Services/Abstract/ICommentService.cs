using CarRentalSystem.Business.DTOs.Comment;
using CarRentalSystem.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Services.Abstract
{
    public interface ICommentService
    {
        Task<IEnumerable<CommentDto>> GetCommentsByCarIdAsync(int carId);
        Task<IEnumerable<CommentDto>> GetCommentsByCustomerIdAsync(int customerId);
        Task<IEnumerable<CommentDto>> GetCommentsByCompanyIdAsync(int companyId);
        Task AddReply(CreateCommentReplyDto comment, int parentId);
        Task<IEnumerable<CommentReplyDto>> GetRepliesByCustomerIdAsync(int customerId, int parentCommentId);
        Task<IEnumerable<CommentReplyDto>> GetReplies(int parentCommentId);
        Task<IEnumerable<CommentDto>> GetWithReplies(int parentCommentId);
        Task<IEnumerable<CommentDto>> GetAll();
        Task CreateToCompany(CommentCreateDto dto, int companyId);
        Task CreateToCar(CommentCreateDto dto, int carId);
        Task Update(CommentDto comment);
        Task DeleteComment(int commentId);



    }
}
