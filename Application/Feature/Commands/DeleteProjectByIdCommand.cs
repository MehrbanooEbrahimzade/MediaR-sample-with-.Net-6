using Application.Interfaces;
using Application.Tools;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Feature.Commands
{
    public class DeleteProjectByIdCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public class DeleteProjectByIdCommandHandler : IRequestHandler<DeleteProjectByIdCommand, Guid>
        {
            private readonly IApplicationDbContext _context;

            public DeleteProjectByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(DeleteProjectByIdCommand command, CancellationToken cancellationToken)
            {
                var project =
                    await _context.Projects.FirstOrDefaultAsync(p => p.Id == command.Id,
                        cancellationToken: cancellationToken);
                project.IsNull();
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
                return project.Id;
            }
        }

    }
}
