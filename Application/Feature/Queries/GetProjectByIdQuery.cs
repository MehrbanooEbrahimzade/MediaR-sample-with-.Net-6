using Application.Interfaces;
using Application.Tools;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Feature.Queries
{
    public class GetProjectByIdQuery : IRequest<Project>
    {
        public Guid Id { get; set; }

        public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Project>
        {
            private readonly IApplicationDbContext _context;

            public GetProjectByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Project> Handle(GetProjectByIdQuery query, CancellationToken cancellationToken)
            {
                var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == query.Id,
                        cancellationToken: cancellationToken);
                project.IsNull();
                return project;
            }
        }
    }
}
