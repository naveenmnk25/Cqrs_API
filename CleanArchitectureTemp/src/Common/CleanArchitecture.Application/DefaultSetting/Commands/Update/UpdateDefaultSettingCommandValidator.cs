using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.DefaultSettings.Commands.Update;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Cities.Commands.Update
{
    public class UpdateDefaultSettingCommandValidator : AbstractValidator<UpdateDefaultSettingCommand>
    {
        private readonly IApplicationDbContext _context;
        public UpdateDefaultSettingCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.SettingName)
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

            RuleFor(v => v.DefaultSettingId).NotNull();
        }

        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.DefaultSetting.AllAsync(x => x.SettingName != name, cancellationToken);
        }
    }
}
