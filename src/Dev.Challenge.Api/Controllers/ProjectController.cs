using Dev.Challenge.Domain.Abstractions;
using Dev.Challenge.Domain.Commands.Project;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Challenge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMediator _mediator;

        public ProjectController(IProjectRepository projectRepository, IMediator mediator)
        {
            _projectRepository = projectRepository;
            _mediator = mediator;
        }

        [HttpPost("projeto")]
        public async Task<IActionResult> CreateEntrie([FromBody] ProjectRequest command)
        {
            var cancelSource = new CancellationTokenSource();
            var result = await _mediator.Send(new ProjectCommand(command.Name, command.Description), cancelSource.Token);

            return Ok(result);
        }

        [HttpGet("projeto/todos")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _projectRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("projeto/{id}")]
        public async Task<IActionResult> ProdutoDetalhe(Guid id)
        {
            var result = await _projectRepository.GetById(id);
            return result == null ? NotFound() : Ok(result);
        }
    }
}
