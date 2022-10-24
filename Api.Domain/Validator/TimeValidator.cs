using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Services.Time;
using FluentValidation;
using System.Linq;
using System.Collections.Generic;

namespace Domain.Validator
{
    public class TimeValidator : AbstractValidator<TimeEntity>
    {
        private ITimeService _service;

        public TimeValidator(ITimeService service)
        {
            _service = service;

            RuleFor(time => time.name)
                .NotNull().WithMessage("name não deve ser nulo")
                .MinimumLength(3);
            RuleFor(time => time.name).MustAsync(IsNameUnique).WithMessage("name deve ser único, já existe um time cadastrado com esse name");
        }

        private async Task<bool> IsNameUnique(string name, CancellationToken arg2)
        {
            var times = await _service.FindAll(name);
            return !times.Any(x => x.name == name);
        }
    }
}
