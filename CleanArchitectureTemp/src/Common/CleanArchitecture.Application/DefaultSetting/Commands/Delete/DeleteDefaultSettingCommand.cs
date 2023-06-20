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

namespace CleanArchitecture.Application.DefaultSettings.Commands.Delete
{
    public class DeleteDefaultSettingCommand : IRequestWrapper<DefaultSettingDto>
    {
        public int Id { get; set; }
    }

    public class DeleteDefaultSettingCommandHandler : IRequestHandlerWrapper<DeleteDefaultSettingCommand, DefaultSettingDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DeleteDefaultSettingCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<DefaultSettingDto>> Handle(DeleteDefaultSettingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.DefaultSetting
                .Where(l => l.DefaultSettingId == request.Id)
                .SingleOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(DefaultSetting), request.Id);
            }

            _context.DefaultSetting.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<DefaultSettingDto>(entity));
        }
    }
}
