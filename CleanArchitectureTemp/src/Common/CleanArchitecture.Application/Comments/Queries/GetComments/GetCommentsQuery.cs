using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Comments.Queries.GetComments
{
    public class GetCommentsQuery : IRequestWrapper<List<DeveloperDto>>
    {

    }

    public class GetCommentsQueryHandler : IRequestHandlerWrapper<GetCommentsQuery, List<DeveloperDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCommentsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<DeveloperDto>>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            List<DeveloperDto> list = await _context.Comment
                .ProjectToType<DeveloperDto>(_mapper.Config)
                .ToListAsync(cancellationToken);

            return list.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<List<DeveloperDto>>(ServiceError.NotFound);
        }
    }
}
