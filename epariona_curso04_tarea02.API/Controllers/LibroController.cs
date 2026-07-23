using epariona_curso04_tarea02.Application.Features.Libros.Commands;
using epariona_curso04_tarea02.Application.Features.Libros.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace epariona_curso04_tarea02.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize] // Requerimiento Tarea 06
public class LibroController : ControllerBase
{
    private readonly IMediator _mediator;

    public LibroController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new ObtenerTodosLibrosQuery());
        if (result.IsSuccess)
            return Ok(result.Value);
        return BadRequest(result.ErrorMessage);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new ObtenerLibroQuery(id));
        if (result.IsSuccess)
            return Ok(result.Value);
        return NotFound(result.ErrorMessage);
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] CrearLibroCommand command)
    {
        var result = await _mediator.Send(command);
        if (result.IsSuccess)
            return Ok(result.Value);
        return BadRequest(result.ErrorMessage);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ActualizarLibroCommand command)
    {
        if (id != command.Id)
            return BadRequest("El ID de la ruta no coincide con el del cuerpo.");

        var result = await _mediator.Send(command);
        if (result.IsSuccess)
            return Ok(result.Value);
        return NotFound(result.ErrorMessage);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new EliminarLibroCommand(id));
        if (result.IsSuccess)
            return Ok("Libro eliminado exitosamente");
        return NotFound(result.ErrorMessage);
    }
}
