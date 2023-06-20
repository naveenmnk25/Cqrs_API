using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Dto;
using CleanArchitecture.Domain.Entities;
using MapsterMapper;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Comments.Commands.Update
{
    public class UpdateCommentCommand : IRequestWrapper<CommentDto>
    {
        public int CommentId { get; set; }
        public int TaskId { get; set; }
        public string Comments { get; set; }
    }

    public class UpdateCommentCommandHandler : IRequestHandlerWrapper<UpdateCommentCommand, CommentDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateCommentCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CommentDto>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Comment.FindAsync(request.CommentId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Comment), request.CommentId);
            }
            entity.Comments = request.Comments;
            entity.TaskId = request.TaskId;
            await _context.SaveChangesAsync(cancellationToken);
            return ServiceResult.Success(_mapper.Map<CommentDto>(entity));
        }
    }
}
