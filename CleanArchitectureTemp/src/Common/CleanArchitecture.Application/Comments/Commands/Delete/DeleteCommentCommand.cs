using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Dto;
using CleanArchitecture.Domain.Entities;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Comments.Commands.Delete
{
    public class DeleteCommentCommand : IRequestWrapper<CommentDto>
    {
        public int Id { get; set; }
    }

    public class DeleteCommentCommandHandler : IRequestHandlerWrapper<DeleteCommentCommand, CommentDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteCommentCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CommentDto>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Comment
                .Where(l => l.CommentId == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Comment), request.Id);
            }

            _context.Comment.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<CommentDto>(entity));
        }
    }
}
