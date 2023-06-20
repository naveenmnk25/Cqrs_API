using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Dto;
using CleanArchitecture.Domain.Entities;
using MapsterMapper;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Cities.Commands.Create
{
    public class CreateDefaultSettingCommand : IRequestWrapper<DefaultSettingDto>
    {
        public int DefaultSettingId { get; set; }
        public string SettingName { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class CreateDefaultSettingCommandHandler : IRequestHandlerWrapper<CreateDefaultSettingCommand, DefaultSettingDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateDefaultSettingCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<DefaultSettingDto>> Handle(CreateDefaultSettingCommand request, CancellationToken cancellationToken)
        {
            var entity = new DefaultSetting
            {
                SettingName = request.SettingName,
                Description = request.Description,
                Type = request.Type,
                Value = request.Value
            };

            //entity.DomainEvents.Add(new DefaultSettingCreatedEvent(entity));

            await _context.DefaultSetting.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<DefaultSettingDto>(entity));
        }
    }
}
