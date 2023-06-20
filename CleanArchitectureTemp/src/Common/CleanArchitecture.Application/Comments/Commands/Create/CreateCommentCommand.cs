using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Dto;
using CleanArchitecture.Domain.Entities;
using MapsterMapper;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Cities.Commands.Create
{
    public class CreateCommentCommand : IRequestWrapper<CommentDto>
    {
        public int CommentId { get; set; }
        public int TaskId { get; set; }
        public string Comments { get; set; }
    }

    public class CreateCommentCommandHandler : IRequestHandlerWrapper<CreateCommentCommand, CommentDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CommentDto>> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = new Comment
            {
                CommentId = request.CommentId,
                TaskId = request.TaskId,
                Comments = request.Comments
            };

            //entity.DomainEvents.Add(new CommentCreatedEvent(entity));

            await _context.Comment.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<CommentDto>(entity));
        }
    }
}
