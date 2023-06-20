using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Dto;
using CleanArchitecture.Domain.Entities;
using MapsterMapper;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DefaultSettings.Commands.Update
{
    public class UpdateDefaultSettingCommand : IRequestWrapper<DefaultSettingDto>
    {
        public int DefaultSettingId { get; set; }
        public string SettingName { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class UpdateDefaultSettingCommandHandler : IRequestHandlerWrapper<UpdateDefaultSettingCommand, DefaultSettingDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateDefaultSettingCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<DefaultSettingDto>> Handle(UpdateDefaultSettingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.DefaultSetting.FindAsync(request.DefaultSettingId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(DefaultSetting), request.DefaultSettingId);
            }
            if (!string.IsNullOrEmpty(request.SettingName))
                entity.SettingName = request.SettingName;

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<DefaultSettingDto>(entity));
        }
    }
}
