using Application.Interfaces;
using Application.Mappers;
using Application.Tools;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Feature.Commands
{
    public class UpdateProjectCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string About { get; set; }


        public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Guid>
        {
            private readonly IApplicationDbContext _context;

            public UpdateProjectCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(UpdateProjectCommand command, CancellationToken cancellationToken)
            {
                var project = await _context.Projects.FirstOrDefaultAsync(a => a.Id == command.Id,
                        cancellationToken: cancellationToken);
                project.IsNull();
                project.UpdateProject(command.Title, command.About);

                var a = project;

                await _context.SaveChangesAsync();

                return project.Id;

            }
        }
    }
}
