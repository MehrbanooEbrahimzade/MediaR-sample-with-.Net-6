using Application.Interfaces;
using Application.Mappers;
using MediatR;

namespace Application.Feature.Commands
{
    public class CreateProjectCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string About { get; set; }

        public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
        {
            private readonly IApplicationDbContext _context;

            public CreateProjectCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(CreateProjectCommand command, CancellationToken cancellationToken)
            {
                var project = new Domain.Entities.Project(command.Title, command.About);

                _context.Projects.Add(project);
                await _context.SaveChangesAsync();
                return project.Id;
            }
        }

    }
}