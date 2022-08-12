using Application.Feature.Commands;
using Application.Feature.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ProjectsController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllProjectsQuery()));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await Mediator.Send(new GetProjectByIdQuery { Id = id }));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await Mediator.Send(new DeleteProjectByIdCommand { Id = id }));
        }
        
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateProjectCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}