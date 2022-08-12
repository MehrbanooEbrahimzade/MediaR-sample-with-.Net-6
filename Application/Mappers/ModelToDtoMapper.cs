using Application.Feature.Dtos;
using Domain.Entities;

namespace Application.Mappers
{
    public  static class ModelToDtoMapper
    {
        
        public static ShowProjectDto ToDto(this Project project)
        {
            return new ShowProjectDto()
            {
                Id = project.Id,
                Title = project.Title,
                About = project.About
            };
        }

        public static List<ShowProjectDto> ToDto(this List<Project> projects)
        {
            return projects.Select(p => new ShowProjectDto
            {
                Id = p.Id,
                Title = p.Title,
                About = p.About
            }).ToList();
        }
    }
}
