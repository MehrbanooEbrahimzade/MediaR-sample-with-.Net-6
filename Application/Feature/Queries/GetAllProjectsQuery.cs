using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Feature.Queries
{
    public class GetAllProjectsQuery : IRequest<IEnumerable<Project>>
    {

        public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IEnumerable<Project>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllProjectsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Project>> Handle(GetAllProjectsQuery query, CancellationToken cancellationToken)
            {
                var projectList = await _context.Projects.ToListAsync(cancellationToken: cancellationToken);
                return projectList.AsReadOnly();
            }
        }
    }
}
