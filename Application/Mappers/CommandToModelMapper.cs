using Application.Feature.Commands;
using Domain.Entities;

namespace Application.Mappers
{
    public static class CommandToModelMapper
    {

        public static Project ToModel(this CreateProjectCommand command)
        {
            return new Project(command.Title, command.About);
        }

    }
}
