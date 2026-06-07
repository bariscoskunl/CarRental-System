using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Business.DTOs.Comment
{
    public class CreateCommentReplyDto
    {
        public string Content { get; set; }
        public int CustomerId { get; set; }
        public int ParentCommentId { get; set; } // Hangi yoruma yanıt
    }
}
