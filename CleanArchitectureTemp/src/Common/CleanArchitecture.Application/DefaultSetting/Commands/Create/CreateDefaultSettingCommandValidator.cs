using CleanArchitecture.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Cities.Commands.Create
{
    public class CreateDefaultSettingCommandValidator : AbstractValidator<CreateDefaultSettingCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateDefaultSettingCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.SettingName)
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.")
                .MustAsync(BeUniqueName).WithMessage("The specified DefaultSetting already exists.")
                .NotEmpty().WithMessage("Name is required.");
        }

        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            //TODO: Control by uppercase and CultureInfo
            return await _context.DefaultSetting.AllAsync(x => x.SettingName != name, cancellationToken);
        }
    }
}
