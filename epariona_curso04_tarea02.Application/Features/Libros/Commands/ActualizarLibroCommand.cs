using epariona_curso04_tarea02.Domain.Common;
using epariona_curso04_tarea02.Domain.Entities;
using MediatR;

namespace epariona_curso04_tarea02.Application.Features.Libros.Commands;

public record ActualizarLibroCommand(int Id, string Titulo, string Autor, string Isbn, DateTime FechaPublicacion, decimal Precio) : IRequest<Result<Libro>>;

public class ActualizarLibroCommandHandler : IRequestHandler<ActualizarLibroCommand, Result<Libro>>
{
    private readonly IRepository<Libro> _repository;

    public ActualizarLibroCommandHandler(IRepository<Libro> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Libro>> Handle(ActualizarLibroCommand request, CancellationToken cancellationToken)
    {
        var libro = await _repository.GetByIdAsync(request.Id);
        if (libro == null)
            return Result<Libro>.Failure("Libro no encontrado");

        libro.Titulo = request.Titulo;
        libro.Autor = request.Autor;
        libro.Isbn = request.Isbn;
        libro.FechaPublicacion = request.FechaPublicacion;
        libro.Precio = request.Precio;

        await _repository.UpdateAsync(libro);
        return Result<Libro>.Success(libro);
    }
}
