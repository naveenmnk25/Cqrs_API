using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DefaultSettings.Queries.GetDefaultSettings
{
    public class GetDefaultSettingQuery : IRequestWrapper<List<DefaultSettingDto>>
    {
        public int? DefaultSettingId { get; set; }
    }

    public class GetDefaultSettingQueryHandler : IRequestHandlerWrapper<GetDefaultSettingQuery, List<DefaultSettingDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetDefaultSettingQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<DefaultSettingDto>>> Handle(GetDefaultSettingQuery request, CancellationToken cancellationToken)
        {
            List<DefaultSettingDto> list = await _context.DefaultSetting
                .ProjectToType<DefaultSettingDto>(_mapper.Config)
                .ToListAsync(cancellationToken);

            return list.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<List<DefaultSettingDto>>(ServiceError.NotFound);
        }
    }
}
