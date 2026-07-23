using epariona_curso04_tarea02.Domain.Common;
using epariona_curso04_tarea02.Domain.Entities;
using MediatR;

namespace epariona_curso04_tarea02.Application.Features.Libros.Commands;

public record CrearLibroCommand(string Titulo, string Autor, string Isbn, DateTime FechaPublicacion, decimal Precio) : IRequest<Result<Libro>>;

public class CrearLibroCommandHandler : IRequestHandler<CrearLibroCommand, Result<Libro>>
{
    private readonly IRepository<Libro> _repository;

    public CrearLibroCommandHandler(IRepository<Libro> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Libro>> Handle(CrearLibroCommand request, CancellationToken cancellationToken)
    {
        var libro = new Libro
        {
            Titulo = request.Titulo,
            Autor = request.Autor,
            Isbn = request.Isbn,
            FechaPublicacion = request.FechaPublicacion,
            Precio = request.Precio
        };

        var result = await _repository.AddAsync(libro);
        return Result<Libro>.Success(result);
    }
}
