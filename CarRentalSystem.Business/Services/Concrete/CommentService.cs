using CarRentalSystem.Business.DTOs.Comment;
using CarRentalSystem.Business.Services.Abstract;
using CarRentalSystem.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.Services.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly CommentRepository _repo;

        public CommentService(CommentRepository repo)
        {
            _repo = repo;
        }
        public async Task AddReply(CreateCommentReplyDto comment, int parentId)
        {
            var parent = await _repo.GetByIdAsync(parentId);
            comment.ParentCommentId = parentId;
            await _repo.AddAsync(new Entity.Entities.Comment
            {
                Content = comment.Content,
                CustomerId = comment.CustomerId,
                ParentCommentId = comment.ParentCommentId
            });
        }

        

        public async Task CreateToCar(CommentCreateDto dto, int carId)
        {
            var comment = new Entity.Entities.Comment
            {
                Content = dto.Content,
                Rating = dto.Rating,
                CustomerId = dto.CustomerId,
                CarId = carId
            };
            await _repo.AddAsync(comment);
        }

        public async Task CreateToCompany(CommentCreateDto dto, int companyId)
        {
            var comment = new Entity.Entities.Comment
            {
                Content = dto.Content,
                Rating = dto.Rating,
                CustomerId = dto.CustomerId,
                CompanyId = companyId
            };
            await _repo.AddAsync(comment);
        }

        public async Task DeleteComment(int commentId)
        {
            var comment = await _repo.GetByIdAsync(commentId);
            if (comment != null)
            {
                await _repo.DeleteAsync(comment);
            }
            else
            {
                throw new Exception("Comment not found");
            }
        }

        public async Task<IEnumerable<CommentDto>> GetAll()
        {
            var comments = await _repo.GetAllAsync();
            var dtos = comments.Select(c => new CommentDto
            {
                Id = c.Id,
                Content = c.Content,
                Rating = c.Rating,
                CustomerId = c.CustomerId,
                CustomerFullName = c.Customer.Name + " " + c.Customer.Surname,
                CarId = c.CarId,
                CompanyId = c.CompanyId
            });
            return dtos;
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByCarIdAsync(int carId)
        {
            var comments = await _repo.FindAsync(c => c.CarId == carId);
            return comments.Select(c => new CommentDto
            {
                Id = c.Id,
                Content = c.Content,
                Rating = c.Rating,
                CustomerFullName = c.Customer.Name + " " + c.Customer.Surname,
                CustomerId = c.CustomerId,
                CarId = c.CarId,
                CompanyId = c.CompanyId
            }); 
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByCompanyIdAsync(int companyId)
        {
            var comments = await _repo.FindAsync(c => c.CompanyId == companyId);
            return comments.Select(c => new CommentDto
            {
                Id = c.Id,
                Content = c.Content,
                Rating = c.Rating,
                CustomerId = c.CustomerId,
                CustomerFullName = c.Customer.Name + " " + c.Customer.Surname,
                CarId = c.CarId,
                CompanyId = c.CompanyId
            });
        }

        public async Task<IEnumerable<CommentDto>> GetCommentsByCustomerIdAsync(int customerId)
        {
            var comments = await _repo.FindAsync(c => c.CustomerId == customerId);
            return comments.Select(c => new CommentDto
            {
                Id = c.Id,
                Content = c.Content,
                Rating = c.Rating,
                CustomerId = c.CustomerId,
                CustomerFullName = c.Customer.Name + " " + c.Customer.Surname,
                CarId = c.CarId,
                CompanyId = c.CompanyId
            });
        }

        public async Task<IEnumerable<CommentReplyDto>> GetReplies(int parentCommentId)
        {
            var replies = await _repo.FindAsync(c => c.ParentCommentId == parentCommentId); 
            return replies.Select(c => new CommentReplyDto
            {
               Id = c.Id,
               Content= c.Content,
               CreatedAt = DateTime.UtcNow,
               CustomerName = c.Customer.Name

            });
        }

        public async Task<IEnumerable<CommentReplyDto>> GetRepliesByCustomerIdAsync(int customerId, int parentCommentId)
        {
            var replies = await _repo.FindAsync(c => c.CustomerId == customerId && c.ParentCommentId == parentCommentId);
            return replies.Select(c => new CommentReplyDto
            {
                Id = c.Id,
                Content = c.Content,
                CreatedAt = DateTime.UtcNow,
                CustomerName = c.Customer.Name
            });
        }

        public async Task<IEnumerable<CommentDto>> GetWithReplies(int parentCommentId)
        {
            var replies = await _repo.FindAsync(c => c.ParentCommentId == parentCommentId);
            return replies.Select(c => new CommentDto
            {
                Id = c.Id,
                Content = c.Content,
                Rating = c.Rating,
                CustomerId = c.CustomerId,
                CustomerFullName = c.Customer.Name + " " + c.Customer.Surname,
                CarId = c.CarId,
                CompanyId = c.CompanyId
            });
        }

        public async Task Update(CommentDto dto)
        {
            var comment = new Entity.Entities.Comment
            {
                Id = dto.Id,
                Content = dto.Content,
                Rating = dto.Rating,
                CustomerId = dto.CustomerId,
                CarId = dto.CarId,
                CompanyId = dto.CompanyId
            };
            await _repo.UpdateAsync(comment);
        }

        
    }
}
